using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbBaseLayoutPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbBaseLayoutPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBaseLayoutPE_1();

	public delegate void SwigDelegateOdDbBaseLayoutPE_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseLayoutPE_3(IntPtr arg0);

	public delegate bool SwigDelegateOdDbBaseLayoutPE_4(IntPtr arg0);

	public delegate bool SwigDelegateOdDbBaseLayoutPE_5(IntPtr arg0);

	public delegate bool SwigDelegateOdDbBaseLayoutPE_6(IntPtr arg0);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseLayoutPE_7(IntPtr arg0);

	public delegate void SwigDelegateOdDbBaseLayoutPE_8(IntPtr arg0, double paperWidth, double paperHeight);

	public delegate int SwigDelegateOdDbBaseLayoutPE_9(IntPtr arg0);

	public delegate double SwigDelegateOdDbBaseLayoutPE_10(IntPtr arg0);

	public delegate double SwigDelegateOdDbBaseLayoutPE_11(IntPtr arg0);

	public delegate double SwigDelegateOdDbBaseLayoutPE_12(IntPtr arg0);

	public delegate double SwigDelegateOdDbBaseLayoutPE_13(IntPtr arg0);

	public delegate bool SwigDelegateOdDbBaseLayoutPE_14(IntPtr arg0);

	public delegate int SwigDelegateOdDbBaseLayoutPE_15(IntPtr arg0, IntPtr ext);

	public delegate bool SwigDelegateOdDbBaseLayoutPE_16(IntPtr arg0);

	public delegate void SwigDelegateOdDbBaseLayoutPE_17(IntPtr arg0, double scale);

	public delegate void SwigDelegateOdDbBaseLayoutPE_18(IntPtr arg0, double numerator, double denominator);

	public delegate int SwigDelegateOdDbBaseLayoutPE_19(IntPtr arg0);

	public delegate int SwigDelegateOdDbBaseLayoutPE_20(IntPtr arg0, OdDbBaseLayoutPE_PlotType arg1);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseLayoutPE_21(IntPtr arg0);

	public delegate void SwigDelegateOdDbBaseLayoutPE_22(IntPtr arg0, double xmin, double ymin, double xmax, double ymax);

	public delegate void SwigDelegateOdDbBaseLayoutPE_23(IntPtr arg0, double x, double y);

	public delegate void SwigDelegateOdDbBaseLayoutPE_24(IntPtr arg0, double paperWidth, double paperHeight);

	public delegate int SwigDelegateOdDbBaseLayoutPE_25(IntPtr arg0);

	public delegate int SwigDelegateOdDbBaseLayoutPE_26(IntPtr arg0, OdDbBaseLayoutPE_PlotPaperUnits arg1);

	public delegate IntPtr SwigDelegateOdDbBaseLayoutPE_27(IntPtr arg0);

	public delegate bool SwigDelegateOdDbBaseLayoutPE_28(IntPtr arg0);

	public delegate bool SwigDelegateOdDbBaseLayoutPE_29(IntPtr arg0, IntPtr extMin, IntPtr extMax);

	public delegate int SwigDelegateOdDbBaseLayoutPE_30(IntPtr arg0, OdDbBaseLayoutPE_StdScaleType arg1);

	public delegate bool SwigDelegateOdDbBaseLayoutPE_31(IntPtr arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBaseLayoutPE_0 swigDelegate0;

	private SwigDelegateOdDbBaseLayoutPE_1 swigDelegate1;

	private SwigDelegateOdDbBaseLayoutPE_2 swigDelegate2;

	private SwigDelegateOdDbBaseLayoutPE_3 swigDelegate3;

	private SwigDelegateOdDbBaseLayoutPE_4 swigDelegate4;

	private SwigDelegateOdDbBaseLayoutPE_5 swigDelegate5;

	private SwigDelegateOdDbBaseLayoutPE_6 swigDelegate6;

	private SwigDelegateOdDbBaseLayoutPE_7 swigDelegate7;

	private SwigDelegateOdDbBaseLayoutPE_8 swigDelegate8;

	private SwigDelegateOdDbBaseLayoutPE_9 swigDelegate9;

	private SwigDelegateOdDbBaseLayoutPE_10 swigDelegate10;

	private SwigDelegateOdDbBaseLayoutPE_11 swigDelegate11;

	private SwigDelegateOdDbBaseLayoutPE_12 swigDelegate12;

	private SwigDelegateOdDbBaseLayoutPE_13 swigDelegate13;

	private SwigDelegateOdDbBaseLayoutPE_14 swigDelegate14;

	private SwigDelegateOdDbBaseLayoutPE_15 swigDelegate15;

	private SwigDelegateOdDbBaseLayoutPE_16 swigDelegate16;

	private SwigDelegateOdDbBaseLayoutPE_17 swigDelegate17;

	private SwigDelegateOdDbBaseLayoutPE_18 swigDelegate18;

	private SwigDelegateOdDbBaseLayoutPE_19 swigDelegate19;

	private SwigDelegateOdDbBaseLayoutPE_20 swigDelegate20;

	private SwigDelegateOdDbBaseLayoutPE_21 swigDelegate21;

	private SwigDelegateOdDbBaseLayoutPE_22 swigDelegate22;

	private SwigDelegateOdDbBaseLayoutPE_23 swigDelegate23;

	private SwigDelegateOdDbBaseLayoutPE_24 swigDelegate24;

	private SwigDelegateOdDbBaseLayoutPE_25 swigDelegate25;

	private SwigDelegateOdDbBaseLayoutPE_26 swigDelegate26;

	private SwigDelegateOdDbBaseLayoutPE_27 swigDelegate27;

	private SwigDelegateOdDbBaseLayoutPE_28 swigDelegate28;

	private SwigDelegateOdDbBaseLayoutPE_29 swigDelegate29;

	private SwigDelegateOdDbBaseLayoutPE_30 swigDelegate30;

	private SwigDelegateOdDbBaseLayoutPE_31 swigDelegate31;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGeExtents3d)
	};

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes17 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes18 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes20 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbBaseLayoutPE_PlotType).MakeByRefType()
	};

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes22 = new Type[5]
	{
		typeof(OdRxObject),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes23 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes24 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes26 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbBaseLayoutPE_PlotPaperUnits).MakeByRefType()
	};

	private static Type[] swigMethodTypes27 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes29 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes30 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbBaseLayoutPE_StdScaleType).MakeByRefType()
	};

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBaseLayoutPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBaseLayoutPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbBaseLayoutPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBaseLayoutPE cast(OdRxObject pObj)
	{
		OdDbBaseLayoutPE rXObject = Helpers.GetRXObject<OdDbBaseLayoutPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_isASwigExplicitOdDbBaseLayoutPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_queryXSwigExplicitOdDbBaseLayoutPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseLayoutPE createObject()
	{
		OdDbBaseLayoutPE rXObject = Helpers.GetRXObject<OdDbBaseLayoutPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string name(OdRxObject arg0)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_name(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isModelLayout(OdRxObject arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_isModelLayout(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool printLineweights(OdRxObject arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_printLineweights(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool showPlotStyles(OdRxObject arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_showPlotStyles(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string paperName(OdRxObject arg0)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_paperName(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getPaperSize(OdRxObject arg0, out double paperWidth, out double paperHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getPaperSize(swigCPtr, OdRxObject.getCPtr(arg0), out paperWidth, out paperHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbBaseLayoutPE_PlotRotation plotRotation(OdRxObject arg0)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_plotRotation(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbBaseLayoutPE_PlotRotation)result;
	}

	public virtual double getTopMargin(OdRxObject arg0)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getTopMargin(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getRightMargin(OdRxObject arg0)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getRightMargin(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getBottomMargin(OdRxObject arg0)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getBottomMargin(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getLeftMargin(OdRxObject arg0)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getLeftMargin(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isOverallVPortErased(OdRxObject arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_isOverallVPortErased(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getGeomExtents(OdRxObject arg0, OdGeExtents3d ext)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getGeomExtents(swigCPtr, OdRxObject.getCPtr(arg0), OdGeExtents3d.getCPtr(ext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool useStandardScale(OdRxObject arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_useStandardScale(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getStdScale(OdRxObject arg0, out double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getStdScale(swigCPtr, OdRxObject.getCPtr(arg0), out scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getCustomPrintScale(OdRxObject arg0, out double numerator, out double denominator)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getCustomPrintScale(swigCPtr, OdRxObject.getCPtr(arg0), out numerator, out denominator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int plotType(OdRxObject arg0)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_plotType(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getPlotType(OdRxObject arg0, out OdDbBaseLayoutPE_PlotType arg1)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getPlotType(swigCPtr, OdRxObject.getCPtr(arg0), out arg1);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual string getPlotViewName(OdRxObject arg0)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getPlotViewName(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getPlotWindowArea(OdRxObject arg0, out double xmin, out double ymin, out double xmax, out double ymax)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getPlotWindowArea(swigCPtr, OdRxObject.getCPtr(arg0), out xmin, out ymin, out xmax, out ymax);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getPlotOrigin(OdRxObject arg0, out double x, out double y)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getPlotOrigin(swigCPtr, OdRxObject.getCPtr(arg0), out x, out y);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getPlotPaperSize(OdRxObject arg0, out double paperWidth, out double paperHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getPlotPaperSize(swigCPtr, OdRxObject.getCPtr(arg0), out paperWidth, out paperHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int plotPaperUnits(OdRxObject arg0)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_plotPaperUnits(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getPlotPaperUnits(OdRxObject arg0, out OdDbBaseLayoutPE_PlotPaperUnits arg1)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getPlotPaperUnits(swigCPtr, OdRxObject.getCPtr(arg0), out arg1);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbStub getBlockId(OdRxObject arg0)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getBlockId(swigCPtr, OdRxObject.getCPtr(arg0));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool scalePSLinetypes(OdRxObject arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_scalePSLinetypes(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getApproxExtents(OdRxObject arg0, OdGePoint3d extMin, OdGePoint3d extMax)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getApproxExtents(swigCPtr, OdRxObject.getCPtr(arg0), OdGePoint3d.getCPtr(extMin), OdGePoint3d.getCPtr(extMax));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getStdScaleType(OdRxObject arg0, out OdDbBaseLayoutPE_StdScaleType arg1)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getStdScaleType(swigCPtr, OdRxObject.getCPtr(arg0), out arg1);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool scaleLineweights(OdRxObject arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_scaleLineweights(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbBaseLayoutPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseLayoutPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbBaseLayoutPE) != GetType();
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
		if (SwigDerivedClassHasMethod("name", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodname;
		}
		if (SwigDerivedClassHasMethod("isModelLayout", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisModelLayout;
		}
		if (SwigDerivedClassHasMethod("printLineweights", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodprintLineweights;
		}
		if (SwigDerivedClassHasMethod("showPlotStyles", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodshowPlotStyles;
		}
		if (SwigDerivedClassHasMethod("paperName", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodpaperName;
		}
		if (SwigDerivedClassHasMethod("getPaperSize", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetPaperSize;
		}
		if (SwigDerivedClassHasMethod("plotRotation", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodplotRotation;
		}
		if (SwigDerivedClassHasMethod("getTopMargin", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetTopMargin;
		}
		if (SwigDerivedClassHasMethod("getRightMargin", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetRightMargin;
		}
		if (SwigDerivedClassHasMethod("getBottomMargin", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetBottomMargin;
		}
		if (SwigDerivedClassHasMethod("getLeftMargin", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetLeftMargin;
		}
		if (SwigDerivedClassHasMethod("isOverallVPortErased", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodisOverallVPortErased;
		}
		if (SwigDerivedClassHasMethod("getGeomExtents", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetGeomExtents;
		}
		if (SwigDerivedClassHasMethod("useStandardScale", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethoduseStandardScale;
		}
		if (SwigDerivedClassHasMethod("getStdScale", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetStdScale;
		}
		if (SwigDerivedClassHasMethod("getCustomPrintScale", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetCustomPrintScale;
		}
		if (SwigDerivedClassHasMethod("plotType", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodplotType;
		}
		if (SwigDerivedClassHasMethod("getPlotType", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodgetPlotType;
		}
		if (SwigDerivedClassHasMethod("getPlotViewName", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodgetPlotViewName;
		}
		if (SwigDerivedClassHasMethod("getPlotWindowArea", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodgetPlotWindowArea;
		}
		if (SwigDerivedClassHasMethod("getPlotOrigin", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodgetPlotOrigin;
		}
		if (SwigDerivedClassHasMethod("getPlotPaperSize", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodgetPlotPaperSize;
		}
		if (SwigDerivedClassHasMethod("plotPaperUnits", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodplotPaperUnits;
		}
		if (SwigDerivedClassHasMethod("getPlotPaperUnits", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodgetPlotPaperUnits;
		}
		if (SwigDerivedClassHasMethod("getBlockId", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodgetBlockId;
		}
		if (SwigDerivedClassHasMethod("scalePSLinetypes", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodscalePSLinetypes;
		}
		if (SwigDerivedClassHasMethod("getApproxExtents", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodgetApproxExtents;
		}
		if (SwigDerivedClassHasMethod("getStdScaleType", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodgetStdScaleType;
		}
		if (SwigDerivedClassHasMethod("scaleLineweights", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodscaleLineweights;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLayoutPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBaseLayoutPE));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodname(IntPtr arg0)
	{
		return name(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisModelLayout(IntPtr arg0)
	{
		return isModelLayout(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodprintLineweights(IntPtr arg0)
	{
		return printLineweights(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodshowPlotStyles(IntPtr arg0)
	{
		return showPlotStyles(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodpaperName(IntPtr arg0)
	{
		return paperName(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodgetPaperSize(IntPtr arg0, double paperWidth, double paperHeight)
	{
		try
		{
			getPaperSize(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), out paperWidth, out paperHeight);
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

	private int SwigDirectorMethodplotRotation(IntPtr arg0)
	{
		return (int)plotRotation(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private double SwigDirectorMethodgetTopMargin(IntPtr arg0)
	{
		return getTopMargin(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private double SwigDirectorMethodgetRightMargin(IntPtr arg0)
	{
		return getRightMargin(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private double SwigDirectorMethodgetBottomMargin(IntPtr arg0)
	{
		return getBottomMargin(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private double SwigDirectorMethodgetLeftMargin(IntPtr arg0)
	{
		return getLeftMargin(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisOverallVPortErased(IntPtr arg0)
	{
		return isOverallVPortErased(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodgetGeomExtents(IntPtr arg0, IntPtr ext)
	{
		return (int)getGeomExtents(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), new OdGeExtents3d(ext, cMemoryOwn: false));
	}

	private bool SwigDirectorMethoduseStandardScale(IntPtr arg0)
	{
		return useStandardScale(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodgetStdScale(IntPtr arg0, double scale)
	{
		try
		{
			getStdScale(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), out scale);
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

	private void SwigDirectorMethodgetCustomPrintScale(IntPtr arg0, double numerator, double denominator)
	{
		try
		{
			getCustomPrintScale(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), out numerator, out denominator);
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

	private int SwigDirectorMethodplotType(IntPtr arg0)
	{
		return plotType(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodgetPlotType(IntPtr arg0, OdDbBaseLayoutPE_PlotType arg1)
	{
		return (int)getPlotType(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), out arg1);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetPlotViewName(IntPtr arg0)
	{
		return getPlotViewName(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodgetPlotWindowArea(IntPtr arg0, double xmin, double ymin, double xmax, double ymax)
	{
		try
		{
			getPlotWindowArea(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), out xmin, out ymin, out xmax, out ymax);
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

	private void SwigDirectorMethodgetPlotOrigin(IntPtr arg0, double x, double y)
	{
		try
		{
			getPlotOrigin(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), out x, out y);
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

	private void SwigDirectorMethodgetPlotPaperSize(IntPtr arg0, double paperWidth, double paperHeight)
	{
		try
		{
			getPlotPaperSize(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), out paperWidth, out paperHeight);
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

	private int SwigDirectorMethodplotPaperUnits(IntPtr arg0)
	{
		return plotPaperUnits(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodgetPlotPaperUnits(IntPtr arg0, OdDbBaseLayoutPE_PlotPaperUnits arg1)
	{
		return (int)getPlotPaperUnits(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), out arg1);
	}

	private IntPtr SwigDirectorMethodgetBlockId(IntPtr arg0)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getBlockId(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private bool SwigDirectorMethodscalePSLinetypes(IntPtr arg0)
	{
		return scalePSLinetypes(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodgetApproxExtents(IntPtr arg0, IntPtr extMin, IntPtr extMax)
	{
		return getApproxExtents(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(extMin, cMemoryOwn: false), new OdGePoint3d(extMax, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetStdScaleType(IntPtr arg0, OdDbBaseLayoutPE_StdScaleType arg1)
	{
		return (int)getStdScaleType(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), out arg1);
	}

	private bool SwigDirectorMethodscaleLineweights(IntPtr arg0)
	{
		return scaleLineweights(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false));
	}
}

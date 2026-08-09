using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiLinetyper : OdGiConveyorNode
{
	public delegate IntPtr SwigDelegateOdGiLinetyper_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiLinetyper_1();

	public delegate void SwigDelegateOdGiLinetyper_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiLinetyper_3();

	public delegate IntPtr SwigDelegateOdGiLinetyper_4();

	public delegate void SwigDelegateOdGiLinetyper_5(IntPtr pDrawCtx);

	public delegate void SwigDelegateOdGiLinetyper_6(IntPtr deviations);

	public delegate void SwigDelegateOdGiLinetyper_7(IntPtr pDeviation);

	public delegate uint SwigDelegateOdGiLinetyper_8(IntPtr id, double scale, double generationCriteria, double dScaleForNonScalableLineStyles);

	public delegate uint SwigDelegateOdGiLinetyper_9(IntPtr id, double scale, double generationCriteria);

	public delegate uint SwigDelegateOdGiLinetyper_10(IntPtr id, double scale);

	public delegate IntPtr SwigDelegateOdGiLinetyper_11();

	public delegate void SwigDelegateOdGiLinetyper_12();

	public delegate bool SwigDelegateOdGiLinetyper_13();

	public delegate void SwigDelegateOdGiLinetyper_14();

	public delegate void SwigDelegateOdGiLinetyper_15(bool bAnalytic);

	public delegate bool SwigDelegateOdGiLinetyper_16();

	public delegate void SwigDelegateOdGiLinetyper_17(bool bAnalytic);

	public delegate bool SwigDelegateOdGiLinetyper_18();

	public delegate void SwigDelegateOdGiLinetyper_19(bool bEnable);

	public delegate bool SwigDelegateOdGiLinetyper_20();

	public delegate IntPtr SwigDelegateOdGiLinetyper_21();

	public delegate void SwigDelegateOdGiLinetyper_22();

	public delegate void SwigDelegateOdGiLinetyper_23();

	public delegate bool SwigDelegateOdGiLinetyper_24();

	public delegate void SwigDelegateOdGiLinetyper_25();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiLinetyper_0 swigDelegate0;

	private SwigDelegateOdGiLinetyper_1 swigDelegate1;

	private SwigDelegateOdGiLinetyper_2 swigDelegate2;

	private SwigDelegateOdGiLinetyper_3 swigDelegate3;

	private SwigDelegateOdGiLinetyper_4 swigDelegate4;

	private SwigDelegateOdGiLinetyper_5 swigDelegate5;

	private SwigDelegateOdGiLinetyper_6 swigDelegate6;

	private SwigDelegateOdGiLinetyper_7 swigDelegate7;

	private SwigDelegateOdGiLinetyper_8 swigDelegate8;

	private SwigDelegateOdGiLinetyper_9 swigDelegate9;

	private SwigDelegateOdGiLinetyper_10 swigDelegate10;

	private SwigDelegateOdGiLinetyper_11 swigDelegate11;

	private SwigDelegateOdGiLinetyper_12 swigDelegate12;

	private SwigDelegateOdGiLinetyper_13 swigDelegate13;

	private SwigDelegateOdGiLinetyper_14 swigDelegate14;

	private SwigDelegateOdGiLinetyper_15 swigDelegate15;

	private SwigDelegateOdGiLinetyper_16 swigDelegate16;

	private SwigDelegateOdGiLinetyper_17 swigDelegate17;

	private SwigDelegateOdGiLinetyper_18 swigDelegate18;

	private SwigDelegateOdGiLinetyper_19 swigDelegate19;

	private SwigDelegateOdGiLinetyper_20 swigDelegate20;

	private SwigDelegateOdGiLinetyper_21 swigDelegate21;

	private SwigDelegateOdGiLinetyper_22 swigDelegate22;

	private SwigDelegateOdGiLinetyper_23 swigDelegate23;

	private SwigDelegateOdGiLinetyper_24 swigDelegate24;

	private SwigDelegateOdGiLinetyper_25 swigDelegate25;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGiConveyorContext) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDoubleArray) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGiDeviation) };

	private static Type[] swigMethodTypes8 = new Type[4]
	{
		typeof(OdDbStub),
		typeof(double),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes9 = new Type[3]
	{
		typeof(OdDbStub),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(double)
	};

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[0];

	private static Type[] swigMethodTypes25 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiLinetyper(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiLinetyper obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiLinetyper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiLinetyper cast(OdRxObject pObj)
	{
		OdGiLinetyper rXObject = Helpers.GetRXObject<OdGiLinetyper>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_isASwigExplicitOdGiLinetyper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_queryXSwigExplicitOdGiLinetyper(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiLinetyper createObject()
	{
		OdGiLinetyper rXObject = Helpers.GetRXObject<OdGiLinetyper>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setDrawContext(OdGiConveyorContext pDrawCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_setDrawContext(swigCPtr, pDrawCtx.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviation(OdDoubleArray deviations)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_setDeviation__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(deviations).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviation(OdGiDeviation pDeviation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_setDeviation__SWIG_1(swigCPtr, pDeviation.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint setLinetype(OdDbStub id, double scale, double generationCriteria, double dScaleForNonScalableLineStyles)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_setLinetype__SWIG_0(swigCPtr, OdDbStub.getCPtr(id), scale, generationCriteria, dScaleForNonScalableLineStyles);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint setLinetype(OdDbStub id, double scale, double generationCriteria)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_setLinetype__SWIG_1(swigCPtr, OdDbStub.getCPtr(id), scale, generationCriteria);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint setLinetype(OdDbStub id, double scale)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_setLinetype__SWIG_2(swigCPtr, OdDbStub.getCPtr(id), scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiLinetypeTraits linetypeTraits()
	{
		OdGiLinetypeTraits rXObject = Helpers.GetRXObject<OdGiLinetypeTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_linetypeTraits(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void enable()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_enable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool enabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_enabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void disable()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_disable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setAnalyticLinetypingCircles(bool bAnalytic)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_setAnalyticLinetypingCircles(swigCPtr, bAnalytic);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isAnalyticLinetypingCircles()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_isAnalyticLinetypingCircles(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAnalyticLinetypingComplexCurves(bool bAnalytic)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_setAnalyticLinetypingComplexCurves(swigCPtr, bAnalytic);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isAnalyticLinetypingComplexCurves()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_isAnalyticLinetypingComplexCurves(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOriginalSelectionGeometryOutput(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_setOriginalSelectionGeometryOutput(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isOriginalSelectionGeometryOutputEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_isOriginalSelectionGeometryOutputEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiConveyorGeometry redirectionGeometry()
	{
		OdGiConveyorGeometry_Internal result = new OdGiConveyorGeometry_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_redirectionGeometry(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void enableCache()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_enableCache(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void disableCache()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_disableCache(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool cacheEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_cacheEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void clearCache()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_clearCache(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiLinetyper()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiLinetyper(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiLinetyper) != GetType();
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
		if (SwigDerivedClassHasMethod("input", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodinput;
		}
		if (SwigDerivedClassHasMethod("output", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodoutput;
		}
		if (SwigDerivedClassHasMethod("setDrawContext", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetDrawContext;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetDeviation__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetDeviation__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetLinetype__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetLinetype__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetLinetype__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("linetypeTraits", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodlinetypeTraits;
		}
		if (SwigDerivedClassHasMethod("enable", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodenable;
		}
		if (SwigDerivedClassHasMethod("enabled", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodenabled;
		}
		if (SwigDerivedClassHasMethod("disable", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethoddisable;
		}
		if (SwigDerivedClassHasMethod("setAnalyticLinetypingCircles", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetAnalyticLinetypingCircles;
		}
		if (SwigDerivedClassHasMethod("isAnalyticLinetypingCircles", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodisAnalyticLinetypingCircles;
		}
		if (SwigDerivedClassHasMethod("setAnalyticLinetypingComplexCurves", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetAnalyticLinetypingComplexCurves;
		}
		if (SwigDerivedClassHasMethod("isAnalyticLinetypingComplexCurves", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodisAnalyticLinetypingComplexCurves;
		}
		if (SwigDerivedClassHasMethod("setOriginalSelectionGeometryOutput", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetOriginalSelectionGeometryOutput;
		}
		if (SwigDerivedClassHasMethod("isOriginalSelectionGeometryOutputEnabled", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodisOriginalSelectionGeometryOutputEnabled;
		}
		if (SwigDerivedClassHasMethod("redirectionGeometry", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodredirectionGeometry;
		}
		if (SwigDerivedClassHasMethod("enableCache", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodenableCache;
		}
		if (SwigDerivedClassHasMethod("disableCache", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethoddisableCache;
		}
		if (SwigDerivedClassHasMethod("cacheEnabled", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodcacheEnabled;
		}
		if (SwigDerivedClassHasMethod("clearCache", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodclearCache;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetyper_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiLinetyper));
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

	private IntPtr SwigDirectorMethodinput()
	{
		return input().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodoutput()
	{
		return output().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodsetDrawContext(IntPtr pDrawCtx)
	{
		try
		{
			setDrawContext(new OdGiConveyorContext_Internal(pDrawCtx, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetDeviation__SWIG_0(IntPtr deviations)
	{
		try
		{
			setDeviation(new OdDoubleArray(deviations, cMemoryOwn: true));
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

	private void SwigDirectorMethodsetDeviation__SWIG_1(IntPtr pDeviation)
	{
		try
		{
			setDeviation(new OdGiDeviation_Internal(pDeviation, cMemoryOwn: false));
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

	private uint SwigDirectorMethodsetLinetype__SWIG_0(IntPtr id, double scale, double generationCriteria, double dScaleForNonScalableLineStyles)
	{
		return setLinetype((id == IntPtr.Zero) ? null : new OdDbStub(id, cMemoryOwn: false), scale, generationCriteria, dScaleForNonScalableLineStyles);
	}

	private uint SwigDirectorMethodsetLinetype__SWIG_1(IntPtr id, double scale, double generationCriteria)
	{
		return setLinetype((id == IntPtr.Zero) ? null : new OdDbStub(id, cMemoryOwn: false), scale, generationCriteria);
	}

	private uint SwigDirectorMethodsetLinetype__SWIG_2(IntPtr id, double scale)
	{
		return setLinetype((id == IntPtr.Zero) ? null : new OdDbStub(id, cMemoryOwn: false), scale);
	}

	private IntPtr SwigDirectorMethodlinetypeTraits()
	{
		return OdGiLinetypeTraits.getCPtr(linetypeTraits()).Handle;
	}

	private void SwigDirectorMethodenable()
	{
		try
		{
			enable();
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

	private bool SwigDirectorMethodenabled()
	{
		return enabled();
	}

	private void SwigDirectorMethoddisable()
	{
		try
		{
			disable();
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

	private void SwigDirectorMethodsetAnalyticLinetypingCircles(bool bAnalytic)
	{
		try
		{
			setAnalyticLinetypingCircles(bAnalytic);
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

	private bool SwigDirectorMethodisAnalyticLinetypingCircles()
	{
		return isAnalyticLinetypingCircles();
	}

	private void SwigDirectorMethodsetAnalyticLinetypingComplexCurves(bool bAnalytic)
	{
		try
		{
			setAnalyticLinetypingComplexCurves(bAnalytic);
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

	private bool SwigDirectorMethodisAnalyticLinetypingComplexCurves()
	{
		return isAnalyticLinetypingComplexCurves();
	}

	private void SwigDirectorMethodsetOriginalSelectionGeometryOutput(bool bEnable)
	{
		try
		{
			setOriginalSelectionGeometryOutput(bEnable);
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

	private bool SwigDirectorMethodisOriginalSelectionGeometryOutputEnabled()
	{
		return isOriginalSelectionGeometryOutputEnabled();
	}

	private IntPtr SwigDirectorMethodredirectionGeometry()
	{
		return redirectionGeometry().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodenableCache()
	{
		try
		{
			enableCache();
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

	private void SwigDirectorMethoddisableCache()
	{
		try
		{
			disableCache();
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

	private bool SwigDirectorMethodcacheEnabled()
	{
		return cacheEnabled();
	}

	private void SwigDirectorMethodclearCache()
	{
		try
		{
			clearCache();
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

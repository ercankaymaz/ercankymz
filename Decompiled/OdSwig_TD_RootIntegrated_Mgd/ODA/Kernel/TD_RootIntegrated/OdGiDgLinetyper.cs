using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDgLinetyper : OdGiLinetyper
{
	public delegate IntPtr SwigDelegateOdGiDgLinetyper_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiDgLinetyper_1();

	public delegate void SwigDelegateOdGiDgLinetyper_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiDgLinetyper_3();

	public delegate IntPtr SwigDelegateOdGiDgLinetyper_4();

	public delegate void SwigDelegateOdGiDgLinetyper_5(IntPtr pDrawCtx);

	public delegate void SwigDelegateOdGiDgLinetyper_6(IntPtr deviations);

	public delegate void SwigDelegateOdGiDgLinetyper_7(IntPtr pDeviation);

	public delegate uint SwigDelegateOdGiDgLinetyper_8(IntPtr id, double scale, double generationCriteria, double dScaleForNonScalableLineStyles);

	public delegate uint SwigDelegateOdGiDgLinetyper_9(IntPtr id, double scale, double generationCriteria);

	public delegate uint SwigDelegateOdGiDgLinetyper_10(IntPtr id, double scale);

	public delegate IntPtr SwigDelegateOdGiDgLinetyper_11();

	public delegate void SwigDelegateOdGiDgLinetyper_12();

	public delegate bool SwigDelegateOdGiDgLinetyper_13();

	public delegate void SwigDelegateOdGiDgLinetyper_14();

	public delegate void SwigDelegateOdGiDgLinetyper_15(bool bAnalytic);

	public delegate bool SwigDelegateOdGiDgLinetyper_16();

	public delegate void SwigDelegateOdGiDgLinetyper_17(bool bAnalytic);

	public delegate bool SwigDelegateOdGiDgLinetyper_18();

	public delegate void SwigDelegateOdGiDgLinetyper_19(bool bEnable);

	public delegate bool SwigDelegateOdGiDgLinetyper_20();

	public delegate IntPtr SwigDelegateOdGiDgLinetyper_21();

	public delegate void SwigDelegateOdGiDgLinetyper_22();

	public delegate void SwigDelegateOdGiDgLinetyper_23();

	public delegate bool SwigDelegateOdGiDgLinetyper_24();

	public delegate void SwigDelegateOdGiDgLinetyper_25();

	public delegate IntPtr SwigDelegateOdGiDgLinetyper_26();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiDgLinetyper_0 swigDelegate0;

	private SwigDelegateOdGiDgLinetyper_1 swigDelegate1;

	private SwigDelegateOdGiDgLinetyper_2 swigDelegate2;

	private SwigDelegateOdGiDgLinetyper_3 swigDelegate3;

	private SwigDelegateOdGiDgLinetyper_4 swigDelegate4;

	private SwigDelegateOdGiDgLinetyper_5 swigDelegate5;

	private SwigDelegateOdGiDgLinetyper_6 swigDelegate6;

	private SwigDelegateOdGiDgLinetyper_7 swigDelegate7;

	private SwigDelegateOdGiDgLinetyper_8 swigDelegate8;

	private SwigDelegateOdGiDgLinetyper_9 swigDelegate9;

	private SwigDelegateOdGiDgLinetyper_10 swigDelegate10;

	private SwigDelegateOdGiDgLinetyper_11 swigDelegate11;

	private SwigDelegateOdGiDgLinetyper_12 swigDelegate12;

	private SwigDelegateOdGiDgLinetyper_13 swigDelegate13;

	private SwigDelegateOdGiDgLinetyper_14 swigDelegate14;

	private SwigDelegateOdGiDgLinetyper_15 swigDelegate15;

	private SwigDelegateOdGiDgLinetyper_16 swigDelegate16;

	private SwigDelegateOdGiDgLinetyper_17 swigDelegate17;

	private SwigDelegateOdGiDgLinetyper_18 swigDelegate18;

	private SwigDelegateOdGiDgLinetyper_19 swigDelegate19;

	private SwigDelegateOdGiDgLinetyper_20 swigDelegate20;

	private SwigDelegateOdGiDgLinetyper_21 swigDelegate21;

	private SwigDelegateOdGiDgLinetyper_22 swigDelegate22;

	private SwigDelegateOdGiDgLinetyper_23 swigDelegate23;

	private SwigDelegateOdGiDgLinetyper_24 swigDelegate24;

	private SwigDelegateOdGiDgLinetyper_25 swigDelegate25;

	private SwigDelegateOdGiDgLinetyper_26 swigDelegate26;

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

	private static Type[] swigMethodTypes26 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDgLinetyper(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetyper_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDgLinetyper obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDgLinetyper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiDgLinetyper cast(OdRxObject pObj)
	{
		OdGiDgLinetyper rXObject = Helpers.GetRXObject<OdGiDgLinetyper>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetyper_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetyper_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetyper_isASwigExplicitOdGiDgLinetyper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetyper_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetyper_queryXSwigExplicitOdGiDgLinetyper(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetyper_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiDgLinetyper createObject()
	{
		OdGiDgLinetyper rXObject = Helpers.GetRXObject<OdGiDgLinetyper>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetyper_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiDgLinetypeTraits dgLinetypeTraits()
	{
		OdGiDgLinetypeTraits rXObject = Helpers.GetRXObject<OdGiDgLinetypeTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetyper_dgLinetypeTraits(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetyper_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiDgLinetyper()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDgLinetyper(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiDgLinetyper) != GetType();
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
		if (SwigDerivedClassHasMethod("dgLinetypeTraits", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethoddgLinetypeTraits;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetyper_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiDgLinetyper));
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

	private IntPtr SwigDirectorMethoddgLinetypeTraits()
	{
		return OdGiDgLinetypeTraits.getCPtr(dgLinetypeTraits()).Handle;
	}
}

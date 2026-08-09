using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiLinetypeRedir : OdGiDgLinetyper
{
	public delegate IntPtr SwigDelegateOdGiLinetypeRedir_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiLinetypeRedir_1();

	public delegate void SwigDelegateOdGiLinetypeRedir_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiLinetypeRedir_3();

	public delegate IntPtr SwigDelegateOdGiLinetypeRedir_4();

	public delegate void SwigDelegateOdGiLinetypeRedir_5(IntPtr pDrawCtx);

	public delegate void SwigDelegateOdGiLinetypeRedir_6(IntPtr deviations);

	public delegate void SwigDelegateOdGiLinetypeRedir_7(IntPtr pDeviation);

	public delegate uint SwigDelegateOdGiLinetypeRedir_8(IntPtr id, double scale, double generationCriteria, double dScaleForNonScalableLineStyles);

	public delegate uint SwigDelegateOdGiLinetypeRedir_9(IntPtr id, double scale, double generationCriteria);

	public delegate uint SwigDelegateOdGiLinetypeRedir_10(IntPtr id, double scale);

	public delegate IntPtr SwigDelegateOdGiLinetypeRedir_11();

	public delegate void SwigDelegateOdGiLinetypeRedir_12();

	public delegate bool SwigDelegateOdGiLinetypeRedir_13();

	public delegate void SwigDelegateOdGiLinetypeRedir_14();

	public delegate void SwigDelegateOdGiLinetypeRedir_15(bool bAnalytic);

	public delegate bool SwigDelegateOdGiLinetypeRedir_16();

	public delegate void SwigDelegateOdGiLinetypeRedir_17(bool bAnalytic);

	public delegate bool SwigDelegateOdGiLinetypeRedir_18();

	public delegate void SwigDelegateOdGiLinetypeRedir_19(bool bEnable);

	public delegate bool SwigDelegateOdGiLinetypeRedir_20();

	public delegate IntPtr SwigDelegateOdGiLinetypeRedir_21();

	public delegate void SwigDelegateOdGiLinetypeRedir_22();

	public delegate void SwigDelegateOdGiLinetypeRedir_23();

	public delegate bool SwigDelegateOdGiLinetypeRedir_24();

	public delegate void SwigDelegateOdGiLinetypeRedir_25();

	public delegate IntPtr SwigDelegateOdGiLinetypeRedir_26();

	public delegate void SwigDelegateOdGiLinetypeRedir_27(int dir);

	public delegate int SwigDelegateOdGiLinetypeRedir_28();

	public delegate IntPtr SwigDelegateOdGiLinetypeRedir_29();

	public delegate IntPtr SwigDelegateOdGiLinetypeRedir_30();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiLinetypeRedir_0 swigDelegate0;

	private SwigDelegateOdGiLinetypeRedir_1 swigDelegate1;

	private SwigDelegateOdGiLinetypeRedir_2 swigDelegate2;

	private SwigDelegateOdGiLinetypeRedir_3 swigDelegate3;

	private SwigDelegateOdGiLinetypeRedir_4 swigDelegate4;

	private SwigDelegateOdGiLinetypeRedir_5 swigDelegate5;

	private SwigDelegateOdGiLinetypeRedir_6 swigDelegate6;

	private SwigDelegateOdGiLinetypeRedir_7 swigDelegate7;

	private SwigDelegateOdGiLinetypeRedir_8 swigDelegate8;

	private SwigDelegateOdGiLinetypeRedir_9 swigDelegate9;

	private SwigDelegateOdGiLinetypeRedir_10 swigDelegate10;

	private SwigDelegateOdGiLinetypeRedir_11 swigDelegate11;

	private SwigDelegateOdGiLinetypeRedir_12 swigDelegate12;

	private SwigDelegateOdGiLinetypeRedir_13 swigDelegate13;

	private SwigDelegateOdGiLinetypeRedir_14 swigDelegate14;

	private SwigDelegateOdGiLinetypeRedir_15 swigDelegate15;

	private SwigDelegateOdGiLinetypeRedir_16 swigDelegate16;

	private SwigDelegateOdGiLinetypeRedir_17 swigDelegate17;

	private SwigDelegateOdGiLinetypeRedir_18 swigDelegate18;

	private SwigDelegateOdGiLinetypeRedir_19 swigDelegate19;

	private SwigDelegateOdGiLinetypeRedir_20 swigDelegate20;

	private SwigDelegateOdGiLinetypeRedir_21 swigDelegate21;

	private SwigDelegateOdGiLinetypeRedir_22 swigDelegate22;

	private SwigDelegateOdGiLinetypeRedir_23 swigDelegate23;

	private SwigDelegateOdGiLinetypeRedir_24 swigDelegate24;

	private SwigDelegateOdGiLinetypeRedir_25 swigDelegate25;

	private SwigDelegateOdGiLinetypeRedir_26 swigDelegate26;

	private SwigDelegateOdGiLinetypeRedir_27 swigDelegate27;

	private SwigDelegateOdGiLinetypeRedir_28 swigDelegate28;

	private SwigDelegateOdGiLinetypeRedir_29 swigDelegate29;

	private SwigDelegateOdGiLinetypeRedir_30 swigDelegate30;

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

	private static Type[] swigMethodTypes27 = new Type[1] { typeof(OdGiLinetypeRedir_Direction) };

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[0];

	private static Type[] swigMethodTypes30 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiLinetypeRedir(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetypeRedir_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiLinetypeRedir obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiLinetypeRedir(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiLinetypeRedir cast(OdRxObject pObj)
	{
		OdGiLinetypeRedir rXObject = Helpers.GetRXObject<OdGiLinetypeRedir>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetypeRedir_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetypeRedir_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetypeRedir_isASwigExplicitOdGiLinetypeRedir(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetypeRedir_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetypeRedir_queryXSwigExplicitOdGiLinetypeRedir(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetypeRedir_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiLinetypeRedir createObject()
	{
		OdGiLinetypeRedir rXObject = Helpers.GetRXObject<OdGiLinetypeRedir>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetypeRedir_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void switchTo(OdGiLinetypeRedir_Direction dir)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetypeRedir_switchTo(swigCPtr, (int)dir);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiLinetypeRedir_Direction currentRedir()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetypeRedir_currentRedir(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiLinetypeRedir_Direction)result;
	}

	public virtual OdGiLinetyper activeLinetyper()
	{
		OdGiLinetyper rXObject = Helpers.GetRXObject<OdGiLinetyper>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetypeRedir_activeLinetyper__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetypeRedir_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiLinetypeRedir()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiLinetypeRedir(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiLinetypeRedir) != GetType();
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
		if (SwigDerivedClassHasMethod("switchTo", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodswitchTo;
		}
		if (SwigDerivedClassHasMethod("currentRedir", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodcurrentRedir;
		}
		if (SwigDerivedClassHasMethod("activeLinetyper", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodactiveLinetyper__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("activeLinetyper", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodactiveLinetyper__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLinetypeRedir_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiLinetypeRedir));
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

	private void SwigDirectorMethodswitchTo(int dir)
	{
		try
		{
			switchTo((OdGiLinetypeRedir_Direction)dir);
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

	private int SwigDirectorMethodcurrentRedir()
	{
		return (int)currentRedir();
	}

	private IntPtr SwigDirectorMethodactiveLinetyper__SWIG_0()
	{
		return OdGiLinetyper.getCPtr(activeLinetyper()).Handle;
	}

	private IntPtr SwigDirectorMethodactiveLinetyper__SWIG_1()
	{
		return OdGiLinetyper.getCPtr(activeLinetyper()).Handle;
	}
}

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiCollideProc : OdGiConveyorNode
{
	public delegate IntPtr SwigDelegateOdGiCollideProc_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiCollideProc_1();

	public delegate void SwigDelegateOdGiCollideProc_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiCollideProc_3();

	public delegate IntPtr SwigDelegateOdGiCollideProc_4();

	public delegate void SwigDelegateOdGiCollideProc_5(IntPtr pReactor, IntPtr pCtx);

	public delegate void SwigDelegateOdGiCollideProc_6(IntPtr pReactor);

	public delegate void SwigDelegateOdGiCollideProc_7(IntPtr deviations);

	public delegate void SwigDelegateOdGiCollideProc_8(IntPtr pDeviation);

	public delegate void SwigDelegateOdGiCollideProc_9(IntPtr pDrawCtx);

	public delegate void SwigDelegateOdGiCollideProc_10(bool bCheck);

	public delegate bool SwigDelegateOdGiCollideProc_11();

	public delegate void SwigDelegateOdGiCollideProc_12(byte options);

	public delegate byte SwigDelegateOdGiCollideProc_13();

	public delegate void SwigDelegateOdGiCollideProc_14(bool bNoFilter);

	public delegate bool SwigDelegateOdGiCollideProc_15();

	public delegate void SwigDelegateOdGiCollideProc_16(int arg0);

	public delegate int SwigDelegateOdGiCollideProc_17();

	public delegate IntPtr SwigDelegateOdGiCollideProc_18();

	public delegate void SwigDelegateOdGiCollideProc_19(OdGiPathNode[] pInputList, uint nInputListSize);

	public delegate void SwigDelegateOdGiCollideProc_20(OdGiPathNode[] pInputList, uint nInputListSize);

	public delegate void SwigDelegateOdGiCollideProc_21();

	public delegate void SwigDelegateOdGiCollideProc_22(double e);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiCollideProc_0 swigDelegate0;

	private SwigDelegateOdGiCollideProc_1 swigDelegate1;

	private SwigDelegateOdGiCollideProc_2 swigDelegate2;

	private SwigDelegateOdGiCollideProc_3 swigDelegate3;

	private SwigDelegateOdGiCollideProc_4 swigDelegate4;

	private SwigDelegateOdGiCollideProc_5 swigDelegate5;

	private SwigDelegateOdGiCollideProc_6 swigDelegate6;

	private SwigDelegateOdGiCollideProc_7 swigDelegate7;

	private SwigDelegateOdGiCollideProc_8 swigDelegate8;

	private SwigDelegateOdGiCollideProc_9 swigDelegate9;

	private SwigDelegateOdGiCollideProc_10 swigDelegate10;

	private SwigDelegateOdGiCollideProc_11 swigDelegate11;

	private SwigDelegateOdGiCollideProc_12 swigDelegate12;

	private SwigDelegateOdGiCollideProc_13 swigDelegate13;

	private SwigDelegateOdGiCollideProc_14 swigDelegate14;

	private SwigDelegateOdGiCollideProc_15 swigDelegate15;

	private SwigDelegateOdGiCollideProc_16 swigDelegate16;

	private SwigDelegateOdGiCollideProc_17 swigDelegate17;

	private SwigDelegateOdGiCollideProc_18 swigDelegate18;

	private SwigDelegateOdGiCollideProc_19 swigDelegate19;

	private SwigDelegateOdGiCollideProc_20 swigDelegate20;

	private SwigDelegateOdGiCollideProc_21 swigDelegate21;

	private SwigDelegateOdGiCollideProc_22 swigDelegate22;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGsCollisionDetectionContext)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGsCollisionDetectionReactor) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdDoubleArray) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGiDeviation) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGiConveyorContext) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(byte) };

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdGiCollideProc_ProcessingPhase) };

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(OdGiPathNode[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes20 = new Type[2]
	{
		typeof(OdGiPathNode[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(double) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiCollideProc(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiCollideProc obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiCollideProc(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiCollideProc cast(OdRxObject pObj)
	{
		OdGiCollideProc rXObject = Helpers.GetRXObject<OdGiCollideProc>(TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_isASwigExplicitOdGiCollideProc(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_queryXSwigExplicitOdGiCollideProc(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiCollideProc createObject()
	{
		OdGiCollideProc rXObject = Helpers.GetRXObject<OdGiCollideProc>(TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void set(OdGsCollisionDetectionReactor pReactor, OdGsCollisionDetectionContext pCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_set__SWIG_0(swigCPtr, OdGsCollisionDetectionReactor.getCPtr(pReactor), OdGsCollisionDetectionContext.getCPtr(pCtx));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdGsCollisionDetectionReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_set__SWIG_1(swigCPtr, OdGsCollisionDetectionReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviation(OdDoubleArray deviations)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_setDeviation__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(deviations).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviation(OdGiDeviation pDeviation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_setDeviation__SWIG_1(swigCPtr, pDeviation.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDrawContext(OdGiConveyorContext pDrawCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_setDrawContext(swigCPtr, pDrawCtx.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLinePrimitivesChecking(bool bCheck)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_setLinePrimitivesChecking(swigCPtr, bCheck);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool linePrimitivesChecking()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_linePrimitivesChecking(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void enableAnalyticMode(byte options)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_enableAnalyticMode(swigCPtr, options);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte analitycMode()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_analitycMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setNoFilter(bool bNoFilter)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_setNoFilter(swigCPtr, bNoFilter);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool noFilter()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_noFilter(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setProcessingPhase(OdGiCollideProc_ProcessingPhase arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_setProcessingPhase(swigCPtr, (int)arg0);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiCollideProc_ProcessingPhase processingPhase()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_processingPhase(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiCollideProc_ProcessingPhase)result;
	}

	public virtual OdGeExtents3d extents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_extents(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setInputDrawables(OdGiPathNode[] pInputList, uint nInputListSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_setInputDrawables(swigCPtr, pInputList, nInputListSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCheckWithDrawables(OdGiPathNode[] pInputList, uint nInputListSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_setCheckWithDrawables(swigCPtr, pInputList, nInputListSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void processTriangles()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_processTriangles(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setExtentsExtension(double e)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_setExtentsExtension(swigCPtr, e);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiCollideProc()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiCollideProc(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiCollideProc) != GetType();
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
		if (SwigDerivedClassHasMethod("set", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodset__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodset__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetDeviation__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetDeviation__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setDrawContext", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetDrawContext;
		}
		if (SwigDerivedClassHasMethod("setLinePrimitivesChecking", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetLinePrimitivesChecking;
		}
		if (SwigDerivedClassHasMethod("linePrimitivesChecking", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodlinePrimitivesChecking;
		}
		if (SwigDerivedClassHasMethod("enableAnalyticMode", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodenableAnalyticMode;
		}
		if (SwigDerivedClassHasMethod("analitycMode", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodanalitycMode;
		}
		if (SwigDerivedClassHasMethod("setNoFilter", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetNoFilter;
		}
		if (SwigDerivedClassHasMethod("noFilter", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodnoFilter;
		}
		if (SwigDerivedClassHasMethod("setProcessingPhase", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetProcessingPhase;
		}
		if (SwigDerivedClassHasMethod("processingPhase", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodprocessingPhase;
		}
		if (SwigDerivedClassHasMethod("extents", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodextents;
		}
		if (SwigDerivedClassHasMethod("setInputDrawables", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetInputDrawables;
		}
		if (SwigDerivedClassHasMethod("setCheckWithDrawables", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsetCheckWithDrawables;
		}
		if (SwigDerivedClassHasMethod("processTriangles", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodprocessTriangles;
		}
		if (SwigDerivedClassHasMethod("setExtentsExtension", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodsetExtentsExtension;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiCollideProc_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiCollideProc));
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

	private void SwigDirectorMethodset__SWIG_0(IntPtr pReactor, IntPtr pCtx)
	{
		try
		{
			set((pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false), (pCtx == IntPtr.Zero) ? null : new OdGsCollisionDetectionContext(pCtx, cMemoryOwn: false));
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

	private void SwigDirectorMethodset__SWIG_1(IntPtr pReactor)
	{
		try
		{
			set((pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetLinePrimitivesChecking(bool bCheck)
	{
		try
		{
			setLinePrimitivesChecking(bCheck);
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

	private bool SwigDirectorMethodlinePrimitivesChecking()
	{
		return linePrimitivesChecking();
	}

	private void SwigDirectorMethodenableAnalyticMode(byte options)
	{
		try
		{
			enableAnalyticMode(options);
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

	private byte SwigDirectorMethodanalitycMode()
	{
		return analitycMode();
	}

	private void SwigDirectorMethodsetNoFilter(bool bNoFilter)
	{
		try
		{
			setNoFilter(bNoFilter);
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

	private bool SwigDirectorMethodnoFilter()
	{
		return noFilter();
	}

	private void SwigDirectorMethodsetProcessingPhase(int arg0)
	{
		try
		{
			setProcessingPhase((OdGiCollideProc_ProcessingPhase)arg0);
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

	private int SwigDirectorMethodprocessingPhase()
	{
		return (int)processingPhase();
	}

	private IntPtr SwigDirectorMethodextents()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeExtents3d.getCPtr(extents()).Handle;
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

	private void SwigDirectorMethodsetInputDrawables(OdGiPathNode[] pInputList, uint nInputListSize)
	{
		try
		{
			setInputDrawables(pInputList, nInputListSize);
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

	private void SwigDirectorMethodsetCheckWithDrawables(OdGiPathNode[] pInputList, uint nInputListSize)
	{
		try
		{
			setCheckWithDrawables(pInputList, nInputListSize);
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

	private void SwigDirectorMethodprocessTriangles()
	{
		try
		{
			processTriangles();
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

	private void SwigDirectorMethodsetExtentsExtension(double e)
	{
		try
		{
			setExtentsExtension(e);
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

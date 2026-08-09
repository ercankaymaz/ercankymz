using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRayTraceProc : OdGiSelectProcBase
{
	public delegate IntPtr SwigDelegateOdGiRayTraceProc_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiRayTraceProc_1();

	public delegate void SwigDelegateOdGiRayTraceProc_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiRayTraceProc_3();

	public delegate IntPtr SwigDelegateOdGiRayTraceProc_4();

	public delegate void SwigDelegateOdGiRayTraceProc_5(uint flags);

	public delegate void SwigDelegateOdGiRayTraceProc_6();

	public delegate void SwigDelegateOdGiRayTraceProc_7(bool arg0);

	public delegate bool SwigDelegateOdGiRayTraceProc_8(IntPtr arg0, bool arg1);

	public delegate bool SwigDelegateOdGiRayTraceProc_9(IntPtr arg0);

	public delegate uint SwigDelegateOdGiRayTraceProc_10();

	public delegate void SwigDelegateOdGiRayTraceProc_11(IntPtr deviations);

	public delegate void SwigDelegateOdGiRayTraceProc_12(IntPtr pDeviation);

	public delegate void SwigDelegateOdGiRayTraceProc_13(IntPtr pDrawCtx);

	public delegate void SwigDelegateOdGiRayTraceProc_14(IntPtr rayOrigin, IntPtr rayDirection, int mode, IntPtr pReactor);

	public delegate void SwigDelegateOdGiRayTraceProc_15(IntPtr rayOrigin, IntPtr rayDirection);

	public delegate void SwigDelegateOdGiRayTraceProc_16(OdGiPathNode[] pObjectList, uint nObjectListSize);

	public delegate void SwigDelegateOdGiRayTraceProc_17(OdGiPathNode[] pObjectList);

	public delegate void SwigDelegateOdGiRayTraceProc_18();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiRayTraceProc_0 swigDelegate0;

	private SwigDelegateOdGiRayTraceProc_1 swigDelegate1;

	private SwigDelegateOdGiRayTraceProc_2 swigDelegate2;

	private SwigDelegateOdGiRayTraceProc_3 swigDelegate3;

	private SwigDelegateOdGiRayTraceProc_4 swigDelegate4;

	private SwigDelegateOdGiRayTraceProc_5 swigDelegate5;

	private SwigDelegateOdGiRayTraceProc_6 swigDelegate6;

	private SwigDelegateOdGiRayTraceProc_7 swigDelegate7;

	private SwigDelegateOdGiRayTraceProc_8 swigDelegate8;

	private SwigDelegateOdGiRayTraceProc_9 swigDelegate9;

	private SwigDelegateOdGiRayTraceProc_10 swigDelegate10;

	private SwigDelegateOdGiRayTraceProc_11 swigDelegate11;

	private SwigDelegateOdGiRayTraceProc_12 swigDelegate12;

	private SwigDelegateOdGiRayTraceProc_13 swigDelegate13;

	private SwigDelegateOdGiRayTraceProc_14 swigDelegate14;

	private SwigDelegateOdGiRayTraceProc_15 swigDelegate15;

	private SwigDelegateOdGiRayTraceProc_16 swigDelegate16;

	private SwigDelegateOdGiRayTraceProc_17 swigDelegate17;

	private SwigDelegateOdGiRayTraceProc_18 swigDelegate18;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdGeExtents3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdDoubleArray) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdGiDeviation) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdGiConveyorContext) };

	private static Type[] swigMethodTypes14 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGiRayTraceProc_RayTracingMode),
		typeof(OdGsRayTraceReactor)
	};

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes16 = new Type[2]
	{
		typeof(OdGiPathNode[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdGiPathNode[]) };

	private static Type[] swigMethodTypes18 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiRayTraceProc(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRayTraceProc obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRayTraceProc(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiRayTraceProc cast(OdRxObject pObj)
	{
		OdGiRayTraceProc rXObject = Helpers.GetRXObject<OdGiRayTraceProc>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_isASwigExplicitOdGiRayTraceProc(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_queryXSwigExplicitOdGiRayTraceProc(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiRayTraceProc createObject()
	{
		OdGiRayTraceProc rXObject = Helpers.GetRXObject<OdGiRayTraceProc>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void set(OdGePoint3d rayOrigin, OdGeVector3d rayDirection, OdGiRayTraceProc_RayTracingMode mode, OdGsRayTraceReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_set(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), (int)mode, OdGsRayTraceReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(OdGePoint3d rayOrigin, OdGeVector3d rayDirection)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_get(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFilter(OdGiPathNode[] pObjectList, uint nObjectListSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_setFilter__SWIG_0(swigCPtr, pObjectList, nObjectListSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFilter(OdGiPathNode[] pObjectList)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_setFilter__SWIG_1(swigCPtr, pObjectList);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFilter()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_setFilter__SWIG_2(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("input", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodinput;
		}
		if (SwigDerivedClassHasMethod("output", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodoutput;
		}
		if (SwigDerivedClassHasMethod("check_n_fire_selected", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcheck_n_fire_selected__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("check_n_fire_selected", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcheck_n_fire_selected__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("switchSectioning", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodswitchSectioning;
		}
		if (SwigDerivedClassHasMethod("handleSelectionByExtents", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodhandleSelectionByExtents__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("handleSelectionByExtents", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodhandleSelectionByExtents__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("supportGeometryPrimitives", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsupportGeometryPrimitives;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetDeviation__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetDeviation__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setDrawContext", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetDrawContext;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodset;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodget;
		}
		if (SwigDerivedClassHasMethod("setFilter", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetFilter__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setFilter", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetFilter__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setFilter", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodsetFilter__SWIG_2;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRayTraceProc_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiRayTraceProc));
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

	private void SwigDirectorMethodcheck_n_fire_selected__SWIG_0(uint flags)
	{
		try
		{
			check_n_fire_selected(flags);
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

	private void SwigDirectorMethodcheck_n_fire_selected__SWIG_1()
	{
		try
		{
			check_n_fire_selected();
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

	private void SwigDirectorMethodswitchSectioning(bool arg0)
	{
		try
		{
			switchSectioning(arg0);
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

	private bool SwigDirectorMethodhandleSelectionByExtents__SWIG_0(IntPtr arg0, bool arg1)
	{
		return handleSelectionByExtents(new OdGeExtents3d(arg0, cMemoryOwn: false), arg1);
	}

	private bool SwigDirectorMethodhandleSelectionByExtents__SWIG_1(IntPtr arg0)
	{
		return handleSelectionByExtents(new OdGeExtents3d(arg0, cMemoryOwn: false));
	}

	private uint SwigDirectorMethodsupportGeometryPrimitives()
	{
		return supportGeometryPrimitives();
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

	private void SwigDirectorMethodset(IntPtr rayOrigin, IntPtr rayDirection, int mode, IntPtr pReactor)
	{
		try
		{
			set(new OdGePoint3d(rayOrigin, cMemoryOwn: false), new OdGeVector3d(rayDirection, cMemoryOwn: false), (OdGiRayTraceProc_RayTracingMode)mode, (pReactor == IntPtr.Zero) ? null : new OdGsRayTraceReactor(pReactor, cMemoryOwn: false));
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

	private void SwigDirectorMethodget(IntPtr rayOrigin, IntPtr rayDirection)
	{
		try
		{
			get(new OdGePoint3d(rayOrigin, cMemoryOwn: false), new OdGeVector3d(rayDirection, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetFilter__SWIG_0(OdGiPathNode[] pObjectList, uint nObjectListSize)
	{
		try
		{
			setFilter(pObjectList, nObjectListSize);
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

	private void SwigDirectorMethodsetFilter__SWIG_1(OdGiPathNode[] pObjectList)
	{
		try
		{
			setFilter(pObjectList);
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

	private void SwigDirectorMethodsetFilter__SWIG_2()
	{
		try
		{
			setFilter();
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

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSelectProcBase : OdGiConveyorNode
{
	public delegate IntPtr SwigDelegateOdGiSelectProcBase_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiSelectProcBase_1();

	public delegate void SwigDelegateOdGiSelectProcBase_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiSelectProcBase_3();

	public delegate IntPtr SwigDelegateOdGiSelectProcBase_4();

	public delegate void SwigDelegateOdGiSelectProcBase_5(uint flags);

	public delegate void SwigDelegateOdGiSelectProcBase_6();

	public delegate void SwigDelegateOdGiSelectProcBase_7(bool arg0);

	public delegate bool SwigDelegateOdGiSelectProcBase_8(IntPtr arg0, bool arg1);

	public delegate bool SwigDelegateOdGiSelectProcBase_9(IntPtr arg0);

	public delegate uint SwigDelegateOdGiSelectProcBase_10();

	public delegate void SwigDelegateOdGiSelectProcBase_11(IntPtr deviations);

	public delegate void SwigDelegateOdGiSelectProcBase_12(IntPtr pDeviation);

	public delegate void SwigDelegateOdGiSelectProcBase_13(IntPtr pDrawCtx);

	private object locker = new object();

	private HandleRef swigCPtr;

	public const uint kCheckMarkerFinish = 2147483648u;

	private SwigDelegateOdGiSelectProcBase_0 swigDelegate0;

	private SwigDelegateOdGiSelectProcBase_1 swigDelegate1;

	private SwigDelegateOdGiSelectProcBase_2 swigDelegate2;

	private SwigDelegateOdGiSelectProcBase_3 swigDelegate3;

	private SwigDelegateOdGiSelectProcBase_4 swigDelegate4;

	private SwigDelegateOdGiSelectProcBase_5 swigDelegate5;

	private SwigDelegateOdGiSelectProcBase_6 swigDelegate6;

	private SwigDelegateOdGiSelectProcBase_7 swigDelegate7;

	private SwigDelegateOdGiSelectProcBase_8 swigDelegate8;

	private SwigDelegateOdGiSelectProcBase_9 swigDelegate9;

	private SwigDelegateOdGiSelectProcBase_10 swigDelegate10;

	private SwigDelegateOdGiSelectProcBase_11 swigDelegate11;

	private SwigDelegateOdGiSelectProcBase_12 swigDelegate12;

	private SwigDelegateOdGiSelectProcBase_13 swigDelegate13;

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

	public const int kCheckMarkerOnChange = 1;

	public const int kCheckMarkerOnViewModeChange = 2;

	public const int kSupportPointsPrim = 1;

	public const int kSupportLinesPrim = 2;

	public const int kSupportTrianglesPrim = 4;

	public const int kSupportAllPrims = 7;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSelectProcBase(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSelectProcBase obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSelectProcBase(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiSelectProcBase cast(OdRxObject pObj)
	{
		OdGiSelectProcBase rXObject = Helpers.GetRXObject<OdGiSelectProcBase>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_isASwigExplicitOdGiSelectProcBase(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_queryXSwigExplicitOdGiSelectProcBase(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiSelectProcBase createObject()
	{
		OdGiSelectProcBase rXObject = Helpers.GetRXObject<OdGiSelectProcBase>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void check_n_fire_selected(uint flags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_check_n_fire_selected__SWIG_0(swigCPtr, flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void check_n_fire_selected()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_check_n_fire_selected__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void switchSectioning(bool arg0)
	{
		if (SwigDerivedClassHasMethod("switchSectioning", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_switchSectioningSwigExplicitOdGiSelectProcBase(swigCPtr, arg0);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_switchSectioning(swigCPtr, arg0);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool handleSelectionByExtents(OdGeExtents3d arg0, bool arg1)
	{
		bool result = (SwigDerivedClassHasMethod("handleSelectionByExtents", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_handleSelectionByExtentsSwigExplicitOdGiSelectProcBase__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(arg0), arg1) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_handleSelectionByExtents__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(arg0), arg1));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool handleSelectionByExtents(OdGeExtents3d arg0)
	{
		bool result = (SwigDerivedClassHasMethod("handleSelectionByExtents", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_handleSelectionByExtentsSwigExplicitOdGiSelectProcBase__SWIG_1(swigCPtr, OdGeExtents3d.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_handleSelectionByExtents__SWIG_1(swigCPtr, OdGeExtents3d.getCPtr(arg0)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint supportGeometryPrimitives()
	{
		uint result = (SwigDerivedClassHasMethod("supportGeometryPrimitives", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_supportGeometryPrimitivesSwigExplicitOdGiSelectProcBase(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_supportGeometryPrimitives(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDeviation(OdDoubleArray deviations)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_setDeviation__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(deviations).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviation(OdGiDeviation pDeviation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_setDeviation__SWIG_1(swigCPtr, pDeviation.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDrawContext(OdGiConveyorContext pDrawCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_setDrawContext(swigCPtr, pDrawCtx.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_getRealClassName(ptr);
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProcBase_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiSelectProcBase));
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
}

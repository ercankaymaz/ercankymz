using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSelectProc : OdGiSelectProcBase
{
	public delegate IntPtr SwigDelegateOdGiSelectProc_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiSelectProc_1();

	public delegate void SwigDelegateOdGiSelectProc_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiSelectProc_3();

	public delegate IntPtr SwigDelegateOdGiSelectProc_4();

	public delegate void SwigDelegateOdGiSelectProc_5(uint flags);

	public delegate void SwigDelegateOdGiSelectProc_6();

	public delegate void SwigDelegateOdGiSelectProc_7(bool arg0);

	public delegate bool SwigDelegateOdGiSelectProc_8(IntPtr arg0, bool arg1);

	public delegate bool SwigDelegateOdGiSelectProc_9(IntPtr arg0);

	public delegate uint SwigDelegateOdGiSelectProc_10();

	public delegate void SwigDelegateOdGiSelectProc_11(IntPtr deviations);

	public delegate void SwigDelegateOdGiSelectProc_12(IntPtr pDeviation);

	public delegate void SwigDelegateOdGiSelectProc_13(IntPtr pDrawCtx);

	public delegate void SwigDelegateOdGiSelectProc_14(IntPtr pPoints, uint nPoints, int mode, IntPtr pReactor);

	public delegate void SwigDelegateOdGiSelectProc_15(IntPtr points, OdGsView_SelectionMode mode);

	private object locker = new object();

	private HandleRef swigCPtr;

	public new const uint kCheckMarkerFinish = 2147483648u;

	private SwigDelegateOdGiSelectProc_0 swigDelegate0;

	private SwigDelegateOdGiSelectProc_1 swigDelegate1;

	private SwigDelegateOdGiSelectProc_2 swigDelegate2;

	private SwigDelegateOdGiSelectProc_3 swigDelegate3;

	private SwigDelegateOdGiSelectProc_4 swigDelegate4;

	private SwigDelegateOdGiSelectProc_5 swigDelegate5;

	private SwigDelegateOdGiSelectProc_6 swigDelegate6;

	private SwigDelegateOdGiSelectProc_7 swigDelegate7;

	private SwigDelegateOdGiSelectProc_8 swigDelegate8;

	private SwigDelegateOdGiSelectProc_9 swigDelegate9;

	private SwigDelegateOdGiSelectProc_10 swigDelegate10;

	private SwigDelegateOdGiSelectProc_11 swigDelegate11;

	private SwigDelegateOdGiSelectProc_12 swigDelegate12;

	private SwigDelegateOdGiSelectProc_13 swigDelegate13;

	private SwigDelegateOdGiSelectProc_14 swigDelegate14;

	private SwigDelegateOdGiSelectProc_15 swigDelegate15;

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
		typeof(OdGePoint2d),
		typeof(uint),
		typeof(OdGsView_SelectionMode),
		typeof(OdGsSelectionReactor)
	};

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(OdGePoint2dArray),
		typeof(OdGsView_SelectionMode).MakeByRefType()
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSelectProc(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProc_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSelectProc obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSelectProc(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override OdGiConveyorInput input()
	{
		OdGiConveyorInput_Internal result = new OdGiConveyorInput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorNode_input(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGiConveyorOutput output()
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorNode_output(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiSelectProc cast(OdRxObject pObj)
	{
		OdGiSelectProc rXObject = Helpers.GetRXObject<OdGiSelectProc>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProc_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProc_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProc_isASwigExplicitOdGiSelectProc(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProc_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProc_queryXSwigExplicitOdGiSelectProc(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProc_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiSelectProc createObject()
	{
		OdGiSelectProc rXObject = Helpers.GetRXObject<OdGiSelectProc>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProc_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void set(OdGePoint2d pPoints, uint nPoints, OdGsView_SelectionMode mode, OdGsSelectionReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProc_set(swigCPtr, OdGePoint2d.getCPtr(pPoints), nPoints, (int)mode, OdGsSelectionReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(OdGePoint2dArray points, out OdGsView_SelectionMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProc_get(swigCPtr, OdGePoint2dArray.getCPtr(points).Handle, out mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool supportsSubentitySelection(OdGiViewport pView, OdGsView_SelectionMode mode, OdGsSelectionReactor pReactor)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProc_supportsSubentitySelection(OdGiViewport.getCPtr(pView), (int)mode, OdGsSelectionReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProc_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiSelectProc()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSelectProc(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiSelectProc) != GetType();
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectProc_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiSelectProc));
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

	private void SwigDirectorMethodset(IntPtr pPoints, uint nPoints, int mode, IntPtr pReactor)
	{
		try
		{
			set((pPoints == IntPtr.Zero) ? null : new OdGePoint2d(pPoints, cMemoryOwn: false), nPoints, (OdGsView_SelectionMode)mode, (pReactor == IntPtr.Zero) ? null : new OdGsSelectionReactor(pReactor, cMemoryOwn: false));
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

	private void SwigDirectorMethodget(IntPtr points, OdGsView_SelectionMode mode)
	{
		try
		{
			get(new OdGePoint2dArray(points, cMemoryOwn: true), out mode);
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

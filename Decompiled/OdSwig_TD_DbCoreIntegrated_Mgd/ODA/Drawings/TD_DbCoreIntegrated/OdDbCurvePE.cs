using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbCurvePE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbCurvePE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbCurvePE_1();

	public delegate void SwigDelegateOdDbCurvePE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbCurvePE_3(IntPtr pCurve, IntPtr projPlane, IntPtr pProjCurve);

	public delegate int SwigDelegateOdDbCurvePE_4(IntPtr pCurve, IntPtr projPlane, IntPtr projDirection, IntPtr pProjCurve);

	public delegate int SwigDelegateOdDbCurvePE_5(IntPtr arg0, double arg1, IntPtr arg2);

	public delegate int SwigDelegateOdDbCurvePE_6(IntPtr arg0, IntPtr arg1, double arg2, IntPtr arg3);

	public delegate int SwigDelegateOdDbCurvePE_7(IntPtr arg0, IntPtr arg1, IntPtr arg2);

	public delegate int SwigDelegateOdDbCurvePE_8(IntPtr arg0, IntPtr arg1, IntPtr arg2);

	public delegate int SwigDelegateOdDbCurvePE_9(IntPtr pCurve, double param);

	public delegate int SwigDelegateOdDbCurvePE_10(IntPtr pCurve, bool extendStart, IntPtr toPoint);

	public delegate int SwigDelegateOdDbCurvePE_11(IntPtr pCurve, IntPtr spline);

	public delegate int SwigDelegateOdDbCurvePE_12(IntPtr pCurve, IntPtr givenPoint, IntPtr pointOnCurve, bool extend);

	public delegate int SwigDelegateOdDbCurvePE_13(IntPtr pCurve, IntPtr givenPoint, IntPtr pointOnCurve);

	public delegate int SwigDelegateOdDbCurvePE_14(IntPtr pCurve, IntPtr givenPoint, IntPtr normal, IntPtr pointOnCurve, bool extend);

	public delegate int SwigDelegateOdDbCurvePE_15(IntPtr pCurve, IntPtr givenPoint, IntPtr normal, IntPtr pointOnCurve);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbCurvePE_0 swigDelegate0;

	private SwigDelegateOdDbCurvePE_1 swigDelegate1;

	private SwigDelegateOdDbCurvePE_2 swigDelegate2;

	private SwigDelegateOdDbCurvePE_3 swigDelegate3;

	private SwigDelegateOdDbCurvePE_4 swigDelegate4;

	private SwigDelegateOdDbCurvePE_5 swigDelegate5;

	private SwigDelegateOdDbCurvePE_6 swigDelegate6;

	private SwigDelegateOdDbCurvePE_7 swigDelegate7;

	private SwigDelegateOdDbCurvePE_8 swigDelegate8;

	private SwigDelegateOdDbCurvePE_9 swigDelegate9;

	private SwigDelegateOdDbCurvePE_10 swigDelegate10;

	private SwigDelegateOdDbCurvePE_11 swigDelegate11;

	private SwigDelegateOdDbCurvePE_12 swigDelegate12;

	private SwigDelegateOdDbCurvePE_13 swigDelegate13;

	private SwigDelegateOdDbCurvePE_14 swigDelegate14;

	private SwigDelegateOdDbCurvePE_15 swigDelegate15;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdDbCurve),
		typeof(OdGePlane),
		typeof(OdDbCurve).MakeByRefType()
	};

	private static Type[] swigMethodTypes4 = new Type[4]
	{
		typeof(OdDbCurve),
		typeof(OdGePlane),
		typeof(OdGeVector3d),
		typeof(OdDbCurve).MakeByRefType()
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdDbCurve),
		typeof(double),
		typeof(OdRxObjectPtrArray)
	};

	private static Type[] swigMethodTypes6 = new Type[4]
	{
		typeof(OdDbCurve),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(OdRxObjectPtrArray)
	};

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(OdDbCurve),
		typeof(OdDoubleArray),
		typeof(OdRxObjectPtrArray)
	};

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(OdDbCurve),
		typeof(OdGePoint3dArray),
		typeof(OdRxObjectPtrArray)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdDbCurve),
		typeof(double)
	};

	private static Type[] swigMethodTypes10 = new Type[3]
	{
		typeof(OdDbCurve),
		typeof(bool),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(OdDbCurve),
		typeof(OdDbSpline).MakeByRefType()
	};

	private static Type[] swigMethodTypes12 = new Type[4]
	{
		typeof(OdDbCurve),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes13 = new Type[3]
	{
		typeof(OdDbCurve),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes14 = new Type[5]
	{
		typeof(OdDbCurve),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGePoint3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes15 = new Type[4]
	{
		typeof(OdDbCurve),
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGePoint3d)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbCurvePE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbCurvePE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbCurvePE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbCurvePE cast(OdRxObject pObj)
	{
		OdDbCurvePE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurvePE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_isASwigExplicitOdDbCurvePE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_queryXSwigExplicitOdDbCurvePE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbCurvePE createObject()
	{
		OdDbCurvePE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurvePE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getOrthoProjectedCurve(OdDbCurve pCurve, OdGePlane projPlane, ref OdDbCurve pProjCurve)
	{
		IntPtr jarg = ((pProjCurve == null) ? IntPtr.Zero : OdDbCurve.getCPtr(pProjCurve).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getOrthoProjectedCurve(swigCPtr, OdDbCurve.getCPtr(pCurve), OdGePlane.getCPtr(projPlane), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pProjCurve = null;
			}
			else if (jarg != intPtr)
			{
				pProjCurve = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getProjectedCurve(OdDbCurve pCurve, OdGePlane projPlane, OdGeVector3d projDirection, ref OdDbCurve pProjCurve)
	{
		IntPtr jarg = ((pProjCurve == null) ? IntPtr.Zero : OdDbCurve.getCPtr(pProjCurve).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getProjectedCurve(swigCPtr, OdDbCurve.getCPtr(pCurve), OdGePlane.getCPtr(projPlane), OdGeVector3d.getCPtr(projDirection), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pProjCurve = null;
			}
			else if (jarg != intPtr)
			{
				pProjCurve = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getOffsetCurves(OdDbCurve arg0, double arg1, OdRxObjectPtrArray arg2)
	{
		int result = (SwigDerivedClassHasMethod("getOffsetCurves", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getOffsetCurvesSwigExplicitOdDbCurvePE(swigCPtr, OdDbCurve.getCPtr(arg0), arg1, OdRxObjectPtrArray.getCPtr(arg2).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getOffsetCurves(swigCPtr, OdDbCurve.getCPtr(arg0), arg1, OdRxObjectPtrArray.getCPtr(arg2).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getOffsetCurvesGivenPlaneNormal(OdDbCurve arg0, OdGeVector3d arg1, double arg2, OdRxObjectPtrArray arg3)
	{
		int result = (SwigDerivedClassHasMethod("getOffsetCurvesGivenPlaneNormal", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getOffsetCurvesGivenPlaneNormalSwigExplicitOdDbCurvePE(swigCPtr, OdDbCurve.getCPtr(arg0), OdGeVector3d.getCPtr(arg1), arg2, OdRxObjectPtrArray.getCPtr(arg3).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getOffsetCurvesGivenPlaneNormal(swigCPtr, OdDbCurve.getCPtr(arg0), OdGeVector3d.getCPtr(arg1), arg2, OdRxObjectPtrArray.getCPtr(arg3).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSplitCurves(OdDbCurve arg0, OdDoubleArray arg1, OdRxObjectPtrArray arg2)
	{
		int result = (SwigDerivedClassHasMethod("getSplitCurves", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getSplitCurvesSwigExplicitOdDbCurvePE__SWIG_0(swigCPtr, OdDbCurve.getCPtr(arg0), OdDoubleArray.getCPtr(arg1).Handle, OdRxObjectPtrArray.getCPtr(arg2).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getSplitCurves__SWIG_0(swigCPtr, OdDbCurve.getCPtr(arg0), OdDoubleArray.getCPtr(arg1).Handle, OdRxObjectPtrArray.getCPtr(arg2).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSplitCurves(OdDbCurve arg0, OdGePoint3dArray arg1, OdRxObjectPtrArray arg2)
	{
		int result = (SwigDerivedClassHasMethod("getSplitCurves", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getSplitCurvesSwigExplicitOdDbCurvePE__SWIG_1(swigCPtr, OdDbCurve.getCPtr(arg0), OdGePoint3dArray.getCPtr(arg1).Handle, OdRxObjectPtrArray.getCPtr(arg2).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getSplitCurves__SWIG_1(swigCPtr, OdDbCurve.getCPtr(arg0), OdGePoint3dArray.getCPtr(arg1).Handle, OdRxObjectPtrArray.getCPtr(arg2).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult extend(OdDbCurve pCurve, double param)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_extend__SWIG_0(swigCPtr, OdDbCurve.getCPtr(pCurve), param);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult extend(OdDbCurve pCurve, bool extendStart, OdGePoint3d toPoint)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_extend__SWIG_1(swigCPtr, OdDbCurve.getCPtr(pCurve), extendStart, OdGePoint3d.getCPtr(toPoint));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSpline(OdDbCurve pCurve, ref OdDbSpline spline)
	{
		IntPtr jarg = ((spline == null) ? IntPtr.Zero : OdDbSpline.getCPtr(spline).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getSpline(swigCPtr, OdDbCurve.getCPtr(pCurve), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				spline = null;
			}
			else if (jarg != intPtr)
			{
				spline = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSpline>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getClosestPointTo(OdDbCurve pCurve, OdGePoint3d givenPoint, OdGePoint3d pointOnCurve, bool extend)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getClosestPointTo__SWIG_0(swigCPtr, OdDbCurve.getCPtr(pCurve), OdGePoint3d.getCPtr(givenPoint), OdGePoint3d.getCPtr(pointOnCurve), extend);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getClosestPointTo(OdDbCurve pCurve, OdGePoint3d givenPoint, OdGePoint3d pointOnCurve)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getClosestPointTo__SWIG_1(swigCPtr, OdDbCurve.getCPtr(pCurve), OdGePoint3d.getCPtr(givenPoint), OdGePoint3d.getCPtr(pointOnCurve));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getClosestPointTo(OdDbCurve pCurve, OdGePoint3d givenPoint, OdGeVector3d normal, OdGePoint3d pointOnCurve, bool extend)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getClosestPointTo__SWIG_2(swigCPtr, OdDbCurve.getCPtr(pCurve), OdGePoint3d.getCPtr(givenPoint), OdGeVector3d.getCPtr(normal), OdGePoint3d.getCPtr(pointOnCurve), extend);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getClosestPointTo(OdDbCurve pCurve, OdGePoint3d givenPoint, OdGeVector3d normal, OdGePoint3d pointOnCurve)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getClosestPointTo__SWIG_3(swigCPtr, OdDbCurve.getCPtr(pCurve), OdGePoint3d.getCPtr(givenPoint), OdGeVector3d.getCPtr(normal), OdGePoint3d.getCPtr(pointOnCurve));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbCurvePE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbCurvePE(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbCurvePE) != GetType();
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
		if (SwigDerivedClassHasMethod("getOrthoProjectedCurve", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetOrthoProjectedCurve;
		}
		if (SwigDerivedClassHasMethod("getProjectedCurve", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetProjectedCurve;
		}
		if (SwigDerivedClassHasMethod("getOffsetCurves", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetOffsetCurves;
		}
		if (SwigDerivedClassHasMethod("getOffsetCurvesGivenPlaneNormal", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetOffsetCurvesGivenPlaneNormal;
		}
		if (SwigDerivedClassHasMethod("getSplitCurves", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetSplitCurves__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getSplitCurves", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetSplitCurves__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("extend", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodextend__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("extend", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodextend__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getSpline", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetSpline;
		}
		if (SwigDerivedClassHasMethod("getClosestPointTo", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetClosestPointTo__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getClosestPointTo", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetClosestPointTo__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getClosestPointTo", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetClosestPointTo__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getClosestPointTo", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetClosestPointTo__SWIG_3;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCurvePE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbCurvePE));
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

	private int SwigDirectorMethodgetOrthoProjectedCurve(IntPtr pCurve, IntPtr projPlane, IntPtr pProjCurve)
	{
		OdSwigDirectorHelper.director_UnpackData(pProjCurve, out var pOriginalObject, out var pFunction);
		OdDbCurve pProjCurve2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getOrthoProjectedCurve(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(pCurve, bOwn: false, bTryAddToTransaction: false), new OdGePlane(projPlane, cMemoryOwn: false), ref pProjCurve2);
		}
		finally
		{
			IntPtr handle = OdDbCurve.getCPtr(pProjCurve2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pProjCurve);
		}
	}

	private int SwigDirectorMethodgetProjectedCurve(IntPtr pCurve, IntPtr projPlane, IntPtr projDirection, IntPtr pProjCurve)
	{
		OdSwigDirectorHelper.director_UnpackData(pProjCurve, out var pOriginalObject, out var pFunction);
		OdDbCurve pProjCurve2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getProjectedCurve(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(pCurve, bOwn: false, bTryAddToTransaction: false), new OdGePlane(projPlane, cMemoryOwn: false), new OdGeVector3d(projDirection, cMemoryOwn: false), ref pProjCurve2);
		}
		finally
		{
			IntPtr handle = OdDbCurve.getCPtr(pProjCurve2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pProjCurve);
		}
	}

	private int SwigDirectorMethodgetOffsetCurves(IntPtr arg0, double arg1, IntPtr arg2)
	{
		return (int)getOffsetCurves(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(arg0, bOwn: false, bTryAddToTransaction: false), arg1, new OdRxObjectPtrArray(arg2, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetOffsetCurvesGivenPlaneNormal(IntPtr arg0, IntPtr arg1, double arg2, IntPtr arg3)
	{
		return (int)getOffsetCurvesGivenPlaneNormal(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(arg0, bOwn: false, bTryAddToTransaction: false), new OdGeVector3d(arg1, cMemoryOwn: false), arg2, new OdRxObjectPtrArray(arg3, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetSplitCurves__SWIG_0(IntPtr arg0, IntPtr arg1, IntPtr arg2)
	{
		return (int)getSplitCurves(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(arg0, bOwn: false, bTryAddToTransaction: false), new OdDoubleArray(arg1, cMemoryOwn: true), new OdRxObjectPtrArray(arg2, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetSplitCurves__SWIG_1(IntPtr arg0, IntPtr arg1, IntPtr arg2)
	{
		return (int)getSplitCurves(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(arg0, bOwn: false, bTryAddToTransaction: false), new OdGePoint3dArray(arg1, cMemoryOwn: true), new OdRxObjectPtrArray(arg2, cMemoryOwn: true));
	}

	private int SwigDirectorMethodextend__SWIG_0(IntPtr pCurve, double param)
	{
		return (int)extend(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(pCurve, bOwn: false, bTryAddToTransaction: false), param);
	}

	private int SwigDirectorMethodextend__SWIG_1(IntPtr pCurve, bool extendStart, IntPtr toPoint)
	{
		return (int)extend(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(pCurve, bOwn: false, bTryAddToTransaction: false), extendStart, new OdGePoint3d(toPoint, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetSpline(IntPtr pCurve, IntPtr spline)
	{
		OdSwigDirectorHelper.director_UnpackData(spline, out var pOriginalObject, out var pFunction);
		OdDbSpline spline2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSpline>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getSpline(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(pCurve, bOwn: false, bTryAddToTransaction: false), ref spline2);
		}
		finally
		{
			IntPtr handle = OdDbSpline.getCPtr(spline2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(spline);
		}
	}

	private int SwigDirectorMethodgetClosestPointTo__SWIG_0(IntPtr pCurve, IntPtr givenPoint, IntPtr pointOnCurve, bool extend)
	{
		return (int)getClosestPointTo(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(pCurve, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(givenPoint, cMemoryOwn: false), new OdGePoint3d(pointOnCurve, cMemoryOwn: false), extend);
	}

	private int SwigDirectorMethodgetClosestPointTo__SWIG_1(IntPtr pCurve, IntPtr givenPoint, IntPtr pointOnCurve)
	{
		return (int)getClosestPointTo(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(pCurve, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(givenPoint, cMemoryOwn: false), new OdGePoint3d(pointOnCurve, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetClosestPointTo__SWIG_2(IntPtr pCurve, IntPtr givenPoint, IntPtr normal, IntPtr pointOnCurve, bool extend)
	{
		return (int)getClosestPointTo(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(pCurve, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(givenPoint, cMemoryOwn: false), new OdGeVector3d(normal, cMemoryOwn: false), new OdGePoint3d(pointOnCurve, cMemoryOwn: false), extend);
	}

	private int SwigDirectorMethodgetClosestPointTo__SWIG_3(IntPtr pCurve, IntPtr givenPoint, IntPtr normal, IntPtr pointOnCurve)
	{
		return (int)getClosestPointTo(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCurve>(pCurve, bOwn: false, bTryAddToTransaction: false), new OdGePoint3d(givenPoint, cMemoryOwn: false), new OdGeVector3d(normal, cMemoryOwn: false), new OdGePoint3d(pointOnCurve, cMemoryOwn: false));
	}
}

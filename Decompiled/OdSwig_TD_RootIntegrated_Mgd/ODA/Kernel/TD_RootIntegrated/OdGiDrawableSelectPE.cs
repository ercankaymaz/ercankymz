using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDrawableSelectPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiDrawableSelectPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiDrawableSelectPE_1();

	public delegate void SwigDelegateOdGiDrawableSelectPE_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiDrawableSelectPE_3(IntPtr pathNode, IntPtr pPoly, uint nbPolyPts, IntPtr tol, IntPtr transformWorldToEye, bool bNeedEyeDepth, IntPtr pSelectionReactor, IntPtr pCustomSelectShape, IntPtr pProjectionStartPoint);

	public delegate void SwigDelegateOdGiDrawableSelectPE_4(IntPtr pathNode, IntPtr pPoly, uint nbPolyPts, IntPtr tol, IntPtr transformWorldToEye, bool bNeedEyeDepth, IntPtr pSelectionReactor, IntPtr pCustomSelectShape);

	public delegate void SwigDelegateOdGiDrawableSelectPE_5(IntPtr pathNode, IntPtr pPoly, uint nbPolyPts, IntPtr tol, IntPtr transformWorldToEye, bool bNeedEyeDepth, IntPtr pSelectionReactor);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiDrawableSelectPE_0 swigDelegate0;

	private SwigDelegateOdGiDrawableSelectPE_1 swigDelegate1;

	private SwigDelegateOdGiDrawableSelectPE_2 swigDelegate2;

	private SwigDelegateOdGiDrawableSelectPE_3 swigDelegate3;

	private SwigDelegateOdGiDrawableSelectPE_4 swigDelegate4;

	private SwigDelegateOdGiDrawableSelectPE_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[9]
	{
		typeof(OdGiPathNode),
		typeof(OdGePoint2d),
		typeof(uint),
		typeof(OdGeTol),
		typeof(OdGeMatrix3d),
		typeof(bool),
		typeof(OdGiDrawablePESelectionReactor),
		typeof(OdSiShape),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes4 = new Type[8]
	{
		typeof(OdGiPathNode),
		typeof(OdGePoint2d),
		typeof(uint),
		typeof(OdGeTol),
		typeof(OdGeMatrix3d),
		typeof(bool),
		typeof(OdGiDrawablePESelectionReactor),
		typeof(OdSiShape)
	};

	private static Type[] swigMethodTypes5 = new Type[7]
	{
		typeof(OdGiPathNode),
		typeof(OdGePoint2d),
		typeof(uint),
		typeof(OdGeTol),
		typeof(OdGeMatrix3d),
		typeof(bool),
		typeof(OdGiDrawablePESelectionReactor)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDrawableSelectPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDrawableSelectPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDrawableSelectPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdGiDrawableSelectPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDrawableSelectPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiDrawableSelectPE) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdGiDrawableSelectPE cast(OdRxObject pObj)
	{
		OdGiDrawableSelectPE rXObject = Helpers.GetRXObject<OdGiDrawableSelectPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_isASwigExplicitOdGiDrawableSelectPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_queryXSwigExplicitOdGiDrawableSelectPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiDrawableSelectPE createObject()
	{
		OdGiDrawableSelectPE rXObject = Helpers.GetRXObject<OdGiDrawableSelectPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool canSelect(OdGiPathNode pathNode, out IntPtr nMarkersCovered)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_canSelect(swigCPtr, OdGiPathNode.getCPtr(pathNode), out nMarkersCovered);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void select(OdGiPathNode pathNode, OdGePoint2d pPoly, uint nbPolyPts, OdGeTol tol, OdGeMatrix3d transformWorldToEye, bool bNeedEyeDepth, OdGiDrawablePESelectionReactor pSelectionReactor, OdSiShape pCustomSelectShape, OdGePoint3d pProjectionStartPoint)
	{
		if (SwigDerivedClassHasMethod("select", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_selectSwigExplicitOdGiDrawableSelectPE__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(pathNode), OdGePoint2d.getCPtr(pPoly), nbPolyPts, OdGeTol.getCPtr(tol), OdGeMatrix3d.getCPtr(transformWorldToEye), bNeedEyeDepth, OdGiDrawablePESelectionReactor.getCPtr(pSelectionReactor), pCustomSelectShape.GetInterfaceCPtr(), OdGePoint3d.getCPtr(pProjectionStartPoint));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_select__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(pathNode), OdGePoint2d.getCPtr(pPoly), nbPolyPts, OdGeTol.getCPtr(tol), OdGeMatrix3d.getCPtr(transformWorldToEye), bNeedEyeDepth, OdGiDrawablePESelectionReactor.getCPtr(pSelectionReactor), pCustomSelectShape.GetInterfaceCPtr(), OdGePoint3d.getCPtr(pProjectionStartPoint));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void select(OdGiPathNode pathNode, OdGePoint2d pPoly, uint nbPolyPts, OdGeTol tol, OdGeMatrix3d transformWorldToEye, bool bNeedEyeDepth, OdGiDrawablePESelectionReactor pSelectionReactor, OdSiShape pCustomSelectShape)
	{
		if (SwigDerivedClassHasMethod("select", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_selectSwigExplicitOdGiDrawableSelectPE__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(pathNode), OdGePoint2d.getCPtr(pPoly), nbPolyPts, OdGeTol.getCPtr(tol), OdGeMatrix3d.getCPtr(transformWorldToEye), bNeedEyeDepth, OdGiDrawablePESelectionReactor.getCPtr(pSelectionReactor), pCustomSelectShape.GetInterfaceCPtr());
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_select__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(pathNode), OdGePoint2d.getCPtr(pPoly), nbPolyPts, OdGeTol.getCPtr(tol), OdGeMatrix3d.getCPtr(transformWorldToEye), bNeedEyeDepth, OdGiDrawablePESelectionReactor.getCPtr(pSelectionReactor), pCustomSelectShape.GetInterfaceCPtr());
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void select(OdGiPathNode pathNode, OdGePoint2d pPoly, uint nbPolyPts, OdGeTol tol, OdGeMatrix3d transformWorldToEye, bool bNeedEyeDepth, OdGiDrawablePESelectionReactor pSelectionReactor)
	{
		if (SwigDerivedClassHasMethod("select", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_selectSwigExplicitOdGiDrawableSelectPE__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(pathNode), OdGePoint2d.getCPtr(pPoly), nbPolyPts, OdGeTol.getCPtr(tol), OdGeMatrix3d.getCPtr(transformWorldToEye), bNeedEyeDepth, OdGiDrawablePESelectionReactor.getCPtr(pSelectionReactor));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_select__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(pathNode), OdGePoint2d.getCPtr(pPoly), nbPolyPts, OdGeTol.getCPtr(tol), OdGeMatrix3d.getCPtr(transformWorldToEye), bNeedEyeDepth, OdGiDrawablePESelectionReactor.getCPtr(pSelectionReactor));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("select", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodselect__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("select", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodselect__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("select", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodselect__SWIG_2;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableSelectPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiDrawableSelectPE));
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

	private void SwigDirectorMethodselect__SWIG_0(IntPtr pathNode, IntPtr pPoly, uint nbPolyPts, IntPtr tol, IntPtr transformWorldToEye, bool bNeedEyeDepth, IntPtr pSelectionReactor, IntPtr pCustomSelectShape, IntPtr pProjectionStartPoint)
	{
		try
		{
			select(new OdGiPathNode(pathNode, cMemoryOwn: false), (pPoly == IntPtr.Zero) ? null : new OdGePoint2d(pPoly, cMemoryOwn: false), nbPolyPts, new OdGeTol(tol, cMemoryOwn: false), new OdGeMatrix3d(transformWorldToEye, cMemoryOwn: false), bNeedEyeDepth, (pSelectionReactor == IntPtr.Zero) ? null : new OdGiDrawablePESelectionReactor(pSelectionReactor, cMemoryOwn: false), new OdSiShapeImpl(pCustomSelectShape, cMemoryOwn: false), (pProjectionStartPoint == IntPtr.Zero) ? null : new OdGePoint3d(pProjectionStartPoint, cMemoryOwn: false));
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

	private void SwigDirectorMethodselect__SWIG_1(IntPtr pathNode, IntPtr pPoly, uint nbPolyPts, IntPtr tol, IntPtr transformWorldToEye, bool bNeedEyeDepth, IntPtr pSelectionReactor, IntPtr pCustomSelectShape)
	{
		try
		{
			select(new OdGiPathNode(pathNode, cMemoryOwn: false), (pPoly == IntPtr.Zero) ? null : new OdGePoint2d(pPoly, cMemoryOwn: false), nbPolyPts, new OdGeTol(tol, cMemoryOwn: false), new OdGeMatrix3d(transformWorldToEye, cMemoryOwn: false), bNeedEyeDepth, (pSelectionReactor == IntPtr.Zero) ? null : new OdGiDrawablePESelectionReactor(pSelectionReactor, cMemoryOwn: false), new OdSiShapeImpl(pCustomSelectShape, cMemoryOwn: false));
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

	private void SwigDirectorMethodselect__SWIG_2(IntPtr pathNode, IntPtr pPoly, uint nbPolyPts, IntPtr tol, IntPtr transformWorldToEye, bool bNeedEyeDepth, IntPtr pSelectionReactor)
	{
		try
		{
			select(new OdGiPathNode(pathNode, cMemoryOwn: false), (pPoly == IntPtr.Zero) ? null : new OdGePoint2d(pPoly, cMemoryOwn: false), nbPolyPts, new OdGeTol(tol, cMemoryOwn: false), new OdGeMatrix3d(transformWorldToEye, cMemoryOwn: false), bNeedEyeDepth, (pSelectionReactor == IntPtr.Zero) ? null : new OdGiDrawablePESelectionReactor(pSelectionReactor, cMemoryOwn: false));
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

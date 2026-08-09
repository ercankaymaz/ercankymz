using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiConveyorContextWrapper : OdGiConveyorContext, IDisposable
{
	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_0();

	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_1();

	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_2();

	public delegate void SwigDelegateOdGiConveyorContextWrapper_3(IntPtr traits, IntPtr fillNormal);

	public delegate void SwigDelegateOdGiConveyorContextWrapper_4(IntPtr traits);

	public delegate bool SwigDelegateOdGiConveyorContextWrapper_5();

	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_6();

	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_7();

	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_8();

	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_9();

	public delegate void SwigDelegateOdGiConveyorContextWrapper_10();

	public delegate void SwigDelegateOdGiConveyorContextWrapper_11(IntPtr position, IntPtr direction, IntPtr upVector);

	public delegate bool SwigDelegateOdGiConveyorContextWrapper_12();

	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_13();

	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_14();

	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_15();

	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_16();

	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_17();

	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_18();

	public delegate IntPtr SwigDelegateOdGiConveyorContextWrapper_19();

	public delegate uint SwigDelegateOdGiConveyorContextWrapper_20();

	public delegate double SwigDelegateOdGiConveyorContextWrapper_21();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiConveyorContextWrapper_0 swigDelegate0;

	private SwigDelegateOdGiConveyorContextWrapper_1 swigDelegate1;

	private SwigDelegateOdGiConveyorContextWrapper_2 swigDelegate2;

	private SwigDelegateOdGiConveyorContextWrapper_3 swigDelegate3;

	private SwigDelegateOdGiConveyorContextWrapper_4 swigDelegate4;

	private SwigDelegateOdGiConveyorContextWrapper_5 swigDelegate5;

	private SwigDelegateOdGiConveyorContextWrapper_6 swigDelegate6;

	private SwigDelegateOdGiConveyorContextWrapper_7 swigDelegate7;

	private SwigDelegateOdGiConveyorContextWrapper_8 swigDelegate8;

	private SwigDelegateOdGiConveyorContextWrapper_9 swigDelegate9;

	private SwigDelegateOdGiConveyorContextWrapper_10 swigDelegate10;

	private SwigDelegateOdGiConveyorContextWrapper_11 swigDelegate11;

	private SwigDelegateOdGiConveyorContextWrapper_12 swigDelegate12;

	private SwigDelegateOdGiConveyorContextWrapper_13 swigDelegate13;

	private SwigDelegateOdGiConveyorContextWrapper_14 swigDelegate14;

	private SwigDelegateOdGiConveyorContextWrapper_15 swigDelegate15;

	private SwigDelegateOdGiConveyorContextWrapper_16 swigDelegate16;

	private SwigDelegateOdGiConveyorContextWrapper_17 swigDelegate17;

	private SwigDelegateOdGiConveyorContextWrapper_18 swigDelegate18;

	private SwigDelegateOdGiConveyorContextWrapper_19 swigDelegate19;

	private SwigDelegateOdGiConveyorContextWrapper_20 swigDelegate20;

	private SwigDelegateOdGiConveyorContextWrapper_21 swigDelegate21;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdGiSubEntityTraitsData),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGiSubEntityTraitsData) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiConveyorContextWrapper(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiConveyorContextWrapper obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiConveyorContextWrapper()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiConveyorContextWrapper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdGiConveyorContext.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_OdGiConveyorContext_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public OdGiConveyorContext getOriginalContext()
	{
		OdGiConveyorContext_Internal result = new OdGiConveyorContext_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_getOriginalContext(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setOriginalContext(OdGiConveyorContext pCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_setOriginalContext(swigCPtr, pCtx.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiContext giContext()
	{
		OdGiContext rXObject = Helpers.GetRXObject<OdGiContext>(SwigDerivedClassHasMethod("giContext", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_giContextSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_giContext(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiSubEntityTraits subEntityTraits()
	{
		OdGiSubEntityTraits rXObject = Helpers.GetRXObject<OdGiSubEntityTraits>(SwigDerivedClassHasMethod("subEntityTraits", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_subEntityTraitsSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_subEntityTraits(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiSubEntityTraitsData effectiveTraits()
	{
		OdGiSubEntityTraitsData result = new OdGiSubEntityTraitsData(SwigDerivedClassHasMethod("effectiveTraits", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_effectiveTraitsSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_effectiveTraits(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEffectiveTraits(OdGiSubEntityTraitsData traits, OdGeVector3d fillNormal)
	{
		if (SwigDerivedClassHasMethod("setEffectiveTraits", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_setEffectiveTraitsSwigExplicitOdGiConveyorContextWrapper__SWIG_0(swigCPtr, OdGiSubEntityTraitsData.getCPtr(traits), OdGeVector3d.getCPtr(fillNormal));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_setEffectiveTraits__SWIG_0(swigCPtr, OdGiSubEntityTraitsData.getCPtr(traits), OdGeVector3d.getCPtr(fillNormal));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEffectiveTraits(OdGiSubEntityTraitsData traits)
	{
		if (SwigDerivedClassHasMethod("setEffectiveTraits", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_setEffectiveTraitsSwigExplicitOdGiConveyorContextWrapper__SWIG_1(swigCPtr, OdGiSubEntityTraitsData.getCPtr(traits));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_setEffectiveTraits__SWIG_1(swigCPtr, OdGiSubEntityTraitsData.getCPtr(traits));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool effectivelyVisible()
	{
		bool result = (SwigDerivedClassHasMethod("effectivelyVisible", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_effectivelyVisibleSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_effectivelyVisible(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDrawableDesc currentDrawableDesc()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("currentDrawableDesc", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_currentDrawableDescSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_currentDrawableDesc(swigCPtr));
		OdGiDrawableDesc result = ((intPtr == IntPtr.Zero) ? null : new OdGiDrawableDesc(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDrawable currentDrawable()
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(SwigDerivedClassHasMethod("currentDrawable", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_currentDrawableSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_currentDrawable(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiViewport giViewport()
	{
		OdGiViewport rXObject = Helpers.GetRXObject<OdGiViewport>(SwigDerivedClassHasMethod("giViewport", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_giViewportSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_giViewport(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsView gsView()
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(SwigDerivedClassHasMethod("gsView", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_gsViewSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_gsView(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void onTraitsModified()
	{
		if (SwigDerivedClassHasMethod("onTraitsModified", swigMethodTypes10))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_onTraitsModifiedSwigExplicitOdGiConveyorContextWrapper(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_onTraitsModified(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onTextProcessing(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector)
	{
		if (SwigDerivedClassHasMethod("onTextProcessing", swigMethodTypes11))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_onTextProcessingSwigExplicitOdGiConveyorContextWrapper(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_onTextProcessing(swigCPtr, OdGePoint3d.getCPtr(position), OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool regenAbort()
	{
		bool result = (SwigDerivedClassHasMethod("regenAbort", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_regenAbortSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_regenAbort(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiPathNode currentGiPath()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("currentGiPath", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_currentGiPathSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_currentGiPath(swigCPtr));
		OdGiPathNode result = ((intPtr == IntPtr.Zero) ? null : new OdGiPathNode(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDeviation worldDeviation()
	{
		OdGiDeviation_Internal result = new OdGiDeviation_Internal(SwigDerivedClassHasMethod("worldDeviation", swigMethodTypes14) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_worldDeviationSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_worldDeviation(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDeviation modelDeviation()
	{
		OdGiDeviation_Internal result = new OdGiDeviation_Internal(SwigDerivedClassHasMethod("modelDeviation", swigMethodTypes15) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_modelDeviationSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_modelDeviation(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDeviation eyeDeviation()
	{
		OdGiDeviation_Internal result = new OdGiDeviation_Internal(SwigDerivedClassHasMethod("eyeDeviation", swigMethodTypes16) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_eyeDeviationSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_eyeDeviation(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getModelToWorldTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("getModelToWorldTransform", swigMethodTypes17) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_getModelToWorldTransformSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_getModelToWorldTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getWorldToModelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("getWorldToModelTransform", swigMethodTypes18) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_getWorldToModelTransformSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_getWorldToModelTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiLineweightOverride currentLineweightOverride()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("currentLineweightOverride", swigMethodTypes19) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_currentLineweightOverrideSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_currentLineweightOverride(swigCPtr));
		OdGiLineweightOverride result = ((intPtr == IntPtr.Zero) ? null : new OdGiLineweightOverride(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint drawContextFlags()
	{
		uint result = (SwigDerivedClassHasMethod("drawContextFlags", swigMethodTypes20) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_drawContextFlagsSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_drawContextFlags(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double annotationScale()
	{
		double result = (SwigDerivedClassHasMethod("annotationScale", swigMethodTypes21) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_annotationScaleSwigExplicitOdGiConveyorContextWrapper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_annotationScale(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("giContext", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgiContext;
		}
		if (SwigDerivedClassHasMethod("subEntityTraits", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodsubEntityTraits;
		}
		if (SwigDerivedClassHasMethod("effectiveTraits", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodeffectiveTraits;
		}
		if (SwigDerivedClassHasMethod("setEffectiveTraits", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetEffectiveTraits__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setEffectiveTraits", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetEffectiveTraits__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("effectivelyVisible", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodeffectivelyVisible;
		}
		if (SwigDerivedClassHasMethod("currentDrawableDesc", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcurrentDrawableDesc;
		}
		if (SwigDerivedClassHasMethod("currentDrawable", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodcurrentDrawable;
		}
		if (SwigDerivedClassHasMethod("giViewport", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgiViewport;
		}
		if (SwigDerivedClassHasMethod("gsView", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgsView;
		}
		if (SwigDerivedClassHasMethod("onTraitsModified", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodonTraitsModified;
		}
		if (SwigDerivedClassHasMethod("onTextProcessing", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodonTextProcessing;
		}
		if (SwigDerivedClassHasMethod("regenAbort", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodregenAbort;
		}
		if (SwigDerivedClassHasMethod("currentGiPath", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodcurrentGiPath;
		}
		if (SwigDerivedClassHasMethod("worldDeviation", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodworldDeviation;
		}
		if (SwigDerivedClassHasMethod("modelDeviation", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodmodelDeviation;
		}
		if (SwigDerivedClassHasMethod("eyeDeviation", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodeyeDeviation;
		}
		if (SwigDerivedClassHasMethod("getModelToWorldTransform", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetModelToWorldTransform;
		}
		if (SwigDerivedClassHasMethod("getWorldToModelTransform", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetWorldToModelTransform;
		}
		if (SwigDerivedClassHasMethod("currentLineweightOverride", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodcurrentLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("drawContextFlags", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethoddrawContextFlags;
		}
		if (SwigDerivedClassHasMethod("annotationScale", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodannotationScale;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContextWrapper_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiConveyorContextWrapper));
	}

	private IntPtr SwigDirectorMethodgiContext()
	{
		return OdGiContext.getCPtr(giContext()).Handle;
	}

	private IntPtr SwigDirectorMethodsubEntityTraits()
	{
		return OdGiSubEntityTraits.getCPtr(subEntityTraits()).Handle;
	}

	private IntPtr SwigDirectorMethodeffectiveTraits()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiSubEntityTraitsData.getCPtr(effectiveTraits()).Handle;
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

	private void SwigDirectorMethodsetEffectiveTraits__SWIG_0(IntPtr traits, IntPtr fillNormal)
	{
		try
		{
			setEffectiveTraits(new OdGiSubEntityTraitsData(traits, cMemoryOwn: false), (fillNormal == IntPtr.Zero) ? null : new OdGeVector3d(fillNormal, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetEffectiveTraits__SWIG_1(IntPtr traits)
	{
		try
		{
			setEffectiveTraits(new OdGiSubEntityTraitsData(traits, cMemoryOwn: false));
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

	private bool SwigDirectorMethodeffectivelyVisible()
	{
		return effectivelyVisible();
	}

	private IntPtr SwigDirectorMethodcurrentDrawableDesc()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiDrawableDesc.getCPtr(currentDrawableDesc()).Handle;
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

	private IntPtr SwigDirectorMethodcurrentDrawable()
	{
		return OdGiDrawable.getCPtr(currentDrawable()).Handle;
	}

	private IntPtr SwigDirectorMethodgiViewport()
	{
		return OdGiViewport.getCPtr(giViewport()).Handle;
	}

	private IntPtr SwigDirectorMethodgsView()
	{
		return OdGsView.getCPtr(gsView()).Handle;
	}

	private void SwigDirectorMethodonTraitsModified()
	{
		try
		{
			onTraitsModified();
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

	private void SwigDirectorMethodonTextProcessing(IntPtr position, IntPtr direction, IntPtr upVector)
	{
		try
		{
			onTextProcessing(new OdGePoint3d(position, cMemoryOwn: false), new OdGeVector3d(direction, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false));
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

	private bool SwigDirectorMethodregenAbort()
	{
		return regenAbort();
	}

	private IntPtr SwigDirectorMethodcurrentGiPath()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiPathNode.getCPtr(currentGiPath()).Handle;
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

	private IntPtr SwigDirectorMethodworldDeviation()
	{
		return worldDeviation().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodmodelDeviation()
	{
		return modelDeviation().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodeyeDeviation()
	{
		return eyeDeviation().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodgetModelToWorldTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getModelToWorldTransform()).Handle;
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

	private IntPtr SwigDirectorMethodgetWorldToModelTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getWorldToModelTransform()).Handle;
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

	private IntPtr SwigDirectorMethodcurrentLineweightOverride()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiLineweightOverride.getCPtr(currentLineweightOverride()).Handle;
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

	private uint SwigDirectorMethoddrawContextFlags()
	{
		return drawContextFlags();
	}

	private double SwigDirectorMethodannotationScale()
	{
		return annotationScale();
	}
}

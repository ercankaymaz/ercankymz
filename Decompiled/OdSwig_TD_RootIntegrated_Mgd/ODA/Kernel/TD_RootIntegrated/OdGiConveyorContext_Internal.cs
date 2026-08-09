using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiConveyorContext_Internal : OdGiConveyorContext, IDisposable
{
	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_0();

	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_1();

	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_2();

	public delegate void SwigDelegateOdGiConveyorContext_Internal_3(IntPtr traits, IntPtr fillNormal);

	public delegate void SwigDelegateOdGiConveyorContext_Internal_4(IntPtr traits);

	public delegate bool SwigDelegateOdGiConveyorContext_Internal_5();

	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_6();

	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_7();

	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_8();

	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_9();

	public delegate void SwigDelegateOdGiConveyorContext_Internal_10();

	public delegate void SwigDelegateOdGiConveyorContext_Internal_11(IntPtr arg0, IntPtr arg1, IntPtr arg2);

	public delegate bool SwigDelegateOdGiConveyorContext_Internal_12();

	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_13();

	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_14();

	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_15();

	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_16();

	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_17();

	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_18();

	public delegate IntPtr SwigDelegateOdGiConveyorContext_Internal_19();

	public delegate uint SwigDelegateOdGiConveyorContext_Internal_20();

	public delegate double SwigDelegateOdGiConveyorContext_Internal_21();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiConveyorContext_Internal_0 swigDelegate0;

	private SwigDelegateOdGiConveyorContext_Internal_1 swigDelegate1;

	private SwigDelegateOdGiConveyorContext_Internal_2 swigDelegate2;

	private SwigDelegateOdGiConveyorContext_Internal_3 swigDelegate3;

	private SwigDelegateOdGiConveyorContext_Internal_4 swigDelegate4;

	private SwigDelegateOdGiConveyorContext_Internal_5 swigDelegate5;

	private SwigDelegateOdGiConveyorContext_Internal_6 swigDelegate6;

	private SwigDelegateOdGiConveyorContext_Internal_7 swigDelegate7;

	private SwigDelegateOdGiConveyorContext_Internal_8 swigDelegate8;

	private SwigDelegateOdGiConveyorContext_Internal_9 swigDelegate9;

	private SwigDelegateOdGiConveyorContext_Internal_10 swigDelegate10;

	private SwigDelegateOdGiConveyorContext_Internal_11 swigDelegate11;

	private SwigDelegateOdGiConveyorContext_Internal_12 swigDelegate12;

	private SwigDelegateOdGiConveyorContext_Internal_13 swigDelegate13;

	private SwigDelegateOdGiConveyorContext_Internal_14 swigDelegate14;

	private SwigDelegateOdGiConveyorContext_Internal_15 swigDelegate15;

	private SwigDelegateOdGiConveyorContext_Internal_16 swigDelegate16;

	private SwigDelegateOdGiConveyorContext_Internal_17 swigDelegate17;

	private SwigDelegateOdGiConveyorContext_Internal_18 swigDelegate18;

	private SwigDelegateOdGiConveyorContext_Internal_19 swigDelegate19;

	private SwigDelegateOdGiConveyorContext_Internal_20 swigDelegate20;

	private SwigDelegateOdGiConveyorContext_Internal_21 swigDelegate21;

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
	public OdGiConveyorContext_Internal(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiConveyorContext_Internal obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiConveyorContext_Internal()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiConveyorContext_Internal(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdGiConveyorContext.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_OdGiConveyorContext_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public virtual OdGiContext giContext()
	{
		OdGiContext rXObject = Helpers.GetRXObject<OdGiContext>(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_giContext(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiSubEntityTraits subEntityTraits()
	{
		OdGiSubEntityTraits rXObject = Helpers.GetRXObject<OdGiSubEntityTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_subEntityTraits(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiSubEntityTraitsData effectiveTraits()
	{
		OdGiSubEntityTraitsData result = new OdGiSubEntityTraitsData(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_effectiveTraits(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEffectiveTraits(OdGiSubEntityTraitsData traits, OdGeVector3d fillNormal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_setEffectiveTraits__SWIG_0(swigCPtr, OdGiSubEntityTraitsData.getCPtr(traits), OdGeVector3d.getCPtr(fillNormal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEffectiveTraits(OdGiSubEntityTraitsData traits)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_setEffectiveTraits__SWIG_1(swigCPtr, OdGiSubEntityTraitsData.getCPtr(traits));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool effectivelyVisible()
	{
		bool result = (SwigDerivedClassHasMethod("effectivelyVisible", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_effectivelyVisibleSwigExplicitOdGiConveyorContext_Internal(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_effectivelyVisible(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDrawableDesc currentDrawableDesc()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_currentDrawableDesc(swigCPtr);
		OdGiDrawableDesc result = ((intPtr == IntPtr.Zero) ? null : new OdGiDrawableDesc(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDrawable currentDrawable()
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_currentDrawable(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiViewport giViewport()
	{
		OdGiViewport rXObject = Helpers.GetRXObject<OdGiViewport>(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_giViewport(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsView gsView()
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_gsView(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void onTraitsModified()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_onTraitsModified(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onTextProcessing(OdGePoint3d arg0, OdGeVector3d arg1, OdGeVector3d arg2)
	{
		if (SwigDerivedClassHasMethod("onTextProcessing", swigMethodTypes11))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_onTextProcessingSwigExplicitOdGiConveyorContext_Internal(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGeVector3d.getCPtr(arg1), OdGeVector3d.getCPtr(arg2));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_onTextProcessing(swigCPtr, OdGePoint3d.getCPtr(arg0), OdGeVector3d.getCPtr(arg1), OdGeVector3d.getCPtr(arg2));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool regenAbort()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_regenAbort(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiPathNode currentGiPath()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_currentGiPath(swigCPtr);
		OdGiPathNode result = ((intPtr == IntPtr.Zero) ? null : new OdGiPathNode(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDeviation worldDeviation()
	{
		OdGiDeviation_Internal result = new OdGiDeviation_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_worldDeviation(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDeviation modelDeviation()
	{
		OdGiDeviation_Internal result = new OdGiDeviation_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_modelDeviation(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDeviation eyeDeviation()
	{
		OdGiDeviation_Internal result = new OdGiDeviation_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_eyeDeviation(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getModelToWorldTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_getModelToWorldTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getWorldToModelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_getWorldToModelTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiLineweightOverride currentLineweightOverride()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("currentLineweightOverride", swigMethodTypes19) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_currentLineweightOverrideSwigExplicitOdGiConveyorContext_Internal(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_currentLineweightOverride(swigCPtr));
		OdGiLineweightOverride result = ((intPtr == IntPtr.Zero) ? null : new OdGiLineweightOverride(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint drawContextFlags()
	{
		uint result = (SwigDerivedClassHasMethod("drawContextFlags", swigMethodTypes20) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_drawContextFlagsSwigExplicitOdGiConveyorContext_Internal(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_drawContextFlags(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double annotationScale()
	{
		double result = (SwigDerivedClassHasMethod("annotationScale", swigMethodTypes21) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_annotationScaleSwigExplicitOdGiConveyorContext_Internal(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_annotationScale(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiConveyorContext_Internal()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiConveyorContext_Internal(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiConveyorContext_Internal) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiConveyorContext_Internal_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiConveyorContext_Internal));
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

	private void SwigDirectorMethodonTextProcessing(IntPtr arg0, IntPtr arg1, IntPtr arg2)
	{
		try
		{
			onTextProcessing(new OdGePoint3d(arg0, cMemoryOwn: false), new OdGeVector3d(arg1, cMemoryOwn: false), new OdGeVector3d(arg2, cMemoryOwn: false));
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

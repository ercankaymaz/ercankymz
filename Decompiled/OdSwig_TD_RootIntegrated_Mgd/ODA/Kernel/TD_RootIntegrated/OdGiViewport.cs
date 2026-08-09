using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiViewport : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiViewport_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiViewport_1();

	public delegate void SwigDelegateOdGiViewport_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiViewport_3();

	public delegate IntPtr SwigDelegateOdGiViewport_4();

	public delegate IntPtr SwigDelegateOdGiViewport_5();

	public delegate IntPtr SwigDelegateOdGiViewport_6();

	public delegate bool SwigDelegateOdGiViewport_7();

	public delegate bool SwigDelegateOdGiViewport_8(IntPtr point);

	public delegate bool SwigDelegateOdGiViewport_9(IntPtr point);

	public delegate void SwigDelegateOdGiViewport_10(IntPtr point, IntPtr pixelDensity, bool bUsePerspective);

	public delegate void SwigDelegateOdGiViewport_11(IntPtr point, IntPtr pixelDensity);

	public delegate IntPtr SwigDelegateOdGiViewport_12();

	public delegate IntPtr SwigDelegateOdGiViewport_13();

	public delegate IntPtr SwigDelegateOdGiViewport_14();

	public delegate IntPtr SwigDelegateOdGiViewport_15();

	public delegate uint SwigDelegateOdGiViewport_16();

	public delegate short SwigDelegateOdGiViewport_17();

	public delegate void SwigDelegateOdGiViewport_18(IntPtr lowerLeft, IntPtr upperRight);

	public delegate bool SwigDelegateOdGiViewport_19(bool clipFront, bool clipBack, double front, double back);

	public delegate double SwigDelegateOdGiViewport_20();

	public delegate double SwigDelegateOdGiViewport_21();

	public delegate bool SwigDelegateOdGiViewport_22(IntPtr layerId);

	public delegate IntPtr SwigDelegateOdGiViewport_23();

	public delegate IntPtr SwigDelegateOdGiViewport_24();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiViewport_0 swigDelegate0;

	private SwigDelegateOdGiViewport_1 swigDelegate1;

	private SwigDelegateOdGiViewport_2 swigDelegate2;

	private SwigDelegateOdGiViewport_3 swigDelegate3;

	private SwigDelegateOdGiViewport_4 swigDelegate4;

	private SwigDelegateOdGiViewport_5 swigDelegate5;

	private SwigDelegateOdGiViewport_6 swigDelegate6;

	private SwigDelegateOdGiViewport_7 swigDelegate7;

	private SwigDelegateOdGiViewport_8 swigDelegate8;

	private SwigDelegateOdGiViewport_9 swigDelegate9;

	private SwigDelegateOdGiViewport_10 swigDelegate10;

	private SwigDelegateOdGiViewport_11 swigDelegate11;

	private SwigDelegateOdGiViewport_12 swigDelegate12;

	private SwigDelegateOdGiViewport_13 swigDelegate13;

	private SwigDelegateOdGiViewport_14 swigDelegate14;

	private SwigDelegateOdGiViewport_15 swigDelegate15;

	private SwigDelegateOdGiViewport_16 swigDelegate16;

	private SwigDelegateOdGiViewport_17 swigDelegate17;

	private SwigDelegateOdGiViewport_18 swigDelegate18;

	private SwigDelegateOdGiViewport_19 swigDelegate19;

	private SwigDelegateOdGiViewport_20 swigDelegate20;

	private SwigDelegateOdGiViewport_21 swigDelegate21;

	private SwigDelegateOdGiViewport_22 swigDelegate22;

	private SwigDelegateOdGiViewport_23 swigDelegate23;

	private SwigDelegateOdGiViewport_24 swigDelegate24;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes10 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint2d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[2]
	{
		typeof(OdGePoint2d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes19 = new Type[4]
	{
		typeof(bool).MakeByRefType(),
		typeof(bool).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiViewport(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiViewport obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiViewport(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiViewport cast(OdRxObject pObj)
	{
		OdGiViewport rXObject = Helpers.GetRXObject<OdGiViewport>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_isASwigExplicitOdGiViewport(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_queryXSwigExplicitOdGiViewport(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiViewport createObject()
	{
		OdGiViewport rXObject = Helpers.GetRXObject<OdGiViewport>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGeMatrix3d getModelToEyeTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_getModelToEyeTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getEyeToModelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_getEyeToModelTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getWorldToEyeTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_getWorldToEyeTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d getEyeToWorldTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_getEyeToWorldTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isPerspective()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_isPerspective(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool doPerspective(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_doPerspective(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool doInversePerspective(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_doInversePerspective(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getNumPixelsInUnitSquare(OdGePoint3d point, OdGePoint2d pixelDensity, bool bUsePerspective)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_getNumPixelsInUnitSquare__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGePoint2d.getCPtr(pixelDensity), bUsePerspective);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getNumPixelsInUnitSquare(OdGePoint3d point, OdGePoint2d pixelDensity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_getNumPixelsInUnitSquare__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point), OdGePoint2d.getCPtr(pixelDensity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint3d getCameraLocation()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_getCameraLocation(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getCameraTarget()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_getCameraTarget(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d getCameraUpVector()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_getCameraUpVector(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d viewDir()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_viewDir(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint viewportId()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_viewportId(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short acadWindowId()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_acadWindowId(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getViewportDcCorners(OdGePoint2d lowerLeft, OdGePoint2d upperRight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_getViewportDcCorners(swigCPtr, OdGePoint2d.getCPtr(lowerLeft), OdGePoint2d.getCPtr(upperRight));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getFrontAndBackClipValues(out bool clipFront, out bool clipBack, out double front, out double back)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_getFrontAndBackClipValues(swigCPtr, out clipFront, out clipBack, out front, out back);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double linetypeScaleMultiplier()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_linetypeScaleMultiplier(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double linetypeGenerationCriteria()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_linetypeGenerationCriteria(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool layerVisible(OdDbStub layerId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_layerVisible(swigCPtr, OdDbStub.getCPtr(layerId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiContextualColors contextualColors()
	{
		OdGiContextualColors rXObject = Helpers.GetRXObject<OdGiContextualColors>(SwigDerivedClassHasMethod("contextualColors", swigMethodTypes23) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_contextualColorsSwigExplicitOdGiViewport(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_contextualColors(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbStub annotationScaleId()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("annotationScaleId", swigMethodTypes24) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_annotationScaleIdSwigExplicitOdGiViewport(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_annotationScaleId(swigCPtr));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiViewport()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiViewport(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiViewport) != GetType();
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
		if (SwigDerivedClassHasMethod("getModelToEyeTransform", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetModelToEyeTransform;
		}
		if (SwigDerivedClassHasMethod("getEyeToModelTransform", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetEyeToModelTransform;
		}
		if (SwigDerivedClassHasMethod("getWorldToEyeTransform", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetWorldToEyeTransform;
		}
		if (SwigDerivedClassHasMethod("getEyeToWorldTransform", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetEyeToWorldTransform;
		}
		if (SwigDerivedClassHasMethod("isPerspective", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodisPerspective;
		}
		if (SwigDerivedClassHasMethod("doPerspective", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddoPerspective;
		}
		if (SwigDerivedClassHasMethod("doInversePerspective", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethoddoInversePerspective;
		}
		if (SwigDerivedClassHasMethod("getNumPixelsInUnitSquare", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getNumPixelsInUnitSquare", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getCameraLocation", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetCameraLocation;
		}
		if (SwigDerivedClassHasMethod("getCameraTarget", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetCameraTarget;
		}
		if (SwigDerivedClassHasMethod("getCameraUpVector", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetCameraUpVector;
		}
		if (SwigDerivedClassHasMethod("viewDir", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodviewDir;
		}
		if (SwigDerivedClassHasMethod("viewportId", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodviewportId;
		}
		if (SwigDerivedClassHasMethod("acadWindowId", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodacadWindowId;
		}
		if (SwigDerivedClassHasMethod("getViewportDcCorners", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetViewportDcCorners;
		}
		if (SwigDerivedClassHasMethod("getFrontAndBackClipValues", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodgetFrontAndBackClipValues;
		}
		if (SwigDerivedClassHasMethod("linetypeScaleMultiplier", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodlinetypeScaleMultiplier;
		}
		if (SwigDerivedClassHasMethod("linetypeGenerationCriteria", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodlinetypeGenerationCriteria;
		}
		if (SwigDerivedClassHasMethod("layerVisible", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodlayerVisible;
		}
		if (SwigDerivedClassHasMethod("contextualColors", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodcontextualColors;
		}
		if (SwigDerivedClassHasMethod("annotationScaleId", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodannotationScaleId;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiViewport_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiViewport));
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

	private IntPtr SwigDirectorMethodgetModelToEyeTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getModelToEyeTransform()).Handle;
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

	private IntPtr SwigDirectorMethodgetEyeToModelTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getEyeToModelTransform()).Handle;
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

	private IntPtr SwigDirectorMethodgetWorldToEyeTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getWorldToEyeTransform()).Handle;
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

	private IntPtr SwigDirectorMethodgetEyeToWorldTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getEyeToWorldTransform()).Handle;
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

	private bool SwigDirectorMethodisPerspective()
	{
		return isPerspective();
	}

	private bool SwigDirectorMethoddoPerspective(IntPtr point)
	{
		return doPerspective(new OdGePoint3d(point, cMemoryOwn: false));
	}

	private bool SwigDirectorMethoddoInversePerspective(IntPtr point)
	{
		return doInversePerspective(new OdGePoint3d(point, cMemoryOwn: false));
	}

	private void SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_0(IntPtr point, IntPtr pixelDensity, bool bUsePerspective)
	{
		try
		{
			getNumPixelsInUnitSquare(new OdGePoint3d(point, cMemoryOwn: false), new OdGePoint2d(pixelDensity, cMemoryOwn: false), bUsePerspective);
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

	private void SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_1(IntPtr point, IntPtr pixelDensity)
	{
		try
		{
			getNumPixelsInUnitSquare(new OdGePoint3d(point, cMemoryOwn: false), new OdGePoint2d(pixelDensity, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodgetCameraLocation()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getCameraLocation()).Handle;
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

	private IntPtr SwigDirectorMethodgetCameraTarget()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getCameraTarget()).Handle;
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

	private IntPtr SwigDirectorMethodgetCameraUpVector()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(getCameraUpVector()).Handle;
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

	private IntPtr SwigDirectorMethodviewDir()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(viewDir()).Handle;
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

	private uint SwigDirectorMethodviewportId()
	{
		return viewportId();
	}

	private short SwigDirectorMethodacadWindowId()
	{
		return acadWindowId();
	}

	private void SwigDirectorMethodgetViewportDcCorners(IntPtr lowerLeft, IntPtr upperRight)
	{
		try
		{
			getViewportDcCorners(new OdGePoint2d(lowerLeft, cMemoryOwn: false), new OdGePoint2d(upperRight, cMemoryOwn: false));
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

	private bool SwigDirectorMethodgetFrontAndBackClipValues(bool clipFront, bool clipBack, double front, double back)
	{
		return getFrontAndBackClipValues(out clipFront, out clipBack, out front, out back);
	}

	private double SwigDirectorMethodlinetypeScaleMultiplier()
	{
		return linetypeScaleMultiplier();
	}

	private double SwigDirectorMethodlinetypeGenerationCriteria()
	{
		return linetypeGenerationCriteria();
	}

	private bool SwigDirectorMethodlayerVisible(IntPtr layerId)
	{
		return layerVisible((layerId == IntPtr.Zero) ? null : new OdDbStub(layerId, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodcontextualColors()
	{
		return OdGiContextualColors.getCPtr(contextualColors()).Handle;
	}

	private IntPtr SwigDirectorMethodannotationScaleId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(annotationScaleId()).Handle;
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
}

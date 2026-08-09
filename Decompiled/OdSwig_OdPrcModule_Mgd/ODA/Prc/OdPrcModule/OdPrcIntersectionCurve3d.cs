using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcIntersectionCurve3d : OdPrcCurve3d
{
	public delegate IntPtr SwigDelegateOdPrcIntersectionCurve3d_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcIntersectionCurve3d_1();

	public delegate void SwigDelegateOdPrcIntersectionCurve3d_2(IntPtr pSource);

	public delegate void SwigDelegateOdPrcIntersectionCurve3d_3(IntPtr pStream);

	public delegate void SwigDelegateOdPrcIntersectionCurve3d_4(IntPtr pStream);

	public delegate bool SwigDelegateOdPrcIntersectionCurve3d_5();

	public delegate int SwigDelegateOdPrcIntersectionCurve3d_6(IntPtr pGeCurve, IntPtr tol);

	public delegate int SwigDelegateOdPrcIntersectionCurve3d_7(IntPtr pGeCurve);

	public delegate int SwigDelegateOdPrcIntersectionCurve3d_8(IntPtr geCurve, IntPtr tol);

	public delegate int SwigDelegateOdPrcIntersectionCurve3d_9(IntPtr geCurve);

	public delegate uint SwigDelegateOdPrcIntersectionCurve3d_10();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcIntersectionCurve3d_0 swigDelegate0;

	private SwigDelegateOdPrcIntersectionCurve3d_1 swigDelegate1;

	private SwigDelegateOdPrcIntersectionCurve3d_2 swigDelegate2;

	private SwigDelegateOdPrcIntersectionCurve3d_3 swigDelegate3;

	private SwigDelegateOdPrcIntersectionCurve3d_4 swigDelegate4;

	private SwigDelegateOdPrcIntersectionCurve3d_5 swigDelegate5;

	private SwigDelegateOdPrcIntersectionCurve3d_6 swigDelegate6;

	private SwigDelegateOdPrcIntersectionCurve3d_7 swigDelegate7;

	private SwigDelegateOdPrcIntersectionCurve3d_8 swigDelegate8;

	private SwigDelegateOdPrcIntersectionCurve3d_9 swigDelegate9;

	private SwigDelegateOdPrcIntersectionCurve3d_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdGeCurve3d).MakeByRefType(),
		typeof(OdGeTol)
	};

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGeCurve3d).MakeByRefType() };

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdGeCurve3d),
		typeof(OdGeTol)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGeCurve3d) };

	private static Type[] swigMethodTypes10 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcIntersectionCurve3d(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcIntersectionCurve3d obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcIntersectionCurve3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcIntersectionCurve3d()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcIntersectionCurve3d(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcIntersectionCurve3d) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual uint prcType()
	{
		uint result = (SwigDerivedClassHasMethod("prcType", swigMethodTypes10) ? OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_prcTypeSwigExplicitOdPrcIntersectionCurve3d(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_prcType(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdPrcIntersectionCurve3d cast(OdRxObject pObj)
	{
		OdPrcIntersectionCurve3d rXObject = Helpers.GetRXObject<OdPrcIntersectionCurve3d>(OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_isASwigExplicitOdPrcIntersectionCurve3d(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_queryXSwigExplicitOdPrcIntersectionCurve3d(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcIntersectionCurve3d createObject()
	{
		OdPrcIntersectionCurve3d rXObject = Helpers.GetRXObject<OdPrcIntersectionCurve3d>(OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void prcOut(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes3))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_prcOutSwigExplicitOdPrcIntersectionCurve3d(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void prcIn(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes4))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_prcInSwigExplicitOdPrcIntersectionCurve3d(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d endLimitPoint()
	{
		OdGePoint3d result = new OdGePoint3d(OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_endLimitPoint__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d startLimitPoint()
	{
		OdGePoint3d result = new OdGePoint3d(OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_startLimitPoint__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcCrossingPointsCrvIntersectionArray crossingPointsCrvIntersection()
	{
		OdPrcCrossingPointsCrvIntersectionArray result = new OdPrcCrossingPointsCrvIntersectionArray(OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_crossingPointsCrvIntersection__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAngularError(double angular_error)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_setAngularError(swigCPtr, angular_error);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double angularError()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_angularError(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setChordalError(double chordal_error)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_setChordalError(swigCPtr, chordal_error);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double chordalError()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_chordalError(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setParameterizationDefinitionRespected(bool parameterization_definition_respected)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_setParameterizationDefinitionRespected(swigCPtr, parameterization_definition_respected);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool parameterizationDefinitionRespected()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_parameterizationDefinitionRespected(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIntersectionSense(bool intersection_sense)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_setIntersectionSense(swigCPtr, intersection_sense);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool intersectionSense()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_intersectionSense(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSurface2Sense(bool surface_2_sense)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_setSurface2Sense(swigCPtr, surface_2_sense);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool surface2Sense()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_surface2Sense(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSurface1Sense(bool surface_1_sense)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_setSurface1Sense(swigCPtr, surface_1_sense);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool surface1Sense()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_surface1Sense(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setSurface1(OdPrcSurface value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_setSurface1(swigCPtr, OdPrcSurface.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdPrcSurface surface1()
	{
		OdPrcSurface rXObject = Helpers.GetRXObject<OdPrcSurface>(OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_surface1(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult setSurface2(OdPrcSurface value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_setSurface2(swigCPtr, OdPrcSurface.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdPrcSurface surface2()
	{
		OdPrcSurface rXObject = Helpers.GetRXObject<OdPrcSurface>(OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_surface2(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult setStartLimitType(uint value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_setStartLimitType(swigCPtr, value);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public uint startLimitType()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_startLimitType(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setEndLimitType(uint value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_setEndLimitType(swigCPtr, value);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public uint endLimitType()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_endLimitType(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setendLimitPoint(OdGePoint3d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_setendLimitPoint(swigCPtr, OdGePoint3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setstartLimitPoint(OdGePoint3d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_setstartLimitPoint(swigCPtr, OdGePoint3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setcrossingPointsCrvIntersection(OdPrcCrossingPointsCrvIntersectionArray value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_setcrossingPointsCrvIntersection(swigCPtr, OdPrcCrossingPointsCrvIntersectionArray.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
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
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodprcOut;
		}
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodprcIn;
		}
		if (SwigDerivedClassHasMethod("is3d", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodis3d;
		}
		if (SwigDerivedClassHasMethod("getOdGeCurve", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetOdGeCurve__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getOdGeCurve", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetOdGeCurve__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setFromOdGeCurve", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetFromOdGeCurve__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setFromOdGeCurve", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetFromOdGeCurve__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("prcType", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodprcType;
		}
		OdPrcModule_GlobalsPINVOKE.OdPrcIntersectionCurve3d_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcIntersectionCurve3d));
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodprcOut(IntPtr pStream)
	{
		try
		{
			prcOut(Helpers.GetRXObject<OdPrcCompressedFiler>(pStream, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodprcIn(IntPtr pStream)
	{
		try
		{
			prcIn(Helpers.GetRXObject<OdPrcCompressedFiler>(pStream, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodis3d()
	{
		return is3d();
	}

	private int SwigDirectorMethodgetOdGeCurve__SWIG_0(IntPtr pGeCurve, IntPtr tol)
	{
		OdGeCurve3d pGeCurve2 = new OdGeCurve3d(pGeCurve, cMemoryOwn: true);
		try
		{
			return (int)getOdGeCurve(out pGeCurve2, new OdGeTol(tol, cMemoryOwn: false));
		}
		finally
		{
			pGeCurve = OdGeCurve3d.getCPtr(pGeCurve2).Handle;
		}
	}

	private int SwigDirectorMethodgetOdGeCurve__SWIG_1(IntPtr pGeCurve)
	{
		OdGeCurve3d pGeCurve2 = new OdGeCurve3d(pGeCurve, cMemoryOwn: true);
		try
		{
			return (int)getOdGeCurve(out pGeCurve2);
		}
		finally
		{
			pGeCurve = OdGeCurve3d.getCPtr(pGeCurve2).Handle;
		}
	}

	private int SwigDirectorMethodsetFromOdGeCurve__SWIG_0(IntPtr geCurve, IntPtr tol)
	{
		return (int)setFromOdGeCurve(Helpers.GetObject<OdGeCurve3d>(geCurve, bOwn: false, bTryAddToTransaction: false), new OdGeTol(tol, cMemoryOwn: false));
	}

	private int SwigDirectorMethodsetFromOdGeCurve__SWIG_1(IntPtr geCurve)
	{
		return (int)setFromOdGeCurve(Helpers.GetObject<OdGeCurve3d>(geCurve, bOwn: false, bTryAddToTransaction: false));
	}

	private uint SwigDirectorMethodprcType()
	{
		return prcType();
	}
}

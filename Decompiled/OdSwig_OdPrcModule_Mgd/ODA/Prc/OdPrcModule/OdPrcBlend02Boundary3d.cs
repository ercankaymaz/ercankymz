using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcBlend02Boundary3d : OdPrcCurve3d
{
	public delegate IntPtr SwigDelegateOdPrcBlend02Boundary3d_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcBlend02Boundary3d_1();

	public delegate void SwigDelegateOdPrcBlend02Boundary3d_2(IntPtr pSource);

	public delegate void SwigDelegateOdPrcBlend02Boundary3d_3(IntPtr pStream);

	public delegate void SwigDelegateOdPrcBlend02Boundary3d_4(IntPtr pStream);

	public delegate bool SwigDelegateOdPrcBlend02Boundary3d_5();

	public delegate int SwigDelegateOdPrcBlend02Boundary3d_6(IntPtr pGeCurve, IntPtr tol);

	public delegate int SwigDelegateOdPrcBlend02Boundary3d_7(IntPtr pGeCurve);

	public delegate int SwigDelegateOdPrcBlend02Boundary3d_8(IntPtr geCurve, IntPtr tol);

	public delegate int SwigDelegateOdPrcBlend02Boundary3d_9(IntPtr geCurve);

	public delegate uint SwigDelegateOdPrcBlend02Boundary3d_10();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcBlend02Boundary3d_0 swigDelegate0;

	private SwigDelegateOdPrcBlend02Boundary3d_1 swigDelegate1;

	private SwigDelegateOdPrcBlend02Boundary3d_2 swigDelegate2;

	private SwigDelegateOdPrcBlend02Boundary3d_3 swigDelegate3;

	private SwigDelegateOdPrcBlend02Boundary3d_4 swigDelegate4;

	private SwigDelegateOdPrcBlend02Boundary3d_5 swigDelegate5;

	private SwigDelegateOdPrcBlend02Boundary3d_6 swigDelegate6;

	private SwigDelegateOdPrcBlend02Boundary3d_7 swigDelegate7;

	private SwigDelegateOdPrcBlend02Boundary3d_8 swigDelegate8;

	private SwigDelegateOdPrcBlend02Boundary3d_9 swigDelegate9;

	private SwigDelegateOdPrcBlend02Boundary3d_10 swigDelegate10;

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
	public OdPrcBlend02Boundary3d(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcBlend02Boundary3d obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcBlend02Boundary3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcBlend02Boundary3d()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcBlend02Boundary3d(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcBlend02Boundary3d) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual uint prcType()
	{
		uint result = (SwigDerivedClassHasMethod("prcType", swigMethodTypes10) ? OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_prcTypeSwigExplicitOdPrcBlend02Boundary3d(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_prcType(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdPrcBlend02Boundary3d cast(OdRxObject pObj)
	{
		OdPrcBlend02Boundary3d rXObject = Helpers.GetRXObject<OdPrcBlend02Boundary3d>(OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_isASwigExplicitOdPrcBlend02Boundary3d(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_queryXSwigExplicitOdPrcBlend02Boundary3d(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcBlend02Boundary3d createObject()
	{
		OdPrcBlend02Boundary3d rXObject = Helpers.GetRXObject<OdPrcBlend02Boundary3d>(OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_createObject(), bOwn: true, bTryAddToTransaction: true);
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
			OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_prcOutSwigExplicitOdPrcBlend02Boundary3d(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
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
			OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_prcInSwigExplicitOdPrcBlend02Boundary3d(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d endLimitPoint()
	{
		OdGePoint3d result = new OdGePoint3d(OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_endLimitPoint__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d startLimitPoint()
	{
		OdGePoint3d result = new OdGePoint3d(OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_startLimitPoint__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3dArray crossingPointPositions()
	{
		OdGePoint3dArray result = new OdGePoint3dArray(OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_crossingPointPositions__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBaseScale(double base_scale)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setBaseScale(swigCPtr, base_scale);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double baseScale()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_baseScale(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBaseParameter(double base_parameter)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setBaseParameter(swigCPtr, base_parameter);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double baseParameter()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_baseParameter(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAngularError(double angular_error)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setAngularError(swigCPtr, angular_error);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double angularError()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_angularError(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setChordalError(double chordal_error)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setChordalError(swigCPtr, chordal_error);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double chordalError()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_chordalError(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIntersectionCurveSens(bool intersection_curve_sens)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setIntersectionCurveSens(swigCPtr, intersection_curve_sens);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool intersectionCurveSens()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_intersectionCurveSens(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIntersectionOrder(bool intersection_order)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setIntersectionOrder(swigCPtr, intersection_order);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool intersectionOrder()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_intersectionOrder(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBoundingSurfaceSens(bool bounding_surface_sens)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setBoundingSurfaceSens(swigCPtr, bounding_surface_sens);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool boundingSurfaceSens()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_boundingSurfaceSens(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setBlend(OdPrcBlend02Surface value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setBlend(swigCPtr, OdPrcBlend02Surface.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdPrcBlend02Surface blend()
	{
		OdPrcBlend02Surface rXObject = Helpers.GetRXObject<OdPrcBlend02Surface>(OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_blend(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult setBound(byte value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setBound(swigCPtr, value);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public byte bound()
	{
		byte result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_bound(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setBoundingSurface(OdPrcSurface value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setBoundingSurface(swigCPtr, OdPrcSurface.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdPrcSurface boundingSurface()
	{
		OdPrcSurface rXObject = Helpers.GetRXObject<OdPrcSurface>(OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_boundingSurface(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult setStartLimitType(uint value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setStartLimitType(swigCPtr, value);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public uint startLimitType()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_startLimitType(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setEndLimitType(uint value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setEndLimitType(swigCPtr, value);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public uint endLimitType()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_endLimitType(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setstartLimitPoint(OdGePoint3d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setstartLimitPoint(swigCPtr, OdGePoint3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setendLimitPoint(OdGePoint3d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setendLimitPoint(swigCPtr, OdGePoint3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setcrossingPointPositions(OdGePoint3dArray value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_setcrossingPointPositions(swigCPtr, OdGePoint3dArray.getCPtr(value));
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
		OdPrcModule_GlobalsPINVOKE.OdPrcBlend02Boundary3d_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcBlend02Boundary3d));
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

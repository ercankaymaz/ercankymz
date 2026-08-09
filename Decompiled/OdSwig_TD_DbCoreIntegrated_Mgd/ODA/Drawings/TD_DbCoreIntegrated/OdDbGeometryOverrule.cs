using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeometryOverrule : OdRxOverrule
{
	public delegate IntPtr SwigDelegateOdDbGeometryOverrule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeometryOverrule_1();

	public delegate void SwigDelegateOdDbGeometryOverrule_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbGeometryOverrule_3(IntPtr pOverruledSubject);

	public delegate int SwigDelegateOdDbGeometryOverrule_4(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbGeometryOverrule_5(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbGeometryOverrule_6(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr points);

	public delegate int SwigDelegateOdDbGeometryOverrule_7(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbGeometryOverrule_8(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbGeometryOverrule_9(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points);

	public delegate int SwigDelegateOdDbGeometryOverrule_10(IntPtr pSubject, IntPtr extents);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeometryOverrule_0 swigDelegate0;

	private SwigDelegateOdDbGeometryOverrule_1 swigDelegate1;

	private SwigDelegateOdDbGeometryOverrule_2 swigDelegate2;

	private SwigDelegateOdDbGeometryOverrule_3 swigDelegate3;

	private SwigDelegateOdDbGeometryOverrule_4 swigDelegate4;

	private SwigDelegateOdDbGeometryOverrule_5 swigDelegate5;

	private SwigDelegateOdDbGeometryOverrule_6 swigDelegate6;

	private SwigDelegateOdDbGeometryOverrule_7 swigDelegate7;

	private SwigDelegateOdDbGeometryOverrule_8 swigDelegate8;

	private SwigDelegateOdDbGeometryOverrule_9 swigDelegate9;

	private SwigDelegateOdDbGeometryOverrule_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[6]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray),
		typeof(IntPtr),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes5 = new Type[5]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes6 = new Type[4]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes7 = new Type[7]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray),
		typeof(IntPtr),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes8 = new Type[6]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes9 = new Type[5]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdGeExtents3d)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeometryOverrule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeometryOverrule obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeometryOverrule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbGeometryOverrule()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbGeometryOverrule(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbGeometryOverrule cast(OdRxObject pObj)
	{
		OdDbGeometryOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeometryOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_isASwigExplicitOdDbGeometryOverrule(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_queryXSwigExplicitOdDbGeometryOverrule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbGeometryOverrule createObject()
	{
		OdDbGeometryOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeometryOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult intersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_intersectWithSwigExplicitOdDbGeometryOverrule__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_intersectWith__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points, IntPtr thisGsMarker)
	{
		int result = (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_intersectWithSwigExplicitOdDbGeometryOverrule__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_intersectWith__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points)
	{
		int result = (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_intersectWithSwigExplicitOdDbGeometryOverrule__SWIG_2(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_intersectWith__SWIG_2(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_intersectWithSwigExplicitOdDbGeometryOverrule__SWIG_3(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_intersectWith__SWIG_3(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points, IntPtr thisGsMarker)
	{
		int result = (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_intersectWithSwigExplicitOdDbGeometryOverrule__SWIG_4(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_intersectWith__SWIG_4(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points)
	{
		int result = (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_intersectWithSwigExplicitOdDbGeometryOverrule__SWIG_5(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_intersectWith__SWIG_5(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getGeomExtents(OdDbEntity pSubject, OdGeExtents3d extents)
	{
		int result = (SwigDerivedClassHasMethod("getGeomExtents", swigMethodTypes10) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_getGeomExtentsSwigExplicitOdDbGeometryOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdGeExtents3d.getCPtr(extents)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_getGeomExtents(swigCPtr, OdDbEntity.getCPtr(pSubject), OdGeExtents3d.getCPtr(extents)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("isApplicable", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisApplicable;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodintersectWith__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodintersectWith__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodintersectWith__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodintersectWith__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodintersectWith__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodintersectWith__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("getGeomExtents", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetGeomExtents;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeometryOverrule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeometryOverrule));
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

	private bool SwigDirectorMethodisApplicable(IntPtr pOverruledSubject)
	{
		return isApplicable(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pOverruledSubject, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodintersectWith__SWIG_0(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		return (int)intersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThisEnt, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePoint3dArray(points, cMemoryOwn: true), thisGsMarker, otherGsMarker);
	}

	private int SwigDirectorMethodintersectWith__SWIG_1(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker)
	{
		return (int)intersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThisEnt, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePoint3dArray(points, cMemoryOwn: true), thisGsMarker);
	}

	private int SwigDirectorMethodintersectWith__SWIG_2(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr points)
	{
		return (int)intersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThisEnt, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePoint3dArray(points, cMemoryOwn: true));
	}

	private int SwigDirectorMethodintersectWith__SWIG_3(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		return (int)intersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThisEnt, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePlane(projPlane, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: true), thisGsMarker, otherGsMarker);
	}

	private int SwigDirectorMethodintersectWith__SWIG_4(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker)
	{
		return (int)intersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThisEnt, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePlane(projPlane, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: true), thisGsMarker);
	}

	private int SwigDirectorMethodintersectWith__SWIG_5(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points)
	{
		return (int)intersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThisEnt, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePlane(projPlane, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetGeomExtents(IntPtr pSubject, IntPtr extents)
	{
		return (int)getGeomExtents(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdGeExtents3d(extents, cMemoryOwn: false));
	}
}

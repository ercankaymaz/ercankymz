using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbEntityIntersectionPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbEntityIntersectionPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbEntityIntersectionPE_1();

	public delegate void SwigDelegateOdDbEntityIntersectionPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbEntityIntersectionPE_3(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbEntityIntersectionPE_4(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbEntityIntersectionPE_5(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr points);

	public delegate int SwigDelegateOdDbEntityIntersectionPE_6(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbEntityIntersectionPE_7(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker);

	public delegate int SwigDelegateOdDbEntityIntersectionPE_8(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points);

	public delegate int SwigDelegateOdDbEntityIntersectionPE_9(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate int SwigDelegateOdDbEntityIntersectionPE_10(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbEntityIntersectionPE_0 swigDelegate0;

	private SwigDelegateOdDbEntityIntersectionPE_1 swigDelegate1;

	private SwigDelegateOdDbEntityIntersectionPE_2 swigDelegate2;

	private SwigDelegateOdDbEntityIntersectionPE_3 swigDelegate3;

	private SwigDelegateOdDbEntityIntersectionPE_4 swigDelegate4;

	private SwigDelegateOdDbEntityIntersectionPE_5 swigDelegate5;

	private SwigDelegateOdDbEntityIntersectionPE_6 swigDelegate6;

	private SwigDelegateOdDbEntityIntersectionPE_7 swigDelegate7;

	private SwigDelegateOdDbEntityIntersectionPE_8 swigDelegate8;

	private SwigDelegateOdDbEntityIntersectionPE_9 swigDelegate9;

	private SwigDelegateOdDbEntityIntersectionPE_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[6]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray),
		typeof(IntPtr),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes4 = new Type[5]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes5 = new Type[4]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes6 = new Type[7]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray),
		typeof(IntPtr),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes7 = new Type[6]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes8 = new Type[5]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes9 = new Type[6]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePoint3dArray),
		typeof(IntPtr),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes10 = new Type[7]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray),
		typeof(IntPtr),
		typeof(IntPtr)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbEntityIntersectionPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbEntityIntersectionPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbEntityIntersectionPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbEntityIntersectionPE cast(OdRxObject pObj)
	{
		OdDbEntityIntersectionPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntityIntersectionPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_isASwigExplicitOdDbEntityIntersectionPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_queryXSwigExplicitOdDbEntityIntersectionPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbEntityIntersectionPE createObject()
	{
		OdDbEntityIntersectionPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntityIntersectionPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult intersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_intersectWith__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points, IntPtr thisGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_intersectWith__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_intersectWith__SWIG_2(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_intersectWith__SWIG_3(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points, IntPtr thisGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_intersectWith__SWIG_4(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult intersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_intersectWith__SWIG_5(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult boundingBoxIntersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_boundingBoxIntersectWith__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult boundingBoxIntersectWith(OdDbEntity pThisEnt, OdDbEntity pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_boundingBoxIntersectWith__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pThisEnt), OdDbEntity.getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points).Handle, thisGsMarker, otherGsMarker);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbEntityIntersectionPE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbEntityIntersectionPE(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbEntityIntersectionPE) != GetType();
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
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodintersectWith__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodintersectWith__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodintersectWith__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodintersectWith__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodintersectWith__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodintersectWith__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("boundingBoxIntersectWith", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodboundingBoxIntersectWith__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("boundingBoxIntersectWith", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodboundingBoxIntersectWith__SWIG_1;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityIntersectionPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbEntityIntersectionPE));
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

	private int SwigDirectorMethodboundingBoxIntersectWith__SWIG_0(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		return (int)boundingBoxIntersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThisEnt, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePoint3dArray(points, cMemoryOwn: true), thisGsMarker, otherGsMarker);
	}

	private int SwigDirectorMethodboundingBoxIntersectWith__SWIG_1(IntPtr pThisEnt, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		return (int)boundingBoxIntersectWith(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThisEnt, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, new OdGePlane(projPlane, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: true), thisGsMarker, otherGsMarker);
	}
}

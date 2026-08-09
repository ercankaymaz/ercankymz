using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbOsnapPointRef : OdDbPointRef
{
	public delegate IntPtr SwigDelegateOdDbOsnapPointRef_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbOsnapPointRef_1();

	public delegate void SwigDelegateOdDbOsnapPointRef_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbOsnapPointRef_3(IntPtr pt);

	public delegate int SwigDelegateOdDbOsnapPointRef_4(IntPtr ents, bool getLastPtRef);

	public delegate int SwigDelegateOdDbOsnapPointRef_5(IntPtr ents);

	public delegate bool SwigDelegateOdDbOsnapPointRef_6();

	public delegate bool SwigDelegateOdDbOsnapPointRef_7(IntPtr ids1, IntPtr ids2, bool isMainObj);

	public delegate bool SwigDelegateOdDbOsnapPointRef_8(IntPtr ids1, IntPtr ids2);

	public delegate int SwigDelegateOdDbOsnapPointRef_9();

	public delegate int SwigDelegateOdDbOsnapPointRef_10(IntPtr idMap);

	public delegate void SwigDelegateOdDbOsnapPointRef_11(IntPtr pFiler);

	public delegate void SwigDelegateOdDbOsnapPointRef_12(IntPtr pFiler);

	public delegate void SwigDelegateOdDbOsnapPointRef_13(IntPtr pFiler);

	public delegate int SwigDelegateOdDbOsnapPointRef_14(IntPtr filer);

	public delegate void SwigDelegateOdDbOsnapPointRef_15(bool inMirror);

	public delegate void SwigDelegateOdDbOsnapPointRef_16();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbOsnapPointRef_0 swigDelegate0;

	private SwigDelegateOdDbOsnapPointRef_1 swigDelegate1;

	private SwigDelegateOdDbOsnapPointRef_2 swigDelegate2;

	private SwigDelegateOdDbOsnapPointRef_3 swigDelegate3;

	private SwigDelegateOdDbOsnapPointRef_4 swigDelegate4;

	private SwigDelegateOdDbOsnapPointRef_5 swigDelegate5;

	private SwigDelegateOdDbOsnapPointRef_6 swigDelegate6;

	private SwigDelegateOdDbOsnapPointRef_7 swigDelegate7;

	private SwigDelegateOdDbOsnapPointRef_8 swigDelegate8;

	private SwigDelegateOdDbOsnapPointRef_9 swigDelegate9;

	private SwigDelegateOdDbOsnapPointRef_10 swigDelegate10;

	private SwigDelegateOdDbOsnapPointRef_11 swigDelegate11;

	private SwigDelegateOdDbOsnapPointRef_12 swigDelegate12;

	private SwigDelegateOdDbOsnapPointRef_13 swigDelegate13;

	private SwigDelegateOdDbOsnapPointRef_14 swigDelegate14;

	private SwigDelegateOdDbOsnapPointRef_15 swigDelegate15;

	private SwigDelegateOdDbOsnapPointRef_16 swigDelegate16;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbFullSubentPathArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbFullSubentPathArray) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(OdDbObjectIdArray),
		typeof(OdDbObjectIdArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdDbObjectIdArray),
		typeof(OdDbObjectIdArray)
	};

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdDbIdMapping).MakeByRefType() };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes16 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbOsnapPointRef(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbOsnapPointRef obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbOsnapPointRef(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbOsnapPointRef()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbOsnapPointRef(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbOsnapPointRef) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdDbOsnapPointRef cast(OdRxObject pObj)
	{
		OdDbOsnapPointRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbOsnapPointRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_isASwigExplicitOdDbOsnapPointRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_queryXSwigExplicitOdDbOsnapPointRef(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OsnapMode osnapType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_osnapType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OsnapMode)result;
	}

	public void setOsnapType(OsnapMode osnapMode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_setOsnapType(swigCPtr, (int)osnapMode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbXrefFullSubentPath mainEntity()
	{
		OdDbXrefFullSubentPath result = new OdDbXrefFullSubentPath(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_mainEntity(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbXrefFullSubentPath intersectEntity()
	{
		OdDbXrefFullSubentPath result = new OdDbXrefFullSubentPath(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_intersectEntity(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getIdPath(OdDbFullSubentPath idPath)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_getIdPath(swigCPtr, OdDbFullSubentPath.getCPtr(idPath));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setIdPath(OdDbFullSubentPath idPath)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_setIdPath(swigCPtr, OdDbFullSubentPath.getCPtr(idPath));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getIntIdPath(OdDbFullSubentPath intIdPath)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_getIntIdPath(swigCPtr, OdDbFullSubentPath.getCPtr(intIdPath));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setIntIdPath(OdDbFullSubentPath intIdPath)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_setIntIdPath(swigCPtr, OdDbFullSubentPath.getCPtr(intIdPath));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double nearPointParam()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_nearPointParam(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNearPointParam(double nearOsnap)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_setNearPointParam(swigCPtr, nearOsnap);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d point()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_point(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPoint(OdGePoint3d pt)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_setPoint(swigCPtr, OdGePoint3d.getCPtr(pt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbOsnapPointRef lastPointRef()
	{
		OdDbOsnapPointRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbOsnapPointRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_lastPointRef__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setLastPointRef(OdDbOsnapPointRef pOsnapPointRef)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_setLastPointRef(swigCPtr, getCPtr(pOsnapPointRef));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGeomErased()
	{
		bool result = (SwigDerivedClassHasMethod("isGeomErased", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_isGeomErasedSwigExplicitOdDbOsnapPointRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_isGeomErased(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isXrefObj(OdDbObjectIdArray ids1, OdDbObjectIdArray ids2, bool isMainObj)
	{
		bool result = (SwigDerivedClassHasMethod("isXrefObj", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_isXrefObjSwigExplicitOdDbOsnapPointRef__SWIG_0(swigCPtr, OdDbObjectIdArray.getCPtr(ids1), OdDbObjectIdArray.getCPtr(ids2), isMainObj) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_isXrefObj__SWIG_0(swigCPtr, OdDbObjectIdArray.getCPtr(ids1), OdDbObjectIdArray.getCPtr(ids2), isMainObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isXrefObj(OdDbObjectIdArray ids1, OdDbObjectIdArray ids2)
	{
		bool result = (SwigDerivedClassHasMethod("isXrefObj", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_isXrefObjSwigExplicitOdDbOsnapPointRef__SWIG_1(swigCPtr, OdDbObjectIdArray.getCPtr(ids1), OdDbObjectIdArray.getCPtr(ids2)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_isXrefObj__SWIG_1(swigCPtr, OdDbObjectIdArray.getCPtr(ids1), OdDbObjectIdArray.getCPtr(ids2)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult updateXrefSubentPath()
	{
		int result = (SwigDerivedClassHasMethod("updateXrefSubentPath", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_updateXrefSubentPathSwigExplicitOdDbOsnapPointRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_updateXrefSubentPath(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult updateSubentPath(ref OdDbIdMapping idMap)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = (SwigDerivedClassHasMethod("updateSubentPath", swigMethodTypes10) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_updateSubentPathSwigExplicitOdDbOsnapPointRef(swigCPtr, ref jarg) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_updateSubentPath(swigCPtr, ref jarg));
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
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public override OdResult evalPoint(OdGePoint3d pt)
	{
		int result = (SwigDerivedClassHasMethod("evalPoint", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_evalPointSwigExplicitOdDbOsnapPointRef(swigCPtr, OdGePoint3d.getCPtr(pt)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_evalPoint(swigCPtr, OdGePoint3d.getCPtr(pt)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getEntities(OdDbFullSubentPathArray ents, bool getLastPtRef)
	{
		int result = (SwigDerivedClassHasMethod("getEntities", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_getEntitiesSwigExplicitOdDbOsnapPointRef__SWIG_0(swigCPtr, OdDbFullSubentPathArray.getCPtr(ents), getLastPtRef) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_getEntities__SWIG_0(swigCPtr, OdDbFullSubentPathArray.getCPtr(ents), getLastPtRef));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override OdResult getEntities(OdDbFullSubentPathArray ents)
	{
		int result = (SwigDerivedClassHasMethod("getEntities", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_getEntitiesSwigExplicitOdDbOsnapPointRef__SWIG_1(swigCPtr, OdDbFullSubentPathArray.getCPtr(ents)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_getEntities__SWIG_1(swigCPtr, OdDbFullSubentPathArray.getCPtr(ents)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void updateDueToMirror(bool inMirror)
	{
		if (SwigDerivedClassHasMethod("updateDueToMirror", swigMethodTypes15))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_updateDueToMirrorSwigExplicitOdDbOsnapPointRef__SWIG_0(swigCPtr, inMirror);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_updateDueToMirror__SWIG_0(swigCPtr, inMirror);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void updateDueToMirror()
	{
		if (SwigDerivedClassHasMethod("updateDueToMirror", swigMethodTypes16))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_updateDueToMirrorSwigExplicitOdDbOsnapPointRef__SWIG_1(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_updateDueToMirror__SWIG_1(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getXrefHandles(OdHandleArray xrefHandles)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_getXrefHandles(swigCPtr, OdHandleArray.getCPtr(xrefHandles).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setXrefHandles(OdHandleArray xrefHandles)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_setXrefHandles(swigCPtr, OdHandleArray.getCPtr(xrefHandles).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getXrefIntHandles(OdHandleArray xrefHandles)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_getXrefIntHandles(swigCPtr, OdHandleArray.getCPtr(xrefHandles).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setXrefIntHandles(OdHandleArray xrefHandles)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_setXrefIntHandles(swigCPtr, OdHandleArray.getCPtr(xrefHandles).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void dwgInFields(OdDbDwgFiler pFiler)
	{
		if (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes12))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_dwgInFieldsSwigExplicitOdDbOsnapPointRef(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void dwgOutFields(OdDbDwgFiler pFiler)
	{
		if (SwigDerivedClassHasMethod("dwgOutFields", swigMethodTypes11))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_dwgOutFieldsSwigExplicitOdDbOsnapPointRef(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void dxfOutFields(OdDbDxfFiler pFiler)
	{
		if (SwigDerivedClassHasMethod("dxfOutFields", swigMethodTypes13))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_dxfOutFieldsSwigExplicitOdDbOsnapPointRef(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler filer)
	{
		int result = (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes14) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_dxfInFieldsSwigExplicitOdDbOsnapPointRef(swigCPtr, OdDbDxfFiler.getCPtr(filer)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(filer)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbOsnapPointRef createObject()
	{
		OdDbOsnapPointRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbOsnapPointRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("evalPoint", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodevalPoint;
		}
		if (SwigDerivedClassHasMethod("getEntities", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetEntities__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getEntities", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetEntities__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isGeomErased", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodisGeomErased;
		}
		if (SwigDerivedClassHasMethod("isXrefObj", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodisXrefObj__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("isXrefObj", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodisXrefObj__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("updateXrefSubentPath", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodupdateXrefSubentPath;
		}
		if (SwigDerivedClassHasMethod("updateSubentPath", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodupdateSubentPath;
		}
		if (SwigDerivedClassHasMethod("dwgOutFields", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethoddwgOutFields;
		}
		if (SwigDerivedClassHasMethod("dwgInFields", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethoddwgInFields;
		}
		if (SwigDerivedClassHasMethod("dxfOutFields", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethoddxfOutFields;
		}
		if (SwigDerivedClassHasMethod("dxfInFields", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethoddxfInFields;
		}
		if (SwigDerivedClassHasMethod("updateDueToMirror", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodupdateDueToMirror__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("updateDueToMirror", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodupdateDueToMirror__SWIG_1;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbOsnapPointRef_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbOsnapPointRef));
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

	private int SwigDirectorMethodevalPoint(IntPtr pt)
	{
		return (int)evalPoint(new OdGePoint3d(pt, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetEntities__SWIG_0(IntPtr ents, bool getLastPtRef)
	{
		return (int)getEntities(new OdDbFullSubentPathArray(ents, cMemoryOwn: false), getLastPtRef);
	}

	private int SwigDirectorMethodgetEntities__SWIG_1(IntPtr ents)
	{
		return (int)getEntities(new OdDbFullSubentPathArray(ents, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisGeomErased()
	{
		return isGeomErased();
	}

	private bool SwigDirectorMethodisXrefObj__SWIG_0(IntPtr ids1, IntPtr ids2, bool isMainObj)
	{
		return isXrefObj(new OdDbObjectIdArray(ids1, cMemoryOwn: false), new OdDbObjectIdArray(ids2, cMemoryOwn: false), isMainObj);
	}

	private bool SwigDirectorMethodisXrefObj__SWIG_1(IntPtr ids1, IntPtr ids2)
	{
		return isXrefObj(new OdDbObjectIdArray(ids1, cMemoryOwn: false), new OdDbObjectIdArray(ids2, cMemoryOwn: false));
	}

	private int SwigDirectorMethodupdateXrefSubentPath()
	{
		return (int)updateXrefSubentPath();
	}

	private int SwigDirectorMethodupdateSubentPath(IntPtr idMap)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return (int)updateSubentPath(ref idMap2);
		}
		finally
		{
			IntPtr handle = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
		}
	}

	private void SwigDirectorMethoddwgOutFields(IntPtr pFiler)
	{
		try
		{
			dwgOutFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethoddwgInFields(IntPtr pFiler)
	{
		try
		{
			dwgInFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethoddxfOutFields(IntPtr pFiler)
	{
		try
		{
			dxfOutFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethoddxfInFields(IntPtr filer)
	{
		return (int)dxfInFields(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(filer, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodupdateDueToMirror__SWIG_0(bool inMirror)
	{
		try
		{
			updateDueToMirror(inMirror);
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

	private void SwigDirectorMethodupdateDueToMirror__SWIG_1()
	{
		try
		{
			updateDueToMirror();
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
}

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbSubentityOverrule : OdRxOverrule
{
	public delegate IntPtr SwigDelegateOdDbSubentityOverrule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbSubentityOverrule_1();

	public delegate void SwigDelegateOdDbSubentityOverrule_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbSubentityOverrule_3(IntPtr pOverruledSubject);

	public delegate int SwigDelegateOdDbSubentityOverrule_4(IntPtr pSubject, IntPtr paths);

	public delegate int SwigDelegateOdDbSubentityOverrule_5(IntPtr pSubject, IntPtr paths);

	public delegate int SwigDelegateOdDbSubentityOverrule_6(IntPtr pSubject, IntPtr paths, IntPtr xform);

	public delegate int SwigDelegateOdDbSubentityOverrule_7(IntPtr pSubject, IntPtr path, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, uint bitflags);

	public delegate int SwigDelegateOdDbSubentityOverrule_8(IntPtr pSubject, IntPtr paths, IntPtr gripAppData, IntPtr offset, uint bitflags);

	public delegate int SwigDelegateOdDbSubentityOverrule_9(IntPtr pSubject, int type, IntPtr gsMark, IntPtr pickPoint, IntPtr viewXform, IntPtr subentPaths, IntPtr pEntAndInsertStack);

	public delegate int SwigDelegateOdDbSubentityOverrule_10(IntPtr pSubject, int type, IntPtr gsMark, IntPtr pickPoint, IntPtr viewXform, IntPtr subentPaths);

	public delegate int SwigDelegateOdDbSubentityOverrule_11(IntPtr pSubject, IntPtr subPath, IntPtr gsMarkers);

	public delegate IntPtr SwigDelegateOdDbSubentityOverrule_12(IntPtr pSubject, IntPtr id);

	public delegate int SwigDelegateOdDbSubentityOverrule_13(IntPtr pSubject, IntPtr xMat);

	public delegate int SwigDelegateOdDbSubentityOverrule_14(IntPtr pSubject, IntPtr path, IntPtr extents);

	public delegate void SwigDelegateOdDbSubentityOverrule_15(IntPtr pSubject, int status, IntPtr subentity);

	public delegate int SwigDelegateOdDbSubentityOverrule_16(IntPtr pSubject, IntPtr path, IntPtr clsId);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbSubentityOverrule_0 swigDelegate0;

	private SwigDelegateOdDbSubentityOverrule_1 swigDelegate1;

	private SwigDelegateOdDbSubentityOverrule_2 swigDelegate2;

	private SwigDelegateOdDbSubentityOverrule_3 swigDelegate3;

	private SwigDelegateOdDbSubentityOverrule_4 swigDelegate4;

	private SwigDelegateOdDbSubentityOverrule_5 swigDelegate5;

	private SwigDelegateOdDbSubentityOverrule_6 swigDelegate6;

	private SwigDelegateOdDbSubentityOverrule_7 swigDelegate7;

	private SwigDelegateOdDbSubentityOverrule_8 swigDelegate8;

	private SwigDelegateOdDbSubentityOverrule_9 swigDelegate9;

	private SwigDelegateOdDbSubentityOverrule_10 swigDelegate10;

	private SwigDelegateOdDbSubentityOverrule_11 swigDelegate11;

	private SwigDelegateOdDbSubentityOverrule_12 swigDelegate12;

	private SwigDelegateOdDbSubentityOverrule_13 swigDelegate13;

	private SwigDelegateOdDbSubentityOverrule_14 swigDelegate14;

	private SwigDelegateOdDbSubentityOverrule_15 swigDelegate15;

	private SwigDelegateOdDbSubentityOverrule_16 swigDelegate16;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdDbFullSubentPathArray)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdDbFullSubentPathArray)
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(OdDbFullSubentPathArray),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes7 = new Type[7]
	{
		typeof(OdDbEntity),
		typeof(OdDbFullSubentPath),
		typeof(OdDbGripDataPtrArray),
		typeof(double),
		typeof(int),
		typeof(OdGeVector3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes8 = new Type[5]
	{
		typeof(OdDbEntity),
		typeof(OdDbFullSubentPathArray),
		typeof(OdDbVoidPtrArray),
		typeof(OdGeVector3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes9 = new Type[7]
	{
		typeof(OdDbEntity),
		typeof(OdDb_SubentType),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdDbFullSubentPathArray),
		typeof(OdDbObjectIdArray)
	};

	private static Type[] swigMethodTypes10 = new Type[6]
	{
		typeof(OdDbEntity),
		typeof(OdDb_SubentType),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdDbFullSubentPathArray)
	};

	private static Type[] swigMethodTypes11 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(OdDbFullSubentPath),
		typeof(OdGsMarkerArray)
	};

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdDbFullSubentPath)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes14 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(OdDbFullSubentPath),
		typeof(OdGeExtents3d)
	};

	private static Type[] swigMethodTypes15 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(OdDb_GripStat),
		typeof(OdDbFullSubentPath)
	};

	private static Type[] swigMethodTypes16 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(OdDbFullSubentPath),
		typeof(IntPtr)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbSubentityOverrule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbSubentityOverrule obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbSubentityOverrule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbSubentityOverrule()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbSubentityOverrule(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbSubentityOverrule cast(OdRxObject pObj)
	{
		OdDbSubentityOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSubentityOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_isASwigExplicitOdDbSubentityOverrule(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_queryXSwigExplicitOdDbSubentityOverrule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbSubentityOverrule createObject()
	{
		OdDbSubentityOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSubentityOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult deleteSubentPaths(OdDbEntity pSubject, OdDbFullSubentPathArray paths)
	{
		int result = (SwigDerivedClassHasMethod("deleteSubentPaths", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_deleteSubentPathsSwigExplicitOdDbSubentityOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPathArray.getCPtr(paths)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_deleteSubentPaths(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPathArray.getCPtr(paths)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult addSubentPaths(OdDbEntity pSubject, OdDbFullSubentPathArray paths)
	{
		int result = (SwigDerivedClassHasMethod("addSubentPaths", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_addSubentPathsSwigExplicitOdDbSubentityOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPathArray.getCPtr(paths)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_addSubentPaths(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPathArray.getCPtr(paths)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult transformSubentPathsBy(OdDbEntity pSubject, OdDbFullSubentPathArray paths, OdGeMatrix3d xform)
	{
		int result = (SwigDerivedClassHasMethod("transformSubentPathsBy", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_transformSubentPathsBySwigExplicitOdDbSubentityOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPathArray.getCPtr(paths), OdGeMatrix3d.getCPtr(xform)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_transformSubentPathsBy(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPathArray.getCPtr(paths), OdGeMatrix3d.getCPtr(xform)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getGripPointsAtSubentPath(OdDbEntity pSubject, OdDbFullSubentPath path, OdDbGripDataPtrArray grips, double curViewUnitSize, int gripSize, OdGeVector3d curViewDir, uint bitflags)
	{
		int result = (SwigDerivedClassHasMethod("getGripPointsAtSubentPath", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getGripPointsAtSubentPathSwigExplicitOdDbSubentityOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPath.getCPtr(path), OdDbGripDataPtrArray.getCPtr(grips).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitflags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getGripPointsAtSubentPath(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPath.getCPtr(path), OdDbGripDataPtrArray.getCPtr(grips).Handle, curViewUnitSize, gripSize, OdGeVector3d.getCPtr(curViewDir), bitflags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult moveGripPointsAtSubentPaths(OdDbEntity pSubject, OdDbFullSubentPathArray paths, OdDbVoidPtrArray gripAppData, OdGeVector3d offset, uint bitflags)
	{
		int result = (SwigDerivedClassHasMethod("moveGripPointsAtSubentPaths", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_moveGripPointsAtSubentPathsSwigExplicitOdDbSubentityOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPathArray.getCPtr(paths), OdDbVoidPtrArray.getCPtr(gripAppData), OdGeVector3d.getCPtr(offset), bitflags) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_moveGripPointsAtSubentPaths(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPathArray.getCPtr(paths), OdDbVoidPtrArray.getCPtr(gripAppData), OdGeVector3d.getCPtr(offset), bitflags));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentPathsAtGsMarker(OdDbEntity pSubject, OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d viewXform, OdDbFullSubentPathArray subentPaths, OdDbObjectIdArray pEntAndInsertStack)
	{
		int result = (SwigDerivedClassHasMethod("getSubentPathsAtGsMarker", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getSubentPathsAtGsMarkerSwigExplicitOdDbSubentityOverrule__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(viewXform), OdDbFullSubentPathArray.getCPtr(subentPaths), OdDbObjectIdArray.getCPtr(pEntAndInsertStack)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getSubentPathsAtGsMarker__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(viewXform), OdDbFullSubentPathArray.getCPtr(subentPaths), OdDbObjectIdArray.getCPtr(pEntAndInsertStack)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentPathsAtGsMarker(OdDbEntity pSubject, OdDb_SubentType type, IntPtr gsMark, OdGePoint3d pickPoint, OdGeMatrix3d viewXform, OdDbFullSubentPathArray subentPaths)
	{
		int result = (SwigDerivedClassHasMethod("getSubentPathsAtGsMarker", swigMethodTypes10) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getSubentPathsAtGsMarkerSwigExplicitOdDbSubentityOverrule__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(viewXform), OdDbFullSubentPathArray.getCPtr(subentPaths)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getSubentPathsAtGsMarker__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)type, gsMark, OdGePoint3d.getCPtr(pickPoint), OdGeMatrix3d.getCPtr(viewXform), OdDbFullSubentPathArray.getCPtr(subentPaths)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getGsMarkersAtSubentPath(OdDbEntity pSubject, OdDbFullSubentPath subPath, OdGsMarkerArray gsMarkers)
	{
		int result = (SwigDerivedClassHasMethod("getGsMarkersAtSubentPath", swigMethodTypes11) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getGsMarkersAtSubentPathSwigExplicitOdDbSubentityOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPath.getCPtr(subPath), OdGsMarkerArray.getCPtr(gsMarkers)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getGsMarkersAtSubentPath(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPath.getCPtr(subPath), OdGsMarkerArray.getCPtr(gsMarkers)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbEntity subentPtr(OdDbEntity pSubject, OdDbFullSubentPath id)
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(SwigDerivedClassHasMethod("subentPtr", swigMethodTypes12) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_subentPtrSwigExplicitOdDbSubentityOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPath.getCPtr(id)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_subentPtr(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPath.getCPtr(id)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getCompoundObjectTransform(OdDbEntity pSubject, OdGeMatrix3d xMat)
	{
		int result = (SwigDerivedClassHasMethod("getCompoundObjectTransform", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getCompoundObjectTransformSwigExplicitOdDbSubentityOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdGeMatrix3d.getCPtr(xMat)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getCompoundObjectTransform(swigCPtr, OdDbEntity.getCPtr(pSubject), OdGeMatrix3d.getCPtr(xMat)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getSubentPathGeomExtents(OdDbEntity pSubject, OdDbFullSubentPath path, OdGeExtents3d extents)
	{
		int result = (SwigDerivedClassHasMethod("getSubentPathGeomExtents", swigMethodTypes14) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getSubentPathGeomExtentsSwigExplicitOdDbSubentityOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPath.getCPtr(path), OdGeExtents3d.getCPtr(extents)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getSubentPathGeomExtents(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPath.getCPtr(path), OdGeExtents3d.getCPtr(extents)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void subentGripStatus(OdDbEntity pSubject, OdDb_GripStat status, OdDbFullSubentPath subentity)
	{
		if (SwigDerivedClassHasMethod("subentGripStatus", swigMethodTypes15))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_subentGripStatusSwigExplicitOdDbSubentityOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)status, OdDbFullSubentPath.getCPtr(subentity));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_subentGripStatus(swigCPtr, OdDbEntity.getCPtr(pSubject), (int)status, OdDbFullSubentPath.getCPtr(subentity));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult getSubentClassId(OdDbEntity pSubject, OdDbFullSubentPath path, IntPtr clsId)
	{
		int result = (SwigDerivedClassHasMethod("getSubentClassId", swigMethodTypes16) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getSubentClassIdSwigExplicitOdDbSubentityOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPath.getCPtr(path), clsId) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getSubentClassId(swigCPtr, OdDbEntity.getCPtr(pSubject), OdDbFullSubentPath.getCPtr(path), clsId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("deleteSubentPaths", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddeleteSubentPaths;
		}
		if (SwigDerivedClassHasMethod("addSubentPaths", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodaddSubentPaths;
		}
		if (SwigDerivedClassHasMethod("transformSubentPathsBy", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodtransformSubentPathsBy;
		}
		if (SwigDerivedClassHasMethod("getGripPointsAtSubentPath", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetGripPointsAtSubentPath;
		}
		if (SwigDerivedClassHasMethod("moveGripPointsAtSubentPaths", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodmoveGripPointsAtSubentPaths;
		}
		if (SwigDerivedClassHasMethod("getSubentPathsAtGsMarker", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetSubentPathsAtGsMarker__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getSubentPathsAtGsMarker", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetSubentPathsAtGsMarker__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getGsMarkersAtSubentPath", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetGsMarkersAtSubentPath;
		}
		if (SwigDerivedClassHasMethod("subentPtr", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsubentPtr;
		}
		if (SwigDerivedClassHasMethod("getCompoundObjectTransform", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetCompoundObjectTransform;
		}
		if (SwigDerivedClassHasMethod("getSubentPathGeomExtents", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetSubentPathGeomExtents;
		}
		if (SwigDerivedClassHasMethod("subentGripStatus", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsubentGripStatus;
		}
		if (SwigDerivedClassHasMethod("getSubentClassId", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetSubentClassId;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentityOverrule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbSubentityOverrule));
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

	private int SwigDirectorMethoddeleteSubentPaths(IntPtr pSubject, IntPtr paths)
	{
		return (int)deleteSubentPaths(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdDbFullSubentPathArray(paths, cMemoryOwn: false));
	}

	private int SwigDirectorMethodaddSubentPaths(IntPtr pSubject, IntPtr paths)
	{
		return (int)addSubentPaths(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdDbFullSubentPathArray(paths, cMemoryOwn: false));
	}

	private int SwigDirectorMethodtransformSubentPathsBy(IntPtr pSubject, IntPtr paths, IntPtr xform)
	{
		return (int)transformSubentPathsBy(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdDbFullSubentPathArray(paths, cMemoryOwn: false), new OdGeMatrix3d(xform, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetGripPointsAtSubentPath(IntPtr pSubject, IntPtr path, IntPtr grips, double curViewUnitSize, int gripSize, IntPtr curViewDir, uint bitflags)
	{
		return (int)getGripPointsAtSubentPath(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdDbFullSubentPath(path, cMemoryOwn: false), new OdDbGripDataPtrArray(grips, cMemoryOwn: true), curViewUnitSize, gripSize, new OdGeVector3d(curViewDir, cMemoryOwn: false), bitflags);
	}

	private int SwigDirectorMethodmoveGripPointsAtSubentPaths(IntPtr pSubject, IntPtr paths, IntPtr gripAppData, IntPtr offset, uint bitflags)
	{
		return (int)moveGripPointsAtSubentPaths(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdDbFullSubentPathArray(paths, cMemoryOwn: false), new OdDbVoidPtrArray(gripAppData, cMemoryOwn: false), new OdGeVector3d(offset, cMemoryOwn: false), bitflags);
	}

	private int SwigDirectorMethodgetSubentPathsAtGsMarker__SWIG_0(IntPtr pSubject, int type, IntPtr gsMark, IntPtr pickPoint, IntPtr viewXform, IntPtr subentPaths, IntPtr pEntAndInsertStack)
	{
		return (int)getSubentPathsAtGsMarker(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), (OdDb_SubentType)type, gsMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGeMatrix3d(viewXform, cMemoryOwn: false), new OdDbFullSubentPathArray(subentPaths, cMemoryOwn: false), (pEntAndInsertStack == IntPtr.Zero) ? null : new OdDbObjectIdArray(pEntAndInsertStack, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetSubentPathsAtGsMarker__SWIG_1(IntPtr pSubject, int type, IntPtr gsMark, IntPtr pickPoint, IntPtr viewXform, IntPtr subentPaths)
	{
		return (int)getSubentPathsAtGsMarker(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), (OdDb_SubentType)type, gsMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGeMatrix3d(viewXform, cMemoryOwn: false), new OdDbFullSubentPathArray(subentPaths, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetGsMarkersAtSubentPath(IntPtr pSubject, IntPtr subPath, IntPtr gsMarkers)
	{
		return (int)getGsMarkersAtSubentPath(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdDbFullSubentPath(subPath, cMemoryOwn: false), new OdGsMarkerArray(gsMarkers, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodsubentPtr(IntPtr pSubject, IntPtr id)
	{
		return OdDbEntity.getCPtr(subentPtr(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdDbFullSubentPath(id, cMemoryOwn: false))).Handle;
	}

	private int SwigDirectorMethodgetCompoundObjectTransform(IntPtr pSubject, IntPtr xMat)
	{
		return (int)getCompoundObjectTransform(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdGeMatrix3d(xMat, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetSubentPathGeomExtents(IntPtr pSubject, IntPtr path, IntPtr extents)
	{
		return (int)getSubentPathGeomExtents(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdDbFullSubentPath(path, cMemoryOwn: false), new OdGeExtents3d(extents, cMemoryOwn: false));
	}

	private void SwigDirectorMethodsubentGripStatus(IntPtr pSubject, int status, IntPtr subentity)
	{
		try
		{
			subentGripStatus(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), (OdDb_GripStat)status, new OdDbFullSubentPath(subentity, cMemoryOwn: false));
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

	private int SwigDirectorMethodgetSubentClassId(IntPtr pSubject, IntPtr path, IntPtr clsId)
	{
		return (int)getSubentClassId(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdDbFullSubentPath(path, cMemoryOwn: false), clsId);
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbSelectionSet : OdSelectionSet
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbSelectionSet(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbSelectionSet obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbSelectionSet(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbSelectionSet cast(OdRxObject pObj)
	{
		OdDbSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbSelectionSet createObject()
	{
		OdDbSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_createObject__SWIG_0(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbSelectionSet createObject(OdDbDatabase pDb)
	{
		OdDbSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_createObject__SWIG_1(OdDbDatabase.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase database()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbObjectIdArray objectIdArray()
	{
		OdDbObjectIdArray result = new OdDbObjectIdArray(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_objectIdArray(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbSelectionSet select(OdDbDatabase pDb, OdRxObject pFilter)
	{
		OdDbSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_select__SWIG_0(OdDbDatabase.getCPtr(pDb), OdRxObject.getCPtr(pFilter)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbSelectionSet select(OdDbDatabase pDb)
	{
		OdDbSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_select__SWIG_1(OdDbDatabase.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbSelectionSet select(OdDbObjectId vpId, OdGePoint3d[] nPoints, OdDbVisualSelection_Mode mode, uint sm, OdRxObject pFilter)
	{
		IntPtr intPtr = ODA.Kernel.TD_RootIntegrated.Helpers.MarshalPoint3dArray(nPoints);
		try
		{
			OdDbSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_select__SWIG_2(OdDbObjectId.getCPtr(vpId), intPtr, (int)mode, sm, OdRxObject.getCPtr(pFilter)), bOwn: true, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public static OdDbSelectionSet select(OdDbObjectId vpId, OdGePoint3d[] nPoints, OdDbVisualSelection_Mode mode, uint sm)
	{
		IntPtr intPtr = ODA.Kernel.TD_RootIntegrated.Helpers.MarshalPoint3dArray(nPoints);
		try
		{
			OdDbSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_select__SWIG_3(OdDbObjectId.getCPtr(vpId), intPtr, (int)mode, sm), bOwn: true, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public static OdDbSelectionSet select(OdDbObjectId vpId, OdGePoint3d[] nPoints, OdDbVisualSelection_Mode mode)
	{
		IntPtr intPtr = ODA.Kernel.TD_RootIntegrated.Helpers.MarshalPoint3dArray(nPoints);
		try
		{
			OdDbSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_select__SWIG_4(OdDbObjectId.getCPtr(vpId), intPtr, (int)mode), bOwn: true, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public static OdDbSelectionSet select(OdDbObjectId vpId, OdGePoint3d[] nPoints)
	{
		IntPtr intPtr = ODA.Kernel.TD_RootIntegrated.Helpers.MarshalPoint3dArray(nPoints);
		try
		{
			OdDbSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_select__SWIG_5(OdDbObjectId.getCPtr(vpId), intPtr), bOwn: true, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void append(OdDbObjectId entityId, OdDbSelectionMethod pMethod)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_append__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(entityId), OdDbSelectionMethod.getCPtr(pMethod));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void append(OdDbObjectId entityId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_append__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(entityId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void append(OdDbObjectIdArray entityIds, OdDbSelectionMethod pMethod)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_append__SWIG_2(swigCPtr, OdDbObjectIdArray.getCPtr(entityIds), OdDbSelectionMethod.getCPtr(pMethod));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void append(OdDbObjectIdArray entityIds)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_append__SWIG_3(swigCPtr, OdDbObjectIdArray.getCPtr(entityIds));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void append(OdDbFullSubentPath subent, OdDbSelectionMethod pMethod)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_append__SWIG_4(swigCPtr, OdDbFullSubentPath.getCPtr(subent), OdDbSelectionMethod.getCPtr(pMethod));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void append(OdDbFullSubentPath subent)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_append__SWIG_5(swigCPtr, OdDbFullSubentPath.getCPtr(subent));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void append(OdSelectionSet pSSet)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_append__SWIG_6(swigCPtr, OdSelectionSet.getCPtr(pSSet));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void remove(OdDbObjectId entityId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_remove__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(entityId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void remove(OdDbObjectIdArray entityIds)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_remove__SWIG_1(swigCPtr, OdDbObjectIdArray.getCPtr(entityIds));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void remove(OdDbFullSubentPath subent)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_remove__SWIG_2(swigCPtr, OdDbFullSubentPath.getCPtr(subent));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void remove(OdSelectionSet pSSet)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_remove__SWIG_3(swigCPtr, OdSelectionSet.getCPtr(pSSet));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isMember(OdDbObjectId entityId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_isMember__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(entityId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isMember(OdDbFullSubentPath subent)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_isMember__SWIG_1(swigCPtr, OdDbFullSubentPath.getCPtr(subent));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbSelectionMethod method(OdDbObjectId entityId)
	{
		OdDbSelectionMethod rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionMethod>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_method__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(entityId)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual uint subentCount(OdDbStub rootEntityId)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_subentCount__SWIG_0(swigCPtr, OdDbStub.getCPtr(rootEntityId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint subentCount()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_subentCount__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getSubentity(OdDbObjectId entityId, uint i, OdDbFullSubentPath path)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_getSubentity(swigCPtr, OdDbObjectId.getCPtr(entityId), i, OdDbFullSubentPath.getCPtr(path));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbSelectionMethod method(OdDbFullSubentPath subent)
	{
		OdDbSelectionMethod rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionMethod>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_method__SWIG_1(swigCPtr, OdDbFullSubentPath.getCPtr(subent)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSet_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbCoordSystemRef : OdRxObjectImpl_OdDbGeomRef
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbCoordSystemRef(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbCoordSystemRef obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbCoordSystemRef(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbCoordSystemRef cast(OdRxObject pObj)
	{
		OdDbCoordSystemRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCoordSystemRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbCoordSystemRef createObject()
	{
		OdDbCoordSystemRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCoordSystemRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbCoordSystemRef Assign(OdDbCoordSystemRef arg0)
	{
		OdDbCoordSystemRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCoordSystemRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_Assign(swigCPtr, getCPtr(arg0)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void copyFrom(OdRxObject arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_copyFrom(swigCPtr, OdRxObject.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void reset()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_reset(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isValid()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_isValid(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isEmpty()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_isEmpty(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d coordSystem()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_coordSystem(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbCompoundObjectId entityId()
	{
		OdDbCompoundObjectId rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCompoundObjectId>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_entityId(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdArray_OdDbSubentRef__p_OdObjectsAllocator subentRefs()
	{
		OdArray_OdDbSubentRef__p_OdObjectsAllocator result = new OdArray_OdDbSubentRef__p_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_subentRefs(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set(OdGeMatrix3d matrix)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_set__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(matrix).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdDbCompoundObjectId entId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_set__SWIG_1(swigCPtr, OdDbCompoundObjectId.getCPtr(entId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdArray_OdDbSubentRef__p_OdObjectsAllocator subentReferences)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_set__SWIG_2(swigCPtr, OdArray_OdDbSubentRef__p_OdObjectsAllocator.getCPtr(subentReferences));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbEntity createEntity()
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_createEntity(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdResult evaluateAndCacheGeometry()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_evaluateAndCacheGeometry(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCoordSystemRef_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

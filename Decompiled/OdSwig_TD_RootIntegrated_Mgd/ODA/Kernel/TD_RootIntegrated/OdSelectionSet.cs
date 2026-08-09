using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSelectionSet : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSelectionSet(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSelectionSet obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdSelectionSet(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdSelectionSet cast(OdRxObject pObj)
	{
		OdSelectionSet rXObject = Helpers.GetRXObject<OdSelectionSet>(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdSelectionSet createObject()
	{
		OdSelectionSet rXObject = Helpers.GetRXObject<OdSelectionSet>(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject baseDatabase()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_baseDatabase(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSetIterator newIterator()
	{
		OdSelectionSetIterator rXObject = Helpers.GetRXObject<OdSelectionSetIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_newIterator(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint numEntities()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_numEntities(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint subentCount(OdDbStub arg0)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_subentCount__SWIG_0(swigCPtr, OdDbStub.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint subentCount()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_subentCount__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void append(OdDbStub entityId, OdDbSelectionMethod pMethod)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_append__SWIG_0(swigCPtr, OdDbStub.getCPtr(entityId), OdDbSelectionMethod.getCPtr(pMethod));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void append(OdDbStub entityId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_append__SWIG_1(swigCPtr, OdDbStub.getCPtr(entityId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void append(OdDbBaseFullSubentPath subent, OdDbSelectionMethod pMethod)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_append__SWIG_2(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subent), OdDbSelectionMethod.getCPtr(pMethod));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void append(OdDbBaseFullSubentPath subent)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_append__SWIG_3(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void append(OdSelectionSet pSSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_append__SWIG_4(swigCPtr, getCPtr(pSSet));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void remove(OdDbStub entityId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_remove__SWIG_0(swigCPtr, OdDbStub.getCPtr(entityId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void remove(OdDbBaseFullSubentPath subent)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_remove__SWIG_1(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void remove(OdSelectionSet pSSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_remove__SWIG_2(swigCPtr, getCPtr(pSSet));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isMember(OdDbStub entityId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_isMember__SWIG_0(swigCPtr, OdDbStub.getCPtr(entityId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isMember(OdDbBaseFullSubentPath subent)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_isMember__SWIG_1(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbSelectionMethod method(OdDbStub entityId)
	{
		OdDbSelectionMethod rXObject = Helpers.GetRXObject<OdDbSelectionMethod>(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_method(swigCPtr, OdDbStub.getCPtr(entityId)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSet_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

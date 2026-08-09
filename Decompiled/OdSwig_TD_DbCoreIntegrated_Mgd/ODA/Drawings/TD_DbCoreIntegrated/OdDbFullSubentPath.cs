using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbFullSubentPath : OdDbBaseFullSubentPath
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbFullSubentPath(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFullSubentPath_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbFullSubentPath obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbFullSubentPath(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbFullSubentPath()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbFullSubentPath__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbFullSubentPath(OdDb_SubentType type, IntPtr index)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbFullSubentPath__SWIG_1((int)type, index), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbFullSubentPath(OdDbObjectId entId, OdDbSubentId subId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbFullSubentPath__SWIG_2(OdDbObjectId.getCPtr(entId), OdDbSubentId.getCPtr(subId)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbFullSubentPath(OdDbObjectId entId, OdDb_SubentType type, IntPtr index)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbFullSubentPath__SWIG_3(OdDbObjectId.getCPtr(entId), (int)type, index), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbFullSubentPath(OdDbObjectIdArray objectIds, OdDbSubentId subId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbFullSubentPath__SWIG_4(OdDbObjectIdArray.getCPtr(objectIds), OdDbSubentId.getCPtr(subId)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbFullSubentPath(OdDbStubPtrArray objectIds, OdDbSubentId subId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbFullSubentPath__SWIG_5(OdDbStubPtrArray.getCPtr(objectIds), OdDbSubentId.getCPtr(subId)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbFullSubentPath(OdDbBaseFullSubentPath basePath)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbFullSubentPath__SWIG_6(OdDbBaseFullSubentPath.getCPtr(basePath)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void objectIds(OdDbObjectIdArray objectIdsArg)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFullSubentPath_objectIds__SWIG_0(swigCPtr, OdDbObjectIdArray.getCPtr(objectIdsArg));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbFullSubentPath Assign(OdDbFullSubentPath fullSubentPath)
	{
		OdDbFullSubentPath result = new OdDbFullSubentPath(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFullSubentPath_Assign(swigCPtr, getCPtr(fullSubentPath)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdDbFullSubentPath fullSubentPath)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFullSubentPath_IsEqual(swigCPtr, getCPtr(fullSubentPath));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdDbObjectIdArray objectIds()
	{
		OdDbObjectIdArray result = new OdDbObjectIdArray(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFullSubentPath_objectIds__SWIG_1(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdDbSubentId subentId()
	{
		OdDbSubentId result = new OdDbSubentId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFullSubentPath_subentId__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbSoftOwnershipId : OdDbObjectId
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbSoftOwnershipId(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSoftOwnershipId_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbSoftOwnershipId obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbSoftOwnershipId(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbSoftOwnershipId()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbSoftOwnershipId__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbSoftOwnershipId(OdDbObjectId objectId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbSoftOwnershipId__SWIG_1(OdDbObjectId.getCPtr(objectId)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbSoftOwnershipId(OdDbStub objectId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbSoftOwnershipId__SWIG_2(OdDbStub.getCPtr(objectId)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new OdDbSoftOwnershipId Assign(OdDbObjectId objectId)
	{
		OdDbSoftOwnershipId result = new OdDbSoftOwnershipId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSoftOwnershipId_Assign(swigCPtr, OdDbObjectId.getCPtr(objectId)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdDbSoftOwnershipId AssignOdDbStub(OdDbStub objectId)
	{
		OdDbSoftOwnershipId result = new OdDbSoftOwnershipId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSoftOwnershipId_AssignOdDbStub(swigCPtr, OdDbStub.getCPtr(objectId)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool IsNotEqual(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSoftOwnershipId_IsNotEqual__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdDbStub objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSoftOwnershipId_IsNotEqual__SWIG_1(swigCPtr, OdDbStub.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool IsEqual(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSoftOwnershipId_IsEqual__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdDbStub objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSoftOwnershipId_IsEqual__SWIG_1(swigCPtr, OdDbStub.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

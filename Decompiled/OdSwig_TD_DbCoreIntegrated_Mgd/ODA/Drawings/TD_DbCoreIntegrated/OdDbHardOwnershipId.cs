using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbHardOwnershipId : OdDbObjectId
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbHardOwnershipId(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHardOwnershipId_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbHardOwnershipId obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbHardOwnershipId(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbHardOwnershipId()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbHardOwnershipId__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbHardOwnershipId(OdDbObjectId objectId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbHardOwnershipId__SWIG_1(OdDbObjectId.getCPtr(objectId)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbHardOwnershipId(OdDbStub objectId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbHardOwnershipId__SWIG_2(OdDbStub.getCPtr(objectId)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new OdDbHardOwnershipId Assign(OdDbObjectId objectId)
	{
		OdDbHardOwnershipId result = new OdDbHardOwnershipId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHardOwnershipId_Assign(swigCPtr, OdDbObjectId.getCPtr(objectId)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdDbHardOwnershipId AssignOdDbStub(OdDbStub objectId)
	{
		OdDbHardOwnershipId result = new OdDbHardOwnershipId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHardOwnershipId_AssignOdDbStub(swigCPtr, OdDbStub.getCPtr(objectId)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool IsNotEqual(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHardOwnershipId_IsNotEqual__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdDbStub objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHardOwnershipId_IsNotEqual__SWIG_1(swigCPtr, OdDbStub.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool IsEqual(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHardOwnershipId_IsEqual__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdDbStub objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHardOwnershipId_IsEqual__SWIG_1(swigCPtr, OdDbStub.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

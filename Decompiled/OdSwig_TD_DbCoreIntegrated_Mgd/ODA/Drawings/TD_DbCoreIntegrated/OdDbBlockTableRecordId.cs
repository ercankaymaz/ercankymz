using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbBlockTableRecordId : OdDbObjectId
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBlockTableRecordId(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableRecordId_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBlockTableRecordId obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbBlockTableRecordId(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbBlockTableRecordId()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbBlockTableRecordId__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBlockTableRecordId(OdDbObjectId objectId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbBlockTableRecordId__SWIG_1(OdDbObjectId.getCPtr(objectId)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBlockTableRecordId(OdDbStub objectId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbBlockTableRecordId__SWIG_2(OdDbStub.getCPtr(objectId)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBlockTableRecordId Assign(OdDbBlockTableRecordId objectId)
	{
		OdDbBlockTableRecordId result = new OdDbBlockTableRecordId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableRecordId_Assign__SWIG_0(swigCPtr, getCPtr(objectId)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdDbBlockTableRecordId Assign(OdDbObjectId objectId)
	{
		OdDbBlockTableRecordId result = new OdDbBlockTableRecordId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableRecordId_Assign__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(objectId)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdDbBlockTableRecordId AssignOdDbStub(OdDbStub objectId)
	{
		OdDbBlockTableRecordId result = new OdDbBlockTableRecordId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableRecordId_AssignOdDbStub(swigCPtr, OdDbStub.getCPtr(objectId)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool IsNotEqual(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableRecordId_IsNotEqual__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdDbStub objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableRecordId_IsNotEqual__SWIG_1(swigCPtr, OdDbStub.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool IsEqual(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableRecordId_IsEqual__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdDbStub objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockTableRecordId_IsEqual__SWIG_1(swigCPtr, OdDbStub.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

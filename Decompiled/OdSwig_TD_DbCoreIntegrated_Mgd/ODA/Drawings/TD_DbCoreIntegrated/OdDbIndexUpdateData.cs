using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbIndexUpdateData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbIndexUpdateData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbIndexUpdateData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbIndexUpdateData()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbIndexUpdateData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbObjectId objectBeingIndexedId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexUpdateData_objectBeingIndexedId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void addId(OdDbObjectId objectId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexUpdateData_addId(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool setIdFlags(OdDbObjectId objectId, byte flags)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexUpdateData_setIdFlags(swigCPtr, OdDbObjectId.getCPtr(objectId), flags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setIdData(OdDbObjectId objectId, uint data)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexUpdateData_setIdData(swigCPtr, OdDbObjectId.getCPtr(objectId), data);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getIdData(OdDbObjectId objectId, out uint data)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexUpdateData_getIdData(swigCPtr, OdDbObjectId.getCPtr(objectId), out data);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getIdFlags(OdDbObjectId objectId, out byte flags)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexUpdateData_getIdFlags(swigCPtr, OdDbObjectId.getCPtr(objectId), out flags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFlagsAndData(OdDbObjectId objectId, out byte flags, out uint data)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexUpdateData_getFlagsAndData(swigCPtr, OdDbObjectId.getCPtr(objectId), out flags, out data);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

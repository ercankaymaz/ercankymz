using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbId_SoftPointer : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbId_SoftPointer(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbId_SoftPointer obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbId_SoftPointer()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbId_SoftPointer(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdDbObjectId read(OdDbDwgFiler pFiler)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbId_SoftPointer_read(OdDbDwgFiler.getCPtr(pFiler)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void write(OdDbDwgFiler pFiler, OdDbObjectId id)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbId_SoftPointer_write(OdDbDwgFiler.getCPtr(pFiler), OdDbObjectId.getCPtr(id));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbId_SoftPointer()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbId_SoftPointer(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

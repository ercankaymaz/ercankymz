using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbObjectIdPair : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdDbObjectId first
	{
		get
		{
			IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIdPair_first_get(swigCPtr);
			OdDbObjectId result = ((intPtr == IntPtr.Zero) ? null : new OdDbObjectId(intPtr, cMemoryOwn: false));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public OdDbObjectId second
	{
		get
		{
			IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIdPair_second_get(swigCPtr);
			OdDbObjectId result = ((intPtr == IntPtr.Zero) ? null : new OdDbObjectId(intPtr, cMemoryOwn: false));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbObjectIdPair(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbObjectIdPair obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbObjectIdPair()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbObjectIdPair(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbObjectIdPair()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbObjectIdPair__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectIdPair(OdDbObjectId first, OdDbObjectId second)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbObjectIdPair__SWIG_1(OdDbObjectId.getCPtr(first), OdDbObjectId.getCPtr(second)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectIdPair(OdDbObjectIdPair other)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbObjectIdPair__SWIG_2(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

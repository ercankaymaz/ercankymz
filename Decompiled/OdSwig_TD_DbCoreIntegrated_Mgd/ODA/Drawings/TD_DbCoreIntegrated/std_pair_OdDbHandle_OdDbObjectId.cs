using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class std_pair_OdDbHandle_OdDbObjectId : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdDbHandle first
	{
		get
		{
			IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.std_pair_OdDbHandle_OdDbObjectId_first_get(swigCPtr);
			OdDbHandle result = ((intPtr == IntPtr.Zero) ? null : new OdDbHandle(intPtr, cMemoryOwn: false));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.std_pair_OdDbHandle_OdDbObjectId_first_set(swigCPtr, OdDbHandle.getCPtr(value));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdDbObjectId second
	{
		get
		{
			IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.std_pair_OdDbHandle_OdDbObjectId_second_get(swigCPtr);
			OdDbObjectId result = ((intPtr == IntPtr.Zero) ? null : new OdDbObjectId(intPtr, cMemoryOwn: false));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public std_pair_OdDbHandle_OdDbObjectId(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(std_pair_OdDbHandle_OdDbObjectId obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~std_pair_OdDbHandle_OdDbObjectId()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_std_pair_OdDbHandle_OdDbObjectId(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public std_pair_OdDbHandle_OdDbObjectId()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_std_pair_OdDbHandle_OdDbObjectId__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public std_pair_OdDbHandle_OdDbObjectId(OdDbHandle first, OdDbObjectId second)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_std_pair_OdDbHandle_OdDbObjectId__SWIG_1(OdDbHandle.getCPtr(first), OdDbObjectId.getCPtr(second)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public std_pair_OdDbHandle_OdDbObjectId(std_pair_OdDbHandle_OdDbObjectId other)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_std_pair_OdDbHandle_OdDbObjectId__SWIG_2(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

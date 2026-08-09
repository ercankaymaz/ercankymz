using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class _OdShapeInfo : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public int position
	{
		get
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE._OdShapeInfo_position_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE._OdShapeInfo_position_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public _OdShapeInfo(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(_OdShapeInfo obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~_OdShapeInfo()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete__OdShapeInfo(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public _OdShapeInfo()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new__OdShapeInfo(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

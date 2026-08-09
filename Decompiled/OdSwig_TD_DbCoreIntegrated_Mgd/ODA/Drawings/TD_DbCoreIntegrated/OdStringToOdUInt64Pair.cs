using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdStringToOdUInt64Pair : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public string first
	{
		get
		{
			string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64Pair_first_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64Pair_first_set(swigCPtr, value);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public ulong second
	{
		get
		{
			ulong result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64Pair_second_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64Pair_second_set(swigCPtr, value);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdStringToOdUInt64Pair(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdStringToOdUInt64Pair obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdStringToOdUInt64Pair()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdStringToOdUInt64Pair(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdStringToOdUInt64Pair()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdStringToOdUInt64Pair__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdStringToOdUInt64Pair(string first, ulong second)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdStringToOdUInt64Pair__SWIG_1(first, second), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdStringToOdUInt64Pair(OdStringToOdUInt64Pair other)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdStringToOdUInt64Pair__SWIG_2(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiLineweightOverrideHelper : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiLineweightOverrideHelper(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiLineweightOverrideHelper obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiLineweightOverrideHelper()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiLineweightOverrideHelper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	private static IntPtr SwigConstructOdGiLineweightOverrideHelper(ref OdGiSubEntityTraits pTraits, OdGiLineweightOverride pOverride)
	{
		IntPtr jarg = ((pTraits == null) ? IntPtr.Zero : OdGiSubEntityTraits.getCPtr(pTraits).Handle);
		IntPtr intPtr = jarg;
		try
		{
			return TD_RootIntegrated_GlobalsPINVOKE.new_OdGiLineweightOverrideHelper(ref jarg, OdGiLineweightOverride.getCPtr(pOverride));
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pTraits = null;
			}
			if (jarg != intPtr)
			{
				pTraits = Helpers.GetRXObject<OdGiSubEntityTraits>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdGiLineweightOverrideHelper(ref OdGiSubEntityTraits pTraits, OdGiLineweightOverride pOverride)
		: this(SwigConstructOdGiLineweightOverrideHelper(ref pTraits, pOverride), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLineweightOverride(ref OdGiSubEntityTraits pTraits, OdGiLineweightOverride pOverride)
	{
		IntPtr jarg = ((pTraits == null) ? IntPtr.Zero : OdGiSubEntityTraits.getCPtr(pTraits).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverrideHelper_setLineweightOverride(swigCPtr, ref jarg, OdGiLineweightOverride.getCPtr(pOverride));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pTraits = null;
			}
			if (jarg != intPtr)
			{
				pTraits = Helpers.GetRXObject<OdGiSubEntityTraits>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdGiLineweightOverrideHelper createInstance()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverrideHelper_createInstance(swigCPtr);
		OdGiLineweightOverrideHelper result = ((intPtr == IntPtr.Zero) ? null : new OdGiLineweightOverrideHelper(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDrawFlagsHelper : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDrawFlagsHelper(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDrawFlagsHelper obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiDrawFlagsHelper()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDrawFlagsHelper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	private static IntPtr SwigConstructOdGiDrawFlagsHelper(ref OdGiSubEntityTraits pTraits, uint addFlags, uint delFlags)
	{
		IntPtr jarg = ((pTraits == null) ? IntPtr.Zero : OdGiSubEntityTraits.getCPtr(pTraits).Handle);
		IntPtr intPtr = jarg;
		try
		{
			return TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDrawFlagsHelper(ref jarg, addFlags, delFlags);
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

	public OdGiDrawFlagsHelper(ref OdGiSubEntityTraits pTraits, uint addFlags, uint delFlags)
		: this(SwigConstructOdGiDrawFlagsHelper(ref pTraits, addFlags, delFlags), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

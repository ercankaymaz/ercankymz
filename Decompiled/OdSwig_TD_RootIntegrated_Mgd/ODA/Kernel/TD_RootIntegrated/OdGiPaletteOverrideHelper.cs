using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPaletteOverrideHelper : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPaletteOverrideHelper(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPaletteOverrideHelper obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiPaletteOverrideHelper()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPaletteOverrideHelper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	private static IntPtr SwigConstructOdGiPaletteOverrideHelper(ref OdGiSubEntityTraits pTraits, OdGiPalette pOverride)
	{
		IntPtr jarg = ((pTraits == null) ? IntPtr.Zero : OdGiSubEntityTraits.getCPtr(pTraits).Handle);
		IntPtr intPtr = jarg;
		try
		{
			return TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPaletteOverrideHelper(ref jarg, OdGiPalette.getCPtr(pOverride));
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

	public OdGiPaletteOverrideHelper(ref OdGiSubEntityTraits pTraits, OdGiPalette pOverride)
		: this(SwigConstructOdGiPaletteOverrideHelper(ref pTraits, pOverride), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPaletteOverride(ref OdGiSubEntityTraits pTraits, OdGiPalette pOverride)
	{
		IntPtr jarg = ((pTraits == null) ? IntPtr.Zero : OdGiSubEntityTraits.getCPtr(pTraits).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPaletteOverrideHelper_setPaletteOverride(swigCPtr, ref jarg, OdGiPalette.getCPtr(pOverride));
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

	public OdGiPaletteOverrideHelper createInstance()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPaletteOverrideHelper_createInstance(swigCPtr);
		OdGiPaletteOverrideHelper result = ((intPtr == IntPtr.Zero) ? null : new OdGiPaletteOverrideHelper(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

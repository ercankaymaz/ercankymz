using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdLyLayerFilterManager : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdLyLayerFilterManager(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilterManager_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdLyLayerFilterManager obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdLyLayerFilterManager(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual OdResult getFilters(ref OdLyLayerFilter pRoot, ref OdLyLayerFilter pCurrent)
	{
		IntPtr jarg = ((pRoot == null) ? IntPtr.Zero : OdLyLayerFilter.getCPtr(pRoot).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((pCurrent == null) ? IntPtr.Zero : OdLyLayerFilter.getCPtr(pCurrent).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilterManager_getFilters(swigCPtr, ref jarg, ref jarg2);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pRoot = null;
			}
			else if (jarg != intPtr)
			{
				pRoot = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdLyLayerFilter>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				pCurrent = null;
			}
			else if (jarg2 != intPtr2)
			{
				pCurrent = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdLyLayerFilter>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void setFilters(OdLyLayerFilter pRoot, OdLyLayerFilter pCurrent)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilterManager_setFilters(swigCPtr, OdLyLayerFilter.getCPtr(pRoot), OdLyLayerFilter.getCPtr(pCurrent));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilterManager_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

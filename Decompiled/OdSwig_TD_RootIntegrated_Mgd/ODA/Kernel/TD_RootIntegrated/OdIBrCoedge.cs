using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdIBrCoedge : OdIBrEntity
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIBrCoedge(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdIBrCoedge_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIBrCoedge obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdIBrCoedge(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual OdIBrEdge getEdge()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdIBrCoedge_getEdge(swigCPtr);
		OdIBrEdge result = ((intPtr == IntPtr.Zero) ? null : new OdIBrEdge(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdIBrLoop getLoop()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdIBrCoedge_getLoop(swigCPtr);
		OdIBrLoop result = ((intPtr == IntPtr.Zero) ? null : new OdIBrLoop(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void nextOnEdge(OdIBrCoedge pFirstChild, ref OdIBrCoedge pCurChild)
	{
		IntPtr jarg = getCPtr(pCurChild).Handle;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdIBrCoedge_nextOnEdge(swigCPtr, getCPtr(pFirstChild), ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (getCPtr(pCurChild).Handle != jarg)
			{
				pCurChild = Helpers.odCreateObjectInternal<OdIBrCoedge>(typeof(OdIBrCoedge), jarg, bIsWrapperOwnNativeObject: false);
			}
		}
	}
}

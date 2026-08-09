using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdIBrComplex : OdIBrEntity
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIBrComplex(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdIBrComplex_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIBrComplex obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdIBrComplex(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual void next(OdIBrShell pFirstChild, ref OdIBrShell pCurChild)
	{
		IntPtr jarg = OdIBrShell.getCPtr(pCurChild).Handle;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdIBrComplex_next(swigCPtr, OdIBrShell.getCPtr(pFirstChild), ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (OdIBrShell.getCPtr(pCurChild).Handle != jarg)
			{
				pCurChild = Helpers.odCreateObjectInternal<OdIBrShell>(typeof(OdIBrShell), jarg, bIsWrapperOwnNativeObject: false);
			}
		}
	}
}

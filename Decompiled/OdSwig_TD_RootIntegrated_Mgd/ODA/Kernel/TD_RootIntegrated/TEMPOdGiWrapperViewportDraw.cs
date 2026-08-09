using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class TEMPOdGiWrapperViewportDraw : TempOdGiWrapperCommonDraw
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TEMPOdGiWrapperViewportDraw(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.TEMPOdGiWrapperViewportDraw_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TEMPOdGiWrapperViewportDraw obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.deletePD_TEMPOdGiWrapperViewportDraw(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new virtual OdGiViewport viewport()
	{
		OdGiViewport rXObject = Helpers.GetRXObject<OdGiViewport>(TD_RootIntegrated_GlobalsPINVOKE.TEMPOdGiWrapperViewportDraw_viewport(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdGiViewportGeometry geometry()
	{
		OdGiViewportGeometry rXObject = Helpers.GetRXObject<OdGiViewportGeometry>(TD_RootIntegrated_GlobalsPINVOKE.TEMPOdGiWrapperViewportDraw_geometry(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual uint sequenceNumber()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.TEMPOdGiWrapperViewportDraw_sequenceNumber(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isValidId(uint viewportId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.TEMPOdGiWrapperViewportDraw_isValidId(swigCPtr, viewportId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdDbStub viewportObjectId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.TEMPOdGiWrapperViewportDraw_viewportObjectId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

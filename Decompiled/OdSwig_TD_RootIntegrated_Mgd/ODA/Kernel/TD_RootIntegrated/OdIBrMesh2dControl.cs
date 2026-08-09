using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdIBrMesh2dControl : OdIBrMeshControl
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIBrMesh2dControl(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdIBrMesh2dControl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIBrMesh2dControl obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdIBrMesh2dControl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual OdBrErrorStatus setMaxAspectRatio(double maxAspectRatio)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMesh2dControl_setMaxAspectRatio__SWIG_0(swigCPtr, maxAspectRatio);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus setMaxAspectRatio()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMesh2dControl_setMaxAspectRatio__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus getMaxAspectRatio(out double maxAspectRatio)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMesh2dControl_getMaxAspectRatio(swigCPtr, out maxAspectRatio);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus setElementShape(Element2dShape elementShape)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMesh2dControl_setElementShape__SWIG_0(swigCPtr, (int)elementShape);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus setElementShape()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMesh2dControl_setElementShape__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public virtual OdBrErrorStatus getElementShape(out Element2dShape elementShape)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMesh2dControl_getElementShape(swigCPtr, out elementShape);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}
}

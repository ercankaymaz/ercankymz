using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrMesh2dControl : OdBrMeshControl
{
	private object locker = new object();

	private HandleRef swigCPtr;

	public static OdBrMesh2dControl OdBrMesh2dControlDefault
	{
		get
		{
			OdBrMesh2dControl result = new OdBrMesh2dControl(TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dControl_OdBrMesh2dControlDefault_get(), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrMesh2dControl(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dControl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrMesh2dControl obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrMesh2dControl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdBrMesh2dControl()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrMesh2dControl__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrMesh2dControl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrMesh2dControl(OdBrMesh2dControl src)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrMesh2dControl__SWIG_1(getCPtr(src)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrMesh2dControl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrMesh2dControl Assign(OdBrMesh2dControl src)
	{
		OdBrMesh2dControl result = new OdBrMesh2dControl(TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dControl_Assign__SWIG_0(swigCPtr, getCPtr(src)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus setMaxAspectRatio(double maxAspectRatio)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dControl_setMaxAspectRatio__SWIG_0(swigCPtr, maxAspectRatio);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setMaxAspectRatio()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dControl_setMaxAspectRatio__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getMaxAspectRatio(out double maxAspectRatio)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dControl_getMaxAspectRatio(swigCPtr, out maxAspectRatio);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setElementShape(Element2dShape elementShape)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dControl_setElementShape__SWIG_0(swigCPtr, (int)elementShape);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setElementShape()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dControl_setElementShape__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getElementShape(out Element2dShape elementShape)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dControl_getElementShape(swigCPtr, out elementShape);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	protected OdBrMesh2dControl(IntPtr pImpl)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrMesh2dControl__SWIG_3(pImpl), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrMesh2dControl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dControl_director_connect(swigCPtr);
	}
}

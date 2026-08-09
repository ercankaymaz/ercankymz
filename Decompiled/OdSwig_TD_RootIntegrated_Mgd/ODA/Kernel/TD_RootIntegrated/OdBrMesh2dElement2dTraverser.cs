using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrMesh2dElement2dTraverser : OdBrTraverser
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrMesh2dElement2dTraverser(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dElement2dTraverser_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrMesh2dElement2dTraverser obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrMesh2dElement2dTraverser(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdBrMesh2dElement2dTraverser()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrMesh2dElement2dTraverser__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrMesh2dElement2dTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrMesh2dElement2dTraverser(OdBrMesh2dElement2dTraverser arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrMesh2dElement2dTraverser__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrMesh2dElement2dTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrMesh2dElement2dTraverser Assign(OdBrMesh2dElement2dTraverser arg0)
	{
		OdBrMesh2dElement2dTraverser result = new OdBrMesh2dElement2dTraverser(TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dElement2dTraverser_Assign__SWIG_0(swigCPtr, getCPtr(arg0)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus setMeshAndElement(OdBrElement2d element2d)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dElement2dTraverser_setMeshAndElement(swigCPtr, OdBrElement2d.getCPtr(element2d));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setMesh(OdBrMesh2d mesh2d)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dElement2dTraverser_setMesh(swigCPtr, OdBrMesh2d.getCPtr(mesh2d));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getMesh(OdBrMesh2d mesh2d)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dElement2dTraverser_getMesh(swigCPtr, OdBrMesh2d.getCPtr(mesh2d));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setElement(OdBrElement2d element2d)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dElement2dTraverser_setElement(swigCPtr, OdBrElement2d.getCPtr(element2d));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getElement(OdBrElement2d element2d)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dElement2dTraverser_getElement(swigCPtr, OdBrElement2d.getCPtr(element2d));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrMesh2dElement2dTraverser_director_connect(swigCPtr);
	}
}

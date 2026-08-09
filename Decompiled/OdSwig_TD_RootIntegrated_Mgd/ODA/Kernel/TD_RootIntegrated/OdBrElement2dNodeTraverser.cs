using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrElement2dNodeTraverser : OdBrTraverser
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrElement2dNodeTraverser(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdBrElement2dNodeTraverser_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrElement2dNodeTraverser obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrElement2dNodeTraverser(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdBrElement2dNodeTraverser()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrElement2dNodeTraverser__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrElement2dNodeTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrElement2dNodeTraverser(OdBrElement2dNodeTraverser arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrElement2dNodeTraverser__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrElement2dNodeTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrElement2dNodeTraverser Assign(OdBrElement2dNodeTraverser arg0)
	{
		OdBrElement2dNodeTraverser result = new OdBrElement2dNodeTraverser(TD_RootIntegrated_GlobalsPINVOKE.OdBrElement2dNodeTraverser_Assign__SWIG_0(swigCPtr, getCPtr(arg0)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus setElement(OdBrMesh2dElement2dTraverser mesh2dElement2dTraverser)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrElement2dNodeTraverser_setElement__SWIG_0(swigCPtr, OdBrMesh2dElement2dTraverser.getCPtr(mesh2dElement2dTraverser));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setElement(OdBrElement2d element)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrElement2dNodeTraverser_setElement__SWIG_1(swigCPtr, OdBrElement2d.getCPtr(element));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getElement(OdBrElement2d element)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrElement2dNodeTraverser_getElement(swigCPtr, OdBrElement2d.getCPtr(element));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setNode(OdBrNode node)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrElement2dNodeTraverser_setNode(swigCPtr, OdBrNode.getCPtr(node));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getNode(OdBrNode node)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrElement2dNodeTraverser_getNode(swigCPtr, OdBrNode.getCPtr(node));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getSurfaceNormal(OdGeVector3d vector)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrElement2dNodeTraverser_getSurfaceNormal(swigCPtr, OdGeVector3d.getCPtr(vector));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getParamPoint(OdGePoint2d point)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrElement2dNodeTraverser_getParamPoint(swigCPtr, OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrElement2dNodeTraverser_director_connect(swigCPtr);
	}
}

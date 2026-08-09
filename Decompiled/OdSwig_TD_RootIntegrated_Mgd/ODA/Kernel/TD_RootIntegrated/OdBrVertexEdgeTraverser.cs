using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrVertexEdgeTraverser : OdBrTraverser
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrVertexEdgeTraverser(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexEdgeTraverser_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrVertexEdgeTraverser obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrVertexEdgeTraverser(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdBrVertexEdgeTraverser()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrVertexEdgeTraverser__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrVertexEdgeTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrVertexEdgeTraverser(OdBrVertexEdgeTraverser arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrVertexEdgeTraverser__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrVertexEdgeTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrVertexEdgeTraverser Assign(OdBrVertexEdgeTraverser arg0)
	{
		OdBrVertexEdgeTraverser result = new OdBrVertexEdgeTraverser(TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexEdgeTraverser_Assign__SWIG_0(swigCPtr, getCPtr(arg0)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus setVertex(OdBrVertex vertex)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexEdgeTraverser_setVertex(swigCPtr, OdBrVertex.getCPtr(vertex));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setEdge(OdBrEdge edge)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexEdgeTraverser_setEdge(swigCPtr, OdBrEdge.getCPtr(edge));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrEdge getEdge()
	{
		OdBrEdge result = new OdBrEdge(TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexEdgeTraverser_getEdge(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrVertex getVertex()
	{
		OdBrVertex result = new OdBrVertex(TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexEdgeTraverser_getVertex(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexEdgeTraverser_director_connect(swigCPtr);
	}
}

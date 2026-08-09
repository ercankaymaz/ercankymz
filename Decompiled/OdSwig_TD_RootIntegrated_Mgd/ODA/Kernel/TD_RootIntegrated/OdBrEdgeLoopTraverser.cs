using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrEdgeLoopTraverser : OdBrTraverser
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrEdgeLoopTraverser(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdBrEdgeLoopTraverser_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrEdgeLoopTraverser obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrEdgeLoopTraverser(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdBrEdgeLoopTraverser()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrEdgeLoopTraverser__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrEdgeLoopTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrEdgeLoopTraverser(OdBrEdgeLoopTraverser arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrEdgeLoopTraverser__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrEdgeLoopTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrEdgeLoopTraverser Assign(OdBrEdgeLoopTraverser arg0)
	{
		OdBrEdgeLoopTraverser result = new OdBrEdgeLoopTraverser(TD_RootIntegrated_GlobalsPINVOKE.OdBrEdgeLoopTraverser_Assign__SWIG_0(swigCPtr, getCPtr(arg0)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus setEdge(OdBrEdge edge)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEdgeLoopTraverser_setEdge__SWIG_0(swigCPtr, OdBrEdge.getCPtr(edge));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setEdge(OdBrVertexEdgeTraverser vertexEdge)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEdgeLoopTraverser_setEdge__SWIG_1(swigCPtr, OdBrVertexEdgeTraverser.getCPtr(vertexEdge));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setLoop(OdBrLoop loop)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEdgeLoopTraverser_setLoop(swigCPtr, OdBrLoop.getCPtr(loop));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setEdgeAndLoop(OdBrLoopEdgeTraverser loopEdge)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrEdgeLoopTraverser_setEdgeAndLoop(swigCPtr, OdBrLoopEdgeTraverser.getCPtr(loopEdge));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrLoop getLoop()
	{
		OdBrLoop result = new OdBrLoop(TD_RootIntegrated_GlobalsPINVOKE.OdBrEdgeLoopTraverser_getLoop(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrEdge getEdge()
	{
		OdBrEdge result = new OdBrEdge(TD_RootIntegrated_GlobalsPINVOKE.OdBrEdgeLoopTraverser_getEdge(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrEdgeLoopTraverser_director_connect(swigCPtr);
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrVertexLoopTraverser : OdBrTraverser
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrVertexLoopTraverser(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexLoopTraverser_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrVertexLoopTraverser obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrVertexLoopTraverser(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdBrVertexLoopTraverser()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrVertexLoopTraverser__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrVertexLoopTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrVertexLoopTraverser(OdBrVertexLoopTraverser arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrVertexLoopTraverser__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrVertexLoopTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrVertexLoopTraverser Assign(OdBrVertexLoopTraverser arg0)
	{
		OdBrVertexLoopTraverser result = new OdBrVertexLoopTraverser(TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexLoopTraverser_Assign__SWIG_0(swigCPtr, getCPtr(arg0)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus setVertex(OdBrVertex vertex)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexLoopTraverser_setVertex(swigCPtr, OdBrVertex.getCPtr(vertex));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setLoop(OdBrLoop loop)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexLoopTraverser_setLoop(swigCPtr, OdBrLoop.getCPtr(loop));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setVertexAndLoop(OdBrLoopVertexTraverser loopVertex)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexLoopTraverser_setVertexAndLoop(swigCPtr, OdBrLoopVertexTraverser.getCPtr(loopVertex));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrLoop getLoop()
	{
		OdBrLoop result = new OdBrLoop(TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexLoopTraverser_getLoop(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrVertex getVertex()
	{
		OdBrVertex result = new OdBrVertex(TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexLoopTraverser_getVertex(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrVertexLoopTraverser_director_connect(swigCPtr);
	}
}

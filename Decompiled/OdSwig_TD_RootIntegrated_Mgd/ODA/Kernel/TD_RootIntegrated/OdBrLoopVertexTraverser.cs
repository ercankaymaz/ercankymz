using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrLoopVertexTraverser : OdBrTraverser
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrLoopVertexTraverser(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopVertexTraverser_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrLoopVertexTraverser obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrLoopVertexTraverser(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdBrLoopVertexTraverser()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrLoopVertexTraverser__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrLoopVertexTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrLoopVertexTraverser(OdBrLoopVertexTraverser arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrLoopVertexTraverser__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrLoopVertexTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrLoopVertexTraverser Assign(OdBrLoopVertexTraverser arg0)
	{
		OdBrLoopVertexTraverser result = new OdBrLoopVertexTraverser(TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopVertexTraverser_Assign__SWIG_0(swigCPtr, getCPtr(arg0)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrVertex getVertex()
	{
		OdBrVertex result = new OdBrVertex(TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopVertexTraverser_getVertex(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrLoop getLoop()
	{
		OdBrLoop result = new OdBrLoop(TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopVertexTraverser_getLoop(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus setLoop(OdBrLoop loop)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopVertexTraverser_setLoop__SWIG_0(swigCPtr, OdBrLoop.getCPtr(loop));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setLoop(OdBrFaceLoopTraverser faceLoop)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopVertexTraverser_setLoop__SWIG_1(swigCPtr, OdBrFaceLoopTraverser.getCPtr(faceLoop));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setLoopAndVertex(OdBrVertexLoopTraverser vertexLoop)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopVertexTraverser_setLoopAndVertex(swigCPtr, OdBrVertexLoopTraverser.getCPtr(vertexLoop));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setVertex(OdBrVertex vertex)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopVertexTraverser_setVertex(swigCPtr, OdBrVertex.getCPtr(vertex));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getParamPoint(OdGePoint2d point)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopVertexTraverser_getParamPoint(swigCPtr, OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopVertexTraverser_director_connect(swigCPtr);
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrLoopEdgeTraverser : OdBrTraverser
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrLoopEdgeTraverser(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrLoopEdgeTraverser obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrLoopEdgeTraverser(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdBrLoopEdgeTraverser()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrLoopEdgeTraverser__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrLoopEdgeTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrLoopEdgeTraverser(OdBrLoopEdgeTraverser arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrLoopEdgeTraverser__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrLoopEdgeTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrLoopEdgeTraverser Assign(OdBrLoopEdgeTraverser arg0)
	{
		OdBrLoopEdgeTraverser result = new OdBrLoopEdgeTraverser(TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_Assign__SWIG_0(swigCPtr, getCPtr(arg0)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve3d getOrientedCurve()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_getOrientedCurve(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getOrientedCurveAsNurb(OdGeNurbCurve3d nurb)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_getOrientedCurveAsNurb(swigCPtr, OdGeNurbCurve3d.getCPtr(nurb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCurve2d getParamCurve()
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_getParamCurve(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus getParamCurveAsNurb(OdGeNurbCurve2d nurb)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_getParamCurveAsNurb(swigCPtr, OdGeNurbCurve2d.getCPtr(nurb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public bool getEdgeOrientToLoop()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_getEdgeOrientToLoop(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrEdge getEdge()
	{
		OdBrEdge result = new OdBrEdge(TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_getEdge(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrLoop getLoop()
	{
		OdBrLoop result = new OdBrLoop(TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_getLoop(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus setEdge(OdBrEdge edge)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_setEdge(swigCPtr, OdBrEdge.getCPtr(edge));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setLoop(OdBrLoop loop)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_setLoop__SWIG_0(swigCPtr, OdBrLoop.getCPtr(loop));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setLoop(OdBrFaceLoopTraverser faceLoop)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_setLoop__SWIG_1(swigCPtr, OdBrFaceLoopTraverser.getCPtr(faceLoop));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setLoopAndEdge(OdBrEdgeLoopTraverser edgeLoop)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_setLoopAndEdge(swigCPtr, OdBrEdgeLoopTraverser.getCPtr(edgeLoop));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrLoopEdgeTraverser_director_connect(swigCPtr);
	}
}

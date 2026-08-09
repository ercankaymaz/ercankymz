using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrFaceLoopTraverser : OdBrTraverser
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrFaceLoopTraverser(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdBrFaceLoopTraverser_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrFaceLoopTraverser obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrFaceLoopTraverser(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdBrFaceLoopTraverser()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrFaceLoopTraverser__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrFaceLoopTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrFaceLoopTraverser(OdBrFaceLoopTraverser arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrFaceLoopTraverser__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrFaceLoopTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrFaceLoopTraverser Assign(OdBrFaceLoopTraverser arg0)
	{
		OdBrFaceLoopTraverser result = new OdBrFaceLoopTraverser(TD_RootIntegrated_GlobalsPINVOKE.OdBrFaceLoopTraverser_Assign__SWIG_0(swigCPtr, getCPtr(arg0)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus setFace(OdBrFace face)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFaceLoopTraverser_setFace__SWIG_0(swigCPtr, OdBrFace.getCPtr(face));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setFace(OdBrShellFaceTraverser shellFaceTrav)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFaceLoopTraverser_setFace__SWIG_1(swigCPtr, OdBrShellFaceTraverser.getCPtr(shellFaceTrav));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setLoop(OdBrLoop loop)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFaceLoopTraverser_setLoop(swigCPtr, OdBrLoop.getCPtr(loop));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setFaceAndLoop(OdBrLoop loop)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFaceLoopTraverser_setFaceAndLoop(swigCPtr, OdBrLoop.getCPtr(loop));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrLoop getLoop()
	{
		OdBrLoop result = new OdBrLoop(TD_RootIntegrated_GlobalsPINVOKE.OdBrFaceLoopTraverser_getLoop(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrFace getFace()
	{
		OdBrFace result = new OdBrFace(TD_RootIntegrated_GlobalsPINVOKE.OdBrFaceLoopTraverser_getFace(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrFaceLoopTraverser_director_connect(swigCPtr);
	}
}

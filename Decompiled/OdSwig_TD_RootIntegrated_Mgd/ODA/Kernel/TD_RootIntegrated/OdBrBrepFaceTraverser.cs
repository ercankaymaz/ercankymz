using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrBrepFaceTraverser : OdBrTraverser
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrBrepFaceTraverser(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdBrBrepFaceTraverser_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrBrepFaceTraverser obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrBrepFaceTraverser(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdBrBrepFaceTraverser()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrBrepFaceTraverser__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrBrepFaceTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrBrepFaceTraverser(OdBrBrepFaceTraverser arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrBrepFaceTraverser__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrBrepFaceTraverser) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrBrepFaceTraverser Assign(OdBrBrepFaceTraverser arg0)
	{
		OdBrBrepFaceTraverser result = new OdBrBrepFaceTraverser(TD_RootIntegrated_GlobalsPINVOKE.OdBrBrepFaceTraverser_Assign__SWIG_0(swigCPtr, getCPtr(arg0)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus setBrep(OdBrBrep brep)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrBrepFaceTraverser_setBrep(swigCPtr, OdBrBrep.getCPtr(brep));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setBrepAndFace(OdBrFace face)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrBrepFaceTraverser_setBrepAndFace(swigCPtr, OdBrFace.getCPtr(face));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus setFace(OdBrFace face)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrBrepFaceTraverser_setFace(swigCPtr, OdBrFace.getCPtr(face));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrFace getFace()
	{
		OdBrFace result = new OdBrFace(TD_RootIntegrated_GlobalsPINVOKE.OdBrBrepFaceTraverser_getFace(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrBrep getBrep()
	{
		OdBrBrep result = new OdBrBrep(TD_RootIntegrated_GlobalsPINVOKE.OdBrBrepFaceTraverser_getBrep(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrBrepFaceTraverser_director_connect(swigCPtr);
	}
}

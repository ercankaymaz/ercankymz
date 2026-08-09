using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdIBrLoop : OdIBrEntity
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIBrLoop(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdIBrLoop_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIBrLoop obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdIBrLoop(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual OdIBrFace getFace()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdIBrLoop_getFace(swigCPtr);
		OdIBrFace result = ((intPtr == IntPtr.Zero) ? null : new OdIBrFace(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void next(OdIBrVertex pFirstChild, ref OdIBrVertex pCurChild)
	{
		IntPtr jarg = OdIBrVertex.getCPtr(pCurChild).Handle;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdIBrLoop_next__SWIG_0(swigCPtr, OdIBrVertex.getCPtr(pFirstChild), ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (OdIBrVertex.getCPtr(pCurChild).Handle != jarg)
			{
				pCurChild = Helpers.odCreateObjectInternal<OdIBrVertex>(typeof(OdIBrVertex), jarg, bIsWrapperOwnNativeObject: false);
			}
		}
	}

	public virtual void next(OdIBrCoedge pFirstChild, ref OdIBrCoedge pCurChild)
	{
		IntPtr jarg = OdIBrCoedge.getCPtr(pCurChild).Handle;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdIBrLoop_next__SWIG_1(swigCPtr, OdIBrCoedge.getCPtr(pFirstChild), ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (OdIBrCoedge.getCPtr(pCurChild).Handle != jarg)
			{
				pCurChild = Helpers.odCreateObjectInternal<OdIBrCoedge>(typeof(OdIBrCoedge), jarg, bIsWrapperOwnNativeObject: false);
			}
		}
	}

	public virtual OdIBrCoedge find(OdIBrEdge pEdge)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdIBrLoop_find(swigCPtr, OdIBrEdge.getCPtr(pEdge));
		OdIBrCoedge result = ((intPtr == IntPtr.Zero) ? null : new OdIBrCoedge(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeCurve2d getParamCurve(OdIBrCoedge pIBrCoedge)
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdIBrLoop_getParamCurve(swigCPtr, OdIBrCoedge.getCPtr(pIBrCoedge)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getParamCurveAsNurb(OdIBrCoedge pIBrCoedge, OdGeNurbCurve2d nurb)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrLoop_getParamCurveAsNurb(swigCPtr, OdIBrCoedge.getCPtr(pIBrCoedge), OdGeNurbCurve2d.getCPtr(nurb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeCurve3d getOrientedCurve(OdIBrCoedge pIBrCoedge)
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdIBrLoop_getOrientedCurve(swigCPtr, OdIBrCoedge.getCPtr(pIBrCoedge)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getOrientedCurveAsNurb(OdIBrCoedge pIBrCoedge, OdGeNurbCurve3d nurb)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrLoop_getOrientedCurveAsNurb(swigCPtr, OdIBrCoedge.getCPtr(pIBrCoedge), OdGeNurbCurve3d.getCPtr(nurb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getEdgeOrientToLoop(OdIBrCoedge pIBrCoedge)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrLoop_getEdgeOrientToLoop(swigCPtr, OdIBrCoedge.getCPtr(pIBrCoedge));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual BrLoopType getType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrLoop_getType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (BrLoopType)result;
	}
}

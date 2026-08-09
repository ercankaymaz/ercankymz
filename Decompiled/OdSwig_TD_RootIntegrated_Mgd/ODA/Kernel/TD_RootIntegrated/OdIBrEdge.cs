using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdIBrEdge : OdIBrEntity
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIBrEdge(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdIBrEdge_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIBrEdge obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdIBrEdge(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual OdIBrVertex getVertex1()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEdge_getVertex1(swigCPtr);
		OdIBrVertex result = ((intPtr == IntPtr.Zero) ? null : new OdIBrVertex(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdIBrVertex getVertex2()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEdge_getVertex2(swigCPtr);
		OdIBrVertex result = ((intPtr == IntPtr.Zero) ? null : new OdIBrVertex(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGe_EntityId getCurveType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEdge_getCurveType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_EntityId)result;
	}

	public virtual OdGeCurve3d getGeCurve()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdIBrEdge_getGeCurve__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdBrErrorStatus getGeCurve(out OdGeCurve3d pCurve)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEdge_getGeCurve__SWIG_1(swigCPtr, out jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdBrErrorStatus)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, bIsWrapperOwnNativeObject: true));
			pCurve = Helpers.odCreateObjectInternal<OdGeCurve3d>(typeof(OdGeCurve3d), jarg, currentTransaction == null);
		}
	}

	public virtual bool getCurveAsNurb(OdGeNurbCurve3d nurb)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEdge_getCurveAsNurb(swigCPtr, OdGeNurbCurve3d.getCPtr(nurb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getOrientToCurve()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEdge_getOrientToCurve(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void next(OdIBrCoedge pFirstChild, ref OdIBrCoedge pCurChild)
	{
		IntPtr jarg = OdIBrCoedge.getCPtr(pCurChild).Handle;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdIBrEdge_next(swigCPtr, OdIBrCoedge.getCPtr(pFirstChild), ref jarg);
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

	public virtual bool hasColor(byte typeFlag)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEdge_hasColor(swigCPtr, typeFlag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getTrueColor(out uint rgb)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEdge_getTrueColor(swigCPtr, out rgb);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getColorIndex(out ushort indx)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrEdge_getColorIndex(swigCPtr, out indx);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

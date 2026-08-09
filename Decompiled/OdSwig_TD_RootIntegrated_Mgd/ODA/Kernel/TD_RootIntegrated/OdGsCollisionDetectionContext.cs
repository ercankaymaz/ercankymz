using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsCollisionDetectionContext : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsCollisionDetectionContext(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsCollisionDetectionContext obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsCollisionDetectionContext()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsCollisionDetectionContext(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsCollisionDetectionContext()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCollisionDetectionContext(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setIntersectionOnly(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_setIntersectionOnly(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool intersectionOnly()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_intersectionOnly(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIntersectionWithModel(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_setIntersectionWithModel(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool intersectionWithModel()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_intersectionWithModel(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIgnoreViewExtents(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_setIgnoreViewExtents(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool ignoreViewExtents()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_ignoreViewExtents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCombineSubEntities(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_setCombineSubEntities(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool combineSubEntities()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_combineSubEntities(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setToleranceOverride(OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_setToleranceOverride(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isToleranceOverride()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_isToleranceOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeTol toleranceOverride()
	{
		OdGeTol result = new OdGeTol(TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_toleranceOverride(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCalculateDistance(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_setCalculateDistance(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getCalculateDistance()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_getCalculateDistance(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCheckAll(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_setCheckAll(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getCheckAll()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_getCheckAll(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setClearance(double c)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_setClearance(swigCPtr, c);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double getClearance()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_getClearance(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setProcessSingleList(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_setProcessSingleList(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getProcessSingleList()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCollisionDetectionContext_getProcessSingleList(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

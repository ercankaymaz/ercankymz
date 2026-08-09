using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdIBrHit : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIBrHit(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIBrHit obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdIBrHit()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdIBrHit(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual bool isEqualTo(OdIBrHit pIBrHit)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrHit_isEqualTo(swigCPtr, getCPtr(pIBrHit));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdIBrHit copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdIBrHit_copy(swigCPtr);
		OdIBrHit result = ((intPtr == IntPtr.Zero) ? null : new OdIBrHit(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isNull()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrHit_isNull(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool brepChanged()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrHit_brepChanged(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdBrErrorStatus getEntityHit(out OdIBrEntity entityHit, out uint subentType)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrHit_getEntityHit(swigCPtr, out jarg, out subentType);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdBrErrorStatus)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdIBrEntity>(typeof(OdIBrEntity), jarg, bIsWrapperOwnNativeObject: true));
			entityHit = Helpers.odCreateObjectInternal<OdIBrEntity>(typeof(OdIBrEntity), jarg, currentTransaction == null);
		}
	}

	public virtual OdBrErrorStatus getEntityEntered(out OdIBrEntity entityEntered, out uint subentType)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrHit_getEntityEntered(swigCPtr, out jarg, out subentType);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdBrErrorStatus)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdIBrEntity>(typeof(OdIBrEntity), jarg, bIsWrapperOwnNativeObject: true));
			entityEntered = Helpers.odCreateObjectInternal<OdIBrEntity>(typeof(OdIBrEntity), jarg, currentTransaction == null);
		}
	}

	public virtual OdBrErrorStatus getEntityAssociated(out OdIBrEntity entityEntered, out uint subentType)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrHit_getEntityAssociated(swigCPtr, out jarg, out subentType);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdBrErrorStatus)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdIBrEntity>(typeof(OdIBrEntity), jarg, bIsWrapperOwnNativeObject: true));
			entityEntered = Helpers.odCreateObjectInternal<OdIBrEntity>(typeof(OdIBrEntity), jarg, currentTransaction == null);
		}
	}

	public virtual OdBrErrorStatus getPoint(OdGePoint3d point)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrHit_getPoint(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}
}

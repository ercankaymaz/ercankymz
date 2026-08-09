using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrMeshEntity : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrMeshEntity(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrMeshEntity obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdBrMeshEntity()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrMeshEntity(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public bool isEqualTo(OdBrMeshEntity other)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMeshEntity_isEqualTo(swigCPtr, getCPtr(other));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isNull()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMeshEntity_isNull(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus getEntityAssociated(out OdBrEntity entity)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMeshEntity_getEntityAssociated(swigCPtr, out jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdBrErrorStatus)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdBrEntity>(typeof(OdBrEntity), jarg, bIsWrapperOwnNativeObject: true));
			entity = Helpers.odCreateObjectInternal<OdBrEntity>(typeof(OdBrEntity), jarg, currentTransaction == null);
		}
	}

	public OdBrErrorStatus setValidationLevel(ref BrValidationLevel level)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMeshEntity_setValidationLevel(swigCPtr, ref level);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getValidationLevel(ref BrValidationLevel level)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMeshEntity_getValidationLevel(swigCPtr, ref level);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public bool brepChanged()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrMeshEntity_brepChanged(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected OdBrMeshEntity()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrMeshEntity__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrMeshEntity) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected OdBrMeshEntity(OdBrMeshEntity arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrMeshEntity__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrMeshEntity) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrMeshEntity_director_connect(swigCPtr);
	}
}

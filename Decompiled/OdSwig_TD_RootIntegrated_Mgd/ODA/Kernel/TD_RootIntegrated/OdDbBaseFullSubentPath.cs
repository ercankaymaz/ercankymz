using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbBaseFullSubentPath : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBaseFullSubentPath(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBaseFullSubentPath obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbBaseFullSubentPath()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbBaseFullSubentPath(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbBaseFullSubentPath()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseFullSubentPath__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBaseFullSubentPath(OdDb_SubentType type, IntPtr index)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseFullSubentPath__SWIG_1((int)type, index), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBaseFullSubentPath(OdDbStub entId, OdDbSubentId subId)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseFullSubentPath__SWIG_2(OdDbStub.getCPtr(entId), OdDbSubentId.getCPtr(subId)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBaseFullSubentPath(OdDbStub entId, OdDb_SubentType type, IntPtr index)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseFullSubentPath__SWIG_3(OdDbStub.getCPtr(entId), (int)type, index), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBaseFullSubentPath(OdDbStubPtrArray objectIds, OdDbSubentId subId)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseFullSubentPath__SWIG_4(OdDbStubPtrArray.getCPtr(objectIds), OdDbSubentId.getCPtr(subId)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void objectIds(OdDbStubPtrArray objectIdsArg)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseFullSubentPath_objectIds__SWIG_0(swigCPtr, OdDbStubPtrArray.getCPtr(objectIdsArg));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBaseFullSubentPath Assign(OdDbBaseFullSubentPath fullSubentPath)
	{
		OdDbBaseFullSubentPath result = new OdDbBaseFullSubentPath(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseFullSubentPath_Assign(swigCPtr, getCPtr(fullSubentPath)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdDbBaseFullSubentPath fullSubentPath)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseFullSubentPath_IsEqual(swigCPtr, getCPtr(fullSubentPath));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStubPtrArray objectIds()
	{
		OdDbStubPtrArray result = new OdDbStubPtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseFullSubentPath_objectIds__SWIG_1(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbSubentId subentId()
	{
		OdDbSubentId result = new OdDbSubentId(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseFullSubentPath_subentId__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

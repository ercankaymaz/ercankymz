using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGraphStack : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGraphStack(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGraphStack obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbGraphStack()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGraphStack(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbGraphStack(int initPhysicalLength, int initGrowLength)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbGraphStack__SWIG_0(initPhysicalLength, initGrowLength), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbGraphStack(int initPhysicalLength)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbGraphStack__SWIG_1(initPhysicalLength), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbGraphStack()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbGraphStack__SWIG_2(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void push(OdDbGraphNode pNode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraphStack_push(swigCPtr, OdDbGraphNode.getCPtr(pNode));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbGraphNode pop()
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		IntPtr p = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraphStack_pop(swigCPtr);
		OdDbGraphNode odDbGraphNode = null;
		if (currentTransaction != null)
		{
			currentTransaction.AddObject((OdDbGraphNode)ODA.Kernel.TD_RootIntegrated.Helpers.odrxCreateObjectInternal(p, own: true));
			odDbGraphNode = (OdDbGraphNode)ODA.Kernel.TD_RootIntegrated.Helpers.odrxCreateObjectInternal(p, own: false);
		}
		else
		{
			odDbGraphNode = (OdDbGraphNode)ODA.Kernel.TD_RootIntegrated.Helpers.odrxCreateObjectInternal(p, own: true);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odDbGraphNode;
	}

	public OdDbGraphNode top()
	{
		OdDbGraphNode rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGraphNode>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraphStack_top(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isEmpty()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraphStack_isEmpty(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

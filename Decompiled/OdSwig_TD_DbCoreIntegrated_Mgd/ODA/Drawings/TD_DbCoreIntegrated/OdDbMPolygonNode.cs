using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbMPolygonNode : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdDbMPolygonNode mParent
	{
		get
		{
			IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygonNode_mParent_get(swigCPtr);
			OdDbMPolygonNode result = ((intPtr == IntPtr.Zero) ? null : new OdDbMPolygonNode(intPtr, cMemoryOwn: false));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygonNode_mParent_set(swigCPtr, getCPtr(value));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdArray_OdDbMPolygonNode__p_OdObjectsAllocator mChildren
	{
		get
		{
			IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygonNode_mChildren_get(swigCPtr);
			OdArray_OdDbMPolygonNode__p_OdObjectsAllocator result = ((intPtr == IntPtr.Zero) ? null : new OdArray_OdDbMPolygonNode__p_OdObjectsAllocator(intPtr, cMemoryOwn: false));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygonNode_mChildren_set(swigCPtr, OdArray_OdDbMPolygonNode__p_OdObjectsAllocator.getCPtr(value));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int mLoopIndex
	{
		get
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygonNode_mLoopIndex_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygonNode_mLoopIndex_set(swigCPtr, value);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbMPolygonNode(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbMPolygonNode obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbMPolygonNode()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbMPolygonNode(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbMPolygonNode()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbMPolygonNode(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

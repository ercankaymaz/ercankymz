using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiProgressiveMeshVertexData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdVector_OdGeVector3d_OdObjectsAllocator_OdGeVector3d_OdrxMemoryManager normals
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshVertexData_normals_get(swigCPtr);
			OdVector_OdGeVector3d_OdObjectsAllocator_OdGeVector3d_OdrxMemoryManager result = ((intPtr == IntPtr.Zero) ? null : new OdVector_OdGeVector3d_OdObjectsAllocator_OdGeVector3d_OdrxMemoryManager(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshVertexData_normals_set(swigCPtr, OdVector_OdGeVector3d_OdObjectsAllocator_OdGeVector3d_OdrxMemoryManager.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdVector_OdCmEntityColor_OdObjectsAllocator_OdCmEntityColor_OdrxMemoryManager colors
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshVertexData_colors_get(swigCPtr);
			OdVector_OdCmEntityColor_OdObjectsAllocator_OdCmEntityColor_OdrxMemoryManager result = ((intPtr == IntPtr.Zero) ? null : new OdVector_OdCmEntityColor_OdObjectsAllocator_OdCmEntityColor_OdrxMemoryManager(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshVertexData_colors_set(swigCPtr, OdVector_OdCmEntityColor_OdObjectsAllocator_OdCmEntityColor_OdrxMemoryManager.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdVector_OdGePoint3d_OdObjectsAllocator_OdGePoint3d_OdrxMemoryManager UV
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshVertexData_UV_get(swigCPtr);
			OdVector_OdGePoint3d_OdObjectsAllocator_OdGePoint3d_OdrxMemoryManager result = ((intPtr == IntPtr.Zero) ? null : new OdVector_OdGePoint3d_OdObjectsAllocator_OdGePoint3d_OdrxMemoryManager(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshVertexData_UV_set(swigCPtr, OdVector_OdGePoint3d_OdObjectsAllocator_OdGePoint3d_OdrxMemoryManager.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiProgressiveMeshVertexData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiProgressiveMeshVertexData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiProgressiveMeshVertexData()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiProgressiveMeshVertexData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiProgressiveMeshVertexData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiProgressiveMeshVertexData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

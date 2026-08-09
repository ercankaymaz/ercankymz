using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiShmDataStorage : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiShmDataStorage(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiShmDataStorage obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiShmDataStorage()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiShmDataStorage(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiShmDataStorage()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiShmDataStorage(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setVertexList(OdGePoint3d pVertexList)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setVertexList(swigCPtr, OdGePoint3d.getCPtr(pVertexList));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d vertexList()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_vertexList(swigCPtr);
		OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3dArray vertexListArray()
	{
		OdGePoint3dArray result = new OdGePoint3dArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_vertexListArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVertexListArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setVertexListArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d resizeVertexListArray(uint nSize, bool bSetPtr)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_resizeVertexListArray__SWIG_0(swigCPtr, nSize, bSetPtr);
		OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d resizeVertexListArray(uint nSize)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_resizeVertexListArray__SWIG_1(swigCPtr, nSize);
		OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFaceList(int pFaceList)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setFaceList(swigCPtr, pFaceList);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int faceList()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_faceList(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdInt32Array faceListArray()
	{
		OdInt32Array result = new OdInt32Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_faceListArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFaceListArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setFaceListArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int resizeFaceListArray(uint nSize, bool bSetPtr)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_resizeFaceListArray__SWIG_0(swigCPtr, nSize, bSetPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int resizeFaceListArray(uint nSize)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_resizeFaceListArray__SWIG_1(swigCPtr, nSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEdgeData(EdgeData pEdgeData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setEdgeData(swigCPtr, pEdgeData);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public EdgeData edgeData()
	{
		EdgeData result = TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_edgeData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiEdgeDataStorage edgeDataStorage()
	{
		OdGiEdgeDataStorage result = new OdGiEdgeDataStorage(TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_edgeDataStorage__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEdgeDataStorage()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setEdgeDataStorage(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetEdgeData()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_resetEdgeData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void cloneEdgeData(EdgeData pEdgeData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_cloneEdgeData(swigCPtr, pEdgeData);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFaceData(OdGiFaceData pFaceData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setFaceData(swigCPtr, OdGiFaceData.getCPtr(pFaceData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiFaceData faceData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_faceData(swigCPtr);
		OdGiFaceData result = ((intPtr == IntPtr.Zero) ? null : new OdGiFaceData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiFaceDataStorage faceDataStorage()
	{
		OdGiFaceDataStorage result = new OdGiFaceDataStorage(TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_faceDataStorage__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFaceDataStorage()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setFaceDataStorage(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetFaceData()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_resetFaceData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void cloneFaceData(OdGiFaceData pFaceData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_cloneFaceData(swigCPtr, OdGiFaceData.getCPtr(pFaceData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setVertexData(OdGiVertexData pVertexData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setVertexData(swigCPtr, OdGiVertexData.getCPtr(pVertexData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiVertexData vertexData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_vertexData(swigCPtr);
		OdGiVertexData result = ((intPtr == IntPtr.Zero) ? null : new OdGiVertexData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiVertexDataStorage vertexDataStorage()
	{
		OdGiVertexDataStorage result = new OdGiVertexDataStorage(TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_vertexDataStorage__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVertexDataStorage()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setVertexDataStorage(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetVertexData()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_resetVertexData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void cloneVertexData(OdGiVertexData pVertexData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_cloneVertexData(swigCPtr, OdGiVertexData.getCPtr(pVertexData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetPointers()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_resetPointers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPointersArray(OdGiFaceData pFaceData, EdgeData pEdgeData, OdGiVertexData pVertexData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setPointersArray__SWIG_0(swigCPtr, OdGiFaceData.getCPtr(pFaceData), pEdgeData, OdGiVertexData.getCPtr(pVertexData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPointersArray(OdGiFaceData pFaceData, EdgeData pEdgeData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setPointersArray__SWIG_1(swigCPtr, OdGiFaceData.getCPtr(pFaceData), pEdgeData);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPointersArray(OdGiFaceData pFaceData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setPointersArray__SWIG_2(swigCPtr, OdGiFaceData.getCPtr(pFaceData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPointersArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_setPointersArray__SWIG_3(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearArrays(OdGiFaceData pFaceData, EdgeData pEdgeData, OdGiVertexData pVertexData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_clearArrays__SWIG_0(swigCPtr, OdGiFaceData.getCPtr(pFaceData), pEdgeData, OdGiVertexData.getCPtr(pVertexData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearArrays(OdGiFaceData pFaceData, EdgeData pEdgeData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_clearArrays__SWIG_1(swigCPtr, OdGiFaceData.getCPtr(pFaceData), pEdgeData);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearArrays(OdGiFaceData pFaceData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_clearArrays__SWIG_2(swigCPtr, OdGiFaceData.getCPtr(pFaceData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearArrays()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_clearArrays__SWIG_3(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteArrays(OdGiFaceData pFaceData, EdgeData pEdgeData, OdGiVertexData pVertexData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_deleteArrays__SWIG_0(swigCPtr, OdGiFaceData.getCPtr(pFaceData), pEdgeData, OdGiVertexData.getCPtr(pVertexData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteArrays(OdGiFaceData pFaceData, EdgeData pEdgeData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_deleteArrays__SWIG_1(swigCPtr, OdGiFaceData.getCPtr(pFaceData), pEdgeData);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteArrays(OdGiFaceData pFaceData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_deleteArrays__SWIG_2(swigCPtr, OdGiFaceData.getCPtr(pFaceData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteArrays()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiShmDataStorage_deleteArrays__SWIG_3(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

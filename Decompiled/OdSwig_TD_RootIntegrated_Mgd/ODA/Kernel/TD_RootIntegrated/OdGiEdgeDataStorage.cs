using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiEdgeDataStorage : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiEdgeDataStorage(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiEdgeDataStorage obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiEdgeDataStorage()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiEdgeDataStorage(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiEdgeDataStorage()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiEdgeDataStorage(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdUInt16Array colorsArray()
	{
		OdUInt16Array result = new OdUInt16Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_colorsArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColorsArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_setColorsArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort resizeColorsArray(uint nSize, bool bSetPtr)
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_resizeColorsArray__SWIG_0(swigCPtr, nSize, bSetPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ushort resizeColorsArray(uint nSize)
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_resizeColorsArray__SWIG_1(swigCPtr, nSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmEntityColorArray trueColorsArray()
	{
		OdCmEntityColorArray result = new OdCmEntityColorArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_trueColorsArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTrueColorsArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_setTrueColorsArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor resizeTrueColorsArray(uint nSize, bool bSetPtr)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_resizeTrueColorsArray__SWIG_0(swigCPtr, nSize, bSetPtr);
		OdCmEntityColor result = ((intPtr == IntPtr.Zero) ? null : new OdCmEntityColor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmEntityColor resizeTrueColorsArray(uint nSize)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_resizeTrueColorsArray__SWIG_1(swigCPtr, nSize);
		OdCmEntityColor result = ((intPtr == IntPtr.Zero) ? null : new OdCmEntityColor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStubPtrArray layerIdsArray()
	{
		OdDbStubPtrArray result = new OdDbStubPtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_layerIdsArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLayersArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_setLayersArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbStub resizeLayerIdsArray(uint nSize, bool bSetPtr)
	{
		OdDbStub result = new OdDbStub(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_resizeLayerIdsArray__SWIG_0(swigCPtr, nSize, bSetPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub resizeLayerIdsArray(uint nSize)
	{
		OdDbStub result = new OdDbStub(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_resizeLayerIdsArray__SWIG_1(swigCPtr, nSize), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStubPtrArray linetypeIdsArray()
	{
		OdDbStubPtrArray result = new OdDbStubPtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_linetypeIdsArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLinetypesArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_setLinetypesArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbStub resizeLinetypeIdsArray(uint nSize, bool bSetPtr)
	{
		OdDbStub result = new OdDbStub(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_resizeLinetypeIdsArray__SWIG_0(swigCPtr, nSize, bSetPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub resizeLinetypeIdsArray(uint nSize)
	{
		OdDbStub result = new OdDbStub(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_resizeLinetypeIdsArray__SWIG_1(swigCPtr, nSize), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsMarkerArray selectionMarkersArray()
	{
		OdGsMarkerArray result = new OdGsMarkerArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_selectionMarkersArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSelectionMarkersArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_setSelectionMarkersArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public IntPtr[] resizeSelectionMarkersArray(uint nSize, bool bSetPtr)
	{
		IntPtr[] result = Helpers.UnMarshalIntPtrFixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_resizeSelectionMarkersArray__SWIG_0(swigCPtr, nSize, bSetPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr[] resizeSelectionMarkersArray(uint nSize)
	{
		IntPtr[] result = Helpers.UnMarshalIntPtrFixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_resizeSelectionMarkersArray__SWIG_1(swigCPtr, nSize));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array visibilityArray()
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_visibilityArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVisibilityArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_setVisibilityArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public byte[] resizeVisibilityArray(uint nSize, bool bSetPtr)
	{
		byte[] result = Helpers.UnMarshalbyteFixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_resizeVisibilityArray__SWIG_0(swigCPtr, nSize, bSetPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte[] resizeVisibilityArray(uint nSize)
	{
		byte[] result = Helpers.UnMarshalbyteFixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_resizeVisibilityArray__SWIG_1(swigCPtr, nSize));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void cloneData(EdgeData pData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_cloneData(swigCPtr, pData);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetPointers()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_resetPointers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPointersArray(EdgeData pEdgeData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_setPointersArray__SWIG_0(swigCPtr, pEdgeData);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPointersArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_setPointersArray__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearArrays(EdgeData pEdgeData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_clearArrays__SWIG_0(swigCPtr, pEdgeData);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearArrays()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_clearArrays__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteArrays(EdgeData pEdgeData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_deleteArrays__SWIG_0(swigCPtr, pEdgeData);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteArrays()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_deleteArrays__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void reserveArrays(EdgeData pEdgeData, uint nReserve)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_reserveArrays(swigCPtr, pEdgeData, nReserve);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void copyFrom(EdgeData pEdgeData, uint nEdge)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeDataStorage_copyFrom(swigCPtr, pEdgeData, nEdge);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

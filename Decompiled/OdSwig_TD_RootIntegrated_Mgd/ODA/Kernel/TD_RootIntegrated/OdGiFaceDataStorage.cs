using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiFaceDataStorage : OdGiFaceData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiFaceDataStorage(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiFaceDataStorage obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiFaceDataStorage(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiFaceDataStorage()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiFaceDataStorage(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdUInt16Array colorsArray()
	{
		OdUInt16Array result = new OdUInt16Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_colorsArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColorsArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_setColorsArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort resizeColorsArray(uint nSize, bool bSetPtr)
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeColorsArray__SWIG_0(swigCPtr, nSize, bSetPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ushort resizeColorsArray(uint nSize)
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeColorsArray__SWIG_1(swigCPtr, nSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmEntityColorArray trueColorsArray()
	{
		OdCmEntityColorArray result = new OdCmEntityColorArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_trueColorsArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTrueColorsArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_setTrueColorsArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor resizeTrueColorsArray(uint nSize, bool bSetPtr)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeTrueColorsArray__SWIG_0(swigCPtr, nSize, bSetPtr);
		OdCmEntityColor result = ((intPtr == IntPtr.Zero) ? null : new OdCmEntityColor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmEntityColor resizeTrueColorsArray(uint nSize)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeTrueColorsArray__SWIG_1(swigCPtr, nSize);
		OdCmEntityColor result = ((intPtr == IntPtr.Zero) ? null : new OdCmEntityColor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStubPtrArray layerIdsArray()
	{
		OdDbStubPtrArray result = new OdDbStubPtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_layerIdsArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLayersArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_setLayersArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbStub resizeLayerIdsArray(uint nSize, bool bSetPtr)
	{
		OdDbStub result = new OdDbStub(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeLayerIdsArray__SWIG_0(swigCPtr, nSize, bSetPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub resizeLayerIdsArray(uint nSize)
	{
		OdDbStub result = new OdDbStub(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeLayerIdsArray__SWIG_1(swigCPtr, nSize), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsMarkerArray selectionMarkersArray()
	{
		OdGsMarkerArray result = new OdGsMarkerArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_selectionMarkersArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSelectionMarkersArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_setSelectionMarkersArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public IntPtr[] resizeSelectionMarkersArray(uint nSize, bool bSetPtr)
	{
		IntPtr[] result = Helpers.UnMarshalIntPtrFixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeSelectionMarkersArray__SWIG_0(swigCPtr, nSize, bSetPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr[] resizeSelectionMarkersArray(uint nSize)
	{
		IntPtr[] result = Helpers.UnMarshalIntPtrFixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeSelectionMarkersArray__SWIG_1(swigCPtr, nSize));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3dArray normalsArray()
	{
		OdGeVector3dArray result = new OdGeVector3dArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_normalsArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNormalsArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_setNormalsArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d resizeNormalsArray(uint nSize, bool bSetPtr)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeNormalsArray__SWIG_0(swigCPtr, nSize, bSetPtr);
		OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d resizeNormalsArray(uint nSize)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeNormalsArray__SWIG_1(swigCPtr, nSize);
		OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array visibilityArray()
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_visibilityArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVisibilityArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_setVisibilityArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public byte[] resizeVisibilityArray(uint nSize, bool bSetPtr)
	{
		byte[] result = Helpers.UnMarshalbyteFixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeVisibilityArray__SWIG_0(swigCPtr, nSize, bSetPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte[] resizeVisibilityArray(uint nSize)
	{
		byte[] result = Helpers.UnMarshalbyteFixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeVisibilityArray__SWIG_1(swigCPtr, nSize));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStubPtrArray materialsArray()
	{
		OdDbStubPtrArray result = new OdDbStubPtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_materialsArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMaterialsArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_setMaterialsArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbStub resizeMaterialsArray(uint nSize, bool bSetPtr)
	{
		OdDbStub result = new OdDbStub(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeMaterialsArray__SWIG_0(swigCPtr, nSize, bSetPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub resizeMaterialsArray(uint nSize)
	{
		OdDbStub result = new OdDbStub(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeMaterialsArray__SWIG_1(swigCPtr, nSize), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiFaceDataStorage_OdGiMapperArray mappersArray()
	{
		OdGiFaceDataStorage_OdGiMapperArray result = new OdGiFaceDataStorage_OdGiMapperArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_mappersArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMappersArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_setMappersArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMapper resizeMappersArray(uint nSize, bool bSetPtr)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeMappersArray__SWIG_0(swigCPtr, nSize, bSetPtr);
		OdGiMapper result = ((intPtr == IntPtr.Zero) ? null : new OdGiMapper(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMapper resizeMappersArray(uint nSize)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeMappersArray__SWIG_1(swigCPtr, nSize);
		OdGiMapper result = ((intPtr == IntPtr.Zero) ? null : new OdGiMapper(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmTransparencyArray transparencyArray()
	{
		OdCmTransparencyArray result = new OdCmTransparencyArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_transparencyArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTransparencyArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_setTransparencyArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmTransparency resizeTransparencyArray(uint nSize, bool bSetPtr)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeTransparencyArray__SWIG_0(swigCPtr, nSize, bSetPtr);
		OdCmTransparency result = ((intPtr == IntPtr.Zero) ? null : new OdCmTransparency(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmTransparency resizeTransparencyArray(uint nSize)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resizeTransparencyArray__SWIG_1(swigCPtr, nSize);
		OdCmTransparency result = ((intPtr == IntPtr.Zero) ? null : new OdCmTransparency(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void cloneData(OdGiFaceData pData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_cloneData(swigCPtr, OdGiFaceData.getCPtr(pData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetPointers()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_resetPointers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPointersArray(OdGiFaceData pFaceData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_setPointersArray__SWIG_0(swigCPtr, OdGiFaceData.getCPtr(pFaceData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPointersArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_setPointersArray__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearArrays(OdGiFaceData pFaceData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_clearArrays__SWIG_0(swigCPtr, OdGiFaceData.getCPtr(pFaceData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearArrays()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_clearArrays__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteArrays(OdGiFaceData pFaceData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_deleteArrays__SWIG_0(swigCPtr, OdGiFaceData.getCPtr(pFaceData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteArrays()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_deleteArrays__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void reserveArrays(OdGiFaceData pFaceData, uint nReserve)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_reserveArrays(swigCPtr, OdGiFaceData.getCPtr(pFaceData), nReserve);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void copyFrom(OdGiFaceData pFaceData, uint nFace)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceDataStorage_copyFrom(swigCPtr, OdGiFaceData.getCPtr(pFaceData), nFace);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

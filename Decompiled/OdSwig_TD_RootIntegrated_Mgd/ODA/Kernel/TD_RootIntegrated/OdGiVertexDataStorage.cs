using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiVertexDataStorage : OdGiVertexData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiVertexDataStorage(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiVertexDataStorage obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiVertexDataStorage(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiVertexDataStorage()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiVertexDataStorage(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3dArray normalsArray()
	{
		OdGeVector3dArray result = new OdGeVector3dArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_normalsArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNormalsArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_setNormalsArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d resizeNormalsArray(uint nSize, bool bSetPtr)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_resizeNormalsArray__SWIG_0(swigCPtr, nSize, bSetPtr);
		OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d resizeNormalsArray(uint nSize)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_resizeNormalsArray__SWIG_1(swigCPtr, nSize);
		OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmEntityColorArray trueColorsArray()
	{
		OdCmEntityColorArray result = new OdCmEntityColorArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_trueColorsArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTrueColorsArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_setTrueColorsArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor resizeTrueColorsArray(uint nSize, bool bSetPtr)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_resizeTrueColorsArray__SWIG_0(swigCPtr, nSize, bSetPtr);
		OdCmEntityColor result = ((intPtr == IntPtr.Zero) ? null : new OdCmEntityColor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmEntityColor resizeTrueColorsArray(uint nSize)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_resizeTrueColorsArray__SWIG_1(swigCPtr, nSize);
		OdCmEntityColor result = ((intPtr == IntPtr.Zero) ? null : new OdCmEntityColor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3dArray mappingCoordsArray(OdGiVertexData_MapChannel arg0)
	{
		OdGePoint3dArray result = new OdGePoint3dArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_mappingCoordsArray__SWIG_0(swigCPtr, (int)arg0), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMappingCoordsArray(OdGiVertexData_MapChannel channel)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_setMappingCoordsArray(swigCPtr, (int)channel);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d resizeMappingCoordsArray(OdGiVertexData_MapChannel channel, uint nSize, bool bSetPtr)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_resizeMappingCoordsArray__SWIG_0(swigCPtr, (int)channel, nSize, bSetPtr);
		OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d resizeMappingCoordsArray(OdGiVertexData_MapChannel channel, uint nSize)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_resizeMappingCoordsArray__SWIG_1(swigCPtr, (int)channel, nSize);
		OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void cloneData(OdGiVertexData pData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_cloneData(swigCPtr, OdGiVertexData.getCPtr(pData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetPointers()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_resetPointers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPointersArray(OdGiVertexData pVertexData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_setPointersArray__SWIG_0(swigCPtr, OdGiVertexData.getCPtr(pVertexData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPointersArray()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_setPointersArray__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearArrays(OdGiVertexData pVertexData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_clearArrays__SWIG_0(swigCPtr, OdGiVertexData.getCPtr(pVertexData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearArrays()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_clearArrays__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteArrays(OdGiVertexData pVertexData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_deleteArrays__SWIG_0(swigCPtr, OdGiVertexData.getCPtr(pVertexData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteArrays()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_deleteArrays__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void reserveArrays(OdGiVertexData pVertexData, uint nReserve)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_reserveArrays(swigCPtr, OdGiVertexData.getCPtr(pVertexData), nReserve);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void copyFrom(OdGiVertexData pVertexData, uint nVertex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexDataStorage_copyFrom(swigCPtr, OdGiVertexData.getCPtr(pVertexData), nVertex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

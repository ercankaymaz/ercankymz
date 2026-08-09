using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiFaceData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiFaceData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiFaceData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiFaceData()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiFaceData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiFaceData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiFaceData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFillOffsetDirections(OdGeVector2d fillOffsetDirections)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_setFillOffsetDirections(swigCPtr, OdGeVector2d.getCPtr(fillOffsetDirections));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFillOffsetScales(double fillOffsetScales)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_setFillOffsetScales(swigCPtr, fillOffsetScales);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFillDashesScales(double fillDashesScales)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_setFillDashesScales(swigCPtr, fillDashesScales);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector2d fillOffsetDirections()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_fillOffsetDirections(swigCPtr);
		OdGeVector2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double fillDashesScales()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_fillDashesScales(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double fillOffsetScales()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_fillOffsetScales(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool HasColors()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_HasColors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool HasTrueColors()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_HasTrueColors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool HasLayerIds()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_HasLayerIds(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool HasSelectionMarkers()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_HasSelectionMarkers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool HasNormals()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_HasNormals(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool HasVisibility()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_HasVisibility(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool HasMaterials()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_HasMaterials(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool HasMappers()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_HasMappers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool HasTransparency()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_HasTransparency(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool HasFillOrigins()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_HasFillOrigins(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool HasFillDirections()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_HasFillDirections(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr Colors()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_Colors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr TrueColors()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_TrueColors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr LayerIds()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_LayerIds(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr SelectionMarkers()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_SelectionMarkers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr Normals()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_Normals(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr Visibility()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_Visibility__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr Materials()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_Materials(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr Mappers()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_Mappers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr Transparency()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_Transparency__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr FillOrigins()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_FillOrigins(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr FillDirections()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_FillDirections(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void DeleteColors()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_DeleteColors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void DeleteTrueColors()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_DeleteTrueColors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void DeleteLayerIds()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_DeleteLayerIds(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void DeleteSelectionMarkers()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_DeleteSelectionMarkers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void DeleteNormals()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_DeleteNormals(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void DeleteVisibility()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_DeleteVisibility(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void DeleteMaterials()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_DeleteMaterials(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void DeleteMappers()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_DeleteMappers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void DeleteTransparency()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_DeleteTransparency(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void DeleteFillOrigins()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_DeleteFillOrigins(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void DeleteFillDirections()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_DeleteFillDirections(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ushort Color(int faceIdx)
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_Color(swigCPtr, faceIdx);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmEntityColor TrueColor(int faceIdx)
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_TrueColor(swigCPtr, faceIdx), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub LayerId(int faceIdx)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_LayerId(swigCPtr, faceIdx);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr SelectionMarker(int faceIdx)
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_SelectionMarker(swigCPtr, faceIdx);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d Normal(int faceIdx)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_Normal(swigCPtr, faceIdx), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte Visibility(int faceIdx)
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_Visibility__SWIG_1(swigCPtr, faceIdx);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub Material(int faceIdx)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_Material(swigCPtr, faceIdx);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMapper Mapper(int faceIdx)
	{
		OdGiMapper result = new OdGiMapper(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_Mapper(swigCPtr, faceIdx), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmTransparency Transparency(int faceIdx)
	{
		OdCmTransparency result = new OdCmTransparency(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_Transparency__SWIG_1(swigCPtr, faceIdx), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d FillOrigin(int faceIdx)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_FillOrigin(swigCPtr, faceIdx), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d FillDirection(int faceIdx)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_FillDirection(swigCPtr, faceIdx), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void SetColors(IntPtr data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_SetColors(swigCPtr, data);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetTrueColors(IntPtr data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_SetTrueColors(swigCPtr, data);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetLayers(IntPtr data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_SetLayers(swigCPtr, data);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetSelectionMarkers(IntPtr data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_SetSelectionMarkers(swigCPtr, data);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetNormals(IntPtr data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_SetNormals(swigCPtr, data);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetVisibility(IntPtr data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_SetVisibility(swigCPtr, data);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetMaterials(IntPtr data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_SetMaterials(swigCPtr, data);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetMappers(IntPtr data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_SetMappers(swigCPtr, data);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetTransparency(IntPtr data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_SetTransparency(swigCPtr, data);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetFillOrigins(IntPtr data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_SetFillOrigins(swigCPtr, data);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetFillDirections(IntPtr data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFaceData_SetFillDirections(swigCPtr, data);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

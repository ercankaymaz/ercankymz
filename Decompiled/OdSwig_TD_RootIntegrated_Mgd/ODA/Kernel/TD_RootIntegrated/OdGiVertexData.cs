using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiVertexData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiVertexData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiVertexData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiVertexData()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiVertexData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiVertexData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiVertexData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setNormals(OdGeVector3d normals)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexData_setNormals(swigCPtr, OdGeVector3d.getCPtr(normals));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOrientationFlag(OdGiOrientationType orientationType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexData_setOrientationFlag(swigCPtr, (int)orientationType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTrueColors(OdCmEntityColor colors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexData_setTrueColors(swigCPtr, OdCmEntityColor.getCPtr(colors));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMappingCoords(OdGiVertexData_MapChannel channel, OdGePoint3d coords)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexData_setMappingCoords(swigCPtr, (int)channel, OdGePoint3d.getCPtr(coords));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d normals()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexData_normals(swigCPtr);
		OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiOrientationType orientationFlag()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexData_orientationFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiOrientationType)result;
	}

	public OdCmEntityColor trueColors()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexData_trueColors(swigCPtr);
		OdCmEntityColor result = ((intPtr == IntPtr.Zero) ? null : new OdCmEntityColor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d mappingCoords(OdGiVertexData_MapChannel channel)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiVertexData_mappingCoords(swigCPtr, (int)channel);
		OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

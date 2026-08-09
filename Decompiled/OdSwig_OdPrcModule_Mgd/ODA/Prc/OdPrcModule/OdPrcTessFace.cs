using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcTessFace : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcTessFace(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcTessFace obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcTessFace()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcTessFace(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcTessFace()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcTessFace(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcOut(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcIn(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdUInt32Array sizesWire()
	{
		OdUInt32Array result = new OdUInt32Array(OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_sizesWire__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt32Array sizesTriangulated()
	{
		OdUInt32Array result = new OdUInt32Array(OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_sizesTriangulated__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcObjectIdArray lineAttributes()
	{
		OdPrcObjectIdArray result = new OdPrcObjectIdArray(OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_lineAttributes__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcArrayRgba arrayRGBA()
	{
		OdPrcArrayRgba result = new OdPrcArrayRgba(OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_arrayRGBA__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setStartWire(uint start_wire)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_setStartWire(swigCPtr, start_wire);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint startWire()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_startWire(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUsedEntitiesFlag(uint used_entities_flag)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_setUsedEntitiesFlag(swigCPtr, used_entities_flag);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint usedEntitiesFlag()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_usedEntitiesFlag(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setStartTriangulated(uint start_triangulated)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_setStartTriangulated(swigCPtr, start_triangulated);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint startTriangulated()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_startTriangulated(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNumberOfTextureCoordinateIndexes(uint number_of_texture_coordinate_indexes)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_setNumberOfTextureCoordinateIndexes(swigCPtr, number_of_texture_coordinate_indexes);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint numberOfTextureCoordinateIndexes()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_numberOfTextureCoordinateIndexes(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBehaviour(uint behaviour)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_setBehaviour(swigCPtr, behaviour);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint behaviour()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_behaviour(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHasVertexColors(bool has_vertex_colors)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_setHasVertexColors(swigCPtr, has_vertex_colors);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasVertexColors()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_hasVertexColors(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBOptimised(bool b_optimised)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_setBOptimised(swigCPtr, b_optimised);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool bOptimised()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_bOptimised(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint prcType()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcTessFace_prcType(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class BrepBuilderInitialSurface : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdBrepBuilder_EntityDirection direction
	{
		get
		{
			int result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_direction_get(swigCPtr);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdBrepBuilder_EntityDirection)result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_direction_set(swigCPtr, (int)value);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public BrepBuilderInitialLoopArray loops
	{
		get
		{
			IntPtr intPtr = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_loops_get(swigCPtr);
			BrepBuilderInitialLoopArray result = ((intPtr == IntPtr.Zero) ? null : new BrepBuilderInitialLoopArray(intPtr, cMemoryOwn: false));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_loops_set(swigCPtr, BrepBuilderInitialLoopArray.getCPtr(value));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdDbStub material
	{
		get
		{
			IntPtr intPtr = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_material_get(swigCPtr);
			OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_material_set(swigCPtr, OdDbStub.getCPtr(value));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool hasMaterialMapping
	{
		get
		{
			bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_hasMaterialMapping_get(swigCPtr);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_hasMaterialMapping_set(swigCPtr, value);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGiMapper materialMapper
	{
		get
		{
			IntPtr intPtr = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_materialMapper_get(swigCPtr);
			OdGiMapper result = ((intPtr == IntPtr.Zero) ? null : new OdGiMapper(intPtr, cMemoryOwn: false));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_materialMapper_set(swigCPtr, OdGiMapper.getCPtr(value));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool hasColor
	{
		get
		{
			bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_hasColor_get(swigCPtr);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_hasColor_set(swigCPtr, value);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdCmEntityColor color
	{
		get
		{
			IntPtr intPtr = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_color_get(swigCPtr);
			OdCmEntityColor result = ((intPtr == IntPtr.Zero) ? null : new OdCmEntityColor(intPtr, cMemoryOwn: false));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_color_set(swigCPtr, OdCmEntityColor.getCPtr(value));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public std_pair_bool_long marker
	{
		get
		{
			IntPtr intPtr = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_marker_get(swigCPtr);
			std_pair_bool_long result = ((intPtr == IntPtr.Zero) ? null : new std_pair_bool_long(intPtr, cMemoryOwn: false));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_marker_set(swigCPtr, std_pair_bool_long.getCPtr(value));
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint parentFaceIdx
	{
		get
		{
			uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_parentFaceIdx_get(swigCPtr);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_parentFaceIdx_set(swigCPtr, value);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public BrepBuilderInitialSurface(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(BrepBuilderInitialSurface obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~BrepBuilderInitialSurface()
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_BrepBuilderInitialSurface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public BrepBuilderInitialSurface()
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialSurface(), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void copyFaceExceptLoops(BrepBuilderInitialSurface other)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_copyFaceExceptLoops(swigCPtr, getCPtr(other));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSurface get_pSurf()
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_get_pSurf(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set_pSurf(OdGeSurface pSurf)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurface_set_pSurf(swigCPtr, OdGeSurface.getCPtr(pSurf));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMapper : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static OdGiMapper kIdentity
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_kIdentity_get();
			OdGiMapper result = ((intPtr == IntPtr.Zero) ? null : new OdGiMapper(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMapper(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMapper obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiMapper()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMapper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiMapper()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMapper__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMapper(OdGiMapper mapper)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMapper__SWIG_1(getCPtr(mapper)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMapper Assign(OdGiMapper mapper)
	{
		OdGiMapper result = new OdGiMapper(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_Assign(swigCPtr, getCPtr(mapper)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGiMapper mapper)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_IsEqual(swigCPtr, getCPtr(mapper));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiMapper mapper)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_IsNotEqual(swigCPtr, getCPtr(mapper));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setProjection(OdGiMapper_Projection projection)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_setProjection(swigCPtr, (int)projection);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUTiling(OdGiMapper_Tiling tiling)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_setUTiling(swigCPtr, (int)tiling);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setVTiling(OdGiMapper_Tiling tiling)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_setVTiling(swigCPtr, (int)tiling);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAutoTransform(OdGiMapper_AutoTransform autoTransform)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_setAutoTransform(swigCPtr, (int)autoTransform);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix3d transform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_transform__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMapper_Projection projection()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_projection(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMapper_Projection)result;
	}

	public OdGiMapper_Tiling uTiling()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_uTiling(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMapper_Tiling)result;
	}

	public OdGiMapper_Tiling vTiling()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_vTiling(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMapper_Tiling)result;
	}

	public OdGiMapper_AutoTransform autoTransform()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_autoTransform(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMapper_AutoTransform)result;
	}

	public void setTransform(OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapper_setTransform(swigCPtr, OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

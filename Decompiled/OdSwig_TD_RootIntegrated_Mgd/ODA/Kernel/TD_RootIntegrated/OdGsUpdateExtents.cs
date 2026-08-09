using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsUpdateExtents : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static OdGsUpdateExtents kInvalid
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_kInvalid_get();
			OdGsUpdateExtents result = ((intPtr == IntPtr.Zero) ? null : new OdGsUpdateExtents(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsUpdateExtents(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsUpdateExtents obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsUpdateExtents()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsUpdateExtents(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsUpdateExtents()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsUpdateExtents__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsUpdateExtents(OdGeExtents3d extents, LineWeight lw)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsUpdateExtents__SWIG_1(OdGeExtents3d.getCPtr(extents), (int)lw), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsUpdateExtents(OdGeExtents3d extents)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsUpdateExtents__SWIG_2(OdGeExtents3d.getCPtr(extents)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeExtents3d getExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_getExtents(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents3d accessExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_accessExtents(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setExtents(OdGeExtents3d extents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_setExtents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetExtents()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_resetExtents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addExtents(OdGeExtents3d extents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_addExtents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasLineweight()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_hasLineweight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public LineWeight getLineweight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_getLineweight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public void setLineweight(LineWeight lw)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_setLineweight(swigCPtr, (int)lw);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetLineweight()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_resetLineweight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addLineweight(LineWeight lw)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_addLineweight(swigCPtr, (int)lw);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void get(OdGeExtents3d extents, out LineWeight lw)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_get(swigCPtr, OdGeExtents3d.getCPtr(extents), out lw);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdGeExtents3d extents, LineWeight lw)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_set(swigCPtr, OdGeExtents3d.getCPtr(extents), (int)lw);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void reset()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_reset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void add(OdGeExtents3d extents, LineWeight lw)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_add__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(extents), (int)lw);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void add(OdGsUpdateExtents extents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_add__SWIG_1(swigCPtr, getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isValid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_isValid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public LineWeight AccessLineweight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateExtents_AccessLineweight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}
}

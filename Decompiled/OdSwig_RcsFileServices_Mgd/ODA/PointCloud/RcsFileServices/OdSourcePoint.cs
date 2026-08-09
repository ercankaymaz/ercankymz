using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdSourcePoint : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdGePoint3d m_coord
	{
		get
		{
			IntPtr intPtr = RcsFileServices_GlobalsPINVOKE.OdSourcePoint_m_coord_get(swigCPtr);
			OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			RcsFileServices_GlobalsPINVOKE.OdSourcePoint_m_coord_set(swigCPtr, OdGePoint3d.getCPtr(value));
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_color
	{
		get
		{
			uint result = RcsFileServices_GlobalsPINVOKE.OdSourcePoint_m_color_get(swigCPtr);
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			RcsFileServices_GlobalsPINVOKE.OdSourcePoint_m_color_set(swigCPtr, value);
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public float m_intensity
	{
		get
		{
			float result = RcsFileServices_GlobalsPINVOKE.OdSourcePoint_m_intensity_get(swigCPtr);
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			RcsFileServices_GlobalsPINVOKE.OdSourcePoint_m_intensity_set(swigCPtr, value);
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSourcePoint(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSourcePoint obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdSourcePoint()
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
					RcsFileServices_GlobalsPINVOKE.delete_OdSourcePoint(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdSourcePoint()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdSourcePoint(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdSourcePoint_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

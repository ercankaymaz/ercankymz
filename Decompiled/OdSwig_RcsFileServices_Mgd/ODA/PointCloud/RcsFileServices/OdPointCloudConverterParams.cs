using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.PointCloud.RcsFileServices;

public class OdPointCloudConverterParams : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public float m_intensityBottom
	{
		get
		{
			float result = RcsFileServices_GlobalsPINVOKE.OdPointCloudConverterParams_m_intensityBottom_get(swigCPtr);
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			RcsFileServices_GlobalsPINVOKE.OdPointCloudConverterParams_m_intensityBottom_set(swigCPtr, value);
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public float m_intensityUpper
	{
		get
		{
			float result = RcsFileServices_GlobalsPINVOKE.OdPointCloudConverterParams_m_intensityUpper_get(swigCPtr);
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			RcsFileServices_GlobalsPINVOKE.OdPointCloudConverterParams_m_intensityUpper_set(swigCPtr, value);
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool m_isTerrestrial
	{
		get
		{
			bool result = RcsFileServices_GlobalsPINVOKE.OdPointCloudConverterParams_m_isTerrestrial_get(swigCPtr);
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			RcsFileServices_GlobalsPINVOKE.OdPointCloudConverterParams_m_isTerrestrial_set(swigCPtr, value);
			if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPointCloudConverterParams(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPointCloudConverterParams obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPointCloudConverterParams()
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
					RcsFileServices_GlobalsPINVOKE.delete_OdPointCloudConverterParams(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPointCloudConverterParams()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdPointCloudConverterParams(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudConverterParams_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

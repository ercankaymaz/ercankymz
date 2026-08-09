using System;
using System.Runtime.InteropServices;

namespace ODA.Drawings.PlotSettingsValidator;

public class tm : IDisposable
{
	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public int tm_sec
	{
		get
		{
			int result = PlotSettingsValidator_GlobalsPINVOKE.tm_tm_sec_get(swigCPtr);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			PlotSettingsValidator_GlobalsPINVOKE.tm_tm_sec_set(swigCPtr, value);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int tm_min
	{
		get
		{
			int result = PlotSettingsValidator_GlobalsPINVOKE.tm_tm_min_get(swigCPtr);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			PlotSettingsValidator_GlobalsPINVOKE.tm_tm_min_set(swigCPtr, value);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int tm_hour
	{
		get
		{
			int result = PlotSettingsValidator_GlobalsPINVOKE.tm_tm_hour_get(swigCPtr);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			PlotSettingsValidator_GlobalsPINVOKE.tm_tm_hour_set(swigCPtr, value);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int tm_mday
	{
		get
		{
			int result = PlotSettingsValidator_GlobalsPINVOKE.tm_tm_mday_get(swigCPtr);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			PlotSettingsValidator_GlobalsPINVOKE.tm_tm_mday_set(swigCPtr, value);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int tm_mon
	{
		get
		{
			int result = PlotSettingsValidator_GlobalsPINVOKE.tm_tm_mon_get(swigCPtr);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			PlotSettingsValidator_GlobalsPINVOKE.tm_tm_mon_set(swigCPtr, value);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int tm_year
	{
		get
		{
			int result = PlotSettingsValidator_GlobalsPINVOKE.tm_tm_year_get(swigCPtr);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			PlotSettingsValidator_GlobalsPINVOKE.tm_tm_year_set(swigCPtr, value);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int tm_wday
	{
		get
		{
			int result = PlotSettingsValidator_GlobalsPINVOKE.tm_tm_wday_get(swigCPtr);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			PlotSettingsValidator_GlobalsPINVOKE.tm_tm_wday_set(swigCPtr, value);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int tm_yday
	{
		get
		{
			int result = PlotSettingsValidator_GlobalsPINVOKE.tm_tm_yday_get(swigCPtr);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			PlotSettingsValidator_GlobalsPINVOKE.tm_tm_yday_set(swigCPtr, value);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int tm_isdst
	{
		get
		{
			int result = PlotSettingsValidator_GlobalsPINVOKE.tm_tm_isdst_get(swigCPtr);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			PlotSettingsValidator_GlobalsPINVOKE.tm_tm_isdst_set(swigCPtr, value);
			if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	internal tm(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(tm obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~tm()
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
					PlotSettingsValidator_GlobalsPINVOKE.delete_tm(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public tm()
		: this(PlotSettingsValidator_GlobalsPINVOKE.new_tm(), cMemoryOwn: true)
	{
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

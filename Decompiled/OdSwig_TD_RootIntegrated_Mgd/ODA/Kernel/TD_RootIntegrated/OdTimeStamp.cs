using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdTimeStamp : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdTimeStamp(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdTimeStamp obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdTimeStamp()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdTimeStamp(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdTimeStamp()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdTimeStamp__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdTimeStamp(OdTimeStamp_InitialValue init)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdTimeStamp__SWIG_1((int)init), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDate(out short month, out short day, out short year)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_getDate(swigCPtr, out month, out day, out year);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult setDate(short month, short day, short year)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setDate(swigCPtr, month, day, year);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public short month()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_month(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMonth(short month)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setMonth(swigCPtr, month);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public short day()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_day(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDay(short day)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setDay(swigCPtr, day);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public short year()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_year(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setYear(short year)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setYear(swigCPtr, year);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTime(out short hour, out short minute, out short second, out short millisecond)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_getTime(swigCPtr, out hour, out minute, out second, out millisecond);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTime(short hour, short minute, short second, short millisecond)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setTime(swigCPtr, hour, minute, second, millisecond);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public short hour()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_hour(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHour(short hour)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setHour(swigCPtr, hour);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public short minute()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_minute(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMinute(short minute)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setMinute(swigCPtr, minute);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public short second()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_second(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSecond(short second)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setSecond(swigCPtr, second);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public short millisecond()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_millisecond(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMillisecond(short millisecond)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setMillisecond(swigCPtr, millisecond);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setToZero()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setToZero(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLocalTime()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_getLocalTime(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getUniversalTime()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_getUniversalTime(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void localToUniversal()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_localToUniversal(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void universalToLocal()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_universalToLocal(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint julianDay()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_julianDay(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setJulianDay(uint julianDay)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setJulianDay(swigCPtr, julianDay);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint msecsPastMidnight()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_msecsPastMidnight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMsecsPastMidnight(uint msecsPastMidnight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setMsecsPastMidnight(swigCPtr, msecsPastMidnight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setJulianDate(uint julianDay, uint msecsPastMidnight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setJulianDate(swigCPtr, julianDay, msecsPastMidnight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double julianFraction()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_julianFraction(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setJulianFraction(double julianFraction)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setJulianFraction(swigCPtr, julianFraction);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdTimeStamp tStamp)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_IsEqual(swigCPtr, getCPtr(tStamp));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdTimeStamp tStamp)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_IsNotEqual(swigCPtr, getCPtr(tStamp));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdTimeStamp Add(OdTimeStamp tStamp)
	{
		OdTimeStamp result = new OdTimeStamp(TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_Add__SWIG_0(swigCPtr, getCPtr(tStamp)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdTimeStamp Sub(OdTimeStamp tStamp)
	{
		OdTimeStamp result = new OdTimeStamp(TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_Sub__SWIG_0(swigCPtr, getCPtr(tStamp)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdTimeStamp add(OdTimeStamp tStamp)
	{
		OdTimeStamp result = new OdTimeStamp(TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_add(swigCPtr, getCPtr(tStamp)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdTimeStamp subtract(OdTimeStamp tStamp)
	{
		OdTimeStamp result = new OdTimeStamp(TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_subtract(swigCPtr, getCPtr(tStamp)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void ctime(ref string timeString)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(timeString);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_ctime(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				timeString = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void strftime(string format, ref string timeString)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(timeString);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_strftime(swigCPtr, format, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				timeString = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public long packedValue()
	{
		long result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_packedValue(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPackedValue(long t)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_setPackedValue(swigCPtr, t);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public short weekday()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdTimeStamp_weekday(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class odiv_DWGSynergyOccurrenceInfo : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public odiv_DWGBodyRecordArray records
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGSynergyOccurrenceInfo_records_get(swigCPtr);
			odiv_DWGBodyRecordArray result = ((intPtr == IntPtr.Zero) ? null : new odiv_DWGBodyRecordArray(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGSynergyOccurrenceInfo_records_set(swigCPtr, odiv_DWGBodyRecordArray.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public odiv_DWGBodyOccurrenceArray occurrences
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGSynergyOccurrenceInfo_occurrences_get(swigCPtr);
			odiv_DWGBodyOccurrenceArray result = ((intPtr == IntPtr.Zero) ? null : new odiv_DWGBodyOccurrenceArray(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGSynergyOccurrenceInfo_occurrences_set(swigCPtr, odiv_DWGBodyOccurrenceArray.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public MeasurementValue measurement
	{
		get
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGSynergyOccurrenceInfo_measurement_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (MeasurementValue)result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGSynergyOccurrenceInfo_measurement_set(swigCPtr, (int)value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public odiv_DWGSynergyOccurrenceInfo(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(odiv_DWGSynergyOccurrenceInfo obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~odiv_DWGSynergyOccurrenceInfo()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_odiv_DWGSynergyOccurrenceInfo(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public odiv_DWGSynergyOccurrenceInfo()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_odiv_DWGSynergyOccurrenceInfo(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

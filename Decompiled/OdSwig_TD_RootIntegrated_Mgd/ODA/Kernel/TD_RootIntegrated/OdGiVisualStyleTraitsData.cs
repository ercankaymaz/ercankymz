using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiVisualStyleTraitsData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiVisualStyleTraitsData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiVisualStyleTraitsData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiVisualStyleTraitsData()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiVisualStyleTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiVisualStyleTraitsData(bool bPhysicalCopy)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiVisualStyleTraitsData__SWIG_0(bPhysicalCopy), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiVisualStyleTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiVisualStyleTraitsData__SWIG_1(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOdGiVisualStyle(OdGiVisualStyle visualStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleTraitsData_setOdGiVisualStyle(swigCPtr, OdGiVisualStyle.getCPtr(visualStyle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiVisualStyle odgiVisualStyle()
	{
		OdGiVisualStyle rXObject = Helpers.GetRXObject<OdGiVisualStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleTraitsData_odgiVisualStyle(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isOdGiVisualStyleSet()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleTraitsData_isOdGiVisualStyleSet(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void resetOdGiVisualStyle()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleTraitsData_resetOdGiVisualStyle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdGiVisualStyleTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleTraitsData_IsEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiVisualStyleTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleTraitsData_IsNotEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiVisualStyleTraitsData Assign(OdGiVisualStyleTraitsData data2)
	{
		OdGiVisualStyleTraitsData result = new OdGiVisualStyleTraitsData(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleTraitsData_Assign(swigCPtr, getCPtr(data2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

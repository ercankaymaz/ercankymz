using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSolidBackgroundTraitsData : OdGiBackgroundTraitsData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSolidBackgroundTraitsData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiSolidBackgroundTraitsData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSolidBackgroundTraitsData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSolidBackgroundTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiSolidBackgroundTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSolidBackgroundTraitsData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor color()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiSolidBackgroundTraitsData_color(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSolidBackgroundTraitsData_setColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdGiSolidBackgroundTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSolidBackgroundTraitsData_IsEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiSolidBackgroundTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSolidBackgroundTraitsData_IsNotEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

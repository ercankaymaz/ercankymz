using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class Temp1OdGiDummyCommonDraw : OdGiWorldDraw
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public Temp1OdGiDummyCommonDraw(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.Temp1OdGiDummyCommonDraw_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(Temp1OdGiDummyCommonDraw obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.deletePD_Temp1OdGiDummyCommonDraw(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new virtual OdGiRegenType regenType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.Temp1OdGiDummyCommonDraw_regenType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRegenType)result;
	}

	public new virtual bool regenAbort()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.Temp1OdGiDummyCommonDraw_regenAbort(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isDragging()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.Temp1OdGiDummyCommonDraw_isDragging(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint numberOfIsolines()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.Temp1OdGiDummyCommonDraw_numberOfIsolines(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual double deviation(OdGiDeviationType t, OdGePoint3d p)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.Temp1OdGiDummyCommonDraw_deviation(swigCPtr, (int)t, OdGePoint3d.getCPtr(p));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

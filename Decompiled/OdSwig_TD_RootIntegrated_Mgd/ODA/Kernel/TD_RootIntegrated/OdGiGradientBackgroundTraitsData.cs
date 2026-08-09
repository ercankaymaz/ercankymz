using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiGradientBackgroundTraitsData : OdGiBackgroundTraitsData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiGradientBackgroundTraitsData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiGradientBackgroundTraitsData obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiGradientBackgroundTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiGradientBackgroundTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiGradientBackgroundTraitsData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor colorTop()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_colorTop(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColorTop(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_setColorTop(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor colorMiddle()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_colorMiddle(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColorMiddle(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_setColorMiddle(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor colorBottom()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_colorBottom(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColorBottom(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_setColorBottom(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double horizon()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_horizon(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double height()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_height(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double rotation()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_rotation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHorizon(double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_setHorizon(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setHeight(double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_setHeight(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRotation(double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_setRotation(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdGiGradientBackgroundTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_IsEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiGradientBackgroundTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraitsData_IsNotEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

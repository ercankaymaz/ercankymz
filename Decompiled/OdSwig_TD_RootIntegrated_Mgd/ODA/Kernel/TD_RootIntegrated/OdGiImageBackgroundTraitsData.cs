using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiImageBackgroundTraitsData : OdGiBackgroundTraitsData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiImageBackgroundTraitsData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiImageBackgroundTraitsData obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiImageBackgroundTraitsData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiImageBackgroundTraitsData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiImageBackgroundTraitsData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string imageFilename()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_imageFilename(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setImageFilename(string filename)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_setImageFilename(swigCPtr, filename);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool fitToScreen()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_fitToScreen(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool maintainAspectRatio()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_maintainAspectRatio(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool useTiling()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_useTiling(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFitToScreen(bool flag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_setFitToScreen(swigCPtr, flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMaintainAspectRatio(bool flag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_setMaintainAspectRatio(swigCPtr, flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUseTiling(bool flag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_setUseTiling(swigCPtr, flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOffset(double x, double y)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_setOffset(swigCPtr, x, y);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double xOffset()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_xOffset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double yOffset()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_yOffset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setXOffset(double xOffset)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_setXOffset(swigCPtr, xOffset);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setYOffset(double yOffset)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_setYOffset(swigCPtr, yOffset);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setScale(double x, double y)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_setScale(swigCPtr, x, y);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double xScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_xScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double yScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_yScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setXScale(double xScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_setXScale(swigCPtr, xScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setYScale(double yScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_setYScale(swigCPtr, yScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdGiImageBackgroundTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_IsEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiImageBackgroundTraitsData data2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBackgroundTraitsData_IsNotEqual(swigCPtr, getCPtr(data2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsPageParams : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsPageParams(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsPageParams obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsPageParams()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsPageParams(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsPageParams()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsPageParams__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsPageParams(double dPaperWidth, double dPaperHeight)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsPageParams__SWIG_1(dPaperWidth, dPaperHeight), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsPageParams(OdGsPageParams data)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsPageParams__SWIG_2(getCPtr(data)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsPageParams Assign(OdGsPageParams from)
	{
		OdGsPageParams result = new OdGsPageParams(TD_RootIntegrated_GlobalsPINVOKE.OdGsPageParams_Assign(swigCPtr, getCPtr(from)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getPaperWidth()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsPageParams_getPaperWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getPaperHeight()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsPageParams_getPaperHeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getLeftMargin()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsPageParams_getLeftMargin(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getRightMargin()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsPageParams_getRightMargin(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getTopMargin()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsPageParams_getTopMargin(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getBottomMargin()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsPageParams_getBottomMargin(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set(double dPaperWidth, double dPaperHeight, double dLeftMargin, double dRightMargin, double dTopMargin, double dBottomMargin)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsPageParams_set__SWIG_0(swigCPtr, dPaperWidth, dPaperHeight, dLeftMargin, dRightMargin, dTopMargin, dBottomMargin);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(double dPaperWidth, double dPaperHeight, double dLeftMargin, double dRightMargin, double dTopMargin)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsPageParams_set__SWIG_1(swigCPtr, dPaperWidth, dPaperHeight, dLeftMargin, dRightMargin, dTopMargin);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(double dPaperWidth, double dPaperHeight, double dLeftMargin, double dRightMargin)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsPageParams_set__SWIG_2(swigCPtr, dPaperWidth, dPaperHeight, dLeftMargin, dRightMargin);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(double dPaperWidth, double dPaperHeight, double dLeftMargin)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsPageParams_set__SWIG_3(swigCPtr, dPaperWidth, dPaperHeight, dLeftMargin);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(double dPaperWidth, double dPaperHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsPageParams_set__SWIG_4(swigCPtr, dPaperWidth, dPaperHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void scale(double dScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsPageParams_scale(swigCPtr, dScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

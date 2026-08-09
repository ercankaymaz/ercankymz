using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdPsPlotStyleData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPsPlotStyleData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPsPlotStyleData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPsPlotStyleData()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdPsPlotStyleData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPsPlotStyleData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdPsPlotStyleData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdPsPlotStyleData other)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_IsEqual(swigCPtr, getCPtr(other));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdPsPlotStyleData other)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_IsNotEqual(swigCPtr, getCPtr(other));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmEntityColor color()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_color(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public short colorPolicy()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_colorPolicy(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public short physicalPenNumber()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_physicalPenNumber(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public short virtualPenNumber()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_virtualPenNumber(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int screening()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_screening(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double linePatternSize()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_linePatternSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPs_LineType linetype()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_linetype(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdPs_LineType)result;
	}

	public bool isAdaptiveLinetype()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_isAdaptiveLinetype(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isGrayScaleOn()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_isGrayScaleOn(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDitherOn()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_isDitherOn(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double lineweight()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_lineweight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPs_FillStyle fillStyle()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_fillStyle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdPs_FillStyle)result;
	}

	public OdPs_LineEndStyle endStyle()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_endStyle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdPs_LineEndStyle)result;
	}

	public OdPs_LineJoinStyle joinStyle()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_joinStyle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdPs_LineJoinStyle)result;
	}

	public void setColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setColorPolicy(short colorPolicy)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setColorPolicy(swigCPtr, colorPolicy);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPhysicalPenNumber(short physicalPenNumber)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setPhysicalPenNumber(swigCPtr, physicalPenNumber);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setVirtualPenNumber(short virtualPenNumber)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setVirtualPenNumber(swigCPtr, virtualPenNumber);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setScreening(int screening)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setScreening(swigCPtr, screening);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLinePatternSize(double linePatternSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setLinePatternSize(swigCPtr, linePatternSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLinetype(OdPs_LineType linetype)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setLinetype(swigCPtr, (int)linetype);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAdaptiveLinetype(bool adaptiveLinetype)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setAdaptiveLinetype(swigCPtr, adaptiveLinetype);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGrayScaleOn(bool grayScaleOn)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setGrayScaleOn(swigCPtr, grayScaleOn);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDitherOn(bool ditherOn)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setDitherOn(swigCPtr, ditherOn);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLineweight(double lineweight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setLineweight(swigCPtr, lineweight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFillStyle(OdPs_FillStyle fillStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setFillStyle(swigCPtr, (int)fillStyle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setEndStyle(OdPs_LineEndStyle lineEndStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setEndStyle(swigCPtr, (int)lineEndStyle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setJoinStyle(OdPs_LineJoinStyle lineJoinStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleData_setJoinStyle(swigCPtr, (int)lineJoinStyle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

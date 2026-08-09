using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiLineweightOverride : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiLineweightOverride(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiLineweightOverride obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiLineweightOverride()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiLineweightOverride(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiLineweightOverride()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiLineweightOverride(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setScaleOverride(double dLwdScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_setScaleOverride(swigCPtr, dLwdScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetScaleOverride()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_resetScaleOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasScaleOverride()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_hasScaleOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double scaleOverride()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_scaleOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPixelScale(double dPixScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_setPixelScale(swigCPtr, dPixScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double pixelScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_pixelScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setStyleOverride(OdPs_LineEndStyle lineCapStyle, OdPs_LineJoinStyle lineJoinStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_setStyleOverride(swigCPtr, (int)lineCapStyle, (int)lineJoinStyle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetStyleOverride()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_resetStyleOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasStyleOverride()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_hasStyleOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPs_LineEndStyle endStyleOverride()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_endStyleOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdPs_LineEndStyle)result;
	}

	public OdPs_LineJoinStyle joinStyleOverride()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_joinStyleOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdPs_LineJoinStyle)result;
	}

	public bool hasOverrides()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_hasOverrides(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGiLineweightOverride lwdO2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_IsEqual(swigCPtr, getCPtr(lwdO2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiLineweightOverride lwdO2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLineweightOverride_IsNotEqual(swigCPtr, getCPtr(lwdO2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

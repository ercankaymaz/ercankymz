using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDgLinetypeModifiers : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public uint m_uFlags
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_m_uFlags_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_m_uFlags_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double m_dDashScale
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_m_dDashScale_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_m_dDashScale_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double m_dGapScale
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_m_dGapScale_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_m_dGapScale_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double m_dWidth
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_m_dWidth_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_m_dWidth_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double m_dEndWidth
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_m_dEndWidth_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_m_dEndWidth_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double m_dPhase
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_m_dPhase_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_m_dPhase_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDgLinetypeModifiers(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDgLinetypeModifiers obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiDgLinetypeModifiers()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDgLinetypeModifiers(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiDgLinetypeModifiers()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDgLinetypeModifiers(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getDashScaleFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getDashScaleFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDashScaleFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setDashScaleFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double getDashScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getDashScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDashScale(double dScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setDashScale(swigCPtr, dScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getGapScaleFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getGapScaleFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGapScaleFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setGapScaleFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double getGapScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getGapScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGapScale(double dScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setGapScale(swigCPtr, dScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getWidthFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getWidthFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setWidthFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setWidthFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double getWidth()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setWidth(double dWidth)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setWidth(swigCPtr, dWidth);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getEndWidthFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getEndWidthFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEndWidthFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setEndWidthFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double getEndWidth()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getEndWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEndWidth(double dEndWidth)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setEndWidth(swigCPtr, dEndWidth);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDgLinetypeModifiers_WidthMode getWidthMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getWidthMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiDgLinetypeModifiers_WidthMode)result;
	}

	public void setWidthMode(OdGiDgLinetypeModifiers_WidthMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setWidthMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getShiftFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getShiftFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setShiftFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setShiftFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getFractionShiftFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getFractionShiftFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFractionShiftFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setFractionShiftFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getCenteredShiftFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getCenteredShiftFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCenteredShiftFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setCenteredShiftFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double getPhase()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getPhase(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPhase(double dPhase)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setPhase(swigCPtr, dPhase);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDgLinetypeModifiers_ShiftMode getShiftMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getShiftMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiDgLinetypeModifiers_ShiftMode)result;
	}

	public void setShiftMode(OdGiDgLinetypeModifiers_ShiftMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setShiftMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getTrueWidthFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getTrueWidthFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTrueWidthFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setTrueWidthFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getBreakAtCornersFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getBreakAtCornersFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBreakAtCornersFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setBreakAtCornersFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getRunThroughCornersFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getRunThroughCornersFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRunThroughCornersFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setRunThroughCornersFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDgLinetypeModifiers_CornersMode getCornersMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_getCornersMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiDgLinetypeModifiers_CornersMode)result;
	}

	public void setCornersMode(OdGiDgLinetypeModifiers_CornersMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_setCornersMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdGiDgLinetypeModifiers lsMod)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_IsEqual(swigCPtr, getCPtr(lsMod));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiDgLinetypeModifiers lsMod)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeModifiers_IsNotEqual(swigCPtr, getCPtr(lsMod));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

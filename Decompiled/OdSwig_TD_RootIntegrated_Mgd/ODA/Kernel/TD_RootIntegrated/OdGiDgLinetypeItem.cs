using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDgLinetypeItem : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public uint m_uFlags
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_m_uFlags_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_m_uFlags_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double m_dLength
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_m_dLength_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_m_dLength_set(swigCPtr, value);
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
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_m_dPhase_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_m_dPhase_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_nMaxIterations
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_m_nMaxIterations_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_m_nMaxIterations_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double m_dOffset
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_m_dOffset_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_m_dOffset_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGiDgLinetypeDashArray m_dashes
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_m_dashes_get(swigCPtr);
			OdGiDgLinetypeDashArray result = ((intPtr == IntPtr.Zero) ? null : new OdGiDgLinetypeDashArray(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_m_dashes_set(swigCPtr, OdGiDgLinetypeDashArray.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDgLinetypeItem(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDgLinetypeItem obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiDgLinetypeItem()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDgLinetypeItem(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiDgLinetypeItem()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDgLinetypeItem(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double getLength()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_getLength(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLength(double dLen)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_setLength(swigCPtr, dLen);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double getPhase()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_getPhase(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPhase(double dPhase)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_setPhase(swigCPtr, dPhase);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getAutoPhaseFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_getAutoPhaseFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAutoPhaseFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_setAutoPhaseFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getUseIterationLimitFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_getUseIterationLimitFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUseIterationLimitFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_setUseIterationLimitFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getSingleSegmentModeFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_getSingleSegmentModeFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSingleSegmentModeFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_setSingleSegmentModeFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getCenterStretchPhaseModeFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_getCenterStretchPhaseModeFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCenterStretchPhaseModeFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_setCenterStretchPhaseModeFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getStandardLinetypeFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_getStandardLinetypeFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setStandardLinetypeFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_setStandardLinetypeFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getComputeStandardScaleFlag()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_getComputeStandardScaleFlag(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setComputeStandardScaleFlag(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_setComputeStandardScaleFlag(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint getMaxIterations()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_getMaxIterations(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMaxIterations(uint iMaxNum)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_setMaxIterations(swigCPtr, iMaxNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double getYOffset()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_getYOffset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setYOffset(double dYOffset)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_setYOffset(swigCPtr, dYOffset);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint numDashes()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_numDashes(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNumDashes(uint count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_setNumDashes(swigCPtr, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void dashAt(uint index, OdGiDgLinetypeDash dash)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_dashAt__SWIG_0(swigCPtr, index, OdGiDgLinetypeDash.getCPtr(dash));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDgLinetypeDash dashAt(uint index)
	{
		OdGiDgLinetypeDash result = new OdGiDgLinetypeDash(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_dashAt__SWIG_1(swigCPtr, index), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDashAt(uint index, OdGiDgLinetypeDash dash)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_setDashAt(swigCPtr, index, OdGiDgLinetypeDash.getCPtr(dash));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void dashes(OdGiDgLinetypeDashArray dashes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_dashes(swigCPtr, OdGiDgLinetypeDashArray.getCPtr(dashes));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDashes(OdGiDgLinetypeDashArray dashes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeItem_setDashes(swigCPtr, OdGiDgLinetypeDashArray.getCPtr(dashes));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

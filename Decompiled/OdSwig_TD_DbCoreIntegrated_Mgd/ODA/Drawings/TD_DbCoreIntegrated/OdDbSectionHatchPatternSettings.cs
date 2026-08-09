using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbSectionHatchPatternSettings : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdDbHLRCurveProperties hatchCurveProperties
	{
		get
		{
			IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHatchPatternSettings_hatchCurveProperties_get(swigCPtr);
			OdDbHLRCurveProperties result = ((intPtr == IntPtr.Zero) ? null : new OdDbHLRCurveProperties(intPtr, cMemoryOwn: false));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHatchPatternSettings_hatchCurveProperties_set(swigCPtr, OdDbHLRCurveProperties.getCPtr(value));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public string strPatternName
	{
		get
		{
			string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHatchPatternSettings_strPatternName_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHatchPatternSettings_strPatternName_set(swigCPtr, value);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdDbHatch_HatchPatternType patternType
	{
		get
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHatchPatternSettings_patternType_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdDbHatch_HatchPatternType)result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHatchPatternSettings_patternType_set(swigCPtr, (int)value);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdHatchPattern userDefinedPattern
	{
		get
		{
			OdHatchPattern result = new OdHatchPattern(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHatchPatternSettings_userDefinedPattern_get(swigCPtr), cMemoryOwn: false);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHatchPatternSettings_userDefinedPattern_set(swigCPtr, OdHatchPattern.getCPtr(value).Handle);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double dPatternAngle
	{
		get
		{
			double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHatchPatternSettings_dPatternAngle_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHatchPatternSettings_dPatternAngle_set(swigCPtr, value);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double dPatternScale
	{
		get
		{
			double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHatchPatternSettings_dPatternScale_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHatchPatternSettings_dPatternScale_set(swigCPtr, value);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbSectionHatchPatternSettings(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbSectionHatchPatternSettings obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbSectionHatchPatternSettings()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbSectionHatchPatternSettings(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbSectionHatchPatternSettings()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbSectionHatchPatternSettings(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

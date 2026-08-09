using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbLoftOptions : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbLoftOptions(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbLoftOptions obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbLoftOptions()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbLoftOptions(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbLoftOptions()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbLoftOptions__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbLoftOptions(OdDbLoftOptions src)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbLoftOptions__SWIG_1(getCPtr(src)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbLoftOptions Assign(OdDbLoftOptions rhs)
	{
		OdDbLoftOptions result = new OdDbLoftOptions(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_Assign(swigCPtr, getCPtr(rhs)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdDbLoftOptions opt)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_IsEqual(swigCPtr, getCPtr(opt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double draftStart()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_draftStart(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDraftStart(double angle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setDraftStart(swigCPtr, angle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double draftEnd()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_draftEnd(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDraftEnd(double angle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setDraftEnd(swigCPtr, angle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double draftStartMag()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_draftStartMag(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDraftStartMag(double startMag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setDraftStartMag(swigCPtr, startMag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double draftEndMag()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_draftEndMag(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDraftEndMag(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setDraftEndMag(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool arcLengthParam()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_arcLengthParam(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setArcLengthParam(bool alParam)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setArcLengthParam(swigCPtr, alParam);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool noTwist()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_noTwist(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNoTwist(bool noTwist)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setNoTwist(swigCPtr, noTwist);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool alignDirection()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_alignDirection(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAlignDirection(bool alignDir)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setAlignDirection(swigCPtr, alignDir);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool simplify()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_simplify(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSimplify(bool simplify)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setSimplify(swigCPtr, simplify);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool periodic()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_periodic(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPeriodic(bool periodic)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setPeriodic(swigCPtr, periodic);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool closed()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_closed(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setClosed(bool closed)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setClosed(swigCPtr, closed);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool ruled()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_ruled(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRuled(bool ruled)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setRuled(swigCPtr, ruled);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool virtualGuide()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_virtualGuide(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVirtualGuide(bool virtGuide)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setVirtualGuide(swigCPtr, virtGuide);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbLoftOptions_NormalOption normal()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_normal(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbLoftOptions_NormalOption)result;
	}

	public void setNormal(OdDbLoftOptions_NormalOption option)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setNormal(swigCPtr, (int)option);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult setOptionsFromSysvars(OdDbDatabase pDb)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setOptionsFromSysvars(swigCPtr, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setSysvarsFromOptions(ref OdDbDatabase pDb)
	{
		IntPtr jarg = ((pDb == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(pDb).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_setSysvarsFromOptions(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pDb = null;
			}
			if (jarg != intPtr)
			{
				pDb = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdResult checkOptions(bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_checkOptions__SWIG_0(swigCPtr, displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkOptions()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_checkOptions__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkLoftCurves(OdDbEntityPtrArray crossSectionCurves, OdDbEntityPtrArray guideCurves, OdDbEntity pPathCurve, out bool allOpen, out bool allClosed, out bool allPlanar, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_checkLoftCurves__SWIG_0(swigCPtr, OdDbEntityPtrArray.getCPtr(crossSectionCurves), OdDbEntityPtrArray.getCPtr(guideCurves), OdDbEntity.getCPtr(pPathCurve), out allOpen, out allClosed, out allPlanar, displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkLoftCurves(OdDbEntityPtrArray crossSectionCurves, OdDbEntityPtrArray guideCurves, OdDbEntity pPathCurve, out bool allOpen, out bool allClosed, out bool allPlanar)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_checkLoftCurves__SWIG_1(swigCPtr, OdDbEntityPtrArray.getCPtr(crossSectionCurves), OdDbEntityPtrArray.getCPtr(guideCurves), OdDbEntity.getCPtr(pPathCurve), out allOpen, out allClosed, out allPlanar);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkCrossSectionCurves(OdDbEntityPtrArray crossSectionCurves, out bool allOpen, out bool allClosed, out bool allPlanar, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_checkCrossSectionCurves__SWIG_0(swigCPtr, OdDbEntityPtrArray.getCPtr(crossSectionCurves), out allOpen, out allClosed, out allPlanar, displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkCrossSectionCurves(OdDbEntityPtrArray crossSectionCurves, out bool allOpen, out bool allClosed, out bool allPlanar)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_checkCrossSectionCurves__SWIG_1(swigCPtr, OdDbEntityPtrArray.getCPtr(crossSectionCurves), out allOpen, out allClosed, out allPlanar);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkGuideCurves(OdDbEntityPtrArray guideCurves, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_checkGuideCurves__SWIG_0(swigCPtr, OdDbEntityPtrArray.getCPtr(guideCurves), displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkGuideCurves(OdDbEntityPtrArray guideCurves)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_checkGuideCurves__SWIG_1(swigCPtr, OdDbEntityPtrArray.getCPtr(guideCurves));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkPathCurve(OdDbEntity pPathCurve, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_checkPathCurve__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pPathCurve), displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkPathCurve(OdDbEntity pPathCurve)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLoftOptions_checkPathCurve__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pPathCurve));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}
}

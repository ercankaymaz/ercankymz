using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbSweepOptions : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbSweepOptions(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbSweepOptions obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbSweepOptions()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbSweepOptions(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbSweepOptions()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbSweepOptions__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbSweepOptions(OdDbSweepOptions src)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbSweepOptions__SWIG_1(getCPtr(src)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbSweepOptions Assign(OdDbSweepOptions src)
	{
		OdDbSweepOptions result = new OdDbSweepOptions(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_Assign(swigCPtr, getCPtr(src)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdDbSweepOptions opt)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_IsEqual(swigCPtr, getCPtr(opt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double draftAngle()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_draftAngle(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDraftAngle(double ang)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setDraftAngle(swigCPtr, ang);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double startDraftDist()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_startDraftDist(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setStartDraftDist(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setStartDraftDist(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double endDraftDist()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_endDraftDist(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEndDraftDist(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setEndDraftDist(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double twistAngle()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_twistAngle(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTwistAngle(double ang)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setTwistAngle(swigCPtr, ang);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double scaleFactor()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_scaleFactor(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setScaleFactor(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setScaleFactor(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double alignAngle()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_alignAngle(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAlignAngle(double ang)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setAlignAngle(swigCPtr, ang);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbSweepOptions_AlignOption align()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_align(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbSweepOptions_AlignOption)result;
	}

	public void setAlign(OdDbSweepOptions_AlignOption val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setAlign(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbSweepOptions_MiterOption miterOption()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_miterOption(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbSweepOptions_MiterOption)result;
	}

	public void setMiterOption(OdDbSweepOptions_MiterOption val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setMiterOption(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool alignStart()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_alignStart(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAlignStart(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setAlignStart(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d basePoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_basePoint(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBasePoint(OdGePoint3d pnt)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setBasePoint(swigCPtr, OdGePoint3d.getCPtr(pnt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool bank()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_bank(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBank(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setBank(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool checkIntersections()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_checkIntersections(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCheckIntersections(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setCheckIntersections(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d twistRefVec()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_twistRefVec(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTwistRefVec(OdGeVector3d vec)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setTwistRefVec(swigCPtr, OdGeVector3d.getCPtr(vec));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getSweepEntityTransform(OdGeMatrix3d mat)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_getSweepEntityTransform(swigCPtr, OdGeMatrix3d.getCPtr(mat));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSweepEntityTransform(OdGeMatrix3d mat)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setSweepEntityTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(mat));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult setSweepEntityTransform(OdDbEntityPtrArray sweepEntities, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setSweepEntityTransform__SWIG_1(swigCPtr, OdDbEntityPtrArray.getCPtr(sweepEntities), displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setSweepEntityTransform(OdDbEntityPtrArray sweepEntities)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setSweepEntityTransform__SWIG_2(swigCPtr, OdDbEntityPtrArray.getCPtr(sweepEntities));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public bool getPathEntityTransform(OdGeMatrix3d mat)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_getPathEntityTransform(swigCPtr, OdGeMatrix3d.getCPtr(mat));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPathEntityTransform(OdGeMatrix3d mat)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setPathEntityTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(mat));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult setPathEntityTransform(OdDbEntity pPathEnt, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setPathEntityTransform__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pPathEnt), displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setPathEntityTransform(OdDbEntity pPathEnt)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_setPathEntityTransform__SWIG_2(swigCPtr, OdDbEntity.getCPtr(pPathEnt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkSweepCurve(OdDbEntity pSweepEnt, out OdDb_Planarity planarity, OdGePoint3d pnt, OdGeVector3d vec, out bool closed, out double approxArcLen, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_checkSweepCurve__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), out planarity, OdGePoint3d.getCPtr(pnt), OdGeVector3d.getCPtr(vec), out closed, out approxArcLen, displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkSweepCurve(OdDbEntity pSweepEnt, out OdDb_Planarity planarity, OdGePoint3d pnt, OdGeVector3d vec, out bool closed, out double approxArcLen)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_checkSweepCurve__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pSweepEnt), out planarity, OdGePoint3d.getCPtr(pnt), OdGeVector3d.getCPtr(vec), out closed, out approxArcLen);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkPathCurve(OdDbEntity pPathEnt, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_checkPathCurve__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pPathEnt), displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkPathCurve(OdDbEntity pPathEnt)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSweepOptions_checkPathCurve__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pPathEnt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbRevolveOptions : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbRevolveOptions(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbRevolveOptions obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbRevolveOptions()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbRevolveOptions(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbRevolveOptions()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbRevolveOptions__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbRevolveOptions(OdDbRevolveOptions src)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbRevolveOptions__SWIG_1(getCPtr(src)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbRevolveOptions Assign(OdDbRevolveOptions src)
	{
		OdDbRevolveOptions result = new OdDbRevolveOptions(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbRevolveOptions_Assign(swigCPtr, getCPtr(src)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdDbRevolveOptions opt)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbRevolveOptions_IsEqual(swigCPtr, getCPtr(opt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double draftAngle()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbRevolveOptions_draftAngle(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDraftAngle(double ang)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbRevolveOptions_setDraftAngle(swigCPtr, ang);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double twistAngle()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbRevolveOptions_twistAngle(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTwistAngle(double ang)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbRevolveOptions_setTwistAngle(swigCPtr, ang);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool closeToAxis()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbRevolveOptions_closeToAxis(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCloseToAxis(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbRevolveOptions_setCloseToAxis(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult checkRevolveCurve(OdDbEntity pRevEnt, OdGePoint3d axisPnt, OdGeVector3d axisDir, out bool closed, out bool endPointsOnAxis, out bool planar, bool displayErrorMessages)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbRevolveOptions_checkRevolveCurve__SWIG_0(swigCPtr, OdDbEntity.getCPtr(pRevEnt), OdGePoint3d.getCPtr(axisPnt), OdGeVector3d.getCPtr(axisDir), out closed, out endPointsOnAxis, out planar, displayErrorMessages);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult checkRevolveCurve(OdDbEntity pRevEnt, OdGePoint3d axisPnt, OdGeVector3d axisDir, out bool closed, out bool endPointsOnAxis, out bool planar)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbRevolveOptions_checkRevolveCurve__SWIG_1(swigCPtr, OdDbEntity.getCPtr(pRevEnt), OdGePoint3d.getCPtr(axisPnt), OdGeVector3d.getCPtr(axisDir), out closed, out endPointsOnAxis, out planar);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}
}

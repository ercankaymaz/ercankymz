using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSectionGeometry : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSectionGeometry(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSectionGeometry obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiSectionGeometry()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSectionGeometry(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiSectionGeometry()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSectionGeometry(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDrawablePtrArray intBoundaryEnts()
	{
		OdGiDrawablePtrArray result = Helpers.GetObject<OdGiDrawablePtrArray>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometry_intBoundaryEnts__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiDrawablePtrArray intFillEnts()
	{
		OdGiDrawablePtrArray result = Helpers.GetObject<OdGiDrawablePtrArray>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometry_intFillEnts__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiDrawablePtrArray backgroundEnts()
	{
		OdGiDrawablePtrArray result = Helpers.GetObject<OdGiDrawablePtrArray>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometry_backgroundEnts__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiDrawablePtrArray foregroundEnts()
	{
		OdGiDrawablePtrArray result = Helpers.GetObject<OdGiDrawablePtrArray>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometry_foregroundEnts__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int foregroundFaceTransparency()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometry_foregroundFaceTransparency(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int foregroundEdgeTransparency()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometry_foregroundEdgeTransparency(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setForegroundTransparency(int faceTransp, int edgeTransp)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometry_setForegroundTransparency(swigCPtr, faceTransp, edgeTransp);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

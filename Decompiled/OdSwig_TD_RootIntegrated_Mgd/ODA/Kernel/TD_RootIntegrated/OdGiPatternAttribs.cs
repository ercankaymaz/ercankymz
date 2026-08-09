using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPatternAttribs : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdGePoint2dArray fillOriginArr
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_fillOriginArr_get(swigCPtr);
			OdGePoint2dArray result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint2dArray(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_fillOriginArr_set(swigCPtr, OdGePoint2dArray.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGeVector2dArray fillDirectionArr
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_fillDirectionArr_get(swigCPtr);
			OdGeVector2dArray result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector2dArray(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_fillDirectionArr_set(swigCPtr, OdGeVector2dArray.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGeVector2dArray fillOffsetDirectionArr
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_fillOffsetDirectionArr_get(swigCPtr);
			OdGeVector2dArray result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector2dArray(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_fillOffsetDirectionArr_set(swigCPtr, OdGeVector2dArray.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdDoubleArray fillDashesScaleArr
	{
		get
		{
			OdDoubleArray result = new OdDoubleArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_fillDashesScaleArr_get(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_fillDashesScaleArr_set(swigCPtr, OdDoubleArray.getCPtr(value).Handle);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdDoubleArray fillOffsetScaleArr
	{
		get
		{
			OdDoubleArray result = new OdDoubleArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_fillOffsetScaleArr_get(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_fillOffsetScaleArr_set(swigCPtr, OdDoubleArray.getCPtr(value).Handle);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPatternAttribs(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPatternAttribs obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiPatternAttribs()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPatternAttribs(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiPatternAttribs()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPatternAttribs(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_isEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void calcAttribs(OdGeSurface pSrf, OdGePoint2d faceFillOrigin, double rotAngle, OdGePoint2dArray basePts, OdDoubleArray angles, OdGeVector2dArray offsets, OdInt32Array faceList, OdGePoint3dArray vertexList, OdGePoint2dArray trMidPts, OdDoubleArray annotationScales, OdGeScale2d globalScaleUv, bool swapUv, double uDerScale, OdGeMatrix3d pTransfMx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_calcAttribs(swigCPtr, OdGeSurface.getCPtr(pSrf), OdGePoint2d.getCPtr(faceFillOrigin), rotAngle, OdGePoint2dArray.getCPtr(basePts).Handle, OdDoubleArray.getCPtr(angles).Handle, OdGeVector2dArray.getCPtr(offsets), OdInt32Array.getCPtr(faceList).Handle, OdGePoint3dArray.getCPtr(vertexList), OdGePoint2dArray.getCPtr(trMidPts).Handle, OdDoubleArray.getCPtr(annotationScales).Handle, OdGeScale2d.getCPtr(globalScaleUv), swapUv, uDerScale, OdGeMatrix3d.getCPtr(pTransfMx));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double calcAngleBetweenCurves(OdGeSurface pSrf, bool swapUv, double uDerScale, OdGePoint2d uvPt, OdGeVector2d dir, bool mirror)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPatternAttribs_calcAngleBetweenCurves(swigCPtr, OdGeSurface.getCPtr(pSrf), swapUv, uDerScale, OdGePoint2d.getCPtr(uvPt), OdGeVector2d.getCPtr(dir).Handle, mirror);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsSpatialQuery : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsSpatialQuery(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsSpatialQuery obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsSpatialQuery()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsSpatialQuery(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsSpatialQuery()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsSpatialQuery(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdSiShape build(OdGsViewImpl view, OdGeExtents3d sceneExtents, int numPoints, OdGePoint2d[] points)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dPair(points);
		try
		{
			OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdGsSpatialQuery_build__SWIG_0(swigCPtr, OdGsViewImpl.getCPtr(view), OdGeExtents3d.getCPtr(sceneExtents), numPoints, intPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(intPtr);
			}
		}
	}

	public OdSiShape build(OdGsViewImpl view, OdGeExtents3d sceneExtents, int numPoints, OdGsDCPoint points)
	{
		OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdGsSpatialQuery_build__SWIG_1(swigCPtr, OdGsViewImpl.getCPtr(view), OdGeExtents3d.getCPtr(sceneExtents), numPoints, OdGsDCPoint.getCPtr(points)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdSiShape build(OdGsViewImpl view, OdGeExtents3d sceneExtents, int numPoints)
	{
		OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdGsSpatialQuery_build__SWIG_2(swigCPtr, OdGsViewImpl.getCPtr(view), OdGeExtents3d.getCPtr(sceneExtents), numPoints), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdSiShape build(OdGsViewImpl view, OdGeExtents3d sceneExtents)
	{
		OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdGsSpatialQuery_build__SWIG_3(swigCPtr, OdGsViewImpl.getCPtr(view), OdGeExtents3d.getCPtr(sceneExtents)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdSiShape build(OdGsViewImpl view, OdGsBaseModel pModel, OdGeExtents3d sceneExtents, int numPoints, OdGePoint2d[] points)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dPair(points);
		try
		{
			OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdGsSpatialQuery_build__SWIG_4(swigCPtr, OdGsViewImpl.getCPtr(view), OdGsBaseModel.getCPtr(pModel), OdGeExtents3d.getCPtr(sceneExtents), numPoints, intPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(intPtr);
			}
		}
	}

	public OdSiShape build(OdGsViewImpl view, OdGsBaseModel pModel, OdGeExtents3d sceneExtents, int numPoints, OdGsDCPoint points)
	{
		OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdGsSpatialQuery_build__SWIG_5(swigCPtr, OdGsViewImpl.getCPtr(view), OdGsBaseModel.getCPtr(pModel), OdGeExtents3d.getCPtr(sceneExtents), numPoints, OdGsDCPoint.getCPtr(points)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdSiShape build(OdGsViewImpl view, OdGsBaseModel pModel, OdGeExtents3d sceneExtents, int numPoints)
	{
		OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdGsSpatialQuery_build__SWIG_6(swigCPtr, OdGsViewImpl.getCPtr(view), OdGsBaseModel.getCPtr(pModel), OdGeExtents3d.getCPtr(sceneExtents), numPoints), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdSiShape build(OdGsViewImpl view, OdGsBaseModel pModel, OdGeExtents3d sceneExtents)
	{
		OdSiShapeImpl result = new OdSiShapeImpl(TD_RootIntegrated_GlobalsPINVOKE.OdGsSpatialQuery_build__SWIG_7(swigCPtr, OdGsViewImpl.getCPtr(view), OdGsBaseModel.getCPtr(pModel), OdGeExtents3d.getCPtr(sceneExtents)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdSi_BBox getBBox()
	{
		OdSi_BBox result = new OdSi_BBox(TD_RootIntegrated_GlobalsPINVOKE.OdGsSpatialQuery_getBBox(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

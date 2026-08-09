using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcCrossingPointsCrvIntersection : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcCrossingPointsCrvIntersection(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcCrossingPointsCrvIntersection obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcCrossingPointsCrvIntersection()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcCrossingPointsCrvIntersection(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcCrossingPointsCrvIntersection()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcCrossingPointsCrvIntersection(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcOut(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcIn(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d crossingPointTangent()
	{
		OdGeVector3d result = new OdGeVector3d(OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_crossingPointTangent__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d crossingPointUv2()
	{
		OdGePoint2d result = new OdGePoint2d(OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_crossingPointUv2__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d crossingPointUv1()
	{
		OdGePoint2d result = new OdGePoint2d(OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_crossingPointUv1__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d crossingPointPosition()
	{
		OdGePoint3d result = new OdGePoint3d(OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_crossingPointPosition__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCrossingPointScale(double crossing_point_scale)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_setCrossingPointScale(swigCPtr, crossing_point_scale);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double crossingPointScale()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_crossingPointScale(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCrossingPointParameter(double crossing_point_parameter)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_setCrossingPointParameter(swigCPtr, crossing_point_parameter);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double crossingPointParameter()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_crossingPointParameter(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCrossingPointFlags(byte crossing_point_flags)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_setCrossingPointFlags(swigCPtr, crossing_point_flags);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public byte crossingPointFlags()
	{
		byte result = OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_crossingPointFlags(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setcrossingPointTangent(OdGeVector3d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_setcrossingPointTangent(swigCPtr, OdGeVector3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setcrossingPointUv2(OdGePoint2d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_setcrossingPointUv2(swigCPtr, OdGePoint2d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setcrossingPointUv1(OdGePoint2d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_setcrossingPointUv1(swigCPtr, OdGePoint2d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setcrossingPointPosition(OdGePoint3d value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersection_setcrossingPointPosition(swigCPtr, OdGePoint3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

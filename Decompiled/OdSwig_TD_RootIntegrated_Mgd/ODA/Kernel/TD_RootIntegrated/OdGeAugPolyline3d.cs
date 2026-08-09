using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeAugPolyline3d : OdGePolyline3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeAugPolyline3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeAugPolyline3d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeAugPolyline3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeAugPolyline3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_copy(swigCPtr);
		OdGeAugPolyline3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeAugPolyline3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeAugPolyline3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeAugPolyline3d result = new OdGeAugPolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeAugPolyline3d translateBy(OdGeVector3d translateVec)
	{
		OdGeAugPolyline3d result = new OdGeAugPolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeAugPolyline3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeAugPolyline3d result = new OdGeAugPolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeAugPolyline3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeAugPolyline3d result = new OdGeAugPolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeAugPolyline3d mirror(OdGePlane plane)
	{
		OdGeAugPolyline3d result = new OdGeAugPolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeAugPolyline3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeAugPolyline3d result = new OdGeAugPolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeAugPolyline3d scaleBy(double scaleFactor)
	{
		OdGeAugPolyline3d result = new OdGeAugPolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeAugPolyline3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeAugPolyline3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeAugPolyline3d(OdGeAugPolyline3d apline)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeAugPolyline3d__SWIG_1(getCPtr(apline)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeAugPolyline3d(OdGeKnotVector knots, OdGePoint3dArray controlPoints, OdGeVector3dArray vecBundle)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeAugPolyline3d__SWIG_2(OdGeKnotVector.getCPtr(knots), OdGePoint3dArray.getCPtr(controlPoints), OdGeVector3dArray.getCPtr(vecBundle)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeAugPolyline3d(OdGePoint3dArray controlPoints, OdGeVector3dArray vecBundle)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeAugPolyline3d__SWIG_3(OdGePoint3dArray.getCPtr(controlPoints), OdGeVector3dArray.getCPtr(vecBundle)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeAugPolyline3d(OdGeCurve3d curve, double fromParam, double toParam, double approxEps)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeAugPolyline3d__SWIG_4(OdGeCurve3d.getCPtr(curve), fromParam, toParam, approxEps), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeAugPolyline3d Assign(OdGeAugPolyline3d apline)
	{
		OdGeAugPolyline3d result = new OdGeAugPolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_Assign(swigCPtr, getCPtr(apline)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d getPoint(int index)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_getPoint(swigCPtr, index), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeAugPolyline3d setPoint(int controlpointIndex, OdGePoint3d point)
	{
		OdGeAugPolyline3d result = new OdGeAugPolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_setPoint(swigCPtr, controlpointIndex, OdGePoint3d.getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getPoints(OdGePoint3dArray controlPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_getPoints(swigCPtr, OdGePoint3dArray.getCPtr(controlPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d getVector(int vectorIndex)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_getVector(swigCPtr, vectorIndex), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeAugPolyline3d setVector(int vectorIndex, OdGeVector3d vect)
	{
		OdGeAugPolyline3d result = new OdGeAugPolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_setVector(swigCPtr, vectorIndex, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getD1Vectors(OdGeVector3dArray tangents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_getD1Vectors(swigCPtr, OdGeVector3dArray.getCPtr(tangents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d getD2Vector(int vectorIndex)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_getD2Vector(swigCPtr, vectorIndex), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeAugPolyline3d setD2Vector(int vectorIndex, OdGeVector3d vect)
	{
		OdGeAugPolyline3d result = new OdGeAugPolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_setD2Vector(swigCPtr, vectorIndex, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getD2Vectors(OdGeVector3dArray d2Vectors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_getD2Vectors(swigCPtr, OdGeVector3dArray.getCPtr(d2Vectors));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double approxTol()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_approxTol(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeAugPolyline3d setApproxTol(double approxTol)
	{
		OdGeAugPolyline3d result = new OdGeAugPolyline3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeAugPolyline3d_setApproxTol(swigCPtr, approxTol), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeNurbSurface : OdGeSurface
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeNurbSurface(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeNurbSurface obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeNurbSurface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeNurbSurface copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_copy(swigCPtr);
		OdGeNurbSurface result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbSurface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbSurface transformBy(OdGeMatrix3d xfm)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbSurface translateBy(OdGeVector3d translateVec)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbSurface rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbSurface rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbSurface mirror(OdGePlane plane)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbSurface scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbSurface scaleBy(double scaleFactor)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbSurface()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbSurface__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbSurface(int degreeInU, int degreeInV, int propsInU, int propsInV, int numControlPointsInU, int numControlPointsInV, OdGePoint3dArray controlPoints, OdDoubleArray weights, OdGeKnotVector uKnots, OdGeKnotVector vKnots, OdGeTol tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbSurface__SWIG_1(degreeInU, degreeInV, propsInU, propsInV, numControlPointsInU, numControlPointsInV, OdGePoint3dArray.getCPtr(controlPoints), OdDoubleArray.getCPtr(weights).Handle, OdGeKnotVector.getCPtr(uKnots), OdGeKnotVector.getCPtr(vKnots), OdGeTol.getCPtr(tol)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbSurface(int degreeInU, int degreeInV, int propsInU, int propsInV, int numControlPointsInU, int numControlPointsInV, OdGePoint3dArray controlPoints, OdDoubleArray weights, OdGeKnotVector uKnots, OdGeKnotVector vKnots)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbSurface__SWIG_2(degreeInU, degreeInV, propsInU, propsInV, numControlPointsInU, numControlPointsInV, OdGePoint3dArray.getCPtr(controlPoints), OdDoubleArray.getCPtr(weights).Handle, OdGeKnotVector.getCPtr(uKnots), OdGeKnotVector.getCPtr(vKnots)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbSurface(OdGeNurbSurface source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbSurface__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbSurface(OdGeEllipCylinder cylinder)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbSurface__SWIG_4(OdGeEllipCylinder.getCPtr(cylinder)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbSurface(OdGeEllipCone cone)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbSurface__SWIG_5(OdGeEllipCone.getCPtr(cone)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbSurface Assign(OdGeNurbSurface nurb)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_Assign(swigCPtr, getCPtr(nurb)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRationalInU()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_isRationalInU(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPeriodicInU(out double period)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_isPeriodicInU(swigCPtr, out period);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRationalInV()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_isRationalInV(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPeriodicInV(out double period)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_isPeriodicInV(swigCPtr, out period);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int singularityInU()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_singularityInU(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int singularityInV()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_singularityInV(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int degreeInU()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_degreeInU(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numControlPointsInU()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_numControlPointsInU(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int degreeInV()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_degreeInV(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numControlPointsInV()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_numControlPointsInV(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getControlPoints(OdGePoint3dArray controlPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_getControlPoints(swigCPtr, OdGePoint3dArray.getCPtr(controlPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getWeights(OdDoubleArray weights)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_getWeights(swigCPtr, OdDoubleArray.getCPtr(weights).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numKnotsInU()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_numKnotsInU(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getUKnots(OdGeKnotVector uKnots)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_getUKnots(swigCPtr, OdGeKnotVector.getCPtr(uKnots));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numKnotsInV()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_numKnotsInV(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getVKnots(OdGeKnotVector vKnots)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_getVKnots(swigCPtr, OdGeKnotVector.getCPtr(vKnots));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDefinition(out int degreeInU, out int degreeInV, out int propsInU, out int propsInV, out int numControlPointsInU, out int numControlPointsInV, OdGePoint3dArray controlPoints, OdDoubleArray weights, OdGeKnotVector uKnots, OdGeKnotVector vKnots)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_getDefinition(swigCPtr, out degreeInU, out degreeInV, out propsInU, out propsInV, out numControlPointsInU, out numControlPointsInV, OdGePoint3dArray.getCPtr(controlPoints), OdDoubleArray.getCPtr(weights).Handle, OdGeKnotVector.getCPtr(uKnots), OdGeKnotVector.getCPtr(vKnots));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbSurface set(int degreeInU, int degreeInV, int propsInU, int propsInV, int numControlPointsInU, int numControlPointsInV, OdGePoint3dArray controlPoints, OdDoubleArray weights, OdGeKnotVector uKnots, OdGeKnotVector vKnots, OdGeTol tol)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_set__SWIG_0(swigCPtr, degreeInU, degreeInV, propsInU, propsInV, numControlPointsInU, numControlPointsInV, OdGePoint3dArray.getCPtr(controlPoints), OdDoubleArray.getCPtr(weights).Handle, OdGeKnotVector.getCPtr(uKnots), OdGeKnotVector.getCPtr(vKnots), OdGeTol.getCPtr(tol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbSurface set(int degreeInU, int degreeInV, int propsInU, int propsInV, int numControlPointsInU, int numControlPointsInV, OdGePoint3dArray controlPoints, OdDoubleArray weights, OdGeKnotVector uKnots, OdGeKnotVector vKnots)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_set__SWIG_1(swigCPtr, degreeInU, degreeInV, propsInU, propsInV, numControlPointsInU, numControlPointsInV, OdGePoint3dArray.getCPtr(controlPoints), OdDoubleArray.getCPtr(weights).Handle, OdGeKnotVector.getCPtr(uKnots), OdGeKnotVector.getCPtr(vKnots)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbSurface setFitData(OdGePoint3dArray fitPoints, OdGeVector3dArray arrTangentsInU, OdGeVector3dArray arrTangentsInV, OdGeVector3dArray arrMixedDerivs, OdGeKnotVector uKnots, OdGeKnotVector vKnots, OdGeTol tol)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_setFitData(swigCPtr, OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3dArray.getCPtr(arrTangentsInU), OdGeVector3dArray.getCPtr(arrTangentsInV), OdGeVector3dArray.getCPtr(arrMixedDerivs), OdGeKnotVector.getCPtr(uKnots), OdGeKnotVector.getCPtr(vKnots), OdGeTol.getCPtr(tol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void computeVIsoLine(double V, OdGeNurbCurve3d isoline)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_computeVIsoLine(swigCPtr, V, OdGeNurbCurve3d.getCPtr(isoline));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void computeUIsoLine(double U, OdGeNurbCurve3d isoline)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_computeUIsoLine(swigCPtr, U, OdGeNurbCurve3d.getCPtr(isoline));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint2d paramOfPrec(OdGePoint3d point, OdGeTol tol)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_paramOfPrec__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d paramOfPrec(OdGePoint3d point)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_paramOfPrec__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int loc(int i, int j)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_loc(swigCPtr, i, j);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbSurface convertFrom(OdGeSurface source, OdGeUvBox domain, OdGeTol tol, bool sameParametrization)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_convertFrom__SWIG_0(OdGeSurface.getCPtr(source), OdGeUvBox.getCPtr(domain), OdGeTol.getCPtr(tol), sameParametrization);
		OdGeNurbSurface result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbSurface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbSurface convertFrom(OdGeSurface source, OdGeUvBox domain, OdGeTol tol)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_convertFrom__SWIG_1(OdGeSurface.getCPtr(source), OdGeUvBox.getCPtr(domain), OdGeTol.getCPtr(tol));
		OdGeNurbSurface result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbSurface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbSurface convertFrom(OdGeSurface source, OdGeUvBox domain)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_convertFrom__SWIG_2(OdGeSurface.getCPtr(source), OdGeUvBox.getCPtr(domain));
		OdGeNurbSurface result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbSurface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbSurface convertFrom(OdGeSurface source, OdGeTol tol, bool sameParametrization)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_convertFrom__SWIG_3(OdGeSurface.getCPtr(source), OdGeTol.getCPtr(tol), sameParametrization);
		OdGeNurbSurface result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbSurface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbSurface convertFrom(OdGeSurface source, OdGeTol tol)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_convertFrom__SWIG_4(OdGeSurface.getCPtr(source), OdGeTol.getCPtr(tol));
		OdGeNurbSurface result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbSurface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbSurface convertFrom(OdGeSurface source)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_convertFrom__SWIG_5(OdGeSurface.getCPtr(source));
		OdGeNurbSurface result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbSurface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbSurface joinWith(OdGeNurbSurface surface, OdGeNurbSurface_ConnectionSide thisConnectionSide, OdGeNurbSurface_ConnectionSide surfaceConnectionSide, OdGeTol tol)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_joinWith__SWIG_0(swigCPtr, getCPtr(surface), (int)thisConnectionSide, (int)surfaceConnectionSide, OdGeTol.getCPtr(tol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbSurface joinWith(OdGeNurbSurface surface, OdGeNurbSurface_ConnectionSide thisConnectionSide, OdGeNurbSurface_ConnectionSide surfaceConnectionSide)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_joinWith__SWIG_1(swigCPtr, getCPtr(surface), (int)thisConnectionSide, (int)surfaceConnectionSide), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbSurface elevateDegree(bool iByU, int iPlusDegree)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_elevateDegree(swigCPtr, iByU, iPlusDegree), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbSurface insertKnot(bool iByU, double iNewKnot, int iTimes)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_insertKnot__SWIG_0(swigCPtr, iByU, iNewKnot, iTimes), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbSurface insertKnot(bool iByU, double iNewKnot)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_insertKnot__SWIG_1(swigCPtr, iByU, iNewKnot), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double knotAt(bool iByU, int iKnotIndex)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_knotAt(swigCPtr, iByU, iKnotIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d controlPointAt(int iIdxU, int iIdxV)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_controlPointAt(swigCPtr, iIdxU, iIdxV), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbSurface setControlPointAt(int iIdxU, int iIdxV, OdGePoint3d iPoint)
	{
		OdGeNurbSurface result = new OdGeNurbSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_setControlPointAt(swigCPtr, iIdxU, iIdxV, OdGePoint3d.getCPtr(iPoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getDerivativesAtWr(OdGePoint2d param, uint numDeriv, VectorDerivArrayWr derivatives)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbSurface_getDerivativesAtWr(swigCPtr, OdGePoint2d.getCPtr(param), numDeriv, VectorDerivArrayWr.getCPtr(derivatives));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

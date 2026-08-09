using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeNurbCurve3d : OdGeSplineEnt3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeNurbCurve3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeNurbCurve3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeNurbCurve3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeNurbCurve3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_copy(swigCPtr);
		OdGeNurbCurve3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve3d translateBy(OdGeVector3d translateVec)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve3d mirror(OdGePlane plane)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve3d scaleBy(double scaleFactor)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGeNurbCurve3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(int degree, OdGeKnotVector knots, OdGePoint3dArray controlPoints, bool isPeriodic)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_2(degree, OdGeKnotVector.getCPtr(knots), OdGePoint3dArray.getCPtr(controlPoints), isPeriodic), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(int degree, OdGeKnotVector knots, OdGePoint3dArray controlPoints)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_3(degree, OdGeKnotVector.getCPtr(knots), OdGePoint3dArray.getCPtr(controlPoints)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(int degree, OdGeKnotVector knots, OdGePoint3dArray controlPoints, OdDoubleArray weights, bool isPeriodic)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_4(degree, OdGeKnotVector.getCPtr(knots), OdGePoint3dArray.getCPtr(controlPoints), OdDoubleArray.getCPtr(weights).Handle, isPeriodic), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(int degree, OdGeKnotVector knots, OdGePoint3dArray controlPoints, OdDoubleArray weights)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_5(degree, OdGeKnotVector.getCPtr(knots), OdGePoint3dArray.getCPtr(controlPoints), OdDoubleArray.getCPtr(weights).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(int degree, OdGeKnotVector knots, OdGePoint3d controlPoints, uint numControlPoints, double[] weights, uint numWeights, bool isPeriodic)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_6(degree, OdGeKnotVector.getCPtr(knots), OdGePoint3d.getCPtr(controlPoints), numControlPoints, weights, numWeights, isPeriodic), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(int degree, OdGeKnotVector knots, OdGePoint3d controlPoints, uint numControlPoints, double[] weights, uint numWeights)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_7(degree, OdGeKnotVector.getCPtr(knots), OdGePoint3d.getCPtr(controlPoints), numControlPoints, weights, numWeights), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(int degree, OdGePolyline3d fitPolyline, bool isPeriodic)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_8(degree, OdGePolyline3d.getCPtr(fitPolyline), isPeriodic), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(int degree, OdGePolyline3d fitPolyline)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_9(degree, OdGePolyline3d.getCPtr(fitPolyline)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGePoint3dArray fitPoints, OdGeVector3d startTangent, OdGeVector3d endTangent, bool startTangentDefined, bool endTangentDefined, OdGeTol fitTol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_10(OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent), startTangentDefined, endTangentDefined, OdGeTol.getCPtr(fitTol)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGePoint3dArray fitPoints, OdGeVector3d startTangent, OdGeVector3d endTangent, bool startTangentDefined, bool endTangentDefined)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_11(OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent), startTangentDefined, endTangentDefined), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGePoint3dArray fitPoints, OdGeVector3d startTangent, OdGeVector3d endTangent, bool startTangentDefined)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_12(OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent), startTangentDefined), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGePoint3dArray fitPoints, OdGeVector3d startTangent, OdGeVector3d endTangent)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_13(OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGePoint3dArray fitPoints, OdGeTol fitTolerance)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_14(OdGePoint3dArray.getCPtr(fitPoints), OdGeTol.getCPtr(fitTolerance)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGePoint3dArray fitPoints)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_15(OdGePoint3dArray.getCPtr(fitPoints)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGePoint3dArray fitPoints, OdGeVector3dArray fitTangents, OdGeTol fitTolerance, bool isPeriodic)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_16(OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3dArray.getCPtr(fitTangents), OdGeTol.getCPtr(fitTolerance), isPeriodic), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGePoint3dArray fitPoints, OdGeVector3dArray fitTangents, OdGeTol fitTolerance)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_17(OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3dArray.getCPtr(fitTangents), OdGeTol.getCPtr(fitTolerance)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGePoint3dArray fitPoints, OdGeVector3dArray fitTangents)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_18(OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3dArray.getCPtr(fitTangents)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGePoint3dArray fitPoints, OdGeVector3d startTangent, OdGeVector3d endTangent, bool startTangentDefined, bool endTangentDefined, OdGe_OdGeKnotParameterization knotParam, OdGeTol fitTolerance)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_19(OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent), startTangentDefined, endTangentDefined, (int)knotParam, OdGeTol.getCPtr(fitTolerance)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGePoint3dArray fitPoints, OdGeVector3d startTangent, OdGeVector3d endTangent, bool startTangentDefined, bool endTangentDefined, OdGe_OdGeKnotParameterization knotParam)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_20(OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent), startTangentDefined, endTangentDefined, (int)knotParam), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGeEllipArc3d ellipse, int numSpans)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_21(OdGeEllipArc3d.getCPtr(ellipse), numSpans), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGeEllipArc3d ellipse)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_22(OdGeEllipArc3d.getCPtr(ellipse)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d(OdGeLineSeg3d lineSeg)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve3d__SWIG_23(OdGeLineSeg3d.getCPtr(lineSeg)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numFitPoints()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_numFitPoints(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFitKnotParameterization(ref OdGe_OdGeKnotParameterization knotParam)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_getFitKnotParameterization(swigCPtr, ref knotParam);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFitPointAt(int fitPointIndex, OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_getFitPointAt(swigCPtr, fitPointIndex, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFitTolerance(OdGeTol fitTolerance)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_getFitTolerance(swigCPtr, OdGeTol.getCPtr(fitTolerance));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFitTangents(OdGeVector3d startTangent, OdGeVector3d endTangent)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_getFitTangents__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFitTangents(OdGeVector3d startTangent, OdGeVector3d endTangent, out bool startTangentDefined, out bool endTangentDefined)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_getFitTangents__SWIG_1(swigCPtr, OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent), out startTangentDefined, out endTangentDefined);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFitData(OdGePoint3dArray fitPoints, OdGeTol fitTolerance, out bool tangentsExist, OdGeVector3d startTangent, OdGeVector3d endTangent)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_getFitData__SWIG_0(swigCPtr, OdGePoint3dArray.getCPtr(fitPoints), OdGeTol.getCPtr(fitTolerance), out tangentsExist, OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFitData(OdGePoint3dArray fitPoints, OdGeTol fitTolerance, out bool tangentsExist, OdGeVector3d startTangent, OdGeVector3d endTangent, ref OdGe_OdGeKnotParameterization knotParam)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_getFitData__SWIG_1(swigCPtr, OdGePoint3dArray.getCPtr(fitPoints), OdGeTol.getCPtr(fitTolerance), out tangentsExist, OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent), ref knotParam);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getDefinitionData(out int degree, out bool rational, out bool periodic, OdGeKnotVector knots, OdGePoint3dArray controlPoints, OdDoubleArray weights)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_getDefinitionData(swigCPtr, out degree, out rational, out periodic, OdGeKnotVector.getCPtr(knots), OdGePoint3dArray.getCPtr(controlPoints), OdDoubleArray.getCPtr(weights).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numWeights()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_numWeights(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double weightAt(int weightIndex)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_weightAt(swigCPtr, weightIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d setWeightAt(int weightIndex, double weight)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setWeightAt(swigCPtr, weightIndex, weight), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool evalMode()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_evalMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getParamsOfC1Discontinuity(OdDoubleArray params_, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_getParamsOfC1Discontinuity__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(params_).Handle, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getParamsOfC1Discontinuity(OdDoubleArray params_)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_getParamsOfC1Discontinuity__SWIG_1(swigCPtr, OdDoubleArray.getCPtr(params_).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getParamsOfG1Discontinuity(OdDoubleArray params_, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_getParamsOfG1Discontinuity__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(params_).Handle, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getParamsOfG1Discontinuity(OdDoubleArray params_)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_getParamsOfG1Discontinuity__SWIG_1(swigCPtr, OdDoubleArray.getCPtr(params_).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setFitPointAt(int fitPointIndex, OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitPointAt(swigCPtr, fitPointIndex, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool addFitPointAt(int fitPointIndex, OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_addFitPointAt(swigCPtr, fitPointIndex, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool deleteFitPointAt(int fitPointIndex)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_deleteFitPointAt(swigCPtr, fitPointIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool addControlPointAt(double newKnot, OdGePoint3d point, double weight)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_addControlPointAt__SWIG_0(swigCPtr, newKnot, OdGePoint3d.getCPtr(point), weight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool addControlPointAt(double newKnot, OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_addControlPointAt__SWIG_1(swigCPtr, newKnot, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool deleteControlPointAt(int index)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_deleteControlPointAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setFitKnotParameterization(OdGe_OdGeKnotParameterization knotParam)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitKnotParameterization(swigCPtr, (int)knotParam);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setFitTolerance(OdGeTol fitTol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitTolerance__SWIG_0(swigCPtr, OdGeTol.getCPtr(fitTol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setFitTolerance()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitTolerance__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setFitTangents(OdGeVector3d startTangent, OdGeVector3d endTangent)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitTangents__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setFitTangents(OdGeVector3d startTangent, OdGeVector3d endTangent, bool startTangentDefined, bool endTangentDefined)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitTangents__SWIG_1(swigCPtr, OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent), startTangentDefined, endTangentDefined);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d setFitData(OdGePoint3dArray fitPoints, OdGeVector3d startTangent, OdGeVector3d endTangent, OdGeTol fitTol)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitData__SWIG_0(swigCPtr, OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent), OdGeTol.getCPtr(fitTol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d setFitData(OdGePoint3dArray fitPoints, OdGeVector3d startTangent, OdGeVector3d endTangent)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitData__SWIG_1(swigCPtr, OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d setFitData(OdGeKnotVector fitKnots, OdGePoint3dArray fitPoints, OdGeVector3d startTangent, OdGeVector3d endTangent, OdGeTol fitTol, bool isPeriodic)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitData__SWIG_2(swigCPtr, OdGeKnotVector.getCPtr(fitKnots), OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent), OdGeTol.getCPtr(fitTol), isPeriodic), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d setFitData(OdGeKnotVector fitKnots, OdGePoint3dArray fitPoints, OdGeVector3d startTangent, OdGeVector3d endTangent, OdGeTol fitTol)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitData__SWIG_3(swigCPtr, OdGeKnotVector.getCPtr(fitKnots), OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent), OdGeTol.getCPtr(fitTol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d setFitData(OdGeKnotVector fitKnots, OdGePoint3dArray fitPoints, OdGeVector3d startTangent, OdGeVector3d endTangent)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitData__SWIG_4(swigCPtr, OdGeKnotVector.getCPtr(fitKnots), OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d setFitData(int degree, OdGePoint3dArray fitPoints, OdGeTol fitTol)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitData__SWIG_5(swigCPtr, degree, OdGePoint3dArray.getCPtr(fitPoints), OdGeTol.getCPtr(fitTol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d setFitData(int degree, OdGePoint3dArray fitPoints)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitData__SWIG_6(swigCPtr, degree, OdGePoint3dArray.getCPtr(fitPoints)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d setFitData(OdGePoint3dArray fitPoints, OdGeVector3d startTangent, OdGeVector3d endTangent, OdGe_OdGeKnotParameterization knotParam, OdGeTol fitTol)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitData__SWIG_7(swigCPtr, OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent), (int)knotParam, OdGeTol.getCPtr(fitTol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d setFitData(OdGePoint3dArray fitPoints, OdGeVector3d startTangent, OdGeVector3d endTangent, OdGe_OdGeKnotParameterization knotParam)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setFitData__SWIG_8(swigCPtr, OdGePoint3dArray.getCPtr(fitPoints), OdGeVector3d.getCPtr(startTangent), OdGeVector3d.getCPtr(endTangent), (int)knotParam), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool purgeFitData()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_purgeFitData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d addKnot(double newKnot)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_addKnot(swigCPtr, newKnot), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d insertKnot(double newKnot)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_insertKnot(swigCPtr, newKnot), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d setEvalMode(bool evalMode)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setEvalMode__SWIG_0(swigCPtr, evalMode), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d setEvalMode()
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_setEvalMode__SWIG_1(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d joinWith(OdGeNurbCurve3d curve, OdGeTol iTolerance)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_joinWith__SWIG_0(swigCPtr, getCPtr(curve), OdGeTol.getCPtr(iTolerance)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d joinWith(OdGeNurbCurve3d curve)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_joinWith__SWIG_1(swigCPtr, getCPtr(curve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d hardTrimByParams(double newStartParam, double newEndParam)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_hardTrimByParams(swigCPtr, newStartParam, newEndParam), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d makeRational(double weight)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_makeRational__SWIG_0(swigCPtr, weight), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d makeRational()
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_makeRational__SWIG_1(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d makeClosed()
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_makeClosed(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d makePeriodic()
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_makePeriodic(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d makeNonPeriodic()
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_makeNonPeriodic(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d makeOpen()
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_makeOpen(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d elevateDegree(int plusDegree)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_elevateDegree(swigCPtr, plusDegree), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d Assign(OdGeNurbCurve3d spline)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_Assign(swigCPtr, getCPtr(spline)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d evalPoint(double param, int hint)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_evalPoint(swigCPtr, param, hint), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void evalPointDivider(double param, OdGePoint3d point, out double divider, int hint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_evalPointDivider(swigCPtr, param, OdGePoint3d.getCPtr(point), out divider, hint);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve3d set(int degree, OdGeKnotVector knots, OdGePoint3dArray controlPoints, OdDoubleArray weights, bool isPeriodic)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_set__SWIG_0(swigCPtr, degree, OdGeKnotVector.getCPtr(knots), OdGePoint3dArray.getCPtr(controlPoints), OdDoubleArray.getCPtr(weights).Handle, isPeriodic), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve3d set(int degree, OdGeKnotVector knots, OdGePoint3dArray controlPoints, OdDoubleArray weights)
	{
		OdGeNurbCurve3d result = new OdGeNurbCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_set__SWIG_1(swigCPtr, degree, OdGeKnotVector.getCPtr(knots), OdGePoint3dArray.getCPtr(controlPoints), OdDoubleArray.getCPtr(weights).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool buildFitData(OdGe_OdGeKnotParameterization knotParam)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_buildFitData__SWIG_0(swigCPtr, (int)knotParam);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool buildFitData()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_buildFitData__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbCurve3d convertFrom(OdGeCurve3d source, OdGeInterval domain, OdGeTol tol, bool sameParametrization)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_convertFrom__SWIG_0(OdGeCurve3d.getCPtr(source), OdGeInterval.getCPtr(domain), OdGeTol.getCPtr(tol), sameParametrization);
		OdGeNurbCurve3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbCurve3d convertFrom(OdGeCurve3d source, OdGeInterval domain, OdGeTol tol)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_convertFrom__SWIG_1(OdGeCurve3d.getCPtr(source), OdGeInterval.getCPtr(domain), OdGeTol.getCPtr(tol));
		OdGeNurbCurve3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbCurve3d convertFrom(OdGeCurve3d source, OdGeInterval domain)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_convertFrom__SWIG_2(OdGeCurve3d.getCPtr(source), OdGeInterval.getCPtr(domain));
		OdGeNurbCurve3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbCurve3d convertFrom(OdGeCurve3d source, OdGeTol tol, bool sameParametrization)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_convertFrom__SWIG_3(OdGeCurve3d.getCPtr(source), OdGeTol.getCPtr(tol), sameParametrization);
		OdGeNurbCurve3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbCurve3d convertFrom(OdGeCurve3d source, OdGeTol tol)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_convertFrom__SWIG_4(OdGeCurve3d.getCPtr(source), OdGeTol.getCPtr(tol));
		OdGeNurbCurve3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbCurve3d convertFrom(OdGeCurve3d source)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve3d_convertFrom__SWIG_5(OdGeCurve3d.getCPtr(source));
		OdGeNurbCurve3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

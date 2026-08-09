using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeNurbCurve2d : OdGeSplineEnt2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeNurbCurve2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeNurbCurve2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeNurbCurve2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeNurbCurve2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_copy(swigCPtr);
		OdGeNurbCurve2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve2d translateBy(OdGeVector2d translateVec)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve2d rotateBy(double angle)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve2d mirror(OdGeLine2d line)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeNurbCurve2d scaleBy(double scaleFactor)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGeNurbCurve2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(int degree, OdGeKnotVector knots, OdGePoint2dArray controlPoints, bool isPeriodic)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_2(degree, OdGeKnotVector.getCPtr(knots), OdGePoint2dArray.getCPtr(controlPoints).Handle, isPeriodic), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(int degree, OdGeKnotVector knots, OdGePoint2dArray controlPoints)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_3(degree, OdGeKnotVector.getCPtr(knots), OdGePoint2dArray.getCPtr(controlPoints).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(int degree, OdGeKnotVector knots, OdGePoint2dArray controlPoints, OdDoubleArray weights, bool isPeriodic)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_4(degree, OdGeKnotVector.getCPtr(knots), OdGePoint2dArray.getCPtr(controlPoints).Handle, OdDoubleArray.getCPtr(weights).Handle, isPeriodic), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(int degree, OdGeKnotVector knots, OdGePoint2dArray controlPoints, OdDoubleArray weights)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_5(degree, OdGeKnotVector.getCPtr(knots), OdGePoint2dArray.getCPtr(controlPoints).Handle, OdDoubleArray.getCPtr(weights).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(int degree, OdGePolyline2d fitPolyline, bool isPeriodic)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_6(degree, OdGePolyline2d.getCPtr(fitPolyline), isPeriodic), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(int degree, OdGePolyline2d fitPolyline)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_7(degree, OdGePolyline2d.getCPtr(fitPolyline)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGePoint2dArray fitPoints, OdGeVector2d startTangent, OdGeVector2d endTangent, bool startTangentDefined, bool endTangentDefined, OdGeTol fitTolerance)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_8(OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle, startTangentDefined, endTangentDefined, OdGeTol.getCPtr(fitTolerance)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGePoint2dArray fitPoints, OdGeVector2d startTangent, OdGeVector2d endTangent, bool startTangentDefined, bool endTangentDefined)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_9(OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle, startTangentDefined, endTangentDefined), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGePoint2dArray fitPoints, OdGeVector2d startTangent, OdGeVector2d endTangent, bool startTangentDefined)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_10(OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle, startTangentDefined), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGePoint2dArray fitPoints, OdGeVector2d startTangent, OdGeVector2d endTangent)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_11(OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGePoint2dArray fitPoints, OdGeTol fitTolerance)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_12(OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeTol.getCPtr(fitTolerance)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGePoint2dArray fitPoints)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_13(OdGePoint2dArray.getCPtr(fitPoints).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGePoint2dArray fitPoints, OdGeVector2dArray fitTangents, OdGeTol fitTolerance, bool isPeriodic)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_14(OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2dArray.getCPtr(fitTangents), OdGeTol.getCPtr(fitTolerance), isPeriodic), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGePoint2dArray fitPoints, OdGeVector2dArray fitTangents, OdGeTol fitTolerance)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_15(OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2dArray.getCPtr(fitTangents), OdGeTol.getCPtr(fitTolerance)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGePoint2dArray fitPoints, OdGeVector2dArray fitTangents)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_16(OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2dArray.getCPtr(fitTangents)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGeEllipArc2d ellipse)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_17(OdGeEllipArc2d.getCPtr(ellipse)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGeLineSeg2d linSeg)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_18(OdGeLineSeg2d.getCPtr(linSeg)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGePoint2dArray fitPoints, OdGeVector2d startTangent, OdGeVector2d endTangent, bool startTangentDefined, bool endTangentDefined, OdGe_OdGeKnotParameterization knotParam, OdGeTol fitTol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_19(OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle, startTangentDefined, endTangentDefined, (int)knotParam, OdGeTol.getCPtr(fitTol)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeNurbCurve2d(OdGePoint2dArray fitPoints, OdGeVector2d startTangent, OdGeVector2d endTangent, bool startTangentDefined, bool endTangentDefined, OdGe_OdGeKnotParameterization knotParam)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeNurbCurve2d__SWIG_20(OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle, startTangentDefined, endTangentDefined, (int)knotParam), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numFitPoints()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_numFitPoints(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFitKnotParameterization(ref OdGe_OdGeKnotParameterization knotParam)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_getFitKnotParameterization(swigCPtr, ref knotParam);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFitPointAt(int fitPointIndex, OdGePoint2d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_getFitPointAt(swigCPtr, fitPointIndex, OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFitTolerance(OdGeTol fitTolerance)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_getFitTolerance(swigCPtr, OdGeTol.getCPtr(fitTolerance));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFitTangents(OdGeVector2d startTangent, OdGeVector2d endTangent)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_getFitTangents(swigCPtr, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFitData(OdGePoint2dArray fitPoints, OdGeTol fitTolerance, out bool tangentsExist, OdGeVector2d startTangent, OdGeVector2d endTangent)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_getFitData__SWIG_0(swigCPtr, OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeTol.getCPtr(fitTolerance), out tangentsExist, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFitData(OdGePoint2dArray fitPoints, OdGeTol fitTolerance, out bool tangentsExist, OdGeVector2d startTangent, OdGeVector2d endTangent, ref OdGe_OdGeKnotParameterization knotParam)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_getFitData__SWIG_1(swigCPtr, OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeTol.getCPtr(fitTolerance), out tangentsExist, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle, ref knotParam);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getDefinitionData(out int degree, out bool rational, out bool periodic, OdGeKnotVector knots, OdGePoint2dArray controlPoints, OdDoubleArray weights)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_getDefinitionData(swigCPtr, out degree, out rational, out periodic, OdGeKnotVector.getCPtr(knots), OdGePoint2dArray.getCPtr(controlPoints).Handle, OdDoubleArray.getCPtr(weights).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int numWeights()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_numWeights(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double weightAt(int weightIndex)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_weightAt(swigCPtr, weightIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d setWeightAt(int weightIndex, double weight)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setWeightAt(swigCPtr, weightIndex, weight), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool evalMode()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_evalMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getParamsOfC1Discontinuity(OdDoubleArray params_, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_getParamsOfC1Discontinuity__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(params_).Handle, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getParamsOfC1Discontinuity(OdDoubleArray params_)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_getParamsOfC1Discontinuity__SWIG_1(swigCPtr, OdDoubleArray.getCPtr(params_).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getParamsOfG1Discontinuity(OdDoubleArray params_, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_getParamsOfG1Discontinuity__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(params_).Handle, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getParamsOfG1Discontinuity(OdDoubleArray params_)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_getParamsOfG1Discontinuity__SWIG_1(swigCPtr, OdDoubleArray.getCPtr(params_).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setFitPointAt(int fitPointIndex, OdGePoint2d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitPointAt(swigCPtr, fitPointIndex, OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool addFitPointAt(int fitPointIndex, OdGePoint2d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_addFitPointAt(swigCPtr, fitPointIndex, OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool deleteFitPointAt(int fitPointIndex)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_deleteFitPointAt(swigCPtr, fitPointIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool addControlPointAt(double newKnot, OdGePoint2d point, double weight)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_addControlPointAt__SWIG_0(swigCPtr, newKnot, OdGePoint2d.getCPtr(point), weight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool addControlPointAt(double newKnot, OdGePoint2d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_addControlPointAt__SWIG_1(swigCPtr, newKnot, OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool deleteControlPointAt(int index)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_deleteControlPointAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setFitKnotParameterization(OdGe_OdGeKnotParameterization knotParam)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitKnotParameterization(swigCPtr, (int)knotParam);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setFitTolerance(OdGeTol fitTol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitTolerance__SWIG_0(swigCPtr, OdGeTol.getCPtr(fitTol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setFitTolerance()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitTolerance__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setFitTangents(OdGeVector2d startTangent, OdGeVector2d endTangent)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitTangents(swigCPtr, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d setFitData(OdGePoint2dArray fitPoints, OdGeVector2d startTangent, OdGeVector2d endTangent, OdGeTol fitTol)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitData__SWIG_0(swigCPtr, OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle, OdGeTol.getCPtr(fitTol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d setFitData(OdGePoint2dArray fitPoints, OdGeVector2d startTangent, OdGeVector2d endTangent)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitData__SWIG_1(swigCPtr, OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d setFitData(OdGeKnotVector fitKnots, OdGePoint2dArray fitPoints, OdGeVector2d startTangent, OdGeVector2d endTangent, OdGeTol fitTol, bool isPeriodic)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitData__SWIG_2(swigCPtr, OdGeKnotVector.getCPtr(fitKnots), OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle, OdGeTol.getCPtr(fitTol), isPeriodic), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d setFitData(OdGeKnotVector fitKnots, OdGePoint2dArray fitPoints, OdGeVector2d startTangent, OdGeVector2d endTangent, OdGeTol fitTol)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitData__SWIG_3(swigCPtr, OdGeKnotVector.getCPtr(fitKnots), OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle, OdGeTol.getCPtr(fitTol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d setFitData(OdGeKnotVector fitKnots, OdGePoint2dArray fitPoints, OdGeVector2d startTangent, OdGeVector2d endTangent)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitData__SWIG_4(swigCPtr, OdGeKnotVector.getCPtr(fitKnots), OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d setFitData(int degree, OdGePoint2dArray fitPoints, OdGeTol fitTol)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitData__SWIG_5(swigCPtr, degree, OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeTol.getCPtr(fitTol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d setFitData(int degree, OdGePoint2dArray fitPoints)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitData__SWIG_6(swigCPtr, degree, OdGePoint2dArray.getCPtr(fitPoints).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d setFitData(OdGePoint2dArray fitPoints, OdGeVector2d startTangent, OdGeVector2d endTangent, OdGe_OdGeKnotParameterization knotParam, OdGeTol fitTol)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitData__SWIG_7(swigCPtr, OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle, (int)knotParam, OdGeTol.getCPtr(fitTol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d setFitData(OdGePoint2dArray fitPoints, OdGeVector2d startTangent, OdGeVector2d endTangent, OdGe_OdGeKnotParameterization knotParam)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setFitData__SWIG_8(swigCPtr, OdGePoint2dArray.getCPtr(fitPoints).Handle, OdGeVector2d.getCPtr(startTangent).Handle, OdGeVector2d.getCPtr(endTangent).Handle, (int)knotParam), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool purgeFitData()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_purgeFitData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d addKnot(double newKnot)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_addKnot(swigCPtr, newKnot), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d insertKnot(double newKnot)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_insertKnot(swigCPtr, newKnot), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d setEvalMode(bool evalMode)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setEvalMode__SWIG_0(swigCPtr, evalMode), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d setEvalMode()
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_setEvalMode__SWIG_1(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d joinWith(OdGeNurbCurve2d curve, OdGeTol iTolerance)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_joinWith__SWIG_0(swigCPtr, getCPtr(curve), OdGeTol.getCPtr(iTolerance)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d joinWith(OdGeNurbCurve2d curve)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_joinWith__SWIG_1(swigCPtr, getCPtr(curve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d hardTrimByParams(double newStartParam, double newEndParam)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_hardTrimByParams(swigCPtr, newStartParam, newEndParam), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d makeRational(double weight)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_makeRational__SWIG_0(swigCPtr, weight), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d makeRational()
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_makeRational__SWIG_1(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d makeClosed()
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_makeClosed(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d makePeriodic()
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_makePeriodic(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d makeNonPeriodic()
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_makeNonPeriodic(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d makeOpen()
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_makeOpen(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d elevateDegree(int plusDegree)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_elevateDegree(swigCPtr, plusDegree), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d Assign(OdGeNurbCurve2d spline)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_Assign(swigCPtr, getCPtr(spline)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLine2d line2d, OdGePoint2dArray pnts2d, OdGeTol tol, OdDoubleArray params_)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_intersectWith__SWIG_0(swigCPtr, OdGeLine2d.getCPtr(line2d), OdGePoint2dArray.getCPtr(pnts2d).Handle, OdGeTol.getCPtr(tol), OdDoubleArray.getCPtr(params_).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLine2d line2d, OdGePoint2dArray pnts2d, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_intersectWith__SWIG_1(swigCPtr, OdGeLine2d.getCPtr(line2d), OdGePoint2dArray.getCPtr(pnts2d).Handle, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLine2d line2d, OdGePoint2dArray pnts2d)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_intersectWith__SWIG_2(swigCPtr, OdGeLine2d.getCPtr(line2d), OdGePoint2dArray.getCPtr(pnts2d).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d set(int degree, OdGeKnotVector knots, OdGePoint2dArray controlPoints, OdDoubleArray weights, bool isPeriodic)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_set__SWIG_0(swigCPtr, degree, OdGeKnotVector.getCPtr(knots), OdGePoint2dArray.getCPtr(controlPoints).Handle, OdDoubleArray.getCPtr(weights).Handle, isPeriodic), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeNurbCurve2d set(int degree, OdGeKnotVector knots, OdGePoint2dArray controlPoints, OdDoubleArray weights)
	{
		OdGeNurbCurve2d result = new OdGeNurbCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_set__SWIG_1(swigCPtr, degree, OdGeKnotVector.getCPtr(knots), OdGePoint2dArray.getCPtr(controlPoints).Handle, OdDoubleArray.getCPtr(weights).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbCurve2d convertFrom(OdGeCurve2d source, OdGeInterval domain, OdGeTol tol, bool sameParametrization)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_convertFrom__SWIG_0(OdGeCurve2d.getCPtr(source), OdGeInterval.getCPtr(domain), OdGeTol.getCPtr(tol), sameParametrization);
		OdGeNurbCurve2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbCurve2d convertFrom(OdGeCurve2d source, OdGeInterval domain, OdGeTol tol)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_convertFrom__SWIG_1(OdGeCurve2d.getCPtr(source), OdGeInterval.getCPtr(domain), OdGeTol.getCPtr(tol));
		OdGeNurbCurve2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbCurve2d convertFrom(OdGeCurve2d source, OdGeInterval domain)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_convertFrom__SWIG_2(OdGeCurve2d.getCPtr(source), OdGeInterval.getCPtr(domain));
		OdGeNurbCurve2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbCurve2d convertFrom(OdGeCurve2d source, OdGeTol tol, bool sameParametrization)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_convertFrom__SWIG_3(OdGeCurve2d.getCPtr(source), OdGeTol.getCPtr(tol), sameParametrization);
		OdGeNurbCurve2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbCurve2d convertFrom(OdGeCurve2d source, OdGeTol tol)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_convertFrom__SWIG_4(OdGeCurve2d.getCPtr(source), OdGeTol.getCPtr(tol));
		OdGeNurbCurve2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeNurbCurve2d convertFrom(OdGeCurve2d source)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeNurbCurve2d_convertFrom__SWIG_5(OdGeCurve2d.getCPtr(source));
		OdGeNurbCurve2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeNurbCurve2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeSegmentChain2d : OdGeSplineEnt2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeSegmentChain2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeSegmentChain2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeSegmentChain2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeSegmentChain2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_copy(swigCPtr);
		OdGeSegmentChain2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeSegmentChain2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSegmentChain2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeSegmentChain2d result = new OdGeSegmentChain2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSegmentChain2d translateBy(OdGeVector2d translateVec)
	{
		OdGeSegmentChain2d result = new OdGeSegmentChain2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSegmentChain2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeSegmentChain2d result = new OdGeSegmentChain2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSegmentChain2d rotateBy(double angle)
	{
		OdGeSegmentChain2d result = new OdGeSegmentChain2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSegmentChain2d mirror(OdGeLine2d line)
	{
		OdGeSegmentChain2d result = new OdGeSegmentChain2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSegmentChain2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeSegmentChain2d result = new OdGeSegmentChain2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeSegmentChain2d scaleBy(double scaleFactor)
	{
		OdGeSegmentChain2d result = new OdGeSegmentChain2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSegmentChain2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSegmentChain2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSegmentChain2d(OdGeSegmentChain2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSegmentChain2d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSegmentChain2d(OdGePoint2dArray fitpoints)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSegmentChain2d__SWIG_2(OdGePoint2dArray.getCPtr(fitpoints).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSegmentChain2d(OdGeKnotVector knots, OdGePoint2dArray points)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSegmentChain2d__SWIG_3(OdGeKnotVector.getCPtr(knots), OdGePoint2dArray.getCPtr(points).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSegmentChain2d(OdGeCurve2d crv, double approxEps)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeSegmentChain2d__SWIG_4(OdGeCurve2d.getCPtr(crv), approxEps), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeSegmentChain2d Assign(OdGeSegmentChain2d pline)
	{
		OdGeSegmentChain2d result = new OdGeSegmentChain2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_Assign(swigCPtr, getCPtr(pline)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeSegmentChain2d setClosed(bool flag)
	{
		OdGeSegmentChain2d result = new OdGeSegmentChain2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_setClosed(swigCPtr, flag), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDoubleArray bulges()
	{
		OdDoubleArray result = new OdDoubleArray(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_bulges(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDoubleArray getBulges()
	{
		OdDoubleArray result = new OdDoubleArray(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_getBulges(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2dArray vertices()
	{
		OdGePoint2dArray result = new OdGePoint2dArray(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_vertices(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2dArray getVertices()
	{
		OdGePoint2dArray result = new OdGePoint2dArray(TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_getVertices(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasBulges()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_hasBulges(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void appendSamplePointsOptimal(int numSampleForEachArc, OdGePoint2dArray pointArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeSegmentChain2d_appendSamplePointsOptimal(swigCPtr, numSampleForEachArc, OdGePoint2dArray.getCPtr(pointArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

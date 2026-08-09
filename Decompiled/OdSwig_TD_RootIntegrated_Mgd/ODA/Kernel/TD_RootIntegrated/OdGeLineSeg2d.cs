using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeLineSeg2d : OdGeLinearEnt2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeLineSeg2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeLineSeg2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeLineSeg2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeLineSeg2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_copy(swigCPtr);
		OdGeLineSeg2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeLineSeg2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeLineSeg2d result = new OdGeLineSeg2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg2d translateBy(OdGeVector2d translateVec)
	{
		OdGeLineSeg2d result = new OdGeLineSeg2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeLineSeg2d result = new OdGeLineSeg2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg2d rotateBy(double angle)
	{
		OdGeLineSeg2d result = new OdGeLineSeg2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg2d mirror(OdGeLine2d line)
	{
		OdGeLineSeg2d result = new OdGeLineSeg2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeLineSeg2d result = new OdGeLineSeg2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeLineSeg2d scaleBy(double scaleFactor)
	{
		OdGeLineSeg2d result = new OdGeLineSeg2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLineSeg2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLineSeg2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLineSeg2d(OdGeLineSeg2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLineSeg2d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLineSeg2d(OdGePoint2d point1, OdGePoint2d point2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLineSeg2d__SWIG_2(OdGePoint2d.getCPtr(point1), OdGePoint2d.getCPtr(point2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLineSeg2d(OdGePoint2d point, OdGeVector2d vect)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeLineSeg2d__SWIG_3(OdGePoint2d.getCPtr(point), OdGeVector2d.getCPtr(vect).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeLineSeg2d set(OdGePoint2d point, OdGeVector2d vect)
	{
		OdGeLineSeg2d result = new OdGeLineSeg2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_set__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(point), OdGeVector2d.getCPtr(vect).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLineSeg2d set(OdGePoint2d point1, OdGePoint2d point2)
	{
		OdGeLineSeg2d result = new OdGeLineSeg2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_set__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(point1), OdGePoint2d.getCPtr(point2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLineSeg2d set(OdGeCurve2d curve1, OdGeCurve2d curve2, out double param1, out double param2, out bool success)
	{
		OdGeLineSeg2d result = new OdGeLineSeg2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_set__SWIG_2(swigCPtr, OdGeCurve2d.getCPtr(curve1), OdGeCurve2d.getCPtr(curve2), out param1, out param2, out success), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLineSeg2d set(OdGeCurve2d curve, OdGePoint2d point, out double param, out bool success)
	{
		OdGeLineSeg2d result = new OdGeLineSeg2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_set__SWIG_3(swigCPtr, OdGeCurve2d.getCPtr(curve), OdGePoint2d.getCPtr(point), out param, out success), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getBisector(OdGeLine2d line)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_getBisector(swigCPtr, OdGeLine2d.getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint2d baryComb(double blendCoeff)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_baryComb(swigCPtr, blendCoeff), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d startPoint()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_startPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d endPoint()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_endPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeLineSeg2d Assign(OdGeLineSeg2d line)
	{
		OdGeLineSeg2d result = new OdGeLineSeg2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeLineSeg2d_Assign(swigCPtr, getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

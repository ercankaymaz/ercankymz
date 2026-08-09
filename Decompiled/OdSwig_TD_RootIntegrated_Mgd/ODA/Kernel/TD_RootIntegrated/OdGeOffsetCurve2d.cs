using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeOffsetCurve2d : OdGeCurve2d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeOffsetCurve2d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeOffsetCurve2d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeOffsetCurve2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeOffsetCurve2d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_copy(swigCPtr);
		OdGeOffsetCurve2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeOffsetCurve2d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve2d transformBy(OdGeMatrix2d xfm)
	{
		OdGeOffsetCurve2d result = new OdGeOffsetCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve2d translateBy(OdGeVector2d translateVec)
	{
		OdGeOffsetCurve2d result = new OdGeOffsetCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_translateBy(swigCPtr, OdGeVector2d.getCPtr(translateVec).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		OdGeOffsetCurve2d result = new OdGeOffsetCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_rotateBy__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve2d rotateBy(double angle)
	{
		OdGeOffsetCurve2d result = new OdGeOffsetCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_rotateBy__SWIG_1(swigCPtr, angle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve2d mirror(OdGeLine2d line)
	{
		OdGeOffsetCurve2d result = new OdGeOffsetCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGeOffsetCurve2d result = new OdGeOffsetCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint2d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve2d scaleBy(double scaleFactor)
	{
		OdGeOffsetCurve2d result = new OdGeOffsetCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetCurve2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeOffsetCurve2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeOffsetCurve2d(OdGeCurve2d baseCurve, double offsetDistance, bool makeCopy)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeOffsetCurve2d__SWIG_1(OdGeCurve2d.getCPtr(baseCurve), offsetDistance, makeCopy), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeOffsetCurve2d(OdGeCurve2d baseCurve, double offsetDistance)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeOffsetCurve2d__SWIG_2(OdGeCurve2d.getCPtr(baseCurve), offsetDistance), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeOffsetCurve2d(OdGeOffsetCurve2d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeOffsetCurve2d__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve2d curve()
	{
		OdGeCurve2d result = Helpers.GetObject<OdGeCurve2d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_curve(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double offsetDistance()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_offsetDistance(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool paramDirection()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_paramDirection(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix2d transformation()
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_transformation(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetCurve2d setCurve(OdGeCurve2d baseCurve, bool makeCopy)
	{
		OdGeOffsetCurve2d result = new OdGeOffsetCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_setCurve__SWIG_0(swigCPtr, OdGeCurve2d.getCPtr(baseCurve), makeCopy), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetCurve2d setCurve(OdGeCurve2d baseCurve)
	{
		OdGeOffsetCurve2d result = new OdGeOffsetCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_setCurve__SWIG_1(swigCPtr, OdGeCurve2d.getCPtr(baseCurve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetCurve2d setOffsetDistance(double distance)
	{
		OdGeOffsetCurve2d result = new OdGeOffsetCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_setOffsetDistance(swigCPtr, distance), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetCurve2d Assign(OdGeOffsetCurve2d offsetCurve)
	{
		OdGeOffsetCurve2d result = new OdGeOffsetCurve2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve2d_Assign(swigCPtr, getCPtr(offsetCurve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

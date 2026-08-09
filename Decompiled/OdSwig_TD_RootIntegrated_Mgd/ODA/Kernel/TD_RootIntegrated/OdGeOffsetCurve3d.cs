using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeOffsetCurve3d : OdGeCurve3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeOffsetCurve3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeOffsetCurve3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeOffsetCurve3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeOffsetCurve3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_copy(swigCPtr);
		OdGeOffsetCurve3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeOffsetCurve3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeOffsetCurve3d result = new OdGeOffsetCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve3d translateBy(OdGeVector3d translateVec)
	{
		OdGeOffsetCurve3d result = new OdGeOffsetCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeOffsetCurve3d result = new OdGeOffsetCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeOffsetCurve3d result = new OdGeOffsetCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve3d mirror(OdGePlane plane)
	{
		OdGeOffsetCurve3d result = new OdGeOffsetCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeOffsetCurve3d result = new OdGeOffsetCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetCurve3d scaleBy(double scaleFactor)
	{
		OdGeOffsetCurve3d result = new OdGeOffsetCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetCurve3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeOffsetCurve3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeOffsetCurve3d(OdGeCurve3d baseCurve, OdGeVector3d planeNormal, double offsetDistance, bool makeCopy)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeOffsetCurve3d__SWIG_1(OdGeCurve3d.getCPtr(baseCurve), OdGeVector3d.getCPtr(planeNormal), offsetDistance, makeCopy), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeOffsetCurve3d(OdGeCurve3d baseCurve, OdGeVector3d planeNormal, double offsetDistance)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeOffsetCurve3d__SWIG_2(OdGeCurve3d.getCPtr(baseCurve), OdGeVector3d.getCPtr(planeNormal), offsetDistance), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeOffsetCurve3d(OdGeOffsetCurve3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeOffsetCurve3d__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve3d curve()
	{
		OdGeCurve3d result = Helpers.GetObject<OdGeCurve3d>(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_curve(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d normal()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_normal(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double offsetDistance()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_offsetDistance(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool paramDirection()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_paramDirection(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d transformation()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_transformation(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetCurve3d setCurve(OdGeCurve3d baseCurve, bool makeCopy)
	{
		OdGeOffsetCurve3d result = new OdGeOffsetCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_setCurve__SWIG_0(swigCPtr, OdGeCurve3d.getCPtr(baseCurve), makeCopy), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetCurve3d setCurve(OdGeCurve3d baseCurve)
	{
		OdGeOffsetCurve3d result = new OdGeOffsetCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_setCurve__SWIG_1(swigCPtr, OdGeCurve3d.getCPtr(baseCurve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetCurve3d setNormal(OdGeVector3d planeNormal)
	{
		OdGeOffsetCurve3d result = new OdGeOffsetCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_setNormal(swigCPtr, OdGeVector3d.getCPtr(planeNormal)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetCurve3d setOffsetDistance(double offsetDistance)
	{
		OdGeOffsetCurve3d result = new OdGeOffsetCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_setOffsetDistance(swigCPtr, offsetDistance), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetCurve3d Assign(OdGeOffsetCurve3d offsetCurve)
	{
		OdGeOffsetCurve3d result = new OdGeOffsetCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetCurve3d_Assign(swigCPtr, getCPtr(offsetCurve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCompositeCurve3d : OdGeCurve3d
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCompositeCurve3d(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCompositeCurve3d obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCompositeCurve3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeCompositeCurve3d copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_copy(swigCPtr);
		OdGeCompositeCurve3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeCompositeCurve3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve3d transformBy(OdGeMatrix3d xfm)
	{
		OdGeCompositeCurve3d result = new OdGeCompositeCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve3d translateBy(OdGeVector3d translateVec)
	{
		OdGeCompositeCurve3d result = new OdGeCompositeCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeCompositeCurve3d result = new OdGeCompositeCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve3d rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeCompositeCurve3d result = new OdGeCompositeCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve3d mirror(OdGePlane plane)
	{
		OdGeCompositeCurve3d result = new OdGeCompositeCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeCompositeCurve3d result = new OdGeCompositeCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCompositeCurve3d scaleBy(double scaleFactor)
	{
		OdGeCompositeCurve3d result = new OdGeCompositeCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCompositeCurve3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCompositeCurve3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCompositeCurve3d(OdGeCompositeCurve3d source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCompositeCurve3d__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCompositeCurve3d(OdGeCurve3dPtrArray curveList)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCompositeCurve3d__SWIG_2(OdGeCurve3dPtrArray.getCPtr(curveList)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCurveList(OdGeCurve3dPtrArray curveList)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_getCurveList__SWIG_0(swigCPtr, OdGeCurve3dPtrArray.getCPtr(curveList));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCurve3dPtrArray getCurveList()
	{
		OdGeCurve3dPtrArray result = new OdGeCurve3dPtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_getCurveList__SWIG_1(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCompositeCurve3d setCurveList(OdGeCurve3dPtrArray curveList)
	{
		OdGeCompositeCurve3d result = new OdGeCompositeCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_setCurveList(swigCPtr, OdGeCurve3dPtrArray.getCPtr(curveList)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double globalToLocalParam(double param, out int crvNum)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_globalToLocalParam(swigCPtr, param, out crvNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double localToGlobalParam(double param, int crvNum)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_localToGlobalParam(swigCPtr, param, crvNum);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCompositeCurve3d Assign(OdGeCompositeCurve3d compCurve)
	{
		OdGeCompositeCurve3d result = new OdGeCompositeCurve3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCompositeCurve3d_Assign(swigCPtr, getCPtr(compCurve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCone : OdGeSurface
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCone(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCone obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCone(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeCone copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_copy(swigCPtr);
		OdGeCone result = ((intPtr == IntPtr.Zero) ? null : new OdGeCone(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCone transformBy(OdGeMatrix3d xfm)
	{
		OdGeCone result = new OdGeCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCone translateBy(OdGeVector3d translateVec)
	{
		OdGeCone result = new OdGeCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCone rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeCone result = new OdGeCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCone rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeCone result = new OdGeCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCone mirror(OdGePlane plane)
	{
		OdGeCone result = new OdGeCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCone scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeCone result = new OdGeCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCone scaleBy(double scaleFactor)
	{
		OdGeCone result = new OdGeCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCone()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCone__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCone(double cosineAngle, double sineAngle, OdGePoint3d baseOrigin, double baseRadius, OdGeVector3d axisOfSymmetry)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCone__SWIG_1(cosineAngle, sineAngle, OdGePoint3d.getCPtr(baseOrigin), baseRadius, OdGeVector3d.getCPtr(axisOfSymmetry)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCone(double cosineAngle, double sineAngle, OdGePoint3d baseOrigin, double baseRadius, OdGeVector3d axisOfSymmetry, OdGeVector3d refAxis, OdGeInterval height, double startAng, double endAng)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCone__SWIG_2(cosineAngle, sineAngle, OdGePoint3d.getCPtr(baseOrigin), baseRadius, OdGeVector3d.getCPtr(axisOfSymmetry), OdGeVector3d.getCPtr(refAxis), OdGeInterval.getCPtr(height), startAng, endAng), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCone(OdGeCone cone)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCone__SWIG_3(getCPtr(cone)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double baseRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_baseRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d baseCenter()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_baseCenter(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getAngles(out double startAng, out double endAng)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_getAngles(swigCPtr, out startAng, out endAng);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double halfAngle()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_halfAngle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getHalfAngle(out double cosineAngle, out double sineAngle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_getHalfAngle(swigCPtr, out cosineAngle, out sineAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getHalfAngleSigned(out double cosineAngle, out double sineAngle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_getHalfAngleSigned(swigCPtr, out cosineAngle, out sineAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getHeight(OdGeInterval height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_getHeight(swigCPtr, OdGeInterval.getCPtr(height));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double heightAt(double u)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_heightAt(swigCPtr, u);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d axisOfSymmetry()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_axisOfSymmetry(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d refAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_refAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d apex()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_apex(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosed(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_isClosed__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_isClosed__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOuterNormal()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_isOuterNormal(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCone setBaseRadius(double baseRadius)
	{
		OdGeCone result = new OdGeCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_setBaseRadius(swigCPtr, baseRadius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCone setAngles(double startAng, double endAng)
	{
		OdGeCone result = new OdGeCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_setAngles(swigCPtr, startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCone setHeight(OdGeInterval height)
	{
		OdGeCone result = new OdGeCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_setHeight(swigCPtr, OdGeInterval.getCPtr(height)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getPoleParam()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_getPoleParam(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCone set(double cosineAngle, double sineAngle, OdGePoint3d baseCenter, double baseRadius, OdGeVector3d axisOfSymmetry)
	{
		OdGeCone result = new OdGeCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_set__SWIG_0(swigCPtr, cosineAngle, sineAngle, OdGePoint3d.getCPtr(baseCenter), baseRadius, OdGeVector3d.getCPtr(axisOfSymmetry)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCone set(double cosineAngle, double sineAngle, OdGePoint3d baseCenter, double baseRadius, OdGeVector3d axisOfSymmetry, OdGeVector3d refAxis, OdGeInterval height, double startAng, double endAng)
	{
		OdGeCone result = new OdGeCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_set__SWIG_1(swigCPtr, cosineAngle, sineAngle, OdGePoint3d.getCPtr(baseCenter), baseRadius, OdGeVector3d.getCPtr(axisOfSymmetry), OdGeVector3d.getCPtr(refAxis), OdGeInterval.getCPtr(height), startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCone Assign(OdGeCone cone)
	{
		OdGeCone result = new OdGeCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_Assign(swigCPtr, getCPtr(cone)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d linEnt, out int numInt, OdGePoint3d p1, OdGePoint3d p2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_intersectWith__SWIG_0(swigCPtr, OdGeLinearEnt3d.getCPtr(linEnt), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d linEnt, out int numInt, OdGePoint3d p1, OdGePoint3d p2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_intersectWith__SWIG_1(swigCPtr, OdGeLinearEnt3d.getCPtr(linEnt), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getUParamScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_getUParamScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUParamScale(double uScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_setUParamScale__SWIG_0(swigCPtr, uScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUParamScale()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCone_setUParamScale__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

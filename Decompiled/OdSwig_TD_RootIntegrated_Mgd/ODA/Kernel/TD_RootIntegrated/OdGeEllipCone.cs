using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeEllipCone : OdGeSurface
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeEllipCone(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeEllipCone obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeEllipCone(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeEllipCone copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_copy(swigCPtr);
		OdGeEllipCone result = ((intPtr == IntPtr.Zero) ? null : new OdGeEllipCone(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCone transformBy(OdGeMatrix3d xfm)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCone translateBy(OdGeVector3d translateVec)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCone rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCone rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCone mirror(OdGePlane plane)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCone scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCone scaleBy(double scaleFactor)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCone()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipCone__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipCone(double cosineAngle, double sineAngle, OdGePoint3d origin, double minorRadius, double majorRadius, OdGeVector3d axisOfSymmetry)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipCone__SWIG_1(cosineAngle, sineAngle, OdGePoint3d.getCPtr(origin), minorRadius, majorRadius, OdGeVector3d.getCPtr(axisOfSymmetry)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipCone(double cosineAngle, double sineAngle, OdGePoint3d baseOrigin, double minorRadius, double majorRadius, OdGeVector3d axisOfSymmetry, OdGeVector3d majorAxis, OdGeInterval height, double startAng, double endAng)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipCone__SWIG_2(cosineAngle, sineAngle, OdGePoint3d.getCPtr(baseOrigin), minorRadius, majorRadius, OdGeVector3d.getCPtr(axisOfSymmetry), OdGeVector3d.getCPtr(majorAxis), OdGeInterval.getCPtr(height), startAng, endAng), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipCone(OdGeEllipCone cone)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipCone__SWIG_3(getCPtr(cone)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double radiusRatio()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_radiusRatio(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double minorRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_minorRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double majorRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_majorRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d baseCenter()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_baseCenter(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getAngles(out double startAng, out double endAng)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_getAngles(swigCPtr, out startAng, out endAng);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double halfAngle()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_halfAngle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getHalfAngle(out double cosineAngle, out double sineAngle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_getHalfAngle(swigCPtr, out cosineAngle, out sineAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getHeight(OdGeInterval height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_getHeight(swigCPtr, OdGeInterval.getCPtr(height));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double heightAt(double u)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_heightAt(swigCPtr, u);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d axisOfSymmetry()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_axisOfSymmetry(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d majorAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_majorAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d minorAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_minorAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d apex()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_apex(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosed(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_isClosed__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_isClosed__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOuterNormal()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_isOuterNormal(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCone setMinorRadius(double minorRadius)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_setMinorRadius(swigCPtr, minorRadius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCone setMajorRadius(double majorRadius)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_setMajorRadius(swigCPtr, majorRadius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCone setAngles(double startAng, double endAng)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_setAngles(swigCPtr, startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCone setHeight(OdGeInterval height)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_setHeight(swigCPtr, OdGeInterval.getCPtr(height)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getPoleParam()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_getPoleParam(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d linEnt, out int numInt, OdGePoint3d p1, OdGePoint3d p2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_intersectWith__SWIG_0(swigCPtr, OdGeLinearEnt3d.getCPtr(linEnt), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d linEnt, out int numInt, OdGePoint3d p1, OdGePoint3d p2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_intersectWith__SWIG_1(swigCPtr, OdGeLinearEnt3d.getCPtr(linEnt), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCone set(double cosineAngle, double sineAngle, OdGePoint3d center, double minorRadius, double majorRadius, OdGeVector3d axisOfSymmetry)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_set__SWIG_0(swigCPtr, cosineAngle, sineAngle, OdGePoint3d.getCPtr(center), minorRadius, majorRadius, OdGeVector3d.getCPtr(axisOfSymmetry)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCone set(double cosineAngle, double sineAngle, OdGePoint3d center, double minorRadius, double majorRadius, OdGeVector3d axisOfSymmetry, OdGeVector3d majorAxis, OdGeInterval height, double startAng, double endAng)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_set__SWIG_1(swigCPtr, cosineAngle, sineAngle, OdGePoint3d.getCPtr(center), minorRadius, majorRadius, OdGeVector3d.getCPtr(axisOfSymmetry), OdGeVector3d.getCPtr(majorAxis), OdGeInterval.getCPtr(height), startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCone Assign(OdGeEllipCone cone)
	{
		OdGeEllipCone result = new OdGeEllipCone(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_Assign(swigCPtr, getCPtr(cone)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getUParamScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_getUParamScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUParamScale(double uScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_setUParamScale__SWIG_0(swigCPtr, uScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUParamScale()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCone_setUParamScale__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

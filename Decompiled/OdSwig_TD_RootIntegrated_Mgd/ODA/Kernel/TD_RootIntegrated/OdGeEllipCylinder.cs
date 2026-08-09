using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeEllipCylinder : OdGeSurface
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeEllipCylinder(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeEllipCylinder obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeEllipCylinder(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeEllipCylinder copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_copy(swigCPtr);
		OdGeEllipCylinder result = ((intPtr == IntPtr.Zero) ? null : new OdGeEllipCylinder(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCylinder transformBy(OdGeMatrix3d xfm)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCylinder translateBy(OdGeVector3d translateVec)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCylinder rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCylinder rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCylinder mirror(OdGePlane plane)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCylinder scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeEllipCylinder scaleBy(double scaleFactor)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCylinder()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipCylinder__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipCylinder(double minorRadius, double majorRadius, OdGePoint3d origin, OdGeVector3d axisOfSymmetry)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipCylinder__SWIG_1(minorRadius, majorRadius, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(axisOfSymmetry)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipCylinder(double minorRadius, double majorRadius, OdGePoint3d origin, OdGeVector3d axisOfSymmetry, OdGeVector3d majorAxis, OdGeInterval height, double startAng, double endAng)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipCylinder__SWIG_2(minorRadius, majorRadius, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(axisOfSymmetry), OdGeVector3d.getCPtr(majorAxis), OdGeInterval.getCPtr(height), startAng, endAng), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipCylinder(OdGeEllipCylinder cylinder)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeEllipCylinder__SWIG_3(getCPtr(cylinder)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double radiusRatio()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_radiusRatio(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double minorRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_minorRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double majorRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_majorRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d origin()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_origin(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getAngles(out double startAng, out double endAng)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_getAngles(swigCPtr, out startAng, out endAng);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getHeight(OdGeInterval height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_getHeight(swigCPtr, OdGeInterval.getCPtr(height));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double heightAt(double u)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_heightAt(swigCPtr, u);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d axisOfSymmetry()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_axisOfSymmetry(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d majorAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_majorAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d minorAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_minorAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOuterNormal()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_isOuterNormal(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosed(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_isClosed__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_isClosed__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIsOuterNormal(bool isOuterNormal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_setIsOuterNormal(swigCPtr, isOuterNormal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeEllipCylinder setMinorRadius(double minorRadius)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_setMinorRadius(swigCPtr, minorRadius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCylinder setMajorRadius(double majorRadius)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_setMajorRadius(swigCPtr, majorRadius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCylinder setAngles(double startAng, double endAng)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_setAngles(swigCPtr, startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCylinder setHeight(OdGeInterval height)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_setHeight(swigCPtr, OdGeInterval.getCPtr(height)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCylinder set(double minorRadius, double majorRadius, OdGePoint3d origin, OdGeVector3d axisOfSymmetry)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_set__SWIG_0(swigCPtr, minorRadius, majorRadius, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(axisOfSymmetry)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCylinder set(double minorRadius, double majorRadius, OdGePoint3d origin, OdGeVector3d axisOfSymmetry, OdGeVector3d majorAxis, OdGeInterval height, double startAng, double endAng)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_set__SWIG_1(swigCPtr, minorRadius, majorRadius, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(axisOfSymmetry), OdGeVector3d.getCPtr(majorAxis), OdGeInterval.getCPtr(height), startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d linEnt, out int numInt, OdGePoint3d p1, OdGePoint3d p2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_intersectWith__SWIG_0(swigCPtr, OdGeLinearEnt3d.getCPtr(linEnt), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d linEnt, out int numInt, OdGePoint3d p1, OdGePoint3d p2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_intersectWith__SWIG_1(swigCPtr, OdGeLinearEnt3d.getCPtr(linEnt), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeEllipCylinder Assign(OdGeEllipCylinder cylinder)
	{
		OdGeEllipCylinder result = new OdGeEllipCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_Assign(swigCPtr, getCPtr(cylinder)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getUParamScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_getUParamScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUParamScale(double uScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_setUParamScale__SWIG_0(swigCPtr, uScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUParamScale()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipCylinder_setUParamScale__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

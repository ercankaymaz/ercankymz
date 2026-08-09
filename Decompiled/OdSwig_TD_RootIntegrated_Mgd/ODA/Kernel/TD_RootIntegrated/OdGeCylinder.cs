using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeCylinder : OdGeSurface
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeCylinder(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeCylinder obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeCylinder(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeCylinder copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_copy(swigCPtr);
		OdGeCylinder result = ((intPtr == IntPtr.Zero) ? null : new OdGeCylinder(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCylinder transformBy(OdGeMatrix3d xfm)
	{
		OdGeCylinder result = new OdGeCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCylinder translateBy(OdGeVector3d translateVec)
	{
		OdGeCylinder result = new OdGeCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCylinder rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeCylinder result = new OdGeCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCylinder rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeCylinder result = new OdGeCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCylinder mirror(OdGePlane plane)
	{
		OdGeCylinder result = new OdGeCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCylinder scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeCylinder result = new OdGeCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeCylinder scaleBy(double scaleFactor)
	{
		OdGeCylinder result = new OdGeCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCylinder()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCylinder__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCylinder(double radius, OdGePoint3d origin, OdGeVector3d axisOfSymmetry)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCylinder__SWIG_1(radius, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(axisOfSymmetry)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCylinder(double radius, OdGePoint3d origin, OdGeVector3d axisOfSymmetry, OdGeVector3d refAxis, OdGeInterval height, double startAng, double endAng)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCylinder__SWIG_2(radius, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(axisOfSymmetry), OdGeVector3d.getCPtr(refAxis), OdGeInterval.getCPtr(height), startAng, endAng), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeCylinder(OdGeCylinder cylinder)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeCylinder__SWIG_3(getCPtr(cylinder)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double radius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_radius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d origin()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_origin(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getAngles(out double startAng, out double endAng)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_getAngles(swigCPtr, out startAng, out endAng);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getHeight(OdGeInterval height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_getHeight(swigCPtr, OdGeInterval.getCPtr(height));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double heightAt(double u)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_heightAt(swigCPtr, u);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d axisOfSymmetry()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_axisOfSymmetry(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d refAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_refAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOuterNormal()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_isOuterNormal(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosed(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_isClosed__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isClosed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_isClosed__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCylinder setRadius(double radius)
	{
		OdGeCylinder result = new OdGeCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_setRadius(swigCPtr, radius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCylinder setAngles(double startAng, double endAng)
	{
		OdGeCylinder result = new OdGeCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_setAngles(swigCPtr, startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCylinder setHeight(OdGeInterval height)
	{
		OdGeCylinder result = new OdGeCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_setHeight(swigCPtr, OdGeInterval.getCPtr(height)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCylinder set(double radius, OdGePoint3d origin, OdGeVector3d axisOfSym)
	{
		OdGeCylinder result = new OdGeCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_set__SWIG_0(swigCPtr, radius, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(axisOfSym)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCylinder set(double radius, OdGePoint3d origin, OdGeVector3d axisOfSymmetry, OdGeVector3d refAxis, OdGeInterval height, double startAng, double endAng)
	{
		OdGeCylinder result = new OdGeCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_set__SWIG_1(swigCPtr, radius, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(axisOfSymmetry), OdGeVector3d.getCPtr(refAxis), OdGeInterval.getCPtr(height), startAng, endAng), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d linEnt, out int numInt, OdGePoint3d p1, OdGePoint3d p2, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_intersectWith__SWIG_0(swigCPtr, OdGeLinearEnt3d.getCPtr(linEnt), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d linEnt, out int numInt, OdGePoint3d p1, OdGePoint3d p2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_intersectWith__SWIG_1(swigCPtr, OdGeLinearEnt3d.getCPtr(linEnt), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeCylinder Assign(OdGeCylinder cylinder)
	{
		OdGeCylinder result = new OdGeCylinder(TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_Assign(swigCPtr, getCPtr(cylinder)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIsOuterNormal(bool isOuterNormal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_setIsOuterNormal(swigCPtr, isOuterNormal);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double getUParamScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_getUParamScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUParamScale(double uScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_setUParamScale__SWIG_0(swigCPtr, uScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUParamScale()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeCylinder_setUParamScale__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

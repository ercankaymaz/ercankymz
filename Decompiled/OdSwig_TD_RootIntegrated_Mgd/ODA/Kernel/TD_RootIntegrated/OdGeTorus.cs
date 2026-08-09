using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeTorus : OdGeSurface
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeTorus(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeTorus obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeTorus(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeTorus copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_copy(swigCPtr);
		OdGeTorus result = ((intPtr == IntPtr.Zero) ? null : new OdGeTorus(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeTorus transformBy(OdGeMatrix3d xfm)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeTorus translateBy(OdGeVector3d translateVec)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeTorus rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeTorus rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeTorus mirror(OdGePlane plane)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeTorus scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeTorus scaleBy(double scaleFactor)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeTorus()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeTorus__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeTorus(double majorRadius, double minorRadius, OdGePoint3d center, OdGeVector3d axisOfSymmetry)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeTorus__SWIG_1(majorRadius, minorRadius, OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(axisOfSymmetry)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeTorus(double majorRadius, double minorRadius, OdGePoint3d center, OdGeVector3d axisOfSymmetry, OdGeVector3d refAxis, double startAngleU, double endAngleU, double startAngleV, double endAngleV)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeTorus__SWIG_2(majorRadius, minorRadius, OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(axisOfSymmetry), OdGeVector3d.getCPtr(refAxis), startAngleU, endAngleU, startAngleV, endAngleV), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeTorus(OdGeTorus source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeTorus__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double majorRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_majorRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double minorRadius()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_minorRadius(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getAnglesInU(out double startAngleU, out double endAngleU)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_getAnglesInU(swigCPtr, out startAngleU, out endAngleU);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getAnglesInV(out double startAngleV, out double endAngleV)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_getAnglesInV(swigCPtr, out startAngleV, out endAngleV);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d center()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_center(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d axisOfSymmetry()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_axisOfSymmetry(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d refAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_refAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOuterNormal()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_isOuterNormal(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeTorus setMajorRadius(double radius)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_setMajorRadius(swigCPtr, radius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeTorus setMinorRadius(double radius)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_setMinorRadius(swigCPtr, radius), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeTorus setAnglesInU(double startAngleU, double endAngleU)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_setAnglesInU(swigCPtr, startAngleU, endAngleU), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeTorus setAnglesInV(double startAngleV, double endAngleV)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_setAnglesInV(swigCPtr, startAngleV, endAngleV), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeTorus set(double majorRadius, double minorRadius, OdGePoint3d center, OdGeVector3d axisOfSymmetry)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_set__SWIG_0(swigCPtr, majorRadius, minorRadius, OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(axisOfSymmetry)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeTorus set(double majorRadius, double minorRadius, OdGePoint3d center, OdGeVector3d axisOfSymmetry, OdGeVector3d refAxis, double startAngleU, double endAngleU, double startAngleV, double endAngleV)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_set__SWIG_1(swigCPtr, majorRadius, minorRadius, OdGePoint3d.getCPtr(center), OdGeVector3d.getCPtr(axisOfSymmetry), OdGeVector3d.getCPtr(refAxis), startAngleU, endAngleU, startAngleV, endAngleV), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeTorus Assign(OdGeTorus torus)
	{
		OdGeTorus result = new OdGeTorus(TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_Assign(swigCPtr, getCPtr(torus)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d linEnt, out int numInt, OdGePoint3d p1, OdGePoint3d p2, OdGePoint3d p3, OdGePoint3d p4, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_intersectWith__SWIG_0(swigCPtr, OdGeLinearEnt3d.getCPtr(linEnt), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2), OdGePoint3d.getCPtr(p3), OdGePoint3d.getCPtr(p4), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeLinearEnt3d linEnt, out int numInt, OdGePoint3d p1, OdGePoint3d p2, OdGePoint3d p3, OdGePoint3d p4)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_intersectWith__SWIG_1(swigCPtr, OdGeLinearEnt3d.getCPtr(linEnt), out numInt, OdGePoint3d.getCPtr(p1), OdGePoint3d.getCPtr(p2), OdGePoint3d.getCPtr(p3), OdGePoint3d.getCPtr(p4));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLemon()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_isLemon(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isApple()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_isApple(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isVortex()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_isVortex(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDoughnut()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_isDoughnut(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDegenerate()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_isDegenerate(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isHollow()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_isHollow(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isReverseV()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_isReverseV(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setReverseV(bool isReverseV)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeTorus_setReverseV(swigCPtr, isReverseV);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

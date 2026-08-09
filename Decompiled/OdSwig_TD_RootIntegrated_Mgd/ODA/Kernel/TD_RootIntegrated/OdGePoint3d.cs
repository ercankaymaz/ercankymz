using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGePoint3d : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static OdGePoint3d kOrigin
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_kOrigin_get();
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return new OdGePoint3d((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
		}
	}

	public double x
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_x_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_x_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double y
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_y_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_y_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double z
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_z_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_z_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGePoint3d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGePoint3d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGePoint3d()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGePoint3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdGePoint3d operator +(OdGePoint3d p, OdGeVector3d v)
	{
		return p.Add(v);
	}

	public static OdGePoint3d operator -(OdGePoint3d p, OdGeVector3d v)
	{
		return p.Sub(v);
	}

	public static OdGeVector3d operator -(OdGePoint3d p, OdGePoint3d v)
	{
		return p.Sub(v);
	}

	public static OdGePoint3d operator *(OdGePoint3d v, double d)
	{
		return v.Mul(d);
	}

	public override string ToString()
	{
		if (swigCPtr.Handle == IntPtr.Zero)
		{
			return "Empty";
		}
		return $"({x},{y},{z})";
	}

	public OdGePoint3d(OdGePoint3d point)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePoint3d__SWIG_1(point.x, point.y, point.z), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePoint3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d(double xx, double yy, double zz)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePoint3d__SWIG_1(xx, yy, zz), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d(OdGePlanarEnt plane, OdGePoint2d pnt2d)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePoint3d__SWIG_2(OdGePlanarEnt.getCPtr(plane), OdGePoint2d.getCPtr(pnt2d)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d setToProduct(OdGeMatrix3d xfm, OdGePoint3d point)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_setToProduct(swigCPtr, OdGeMatrix3d.getCPtr(xfm), getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint3d(this);
	}

	public OdGePoint3d transformBy(OdGeMatrix3d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_transformBy__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint3d(this);
	}

	public OdGePoint3d transformBy(OdGeMatrix3d xfm, out OdGe_ErrorCondition status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_transformBy__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(xfm), out status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint3d(this);
	}

	public OdGePoint3d rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), getCPtr(basePoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint3d(this);
	}

	public OdGePoint3d rotateBy(double angle, OdGeVector3d vect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint3d(this);
	}

	public OdGePoint3d mirror(OdGePlane plane)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_mirror(swigCPtr, OdGePlane.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint3d(this);
	}

	public OdGePoint3d scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_scaleBy__SWIG_0(swigCPtr, scaleFactor, getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d scaleBy(double scaleFactor)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d convert2d(OdGePlanarEnt plane)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_convert2d__SWIG_0(swigCPtr, OdGePlanarEnt.getCPtr(plane)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d convert2d()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_convert2d__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d Mul(double scale)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_Mul__SWIG_0(swigCPtr, scale), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d Div(double scale)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_Div__SWIG_0(swigCPtr, scale), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d Add(OdGeVector3d vect)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_Add__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(vect)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d Sub(OdGeVector3d vect)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_Sub__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(vect)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d setToSum(OdGePoint3d point, OdGeVector3d vect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_setToSum(swigCPtr, getCPtr(point), OdGeVector3d.getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint3d(this);
	}

	public OdGeVector3d Sub(OdGePoint3d point)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_Sub__SWIG_2(swigCPtr, getCPtr(point)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d asVector()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_asVector__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceTo(OdGePoint3d point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_distanceTo(swigCPtr, getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceSqrdTo(OdGePoint3d point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_distanceSqrdTo(swigCPtr, getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d project(OdGePlanarEnt plane, OdGeVector3d vect)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_project(swigCPtr, OdGePlanarEnt.getCPtr(plane), OdGeVector3d.getCPtr(vect)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d orthoProject(OdGePlane plane)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_orthoProject(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_IsEqual(swigCPtr, getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_IsNotEqual(swigCPtr, getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGePoint3d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_isEqualTo__SWIG_0(swigCPtr, getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_isEqualTo__SWIG_1(swigCPtr, getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double GetItem(uint i)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_GetItem__SWIG_0(swigCPtr, i);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d set(double xx, double yy, double zz)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_set__SWIG_0(swigCPtr, xx, yy, zz);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint3d(this);
	}

	public OdGePoint3d set(OdGePoint2d xy, double zz)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_set__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(xy), zz);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint3d(this);
	}

	public OdGePoint3d set(OdGePoint2d xy)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_set__SWIG_2(swigCPtr, OdGePoint2d.getCPtr(xy));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint3d(this);
	}

	public OdGePoint3d set(OdGePlanarEnt plane, OdGePoint2d point)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_set__SWIG_3(swigCPtr, OdGePlanarEnt.getCPtr(plane), OdGePoint2d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint3d(this);
	}

	public OdGePoint3d swapWithPoint(OdGePoint3d point)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint3d_swapWithPoint(swigCPtr, getCPtr(point)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

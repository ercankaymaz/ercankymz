using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeVector3d : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static OdGeVector3d kIdentity
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_kIdentity_get();
			OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static OdGeVector3d kXAxis
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_kXAxis_get();
			OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static OdGeVector3d kYAxis
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_kYAxis_get();
			OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static OdGeVector3d kZAxis
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_kZAxis_get();
			OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public double x
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_x_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_x_set(swigCPtr, value);
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
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_y_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_y_set(swigCPtr, value);
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
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_z_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_z_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeVector3d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeVector3d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeVector3d()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeVector3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdGeVector3d operator *(OdGeVector3d v, double d)
	{
		return v.Mul(d);
	}

	public static OdGeVector3d operator -(OdGeVector3d v, OdGeVector3d d)
	{
		return v.Sub(d);
	}

	public static OdGeVector3d operator +(OdGeVector3d v, OdGeVector3d d)
	{
		return v.Add(d);
	}

	public static OdGeVector3d operator -(OdGeVector3d v)
	{
		return v.Sub();
	}

	public static OdGeVector3d operator /(OdGeVector3d v, double scale)
	{
		return v.Div(scale);
	}

	public override string ToString()
	{
		if (swigCPtr.Handle == IntPtr.Zero)
		{
			return "Empty";
		}
		return $"({x},{y},{z})";
	}

	public OdGeVector3d(OdGeVector3d vect)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeVector3d__SWIG_1(vect.x, vect.y, vect.z), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeVector3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d(double xx, double yy, double zz)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeVector3d__SWIG_1(xx, yy, zz), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d(OdGePlanarEnt plane, OdGeVector2d vector2d)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeVector3d__SWIG_2(OdGePlanarEnt.getCPtr(plane), OdGeVector2d.getCPtr(vector2d).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d setToProduct(OdGeMatrix3d matrix, OdGeVector3d vect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_setToProduct__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(matrix), getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector3d(this);
	}

	public OdGeVector3d setToProduct(OdGeVector3d vect, double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_setToProduct__SWIG_1(swigCPtr, getCPtr(vect), scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector3d(this);
	}

	public OdGeVector3d transformBy(OdGeMatrix3d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector3d(this);
	}

	public OdGeVector3d rotateBy(double angle, OdGeVector3d axis)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_rotateBy(swigCPtr, angle, getCPtr(axis));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector3d(this);
	}

	public OdGeVector3d mirror(OdGeVector3d normalToPlane)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_mirror(swigCPtr, getCPtr(normalToPlane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector3d(this);
	}

	public OdGeVector2d convert2d(OdGePlanarEnt plane)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_convert2d__SWIG_0(swigCPtr, OdGePlanarEnt.getCPtr(plane)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d convert2d()
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_convert2d__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d Mul(double scale)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_Mul__SWIG_0(swigCPtr, scale), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d Div(double scale)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_Div__SWIG_0(swigCPtr, scale), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d Add(OdGeVector3d vect)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_Add__SWIG_0(swigCPtr, getCPtr(vect)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d Sub(OdGeVector3d vect)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_Sub__SWIG_0(swigCPtr, getCPtr(vect)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d asPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_asPoint__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d setToSum(OdGeVector3d vector1, OdGeVector3d vector2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_setToSum(swigCPtr, getCPtr(vector1), getCPtr(vector2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector3d(this);
	}

	public OdGeVector3d Sub()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_Sub__SWIG_2(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d negate()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_negate(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector3d(this);
	}

	public OdGeVector3d perpVector()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_perpVector(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double angleTo(OdGeVector3d vect)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_angleTo__SWIG_0(swigCPtr, getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double angleTo(OdGeVector3d vect, OdGeVector3d refVector)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_angleTo__SWIG_1(swigCPtr, getCPtr(vect), getCPtr(refVector));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double angleOnPlane(OdGePlanarEnt plane)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_angleOnPlane(swigCPtr, OdGePlanarEnt.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d normal(OdGeTol tol)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_normal__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d normal()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_normal__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d normalize(OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_normalize__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector3d(this);
	}

	public OdGeVector3d normalize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_normalize__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector3d(this);
	}

	public OdGeVector3d normalize(OdGeTol tol, out OdGe_ErrorCondition status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_normalize__SWIG_2(swigCPtr, OdGeTol.getCPtr(tol), out status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector3d(this);
	}

	public double normalizeGetLength(double tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_normalizeGetLength__SWIG_0(swigCPtr, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double normalizeGetLength()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_normalizeGetLength__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double length()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_length(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLength(double length)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_setLength(swigCPtr, length);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double lengthSqrd()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_lengthSqrd(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isUnitLength(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isUnitLength__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isUnitLength()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isUnitLength__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isZeroLength(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isZeroLength__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isZeroLength()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isZeroLength__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGeVector3d vect, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isParallelTo__SWIG_0(swigCPtr, getCPtr(vect), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGeVector3d vect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isParallelTo__SWIG_1(swigCPtr, getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGeVector3d vect, OdGeTol tol, out OdGe_ErrorCondition status)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isParallelTo__SWIG_2(swigCPtr, getCPtr(vect), OdGeTol.getCPtr(tol), out status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCodirectionalTo(OdGeVector3d vect, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isCodirectionalTo__SWIG_0(swigCPtr, getCPtr(vect), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCodirectionalTo(OdGeVector3d vect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isCodirectionalTo__SWIG_1(swigCPtr, getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCodirectionalTo(OdGeVector3d vect, OdGeTol tol, out OdGe_ErrorCondition status)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isCodirectionalTo__SWIG_2(swigCPtr, getCPtr(vect), OdGeTol.getCPtr(tol), out status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGeVector3d vect, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isPerpendicularTo__SWIG_0(swigCPtr, getCPtr(vect), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGeVector3d vect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isPerpendicularTo__SWIG_1(swigCPtr, getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGeVector3d vect, OdGeTol tol, out OdGe_ErrorCondition status)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isPerpendicularTo__SWIG_2(swigCPtr, getCPtr(vect), OdGeTol.getCPtr(tol), out status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double dotProduct(OdGeVector3d vect)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_dotProduct(swigCPtr, getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d crossProduct(OdGeVector3d vect)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_crossProduct(swigCPtr, getCPtr(vect)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d project(OdGeVector3d planeNormal, OdGeVector3d projectDirection)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_project__SWIG_0(swigCPtr, getCPtr(planeNormal), getCPtr(projectDirection)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d project(OdGeVector3d planeNormal, OdGeVector3d projectDirection, OdGeTol tol, out OdGe_ErrorCondition flag)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_project__SWIG_1(swigCPtr, getCPtr(planeNormal), getCPtr(projectDirection), OdGeTol.getCPtr(tol), out flag), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d orthoProject(OdGeVector3d planeNormal)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_orthoProject__SWIG_0(swigCPtr, getCPtr(planeNormal)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d orthoProject(OdGeVector3d planeNormal, OdGeTol tol, out OdGe_ErrorCondition flag)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_orthoProject__SWIG_1(swigCPtr, getCPtr(planeNormal), OdGeTol.getCPtr(tol), out flag), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGeVector3d vect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_IsEqual(swigCPtr, getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGeVector3d vect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_IsNotEqual(swigCPtr, getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeVector3d vect, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isEqualTo__SWIG_0(swigCPtr, getCPtr(vect), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeVector3d vect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_isEqualTo__SWIG_1(swigCPtr, getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double GetItem(uint i)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_GetItem__SWIG_0(swigCPtr, i);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint largestElement()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_largestElement(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d set(double xx, double yy, double zz)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_set__SWIG_0(swigCPtr, xx, yy, zz);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector3d(this);
	}

	public OdGeVector3d set(OdGePlanarEnt plane, OdGeVector2d vect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector3d_set__SWIG_1(swigCPtr, OdGePlanarEnt.getCPtr(plane), OdGeVector2d.getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector3d(this);
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeVector2d : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static OdGeVector2d kIdentity
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_kIdentity_get();
			OdGeVector2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector2d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static OdGeVector2d kXAxis
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_kXAxis_get();
			OdGeVector2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector2d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static OdGeVector2d kYAxis
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_kYAxis_get();
			OdGeVector2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector2d(intPtr, cMemoryOwn: false));
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
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_x_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_x_set(swigCPtr, value);
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
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_y_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_y_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeVector2d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeVector2d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeVector2d()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeVector2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdGeVector2d operator *(OdGeVector2d v, double d)
	{
		return v.Mul(d);
	}

	public static OdGeVector2d operator -(OdGeVector2d v, OdGeVector2d d)
	{
		return v.Sub(d);
	}

	public static OdGeVector2d operator +(OdGeVector2d v, OdGeVector2d d)
	{
		return v.Add(d);
	}

	public static OdGeVector2d operator -(OdGeVector2d v)
	{
		return v.Sub();
	}

	public static OdGeVector2d operator /(OdGeVector2d v, double scale)
	{
		return v.Div(scale);
	}

	public override string ToString()
	{
		if (swigCPtr.Handle == IntPtr.Zero)
		{
			return "Empty";
		}
		return $"({x},{y})";
	}

	public OdGeVector2d(OdGeVector2d vect)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeVector2d__SWIG_1(vect.x, vect.y), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeVector2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector2d(double xx, double yy)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeVector2d__SWIG_1(xx, yy), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector2d setToProduct(OdGeMatrix2d matrix, OdGeVector2d vect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_setToProduct__SWIG_0(swigCPtr, OdGeMatrix2d.getCPtr(matrix), getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector2d(this);
	}

	public OdGeVector2d setToProduct(OdGeVector2d vect, double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_setToProduct__SWIG_1(swigCPtr, getCPtr(vect).Handle, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector2d(this);
	}

	public OdGeVector2d transformBy(OdGeMatrix2d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector2d(this);
	}

	public OdGeVector2d rotateBy(double angle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_rotateBy(swigCPtr, angle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector2d(this);
	}

	public OdGeVector2d mirror(OdGeVector2d line)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_mirror(swigCPtr, getCPtr(line).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector2d(this);
	}

	public OdGeVector2d Mul(double scale)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_Mul__SWIG_0(swigCPtr, scale), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d Div(double scale)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_Div__SWIG_0(swigCPtr, scale), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d Add(OdGeVector2d vect)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_Add__SWIG_0(swigCPtr, getCPtr(vect).Handle), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d Sub(OdGeVector2d vect)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_Sub__SWIG_0(swigCPtr, getCPtr(vect).Handle), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d asPoint()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_asPoint__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d setToSum(OdGeVector2d vector1, OdGeVector2d vector2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_setToSum(swigCPtr, getCPtr(vector1).Handle, getCPtr(vector2).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector2d(this);
	}

	public OdGeVector2d Sub()
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_Sub__SWIG_2(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d negate()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_negate(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector2d(this);
	}

	public OdGeVector2d perpVector()
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_perpVector(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double angle()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_angle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double angleTo(OdGeVector2d vect)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_angleTo(swigCPtr, getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double angleToCCW(OdGeVector2d vect)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_angleToCCW(swigCPtr, getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d normal(OdGeTol tol)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_normal__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d normal()
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_normal__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d normalize(OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_normalize__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector2d(this);
	}

	public OdGeVector2d normalize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_normalize__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector2d(this);
	}

	public OdGeVector2d normalize(OdGeTol tol, out OdGe_ErrorCondition status)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_normalize__SWIG_2(swigCPtr, OdGeTol.getCPtr(tol), out status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector2d(this);
	}

	public double normalizeGetLength(double tol)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_normalizeGetLength__SWIG_0(swigCPtr, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double normalizeGetLength()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_normalizeGetLength__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double length()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_length(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double lengthSqrd()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_lengthSqrd(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isUnitLength(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isUnitLength__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isUnitLength()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isUnitLength__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isZeroLength(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isZeroLength__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isZeroLength()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isZeroLength__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGeVector2d vect, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isParallelTo__SWIG_0(swigCPtr, getCPtr(vect).Handle, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGeVector2d vect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isParallelTo__SWIG_1(swigCPtr, getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isParallelTo(OdGeVector2d vect, OdGeTol tol, out OdGe_ErrorCondition status)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isParallelTo__SWIG_2(swigCPtr, getCPtr(vect).Handle, OdGeTol.getCPtr(tol), out status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCodirectionalTo(OdGeVector2d vect, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isCodirectionalTo__SWIG_0(swigCPtr, getCPtr(vect).Handle, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCodirectionalTo(OdGeVector2d vect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isCodirectionalTo__SWIG_1(swigCPtr, getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCodirectionalTo(OdGeVector2d vect, OdGeTol tol, out OdGe_ErrorCondition status)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isCodirectionalTo__SWIG_2(swigCPtr, getCPtr(vect).Handle, OdGeTol.getCPtr(tol), out status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGeVector2d vect, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isPerpendicularTo__SWIG_0(swigCPtr, getCPtr(vect).Handle, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGeVector2d vect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isPerpendicularTo__SWIG_1(swigCPtr, getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerpendicularTo(OdGeVector2d vect, OdGeTol tol, out OdGe_ErrorCondition status)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isPerpendicularTo__SWIG_2(swigCPtr, getCPtr(vect).Handle, OdGeTol.getCPtr(tol), out status);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double dotProduct(OdGeVector2d vect)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_dotProduct(swigCPtr, getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double crossProduct(OdGeVector2d vect)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_crossProduct(swigCPtr, getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGeVector2d vect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_IsEqual(swigCPtr, getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGeVector2d vect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_IsNotEqual(swigCPtr, getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeVector2d vect, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isEqualTo__SWIG_0(swigCPtr, getCPtr(vect).Handle, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeVector2d vect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_isEqualTo__SWIG_1(swigCPtr, getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double GetItem(uint i)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_GetItem__SWIG_0(swigCPtr, i);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint largestElement()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_largestElement(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d set(double xx, double yy)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeVector2d_set(swigCPtr, xx, yy);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGeVector2d(this);
	}
}

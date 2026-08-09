using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGePoint2d : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static OdGePoint2d kOrigin
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_kOrigin_get();
			OdGePoint2d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint2d(intPtr, cMemoryOwn: false));
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
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_x_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_x_set(swigCPtr, value);
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
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_y_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_y_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGePoint2d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGePoint2d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGePoint2d()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGePoint2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdGePoint2d operator +(OdGePoint2d p, OdGeVector2d v)
	{
		return p.Add(v);
	}

	public static OdGePoint2d operator -(OdGePoint2d p, OdGeVector2d v)
	{
		return p.Sub(v);
	}

	public static OdGePoint2d operator *(OdGePoint2d v, double d)
	{
		return v.Mul(d);
	}

	public override string ToString()
	{
		if (swigCPtr.Handle == IntPtr.Zero)
		{
			return "Empty";
		}
		return $"({x}, {y})";
	}

	public OdGePoint2d(OdGePoint2d point)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePoint2d__SWIG_1(point.x, point.y), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePoint2d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint2d(double xx, double yy)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGePoint2d__SWIG_1(xx, yy), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint2d setToProduct(OdGeMatrix2d matrix, OdGePoint2d point)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_setToProduct(swigCPtr, OdGeMatrix2d.getCPtr(matrix), getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint2d(this);
	}

	public OdGePoint2d transformBy(OdGeMatrix2d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_transformBy(swigCPtr, OdGeMatrix2d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint2d(this);
	}

	public OdGePoint2d rotateBy(double angle, OdGePoint2d basePoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_rotateBy__SWIG_0(swigCPtr, angle, getCPtr(basePoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint2d(this);
	}

	public OdGePoint2d rotateBy(double angle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_rotateBy__SWIG_1(swigCPtr, angle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint2d(this);
	}

	public OdGePoint2d mirror(OdGeLine2d line)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_mirror(swigCPtr, OdGeLine2d.getCPtr(line));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint2d(this);
	}

	public OdGePoint2d scaleBy(double scaleFactor, OdGePoint2d basePoint)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_scaleBy__SWIG_0(swigCPtr, scaleFactor, getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d scaleBy(double scaleFactor)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d Mul(double scale)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_Mul__SWIG_0(swigCPtr, scale), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d Div(double scale)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_Div__SWIG_0(swigCPtr, scale), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d Add(OdGeVector2d vect)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_Add__SWIG_0(swigCPtr, OdGeVector2d.getCPtr(vect).Handle), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d Sub(OdGeVector2d vect)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_Sub__SWIG_0(swigCPtr, OdGeVector2d.getCPtr(vect).Handle), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d setToSum(OdGePoint2d point, OdGeVector2d vect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_setToSum(swigCPtr, getCPtr(point), OdGeVector2d.getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint2d(this);
	}

	public OdGeVector2d Sub(OdGePoint2d point)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_Sub__SWIG_2(swigCPtr, getCPtr(point)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector2d asVector()
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_asVector__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceTo(OdGePoint2d point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_distanceTo(swigCPtr, getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double distanceSqrdTo(OdGePoint2d point)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_distanceSqrdTo(swigCPtr, getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGePoint2d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_IsEqual(swigCPtr, getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGePoint2d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_IsNotEqual(swigCPtr, getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGePoint2d point, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_isEqualTo__SWIG_0(swigCPtr, getCPtr(point), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGePoint2d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_isEqualTo__SWIG_1(swigCPtr, getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double GetItem(uint i)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_GetItem(swigCPtr, i);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d set(double xx, double yy)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGePoint2d_set(swigCPtr, xx, yy);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return new OdGePoint2d(this);
	}
}

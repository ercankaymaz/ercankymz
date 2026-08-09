using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeScale3d : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static OdGeScale3d kIdentity
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_kIdentity_get();
			OdGeScale3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeScale3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public double sx
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_sx_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_sx_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double sy
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_sy_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_sy_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double sz
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_sz_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_sz_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeScale3d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeScale3d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeScale3d()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeScale3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public override string ToString()
	{
		if (swigCPtr.Handle == IntPtr.Zero)
		{
			return "Empty";
		}
		return $"({sx},{sy},{sz})";
	}

	public OdGeScale3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeScale3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeScale3d(double factor)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeScale3d__SWIG_1(factor), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeScale3d(double xFactor, double yFactor, double zFactor)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeScale3d__SWIG_2(xFactor, yFactor, zFactor), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeScale3d Mul(OdGeScale3d scaleVec)
	{
		OdGeScale3d result = new OdGeScale3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_Mul__SWIG_0(swigCPtr, getCPtr(scaleVec)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeScale3d Mul(double factor)
	{
		OdGeScale3d result = new OdGeScale3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_Mul__SWIG_1(swigCPtr, factor), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeScale3d setToProduct(OdGeScale3d scaleVec1, OdGeScale3d scaleVec2)
	{
		OdGeScale3d result = new OdGeScale3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_setToProduct__SWIG_0(swigCPtr, getCPtr(scaleVec1), getCPtr(scaleVec2)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeScale3d setToProduct(OdGeScale3d scaleVec, double factor)
	{
		OdGeScale3d result = new OdGeScale3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_setToProduct__SWIG_1(swigCPtr, getCPtr(scaleVec), factor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeScale3d inverse()
	{
		OdGeScale3d result = new OdGeScale3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_inverse(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeScale3d invert()
	{
		OdGeScale3d result = new OdGeScale3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_invert(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isProportional(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_isProportional__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isProportional()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_isProportional__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGeScale3d scaleVec)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_IsEqual(swigCPtr, getCPtr(scaleVec));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGeScale3d scaleVec)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_IsNotEqual(swigCPtr, getCPtr(scaleVec));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeScale3d scaleVec, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_isEqualTo__SWIG_0(swigCPtr, getCPtr(scaleVec), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeScale3d scaleVec)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_isEqualTo__SWIG_1(swigCPtr, getCPtr(scaleVec));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double GetItem(uint i)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_GetItem__SWIG_0(swigCPtr, i);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeScale3d set(double xFactor, double yFactor, double zFactor)
	{
		OdGeScale3d result = new OdGeScale3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_set(swigCPtr, xFactor, yFactor, zFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getMatrix(OdGeMatrix3d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_getMatrix(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeScale3d extractScale(OdGeMatrix3d xfm)
	{
		OdGeScale3d result = new OdGeScale3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_extractScale(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeScale3d removeScale(OdGeMatrix3d xfm, bool negateX)
	{
		OdGeScale3d result = new OdGeScale3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_removeScale__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(xfm), negateX), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeScale3d removeScale(OdGeMatrix3d xfm)
	{
		OdGeScale3d result = new OdGeScale3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_removeScale__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeScale3d_isValid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

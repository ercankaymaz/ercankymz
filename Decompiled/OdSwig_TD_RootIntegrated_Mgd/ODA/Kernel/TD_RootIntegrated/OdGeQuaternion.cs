using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeQuaternion : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public double w
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_w_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_w_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double x
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_x_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_x_set(swigCPtr, value);
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
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_y_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_y_set(swigCPtr, value);
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
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_z_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_z_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public static OdGeQuaternion kIdentity
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_kIdentity_get();
			OdGeQuaternion result = ((intPtr == IntPtr.Zero) ? null : new OdGeQuaternion(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeQuaternion(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeQuaternion obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeQuaternion()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeQuaternion(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGeQuaternion()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeQuaternion__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeQuaternion(double ww, double xx, double yy, double zz)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeQuaternion__SWIG_1(ww, xx, yy, zz), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeQuaternion set(double ww, double xx, double yy, double zz)
	{
		OdGeQuaternion result = new OdGeQuaternion(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_set__SWIG_0(swigCPtr, ww, xx, yy, zz), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeQuaternion set(OdGeMatrix3d matrix)
	{
		OdGeQuaternion result = new OdGeQuaternion(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_set__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(matrix)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d getMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_getMatrix(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d rotate(OdGePoint3d sourcePoint)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_rotate__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(sourcePoint)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d rotate(OdGeVector3d vector)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_rotate__SWIG_1(swigCPtr, OdGeVector3d.getCPtr(vector)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d rotateOpposite(OdGePoint3d sourcePoint)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_rotateOpposite__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(sourcePoint)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d rotateOpposite(OdGeVector3d vector)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_rotateOpposite__SWIG_1(swigCPtr, OdGeVector3d.getCPtr(vector)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeQuaternion quat, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_isEqualTo__SWIG_0(swigCPtr, getCPtr(quat), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeQuaternion quat)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_isEqualTo__SWIG_1(swigCPtr, getCPtr(quat));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGeQuaternion quat)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_IsEqual(swigCPtr, getCPtr(quat));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGeQuaternion quat)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_IsNotEqual(swigCPtr, getCPtr(quat));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeQuaternion Mul(double scale)
	{
		OdGeQuaternion result = new OdGeQuaternion(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_Mul__SWIG_0(swigCPtr, scale), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeQuaternion Div(double scale)
	{
		OdGeQuaternion result = new OdGeQuaternion(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_Div__SWIG_0(swigCPtr, scale), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeQuaternion Add(OdGeQuaternion quat)
	{
		OdGeQuaternion result = new OdGeQuaternion(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_Add__SWIG_0(swigCPtr, getCPtr(quat)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeQuaternion Sub(OdGeQuaternion quat)
	{
		OdGeQuaternion result = new OdGeQuaternion(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_Sub__SWIG_0(swigCPtr, getCPtr(quat)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeQuaternion Sub()
	{
		OdGeQuaternion result = new OdGeQuaternion(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_Sub__SWIG_2(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double normSqrd()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_normSqrd(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double norm()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_norm(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeQuaternion normalize(OdGeTol tol)
	{
		OdGeQuaternion result = new OdGeQuaternion(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_normalize__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeQuaternion normalize()
	{
		OdGeQuaternion result = new OdGeQuaternion(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_normalize__SWIG_1(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double dotProduct(OdGeQuaternion quat)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_dotProduct(swigCPtr, getCPtr(quat));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeQuaternion slerp(OdGeQuaternion q, double t, bool bUseShortestPath)
	{
		OdGeQuaternion result = new OdGeQuaternion(TD_RootIntegrated_GlobalsPINVOKE.OdGeQuaternion_slerp(swigCPtr, getCPtr(q), t, bUseShortestPath), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

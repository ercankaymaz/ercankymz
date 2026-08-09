using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeMatrix3d : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public double this[int row, int column]
	{
		get
		{
			return GetItem(row, column);
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_entry_set(swigCPtr, row, column, value);
		}
	}

	public static OdGeMatrix3d kIdentity
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_kIdentity_get();
			OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeMatrix3d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeMatrix3d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeMatrix3d()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeMatrix3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdGeMatrix3d operator *(OdGeMatrix3d m, OdGeMatrix3d d)
	{
		return m.Mul(d);
	}

	public static OdGePoint3d operator *(OdGeMatrix3d matrix, OdGePoint3d point)
	{
		return TD_RootIntegrated_Globals.Mul(matrix, point);
	}

	public static OdGeVector3d operator *(OdGeMatrix3d matrix, OdGeVector3d vect)
	{
		return TD_RootIntegrated_Globals.Mul(matrix, vect);
	}

	public OdGeMatrix3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeMatrix3d(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix3d setToIdentity()
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToIdentity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public void validateZero(OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_validateZero__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void validateZero()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_validateZero__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix3d Mul(OdGeMatrix3d matrix)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_Mul__SWIG_0(swigCPtr, getCPtr(matrix)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d preMultBy(OdGeMatrix3d leftSide)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_preMultBy(swigCPtr, getCPtr(leftSide));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d postMultBy(OdGeMatrix3d rightSide)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_postMultBy(swigCPtr, getCPtr(rightSide));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d setToProduct(OdGeMatrix3d matrix1, OdGeMatrix3d matrix2)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToProduct(swigCPtr, getCPtr(matrix1), getCPtr(matrix2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d invert()
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_invert(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d inverse()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_inverse__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d inverse(OdGeTol tol)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_inverse__SWIG_1(swigCPtr, OdGeTol.getCPtr(tol)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool inverse(OdGeMatrix3d inverseMatrix, double tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_inverse__SWIG_2(swigCPtr, getCPtr(inverseMatrix), tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSingular(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_isSingular__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSingular()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_isSingular__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d transposeIt()
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_transposeIt(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d transpose()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_transpose(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGeMatrix3d matrix)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_IsEqual(swigCPtr, getCPtr(matrix));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGeMatrix3d matrix)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_IsNotEqual(swigCPtr, getCPtr(matrix));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeMatrix3d matrix, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_isEqualTo__SWIG_0(swigCPtr, getCPtr(matrix), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeMatrix3d matrix)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_isEqualTo__SWIG_1(swigCPtr, getCPtr(matrix));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isUniScaledOrtho(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_isUniScaledOrtho__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isUniScaledOrtho()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_isUniScaledOrtho__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isScaledOrtho(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_isScaledOrtho__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isScaledOrtho()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_isScaledOrtho__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerspective(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_isPerspective__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPerspective()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_isPerspective__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double det()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_det(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d setTranslation(OdGeVector3d vect)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setTranslation(swigCPtr, OdGeVector3d.getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d setCoordSystem(OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis, OdGeVector3d zAxis)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setCoordSystem(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(zAxis));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public void getCoordSystem(OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis, OdGeVector3d zAxis)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_getCoordSystem(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(zAxis));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d getCsOrigin()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_getCsOrigin(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d getCsXAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_getCsXAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d getCsYAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_getCsYAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d getCsZAxis()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_getCsZAxis(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d setToTranslation(OdGeVector3d vect)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToTranslation(swigCPtr, OdGeVector3d.getCPtr(vect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d setToRotation(double angle, OdGeVector3d axis, OdGePoint3d center)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToRotation__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(axis), OdGePoint3d.getCPtr(center));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d setToRotation(double angle, OdGeVector3d axis)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToRotation__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(axis));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d setToScaling(double scale, OdGePoint3d center)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToScaling__SWIG_0(swigCPtr, scale, OdGePoint3d.getCPtr(center));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d setToScaling(double scale)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToScaling__SWIG_1(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d setToScaling(OdGeScale3d scale, OdGePoint3d center)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToScaling__SWIG_2(swigCPtr, OdGeScale3d.getCPtr(scale), OdGePoint3d.getCPtr(center));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d setToScaling(OdGeScale3d scale)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToScaling__SWIG_3(swigCPtr, OdGeScale3d.getCPtr(scale));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d setToMirroring(OdGePlane mirrorPlane)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToMirroring__SWIG_0(swigCPtr, OdGePlane.getCPtr(mirrorPlane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d setToMirroring(OdGePoint3d mirrorPoint)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToMirroring__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(mirrorPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d setToMirroring(OdGeLine3d mirrorLine)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToMirroring__SWIG_2(swigCPtr, OdGeLine3d.getCPtr(mirrorLine));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d setToProjection(OdGePlane projectionPlane, OdGeVector3d projectDir)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToProjection(swigCPtr, OdGePlane.getCPtr(projectionPlane), OdGeVector3d.getCPtr(projectDir)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d setToAlignCoordSys(OdGePoint3d fromOrigin, OdGeVector3d fromXAxis, OdGeVector3d fromYAxis, OdGeVector3d fromZAxis, OdGePoint3d toOrigin, OdGeVector3d toXAxis, OdGeVector3d toYAxis, OdGeVector3d toZAxis)
	{
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToAlignCoordSys(swigCPtr, OdGePoint3d.getCPtr(fromOrigin), OdGeVector3d.getCPtr(fromXAxis), OdGeVector3d.getCPtr(fromYAxis), OdGeVector3d.getCPtr(fromZAxis), OdGePoint3d.getCPtr(toOrigin), OdGeVector3d.getCPtr(toXAxis), OdGeVector3d.getCPtr(toYAxis), OdGeVector3d.getCPtr(toZAxis));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = this[i, j];
			}
		}
		return odGeMatrix3d;
	}

	public OdGeMatrix3d setToWorldToPlane(OdGeVector3d normal)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToWorldToPlane__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(normal)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d setToWorldToPlane(OdGePlane plane)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToWorldToPlane__SWIG_1(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d setToPlaneToWorld(OdGeVector3d normal)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToPlaneToWorld__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(normal)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d setToPlaneToWorld(OdGePlane plane)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_setToPlaneToWorld__SWIG_1(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d translation(OdGeVector3d vect)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_translation__SWIG_0(OdGeVector3d.getCPtr(vect)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d translation()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_translation__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d rotation(double angle, OdGeVector3d axis, OdGePoint3d center)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_rotation__SWIG_0(angle, OdGeVector3d.getCPtr(axis), OdGePoint3d.getCPtr(center)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d rotation(double angle, OdGeVector3d axis)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_rotation__SWIG_1(angle, OdGeVector3d.getCPtr(axis)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d scaling(double scale, OdGePoint3d center)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_scaling__SWIG_0(scale, OdGePoint3d.getCPtr(center)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d scaling(double scale)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_scaling__SWIG_1(scale), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d scaling(OdGeScale3d scale, OdGePoint3d center)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_scaling__SWIG_2(OdGeScale3d.getCPtr(scale), OdGePoint3d.getCPtr(center)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d scaling(OdGeScale3d scale)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_scaling__SWIG_3(OdGeScale3d.getCPtr(scale)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d mirroring(OdGePlane mirrorPlane)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_mirroring__SWIG_0(OdGePlane.getCPtr(mirrorPlane)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d mirroring(OdGePoint3d mirrorPoint)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_mirroring__SWIG_1(OdGePoint3d.getCPtr(mirrorPoint)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d mirroring(OdGeLine3d mirrorLine)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_mirroring__SWIG_2(OdGeLine3d.getCPtr(mirrorLine)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d projection(OdGePlane projectionPlane, OdGeVector3d projectDir)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_projection(OdGePlane.getCPtr(projectionPlane), OdGeVector3d.getCPtr(projectDir)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d alignCoordSys(OdGePoint3d fromOrigin, OdGeVector3d fromXAxis, OdGeVector3d fromYAxis, OdGeVector3d fromZAxis, OdGePoint3d toOrigin, OdGeVector3d toXAxis, OdGeVector3d toYAxis, OdGeVector3d toZAxis)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_alignCoordSys(OdGePoint3d.getCPtr(fromOrigin), OdGeVector3d.getCPtr(fromXAxis), OdGeVector3d.getCPtr(fromYAxis), OdGeVector3d.getCPtr(fromZAxis), OdGePoint3d.getCPtr(toOrigin), OdGeVector3d.getCPtr(toXAxis), OdGeVector3d.getCPtr(toYAxis), OdGeVector3d.getCPtr(toZAxis)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d worldToPlane(OdGeVector3d normal)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_worldToPlane__SWIG_0(OdGeVector3d.getCPtr(normal)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d worldToPlane(OdGePlane plane)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_worldToPlane__SWIG_1(OdGePlane.getCPtr(plane)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d planeToWorld(OdGeVector3d normal)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_planeToWorld__SWIG_0(OdGeVector3d.getCPtr(normal)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix3d planeToWorld(OdGePlane plane)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_planeToWorld__SWIG_1(OdGePlane.getCPtr(plane)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double scale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_scale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double norm()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_norm(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix2d convertToLocal(OdGeVector3d normal, out double elevation)
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_convertToLocal(swigCPtr, OdGeVector3d.getCPtr(normal), out elevation), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double GetItem(int row, int column)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix3d_GetItem(swigCPtr, row, column);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

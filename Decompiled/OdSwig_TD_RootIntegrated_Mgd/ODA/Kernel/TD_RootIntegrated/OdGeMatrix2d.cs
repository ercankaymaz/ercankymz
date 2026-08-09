using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeMatrix2d : IDisposable
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
			TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_entry_set(swigCPtr, row, column, value);
		}
	}

	public static OdGeMatrix2d kIdentity
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_kIdentity_get();
			OdGeMatrix2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix2d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeMatrix2d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeMatrix2d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeMatrix2d()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeMatrix2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdGeMatrix2d operator *(OdGeMatrix2d m, OdGeMatrix2d d)
	{
		return m.Mul(d);
	}

	public static OdGePoint2d operator *(OdGeMatrix2d matrix, OdGePoint2d point)
	{
		return TD_RootIntegrated_Globals.Mul(matrix, point);
	}

	public static OdGeVector2d operator *(OdGeMatrix2d matrix, OdGeVector2d vect)
	{
		return TD_RootIntegrated_Globals.Mul(matrix, vect);
	}

	public OdGeMatrix2d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeMatrix2d(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix2d setToIdentity()
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setToIdentity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d Mul(OdGeMatrix2d matrix)
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_Mul__SWIG_0(swigCPtr, getCPtr(matrix)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix2d preMultBy(OdGeMatrix2d leftSide)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_preMultBy(swigCPtr, getCPtr(leftSide));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d postMultBy(OdGeMatrix2d rightSide)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_postMultBy(swigCPtr, getCPtr(rightSide));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d setToProduct(OdGeMatrix2d matrix1, OdGeMatrix2d matrix2)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setToProduct(swigCPtr, getCPtr(matrix1), getCPtr(matrix2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d invert()
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_invert(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d inverse()
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_inverse(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSingular(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_isSingular__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSingular()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_isSingular__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix2d transposeIt()
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_transposeIt(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d transpose()
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_transpose(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGeMatrix2d matrix)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_IsEqual(swigCPtr, getCPtr(matrix));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGeMatrix2d matrix)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_IsNotEqual(swigCPtr, getCPtr(matrix));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeMatrix2d matrix, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_isEqualTo__SWIG_0(swigCPtr, getCPtr(matrix), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeMatrix2d matrix)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_isEqualTo__SWIG_1(swigCPtr, getCPtr(matrix));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isUniScaledOrtho(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_isUniScaledOrtho__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isUniScaledOrtho()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_isUniScaledOrtho__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isScaledOrtho(OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_isScaledOrtho__SWIG_0(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isScaledOrtho()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_isScaledOrtho__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double scale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_scale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double det()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_det(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix2d setTranslation(OdGeVector2d vect)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setTranslation(swigCPtr, OdGeVector2d.getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeVector2d translation()
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_translation__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix2d translation(OdGeVector2d vector)
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_translation__SWIG_1(OdGeVector2d.getCPtr(vector).Handle), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isConformal(out double scale, out double angle, out bool isMirror, OdGeVector2d reflex)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_isConformal(swigCPtr, out scale, out angle, out isMirror, OdGeVector2d.getCPtr(reflex).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix2d setCoordSystem(OdGePoint2d origin, OdGeVector2d xAxis, OdGeVector2d yAxis)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setCoordSystem(swigCPtr, OdGePoint2d.getCPtr(origin), OdGeVector2d.getCPtr(xAxis).Handle, OdGeVector2d.getCPtr(yAxis).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public void getCoordSystem(OdGePoint2d origin, OdGeVector2d xAxis, OdGeVector2d yAxis)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_getCoordSystem(swigCPtr, OdGePoint2d.getCPtr(origin), OdGeVector2d.getCPtr(xAxis).Handle, OdGeVector2d.getCPtr(yAxis).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix2d setToTranslation(OdGeVector2d vect)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setToTranslation(swigCPtr, OdGeVector2d.getCPtr(vect).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d setToRotation(double angle, OdGePoint2d center)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setToRotation__SWIG_0(swigCPtr, angle, OdGePoint2d.getCPtr(center));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d setToRotation(double angle)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setToRotation__SWIG_1(swigCPtr, angle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d setToScaling(double scale, OdGePoint2d center)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setToScaling__SWIG_0(swigCPtr, scale, OdGePoint2d.getCPtr(center));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d setToScaling(double scale)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setToScaling__SWIG_1(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d setToScaling(OdGeScale2d scale, OdGePoint2d center)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setToScaling__SWIG_2(swigCPtr, OdGeScale2d.getCPtr(scale), OdGePoint2d.getCPtr(center));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d setToScaling(OdGeScale2d scale)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setToScaling__SWIG_3(swigCPtr, OdGeScale2d.getCPtr(scale));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d setToMirroring(OdGePoint2d mirrorPoint)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setToMirroring__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(mirrorPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d setToMirroring(OdGeLine2d mirrorLine)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setToMirroring__SWIG_1(swigCPtr, OdGeLine2d.getCPtr(mirrorLine));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public OdGeMatrix2d setToAlignCoordSys(OdGePoint2d fromOrigin, OdGeVector2d fromXAxis, OdGeVector2d fromYAxis, OdGePoint2d toOrigin, OdGeVector2d toXAxis, OdGeVector2d toYAxis)
	{
		OdGeMatrix2d odGeMatrix2d = new OdGeMatrix2d();
		TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_setToAlignCoordSys(swigCPtr, OdGePoint2d.getCPtr(fromOrigin), OdGeVector2d.getCPtr(fromXAxis).Handle, OdGeVector2d.getCPtr(fromYAxis).Handle, OdGePoint2d.getCPtr(toOrigin), OdGeVector2d.getCPtr(toXAxis).Handle, OdGeVector2d.getCPtr(toYAxis).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				odGeMatrix2d[i, j] = this[i, j];
			}
		}
		return odGeMatrix2d;
	}

	public static OdGeMatrix2d rotation(double angle, OdGePoint2d center)
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_rotation__SWIG_0(angle, OdGePoint2d.getCPtr(center)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix2d rotation(double angle)
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_rotation__SWIG_1(angle), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix2d scaling(double scale, OdGePoint2d center)
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_scaling__SWIG_0(scale, OdGePoint2d.getCPtr(center)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix2d scaling(double scale)
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_scaling__SWIG_1(scale), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix2d scaling(OdGeScale2d scale, OdGePoint2d center)
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_scaling__SWIG_2(OdGeScale2d.getCPtr(scale), OdGePoint2d.getCPtr(center)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix2d scaling(OdGeScale2d scale)
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_scaling__SWIG_3(OdGeScale2d.getCPtr(scale)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix2d mirroring(OdGePoint2d mirrorPoint)
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_mirroring__SWIG_0(OdGePoint2d.getCPtr(mirrorPoint)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix2d mirroring(OdGeLine2d mirrorLine)
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_mirroring__SWIG_1(OdGeLine2d.getCPtr(mirrorLine)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeMatrix2d alignCoordSys(OdGePoint2d fromOrigin, OdGeVector2d fromXAxis, OdGeVector2d fromYAxis, OdGePoint2d toOrigin, OdGeVector2d toXAxis, OdGeVector2d toYAxis)
	{
		OdGeMatrix2d result = new OdGeMatrix2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_alignCoordSys(OdGePoint2d.getCPtr(fromOrigin), OdGeVector2d.getCPtr(fromXAxis).Handle, OdGeVector2d.getCPtr(fromYAxis).Handle, OdGePoint2d.getCPtr(toOrigin), OdGeVector2d.getCPtr(toXAxis).Handle, OdGeVector2d.getCPtr(toYAxis).Handle), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double GetItem(int row, int column)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeMatrix2d_GetItem(swigCPtr, row, column);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

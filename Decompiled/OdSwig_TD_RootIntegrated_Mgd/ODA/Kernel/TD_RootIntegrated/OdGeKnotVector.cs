using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeKnotVector : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public double this[int i] => GetItem(i);

	public static double globalKnotTolerance
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_globalKnotTolerance_get();
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static OdGeVector2d globalKnotTolerance2d
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_globalKnotTolerance2d_get();
			OdGeVector2d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector2d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeKnotVector(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeKnotVector obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeKnotVector()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeKnotVector(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGeKnotVector(double tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeKnotVector__SWIG_0(tol), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeKnotVector()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeKnotVector__SWIG_1(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeKnotVector(int size, int growSize, double tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeKnotVector__SWIG_2(size, growSize, tol), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeKnotVector(int size, int growSize)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeKnotVector__SWIG_3(size, growSize), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeKnotVector(int size, double[] source, double tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeKnotVector__SWIG_4(size, Helpers.MarshaldoubleFixedArray(source), tol), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeKnotVector(int size, double[] source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeKnotVector__SWIG_5(size, Helpers.MarshaldoubleFixedArray(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeKnotVector(int plusMult, OdGeKnotVector source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeKnotVector__SWIG_6(plusMult, getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeKnotVector(OdGeKnotVector source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeKnotVector__SWIG_7(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeKnotVector(OdDoubleArray source, double tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeKnotVector__SWIG_8(OdDoubleArray.getCPtr(source).Handle, tol), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeKnotVector(OdDoubleArray source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeKnotVector__SWIG_9(OdDoubleArray.getCPtr(source).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeKnotVector Assign(OdGeKnotVector knotVector)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_Assign__SWIG_0(swigCPtr, getCPtr(knotVector)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector Assign(OdDoubleArray dblArray)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_Assign__SWIG_1(swigCPtr, OdDoubleArray.getCPtr(dblArray).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double GetItem(int i)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_GetItem(swigCPtr, i);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double startParam()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_startParam(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double endParam()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_endParam(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int multiplicityAt(int knotIndex)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_multiplicityAt__SWIG_0(swigCPtr, knotIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int numIntervals()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_numIntervals(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getInterval(int order, double param, OdGeInterval interval)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_getInterval(swigCPtr, order, param, OdGeInterval.getCPtr(interval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getDistinctKnots(OdDoubleArray knots, OdIntArray multiplicity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_getDistinctKnots__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(knots).Handle, OdIntArray.getCPtr(multiplicity).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDistinctKnots(OdDoubleArray knots)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_getDistinctKnots__SWIG_1(swigCPtr, OdDoubleArray.getCPtr(knots).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool contains(double param)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_contains(swigCPtr, param);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOn(double knot)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_isOn(swigCPtr, knot);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector reverse()
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_reverse(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector removeAt(int knotIndex)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_removeAt(swigCPtr, knotIndex), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector removeSubVector(int startIndex, int endIndex)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_removeSubVector(swigCPtr, startIndex, endIndex), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector insertAt(int knotIndex, double knot, int multiplicity)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_insertAt__SWIG_0(swigCPtr, knotIndex, knot, multiplicity), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector insertAt(int knotIndex, double knot)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_insertAt__SWIG_1(swigCPtr, knotIndex, knot), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector insert(double param)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_insert(swigCPtr, param), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector insertIn(double param)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_insertIn(swigCPtr, param), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int append(double knot)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_append__SWIG_0(swigCPtr, knot);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector append(OdGeKnotVector tail, double knotRatio)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_append__SWIG_1(swigCPtr, getCPtr(tail), knotRatio), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector append(OdGeKnotVector tail)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_append__SWIG_2(swigCPtr, getCPtr(tail)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int split(double param, OdGeKnotVector pKnotHead, int multLast, OdGeKnotVector pKnotTail, int multFirst)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_split(swigCPtr, param, getCPtr(pKnotHead), multLast, getCPtr(pKnotTail), multFirst);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector setRange(double lower, double upper)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_setRange(swigCPtr, lower, upper), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double tolerance()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_tolerance(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector setTolerance(double tol)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_setTolerance(swigCPtr, tol), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int length()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_length(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_isEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int logicalLength()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_logicalLength(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector setLogicalLength(int size)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_setLogicalLength(swigCPtr, size), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int physicalLength()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_physicalLength(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector setPhysicalLength(int physLength)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_setPhysicalLength(swigCPtr, physLength), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int growLength()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_growLength(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector setGrowLength(int rowLength)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_setGrowLength(swigCPtr, rowLength), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector set(int size, double[] source, double tol)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_set__SWIG_0(swigCPtr, size, Helpers.MarshaldoubleFixedArray(source), tol), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeKnotVector set(int size, double[] source)
	{
		OdGeKnotVector result = new OdGeKnotVector(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_set__SWIG_1(swigCPtr, size, Helpers.MarshaldoubleFixedArray(source)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int multiplicityAt(double param)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_multiplicityAt__SWIG_1(swigCPtr, param);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDoubleArray getArray()
	{
		OdDoubleArray result = new OdDoubleArray(TD_RootIntegrated_GlobalsPINVOKE.OdGeKnotVector_getArray__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

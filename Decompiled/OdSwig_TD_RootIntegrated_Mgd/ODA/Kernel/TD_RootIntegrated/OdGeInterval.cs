using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeInterval : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeInterval(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeInterval obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeInterval()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeInterval(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGeInterval(double tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeInterval__SWIG_0(tol), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeInterval()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeInterval__SWIG_1(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeInterval(double lower, double upper, double tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeInterval__SWIG_2(lower, upper, tol), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeInterval(double lower, double upper)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeInterval__SWIG_3(lower, upper), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeInterval(bool boundedBelow, double bound, double tol)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeInterval__SWIG_4(boundedBelow, bound, tol), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeInterval(bool boundedBelow, double bound)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeInterval__SWIG_5(boundedBelow, bound), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double lowerBound()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_lowerBound(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double upperBound()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_upperBound(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double middle()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_middle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double element()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_element(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getBounds(out double lower, out double upper)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_getBounds(swigCPtr, out lower, out upper);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double getEnd(int index)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_getEnd(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double length()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_length(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double tolerance()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_tolerance(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double eval(double ratio)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_eval(swigCPtr, ratio);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeInterval set(double lower, double upper)
	{
		OdGeInterval result = new OdGeInterval(TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_set__SWIG_0(swigCPtr, lower, upper), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeInterval set(bool boundedBelow, double bound)
	{
		OdGeInterval result = new OdGeInterval(TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_set__SWIG_1(swigCPtr, boundedBelow, bound), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeInterval set()
	{
		OdGeInterval result = new OdGeInterval(TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_set__SWIG_2(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeInterval setUpper(double upper)
	{
		OdGeInterval result = new OdGeInterval(TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_setUpper(swigCPtr, upper), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeInterval setLower(double lower)
	{
		OdGeInterval result = new OdGeInterval(TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_setLower(swigCPtr, lower), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeInterval setTolerance(double tol)
	{
		OdGeInterval result = new OdGeInterval(TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_setTolerance(swigCPtr, tol), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeInterval scale(double factor)
	{
		OdGeInterval result = new OdGeInterval(TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_scale(swigCPtr, factor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeInterval swap()
	{
		OdGeInterval result = new OdGeInterval(TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_swap(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getMerge(OdGeInterval otherInterval, OdGeInterval result)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_getMerge(swigCPtr, getCPtr(otherInterval), getCPtr(result));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int subtract(OdGeInterval otherInterval, OdGeInterval lInterval, OdGeInterval rInterval)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_subtract(swigCPtr, getCPtr(otherInterval), getCPtr(lInterval), getCPtr(rInterval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool intersectWith(OdGeInterval otherInterval, OdGeInterval result)
	{
		bool result2 = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_intersectWith(swigCPtr, getCPtr(otherInterval), getCPtr(result));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result2;
	}

	public bool finiteIntersectWith(OdGeInterval range, OdGeInterval result)
	{
		bool result2 = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_finiteIntersectWith(swigCPtr, getCPtr(range), getCPtr(result));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result2;
	}

	public bool isBounded()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_isBounded(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isBoundedAbove()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_isBoundedAbove(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isBoundedBelow()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_isBoundedBelow(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isUnBounded()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_isUnBounded(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSingleton()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_isSingleton(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDisjoint(OdGeInterval otherInterval)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_isDisjoint(swigCPtr, getCPtr(otherInterval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool contains(OdGeInterval otherInterval)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_contains__SWIG_0(swigCPtr, getCPtr(otherInterval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool contains(double value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_contains__SWIG_1(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double clamp(double value)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_clamp(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isContinuousAtUpper(OdGeInterval otherInterval)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_isContinuousAtUpper(swigCPtr, getCPtr(otherInterval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOverlapAtUpper(OdGeInterval otherInterval, OdGeInterval overlap)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_isOverlapAtUpper(swigCPtr, getCPtr(otherInterval), getCPtr(overlap));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGeInterval otherInterval)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_IsEqual(swigCPtr, getCPtr(otherInterval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGeInterval otherInterval)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_IsNotEqual(swigCPtr, getCPtr(otherInterval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualAtUpper(OdGeInterval otherInterval)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_isEqualAtUpper__SWIG_0(swigCPtr, getCPtr(otherInterval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualAtUpper(double value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_isEqualAtUpper__SWIG_1(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualAtLower(OdGeInterval otherInterval)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_isEqualAtLower__SWIG_0(swigCPtr, getCPtr(otherInterval));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualAtLower(double value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_isEqualAtLower__SWIG_1(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPeriodicallyOn(double period, out double value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeInterval_isPeriodicallyOn(swigCPtr, period, out value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

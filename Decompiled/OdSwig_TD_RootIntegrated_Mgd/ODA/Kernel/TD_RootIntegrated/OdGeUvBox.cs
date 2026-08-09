using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeUvBox : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdGeInterval intervals
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_intervals_get(swigCPtr);
			OdGeInterval result = ((intPtr == IntPtr.Zero) ? null : new OdGeInterval(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_intervals_set(swigCPtr, OdGeInterval.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeUvBox(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeUvBox obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGeUvBox()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeUvBox(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGeUvBox()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeUvBox__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeUvBox(OdGeInterval iIntervalU, OdGeInterval iIntervalV)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeUvBox__SWIG_1(OdGeInterval.getCPtr(iIntervalU), OdGeInterval.getCPtr(iIntervalV)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeInterval u()
	{
		OdGeInterval result = new OdGeInterval(TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_u__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeInterval v()
	{
		OdGeInterval result = new OdGeInterval(TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_v__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeInterval GetItem(int idx)
	{
		OdGeInterval result = new OdGeInterval(TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_GetItem__SWIG_0(swigCPtr, idx), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeUvBox set()
	{
		OdGeUvBox result = new OdGeUvBox(TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_set__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeUvBox set(OdGeInterval iIntervalU, OdGeInterval iIntervalV)
	{
		OdGeUvBox result = new OdGeUvBox(TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_set__SWIG_1(swigCPtr, OdGeInterval.getCPtr(iIntervalU), OdGeInterval.getCPtr(iIntervalV)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeUvBox set(OdGePoint2d iLowerBound, OdGePoint2d iUpperBound)
	{
		OdGeUvBox result = new OdGeUvBox(TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_set__SWIG_2(swigCPtr, OdGePoint2d.getCPtr(iLowerBound), OdGePoint2d.getCPtr(iUpperBound)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool contains(double uparam, double vparam)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_contains__SWIG_0(swigCPtr, uparam, vparam);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool contains(OdGePoint2d uvpoint)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_contains__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(uvpoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isBounded()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_isBounded(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool finiteIntersectWith(OdGeUvBox range, OdGeUvBox result)
	{
		bool result2 = TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_finiteIntersectWith(swigCPtr, getCPtr(range), getCPtr(result));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result2;
	}

	public OdGePoint2d lowerBound()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_lowerBound(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d upperBound()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_upperBound(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEqualTo(OdGeUvBox uvbox)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_isEqualTo(swigCPtr, getCPtr(uvbox));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d eval(double ratioU, double ratioV)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_eval(swigCPtr, ratioU, ratioV), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d clamp(OdGePoint2d point)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_clamp(swigCPtr, OdGePoint2d.getCPtr(point)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGeUvBox otherUvBox)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeUvBox_IsEqual(swigCPtr, getCPtr(otherUvBox));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

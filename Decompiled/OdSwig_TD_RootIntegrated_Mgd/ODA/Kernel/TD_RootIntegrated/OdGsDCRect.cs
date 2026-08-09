using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsDCRect : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdGsDCPoint m_min
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_m_min_get(swigCPtr);
			OdGsDCPoint result = ((intPtr == IntPtr.Zero) ? null : new OdGsDCPoint(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_m_min_set(swigCPtr, OdGsDCPoint.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGsDCPoint m_max
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_m_max_get(swigCPtr);
			OdGsDCPoint result = ((intPtr == IntPtr.Zero) ? null : new OdGsDCPoint(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_m_max_set(swigCPtr, OdGsDCPoint.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsDCRect(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsDCRect obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsDCRect()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsDCRect(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsDCRect()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDCRect__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCRect(OdGsDCPoint minPoint, OdGsDCPoint maxPoint)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDCRect__SWIG_1(OdGsDCPoint.getCPtr(minPoint), OdGsDCPoint.getCPtr(maxPoint)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCRect(int xMin, int xMax, int yMin, int yMax)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDCRect__SWIG_2(xMin, xMax, yMin, yMax), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCRect(OdGsDCRect_NullFlag arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDCRect__SWIG_3((int)arg0), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCRect Assign(OdGsDCRect dcRect)
	{
		OdGsDCRect result = new OdGsDCRect(TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_Assign(swigCPtr, getCPtr(dcRect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGsDCRect dcRect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_IsEqual(swigCPtr, getCPtr(dcRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGsDCRect dcRect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_IsNotEqual(swigCPtr, getCPtr(dcRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set_null()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_set_null(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool is_null()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_is_null(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool within(OdGsDCRect dcRect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_within(swigCPtr, getCPtr(dcRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void offset(int x, int y)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_offset(swigCPtr, x, y);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void intersectWith(OdGsDCRect dcRect, bool bValidate)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_intersectWith__SWIG_0(swigCPtr, getCPtr(dcRect), bValidate);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void intersectWith(OdGsDCRect dcRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_intersectWith__SWIG_1(swigCPtr, getCPtr(dcRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void normalize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_normalize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDisjoint(OdGsDCRect r)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRect_isDisjoint(swigCPtr, getCPtr(r));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

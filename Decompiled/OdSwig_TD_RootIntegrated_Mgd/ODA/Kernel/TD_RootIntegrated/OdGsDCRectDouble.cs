using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsDCRectDouble : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdGePoint2d m_min
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRectDouble_m_min_get(swigCPtr);
			OdGePoint2d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint2d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRectDouble_m_min_set(swigCPtr, OdGePoint2d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGePoint2d m_max
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRectDouble_m_max_get(swigCPtr);
			OdGePoint2d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint2d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRectDouble_m_max_set(swigCPtr, OdGePoint2d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsDCRectDouble(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsDCRectDouble obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsDCRectDouble()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsDCRectDouble(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsDCRectDouble()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDCRectDouble__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCRectDouble(OdGePoint2d minPoint, OdGePoint2d maxPoint)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDCRectDouble__SWIG_1(OdGePoint2d.getCPtr(minPoint), OdGePoint2d.getCPtr(maxPoint)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCRectDouble(double xMin, double xMax, double yMin, double yMax)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDCRectDouble__SWIG_2(xMin, xMax, yMin, yMax), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCRectDouble(OdGsDCRect rc)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDCRectDouble__SWIG_3(OdGsDCRect.getCPtr(rc)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCRectDouble Assign(OdGsDCRect dcRect)
	{
		OdGsDCRectDouble result = new OdGsDCRectDouble(TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRectDouble_Assign(swigCPtr, OdGsDCRect.getCPtr(dcRect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGsDCRectDouble dcRect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRectDouble_IsEqual(swigCPtr, getCPtr(dcRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGsDCRectDouble dcRect)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRectDouble_IsNotEqual(swigCPtr, getCPtr(dcRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsDCRect round()
	{
		OdGsDCRect result = new OdGsDCRect(TD_RootIntegrated_GlobalsPINVOKE.OdGsDCRectDouble_round(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

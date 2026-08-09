using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiClipBoundaryWithAbstractData : OdGiClipBoundary
{
	private object locker = new object();

	private HandleRef swigCPtr;

	public OdGiAbstractClipBoundary m_pAbstractData
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiClipBoundaryWithAbstractData_m_pAbstractData_get(swigCPtr);
			OdGiAbstractClipBoundary result = ((intPtr == IntPtr.Zero) ? null : new OdGiAbstractClipBoundary(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiClipBoundaryWithAbstractData_m_pAbstractData_set(swigCPtr, OdGiAbstractClipBoundary.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiClipBoundaryWithAbstractData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiClipBoundaryWithAbstractData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiClipBoundaryWithAbstractData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiClipBoundaryWithAbstractData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiClipBoundaryWithAbstractData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiClipBoundaryWithAbstractData__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiClipBoundaryWithAbstractData(OdGiClipBoundary pBoundary, OdGiAbstractClipBoundary pAbsData)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiClipBoundaryWithAbstractData__SWIG_1(OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pAbsData)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiClipBoundaryWithAbstractData(OdGiClipBoundary pBoundary)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiClipBoundaryWithAbstractData__SWIG_2(OdGiClipBoundary.getCPtr(pBoundary)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiClipBoundaryWithAbstractData(OdGiClipBoundaryWithAbstractData pBoundary)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiClipBoundaryWithAbstractData__SWIG_3(getCPtr(pBoundary)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

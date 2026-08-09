using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPlineContourCalcEmptyInheritance : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPlineContourCalcEmptyInheritance(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPlineContourCalcEmptyInheritance obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiPlineContourCalcEmptyInheritance()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPlineContourCalcEmptyInheritance(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public void pline(OdGiPolyline arg0, uint arg1, uint arg2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlineContourCalcEmptyInheritance_pline__SWIG_0(swigCPtr, OdGiPolyline.getCPtr(arg0), arg1, arg2);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void pline(OdGiPolyline arg0, uint arg1)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlineContourCalcEmptyInheritance_pline__SWIG_1(swigCPtr, OdGiPolyline.getCPtr(arg0), arg1);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void pline(OdGiPolyline arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlineContourCalcEmptyInheritance_pline__SWIG_2(swigCPtr, OdGiPolyline.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiPlineContourCalcEmptyInheritance()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPlineContourCalcEmptyInheritance(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

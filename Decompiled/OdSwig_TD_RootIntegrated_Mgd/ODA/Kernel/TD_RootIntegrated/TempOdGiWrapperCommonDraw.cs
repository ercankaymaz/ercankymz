using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class TempOdGiWrapperCommonDraw : OdGiViewportDraw
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TempOdGiWrapperCommonDraw(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperCommonDraw_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TempOdGiWrapperCommonDraw obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.deletePD_TempOdGiWrapperCommonDraw(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new virtual OdGiGeometry rawGeometry()
	{
		OdGiGeometry rXObject = Helpers.GetRXObject<OdGiGeometry>(TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperCommonDraw_rawGeometry(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdGiRegenType regenType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperCommonDraw_regenType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRegenType)result;
	}

	public new virtual bool regenAbort()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperCommonDraw_regenAbort(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiSubEntityTraits subEntityTraits()
	{
		OdGiSubEntityTraits rXObject = Helpers.GetRXObject<OdGiSubEntityTraits>(TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperCommonDraw_subEntityTraits(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual bool isDragging()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperCommonDraw_isDragging(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiContext context()
	{
		OdGiContext rXObject = Helpers.GetRXObject<OdGiContext>(TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperCommonDraw_context(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual uint numberOfIsolines()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperCommonDraw_numberOfIsolines(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual double deviation(OdGiDeviationType t, OdGePoint3d p)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGiWrapperCommonDraw_deviation(swigCPtr, (int)t, OdGePoint3d.getCPtr(p));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

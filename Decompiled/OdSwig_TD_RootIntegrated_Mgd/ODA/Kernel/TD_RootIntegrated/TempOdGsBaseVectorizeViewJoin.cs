using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class TempOdGsBaseVectorizeViewJoin : OdGsBaseVectorizer
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TempOdGsBaseVectorizeViewJoin(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoin_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TempOdGsBaseVectorizeViewJoin obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.deletePD_TempOdGsBaseVectorizeViewJoin(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new virtual void clearLinetypeCache()
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoin_clearLinetypeCache(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void init(OdGsBaseVectorizeDevice pDevice, OdGsClientViewInfo pViewInfo, bool enableLayerVisibilityPerView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoin_init__SWIG_0(swigCPtr, OdGsBaseVectorizeDevice.getCPtr(pDevice), OdGsClientViewInfo.getCPtr(pViewInfo), enableLayerVisibilityPerView);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void init(OdGsBaseVectorizeDevice pDevice, OdGsClientViewInfo pViewInfo)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoin_init__SWIG_1(swigCPtr, OdGsBaseVectorizeDevice.getCPtr(pDevice), OdGsClientViewInfo.getCPtr(pViewInfo));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void init(OdGsBaseVectorizeDevice pDevice)
	{
		TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoin_init__SWIG_2(swigCPtr, OdGsBaseVectorizeDevice.getCPtr(pDevice));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d target()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoin_target(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double fieldWidth()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoin_fieldWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double fieldHeight()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoin_fieldHeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d eyeToScreenMatrix(OdGsOverlayId nOverlay)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoin_eyeToScreenMatrix__SWIG_0(swigCPtr, (int)nOverlay), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d eyeToScreenMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoin_eyeToScreenMatrix__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeMatrix3d objectToDeviceMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.TempOdGsBaseVectorizeViewJoin_objectToDeviceMatrix(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

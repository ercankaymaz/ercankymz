using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsViewImpl : OdGsView
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsViewImpl(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsViewImpl obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsViewImpl()
	{
		Dispose(disposing: false);
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected new virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsViewImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public new static OdGsViewImpl cast(OdRxObject pObj)
	{
		OdGsViewImpl rXObject = Helpers.GetRXObject<OdGsViewImpl>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsViewImpl createObject()
	{
		OdGsViewImpl rXObject = Helpers.GetRXObject<OdGsViewImpl>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void init(OdGsBaseVectorizeDevice pDevice, OdGsClientViewInfo pViewInfo, bool enableLayerVisibilityPerView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_init(swigCPtr, OdGsBaseVectorizeDevice.getCPtr(pDevice), OdGsClientViewInfo.getCPtr(pViewInfo), enableLayerVisibilityPerView);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdGsDevice device()
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_device(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdGsView_RenderMode mode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_mode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsView_RenderMode)result;
	}

	public bool setModeOverride(OdGsView_RenderMode mode)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setModeOverride(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setMode(OdGsView_RenderMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void freezeLayer(OdDbStub layerID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_freezeLayer(swigCPtr, OdDbStub.getCPtr(layerID));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void thawLayer(OdDbStub layerID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_thawLayer(swigCPtr, OdDbStub.getCPtr(layerID));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void clearFrozenLayers()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_clearFrozenLayers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setViewportBorderProperties(uint color, int width)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setViewportBorderProperties(swigCPtr, color, width);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void getViewportBorderProperties(out uint color, out int width)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getViewportBorderProperties(swigCPtr, out color, out width);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setViewportBorderVisibility(bool visible)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setViewportBorderVisibility(swigCPtr, visible);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool isViewportBorderVisible()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isViewportBorderVisible(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setEnableFrontClip(bool enable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setEnableFrontClip(swigCPtr, enable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool isFrontClipped()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isFrontClipped(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setFrontClip(double distance)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setFrontClip(swigCPtr, distance);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual double frontClip()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_frontClip(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setEnableBackClip(bool enable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setEnableBackClip(swigCPtr, enable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool isBackClipped()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isBackClipped(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setBackClip(double distance)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setBackClip(swigCPtr, distance);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual double backClip()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_backClip(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGePoint3d position()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_position(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGePoint3d target()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_target(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGeVector3d upVector()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_upVector(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual double fieldWidth()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_fieldWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual double fieldHeight()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_fieldHeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double windowAspect()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_windowAspect(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual double lensLength()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_lensLength(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setLensLength(double lensLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setLensLength(swigCPtr, lensLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool isPerspective()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isPerspective(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void beginInteractivity(double frameRateInHz)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_beginInteractivity(swigCPtr, frameRateInHz);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool isInInteractivity()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isInInteractivity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual double interactivityFrameRate()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_interactivityFrameRate(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void endInteractivity()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_endInteractivity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void flush()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_flush(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void hide()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_hide(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void show()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_show(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool isVisible()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isVisible(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGsView cloneView(bool cloneViewParameters, bool cloneGeometry)
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_cloneView__SWIG_0(swigCPtr, cloneViewParameters, cloneGeometry), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGsView cloneView(bool cloneViewParameters)
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_cloneView__SWIG_1(swigCPtr, cloneViewParameters), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGsView cloneView()
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_cloneView__SWIG_2(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual bool exceededBounds()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_exceededBounds(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void enableStereo(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_enableStereo(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool isStereoEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isStereoEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setStereoParameters(double magnitude, double parallax)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setStereoParameters(swigCPtr, magnitude, parallax);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void getStereoParameters(out double magnitude, out double parallax)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getStereoParameters(swigCPtr, out magnitude, out parallax);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void initLights(OdRxIterator pLightsIterator)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_initLights(swigCPtr, OdRxIterator.getCPtr(pLightsIterator));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void getSnapShot(ref OdGiRasterImage pImage, OdGsDCRect region)
	{
		IntPtr jarg = ((pImage == null) ? IntPtr.Zero : OdGiRasterImage.getCPtr(pImage).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getSnapShot(swigCPtr, ref jarg, OdGsDCRect.getCPtr(region));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pImage = null;
			}
			else if (jarg != intPtr)
			{
				pImage = Helpers.GetRXObject<OdGiRasterImage>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public new virtual void setViewport(OdGePoint2d lowerLeft, OdGePoint2d upperRight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setViewport__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(lowerLeft), OdGePoint2d.getCPtr(upperRight));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setViewport(OdGsDCRect screenRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setViewport__SWIG_1(swigCPtr, OdGsDCRect.getCPtr(screenRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setViewport(OdGsDCRectDouble screenRec)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setViewport__SWIG_2(swigCPtr, OdGsDCRectDouble.getCPtr(screenRec));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void getViewport(OdGePoint2d lowerLeft, OdGePoint2d upperRight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getViewport__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(lowerLeft), OdGePoint2d.getCPtr(upperRight));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void getViewport(OdGsDCRect screenRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getViewport__SWIG_1(swigCPtr, OdGsDCRect.getCPtr(screenRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void getViewport(OdGsDCRectDouble screenRec)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getViewport__SWIG_2(swigCPtr, OdGsDCRectDouble.getCPtr(screenRec));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdGeMatrix3d screenMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_screenMatrix(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGeMatrix3d worldToDeviceMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_worldToDeviceMatrix__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGeMatrix3d objectToDeviceMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_objectToDeviceMatrix__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGeMatrix3d viewingMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_viewingMatrix(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGeMatrix3d projectionMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_projectionMatrix__SWIG_0(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void viewParameters(OdGsView pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_viewParameters(swigCPtr, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual double lineweightToDcScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_lineweightToDcScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setLineweightToDcScale(double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setLineweightToDcScale(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLineweightEnum(byte[] numLineweights, ushort altSourceLwds)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(numLineweights);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setLineweightEnum(swigCPtr, intPtr, altSourceLwds);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public new virtual void setLinetypeScaleMultiplier(double linetypeScaleMultiplier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setLinetypeScaleMultiplier(swigCPtr, linetypeScaleMultiplier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setAlternateLinetypeScaleMultiplier(double linetypeAlternateScaleMultiplier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setAlternateLinetypeScaleMultiplier(swigCPtr, linetypeAlternateScaleMultiplier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual double linetypeScaleMultiplier()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_linetypeScaleMultiplier(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void dolly(OdGeVector3d dollyVector)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_dolly__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(dollyVector));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void dolly(double xDolly, double yDolly, double zDolly)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_dolly__SWIG_1(swigCPtr, xDolly, yDolly, zDolly);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void roll(double rollAngle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_roll(swigCPtr, rollAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void orbit(double xOrbit, double yOrbit)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_orbit(swigCPtr, xOrbit, yOrbit);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void zoom(double zoomFactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_zoom(swigCPtr, zoomFactor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void pan(double xPan, double yPan)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_pan(swigCPtr, xPan, yPan);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setView(OdGePoint3d position, OdGePoint3d target, OdGeVector3d upVector, double fieldWidth, double fieldHeight, OdGsView_Projection projection)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setView__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(position), OdGePoint3d.getCPtr(target), OdGeVector3d.getCPtr(upVector), fieldWidth, fieldHeight, (int)projection);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setView(OdGePoint3d position, OdGePoint3d target, OdGeVector3d upVector, double fieldWidth, double fieldHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setView__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(position), OdGePoint3d.getCPtr(target), OdGeVector3d.getCPtr(upVector), fieldWidth, fieldHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void zoomExtents(OdGePoint3d minPt, OdGePoint3d maxPt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_zoomExtents(swigCPtr, OdGePoint3d.getCPtr(minPt), OdGePoint3d.getCPtr(maxPt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void zoomWindow(OdGePoint2d lowerLeft, OdGePoint2d upperRight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_zoomWindow(swigCPtr, OdGePoint2d.getCPtr(lowerLeft), OdGePoint2d.getCPtr(upperRight));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool pointInView(OdGePoint3d pt)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_pointInView(swigCPtr, OdGePoint3d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool extentsInView(OdGePoint3d minPt, OdGePoint3d maxPt)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_extentsInView(swigCPtr, OdGePoint3d.getCPtr(minPt), OdGePoint3d.getCPtr(maxPt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void viewportClipRegion(OdIntArray counts, OdGePoint2dArray vertices)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_viewportClipRegion__SWIG_0(swigCPtr, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(vertices).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void viewportClipRegion(OdIntArray counts, OdGsDCPointArray dcPts)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_viewportClipRegion__SWIG_1(swigCPtr, OdIntArray.getCPtr(counts).Handle, OdGsDCPointArray.getCPtr(dcPts).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setViewportClipRegion(OdGePoint2dArray[] numContours)
	{
		IntPtr intPtr = Helpers.MarshalClipRegion(numContours);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setViewportClipRegion__SWIG_0(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public bool isDependentViewportView()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isDependentViewportView(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDependentGeometryView()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isDependentGeometryView(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isHelperView()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isHelperView(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsBaseModule getGsModulePtr()
	{
		OdGsBaseModule rXObject = Helpers.GetRXObject<OdGsBaseModule>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getGsModulePtr(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiContextualColors contextualColors()
	{
		OdGiContextualColors rXObject = Helpers.GetRXObject<OdGiContextualColors>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_contextualColors(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setContextualColors(OdGiContextualColors pColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setContextualColors(swigCPtr, OdGiContextualColors.getCPtr(pColors));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool pointInViewport(OdGePoint2d screenPoint)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_pointInViewport(swigCPtr, OdGePoint2d.getCPtr(screenPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setClearColor(OdGsView_ClearColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setClearColor(swigCPtr, (int)color);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void invalidate()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_invalidate__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void invalidate(OdGsDCRect rect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_invalidate__SWIG_1(swigCPtr, OdGsDCRect.getCPtr(rect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void invalidateCachedViewportGeometry()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_invalidateCachedViewportGeometry__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void select(OdGsDCPoint[] points, OdGsSelectionReactor pReactor, OdGsView_SelectionMode mode)
	{
		IntPtr intPtr = Helpers.MarshalOdGsDCPointArray(points);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_select__SWIG_0(swigCPtr, intPtr, OdGsSelectionReactor.getCPtr(pReactor), (int)mode);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public new virtual bool add(OdGiDrawable sceneGraph, OdGsModel model)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_add(swigCPtr, OdGiDrawable.getCPtr(sceneGraph), OdGsModel.getCPtr(model));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual int numRootDrawables()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_numRootDrawables(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdDbStub rootDrawableIdAt(int i, ref OdGsModel pModelReturn)
	{
		IntPtr jarg = ((pModelReturn == null) ? IntPtr.Zero : OdGsModel.getCPtr(pModelReturn).Handle);
		IntPtr intPtr = jarg;
		try
		{
			IntPtr intPtr2 = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_rootDrawableIdAt__SWIG_0(swigCPtr, i, ref jarg);
			OdDbStub result = ((intPtr2 == IntPtr.Zero) ? null : new OdDbStub(intPtr2, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pModelReturn = null;
			}
			else if (jarg != intPtr)
			{
				pModelReturn = Helpers.GetRXObject<OdGsModel>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public override OdDbStub rootDrawableIdAt(int i)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_rootDrawableIdAt__SWIG_1(swigCPtr, i);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiDrawable rootDrawableAt(int i, ref OdGsModel pModelReturn)
	{
		IntPtr jarg = ((pModelReturn == null) ? IntPtr.Zero : OdGsModel.getCPtr(pModelReturn).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_rootDrawableAt__SWIG_0(swigCPtr, i, ref jarg), bOwn: true, bTryAddToTransaction: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pModelReturn = null;
			}
			else if (jarg != intPtr)
			{
				pModelReturn = Helpers.GetRXObject<OdGsModel>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public override OdGiDrawable rootDrawableAt(int i)
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_rootDrawableAt__SWIG_1(swigCPtr, i), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual bool erase(OdGiDrawable sceneGraph)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_erase(swigCPtr, OdGiDrawable.getCPtr(sceneGraph));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void eraseAll()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_eraseAll(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdGsModel getModel(OdGiDrawable pDrawable)
	{
		OdGsModel rXObject = Helpers.GetRXObject<OdGsModel>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getModel(swigCPtr, OdGiDrawable.getCPtr(pDrawable)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdGsModelArray getModelList()
	{
		OdGsModelArray result = new OdGsModelArray(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getModelList(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isValid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isValid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void getNumPixelsInUnitSquare(OdGePoint3d givenWorldpt, OdGePoint2d pixelArea, bool includePerspective)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getNumPixelsInUnitSquare__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(givenWorldpt), OdGePoint2d.getCPtr(pixelArea), includePerspective);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void getNumPixelsInUnitSquare(OdGePoint3d givenWorldpt, OdGePoint2d pixelArea)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getNumPixelsInUnitSquare__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(givenWorldpt), OdGePoint2d.getCPtr(pixelArea));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setBackground(OdDbStub backgroundId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setBackground(swigCPtr, OdDbStub.getCPtr(backgroundId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdDbStub background()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_background(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setVisualStyle(OdDbStub visualStyleId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setVisualStyle__SWIG_0(swigCPtr, OdDbStub.getCPtr(visualStyleId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdDbStub visualStyle()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_visualStyle__SWIG_0(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setVisualStyle(OdGiVisualStyle visualStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setVisualStyle__SWIG_1(swigCPtr, OdGiVisualStyle.getCPtr(visualStyle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool visualStyle(ref OdGiVisualStyle vs)
	{
		IntPtr jarg = ((vs == null) ? IntPtr.Zero : OdGiVisualStyle.getCPtr(vs).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_visualStyle__SWIG_1(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				vs = null;
			}
			if (jarg != intPtr)
			{
				vs = Helpers.GetRXObject<OdGiVisualStyle>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public override void enableDefaultLighting(bool bEnable, OdGsView_DefaultLightingType lightType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_enableDefaultLighting__SWIG_0(swigCPtr, bEnable, (int)lightType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void enableDefaultLighting(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_enableDefaultLighting__SWIG_1(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool defaultLightingEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_defaultLightingEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsView_DefaultLightingType defaultLightingType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_defaultLightingType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsView_DefaultLightingType)result;
	}

	public static OdGsViewImpl safeCast(OdGsView pView)
	{
		OdGsViewImpl rXObject = Helpers.GetRXObject<OdGsViewImpl>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_safeCast__SWIG_0(OdGsView.getCPtr(pView)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public uint viewportId()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_viewportId(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValidViewportId(uint vpId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isValidViewportId(swigCPtr, vpId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub getViewportObjectId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getViewportObjectId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsBaseVectorizeDevice baseDevice()
	{
		OdGsBaseVectorizeDevice rXObject = Helpers.GetRXObject<OdGsBaseVectorizeDevice>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_baseDevice__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbStub annotationScaleId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_annotationScaleId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr drawablesFilterFunction()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_drawablesFilterFunction(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool viewExtents(OdGeBoundBlock3d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_viewExtents(swigCPtr, OdGeBoundBlock3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void select(OdGePoint2d[] aPtDc, OdGsSelectionReactor pReactor, OdGsView_SelectionMode mode)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(aPtDc);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_select__SWIG_1(swigCPtr, intPtr, OdGsSelectionReactor.getCPtr(pReactor), (int)mode);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public bool isSnapping()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isSnapping(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSnapping(bool val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setSnapping(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isRegenOnDrawForbidden()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isRegenOnDrawForbidden(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRegenOnDrawForbidden(bool val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setRegenOnDrawForbidden(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isAccumulateVpChanges()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isAccumulateVpChanges(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void clearLinetypeCache()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_clearLinetypeCache(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual double linetypeAlternateScaleMultiplier()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_linetypeAlternateScaleMultiplier(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isSupportLegacyWireframeMode()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isSupportLegacyWireframeMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isLegacyWireframeMode()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isLegacyWireframeMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLegacyWireframeMode(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setLegacyWireframeMode(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isSupportLegacyHiddenMode()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isSupportLegacyHiddenMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isLegacyHiddenMode()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isLegacyHiddenMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLegacyHiddenMode(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setLegacyHiddenMode(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isSupportPlotStyles()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isSupportPlotStyles(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isPlotTransparency()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isPlotTransparency(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPlotTransparency(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setPlotTransparency(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint frozenLayers()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_frozenLayers__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void frozenLayers(OdDbStubPtrArray frozenLayers)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_frozenLayers__SWIG_1(swigCPtr, OdDbStubPtrArray.getCPtr(frozenLayers));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isLayerVisible(OdDbStub layerId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isLayerVisible(swigCPtr, OdDbStub.getCPtr(layerId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void includeFrozenLayersVisibilityInViewExtents(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_includeFrozenLayersVisibilityInViewExtents(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isFrozenLayersVisibilityIncludedInViewExtents()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isFrozenLayersVisibilityIncludedInViewExtents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double lineweightToPixels(double lineweight)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_lineweightToPixels__SWIG_0(swigCPtr, lineweight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void screenRect(OdGsDCPoint lowerLeft, OdGsDCPoint upperRight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_screenRect__SWIG_0(swigCPtr, OdGsDCPoint.getCPtr(lowerLeft), OdGsDCPoint.getCPtr(upperRight));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void screenRect(OdGePoint2d lowerLeft, OdGePoint2d upperRight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_screenRect__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(lowerLeft), OdGePoint2d.getCPtr(upperRight));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void screenRectNorm(OdGsDCRect normalizedRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_screenRectNorm(swigCPtr, OdGsDCRect.getCPtr(normalizedRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void viewportDcCorners(OdGePoint2d lower_left, OdGePoint2d upper_right)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_viewportDcCorners(swigCPtr, OdGePoint2d.getCPtr(lower_left), OdGePoint2d.getCPtr(upper_right));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool doPerspectivePt(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_doPerspectivePt(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool doInversePerspectivePt(OdGePoint3d point)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_doInversePerspectivePt(swigCPtr, OdGePoint3d.getCPtr(point));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d eyeToWorldMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_eyeToWorldMatrix(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d worldToEyeMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_worldToEyeMatrix(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d eyeToScreenMatrix(OdGsOverlayId nOverlay)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_eyeToScreenMatrix__SWIG_0(swigCPtr, (int)nOverlay), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d worldToDeviceMatrix(OdGsOverlayId nOverlay)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_worldToDeviceMatrix__SWIG_1(swigCPtr, (int)nOverlay), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d objectToDeviceMatrix(OdGsOverlayId nOverlay)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_objectToDeviceMatrix__SWIG_1(swigCPtr, (int)nOverlay), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d projectionMatrix(uint nIncludes, OdGsOverlayId nOverlay)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_projectionMatrix__SWIG_1(swigCPtr, nIncludes, (int)nOverlay), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d projectionMatrix(uint nIncludes)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_projectionMatrix__SWIG_2(swigCPtr, nIncludes), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsView_ClearColor clearColor()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_clearColor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsView_ClearColor)result;
	}

	public OdGsOverlayId extentsToPixels(OdGsDCRect rc, OdGeExtents3d worldExt, OdGsBaseModel pModel, LineWeight extendByLineweight)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_extentsToPixels__SWIG_0(swigCPtr, OdGsDCRect.getCPtr(rc), OdGeExtents3d.getCPtr(worldExt), OdGsBaseModel.getCPtr(pModel), (int)extendByLineweight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsOverlayId)result;
	}

	public OdGsOverlayId extentsToPixels(OdGsDCRect rc, OdGeExtents3d worldExt, OdGsBaseModel pModel)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_extentsToPixels__SWIG_1(swigCPtr, OdGsDCRect.getCPtr(rc), OdGeExtents3d.getCPtr(worldExt), OdGsBaseModel.getCPtr(pModel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsOverlayId)result;
	}

	public virtual void invalidate(OdGeExtents3d worldExt, OdGsBaseModel pModel, LineWeight extendByLineweight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_invalidate__SWIG_2(swigCPtr, OdGeExtents3d.getCPtr(worldExt), OdGsBaseModel.getCPtr(pModel), (int)extendByLineweight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidate(OdGeExtents3d worldExt, OdGsBaseModel pModel)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_invalidate__SWIG_3(swigCPtr, OdGeExtents3d.getCPtr(worldExt), OdGsBaseModel.getCPtr(pModel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void invalidate(OdGsUpdateExtents extents, OdGsBaseModel pModel)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_invalidate__SWIG_4(swigCPtr, OdGsUpdateExtents.getCPtr(extents), OdGsBaseModel.getCPtr(pModel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void invalidateRegion(OdGiPathNode path)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_invalidateRegion(swigCPtr, OdGiPathNode.getCPtr(path));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsDCRectArray invalidRects(OdGsOverlayId nOverlay)
	{
		OdGsDCRectArray result = new OdGsDCRectArray(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_invalidRects__SWIG_0(swigCPtr, (int)nOverlay), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsDCRectArray invalidRects()
	{
		OdGsDCRectArray result = new OdGsDCRectArray(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_invalidRects__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isViewportOnScreen()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isViewportOnScreen(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCompletelyVisible()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isCompletelyVisible(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCompletelyVisible(bool val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setCompletelyVisible(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setInversion(bool invertedX, bool invertedY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setInversion(swigCPtr, invertedX, invertedY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiRegenType getRegenType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getRegenType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRegenType)result;
	}

	public double focalLength()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_focalLength(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d eyeVector()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_eyeVector(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d xVector()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_xVector(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d getUpVector()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getUpVector(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getLinetypeScaleMultiplier()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getLinetypeScaleMultiplier(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getLinetypeGenerationCriteria()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getLinetypeGenerationCriteria(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getDeviation(OdGiDeviationType deviationType, OdGePoint3d pointOnCurve, bool bRecalculate)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getDeviation__SWIG_0(swigCPtr, (int)deviationType, OdGePoint3d.getCPtr(pointOnCurve), bRecalculate);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getDeviation(OdGiDeviationType deviationType, OdGePoint3d pointOnCurve)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getDeviation__SWIG_1(swigCPtr, (int)deviationType, OdGePoint3d.getCPtr(pointOnCurve));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void initDeviation()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_initDeviation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int cachedDrawables()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_cachedDrawables(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint localViewportId(OdGsBaseModel pModel)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_localViewportId(swigCPtr, OdGsBaseModel.getCPtr(pModel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isLocalViewportIdCompatible(OdGsViewImpl pView)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isLocalViewportIdCompatible(swigCPtr, getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsViewLocalId getViewLocalId()
	{
		OdGsViewLocalId result = new OdGsViewLocalId(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getViewLocalId(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isViewRegenerated()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isViewRegenerated(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d center()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_center(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCenter(OdGePoint2d center)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setCenter(swigCPtr, OdGePoint2d.getCPtr(center));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d focusPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_focusPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isNonRectClipped()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isNonRectClipped(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasLweights()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_hasLweights(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint numLweights()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_numLweights(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint getLweight(int nLineweight)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getLweight(swigCPtr, nLineweight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array getLweightsEnum()
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getLweightsEnum(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt16Array getLweightsEnum2()
	{
		OdUInt16Array result = new OdUInt16Array(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getLweightsEnum2(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d dcScreenMin()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_dcScreenMin(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d dcScreenMax()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_dcScreenMax(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d dcLowerLeft()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_dcLowerLeft(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint2d dcUpperRight()
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_dcUpperRight(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d perspectiveMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_perspectiveMatrix(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double lensLengthToFOV(double lensLength)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_lensLengthToFOV(lensLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double lensLengthFromFOV(double fovAngle)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_lensLengthFromFOV(fovAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void invalidateCachedViewportGeometry(uint mask)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_invalidateCachedViewportGeometry__SWIG_1(swigCPtr, mask);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void registerOverlay(OdGsModel pModel)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_registerOverlay(swigCPtr, OdGsModel.getCPtr(pModel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void unregisterOverlay(OdGsModel pModel)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_unregisterOverlay(swigCPtr, OdGsModel.getCPtr(pModel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int partialUpdateExtentsEnlargement()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_partialUpdateExtentsEnlargement(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double calcDeviation(OdGiDeviationType type, OdGePoint3d pt)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_calcDeviation(swigCPtr, (int)type, OdGePoint3d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsProperties getViewportPropertiesRoot()
	{
		OdGsProperties rXObject = Helpers.GetRXObject<OdGsProperties>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getViewportPropertiesRoot(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool updateViewportProperties(uint incFlags)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_updateViewportProperties(swigCPtr, incFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsProperties getViewportPropertiesForType(OdGsProperties_PropertiesType type)
	{
		OdGsProperties rXObject = Helpers.GetRXObject<OdGsProperties>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getViewportPropertiesForType(swigCPtr, (int)type), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGeMatrix3d rotationMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_rotationMatrix(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public short viewportRotation()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_viewportRotation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRotated()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isRotated(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double unrotatedFieldHeight()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_unrotatedFieldHeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double unrotatedFieldWidth()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_unrotatedFieldWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double actualFieldWidth()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_actualFieldWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double actualFieldHeight()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_actualFieldHeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void initCullingVolume()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_initCullingVolume(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCullingVolume(OdGsCullingVolume newVol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setCullingVolume(swigCPtr, OdGsCullingVolume.getCPtr(newVol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCullingVolume cullingVolume()
	{
		OdGsCullingVolume rXObject = Helpers.GetRXObject<OdGsCullingVolume>(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_cullingVolume(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isCullingVolumeInitialized()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isCullingVolumeInitialized(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool cullingVolumeIntersectWithOpt(OdGsCullingPrimitive prim)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_cullingVolumeIntersectWithOpt(swigCPtr, OdGsCullingPrimitive.getCPtr(prim));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsCullingVolume_IntersectionStatus cullingVolumeIntersectWith(OdGsCullingPrimitive prim)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_cullingVolumeIntersectWith(swigCPtr, OdGsCullingPrimitive.getCPtr(prim));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsCullingVolume_IntersectionStatus)result;
	}

	public virtual void cullingVolumeTransformBy(OdGeMatrix3d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_cullingVolumeTransformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setViewport3dClipping(OdGiClipBoundary pBoundary, OdGiAbstractClipBoundary pClipInfo)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setViewport3dClipping__SWIG_0(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setViewport3dClipping(OdGiClipBoundary pBoundary)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setViewport3dClipping__SWIG_1(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdGiClipBoundary viewport3dClipping(OdGiAbstractClipBoundary ppClipInfo)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_viewport3dClipping__SWIG_0(swigCPtr, OdGiAbstractClipBoundary.getCPtr(ppClipInfo).Handle);
		OdGiClipBoundary result = ((intPtr == IntPtr.Zero) ? null : new OdGiClipBoundary(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGiClipBoundary viewport3dClipping()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_viewport3dClipping__SWIG_1(swigCPtr);
		OdGiClipBoundary result = ((intPtr == IntPtr.Zero) ? null : new OdGiClipBoundary(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiClipBoundaryWithAbstractData viewport3dClippingObject()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_viewport3dClippingObject(swigCPtr);
		OdGiClipBoundaryWithAbstractData result = ((intPtr == IntPtr.Zero) ? null : new OdGiClipBoundaryWithAbstractData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasViewport3dClipping()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_hasViewport3dClipping(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool saveViewState(OdGsFilerGSS pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_saveViewState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadViewState(OdGsFilerGSS pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_loadViewState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool saveClientViewState(OdGsFilerGSS pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_saveClientViewState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadClientViewState(OdGsFilerGSS pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_loadClientViewState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void enableAntiAliasing(uint nMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_enableAntiAliasing(swigCPtr, nMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual uint antiAliasingMode()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_antiAliasingMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void enableSSAO(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_enableSSAO(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool ssaoMode()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_ssaoMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void enableRayTracedView(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_enableRayTracedView(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool rayTracedView()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_rayTracedView(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void addClippingShape(OdSiShape arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_addClippingShape(swigCPtr, arg0.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void removeClippingShape(OdSiShape arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_removeClippingShape(swigCPtr, arg0.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdSiShapeConstPtrArray clippingShapes()
	{
		OdSiShapeConstPtrArray result = new OdSiShapeConstPtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_clippingShapes(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setClippingShapes(OdSiShapeConstPtrArray s)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setClippingShapes(swigCPtr, OdSiShapeConstPtrArray.getCPtr(s));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isShowFrozenLayers()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_isShowFrozenLayers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setShowFrozenLayers(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_setShowFrozenLayers(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int lineweightToPixels(LineWeight lw)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_lineweightToPixels__SWIG_1(swigCPtr, (int)lw);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d eyeToScreenMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsViewImpl_eyeToScreenMatrix__SWIG_2(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsDevice : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsDevice(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsDevice obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsDevice(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsDevice cast(OdRxObject pObj)
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGsDevice createObject()
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxDictionary properties()
	{
		OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_properties(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiContext userGiContext()
	{
		OdGiContext rXObject = Helpers.GetRXObject<OdGiContext>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_userGiContext(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setUserGiContext(OdGiContext pUserGiContext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_setUserGiContext(swigCPtr, OdGiContext.getCPtr(pUserGiContext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidate()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_invalidate__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidate(OdGsDCRect screenRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_invalidate__SWIG_1(swigCPtr, OdGsDCRect.getCPtr(screenRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isValid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_isValid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void update(OdGsDCRect pUpdatedRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_update__SWIG_0(swigCPtr, OdGsDCRect.getCPtr(pUpdatedRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void update()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_update__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onSize(OdGsDCRect outputRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_onSize__SWIG_0(swigCPtr, OdGsDCRect.getCPtr(outputRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onSize(OdGsDCRectDouble outputRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_onSize__SWIG_1(swigCPtr, OdGsDCRectDouble.getCPtr(outputRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getSize(OdGsDCRect outputRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_getSize__SWIG_0(swigCPtr, OdGsDCRect.getCPtr(outputRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getSize(OdGsDCRectDouble outputRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_getSize__SWIG_1(swigCPtr, OdGsDCRectDouble.getCPtr(outputRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onRealizeForegroundPalette()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_onRealizeForegroundPalette(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onRealizeBackgroundPalette()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_onRealizeBackgroundPalette(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onDisplayChange(int bitsPerPixel, int xPixels, int yPixels)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_onDisplayChange(swigCPtr, bitsPerPixel, xPixels, yPixels);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsView createView(OdGsClientViewInfo pViewInfo, bool enableLayerVisibilityPerView)
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_createView__SWIG_0(swigCPtr, OdGsClientViewInfo.getCPtr(pViewInfo), enableLayerVisibilityPerView), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsView createView(OdGsClientViewInfo pViewInfo)
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_createView__SWIG_1(swigCPtr, OdGsClientViewInfo.getCPtr(pViewInfo)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsView createView()
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_createView__SWIG_2(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void addView(OdGsView pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_addView(swigCPtr, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsModel createModel()
	{
		OdGsModel rXObject = Helpers.GetRXObject<OdGsModel>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_createModel(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isModelCompatible(OdGsModel pModel)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_isModelCompatible(swigCPtr, OdGsModel.getCPtr(pModel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool saveDeviceState(OdGsFilerGSS pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_saveDeviceState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadDeviceState(OdGsFilerGSS pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_loadDeviceState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsFilerDeviceInterface gsFilerDeviceInterface()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_gsFilerDeviceInterface(swigCPtr);
		OdGsFilerDeviceInterface result = ((intPtr == IntPtr.Zero) ? null : new OdGsFilerDeviceInterface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void insertView(int viewIndex, OdGsView pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_insertView(swigCPtr, viewIndex, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool eraseView(OdGsView pView)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_eraseView__SWIG_0(swigCPtr, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool eraseView(int viewIndex)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_eraseView__SWIG_1(swigCPtr, viewIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void eraseAllViews()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_eraseAllViews(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int numViews()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_numViews(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsView viewAt(int viewIndex)
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_viewAt(swigCPtr, viewIndex), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool setBackgroundColor(uint backgroundColor)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_setBackgroundColor(swigCPtr, backgroundColor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getBackgroundColor()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_getBackgroundColor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLogicalPalette(uint[] logicalPalette, int numColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_setLogicalPalette(swigCPtr, logicalPalette, numColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint[] getLogicalPalette(out int numColors)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_getLogicalPalette(swigCPtr, out numColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		int num = 257;
		int[] array = new int[num];
		Marshal.Copy(intPtr, array, 0, num);
		return Array.ConvertAll(array, (int in_value) => (uint)in_value);
	}

	public virtual void getSnapShot(ref OdGiRasterImage pImage, OdGsDCRect region)
	{
		IntPtr jarg = ((pImage == null) ? IntPtr.Zero : OdGiRasterImage.getCPtr(pImage).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_getSnapShot(swigCPtr, ref jarg, OdGsDCRect.getCPtr(region));
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

	public virtual OdGsUpdateManager getUpdateManager(bool createIfNotExist)
	{
		OdGsUpdateManager rXObject = Helpers.GetRXObject<OdGsUpdateManager>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_getUpdateManager__SWIG_0(swigCPtr, createIfNotExist), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsUpdateManager getUpdateManager()
	{
		OdGsUpdateManager rXObject = Helpers.GetRXObject<OdGsUpdateManager>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_getUpdateManager__SWIG_1(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setUpdateManager(OdGsUpdateManager pManager)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_setUpdateManager(swigCPtr, OdGsUpdateManager.getCPtr(pManager));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDevice_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

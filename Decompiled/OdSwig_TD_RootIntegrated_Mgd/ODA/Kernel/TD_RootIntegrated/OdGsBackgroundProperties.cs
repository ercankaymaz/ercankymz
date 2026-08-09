using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBackgroundProperties : OdGsProperties
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBackgroundProperties(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBackgroundProperties obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBackgroundProperties(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsBackgroundProperties cast(OdRxObject pObj)
	{
		OdGsBackgroundProperties rXObject = Helpers.GetRXObject<OdGsBackgroundProperties>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsBackgroundProperties createObject()
	{
		OdGsBackgroundProperties rXObject = Helpers.GetRXObject<OdGsBackgroundProperties>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiSolidBackgroundTraitsData solidBackgroundTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_solidBackgroundTraitsData(swigCPtr);
		OdGiSolidBackgroundTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiSolidBackgroundTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiGradientBackgroundTraitsData gradientBackgroundTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_gradientBackgroundTraitsData(swigCPtr);
		OdGiGradientBackgroundTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiGradientBackgroundTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiImageBackgroundTraitsData imageBackgroundTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_imageBackgroundTraitsData(swigCPtr);
		OdGiImageBackgroundTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiImageBackgroundTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiGroundPlaneBackgroundTraitsData groundPlaneBackgroundTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_groundPlaneBackgroundTraitsData(swigCPtr);
		OdGiGroundPlaneBackgroundTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiGroundPlaneBackgroundTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiSkyBackgroundTraitsData skyBackgroundTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_skyBackgroundTraitsData(swigCPtr);
		OdGiSkyBackgroundTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiSkyBackgroundTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiIBLBackgroundTraitsData iblBackgroundTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_iblBackgroundTraitsData(swigCPtr);
		OdGiIBLBackgroundTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiIBLBackgroundTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiEnvironmentBackgroundTraitsData environmentBackgroundTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_environmentBackgroundTraitsData(swigCPtr);
		OdGiEnvironmentBackgroundTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiEnvironmentBackgroundTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiCustomBackgroundTraitsData customBackgroundTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_customBackgroundTraitsData(swigCPtr);
		OdGiCustomBackgroundTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiCustomBackgroundTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiBackgroundTraitsData backgroundTraitsData()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_backgroundTraitsData(swigCPtr);
		OdGiBackgroundTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiBackgroundTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiDrawable_DrawableType backgroundType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_backgroundType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiDrawable_DrawableType)result;
	}

	public OdGsBackgroundProperties secondaryBackground()
	{
		OdGsBackgroundProperties rXObject = Helpers.GetRXObject<OdGsBackgroundProperties>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_secondaryBackground__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isTraitsModified()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_isTraitsModified(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearTraits()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_clearTraits(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdGsProperties_PropertiesType propertiesType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_propertiesType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsProperties_PropertiesType)result;
	}

	public override OdGsProperties propertiesForType(OdGsProperties_PropertiesType type)
	{
		OdGsProperties rXObject = Helpers.GetRXObject<OdGsProperties>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_propertiesForType(swigCPtr, (int)type), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual void update(OdGiDrawable pUnderlyingDrawable, OdGsViewImpl view, uint incFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_update__SWIG_0(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable), OdGsViewImpl.getCPtr(view), incFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void update(OdGiDrawable pUnderlyingDrawable, OdGsViewImpl view)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_update__SWIG_1(swigCPtr, OdGiDrawable.getCPtr(pUnderlyingDrawable), OdGsViewImpl.getCPtr(view));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void display(OdGsBaseVectorizer view, OdGsPropertiesDirectRenderOutput pdro, uint incFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_display__SWIG_0(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGsPropertiesDirectRenderOutput.getCPtr(pdro), incFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void display(OdGsBaseVectorizer view, OdGsPropertiesDirectRenderOutput pdro)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_display__SWIG_1(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGsPropertiesDirectRenderOutput.getCPtr(pdro));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void display(OdGsBaseVectorizer view)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_display__SWIG_2(swigCPtr, OdGsBaseVectorizer.getCPtr(view));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackgroundProperties_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

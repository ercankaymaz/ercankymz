using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBackground : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBackground(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBackground obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBackground(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsBackground cast(OdRxObject pObj)
	{
		OdGsBackground rXObject = Helpers.GetRXObject<OdGsBackground>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGsBackground createObject()
	{
		OdGsBackground rXObject = Helpers.GetRXObject<OdGsBackground>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsBackground_BackgroundType type()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_type(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsBackground_BackgroundType)result;
	}

	public virtual void display(OdGsBaseVectorizer view, OdGiDrawable pDrawable, OdGiBackgroundTraitsData pBackgroundTraits, OdGsPropertiesDirectRenderOutput pdro)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_display__SWIG_0(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGiDrawable.getCPtr(pDrawable), OdGiBackgroundTraitsData.getCPtr(pBackgroundTraits), OdGsPropertiesDirectRenderOutput.getCPtr(pdro));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void display(OdGsBaseVectorizer view, OdGiDrawable pDrawable, OdGiBackgroundTraitsData pBackgroundTraits)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_display__SWIG_1(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGiDrawable.getCPtr(pDrawable), OdGiBackgroundTraitsData.getCPtr(pBackgroundTraits));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void nestedBackgroundDisplay(OdGsBaseVectorizer view, OdGiDrawable pDrawable, OdGiBackgroundTraitsData pBackgroundTraits, OdGsPropertiesDirectRenderOutput pdro)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_nestedBackgroundDisplay__SWIG_0(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGiDrawable.getCPtr(pDrawable), OdGiBackgroundTraitsData.getCPtr(pBackgroundTraits), OdGsPropertiesDirectRenderOutput.getCPtr(pdro));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void nestedBackgroundDisplay(OdGsBaseVectorizer view, OdGiDrawable pDrawable, OdGiBackgroundTraitsData pBackgroundTraits)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_nestedBackgroundDisplay__SWIG_1(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdGiDrawable.getCPtr(pDrawable), OdGiBackgroundTraitsData.getCPtr(pBackgroundTraits));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setNestedBackground(OdGsNestedBackground arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_setNestedBackground(swigCPtr, OdGsNestedBackground.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsNestedBackground getNestedBackground()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_getNestedBackground(swigCPtr);
		OdGsNestedBackground result = ((intPtr == IntPtr.Zero) ? null : new OdGsNestedBackground(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBackground_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

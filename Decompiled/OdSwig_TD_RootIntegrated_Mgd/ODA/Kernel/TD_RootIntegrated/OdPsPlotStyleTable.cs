using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdPsPlotStyleTable : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPsPlotStyleTable(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPsPlotStyleTable obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdPsPlotStyleTable(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPsPlotStyleTable cast(OdRxObject pObj)
	{
		OdPsPlotStyleTable rXObject = Helpers.GetRXObject<OdPsPlotStyleTable>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPsPlotStyleTable createObject()
	{
		OdPsPlotStyleTable rXObject = Helpers.GetRXObject<OdPsPlotStyleTable>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isApplyScaleFactor()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_isApplyScaleFactor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string description()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_description(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double scaleFactor()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_scaleFactor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isDisplayCustomLineweightUnits()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_isDisplayCustomLineweightUnits(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getLineweightAt(uint index)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_getLineweightAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPsPlotStyle plotStyleAt(string name)
	{
		OdPsPlotStyle rXObject = Helpers.GetRXObject<OdPsPlotStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_plotStyleAt__SWIG_0(swigCPtr, name), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdPsPlotStyle plotStyleAt(int index)
	{
		OdPsPlotStyle rXObject = Helpers.GetRXObject<OdPsPlotStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_plotStyleAt__SWIG_1(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint plotStyleSize()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_plotStyleSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint lineweightSize()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_lineweightSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isAciTableAvailable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_isAciTableAvailable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPsPlotStyle addNewPlotStyle(string styleName)
	{
		OdPsPlotStyle rXObject = Helpers.GetRXObject<OdPsPlotStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_addNewPlotStyle(swigCPtr, styleName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdPsPlotStyle delPlotStyle(OdPsPlotStyle pPsPtr)
	{
		OdPsPlotStyle rXObject = Helpers.GetRXObject<OdPsPlotStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_delPlotStyle(swigCPtr, OdPsPlotStyle.getCPtr(pPsPtr)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setDescription(string desc)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_setDescription(swigCPtr, desc);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setScaleFactor(double scFac)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_setScaleFactor(swigCPtr, scFac);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setApplyScaleFactor(bool flag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_setApplyScaleFactor(swigCPtr, flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDisplayCustomLineweightUnits(bool flag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_setDisplayCustomLineweightUnits(swigCPtr, flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineweightAt(double value, uint index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_setLineweightAt(swigCPtr, value, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineweights(OdDoubleArray lineweights)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_setLineweights(swigCPtr, OdDoubleArray.getCPtr(lineweights).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setAciTableAvailable(bool flag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_setAciTableAvailable(swigCPtr, flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPlotStylesIndexed(OdPsPlotStylesArray plotStylesIndexed)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_setPlotStylesIndexed(swigCPtr, OdPsPlotStylesArray.getCPtr(plotStylesIndexed));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPlotStyles(OdPsPlotStylesMap plotStyles)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_setPlotStyles(swigCPtr, OdPsPlotStylesMap.getCPtr(plotStyles));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addPlotStyle(OdPsPlotStyle pPs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_addPlotStyle(swigCPtr, OdPsPlotStyle.getCPtr(pPs));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setOrdering(OdStringArray order)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_setOrdering(swigCPtr, OdStringArray.getCPtr(order));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdPsPlotStylesMap plotStyles()
	{
		OdPsPlotStylesMap result = new OdPsPlotStylesMap(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_plotStyles(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPsPlotStylesArray plotStylesIndexed()
	{
		OdPsPlotStylesArray result = new OdPsPlotStylesArray(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_plotStylesIndexed(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleTable_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

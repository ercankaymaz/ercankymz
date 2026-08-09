using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbAbstractPlotDataForDbViewport : OdDbAbstractPlotData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbAbstractPlotDataForDbViewport(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbAbstractPlotDataForDbViewport obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbAbstractPlotDataForDbViewport(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override bool useStandardScale(OdRxObject pPlotObj)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_useStandardScale(swigCPtr, OdRxObject.getCPtr(pPlotObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double customScale(OdRxObject pPlotObj)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_customScale(swigCPtr, OdRxObject.getCPtr(pPlotObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setCustomScale(OdRxObject pPlotObj, double customScale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_setCustomScale(swigCPtr, OdRxObject.getCPtr(pPlotObj), customScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbPlotSettings_StdScaleType standardScale(OdRxObject pPlotObj)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_standardScale(swigCPtr, OdRxObject.getCPtr(pPlotObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbPlotSettings_StdScaleType)result;
	}

	public override void setStandardScale(OdRxObject pPlotObj, OdDbPlotSettings_StdScaleType standardScale)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_setStandardScale(swigCPtr, OdRxObject.getCPtr(pPlotObj), (int)standardScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override string styleSheet(OdRxObject pPlotObj)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_styleSheet(swigCPtr, OdRxObject.getCPtr(pPlotObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setStyleSheet(OdRxObject pPlotObj, string styleSheetName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_setStyleSheet(swigCPtr, OdRxObject.getCPtr(pPlotObj), styleSheetName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbPlotSettings_ShadePlotType shadePlot(OdRxObject pPlotObj)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_shadePlot(swigCPtr, OdRxObject.getCPtr(pPlotObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbPlotSettings_ShadePlotType)result;
	}

	public override void setShadePlot(OdRxObject pPlotObj, OdDbPlotSettings_ShadePlotType shadePlotSet)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_setShadePlot__SWIG_0(swigCPtr, OdRxObject.getCPtr(pPlotObj), (int)shadePlotSet);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbObjectId shadePlotId(OdRxObject pPlotObj)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_shadePlotId(swigCPtr, OdRxObject.getCPtr(pPlotObj)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setShadePlot(OdRxObject pPlotObj, OdDbPlotSettings_ShadePlotType type, OdDbObjectId shadePlotId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_setShadePlot__SWIG_1(swigCPtr, OdRxObject.getCPtr(pPlotObj), (int)type, OdDbObjectId.getCPtr(shadePlotId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool plotHiddenLines(OdRxObject pPlotObj)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_plotHiddenLines(swigCPtr, OdRxObject.getCPtr(pPlotObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setPlotHiddenLines(OdRxObject pPlotObj, bool plotHidden)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_setPlotHiddenLines(swigCPtr, OdRxObject.getCPtr(pPlotObj), plotHidden);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool plotWireframe(OdRxObject pPlotObj)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_plotWireframe(swigCPtr, OdRxObject.getCPtr(pPlotObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool plotAsRaster(OdRxObject pPlotObj)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_plotAsRaster(swigCPtr, OdRxObject.getCPtr(pPlotObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool plotTransparency(OdRxObject pPlotObj)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_plotTransparency(swigCPtr, OdRxObject.getCPtr(pPlotObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setPlotTransparency(OdRxObject pPlotObj, bool bEnable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_setPlotTransparency(swigCPtr, OdRxObject.getCPtr(pPlotObj), bEnable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool plotLineweights(OdRxObject pPlotObj)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_plotLineweights(swigCPtr, OdRxObject.getCPtr(pPlotObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setPlotLineweights(OdRxObject pPlotObj, bool bEnable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_setPlotLineweights(swigCPtr, OdRxObject.getCPtr(pPlotObj), bEnable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool modelType(OdRxObject pPlotObj)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_modelType(swigCPtr, OdRxObject.getCPtr(pPlotObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setModelType(OdRxObject pPlotObj, bool modelTypeSet)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_setModelType(swigCPtr, OdRxObject.getCPtr(pPlotObj), modelTypeSet);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractPlotDataForDbViewport_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

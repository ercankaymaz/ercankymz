using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.PlotSettingsValidator;

public class OdPlotSettingsValidatorPEImpl : OdDbPlotSettingsValidatorPE
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPlotSettingsValidatorPEImpl(IntPtr cPtr, bool cMemoryOwn)
		: base(PlotSettingsValidator_GlobalsPINVOKE.OdPlotSettingsValidatorPEImpl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPlotSettingsValidatorPEImpl obj)
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
					PlotSettingsValidator_GlobalsPINVOKE.delete_OdPlotSettingsValidatorPEImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override OdResult getMediaList(string deviceName, OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator mediaList, bool bUpdateMediaMargins)
	{
		int result = PlotSettingsValidator_GlobalsPINVOKE.OdPlotSettingsValidatorPEImpl_getMediaList(swigCPtr, deviceName, OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator.getCPtr(mediaList).Handle, bUpdateMediaMargins);
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PlotSettingsValidator_GlobalsPINVOKE.OdPlotSettingsValidatorPEImpl_getRealClassName(ptr);
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

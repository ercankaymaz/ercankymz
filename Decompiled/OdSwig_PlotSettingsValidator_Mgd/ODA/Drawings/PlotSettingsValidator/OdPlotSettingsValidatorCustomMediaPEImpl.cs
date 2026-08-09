using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Drawings.PlotSettingsValidator;

public class OdPlotSettingsValidatorCustomMediaPEImpl : OdDbPlotSettingsValidatorCustomMediaPE
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPlotSettingsValidatorCustomMediaPEImpl(IntPtr cPtr, bool cMemoryOwn)
		: base(PlotSettingsValidator_GlobalsPINVOKE.OdPlotSettingsValidatorCustomMediaPEImpl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPlotSettingsValidatorCustomMediaPEImpl obj)
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
					PlotSettingsValidator_GlobalsPINVOKE.delete_OdPlotSettingsValidatorCustomMediaPEImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PlotSettingsValidator_GlobalsPINVOKE.OdPlotSettingsValidatorCustomMediaPEImpl_getRealClassName(ptr);
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

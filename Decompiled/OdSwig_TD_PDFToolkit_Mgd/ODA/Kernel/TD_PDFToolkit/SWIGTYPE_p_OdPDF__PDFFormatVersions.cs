using System;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_PDFToolkit;

public class SWIGTYPE_p_OdPDF__PDFFormatVersions
{
	private HandleRef swigCPtr;

	internal SWIGTYPE_p_OdPDF__PDFFormatVersions(IntPtr cPtr, bool futureUse)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	protected SWIGTYPE_p_OdPDF__PDFFormatVersions()
	{
		swigCPtr = new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef getCPtr(SWIGTYPE_p_OdPDF__PDFFormatVersions obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}
}

using System;
using System.Runtime.InteropServices;

namespace ODA.Publish.PdfPublish;

public class SWIGTYPE_p_OdPDF__OdDatabaseToPdfWrapperInterface
{
	private HandleRef swigCPtr;

	internal SWIGTYPE_p_OdPDF__OdDatabaseToPdfWrapperInterface(IntPtr cPtr, bool futureUse)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	protected SWIGTYPE_p_OdPDF__OdDatabaseToPdfWrapperInterface()
	{
		swigCPtr = new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef getCPtr(SWIGTYPE_p_OdPDF__OdDatabaseToPdfWrapperInterface obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}
}

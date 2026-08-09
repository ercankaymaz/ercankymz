using System;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class SWIGTYPE_p_PCCERT_CONTEXT
{
	private HandleRef swigCPtr;

	internal SWIGTYPE_p_PCCERT_CONTEXT(IntPtr cPtr, bool futureUse)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	protected SWIGTYPE_p_PCCERT_CONTEXT()
	{
		swigCPtr = new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef getCPtr(SWIGTYPE_p_PCCERT_CONTEXT obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}
}

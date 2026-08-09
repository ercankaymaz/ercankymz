using System;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class SWIGTYPE_p_OdDbNextIteratorWrapT_OdDbXrecordIterator_t
{
	private HandleRef swigCPtr;

	internal SWIGTYPE_p_OdDbNextIteratorWrapT_OdDbXrecordIterator_t(IntPtr cPtr, bool futureUse)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	protected SWIGTYPE_p_OdDbNextIteratorWrapT_OdDbXrecordIterator_t()
	{
		swigCPtr = new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef getCPtr(SWIGTYPE_p_OdDbNextIteratorWrapT_OdDbXrecordIterator_t obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}
}

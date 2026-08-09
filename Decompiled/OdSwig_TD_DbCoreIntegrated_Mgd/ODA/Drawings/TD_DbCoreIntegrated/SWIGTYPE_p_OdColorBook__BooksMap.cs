using System;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class SWIGTYPE_p_OdColorBook__BooksMap
{
	private HandleRef swigCPtr;

	internal SWIGTYPE_p_OdColorBook__BooksMap(IntPtr cPtr, bool futureUse)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	protected SWIGTYPE_p_OdColorBook__BooksMap()
	{
		swigCPtr = new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef getCPtr(SWIGTYPE_p_OdColorBook__BooksMap obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}
}

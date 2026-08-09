using System;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class SWIGTYPE_p_p_OdDb3dSolidGeomParams
{
	private HandleRef swigCPtr;

	internal SWIGTYPE_p_p_OdDb3dSolidGeomParams(IntPtr cPtr, bool futureUse)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	protected SWIGTYPE_p_p_OdDb3dSolidGeomParams()
	{
		swigCPtr = new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef getCPtr(SWIGTYPE_p_p_OdDb3dSolidGeomParams obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}
}

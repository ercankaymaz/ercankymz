using System;
using System.Runtime.InteropServices;

namespace ODA.PointCloud.RcsFileServices;

public class SWIGTYPE_p_OdRcpFileWriterPtr
{
	private HandleRef swigCPtr;

	internal SWIGTYPE_p_OdRcpFileWriterPtr(IntPtr cPtr, bool futureUse)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	protected SWIGTYPE_p_OdRcpFileWriterPtr()
	{
		swigCPtr = new HandleRef(null, IntPtr.Zero);
	}

	internal static HandleRef getCPtr(SWIGTYPE_p_OdRcpFileWriterPtr obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}
}

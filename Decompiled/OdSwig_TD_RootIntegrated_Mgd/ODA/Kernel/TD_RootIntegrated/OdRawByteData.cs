using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRawByteData : OdByteData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRawByteData(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRawByteData_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRawByteData obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRawByteData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public void init(byte[] pData, uint length)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRawByteData_init(swigCPtr, Helpers.MarshalbyteFixedArray(pData), length);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint bytesLeft()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRawByteData_bytesLeft(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void read(uint nBytes, IntPtr buffer)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRawByteData_read(swigCPtr, nBytes, buffer);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRawByteData_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

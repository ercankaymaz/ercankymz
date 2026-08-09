using System;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdTrVisRawTexture : IDisposable
{
	private HandleRef swigCPtr;

	private bool swigCMemOwnBase;

	public OdTrVisRawTexture(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwnBase = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	public static HandleRef getCPtr(OdTrVisRawTexture obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdTrVisRawTexture()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwnBase)
				{
					swigCMemOwnBase = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdTrVisRawTexture(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdTrVisRawTexture()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdTrVisRawTexture(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint width, uint height, uint format)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTrVisRawTexture_resize(swigCPtr, width, height, format);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static uint pixelSize(uint format)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdTrVisRawTexture_pixelSize(format);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdTrVisRawTexture_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint width()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdTrVisRawTexture_width(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint height()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdTrVisRawTexture_height(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint format()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdTrVisRawTexture_format(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte[] data()
	{
		byte[] result = Helpers.UnMarshalbyteFixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdTrVisRawTexture_data__SWIG_0(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

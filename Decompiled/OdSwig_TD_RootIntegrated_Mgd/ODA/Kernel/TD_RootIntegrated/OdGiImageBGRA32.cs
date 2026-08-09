using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiImageBGRA32 : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiImageBGRA32(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiImageBGRA32 obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiImageBGRA32()
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
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiImageBGRA32(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiImageBGRA32()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiImageBGRA32__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiImageBGRA32(uint imageWidth, uint imageHeight, OdGiPixelBGRA32 imageData)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiImageBGRA32__SWIG_1(imageWidth, imageHeight, OdGiPixelBGRA32.getCPtr(imageData)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiPixelBGRA32 image()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBGRA32_image(swigCPtr);
		OdGiPixelBGRA32 result = ((intPtr == IntPtr.Zero) ? null : new OdGiPixelBGRA32(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint width()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBGRA32_width(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint height()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBGRA32_height(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setImage(uint imageWidth, uint imageHeight, OdGiPixelBGRA32 imageData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiImageBGRA32_setImage(swigCPtr, imageWidth, imageHeight, OdGiPixelBGRA32.getCPtr(imageData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

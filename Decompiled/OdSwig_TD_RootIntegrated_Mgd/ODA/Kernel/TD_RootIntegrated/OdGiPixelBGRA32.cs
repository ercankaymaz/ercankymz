using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPixelBGRA32 : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPixelBGRA32(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPixelBGRA32 obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiPixelBGRA32()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPixelBGRA32(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiPixelBGRA32()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPixelBGRA32__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiPixelBGRA32(uint bgra)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPixelBGRA32__SWIG_1(bgra), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiPixelBGRA32(byte blue, byte green, byte red, byte alpha)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPixelBGRA32__SWIG_2(blue, green, red, alpha), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint getBGRA()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_getBGRA(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint getRGBA()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_getRGBA(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte blue()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_blue(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte green()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_green(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte red()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_red(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte alpha()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_alpha(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBGRA(uint bgra)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_setBGRA__SWIG_0(swigCPtr, bgra);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBGRA(byte blue, byte green, byte red, byte alpha)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_setBGRA__SWIG_1(swigCPtr, blue, green, red, alpha);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRGBA(uint rgba)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_setRGBA__SWIG_0(swigCPtr, rgba);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRGBA(byte red, byte green, byte blue, byte alpha)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_setRGBA__SWIG_1(swigCPtr, red, green, blue, alpha);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBlue(byte blue)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_setBlue(swigCPtr, blue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGreen(byte green)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_setGreen(swigCPtr, green);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRed(byte red)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_setRed(swigCPtr, red);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAlpha(byte alpha)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPixelBGRA32_setAlpha(swigCPtr, alpha);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

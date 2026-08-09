using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsPalette : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsPalette(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsPalette_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsPalette obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsPalette(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual uint numColors()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsPalette_numColors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setNumColors(uint nColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsPalette_setNumColors(swigCPtr, nColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setColorAt(uint nIndex, byte blue, byte green, byte red, byte alpha)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsPalette_setColorAt__SWIG_0(swigCPtr, nIndex, blue, green, red, alpha);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setColorAt(uint nIndex, byte blue, byte green, byte red)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsPalette_setColorAt__SWIG_1(swigCPtr, nIndex, blue, green, red);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void colorAt(uint nIndex, out byte blue, out byte green, out byte red, byte[] pAlpha)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsPalette_colorAt__SWIG_0(swigCPtr, nIndex, out blue, out green, out red, Helpers.MarshalbyteFixedArray(pAlpha));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void colorAt(uint nIndex, out byte blue, out byte green, out byte red)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsPalette_colorAt__SWIG_1(swigCPtr, nIndex, out blue, out green, out red);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setColors(uint nColors, uint[] pColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsPalette_setColors(swigCPtr, nColors, pColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsPalette_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

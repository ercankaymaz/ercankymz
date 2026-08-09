using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdCmEntityColor : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdCmEntityColor(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdCmEntityColor obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdCmEntityColor()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdCmEntityColor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdCmEntityColor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdCmEntityColor__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor(OdCmEntityColor color)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdCmEntityColor__SWIG_1(getCPtr(color)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor(OdCmEntityColor_ColorMethod colorMethod)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdCmEntityColor__SWIG_2((int)colorMethod), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor(byte red, byte green, byte blue)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdCmEntityColor__SWIG_3(red, green, blue), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor Assign(OdCmEntityColor color)
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_Assign(swigCPtr, getCPtr(color)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdCmEntityColor color)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_IsEqual(swigCPtr, getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdCmEntityColor color)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_IsNotEqual(swigCPtr, getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColorMethod(OdCmEntityColor_ColorMethod colorMethod)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setColorMethod__SWIG_0(swigCPtr, (int)colorMethod);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor_ColorMethod colorMethod()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_colorMethod__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCmEntityColor_ColorMethod)result;
	}

	public void setColor(uint color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setColor__SWIG_0(swigCPtr, color);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint color()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_color(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColorIndex(short colorIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setColorIndex__SWIG_0(swigCPtr, colorIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public short colorIndex()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_colorIndex__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRGB(byte red, byte green, byte blue)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setRGB__SWIG_0(swigCPtr, red, green, blue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRed(byte red)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setRed__SWIG_0(swigCPtr, red);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGreen(byte green)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setGreen__SWIG_0(swigCPtr, green);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBlue(byte blue)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setBlue__SWIG_0(swigCPtr, blue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public byte red()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_red__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte green()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_green__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte blue()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_blue__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isByColor()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isByColor__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isByLayer()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isByLayer__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isByBlock()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isByBlock__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isByACI()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isByACI__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isForeground()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isForeground__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isByDgnIndex()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isByDgnIndex__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isNone()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isNone__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTrueColor()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setTrueColor__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void setColorMethod(uint pRGBM, OdCmEntityColor_ColorMethod colorMethod)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setColorMethod__SWIG_1(pRGBM, (int)colorMethod);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdCmEntityColor_ColorMethod colorMethod(uint pRGBM)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_colorMethod__SWIG_1(pRGBM);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCmEntityColor_ColorMethod)result;
	}

	public static void setColor(uint pRGBM, uint color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setColor__SWIG_1(pRGBM, color);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void setColorIndex(uint pRGBM, short colorIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setColorIndex__SWIG_1(pRGBM, colorIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void setDgnColorIndex(uint pRGBM, short colorIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setDgnColorIndex(pRGBM, colorIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static short colorIndex(uint pRGBM)
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_colorIndex__SWIG_1(pRGBM);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void setRGB(uint pRGBM, byte red, byte green, byte blue)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setRGB__SWIG_1(pRGBM, red, green, blue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void setRed(uint pRGBM, byte red)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setRed__SWIG_1(pRGBM, red);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void setGreen(uint pRGBM, byte green)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setGreen__SWIG_1(pRGBM, green);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void setBlue(uint pRGBM, byte blue)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setBlue__SWIG_1(pRGBM, blue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static byte red(uint pRGBM)
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_red__SWIG_1(pRGBM);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static byte green(uint pRGBM)
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_green__SWIG_1(pRGBM);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static byte blue(uint pRGBM)
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_blue__SWIG_1(pRGBM);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isByColor(uint pRGBM)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isByColor__SWIG_1(pRGBM);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isByLayer(uint pRGBM)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isByLayer__SWIG_1(pRGBM);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isByBlock(uint pRGBM)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isByBlock__SWIG_1(pRGBM);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isByACI(uint pRGBM)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isByACI__SWIG_1(pRGBM);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isForeground(uint pRGBM)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isForeground__SWIG_1(pRGBM);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isByDgnIndex(uint pRGBM)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isByDgnIndex__SWIG_1(pRGBM);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isNone(uint pRGBM)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_isNone__SWIG_1(pRGBM);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void setTrueColor(uint pRGBM)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_setTrueColor__SWIG_1(pRGBM);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static uint lookUpRGB(byte colorIndex)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_lookUpRGB(colorIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static byte lookUpACI(byte red, byte green, byte blue)
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdCmEntityColor_lookUpACI(red, green, blue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

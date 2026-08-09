using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiGradientGenerator : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiGradientGenerator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiGradientGenerator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiGradientGenerator()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiGradientGenerator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiGradientGenerator()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiGradientGenerator__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiGradientGenerator(OdGiGradientGenerator other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiGradientGenerator__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createColorArray(uint nColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createColorArray(swigCPtr, nColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createColorArrayFilled(uint color, uint nColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createColorArrayFilled(swigCPtr, color, nColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void copyGradient(OdUInt32Array other)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_copyGradient__SWIG_0(swigCPtr, OdUInt32Array.getCPtr(other).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void copyGradient(uint[] colors)
	{
		IntPtr intPtr = Helpers.MarshalPalette(colors);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_copyGradient__SWIG_1(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public void createGradient(uint color1, uint color2, uint nColors, OdGiGradientGenerator_InterpolationType ipl)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createGradient__SWIG_0(swigCPtr, color1, color2, nColors, (int)ipl);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createGradient(uint color1, uint color2, uint nColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createGradient__SWIG_1(swigCPtr, color1, color2, nColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createGradient(uint color1, uint color2, uint color3, uint nColors, OdGiGradientGenerator_InterpolationType ipl)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createGradient__SWIG_2(swigCPtr, color1, color2, color3, nColors, (int)ipl);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createGradient(uint color1, uint color2, uint color3, uint nColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createGradient__SWIG_3(swigCPtr, color1, color2, color3, nColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createGradient(uint color1, uint color2, uint color3, uint nColors, OdGiGradientGenerator_InterpolationType ipl1, OdGiGradientGenerator_InterpolationType ipl2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createGradient__SWIG_4(swigCPtr, color1, color2, color3, nColors, (int)ipl1, (int)ipl2);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createGradient(uint color1, uint color2, uint color3, uint color4, uint nColors, OdGiGradientGenerator_InterpolationType ipl)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createGradient__SWIG_5(swigCPtr, color1, color2, color3, color4, nColors, (int)ipl);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createGradient(uint color1, uint color2, uint color3, uint color4, uint nColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createGradient__SWIG_6(swigCPtr, color1, color2, color3, color4, nColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createGradient(uint color1, uint color2, uint color3, uint color4, uint nColors, OdGiGradientGenerator_InterpolationType ipl1, OdGiGradientGenerator_InterpolationType ipl2, OdGiGradientGenerator_InterpolationType ipl3)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createGradient__SWIG_7(swigCPtr, color1, color2, color3, color4, nColors, (int)ipl1, (int)ipl2, (int)ipl3);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createGradient(uint color1, uint color2, uint color3, uint color4, uint color5, uint nColors, OdGiGradientGenerator_InterpolationType ipl)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createGradient__SWIG_8(swigCPtr, color1, color2, color3, color4, color5, nColors, (int)ipl);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createGradient(uint color1, uint color2, uint color3, uint color4, uint color5, uint nColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createGradient__SWIG_9(swigCPtr, color1, color2, color3, color4, color5, nColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createGradient(uint color1, uint color2, uint color3, uint color4, uint color5, uint nColors, OdGiGradientGenerator_InterpolationType ipl1, OdGiGradientGenerator_InterpolationType ipl2, OdGiGradientGenerator_InterpolationType ipl3, OdGiGradientGenerator_InterpolationType ipl4)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createGradient__SWIG_10(swigCPtr, color1, color2, color3, color4, color5, nColors, (int)ipl1, (int)ipl2, (int)ipl3, (int)ipl4);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fillInterval(uint color, double from, double to)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_fillInterval__SWIG_0(swigCPtr, color, from, to);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fillInterval(uint color, double from)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_fillInterval__SWIG_1(swigCPtr, color, from);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fillInterval(uint color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_fillInterval__SWIG_2(swigCPtr, color);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fillInterval(uint color, uint from, uint to)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_fillInterval__SWIG_3(swigCPtr, color, from, to);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void generateInterval(uint color1, uint color2, double from, double to, OdGiGradientGenerator_InterpolationType ipl)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_generateInterval__SWIG_0(swigCPtr, color1, color2, from, to, (int)ipl);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void generateInterval(uint color1, uint color2, double from, double to)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_generateInterval__SWIG_1(swigCPtr, color1, color2, from, to);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void generateInterval(uint color1, uint color2, double from)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_generateInterval__SWIG_2(swigCPtr, color1, color2, from);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void generateInterval(uint color1, uint color2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_generateInterval__SWIG_3(swigCPtr, color1, color2);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void generateInterval(uint color1, uint color2, uint from, uint to, OdGiGradientGenerator_InterpolationType ipl)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_generateInterval__SWIG_4(swigCPtr, color1, color2, from, to, (int)ipl);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void generateInterval(uint color1, uint color2, uint from, uint to)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_generateInterval__SWIG_5(swigCPtr, color1, color2, from, to);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint colorsCount()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_colorsCount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint colorAt(uint nColor)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_colorAt__SWIG_0(swigCPtr, nColor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint colorAt(double at)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_colorAt__SWIG_1(swigCPtr, at);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isInitialized()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_isInitialized(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt32Array asArray()
	{
		OdUInt32Array result = new OdUInt32Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_asArray(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAddressMode(OdGiGradientGenerator_AddressMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_setAddressMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiGradientGenerator_AddressMode addressMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_addressMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiGradientGenerator_AddressMode)result;
	}

	public static uint interpolateColor(uint color1, uint color2, double at, OdGiGradientGenerator_InterpolationType ipl, OdGiGradientGenerator_AddressMode mode)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_interpolateColor__SWIG_0(color1, color2, at, (int)ipl, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint interpolateColor(uint color1, uint color2, double at, OdGiGradientGenerator_InterpolationType ipl)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_interpolateColor__SWIG_1(color1, color2, at, (int)ipl);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint interpolateColor(uint color1, uint color2, double at)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_interpolateColor__SWIG_2(color1, color2, at);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiGradientGenerator Assign(OdGiGradientGenerator other)
	{
		OdGiGradientGenerator result = new OdGiGradientGenerator(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_Assign(swigCPtr, getCPtr(other)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiGradientGenerator createSpectrumGradient(uint nColors, byte alpha)
	{
		OdGiGradientGenerator result = new OdGiGradientGenerator(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createSpectrumGradient__SWIG_0(nColors, alpha), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiGradientGenerator createSpectrumGradient(uint nColors)
	{
		OdGiGradientGenerator result = new OdGiGradientGenerator(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_createSpectrumGradient__SWIG_1(nColors), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void appendGradient(OdGiGradientGenerator other)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_appendGradient(swigCPtr, getCPtr(other));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdGiGradientGenerator other)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientGenerator_Add(swigCPtr, getCPtr(other));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}

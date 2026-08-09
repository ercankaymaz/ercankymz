using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdExGiRasterImage : OdGiRasterImageParam
{
	public class Header : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public uint m_width
		{
			get
			{
				uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Header_m_width_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Header_m_width_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public uint m_height
		{
			get
			{
				uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Header_m_height_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Header_m_height_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public ushort m_bitPerPixel
		{
			get
			{
				ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Header_m_bitPerPixel_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Header_m_bitPerPixel_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double m_xPelsPerUnit
		{
			get
			{
				double result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Header_m_xPelsPerUnit_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Header_m_xPelsPerUnit_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double m_yPelsPerUnit
		{
			get
			{
				double result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Header_m_yPelsPerUnit_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Header_m_yPelsPerUnit_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdGiRasterImage_Units m_resUnits
		{
			get
			{
				int result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Header_m_resUnits_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return (OdGiRasterImage_Units)result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Header_m_resUnits_set(swigCPtr, (int)value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Header(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(Header obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~Header()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdExGiRasterImage_Header(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public Header(uint width, uint height, ushort bitPerPixel)
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdExGiRasterImage_Header__SWIG_0(width, height, bitPerPixel), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public Header()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdExGiRasterImage_Header__SWIG_1(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class Palette : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Palette(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(Palette obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~Palette()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdExGiRasterImage_Palette(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public byte[] getData()
		{
			byte[] result = Helpers.UnMarshalbyteFixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Palette_getData(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public OdBinaryData data()
		{
			OdBinaryData result = new OdBinaryData(TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Palette_data(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public OdBinaryData getBinData()
		{
			OdBinaryData result = new OdBinaryData(TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Palette_getBinData(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public uint numColors()
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Palette_numColors(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setNumColors(uint nColors)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Palette_setNumColors(swigCPtr, nColors);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setColorAt(uint nIndex, byte blue, byte green, byte red, byte alpha)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Palette_setColorAt__SWIG_0(swigCPtr, nIndex, blue, green, red, alpha);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setColorAt(uint nIndex, byte blue, byte green, byte red)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Palette_setColorAt__SWIG_1(swigCPtr, nIndex, blue, green, red);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void colorAt(uint nIndex, out byte blue, out byte green, out byte red, byte[] pAlpha)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Palette_colorAt__SWIG_0(swigCPtr, nIndex, out blue, out green, out red, Helpers.MarshalbyteFixedArray(pAlpha));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void colorAt(uint nIndex, out byte blue, out byte green, out byte red)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_Palette_colorAt__SWIG_1(swigCPtr, nIndex, out blue, out green, out red);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public Palette()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdExGiRasterImage_Palette(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdExGiRasterImage(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdExGiRasterImage obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdExGiRasterImage(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new virtual OdRxObject clone()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_clone(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setModule(OdRxModule pModule)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_setModule(swigCPtr, OdRxModule.getCPtr(pModule));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static uint bitDataSize(uint xPixels, uint yPixels, ushort bitsPerPixel)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_bitDataSize__SWIG_0(xPixels, yPixels, bitsPerPixel);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint bitDataSize()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_bitDataSize__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRasterData bits()
	{
		OdRasterData result = new OdRasterData(TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_bits(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRasterData getBits()
	{
		OdRasterData result = new OdRasterData(TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_getBits(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte[] getScanLines(out uint numBytes)
	{
		byte[] result = Helpers.UnMarshalbyteFixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_getScanLines(swigCPtr, out numBytes));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBits(OdRasterData data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_setBits__SWIG_0(swigCPtr, OdRasterData.getCPtr(data));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBits(byte[] data, uint numBytes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_setBits__SWIG_1(swigCPtr, Helpers.MarshalbyteFixedArray(data), numBytes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMetrics(uint xPixels, uint yPixels, ushort bitsPerPixel)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_setMetrics(swigCPtr, xPixels, yPixels, bitsPerPixel);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDefaultResolution(OdGiRasterImage_Units units, double xPelsPerUnit, double yPelsPerUnit)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_setDefaultResolution(swigCPtr, (int)units, xPelsPerUnit, yPelsPerUnit);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTransparentColor(int nTransparentColor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_setTransparentColor(swigCPtr, nTransparentColor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPalNumColors(uint numColors)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_setPalNumColors(swigCPtr, numColors);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint getPalNumColors()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_getPalNumColors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public Palette getPalette()
	{
		Palette result = new Palette(TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_getPalette(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint paletteDataSize()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_paletteDataSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void paletteData(ref byte[] bytes)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(bytes);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_paletteData(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			bytes = Helpers.UnMarshalbyteFixedArray(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public Palette palette()
	{
		Palette result = new Palette(TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_palette(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPalColorAt(uint paletteIndex, byte blue, byte green, byte red, byte alpha)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_setPalColorAt__SWIG_0(swigCPtr, paletteIndex, blue, green, red, alpha);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPalColorAt(uint paletteIndex, byte blue, byte green, byte red)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_setPalColorAt__SWIG_1(swigCPtr, paletteIndex, blue, green, red);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPalColorAt(uint paletteIndex, out byte blue, out byte green, out byte red, byte[] pAlpha)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_getPalColorAt__SWIG_0(swigCPtr, paletteIndex, out blue, out green, out red, Helpers.MarshalbyteFixedArray(pAlpha));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPalColorAt(uint paletteIndex, out byte blue, out byte green, out byte red)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_getPalColorAt__SWIG_1(swigCPtr, paletteIndex, out blue, out green, out red);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getColorAt(uint x, uint y, out byte blue, out byte green, out byte red)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_getColorAt(swigCPtr, x, y, out blue, out green, out red);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void copyFrom(OdRxObject pOtherObj)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_copyFrom(swigCPtr, OdRxObject.getCPtr(pOtherObj));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual uint pixelWidth()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_pixelWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint pixelHeight()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_pixelHeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint colorDepth()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_colorDepth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiRasterImage_Units defaultResolution(out double xPelsPerUnit, out double yPelsPerUnit)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_defaultResolution(swigCPtr, out xPelsPerUnit, out yPelsPerUnit);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_Units)result;
	}

	public new virtual uint numColors()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_numColors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint color(uint colorIndex)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_color(swigCPtr, colorIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual int transparentColor()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_transparentColor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void scanLines(ref byte[] scnLines, uint firstScanline, uint numLines)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(scnLines);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_scanLines__SWIG_0(swigCPtr, intPtr, firstScanline, numLines);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			scnLines = Helpers.UnMarshalbyteFixedArray(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public override void scanLines(ref byte[] scnLines, uint firstScanline)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(scnLines);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_scanLines__SWIG_1(swigCPtr, intPtr, firstScanline);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			scnLines = Helpers.UnMarshalbyteFixedArray(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public new virtual byte[] scanLines()
	{
		byte[] result = Helpers.UnMarshalbyteFixedArray(TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_scanLines__SWIG_2(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual PixelFormatInfo pixelFormat()
	{
		PixelFormatInfo result = new PixelFormatInfo(TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_pixelFormat(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint scanLinesAlignment()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_scanLinesAlignment(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint supportedParams()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_supportedParams(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiRasterImage_ImageSource imageSource()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_imageSource(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_ImageSource)result;
	}

	public override void setImageSource(OdGiRasterImage_ImageSource source)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_setImageSource(swigCPtr, (int)source);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual string sourceFileName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_sourceFileName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setSourceFileName(string fileName)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_setSourceFileName(swigCPtr, fileName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdGiRasterImage_TransparencyMode transparencyMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_transparencyMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_TransparencyMode)result;
	}

	public override void setTransparencyMode(OdGiRasterImage_TransparencyMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_setTransparencyMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdExGiRasterImage_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

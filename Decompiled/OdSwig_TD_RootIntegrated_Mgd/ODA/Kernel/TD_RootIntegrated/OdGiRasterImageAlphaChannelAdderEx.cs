using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRasterImageAlphaChannelAdderEx : OdGiRasterImageParam
{
	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdderEx_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdderEx_1();

	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdderEx_2();

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdderEx_3(IntPtr pSource);

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdderEx_4();

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdderEx_5();

	public delegate int SwigDelegateOdGiRasterImageAlphaChannelAdderEx_6(double xPelsPerUnit, double yPelsPerUnit);

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdderEx_7();

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdderEx_8();

	public delegate int SwigDelegateOdGiRasterImageAlphaChannelAdderEx_9();

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdderEx_10(uint colorIndex);

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdderEx_11();

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdderEx_12(IntPtr bytes);

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdderEx_13();

	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdderEx_14();

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdderEx_15(IntPtr scnLines, uint firstScanline, uint numLines);

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdderEx_16(IntPtr scnLines, uint firstScanline);

	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdderEx_17();

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdderEx_18();

	public delegate int SwigDelegateOdGiRasterImageAlphaChannelAdderEx_19();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdGiRasterImageAlphaChannelAdderEx_20();

	public delegate int SwigDelegateOdGiRasterImageAlphaChannelAdderEx_21();

	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdderEx_22(uint x, uint y, uint width, uint height);

	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdderEx_23();

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdderEx_24();

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdderEx_25(int arg0);

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdderEx_26([MarshalAs(UnmanagedType.LPWStr)] string arg0);

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdderEx_27(int mode);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_0 swigDelegate0;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_1 swigDelegate1;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_2 swigDelegate2;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_3 swigDelegate3;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_4 swigDelegate4;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_5 swigDelegate5;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_6 swigDelegate6;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_7 swigDelegate7;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_8 swigDelegate8;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_9 swigDelegate9;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_10 swigDelegate10;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_11 swigDelegate11;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_12 swigDelegate12;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_13 swigDelegate13;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_14 swigDelegate14;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_15 swigDelegate15;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_16 swigDelegate16;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_17 swigDelegate17;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_18 swigDelegate18;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_19 swigDelegate19;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_20 swigDelegate20;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_21 swigDelegate21;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_22 swigDelegate22;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_23 swigDelegate23;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_24 swigDelegate24;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_25 swigDelegate25;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_26 swigDelegate26;

	private SwigDelegateOdGiRasterImageAlphaChannelAdderEx_27 swigDelegate27;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(byte[]).MakeByRefType() };

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[3]
	{
		typeof(byte[]).MakeByRefType(),
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes16 = new Type[2]
	{
		typeof(byte[]).MakeByRefType(),
		typeof(uint)
	};

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[4]
	{
		typeof(uint),
		typeof(uint),
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[0];

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(OdGiRasterImage_ImageSource) };

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes27 = new Type[1] { typeof(OdGiRasterImage_TransparencyMode) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiRasterImageAlphaChannelAdderEx(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRasterImageAlphaChannelAdderEx obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRasterImageAlphaChannelAdderEx(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiRasterImageAlphaChannelAdderEx()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRasterImageAlphaChannelAdderEx(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiRasterImageAlphaChannelAdderEx) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public static OdGiRasterImage createObject(OdGiRasterImage pOrig, uint transColor, byte alpha, byte alphaTransparent)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_createObject__SWIG_0(OdGiRasterImage.getCPtr(pOrig), transColor, alpha, alphaTransparent), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiRasterImage createObject(OdGiRasterImage pOrig, uint transColor, byte alpha)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_createObject__SWIG_1(OdGiRasterImage.getCPtr(pOrig), transColor, alpha), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiRasterImage createObject(OdGiRasterImage pOrig, uint transColor)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_createObject__SWIG_2(OdGiRasterImage.getCPtr(pOrig), transColor), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override uint scanLineSize()
	{
		uint result = (SwigDerivedClassHasMethod("scanLineSize", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_scanLineSizeSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_scanLineSize(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override byte[] scanLines()
	{
		byte[] result = Helpers.UnMarshalbyteFixedArray(SwigDerivedClassHasMethod("scanLines", swigMethodTypes14) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_scanLinesSwigExplicitOdGiRasterImageAlphaChannelAdderEx__SWIG_0(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_scanLines__SWIG_0(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void scanLines(ref byte[] scnLines, uint firstScanline, uint numLines)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(scnLines);
		try
		{
			if (SwigDerivedClassHasMethod("scanLines", swigMethodTypes15))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_scanLinesSwigExplicitOdGiRasterImageAlphaChannelAdderEx__SWIG_1(swigCPtr, intPtr, firstScanline, numLines);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_scanLines__SWIG_1(swigCPtr, intPtr, firstScanline, numLines);
			}
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
			if (SwigDerivedClassHasMethod("scanLines", swigMethodTypes16))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_scanLinesSwigExplicitOdGiRasterImageAlphaChannelAdderEx__SWIG_2(swigCPtr, intPtr, firstScanline);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_scanLines__SWIG_2(swigCPtr, intPtr, firstScanline);
			}
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

	public override uint pixelWidth()
	{
		uint result = (SwigDerivedClassHasMethod("pixelWidth", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_pixelWidthSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_pixelWidth(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint pixelHeight()
	{
		uint result = (SwigDerivedClassHasMethod("pixelHeight", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_pixelHeightSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_pixelHeight(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint colorDepth()
	{
		uint result = (SwigDerivedClassHasMethod("colorDepth", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_colorDepthSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_colorDepth(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint numColors()
	{
		uint result = (SwigDerivedClassHasMethod("numColors", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_numColorsSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_numColors(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint color(uint colorIndex)
	{
		uint result = (SwigDerivedClassHasMethod("color", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_colorSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr, colorIndex) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_color(swigCPtr, colorIndex));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint paletteDataSize()
	{
		uint result = (SwigDerivedClassHasMethod("paletteDataSize", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_paletteDataSizeSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_paletteDataSize(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void paletteData(ref byte[] bytes)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(bytes);
		try
		{
			if (SwigDerivedClassHasMethod("paletteData", swigMethodTypes12))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_paletteDataSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_paletteData(swigCPtr, intPtr);
			}
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

	public new virtual PixelFormatInfo pixelFormat()
	{
		PixelFormatInfo result = new PixelFormatInfo(SwigDerivedClassHasMethod("pixelFormat", swigMethodTypes17) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_pixelFormatSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_pixelFormat(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint scanLinesAlignment()
	{
		uint result = (SwigDerivedClassHasMethod("scanLinesAlignment", swigMethodTypes18) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_scanLinesAlignmentSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_scanLinesAlignment(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiRasterImage_Units defaultResolution(out double xPelsPerUnit, out double yPelsPerUnit)
	{
		int result = (SwigDerivedClassHasMethod("defaultResolution", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_defaultResolutionSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr, out xPelsPerUnit, out yPelsPerUnit) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_defaultResolution(swigCPtr, out xPelsPerUnit, out yPelsPerUnit));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_Units)result;
	}

	public override uint supportedParams()
	{
		uint result = (SwigDerivedClassHasMethod("supportedParams", swigMethodTypes24) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_supportedParamsSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_supportedParams(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiRasterImage_ImageSource imageSource()
	{
		int result = (SwigDerivedClassHasMethod("imageSource", swigMethodTypes19) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_imageSourceSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_imageSource(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_ImageSource)result;
	}

	public new virtual OdGiRasterImage_TransparencyMode transparencyMode()
	{
		int result = (SwigDerivedClassHasMethod("transparencyMode", swigMethodTypes21) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_transparencyModeSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_transparencyMode(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_TransparencyMode)result;
	}

	public new virtual void setTransparencyMode(OdGiRasterImage_TransparencyMode mode)
	{
		if (SwigDerivedClassHasMethod("setTransparencyMode", swigMethodTypes27))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_setTransparencyModeSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr, (int)mode);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_setTransparencyMode(swigCPtr, (int)mode);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdRxObject clone()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("clone", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_cloneSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_clone(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void copyFrom(OdRxObject pSource)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_copyFromSwigExplicitOdGiRasterImageAlphaChannelAdderEx(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiRasterImageAlphaChannelAdderEx createObject()
	{
		OdGiRasterImageAlphaChannelAdderEx rXObject = Helpers.GetRXObject<OdGiRasterImageAlphaChannelAdderEx>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_createObject__SWIG_3(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("queryX", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodqueryX;
		}
		if (SwigDerivedClassHasMethod("isA", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisA;
		}
		if (SwigDerivedClassHasMethod("clone", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodclone;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("pixelWidth", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodpixelWidth;
		}
		if (SwigDerivedClassHasMethod("pixelHeight", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodpixelHeight;
		}
		if (SwigDerivedClassHasMethod("defaultResolution", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoddefaultResolution;
		}
		if (SwigDerivedClassHasMethod("colorDepth", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodcolorDepth;
		}
		if (SwigDerivedClassHasMethod("numColors", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodnumColors;
		}
		if (SwigDerivedClassHasMethod("transparentColor", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodtransparentColor;
		}
		if (SwigDerivedClassHasMethod("color", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcolor;
		}
		if (SwigDerivedClassHasMethod("paletteDataSize", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodpaletteDataSize;
		}
		if (SwigDerivedClassHasMethod("paletteData", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodpaletteData;
		}
		if (SwigDerivedClassHasMethod("scanLineSize", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodscanLineSize;
		}
		if (SwigDerivedClassHasMethod("scanLines", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodscanLines__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("scanLines", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodscanLines__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("scanLines", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodscanLines__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("pixelFormat", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodpixelFormat;
		}
		if (SwigDerivedClassHasMethod("scanLinesAlignment", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodscanLinesAlignment;
		}
		if (SwigDerivedClassHasMethod("imageSource", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodimageSource;
		}
		if (SwigDerivedClassHasMethod("sourceFileName", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsourceFileName;
		}
		if (SwigDerivedClassHasMethod("transparencyMode", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodtransparencyMode;
		}
		if (SwigDerivedClassHasMethod("crop", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodcrop;
		}
		if (SwigDerivedClassHasMethod("imp", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodimp;
		}
		if (SwigDerivedClassHasMethod("supportedParams", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodsupportedParams;
		}
		if (SwigDerivedClassHasMethod("setImageSource", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsetImageSource;
		}
		if (SwigDerivedClassHasMethod("setSourceFileName", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodsetSourceFileName;
		}
		if (SwigDerivedClassHasMethod("setTransparencyMode", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodsetTransparencyMode;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdderEx_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiRasterImageAlphaChannelAdderEx));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private IntPtr SwigDirectorMethodclone()
	{
		return OdRxObject.getCPtr(clone()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private uint SwigDirectorMethodpixelWidth()
	{
		return pixelWidth();
	}

	private uint SwigDirectorMethodpixelHeight()
	{
		return pixelHeight();
	}

	private int SwigDirectorMethoddefaultResolution(double xPelsPerUnit, double yPelsPerUnit)
	{
		return (int)defaultResolution(out xPelsPerUnit, out yPelsPerUnit);
	}

	private uint SwigDirectorMethodcolorDepth()
	{
		return colorDepth();
	}

	private uint SwigDirectorMethodnumColors()
	{
		return numColors();
	}

	private int SwigDirectorMethodtransparentColor()
	{
		return transparentColor();
	}

	private uint SwigDirectorMethodcolor(uint colorIndex)
	{
		return color(colorIndex);
	}

	private uint SwigDirectorMethodpaletteDataSize()
	{
		return paletteDataSize();
	}

	private void SwigDirectorMethodpaletteData(IntPtr bytes)
	{
		byte[] bytes2 = Helpers.UnMarshalbyteFixedArray(bytes);
		try
		{
			paletteData(ref bytes2);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
		finally
		{
			bytes = Helpers.MarshalbyteFixedArray(bytes2);
		}
	}

	private uint SwigDirectorMethodscanLineSize()
	{
		return scanLineSize();
	}

	private IntPtr SwigDirectorMethodscanLines__SWIG_0()
	{
		return Helpers.MarshalbyteFixedArray(scanLines());
	}

	private void SwigDirectorMethodscanLines__SWIG_1(IntPtr scnLines, uint firstScanline, uint numLines)
	{
		byte[] scnLines2 = Helpers.UnMarshalbyteFixedArray(scnLines);
		try
		{
			scanLines(ref scnLines2, firstScanline, numLines);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
		finally
		{
			scnLines = Helpers.MarshalbyteFixedArray(scnLines2);
		}
	}

	private void SwigDirectorMethodscanLines__SWIG_2(IntPtr scnLines, uint firstScanline)
	{
		byte[] scnLines2 = Helpers.UnMarshalbyteFixedArray(scnLines);
		try
		{
			scanLines(ref scnLines2, firstScanline);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
		finally
		{
			scnLines = Helpers.MarshalbyteFixedArray(scnLines2);
		}
	}

	private IntPtr SwigDirectorMethodpixelFormat()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return PixelFormatInfo.getCPtr(pixelFormat()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private uint SwigDirectorMethodscanLinesAlignment()
	{
		return scanLinesAlignment();
	}

	private int SwigDirectorMethodimageSource()
	{
		return (int)imageSource();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodsourceFileName()
	{
		return sourceFileName();
	}

	private int SwigDirectorMethodtransparencyMode()
	{
		return (int)transparencyMode();
	}

	private IntPtr SwigDirectorMethodcrop(uint x, uint y, uint width, uint height)
	{
		return OdGiRasterImage.getCPtr(crop(x, y, width, height)).Handle;
	}

	private IntPtr SwigDirectorMethodimp()
	{
		return imp();
	}

	private uint SwigDirectorMethodsupportedParams()
	{
		return supportedParams();
	}

	private void SwigDirectorMethodsetImageSource(int arg0)
	{
		try
		{
			setImageSource((OdGiRasterImage_ImageSource)arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetSourceFileName([MarshalAs(UnmanagedType.LPWStr)] string arg0)
	{
		try
		{
			setSourceFileName(arg0);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetTransparencyMode(int mode)
	{
		try
		{
			setTransparencyMode((OdGiRasterImage_TransparencyMode)mode);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}

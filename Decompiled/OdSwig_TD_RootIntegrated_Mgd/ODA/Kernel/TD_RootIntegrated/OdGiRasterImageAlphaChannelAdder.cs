using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRasterImageAlphaChannelAdder : OdGiRasterImageParam
{
	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdder_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdder_1();

	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdder_2();

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdder_3(IntPtr pSource);

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdder_4();

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdder_5();

	public delegate int SwigDelegateOdGiRasterImageAlphaChannelAdder_6(double xPelsPerUnit, double yPelsPerUnit);

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdder_7();

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdder_8();

	public delegate int SwigDelegateOdGiRasterImageAlphaChannelAdder_9();

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdder_10(uint colorIndex);

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdder_11();

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdder_12(IntPtr bytes);

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdder_13();

	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdder_14();

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdder_15(IntPtr scnLines, uint firstScanline, uint numLines);

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdder_16(IntPtr scnLines, uint firstScanline);

	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdder_17();

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdder_18();

	public delegate int SwigDelegateOdGiRasterImageAlphaChannelAdder_19();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdGiRasterImageAlphaChannelAdder_20();

	public delegate int SwigDelegateOdGiRasterImageAlphaChannelAdder_21();

	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdder_22(uint x, uint y, uint width, uint height);

	public delegate IntPtr SwigDelegateOdGiRasterImageAlphaChannelAdder_23();

	public delegate uint SwigDelegateOdGiRasterImageAlphaChannelAdder_24();

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdder_25(int arg0);

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdder_26([MarshalAs(UnmanagedType.LPWStr)] string arg0);

	public delegate void SwigDelegateOdGiRasterImageAlphaChannelAdder_27(int mode);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_0 swigDelegate0;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_1 swigDelegate1;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_2 swigDelegate2;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_3 swigDelegate3;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_4 swigDelegate4;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_5 swigDelegate5;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_6 swigDelegate6;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_7 swigDelegate7;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_8 swigDelegate8;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_9 swigDelegate9;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_10 swigDelegate10;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_11 swigDelegate11;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_12 swigDelegate12;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_13 swigDelegate13;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_14 swigDelegate14;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_15 swigDelegate15;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_16 swigDelegate16;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_17 swigDelegate17;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_18 swigDelegate18;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_19 swigDelegate19;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_20 swigDelegate20;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_21 swigDelegate21;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_22 swigDelegate22;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_23 swigDelegate23;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_24 swigDelegate24;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_25 swigDelegate25;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_26 swigDelegate26;

	private SwigDelegateOdGiRasterImageAlphaChannelAdder_27 swigDelegate27;

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
	public OdGiRasterImageAlphaChannelAdder(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRasterImageAlphaChannelAdder obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRasterImageAlphaChannelAdder(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiRasterImageAlphaChannelAdder()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRasterImageAlphaChannelAdder(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiRasterImageAlphaChannelAdder) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public static OdGiRasterImage createObject(OdGiRasterImage pOrig, uint cutColor, byte threshold)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_createObject__SWIG_0(OdGiRasterImage.getCPtr(pOrig), cutColor, threshold), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiRasterImage createObject(OdGiRasterImage pOrig, uint cutColor)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_createObject__SWIG_1(OdGiRasterImage.getCPtr(pOrig), cutColor), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override uint scanLineSize()
	{
		uint result = (SwigDerivedClassHasMethod("scanLineSize", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_scanLineSizeSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_scanLineSize(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override byte[] scanLines()
	{
		byte[] result = Helpers.UnMarshalbyteFixedArray(SwigDerivedClassHasMethod("scanLines", swigMethodTypes14) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_scanLinesSwigExplicitOdGiRasterImageAlphaChannelAdder__SWIG_0(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_scanLines__SWIG_0(swigCPtr));
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
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_scanLinesSwigExplicitOdGiRasterImageAlphaChannelAdder__SWIG_1(swigCPtr, intPtr, firstScanline, numLines);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_scanLines__SWIG_1(swigCPtr, intPtr, firstScanline, numLines);
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
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_scanLinesSwigExplicitOdGiRasterImageAlphaChannelAdder__SWIG_2(swigCPtr, intPtr, firstScanline);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_scanLines__SWIG_2(swigCPtr, intPtr, firstScanline);
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
		uint result = (SwigDerivedClassHasMethod("pixelWidth", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_pixelWidthSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_pixelWidth(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint pixelHeight()
	{
		uint result = (SwigDerivedClassHasMethod("pixelHeight", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_pixelHeightSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_pixelHeight(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint colorDepth()
	{
		uint result = (SwigDerivedClassHasMethod("colorDepth", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_colorDepthSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_colorDepth(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint numColors()
	{
		uint result = (SwigDerivedClassHasMethod("numColors", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_numColorsSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_numColors(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint color(uint colorIndex)
	{
		uint result = (SwigDerivedClassHasMethod("color", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_colorSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr, colorIndex) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_color(swigCPtr, colorIndex));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint paletteDataSize()
	{
		uint result = (SwigDerivedClassHasMethod("paletteDataSize", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_paletteDataSizeSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_paletteDataSize(swigCPtr));
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
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_paletteDataSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_paletteData(swigCPtr, intPtr);
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
		PixelFormatInfo result = new PixelFormatInfo(SwigDerivedClassHasMethod("pixelFormat", swigMethodTypes17) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_pixelFormatSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_pixelFormat(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint scanLinesAlignment()
	{
		uint result = (SwigDerivedClassHasMethod("scanLinesAlignment", swigMethodTypes18) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_scanLinesAlignmentSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_scanLinesAlignment(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiRasterImage_Units defaultResolution(out double xPelsPerUnit, out double yPelsPerUnit)
	{
		int result = (SwigDerivedClassHasMethod("defaultResolution", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_defaultResolutionSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr, out xPelsPerUnit, out yPelsPerUnit) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_defaultResolution(swigCPtr, out xPelsPerUnit, out yPelsPerUnit));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_Units)result;
	}

	public override uint supportedParams()
	{
		uint result = (SwigDerivedClassHasMethod("supportedParams", swigMethodTypes24) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_supportedParamsSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_supportedParams(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiRasterImage_ImageSource imageSource()
	{
		int result = (SwigDerivedClassHasMethod("imageSource", swigMethodTypes19) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_imageSourceSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_imageSource(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_ImageSource)result;
	}

	public new virtual OdGiRasterImage_TransparencyMode transparencyMode()
	{
		int result = (SwigDerivedClassHasMethod("transparencyMode", swigMethodTypes21) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_transparencyModeSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_transparencyMode(swigCPtr));
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
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_setTransparencyModeSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr, (int)mode);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_setTransparencyMode(swigCPtr, (int)mode);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdRxObject clone()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("clone", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_cloneSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_clone(swigCPtr), bOwn: true, bTryAddToTransaction: true);
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
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_copyFromSwigExplicitOdGiRasterImageAlphaChannelAdder(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiRasterImageAlphaChannelAdder createObject()
	{
		OdGiRasterImageAlphaChannelAdder rXObject = Helpers.GetRXObject<OdGiRasterImageAlphaChannelAdder>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_createObject__SWIG_2(), bOwn: true, bTryAddToTransaction: true);
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageAlphaChannelAdder_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiRasterImageAlphaChannelAdder));
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

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRasterImageHolder : OdGiRasterImageParam
{
	public delegate IntPtr SwigDelegateOdGiRasterImageHolder_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiRasterImageHolder_1();

	public delegate IntPtr SwigDelegateOdGiRasterImageHolder_2();

	public delegate void SwigDelegateOdGiRasterImageHolder_3(IntPtr pSource);

	public delegate uint SwigDelegateOdGiRasterImageHolder_4();

	public delegate uint SwigDelegateOdGiRasterImageHolder_5();

	public delegate int SwigDelegateOdGiRasterImageHolder_6(double xPelsPerUnit, double yPelsPerUnit);

	public delegate uint SwigDelegateOdGiRasterImageHolder_7();

	public delegate uint SwigDelegateOdGiRasterImageHolder_8();

	public delegate int SwigDelegateOdGiRasterImageHolder_9();

	public delegate uint SwigDelegateOdGiRasterImageHolder_10(uint colorIndex);

	public delegate uint SwigDelegateOdGiRasterImageHolder_11();

	public delegate void SwigDelegateOdGiRasterImageHolder_12(IntPtr bytes);

	public delegate uint SwigDelegateOdGiRasterImageHolder_13();

	public delegate IntPtr SwigDelegateOdGiRasterImageHolder_14();

	public delegate void SwigDelegateOdGiRasterImageHolder_15(IntPtr scnLines, uint firstScanline, uint numLines);

	public delegate void SwigDelegateOdGiRasterImageHolder_16(IntPtr scnLines, uint firstScanline);

	public delegate IntPtr SwigDelegateOdGiRasterImageHolder_17();

	public delegate uint SwigDelegateOdGiRasterImageHolder_18();

	public delegate int SwigDelegateOdGiRasterImageHolder_19();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdGiRasterImageHolder_20();

	public delegate int SwigDelegateOdGiRasterImageHolder_21();

	public delegate IntPtr SwigDelegateOdGiRasterImageHolder_22(uint x, uint y, uint width, uint height);

	public delegate IntPtr SwigDelegateOdGiRasterImageHolder_23();

	public delegate uint SwigDelegateOdGiRasterImageHolder_24();

	public delegate void SwigDelegateOdGiRasterImageHolder_25(int source);

	public delegate void SwigDelegateOdGiRasterImageHolder_26([MarshalAs(UnmanagedType.LPWStr)] string fileName);

	public delegate void SwigDelegateOdGiRasterImageHolder_27(int mode);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiRasterImageHolder_0 swigDelegate0;

	private SwigDelegateOdGiRasterImageHolder_1 swigDelegate1;

	private SwigDelegateOdGiRasterImageHolder_2 swigDelegate2;

	private SwigDelegateOdGiRasterImageHolder_3 swigDelegate3;

	private SwigDelegateOdGiRasterImageHolder_4 swigDelegate4;

	private SwigDelegateOdGiRasterImageHolder_5 swigDelegate5;

	private SwigDelegateOdGiRasterImageHolder_6 swigDelegate6;

	private SwigDelegateOdGiRasterImageHolder_7 swigDelegate7;

	private SwigDelegateOdGiRasterImageHolder_8 swigDelegate8;

	private SwigDelegateOdGiRasterImageHolder_9 swigDelegate9;

	private SwigDelegateOdGiRasterImageHolder_10 swigDelegate10;

	private SwigDelegateOdGiRasterImageHolder_11 swigDelegate11;

	private SwigDelegateOdGiRasterImageHolder_12 swigDelegate12;

	private SwigDelegateOdGiRasterImageHolder_13 swigDelegate13;

	private SwigDelegateOdGiRasterImageHolder_14 swigDelegate14;

	private SwigDelegateOdGiRasterImageHolder_15 swigDelegate15;

	private SwigDelegateOdGiRasterImageHolder_16 swigDelegate16;

	private SwigDelegateOdGiRasterImageHolder_17 swigDelegate17;

	private SwigDelegateOdGiRasterImageHolder_18 swigDelegate18;

	private SwigDelegateOdGiRasterImageHolder_19 swigDelegate19;

	private SwigDelegateOdGiRasterImageHolder_20 swigDelegate20;

	private SwigDelegateOdGiRasterImageHolder_21 swigDelegate21;

	private SwigDelegateOdGiRasterImageHolder_22 swigDelegate22;

	private SwigDelegateOdGiRasterImageHolder_23 swigDelegate23;

	private SwigDelegateOdGiRasterImageHolder_24 swigDelegate24;

	private SwigDelegateOdGiRasterImageHolder_25 swigDelegate25;

	private SwigDelegateOdGiRasterImageHolder_26 swigDelegate26;

	private SwigDelegateOdGiRasterImageHolder_27 swigDelegate27;

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
	public OdGiRasterImageHolder(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRasterImageHolder obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRasterImageHolder(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiRasterImageHolder()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRasterImageHolder(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiRasterImageHolder) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public void setFrom(OdGiRasterImage pOrig)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_setFrom(swigCPtr, OdGiRasterImage.getCPtr(pOrig));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGiRasterImage createObject(OdGiRasterImage pImage)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_createObject__SWIG_0(OdGiRasterImage.getCPtr(pImage)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override uint pixelWidth()
	{
		uint result = (SwigDerivedClassHasMethod("pixelWidth", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_pixelWidthSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_pixelWidth(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint pixelHeight()
	{
		uint result = (SwigDerivedClassHasMethod("pixelHeight", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_pixelHeightSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_pixelHeight(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGiRasterImage_Units defaultResolution(out double xPelsPerUnit, out double yPelsPerUnit)
	{
		int result = (SwigDerivedClassHasMethod("defaultResolution", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_defaultResolutionSwigExplicitOdGiRasterImageHolder(swigCPtr, out xPelsPerUnit, out yPelsPerUnit) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_defaultResolution(swigCPtr, out xPelsPerUnit, out yPelsPerUnit));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_Units)result;
	}

	public override uint colorDepth()
	{
		uint result = (SwigDerivedClassHasMethod("colorDepth", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_colorDepthSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_colorDepth(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint numColors()
	{
		uint result = (SwigDerivedClassHasMethod("numColors", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_numColorsSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_numColors(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint color(uint colorIndex)
	{
		uint result = (SwigDerivedClassHasMethod("color", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_colorSwigExplicitOdGiRasterImageHolder(swigCPtr, colorIndex) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_color(swigCPtr, colorIndex));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint paletteDataSize()
	{
		uint result = (SwigDerivedClassHasMethod("paletteDataSize", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_paletteDataSizeSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_paletteDataSize(swigCPtr));
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
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_paletteDataSwigExplicitOdGiRasterImageHolder(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_paletteData(swigCPtr, intPtr);
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

	public override uint scanLineSize()
	{
		uint result = (SwigDerivedClassHasMethod("scanLineSize", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_scanLineSizeSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_scanLineSize(swigCPtr));
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
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_scanLinesSwigExplicitOdGiRasterImageHolder__SWIG_0(swigCPtr, intPtr, firstScanline, numLines);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_scanLines__SWIG_0(swigCPtr, intPtr, firstScanline, numLines);
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
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_scanLinesSwigExplicitOdGiRasterImageHolder__SWIG_1(swigCPtr, intPtr, firstScanline);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_scanLines__SWIG_1(swigCPtr, intPtr, firstScanline);
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

	public override byte[] scanLines()
	{
		byte[] result = Helpers.UnMarshalbyteFixedArray(SwigDerivedClassHasMethod("scanLines", swigMethodTypes14) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_scanLinesSwigExplicitOdGiRasterImageHolder__SWIG_2(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_scanLines__SWIG_2(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override PixelFormatInfo pixelFormat()
	{
		PixelFormatInfo result = new PixelFormatInfo(SwigDerivedClassHasMethod("pixelFormat", swigMethodTypes17) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_pixelFormatSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_pixelFormat(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint scanLinesAlignment()
	{
		uint result = (SwigDerivedClassHasMethod("scanLinesAlignment", swigMethodTypes18) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_scanLinesAlignmentSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_scanLinesAlignment(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override int transparentColor()
	{
		int result = (SwigDerivedClassHasMethod("transparentColor", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_transparentColorSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_transparentColor(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGiRasterImage_ImageSource imageSource()
	{
		int result = (SwigDerivedClassHasMethod("imageSource", swigMethodTypes19) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_imageSourceSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_imageSource(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_ImageSource)result;
	}

	public override string sourceFileName()
	{
		string result = (SwigDerivedClassHasMethod("sourceFileName", swigMethodTypes20) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_sourceFileNameSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_sourceFileName(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGiRasterImage_TransparencyMode transparencyMode()
	{
		int result = (SwigDerivedClassHasMethod("transparencyMode", swigMethodTypes21) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_transparencyModeSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_transparencyMode(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_TransparencyMode)result;
	}

	public override uint supportedParams()
	{
		uint result = (SwigDerivedClassHasMethod("supportedParams", swigMethodTypes24) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_supportedParamsSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_supportedParams(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setImageSource(OdGiRasterImage_ImageSource source)
	{
		if (SwigDerivedClassHasMethod("setImageSource", swigMethodTypes25))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_setImageSourceSwigExplicitOdGiRasterImageHolder(swigCPtr, (int)source);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_setImageSource(swigCPtr, (int)source);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setSourceFileName(string fileName)
	{
		if (SwigDerivedClassHasMethod("setSourceFileName", swigMethodTypes26))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_setSourceFileNameSwigExplicitOdGiRasterImageHolder(swigCPtr, fileName);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_setSourceFileName(swigCPtr, fileName);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setTransparencyMode(OdGiRasterImage_TransparencyMode mode)
	{
		if (SwigDerivedClassHasMethod("setTransparencyMode", swigMethodTypes27))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_setTransparencyModeSwigExplicitOdGiRasterImageHolder(swigCPtr, (int)mode);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_setTransparencyMode(swigCPtr, (int)mode);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdRxObject clone()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("clone", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_cloneSwigExplicitOdGiRasterImageHolder(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_clone(swigCPtr), bOwn: true, bTryAddToTransaction: true);
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
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_copyFromSwigExplicitOdGiRasterImageHolder(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiRasterImageHolder createObject()
	{
		OdGiRasterImageHolder rXObject = Helpers.GetRXObject<OdGiRasterImageHolder>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_createObject__SWIG_1(), bOwn: true, bTryAddToTransaction: true);
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
			swigDelegate14 = SwigDirectorMethodscanLines__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("scanLines", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodscanLines__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("scanLines", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodscanLines__SWIG_1;
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageHolder_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiRasterImageHolder));
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

	private IntPtr SwigDirectorMethodscanLines__SWIG_2()
	{
		return Helpers.MarshalbyteFixedArray(scanLines());
	}

	private void SwigDirectorMethodscanLines__SWIG_0(IntPtr scnLines, uint firstScanline, uint numLines)
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

	private void SwigDirectorMethodscanLines__SWIG_1(IntPtr scnLines, uint firstScanline)
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

	private void SwigDirectorMethodsetImageSource(int source)
	{
		try
		{
			setImageSource((OdGiRasterImage_ImageSource)source);
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

	private void SwigDirectorMethodsetSourceFileName([MarshalAs(UnmanagedType.LPWStr)] string fileName)
	{
		try
		{
			setSourceFileName(fileName);
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

using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiBitonalRasterTransformer : OdGiRasterImageWrapper
{
	public delegate IntPtr SwigDelegateOdGiBitonalRasterTransformer_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiBitonalRasterTransformer_1();

	public delegate IntPtr SwigDelegateOdGiBitonalRasterTransformer_2();

	public delegate void SwigDelegateOdGiBitonalRasterTransformer_3(IntPtr pSource);

	public delegate uint SwigDelegateOdGiBitonalRasterTransformer_4();

	public delegate uint SwigDelegateOdGiBitonalRasterTransformer_5();

	public delegate int SwigDelegateOdGiBitonalRasterTransformer_6(double xPelsPerUnit, double yPelsPerUnit);

	public delegate uint SwigDelegateOdGiBitonalRasterTransformer_7();

	public delegate uint SwigDelegateOdGiBitonalRasterTransformer_8();

	public delegate int SwigDelegateOdGiBitonalRasterTransformer_9();

	public delegate uint SwigDelegateOdGiBitonalRasterTransformer_10(uint colorIndex);

	public delegate uint SwigDelegateOdGiBitonalRasterTransformer_11();

	public delegate void SwigDelegateOdGiBitonalRasterTransformer_12(IntPtr bytes);

	public delegate uint SwigDelegateOdGiBitonalRasterTransformer_13();

	public delegate IntPtr SwigDelegateOdGiBitonalRasterTransformer_14();

	public delegate void SwigDelegateOdGiBitonalRasterTransformer_15(IntPtr scnLines, uint firstScanline, uint numLines);

	public delegate void SwigDelegateOdGiBitonalRasterTransformer_16(IntPtr scnLines, uint firstScanline);

	public delegate IntPtr SwigDelegateOdGiBitonalRasterTransformer_17();

	public delegate uint SwigDelegateOdGiBitonalRasterTransformer_18();

	public delegate int SwigDelegateOdGiBitonalRasterTransformer_19();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdGiBitonalRasterTransformer_20();

	public delegate int SwigDelegateOdGiBitonalRasterTransformer_21();

	public delegate IntPtr SwigDelegateOdGiBitonalRasterTransformer_22(uint x, uint y, uint width, uint height);

	public delegate IntPtr SwigDelegateOdGiBitonalRasterTransformer_23();

	public delegate uint SwigDelegateOdGiBitonalRasterTransformer_24();

	public delegate void SwigDelegateOdGiBitonalRasterTransformer_25(int source);

	public delegate void SwigDelegateOdGiBitonalRasterTransformer_26([MarshalAs(UnmanagedType.LPWStr)] string fileName);

	public delegate void SwigDelegateOdGiBitonalRasterTransformer_27(int mode);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiBitonalRasterTransformer_0 swigDelegate0;

	private SwigDelegateOdGiBitonalRasterTransformer_1 swigDelegate1;

	private SwigDelegateOdGiBitonalRasterTransformer_2 swigDelegate2;

	private SwigDelegateOdGiBitonalRasterTransformer_3 swigDelegate3;

	private SwigDelegateOdGiBitonalRasterTransformer_4 swigDelegate4;

	private SwigDelegateOdGiBitonalRasterTransformer_5 swigDelegate5;

	private SwigDelegateOdGiBitonalRasterTransformer_6 swigDelegate6;

	private SwigDelegateOdGiBitonalRasterTransformer_7 swigDelegate7;

	private SwigDelegateOdGiBitonalRasterTransformer_8 swigDelegate8;

	private SwigDelegateOdGiBitonalRasterTransformer_9 swigDelegate9;

	private SwigDelegateOdGiBitonalRasterTransformer_10 swigDelegate10;

	private SwigDelegateOdGiBitonalRasterTransformer_11 swigDelegate11;

	private SwigDelegateOdGiBitonalRasterTransformer_12 swigDelegate12;

	private SwigDelegateOdGiBitonalRasterTransformer_13 swigDelegate13;

	private SwigDelegateOdGiBitonalRasterTransformer_14 swigDelegate14;

	private SwigDelegateOdGiBitonalRasterTransformer_15 swigDelegate15;

	private SwigDelegateOdGiBitonalRasterTransformer_16 swigDelegate16;

	private SwigDelegateOdGiBitonalRasterTransformer_17 swigDelegate17;

	private SwigDelegateOdGiBitonalRasterTransformer_18 swigDelegate18;

	private SwigDelegateOdGiBitonalRasterTransformer_19 swigDelegate19;

	private SwigDelegateOdGiBitonalRasterTransformer_20 swigDelegate20;

	private SwigDelegateOdGiBitonalRasterTransformer_21 swigDelegate21;

	private SwigDelegateOdGiBitonalRasterTransformer_22 swigDelegate22;

	private SwigDelegateOdGiBitonalRasterTransformer_23 swigDelegate23;

	private SwigDelegateOdGiBitonalRasterTransformer_24 swigDelegate24;

	private SwigDelegateOdGiBitonalRasterTransformer_25 swigDelegate25;

	private SwigDelegateOdGiBitonalRasterTransformer_26 swigDelegate26;

	private SwigDelegateOdGiBitonalRasterTransformer_27 swigDelegate27;

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
	public OdGiBitonalRasterTransformer(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiBitonalRasterTransformer obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiBitonalRasterTransformer(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiBitonalRasterTransformer()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiBitonalRasterTransformer(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiBitonalRasterTransformer) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public static OdGiRasterImage createObject(OdGiRasterImage pOrig, uint foregroundColor, uint backgroundColor, bool transparent)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_createObject__SWIG_0(OdGiRasterImage.getCPtr(pOrig), foregroundColor, backgroundColor, transparent), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setOriginal(OdGiRasterImage pOrig, uint foregroundColor, uint backgroundColor, bool transparent)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_setOriginal(swigCPtr, OdGiRasterImage.getCPtr(pOrig), foregroundColor, backgroundColor, transparent);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override uint numColors()
	{
		uint result = (SwigDerivedClassHasMethod("numColors", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_numColorsSwigExplicitOdGiBitonalRasterTransformer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_numColors(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint color(uint colorIndex)
	{
		uint result = (SwigDerivedClassHasMethod("color", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_colorSwigExplicitOdGiBitonalRasterTransformer(swigCPtr, colorIndex) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_color(swigCPtr, colorIndex));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint paletteDataSize()
	{
		uint result = (SwigDerivedClassHasMethod("paletteDataSize", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_paletteDataSizeSwigExplicitOdGiBitonalRasterTransformer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_paletteDataSize(swigCPtr));
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
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_paletteDataSwigExplicitOdGiBitonalRasterTransformer(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_paletteData(swigCPtr, intPtr);
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

	public override PixelFormatInfo pixelFormat()
	{
		PixelFormatInfo result = new PixelFormatInfo(SwigDerivedClassHasMethod("pixelFormat", swigMethodTypes17) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_pixelFormatSwigExplicitOdGiBitonalRasterTransformer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_pixelFormat(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override int transparentColor()
	{
		int result = (SwigDerivedClassHasMethod("transparentColor", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_transparentColorSwigExplicitOdGiBitonalRasterTransformer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_transparentColor(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdRxObject clone()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("clone", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_cloneSwigExplicitOdGiBitonalRasterTransformer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_clone(swigCPtr), bOwn: true, bTryAddToTransaction: true);
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
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_copyFromSwigExplicitOdGiBitonalRasterTransformer(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiBitonalRasterTransformer createObject()
	{
		OdGiBitonalRasterTransformer rXObject = Helpers.GetRXObject<OdGiBitonalRasterTransformer>(TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_createObject__SWIG_1(), bOwn: true, bTryAddToTransaction: true);
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiBitonalRasterTransformer_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiBitonalRasterTransformer));
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

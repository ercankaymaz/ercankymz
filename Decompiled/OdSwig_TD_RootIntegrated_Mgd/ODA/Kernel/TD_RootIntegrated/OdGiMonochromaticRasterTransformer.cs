using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMonochromaticRasterTransformer : OdGiGrayscaleRasterTransformer
{
	public delegate IntPtr SwigDelegateOdGiMonochromaticRasterTransformer_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiMonochromaticRasterTransformer_1();

	public delegate IntPtr SwigDelegateOdGiMonochromaticRasterTransformer_2();

	public delegate void SwigDelegateOdGiMonochromaticRasterTransformer_3(IntPtr pSource);

	public delegate uint SwigDelegateOdGiMonochromaticRasterTransformer_4();

	public delegate uint SwigDelegateOdGiMonochromaticRasterTransformer_5();

	public delegate int SwigDelegateOdGiMonochromaticRasterTransformer_6(double xPelsPerUnit, double yPelsPerUnit);

	public delegate uint SwigDelegateOdGiMonochromaticRasterTransformer_7();

	public delegate uint SwigDelegateOdGiMonochromaticRasterTransformer_8();

	public delegate int SwigDelegateOdGiMonochromaticRasterTransformer_9();

	public delegate uint SwigDelegateOdGiMonochromaticRasterTransformer_10(uint colorIndex);

	public delegate uint SwigDelegateOdGiMonochromaticRasterTransformer_11();

	public delegate void SwigDelegateOdGiMonochromaticRasterTransformer_12(IntPtr bytes);

	public delegate uint SwigDelegateOdGiMonochromaticRasterTransformer_13();

	public delegate IntPtr SwigDelegateOdGiMonochromaticRasterTransformer_14();

	public delegate void SwigDelegateOdGiMonochromaticRasterTransformer_15(IntPtr scnLines, uint firstScanline, uint numLines);

	public delegate void SwigDelegateOdGiMonochromaticRasterTransformer_16(IntPtr scnLines, uint firstScanline);

	public delegate IntPtr SwigDelegateOdGiMonochromaticRasterTransformer_17();

	public delegate uint SwigDelegateOdGiMonochromaticRasterTransformer_18();

	public delegate int SwigDelegateOdGiMonochromaticRasterTransformer_19();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdGiMonochromaticRasterTransformer_20();

	public delegate int SwigDelegateOdGiMonochromaticRasterTransformer_21();

	public delegate IntPtr SwigDelegateOdGiMonochromaticRasterTransformer_22(uint x, uint y, uint width, uint height);

	public delegate IntPtr SwigDelegateOdGiMonochromaticRasterTransformer_23();

	public delegate uint SwigDelegateOdGiMonochromaticRasterTransformer_24();

	public delegate void SwigDelegateOdGiMonochromaticRasterTransformer_25(int source);

	public delegate void SwigDelegateOdGiMonochromaticRasterTransformer_26([MarshalAs(UnmanagedType.LPWStr)] string fileName);

	public delegate void SwigDelegateOdGiMonochromaticRasterTransformer_27(int mode);

	public delegate uint SwigDelegateOdGiMonochromaticRasterTransformer_28(uint color);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiMonochromaticRasterTransformer_0 swigDelegate0;

	private SwigDelegateOdGiMonochromaticRasterTransformer_1 swigDelegate1;

	private SwigDelegateOdGiMonochromaticRasterTransformer_2 swigDelegate2;

	private SwigDelegateOdGiMonochromaticRasterTransformer_3 swigDelegate3;

	private SwigDelegateOdGiMonochromaticRasterTransformer_4 swigDelegate4;

	private SwigDelegateOdGiMonochromaticRasterTransformer_5 swigDelegate5;

	private SwigDelegateOdGiMonochromaticRasterTransformer_6 swigDelegate6;

	private SwigDelegateOdGiMonochromaticRasterTransformer_7 swigDelegate7;

	private SwigDelegateOdGiMonochromaticRasterTransformer_8 swigDelegate8;

	private SwigDelegateOdGiMonochromaticRasterTransformer_9 swigDelegate9;

	private SwigDelegateOdGiMonochromaticRasterTransformer_10 swigDelegate10;

	private SwigDelegateOdGiMonochromaticRasterTransformer_11 swigDelegate11;

	private SwigDelegateOdGiMonochromaticRasterTransformer_12 swigDelegate12;

	private SwigDelegateOdGiMonochromaticRasterTransformer_13 swigDelegate13;

	private SwigDelegateOdGiMonochromaticRasterTransformer_14 swigDelegate14;

	private SwigDelegateOdGiMonochromaticRasterTransformer_15 swigDelegate15;

	private SwigDelegateOdGiMonochromaticRasterTransformer_16 swigDelegate16;

	private SwigDelegateOdGiMonochromaticRasterTransformer_17 swigDelegate17;

	private SwigDelegateOdGiMonochromaticRasterTransformer_18 swigDelegate18;

	private SwigDelegateOdGiMonochromaticRasterTransformer_19 swigDelegate19;

	private SwigDelegateOdGiMonochromaticRasterTransformer_20 swigDelegate20;

	private SwigDelegateOdGiMonochromaticRasterTransformer_21 swigDelegate21;

	private SwigDelegateOdGiMonochromaticRasterTransformer_22 swigDelegate22;

	private SwigDelegateOdGiMonochromaticRasterTransformer_23 swigDelegate23;

	private SwigDelegateOdGiMonochromaticRasterTransformer_24 swigDelegate24;

	private SwigDelegateOdGiMonochromaticRasterTransformer_25 swigDelegate25;

	private SwigDelegateOdGiMonochromaticRasterTransformer_26 swigDelegate26;

	private SwigDelegateOdGiMonochromaticRasterTransformer_27 swigDelegate27;

	private SwigDelegateOdGiMonochromaticRasterTransformer_28 swigDelegate28;

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

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(uint) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMonochromaticRasterTransformer(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMonochromaticRasterTransformer obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMonochromaticRasterTransformer(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiMonochromaticRasterTransformer()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMonochromaticRasterTransformer(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMonochromaticRasterTransformer) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public static OdGiRasterImage createObject(OdGiRasterImage pOrig, int threshold)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_createObject__SWIG_0(OdGiRasterImage.getCPtr(pOrig), threshold), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiRasterImage createObject(OdGiRasterImage pOrig)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_createObject__SWIG_1(OdGiRasterImage.getCPtr(pOrig)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject clone()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("clone", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_cloneSwigExplicitOdGiMonochromaticRasterTransformer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_clone(swigCPtr), bOwn: true, bTryAddToTransaction: true);
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
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_copyFromSwigExplicitOdGiMonochromaticRasterTransformer(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setThreshold(byte treshold)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_setThreshold(swigCPtr, treshold);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int threshold()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_threshold(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected override uint colorXform(uint color)
	{
		uint result = (SwigDerivedClassHasMethod("colorXform", swigMethodTypes28) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_colorXformSwigExplicitOdGiMonochromaticRasterTransformer(swigCPtr, color) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_colorXform(swigCPtr, color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiMonochromaticRasterTransformer createObject()
	{
		OdGiMonochromaticRasterTransformer rXObject = Helpers.GetRXObject<OdGiMonochromaticRasterTransformer>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_createObject__SWIG_2(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("colorXform", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodcolorXform;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMonochromaticRasterTransformer_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMonochromaticRasterTransformer));
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

	private uint SwigDirectorMethodcolorXform(uint color)
	{
		return colorXform(color);
	}
}

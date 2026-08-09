using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRasterImage : OdRxObject
{
	public class PixelFormatInfo : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public byte redOffset
		{
			get
			{
				byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_redOffset_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_redOffset_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public byte numRedBits
		{
			get
			{
				byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_numRedBits_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_numRedBits_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public byte greenOffset
		{
			get
			{
				byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_greenOffset_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_greenOffset_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public byte numGreenBits
		{
			get
			{
				byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_numGreenBits_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_numGreenBits_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public byte blueOffset
		{
			get
			{
				byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_blueOffset_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_blueOffset_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public byte numBlueBits
		{
			get
			{
				byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_numBlueBits_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_numBlueBits_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public byte alphaOffset
		{
			get
			{
				byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_alphaOffset_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_alphaOffset_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public byte numAlphaBits
		{
			get
			{
				byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_numAlphaBits_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_numAlphaBits_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public byte bitsPerPixel
		{
			get
			{
				byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_bitsPerPixel_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_bitsPerPixel_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PixelFormatInfo(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(PixelFormatInfo obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~PixelFormatInfo()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRasterImage_PixelFormatInfo(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public bool IsEqual(PixelFormatInfo other)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_IsEqual(swigCPtr, getCPtr(other));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public PixelFormatInfo()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRasterImage_PixelFormatInfo(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isRGB()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_isRGB(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setRGB()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_setRGB(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isBGR()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_isBGR(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setBGR()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_setBGR(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool is16bitBGR()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_is16bitBGR(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void set16bitBGR()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_set16bitBGR(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isRGBA()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_isRGBA(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setRGBA()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_setRGBA(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isBGRA()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_isBGRA(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setBGRA()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_PixelFormatInfo_setBGRA(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate IntPtr SwigDelegateOdGiRasterImage_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiRasterImage_1();

	public delegate void SwigDelegateOdGiRasterImage_2(IntPtr pSource);

	public delegate uint SwigDelegateOdGiRasterImage_3();

	public delegate uint SwigDelegateOdGiRasterImage_4();

	public delegate int SwigDelegateOdGiRasterImage_5(double xPelsPerUnit, double yPelsPerUnit);

	public delegate uint SwigDelegateOdGiRasterImage_6();

	public delegate uint SwigDelegateOdGiRasterImage_7();

	public delegate int SwigDelegateOdGiRasterImage_8();

	public delegate uint SwigDelegateOdGiRasterImage_9(uint colorIndex);

	public delegate uint SwigDelegateOdGiRasterImage_10();

	public delegate void SwigDelegateOdGiRasterImage_11(IntPtr bytes);

	public delegate uint SwigDelegateOdGiRasterImage_12();

	public delegate IntPtr SwigDelegateOdGiRasterImage_13();

	public delegate void SwigDelegateOdGiRasterImage_14(IntPtr scnLines, uint firstScanline, uint numLines);

	public delegate void SwigDelegateOdGiRasterImage_15(IntPtr scnLines, uint firstScanline);

	public delegate IntPtr SwigDelegateOdGiRasterImage_16();

	public delegate uint SwigDelegateOdGiRasterImage_17();

	public delegate int SwigDelegateOdGiRasterImage_18();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdGiRasterImage_19();

	public delegate int SwigDelegateOdGiRasterImage_20();

	public delegate IntPtr SwigDelegateOdGiRasterImage_21(uint x, uint y, uint width, uint height);

	public delegate IntPtr SwigDelegateOdGiRasterImage_22();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiRasterImage_0 swigDelegate0;

	private SwigDelegateOdGiRasterImage_1 swigDelegate1;

	private SwigDelegateOdGiRasterImage_2 swigDelegate2;

	private SwigDelegateOdGiRasterImage_3 swigDelegate3;

	private SwigDelegateOdGiRasterImage_4 swigDelegate4;

	private SwigDelegateOdGiRasterImage_5 swigDelegate5;

	private SwigDelegateOdGiRasterImage_6 swigDelegate6;

	private SwigDelegateOdGiRasterImage_7 swigDelegate7;

	private SwigDelegateOdGiRasterImage_8 swigDelegate8;

	private SwigDelegateOdGiRasterImage_9 swigDelegate9;

	private SwigDelegateOdGiRasterImage_10 swigDelegate10;

	private SwigDelegateOdGiRasterImage_11 swigDelegate11;

	private SwigDelegateOdGiRasterImage_12 swigDelegate12;

	private SwigDelegateOdGiRasterImage_13 swigDelegate13;

	private SwigDelegateOdGiRasterImage_14 swigDelegate14;

	private SwigDelegateOdGiRasterImage_15 swigDelegate15;

	private SwigDelegateOdGiRasterImage_16 swigDelegate16;

	private SwigDelegateOdGiRasterImage_17 swigDelegate17;

	private SwigDelegateOdGiRasterImage_18 swigDelegate18;

	private SwigDelegateOdGiRasterImage_19 swigDelegate19;

	private SwigDelegateOdGiRasterImage_20 swigDelegate20;

	private SwigDelegateOdGiRasterImage_21 swigDelegate21;

	private SwigDelegateOdGiRasterImage_22 swigDelegate22;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(byte[]).MakeByRefType() };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[3]
	{
		typeof(byte[]).MakeByRefType(),
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(byte[]).MakeByRefType(),
		typeof(uint)
	};

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[4]
	{
		typeof(uint),
		typeof(uint),
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes22 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiRasterImage(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRasterImage obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRasterImage(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiRasterImage cast(OdRxObject pObj)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_isASwigExplicitOdGiRasterImage(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_queryXSwigExplicitOdGiRasterImage(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiRasterImage createObject()
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static double millimetersInUnit(OdGiRasterImage_Units units)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_millimetersInUnit((int)units);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint pixelWidth()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_pixelWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint pixelHeight()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_pixelHeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiRasterImage_Units defaultResolution(out double xPelsPerUnit, out double yPelsPerUnit)
	{
		int result = (SwigDerivedClassHasMethod("defaultResolution", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_defaultResolutionSwigExplicitOdGiRasterImage(swigCPtr, out xPelsPerUnit, out yPelsPerUnit) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_defaultResolution(swigCPtr, out xPelsPerUnit, out yPelsPerUnit));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_Units)result;
	}

	public virtual uint colorDepth()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_colorDepth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numColors()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_numColors(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int transparentColor()
	{
		int result = (SwigDerivedClassHasMethod("transparentColor", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_transparentColorSwigExplicitOdGiRasterImage(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_transparentColor(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint color(uint colorIndex)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_color(swigCPtr, colorIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint paletteDataSize()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_paletteDataSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void paletteData(ref byte[] bytes)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(bytes);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_paletteData(swigCPtr, intPtr);
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

	public virtual uint scanLineSize()
	{
		uint result = (SwigDerivedClassHasMethod("scanLineSize", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_scanLineSizeSwigExplicitOdGiRasterImage(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_scanLineSize(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual byte[] scanLines()
	{
		uint num = pixelHeight();
		byte[] scnLines = new byte[num * scanLineSize()];
		scanLines(ref scnLines, 0u, num);
		return scnLines;
	}

	public virtual void scanLines(ref byte[] scnLines, uint firstScanline, uint numLines)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(scnLines);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_scanLines__SWIG_1(swigCPtr, intPtr, firstScanline, numLines);
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

	public virtual void scanLines(ref byte[] scnLines, uint firstScanline)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(scnLines);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_scanLines__SWIG_2(swigCPtr, intPtr, firstScanline);
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

	public virtual PixelFormatInfo pixelFormat()
	{
		PixelFormatInfo result = new PixelFormatInfo(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_pixelFormat(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint scanLinesAlignment()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_scanLinesAlignment(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiRasterImage_ImageSource imageSource()
	{
		int result = (SwigDerivedClassHasMethod("imageSource", swigMethodTypes18) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_imageSourceSwigExplicitOdGiRasterImage(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_imageSource(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_ImageSource)result;
	}

	public virtual string sourceFileName()
	{
		string result = (SwigDerivedClassHasMethod("sourceFileName", swigMethodTypes19) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_sourceFileNameSwigExplicitOdGiRasterImage(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_sourceFileName(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiRasterImage_TransparencyMode transparencyMode()
	{
		int result = (SwigDerivedClassHasMethod("transparencyMode", swigMethodTypes20) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_transparencyModeSwigExplicitOdGiRasterImage(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_transparencyMode(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiRasterImage_TransparencyMode)result;
	}

	public OdGiRasterImage changeImageSource(OdGiRasterImage_ImageSource source, string pFileName)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_changeImageSource__SWIG_0(swigCPtr, (int)source, pFileName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage changeImageSource(OdGiRasterImage_ImageSource source)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_changeImageSource__SWIG_1(swigCPtr, (int)source), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage changeSourceFileName(string fileName)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_changeSourceFileName(swigCPtr, fileName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage changeTransparencyMode(OdGiRasterImage_TransparencyMode mode)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_changeTransparencyMode(swigCPtr, (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static uint calcBMPScanLineSize(uint pixelWidth, int colorDepth)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_calcBMPScanLineSize(pixelWidth, colorDepth);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint calcColorMask(byte numColorBits, byte colorOffset)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_calcColorMask__SWIG_0(numColorBits, colorOffset);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint calcColorMask(byte numColorBits)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_calcColorMask__SWIG_1(numColorBits);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiRasterImage convert(bool convertPaletteToRGB, double brightness, double contrast, double fade, uint backgroundColor, bool flipX, bool flipY, bool rotate90, OdGiRasterImage pDestDesc, bool transparency)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_convert__SWIG_0(swigCPtr, convertPaletteToRGB, brightness, contrast, fade, backgroundColor, flipX, flipY, rotate90, getCPtr(pDestDesc), transparency), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage convert(bool convertPaletteToRGB, double brightness, double contrast, double fade, uint backgroundColor, bool flipX, bool flipY, bool rotate90, OdGiRasterImage pDestDesc)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_convert__SWIG_1(swigCPtr, convertPaletteToRGB, brightness, contrast, fade, backgroundColor, flipX, flipY, rotate90, getCPtr(pDestDesc)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage convert(bool convertPaletteToRGB, double brightness, double contrast, double fade, uint backgroundColor, bool flipX, bool flipY, bool rotate90)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_convert__SWIG_2(swigCPtr, convertPaletteToRGB, brightness, contrast, fade, backgroundColor, flipX, flipY, rotate90), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage convert(bool convertPaletteToRGB, double brightness, double contrast, double fade, uint backgroundColor, bool flipX, bool flipY)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_convert__SWIG_3(swigCPtr, convertPaletteToRGB, brightness, contrast, fade, backgroundColor, flipX, flipY), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage convert(bool convertPaletteToRGB, double brightness, double contrast, double fade, uint backgroundColor, bool flipX)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_convert__SWIG_4(swigCPtr, convertPaletteToRGB, brightness, contrast, fade, backgroundColor, flipX), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage convert(bool convertPaletteToRGB, double brightness, double contrast, double fade, uint backgroundColor)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_convert__SWIG_5(swigCPtr, convertPaletteToRGB, brightness, contrast, fade, backgroundColor), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage convert(bool convertPaletteToRGB, double brightness, double contrast, double fade)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_convert__SWIG_6(swigCPtr, convertPaletteToRGB, brightness, contrast, fade), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage convert(bool convertPaletteToRGB, double brightness, double contrast)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_convert__SWIG_7(swigCPtr, convertPaletteToRGB, brightness, contrast), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage convert(bool convertPaletteToRGB, double brightness)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_convert__SWIG_8(swigCPtr, convertPaletteToRGB, brightness), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage convert(bool convertPaletteToRGB)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_convert__SWIG_9(swigCPtr, convertPaletteToRGB), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiRasterImage crop(uint x, uint y, uint width, uint height)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(SwigDerivedClassHasMethod("crop", swigMethodTypes21) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_cropSwigExplicitOdGiRasterImage(swigCPtr, x, y, width, height) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_crop(swigCPtr, x, y, width, height), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual IntPtr imp()
	{
		IntPtr result = (SwigDerivedClassHasMethod("imp", swigMethodTypes22) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_impSwigExplicitOdGiRasterImage(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_imp(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiRasterImage()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRasterImage(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiRasterImage) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("pixelWidth", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodpixelWidth;
		}
		if (SwigDerivedClassHasMethod("pixelHeight", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodpixelHeight;
		}
		if (SwigDerivedClassHasMethod("defaultResolution", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoddefaultResolution;
		}
		if (SwigDerivedClassHasMethod("colorDepth", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcolorDepth;
		}
		if (SwigDerivedClassHasMethod("numColors", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodnumColors;
		}
		if (SwigDerivedClassHasMethod("transparentColor", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodtransparentColor;
		}
		if (SwigDerivedClassHasMethod("color", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcolor;
		}
		if (SwigDerivedClassHasMethod("paletteDataSize", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodpaletteDataSize;
		}
		if (SwigDerivedClassHasMethod("paletteData", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodpaletteData;
		}
		if (SwigDerivedClassHasMethod("scanLineSize", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodscanLineSize;
		}
		if (SwigDerivedClassHasMethod("scanLines", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodscanLines__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("scanLines", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodscanLines__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("scanLines", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodscanLines__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("pixelFormat", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodpixelFormat;
		}
		if (SwigDerivedClassHasMethod("scanLinesAlignment", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodscanLinesAlignment;
		}
		if (SwigDerivedClassHasMethod("imageSource", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodimageSource;
		}
		if (SwigDerivedClassHasMethod("sourceFileName", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsourceFileName;
		}
		if (SwigDerivedClassHasMethod("transparencyMode", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodtransparencyMode;
		}
		if (SwigDerivedClassHasMethod("crop", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodcrop;
		}
		if (SwigDerivedClassHasMethod("imp", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodimp;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImage_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiRasterImage));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
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
		return getCPtr(crop(x, y, width, height)).Handle;
	}

	private IntPtr SwigDirectorMethodimp()
	{
		return imp();
	}
}

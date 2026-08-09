using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdFont : OdRxObject
{
	public delegate IntPtr SwigDelegateOdFont_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdFont_1();

	public delegate void SwigDelegateOdFont_2(IntPtr pSource);

	public delegate int SwigDelegateOdFont_3(IntPtr pStreamBuf);

	public delegate int SwigDelegateOdFont_4(char character, IntPtr advance, IntPtr pWd, IntPtr textProperties);

	public delegate int SwigDelegateOdFont_5(char character, IntPtr advance, IntPtr pGeometry, IntPtr textProperties);

	public delegate IntPtr SwigDelegateOdFont_6(char arg0, uint arg1, uint arg2, IntPtr arg3);

	public delegate double SwigDelegateOdFont_7();

	public delegate double SwigDelegateOdFont_8();

	public delegate uint SwigDelegateOdFont_9(IntPtr characters);

	public delegate bool SwigDelegateOdFont_10(char character);

	public delegate double SwigDelegateOdFont_11();

	public delegate double SwigDelegateOdFont_12();

	public delegate double SwigDelegateOdFont_13(double textSize);

	public delegate double SwigDelegateOdFont_14(double textSize);

	public delegate bool SwigDelegateOdFont_15();

	public delegate double SwigDelegateOdFont_16();

	public delegate void SwigDelegateOdFont_17(char character, IntPtr advance, IntPtr pointsOver, IntPtr pointsUnder, IntPtr textFlags);

	public delegate uint SwigDelegateOdFont_18(uint dwTable, uint dwOffset, IntPtr pBuffer, uint cbData);

	public delegate bool SwigDelegateOdFont_19();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdFont_20();

	public delegate void SwigDelegateOdFont_21(IntPtr arg0);

	public delegate int SwigDelegateOdFont_22(IntPtr arg0);

	public delegate double SwigDelegateOdFont_23(double textSize);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdFont_0 swigDelegate0;

	private SwigDelegateOdFont_1 swigDelegate1;

	private SwigDelegateOdFont_2 swigDelegate2;

	private SwigDelegateOdFont_3 swigDelegate3;

	private SwigDelegateOdFont_4 swigDelegate4;

	private SwigDelegateOdFont_5 swigDelegate5;

	private SwigDelegateOdFont_6 swigDelegate6;

	private SwigDelegateOdFont_7 swigDelegate7;

	private SwigDelegateOdFont_8 swigDelegate8;

	private SwigDelegateOdFont_9 swigDelegate9;

	private SwigDelegateOdFont_10 swigDelegate10;

	private SwigDelegateOdFont_11 swigDelegate11;

	private SwigDelegateOdFont_12 swigDelegate12;

	private SwigDelegateOdFont_13 swigDelegate13;

	private SwigDelegateOdFont_14 swigDelegate14;

	private SwigDelegateOdFont_15 swigDelegate15;

	private SwigDelegateOdFont_16 swigDelegate16;

	private SwigDelegateOdFont_17 swigDelegate17;

	private SwigDelegateOdFont_18 swigDelegate18;

	private SwigDelegateOdFont_19 swigDelegate19;

	private SwigDelegateOdFont_20 swigDelegate20;

	private SwigDelegateOdFont_21 swigDelegate21;

	private SwigDelegateOdFont_22 swigDelegate22;

	private SwigDelegateOdFont_23 swigDelegate23;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes4 = new Type[4]
	{
		typeof(char),
		typeof(OdGePoint2d),
		typeof(OdGiCommonDraw),
		typeof(OdTextProperties)
	};

	private static Type[] swigMethodTypes5 = new Type[4]
	{
		typeof(char),
		typeof(OdGePoint2d),
		typeof(OdGiConveyorGeometry),
		typeof(OdTextProperties)
	};

	private static Type[] swigMethodTypes6 = new Type[4]
	{
		typeof(char),
		typeof(uint),
		typeof(uint),
		typeof(OdTextProperties)
	};

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdCharArray) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(char) };

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[5]
	{
		typeof(char),
		typeof(OdGePoint2d),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdTextProperties)
	};

	private static Type[] swigMethodTypes18 = new Type[4]
	{
		typeof(uint),
		typeof(uint),
		typeof(IntPtr),
		typeof(uint)
	};

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdTtfDescriptor) };

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(double) };

	public const int kBigFont10 = 1;

	public const int kUniFont10 = 2;

	public const int kFont10 = 4;

	public const int kFont11 = 8;

	public const int kFont10A = 16;

	public const int kTrueType = 32;

	public const int kFontGdt = 64;

	public const int kFontSimplex6 = 128;

	public const int kShapes11 = 256;

	public const int kFontRsc = 512;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdFont(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdFont_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdFont obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdFont(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdFont cast(OdRxObject pObj)
	{
		OdFont rXObject = Helpers.GetRXObject<OdFont>(TD_RootIntegrated_GlobalsPINVOKE.OdFont_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdFont_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_isASwigExplicitOdFont(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_queryXSwigExplicitOdFont(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdFont createObject()
	{
		OdFont rXObject = Helpers.GetRXObject<OdFont>(TD_RootIntegrated_GlobalsPINVOKE.OdFont_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdFont()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdFont(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdFont) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public uint getFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdFont_getFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint flags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdFont_flags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFlags(uint fontFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFont_setFlags(swigCPtr, fontFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addFlag(uint fontFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdFont_addFlag(swigCPtr, fontFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult initialize(OdStreamBuf pStreamBuf)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdFont_initialize(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult drawCharacter(char character, OdGePoint2d advance, OdGiCommonDraw pWd, OdTextProperties textProperties)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdFont_drawCharacter__SWIG_0(swigCPtr, character, OdGePoint2d.getCPtr(advance), OdGiCommonDraw.getCPtr(pWd), OdTextProperties.getCPtr(textProperties));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult drawCharacter(char character, OdGePoint2d advance, OdGiConveyorGeometry pGeometry, OdTextProperties textProperties)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdFont_drawCharacter__SWIG_1(swigCPtr, character, OdGePoint2d.getCPtr(advance), pGeometry.GetInterfaceCPtr(), OdTextProperties.getCPtr(textProperties));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdTrVisRawTexture createCharacterTexture(char arg0, uint arg1, uint arg2, OdTextProperties arg3)
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("createCharacterTexture", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_createCharacterTextureSwigExplicitOdFont(swigCPtr, arg0, arg1, arg2, OdTextProperties.getCPtr(arg3)) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_createCharacterTexture(swigCPtr, arg0, arg1, arg2, OdTextProperties.getCPtr(arg3)));
		OdTrVisRawTexture result = ((intPtr == IntPtr.Zero) ? null : new OdTrVisRawTexture(intPtr, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getAbove()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdFont_getAbove(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getBelow()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdFont_getBelow(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getAvailableChars(OdCharArray characters)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdFont_getAvailableChars(swigCPtr, OdCharArray.getCPtr(characters));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasCharacter(char character)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdFont_hasCharacter(swigCPtr, character);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getHeight()
	{
		double result = (SwigDerivedClassHasMethod("getHeight", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_getHeightSwigExplicitOdFont(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_getHeight(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getInternalLeading()
	{
		double result = (SwigDerivedClassHasMethod("getInternalLeading", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_getInternalLeadingSwigExplicitOdFont(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_getInternalLeading(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double fontAbove()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdFont_fontAbove(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getUnderlinePos(double textSize)
	{
		double result = (SwigDerivedClassHasMethod("getUnderlinePos", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_getUnderlinePosSwigExplicitOdFont(swigCPtr, textSize) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_getUnderlinePos(swigCPtr, textSize));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getOverlinePos(double textSize)
	{
		double result = (SwigDerivedClassHasMethod("getOverlinePos", swigMethodTypes14) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_getOverlinePosSwigExplicitOdFont(swigCPtr, textSize) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_getOverlinePos(swigCPtr, textSize));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isShxFont()
	{
		bool result = (SwigDerivedClassHasMethod("isShxFont", swigMethodTypes15) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_isShxFontSwigExplicitOdFont(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_isShxFont(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getAverageWidth()
	{
		double result = (SwigDerivedClassHasMethod("getAverageWidth", swigMethodTypes16) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_getAverageWidthSwigExplicitOdFont(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_getAverageWidth(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getScore(char character, OdGePoint2d advance, OdGePoint3d pointsOver, OdGePoint3d pointsUnder, OdTextProperties textFlags)
	{
		if (SwigDerivedClassHasMethod("getScore", swigMethodTypes17))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdFont_getScoreSwigExplicitOdFont(swigCPtr, character, OdGePoint2d.getCPtr(advance), OdGePoint3d.getCPtr(pointsOver), OdGePoint3d.getCPtr(pointsUnder), OdTextProperties.getCPtr(textFlags));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdFont_getScore(swigCPtr, character, OdGePoint2d.getCPtr(advance), OdGePoint3d.getCPtr(pointsOver), OdGePoint3d.getCPtr(pointsUnder), OdTextProperties.getCPtr(textFlags));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getFontData(uint dwTable, uint dwOffset, IntPtr pBuffer, uint cbData)
	{
		uint result = (SwigDerivedClassHasMethod("getFontData", swigMethodTypes18) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_getFontDataSwigExplicitOdFont(swigCPtr, dwTable, dwOffset, pBuffer, cbData) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_getFontData(swigCPtr, dwTable, dwOffset, pBuffer, cbData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool supportsVerticalMode()
	{
		bool result = (SwigDerivedClassHasMethod("supportsVerticalMode", swigMethodTypes19) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_supportsVerticalModeSwigExplicitOdFont(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_supportsVerticalMode(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFileName()
	{
		string result = (SwigDerivedClassHasMethod("getFileName", swigMethodTypes20) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_getFileNameSwigExplicitOdFont(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_getFileName(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getDescriptor(OdTtfDescriptor arg0)
	{
		if (SwigDerivedClassHasMethod("getDescriptor", swigMethodTypes21))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdFont_getDescriptorSwigExplicitOdFont(swigCPtr, OdTtfDescriptor.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdFont_getDescriptor(swigCPtr, OdTtfDescriptor.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int getLogFont(IntPtr arg0)
	{
		int result = (SwigDerivedClassHasMethod("getLogFont", swigMethodTypes22) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_getLogFontSwigExplicitOdFont(swigCPtr, arg0) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_getLogFont(swigCPtr, arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getTextSizeAligned(double textSize)
	{
		double result = (SwigDerivedClassHasMethod("getTextSizeAligned", swigMethodTypes23) ? TD_RootIntegrated_GlobalsPINVOKE.OdFont_getTextSizeAlignedSwigExplicitOdFont(swigCPtr, textSize) : TD_RootIntegrated_GlobalsPINVOKE.OdFont_getTextSizeAligned(swigCPtr, textSize));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdFont_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		if (SwigDerivedClassHasMethod("initialize", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodinitialize;
		}
		if (SwigDerivedClassHasMethod("drawCharacter", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddrawCharacter__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("drawCharacter", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoddrawCharacter__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createCharacterTexture", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcreateCharacterTexture;
		}
		if (SwigDerivedClassHasMethod("getAbove", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetAbove;
		}
		if (SwigDerivedClassHasMethod("getBelow", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetBelow;
		}
		if (SwigDerivedClassHasMethod("getAvailableChars", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetAvailableChars;
		}
		if (SwigDerivedClassHasMethod("hasCharacter", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodhasCharacter;
		}
		if (SwigDerivedClassHasMethod("getHeight", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetHeight;
		}
		if (SwigDerivedClassHasMethod("getInternalLeading", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetInternalLeading;
		}
		if (SwigDerivedClassHasMethod("getUnderlinePos", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetUnderlinePos;
		}
		if (SwigDerivedClassHasMethod("getOverlinePos", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetOverlinePos;
		}
		if (SwigDerivedClassHasMethod("isShxFont", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodisShxFont;
		}
		if (SwigDerivedClassHasMethod("getAverageWidth", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetAverageWidth;
		}
		if (SwigDerivedClassHasMethod("getScore", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetScore;
		}
		if (SwigDerivedClassHasMethod("getFontData", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetFontData;
		}
		if (SwigDerivedClassHasMethod("supportsVerticalMode", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsupportsVerticalMode;
		}
		if (SwigDerivedClassHasMethod("getFileName", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodgetFileName;
		}
		if (SwigDerivedClassHasMethod("getDescriptor", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodgetDescriptor;
		}
		if (SwigDerivedClassHasMethod("getLogFont", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodgetLogFont;
		}
		if (SwigDerivedClassHasMethod("getTextSizeAligned", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodgetTextSizeAligned;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdFont_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdFont));
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

	private int SwigDirectorMethodinitialize(IntPtr pStreamBuf)
	{
		return (int)initialize(Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethoddrawCharacter__SWIG_0(char character, IntPtr advance, IntPtr pWd, IntPtr textProperties)
	{
		return (int)drawCharacter(character, new OdGePoint2d(advance, cMemoryOwn: false), Helpers.GetRXObject<OdGiCommonDraw>(pWd, bOwn: false, bTryAddToTransaction: false), new OdTextProperties(textProperties, cMemoryOwn: false));
	}

	private int SwigDirectorMethoddrawCharacter__SWIG_1(char character, IntPtr advance, IntPtr pGeometry, IntPtr textProperties)
	{
		return (int)drawCharacter(character, new OdGePoint2d(advance, cMemoryOwn: false), new OdGiConveyorGeometry_Internal(pGeometry, cMemoryOwn: false), new OdTextProperties(textProperties, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodcreateCharacterTexture(char arg0, uint arg1, uint arg2, IntPtr arg3)
	{
		return OdTrVisRawTexture.getCPtr(createCharacterTexture(arg0, arg1, arg2, new OdTextProperties(arg3, cMemoryOwn: false))).Handle;
	}

	private double SwigDirectorMethodgetAbove()
	{
		return getAbove();
	}

	private double SwigDirectorMethodgetBelow()
	{
		return getBelow();
	}

	private uint SwigDirectorMethodgetAvailableChars(IntPtr characters)
	{
		return getAvailableChars(new OdCharArray(characters, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodhasCharacter(char character)
	{
		return hasCharacter(character);
	}

	private double SwigDirectorMethodgetHeight()
	{
		return getHeight();
	}

	private double SwigDirectorMethodgetInternalLeading()
	{
		return getInternalLeading();
	}

	private double SwigDirectorMethodgetUnderlinePos(double textSize)
	{
		return getUnderlinePos(textSize);
	}

	private double SwigDirectorMethodgetOverlinePos(double textSize)
	{
		return getOverlinePos(textSize);
	}

	private bool SwigDirectorMethodisShxFont()
	{
		return isShxFont();
	}

	private double SwigDirectorMethodgetAverageWidth()
	{
		return getAverageWidth();
	}

	private void SwigDirectorMethodgetScore(char character, IntPtr advance, IntPtr pointsOver, IntPtr pointsUnder, IntPtr textFlags)
	{
		try
		{
			getScore(character, new OdGePoint2d(advance, cMemoryOwn: false), (pointsOver == IntPtr.Zero) ? null : new OdGePoint3d(pointsOver, cMemoryOwn: false), (pointsUnder == IntPtr.Zero) ? null : new OdGePoint3d(pointsUnder, cMemoryOwn: false), new OdTextProperties(textFlags, cMemoryOwn: false));
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

	private uint SwigDirectorMethodgetFontData(uint dwTable, uint dwOffset, IntPtr pBuffer, uint cbData)
	{
		return getFontData(dwTable, dwOffset, pBuffer, cbData);
	}

	private bool SwigDirectorMethodsupportsVerticalMode()
	{
		return supportsVerticalMode();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetFileName()
	{
		return getFileName();
	}

	private void SwigDirectorMethodgetDescriptor(IntPtr arg0)
	{
		try
		{
			getDescriptor(new OdTtfDescriptor(arg0, cMemoryOwn: false));
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

	private int SwigDirectorMethodgetLogFont(IntPtr arg0)
	{
		return getLogFont(arg0);
	}

	private double SwigDirectorMethodgetTextSizeAligned(double textSize)
	{
		return getTextSizeAligned(textSize);
	}
}

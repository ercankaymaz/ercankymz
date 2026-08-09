using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdCmColor : OdCmColorBase
{
	public delegate int SwigDelegateOdCmColor_0();

	public delegate void SwigDelegateOdCmColor_1(int colorMethod);

	public delegate bool SwigDelegateOdCmColor_2();

	public delegate bool SwigDelegateOdCmColor_3();

	public delegate bool SwigDelegateOdCmColor_4();

	public delegate bool SwigDelegateOdCmColor_5();

	public delegate bool SwigDelegateOdCmColor_6();

	public delegate bool SwigDelegateOdCmColor_7();

	public delegate uint SwigDelegateOdCmColor_8();

	public delegate void SwigDelegateOdCmColor_9(uint color);

	public delegate void SwigDelegateOdCmColor_10(byte red, byte green, byte blue);

	public delegate void SwigDelegateOdCmColor_11(byte red);

	public delegate void SwigDelegateOdCmColor_12(byte green);

	public delegate void SwigDelegateOdCmColor_13(byte blue);

	public delegate byte SwigDelegateOdCmColor_14();

	public delegate byte SwigDelegateOdCmColor_15();

	public delegate byte SwigDelegateOdCmColor_16();

	public delegate ushort SwigDelegateOdCmColor_17();

	public delegate void SwigDelegateOdCmColor_18(ushort colorIndex);

	public delegate bool SwigDelegateOdCmColor_19([MarshalAs(UnmanagedType.LPWStr)] string colorName, [MarshalAs(UnmanagedType.LPWStr)] string bookName);

	public delegate bool SwigDelegateOdCmColor_20([MarshalAs(UnmanagedType.LPWStr)] string colorName);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdCmColor_21();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdCmColor_22();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdCmColor_23();

	public delegate bool SwigDelegateOdCmColor_24();

	public delegate bool SwigDelegateOdCmColor_25();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdCmColor_0 swigDelegate0;

	private SwigDelegateOdCmColor_1 swigDelegate1;

	private SwigDelegateOdCmColor_2 swigDelegate2;

	private SwigDelegateOdCmColor_3 swigDelegate3;

	private SwigDelegateOdCmColor_4 swigDelegate4;

	private SwigDelegateOdCmColor_5 swigDelegate5;

	private SwigDelegateOdCmColor_6 swigDelegate6;

	private SwigDelegateOdCmColor_7 swigDelegate7;

	private SwigDelegateOdCmColor_8 swigDelegate8;

	private SwigDelegateOdCmColor_9 swigDelegate9;

	private SwigDelegateOdCmColor_10 swigDelegate10;

	private SwigDelegateOdCmColor_11 swigDelegate11;

	private SwigDelegateOdCmColor_12 swigDelegate12;

	private SwigDelegateOdCmColor_13 swigDelegate13;

	private SwigDelegateOdCmColor_14 swigDelegate14;

	private SwigDelegateOdCmColor_15 swigDelegate15;

	private SwigDelegateOdCmColor_16 swigDelegate16;

	private SwigDelegateOdCmColor_17 swigDelegate17;

	private SwigDelegateOdCmColor_18 swigDelegate18;

	private SwigDelegateOdCmColor_19 swigDelegate19;

	private SwigDelegateOdCmColor_20 swigDelegate20;

	private SwigDelegateOdCmColor_21 swigDelegate21;

	private SwigDelegateOdCmColor_22 swigDelegate22;

	private SwigDelegateOdCmColor_23 swigDelegate23;

	private SwigDelegateOdCmColor_24 swigDelegate24;

	private SwigDelegateOdCmColor_25 swigDelegate25;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdCmEntityColor_ColorMethod) };

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes10 = new Type[3]
	{
		typeof(byte),
		typeof(byte),
		typeof(byte)
	};

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(byte) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(byte) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(byte) };

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(ushort) };

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[0];

	private static Type[] swigMethodTypes25 = new Type[0];

	public static ushort MaxColorIndex
	{
		get
		{
			ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_MaxColorIndex_get();
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdCmColor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdCmColor obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdCmColor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override string ToString()
	{
		if (swigCPtr.Handle == IntPtr.Zero)
		{
			return "Empty";
		}
		string result = "???";
		if (isByLayer())
		{
			result = "ByLayer";
		}
		else if (isByBlock())
		{
			result = "ByBlock";
		}
		else if (isForeground())
		{
			result = "Foreground";
		}
		else if (isNone())
		{
			result = "None";
		}
		else if (isByACI())
		{
			result = $"ACI = {colorIndex()}";
		}
		else if (isByColor())
		{
			result = "ByColor r" + red() + ":g" + green() + ":b" + blue();
		}
		return result;
	}

	public OdCmColor()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdCmColor__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdCmColor) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdCmColor(OdCmColor color)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdCmColor__SWIG_1(getCPtr(color)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdCmColor) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdCmColor(OdCmColorBase color)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdCmColor__SWIG_2(OdCmColorBase.getCPtr(color)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdCmColor) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdCmColor(OdCmEntityColor_ColorMethod color)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdCmColor__SWIG_3((int)color), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdCmColor) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdCmColor Assign(OdCmColor color)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_Assign__SWIG_0(swigCPtr, getCPtr(color)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmColor Assign(OdCmColorBase color)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_Assign__SWIG_1(swigCPtr, OdCmColorBase.getCPtr(color)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdCmColor color)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_IsEqual__SWIG_0(swigCPtr, getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdCmColorBase color)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_IsEqual__SWIG_1(swigCPtr, OdCmColorBase.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdCmColor color)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_IsNotEqual__SWIG_0(swigCPtr, getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdCmColorBase color)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_IsNotEqual__SWIG_1(swigCPtr, OdCmColorBase.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string getDescription()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_getDescription(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string getExplanation()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_getExplanation(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdCmEntityColor_ColorMethod colorMethod()
	{
		int result = (SwigDerivedClassHasMethod("colorMethod", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_colorMethodSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_colorMethod(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCmEntityColor_ColorMethod)result;
	}

	public override void setColorMethod(OdCmEntityColor_ColorMethod colorMethod)
	{
		if (SwigDerivedClassHasMethod("setColorMethod", swigMethodTypes1))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setColorMethodSwigExplicitOdCmColor(swigCPtr, (int)colorMethod);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setColorMethod(swigCPtr, (int)colorMethod);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isByColor()
	{
		bool result = (SwigDerivedClassHasMethod("isByColor", swigMethodTypes2) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_isByColorSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_isByColor(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isByLayer()
	{
		bool result = (SwigDerivedClassHasMethod("isByLayer", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_isByLayerSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_isByLayer(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isByBlock()
	{
		bool result = (SwigDerivedClassHasMethod("isByBlock", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_isByBlockSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_isByBlock(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isByACI()
	{
		bool result = (SwigDerivedClassHasMethod("isByACI", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_isByACISwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_isByACI(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isForeground()
	{
		bool result = (SwigDerivedClassHasMethod("isForeground", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_isForegroundSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_isForeground(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isByDgnIndex()
	{
		bool result = (SwigDerivedClassHasMethod("isByDgnIndex", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_isByDgnIndexSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_isByDgnIndex(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isNone()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_isNone(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint color()
	{
		uint result = (SwigDerivedClassHasMethod("color", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_colorSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_color(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setColor(uint color)
	{
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes9))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setColorSwigExplicitOdCmColor(swigCPtr, color);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setColor(swigCPtr, color);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setRGB(byte red, byte green, byte blue)
	{
		if (SwigDerivedClassHasMethod("setRGB", swigMethodTypes10))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setRGBSwigExplicitOdCmColor(swigCPtr, red, green, blue);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setRGB(swigCPtr, red, green, blue);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setRed(byte red)
	{
		if (SwigDerivedClassHasMethod("setRed", swigMethodTypes11))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setRedSwigExplicitOdCmColor(swigCPtr, red);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setRed(swigCPtr, red);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setGreen(byte green)
	{
		if (SwigDerivedClassHasMethod("setGreen", swigMethodTypes12))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setGreenSwigExplicitOdCmColor(swigCPtr, green);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setGreen(swigCPtr, green);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setBlue(byte blue)
	{
		if (SwigDerivedClassHasMethod("setBlue", swigMethodTypes13))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setBlueSwigExplicitOdCmColor(swigCPtr, blue);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setBlue(swigCPtr, blue);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override byte red()
	{
		byte result = (SwigDerivedClassHasMethod("red", swigMethodTypes14) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_redSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_red(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override byte green()
	{
		byte result = (SwigDerivedClassHasMethod("green", swigMethodTypes15) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_greenSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_green(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override byte blue()
	{
		byte result = (SwigDerivedClassHasMethod("blue", swigMethodTypes16) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_blueSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_blue(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override ushort colorIndex()
	{
		ushort result = (SwigDerivedClassHasMethod("colorIndex", swigMethodTypes17) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_colorIndexSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_colorIndex(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setColorIndex(ushort colorIndex)
	{
		if (SwigDerivedClassHasMethod("setColorIndex", swigMethodTypes18))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setColorIndexSwigExplicitOdCmColor(swigCPtr, colorIndex);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setColorIndex(swigCPtr, colorIndex);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool setNames(string colorName, string bookName)
	{
		bool result = (SwigDerivedClassHasMethod("setNames", swigMethodTypes19) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setNamesSwigExplicitOdCmColor__SWIG_0(swigCPtr, colorName, bookName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setNames__SWIG_0(swigCPtr, colorName, bookName));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool setNames(string colorName)
	{
		bool result = (SwigDerivedClassHasMethod("setNames", swigMethodTypes20) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setNamesSwigExplicitOdCmColor__SWIG_1(swigCPtr, colorName) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setNames__SWIG_1(swigCPtr, colorName));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string colorName()
	{
		string result = (SwigDerivedClassHasMethod("colorName", swigMethodTypes21) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_colorNameSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_colorName(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string bookName()
	{
		string result = (SwigDerivedClassHasMethod("bookName", swigMethodTypes22) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_bookNameSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_bookName(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override string colorNameForDisplay()
	{
		string result = (SwigDerivedClassHasMethod("colorNameForDisplay", swigMethodTypes23) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_colorNameForDisplaySwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_colorNameForDisplay(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool hasColorName()
	{
		bool result = (SwigDerivedClassHasMethod("hasColorName", swigMethodTypes24) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_hasColorNameSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_hasColorName(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool hasBookName()
	{
		bool result = (SwigDerivedClassHasMethod("hasBookName", swigMethodTypes25) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_hasBookNameSwigExplicitOdCmColor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_hasBookName(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmEntityColor entityColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_entityColor(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string getDictionaryKey()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_getDictionaryKey(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setNamesFromDictionaryKey(string dictionaryKey)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_setNamesFromDictionaryKey(swigCPtr, dictionaryKey);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void dwgIn(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_dwgIn(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void dwgOut(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_dwgOut(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void dxfIn(OdDbDxfFiler pFiler, int groupCodeOffset)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_dxfIn__SWIG_0(swigCPtr, OdDbDxfFiler.getCPtr(pFiler), groupCodeOffset);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void dxfIn(OdDbDxfFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_dxfIn__SWIG_1(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void dxfOut(OdDbDxfFiler pFiler, int groupCodeOffset)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_dxfOut__SWIG_0(swigCPtr, OdDbDxfFiler.getCPtr(pFiler), groupCodeOffset);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void dxfOut(OdDbDxfFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_dxfOut__SWIG_1(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void audit(OdDbAuditInfo pAuditInfo)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_audit(swigCPtr, OdDbAuditInfo.getCPtr(pAuditInfo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void dwgInAsTrueColor(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_dwgInAsTrueColor(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void dwgOutAsTrueColor(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_dwgOutAsTrueColor(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdResult odcmGetColorFromColorBookName(OdCmColor color, SWIGTYPE_p_OdColorBook__BooksMap bookMap, string bookName, string colorName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_odcmGetColorFromColorBookName__SWIG_0(getCPtr(color), SWIGTYPE_p_OdColorBook__BooksMap.getCPtr(bookMap), bookName, colorName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult odcmGetColorFromColorBookName(OdCmColor color, string bookName, string colorName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_odcmGetColorFromColorBookName__SWIG_1(getCPtr(color), bookName, colorName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void dxfIn(OdDbDxfFiler pFiler, int groupCodeOffset, bool bFixColor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_dxfIn__SWIG_2(swigCPtr, OdDbDxfFiler.getCPtr(pFiler), groupCodeOffset, bFixColor);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool dxfInXRec(OdDbDxfFiler pFiler, int groupCodeOffset)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_dxfInXRec(swigCPtr, OdDbDxfFiler.getCPtr(pFiler), groupCodeOffset);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void dxfOutXRec(OdDbDxfFiler pFiler, int groupCodeOffset)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_dxfOutXRec(swigCPtr, OdDbDxfFiler.getCPtr(pFiler), groupCodeOffset);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("colorMethod", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodcolorMethod;
		}
		if (SwigDerivedClassHasMethod("setColorMethod", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodsetColorMethod;
		}
		if (SwigDerivedClassHasMethod("isByColor", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodisByColor;
		}
		if (SwigDerivedClassHasMethod("isByLayer", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisByLayer;
		}
		if (SwigDerivedClassHasMethod("isByBlock", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisByBlock;
		}
		if (SwigDerivedClassHasMethod("isByACI", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodisByACI;
		}
		if (SwigDerivedClassHasMethod("isForeground", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodisForeground;
		}
		if (SwigDerivedClassHasMethod("isByDgnIndex", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodisByDgnIndex;
		}
		if (SwigDerivedClassHasMethod("color", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcolor;
		}
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetColor;
		}
		if (SwigDerivedClassHasMethod("setRGB", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetRGB;
		}
		if (SwigDerivedClassHasMethod("setRed", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetRed;
		}
		if (SwigDerivedClassHasMethod("setGreen", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetGreen;
		}
		if (SwigDerivedClassHasMethod("setBlue", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetBlue;
		}
		if (SwigDerivedClassHasMethod("red", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodred;
		}
		if (SwigDerivedClassHasMethod("green", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgreen;
		}
		if (SwigDerivedClassHasMethod("blue", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodblue;
		}
		if (SwigDerivedClassHasMethod("colorIndex", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodcolorIndex;
		}
		if (SwigDerivedClassHasMethod("setColorIndex", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodsetColorIndex;
		}
		if (SwigDerivedClassHasMethod("setNames", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetNames__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setNames", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsetNames__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("colorName", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodcolorName;
		}
		if (SwigDerivedClassHasMethod("bookName", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodbookName;
		}
		if (SwigDerivedClassHasMethod("colorNameForDisplay", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodcolorNameForDisplay;
		}
		if (SwigDerivedClassHasMethod("hasColorName", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodhasColorName;
		}
		if (SwigDerivedClassHasMethod("hasBookName", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodhasBookName;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdCmColor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdCmColor));
	}

	private int SwigDirectorMethodcolorMethod()
	{
		return (int)colorMethod();
	}

	private void SwigDirectorMethodsetColorMethod(int colorMethod)
	{
		try
		{
			setColorMethod((OdCmEntityColor_ColorMethod)colorMethod);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisByColor()
	{
		return isByColor();
	}

	private bool SwigDirectorMethodisByLayer()
	{
		return isByLayer();
	}

	private bool SwigDirectorMethodisByBlock()
	{
		return isByBlock();
	}

	private bool SwigDirectorMethodisByACI()
	{
		return isByACI();
	}

	private bool SwigDirectorMethodisForeground()
	{
		return isForeground();
	}

	private bool SwigDirectorMethodisByDgnIndex()
	{
		return isByDgnIndex();
	}

	private uint SwigDirectorMethodcolor()
	{
		return color();
	}

	private void SwigDirectorMethodsetColor(uint color)
	{
		try
		{
			setColor(color);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetRGB(byte red, byte green, byte blue)
	{
		try
		{
			setRGB(red, green, blue);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetRed(byte red)
	{
		try
		{
			setRed(red);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetGreen(byte green)
	{
		try
		{
			setGreen(green);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetBlue(byte blue)
	{
		try
		{
			setBlue(blue);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private byte SwigDirectorMethodred()
	{
		return red();
	}

	private byte SwigDirectorMethodgreen()
	{
		return green();
	}

	private byte SwigDirectorMethodblue()
	{
		return blue();
	}

	private ushort SwigDirectorMethodcolorIndex()
	{
		return colorIndex();
	}

	private void SwigDirectorMethodsetColorIndex(ushort colorIndex)
	{
		try
		{
			setColorIndex(colorIndex);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodsetNames__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string colorName, [MarshalAs(UnmanagedType.LPWStr)] string bookName)
	{
		return setNames(colorName, bookName);
	}

	private bool SwigDirectorMethodsetNames__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string colorName)
	{
		return setNames(colorName);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodcolorName()
	{
		return colorName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodbookName()
	{
		return bookName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodcolorNameForDisplay()
	{
		return colorNameForDisplay();
	}

	private bool SwigDirectorMethodhasColorName()
	{
		return hasColorName();
	}

	private bool SwigDirectorMethodhasBookName()
	{
		return hasBookName();
	}
}

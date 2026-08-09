using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdCmColorBase : IDisposable
{
	public delegate int SwigDelegateOdCmColorBase_0();

	public delegate void SwigDelegateOdCmColorBase_1(int colorMethod);

	public delegate bool SwigDelegateOdCmColorBase_2();

	public delegate bool SwigDelegateOdCmColorBase_3();

	public delegate bool SwigDelegateOdCmColorBase_4();

	public delegate bool SwigDelegateOdCmColorBase_5();

	public delegate bool SwigDelegateOdCmColorBase_6();

	public delegate bool SwigDelegateOdCmColorBase_7();

	public delegate uint SwigDelegateOdCmColorBase_8();

	public delegate void SwigDelegateOdCmColorBase_9(uint color);

	public delegate void SwigDelegateOdCmColorBase_10(byte red, byte green, byte blue);

	public delegate void SwigDelegateOdCmColorBase_11(byte red);

	public delegate void SwigDelegateOdCmColorBase_12(byte green);

	public delegate void SwigDelegateOdCmColorBase_13(byte blue);

	public delegate byte SwigDelegateOdCmColorBase_14();

	public delegate byte SwigDelegateOdCmColorBase_15();

	public delegate byte SwigDelegateOdCmColorBase_16();

	public delegate ushort SwigDelegateOdCmColorBase_17();

	public delegate void SwigDelegateOdCmColorBase_18(ushort colorIndex);

	public delegate bool SwigDelegateOdCmColorBase_19([MarshalAs(UnmanagedType.LPWStr)] string colorName, [MarshalAs(UnmanagedType.LPWStr)] string bookName);

	public delegate bool SwigDelegateOdCmColorBase_20([MarshalAs(UnmanagedType.LPWStr)] string colorName);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdCmColorBase_21();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdCmColorBase_22();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdCmColorBase_23();

	public delegate bool SwigDelegateOdCmColorBase_24();

	public delegate bool SwigDelegateOdCmColorBase_25();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdCmColorBase_0 swigDelegate0;

	private SwigDelegateOdCmColorBase_1 swigDelegate1;

	private SwigDelegateOdCmColorBase_2 swigDelegate2;

	private SwigDelegateOdCmColorBase_3 swigDelegate3;

	private SwigDelegateOdCmColorBase_4 swigDelegate4;

	private SwigDelegateOdCmColorBase_5 swigDelegate5;

	private SwigDelegateOdCmColorBase_6 swigDelegate6;

	private SwigDelegateOdCmColorBase_7 swigDelegate7;

	private SwigDelegateOdCmColorBase_8 swigDelegate8;

	private SwigDelegateOdCmColorBase_9 swigDelegate9;

	private SwigDelegateOdCmColorBase_10 swigDelegate10;

	private SwigDelegateOdCmColorBase_11 swigDelegate11;

	private SwigDelegateOdCmColorBase_12 swigDelegate12;

	private SwigDelegateOdCmColorBase_13 swigDelegate13;

	private SwigDelegateOdCmColorBase_14 swigDelegate14;

	private SwigDelegateOdCmColorBase_15 swigDelegate15;

	private SwigDelegateOdCmColorBase_16 swigDelegate16;

	private SwigDelegateOdCmColorBase_17 swigDelegate17;

	private SwigDelegateOdCmColorBase_18 swigDelegate18;

	private SwigDelegateOdCmColorBase_19 swigDelegate19;

	private SwigDelegateOdCmColorBase_20 swigDelegate20;

	private SwigDelegateOdCmColorBase_21 swigDelegate21;

	private SwigDelegateOdCmColorBase_22 swigDelegate22;

	private SwigDelegateOdCmColorBase_23 swigDelegate23;

	private SwigDelegateOdCmColorBase_24 swigDelegate24;

	private SwigDelegateOdCmColorBase_25 swigDelegate25;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdCmColorBase(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdCmColorBase obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdCmColorBase()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdCmColorBase(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual OdCmEntityColor_ColorMethod colorMethod()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_colorMethod(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCmEntityColor_ColorMethod)result;
	}

	public virtual void setColorMethod(OdCmEntityColor_ColorMethod colorMethod)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_setColorMethod(swigCPtr, (int)colorMethod);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isByColor()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_isByColor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isByLayer()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_isByLayer(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isByBlock()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_isByBlock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isByACI()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_isByACI(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isForeground()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_isForeground(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isByDgnIndex()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_isByDgnIndex(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint color()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_color(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColor(uint color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_setColor(swigCPtr, color);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRGB(byte red, byte green, byte blue)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_setRGB(swigCPtr, red, green, blue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRed(byte red)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_setRed(swigCPtr, red);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGreen(byte green)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_setGreen(swigCPtr, green);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBlue(byte blue)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_setBlue(swigCPtr, blue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte red()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_red(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual byte green()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_green(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual byte blue()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_blue(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ushort colorIndex()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_colorIndex(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColorIndex(ushort colorIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_setColorIndex(swigCPtr, colorIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool setNames(string colorName, string bookName)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_setNames__SWIG_0(swigCPtr, colorName, bookName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setNames(string colorName)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_setNames__SWIG_1(swigCPtr, colorName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string colorName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_colorName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string bookName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_bookName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string colorNameForDisplay()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_colorNameForDisplay(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasColorName()
	{
		bool result = (SwigDerivedClassHasMethod("hasColorName", swigMethodTypes24) ? TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_hasColorNameSwigExplicitOdCmColorBase(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_hasColorName(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasBookName()
	{
		bool result = (SwigDerivedClassHasMethod("hasBookName", swigMethodTypes25) ? TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_hasBookNameSwigExplicitOdCmColorBase(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_hasBookName(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmColorBase()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdCmColorBase(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdCmColorBase) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		TD_RootIntegrated_GlobalsPINVOKE.OdCmColorBase_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdCmColorBase));
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

	private void SwigDirectorMethodsetRGB(byte red, byte green, byte blue)
	{
		try
		{
			setRGB(red, green, blue);
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

	private void SwigDirectorMethodsetRed(byte red)
	{
		try
		{
			setRed(red);
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

	private void SwigDirectorMethodsetGreen(byte green)
	{
		try
		{
			setGreen(green);
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

	private void SwigDirectorMethodsetBlue(byte blue)
	{
		try
		{
			setBlue(blue);
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

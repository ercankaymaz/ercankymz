using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdUnitsFormatterTool : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdUnitsFormatterTool(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdUnitsFormatterTool obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdUnitsFormatterTool()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdUnitsFormatterTool(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdUnitsFormatterTool()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdUnitsFormatterTool(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static string formatDecimal(double value, int precision, int dimzin, string decsep, string thsep)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_formatDecimal__SWIG_0(value, precision, dimzin, decsep, thsep);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string formatDecimal(double value, int precision, int dimzin, string decsep)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_formatDecimal__SWIG_1(value, precision, dimzin, decsep);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double angle(char[] buf, bool refuseDots)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_angle__SWIG_0(buf, refuseDots);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double angle(char[] buf)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_angle__SWIG_1(buf);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int toInt(string sValue, int nMinValid, int nMaxValid)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_toInt__SWIG_0(sValue, nMinValid, nMaxValid);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int toInt(string sValue, int nMinValid)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_toInt__SWIG_1(sValue, nMinValid);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int toInt(string sValue)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_toInt__SWIG_2(sValue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isZero(double v, int precision)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_isZero(v, precision);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string formatArchitectural(bool isNegative, int feet, int entier, int numerator, int denominator, int dimzin, int mode)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_formatArchitectural(isNegative, feet, entier, numerator, denominator, dimzin, mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool negative(char[] buf)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_negative(buf);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double integer(char[] buf)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_integer(buf);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double number(char[] buf, bool pHasDot, bool pHasExponent)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_number__SWIG_0(buf, pHasDot, pHasExponent);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double number(char[] buf, bool pHasDot)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_number__SWIG_1(buf, pHasDot);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double number(char[] buf)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_number__SWIG_2(buf);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void fraction(double value, out int entier, out int numerator, out int denominator, int precision)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_fraction(value, out entier, out numerator, out denominator, precision);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static double base_denominator(int prec, double base_)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_base_denominator(prec, base_);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double linear_denominator(int prec)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_linear_denominator(prec);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool digit(char c)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_digit(c);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double denominator(int prec)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_denominator(prec);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void decomp(double v, out int degs, out int mins, out double secs, int prec)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_decomp(v, out degs, out mins, out secs, prec);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static string format(int degs, int mins, double secs, int prec)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_format(degs, mins, secs, prec);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string next(ref string list, string delim)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(list);
		IntPtr intPtr = jarg;
		try
		{
			string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_next__SWIG_0(ref jarg, delim);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				list = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static string next(ref string list)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(list);
		IntPtr intPtr = jarg;
		try
		{
			string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_next__SWIG_1(ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				list = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static int countOccurences(string string_, char delim)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_countOccurences__SWIG_0(string_, delim);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int countOccurences(string string_)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatterTool_countOccurences__SWIG_1(string_);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}

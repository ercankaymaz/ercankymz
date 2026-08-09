using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdCharMapper : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdCharMapper(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdCharMapper obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdCharMapper()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdCharMapper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdResult initialize(string filename)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_initialize(filename);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult unicodeToCodepage(char sourceChar, OdCodePageId codepageId, char codepageChar, bool bTryToUseSystemCP)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_unicodeToCodepage__SWIG_0(sourceChar, (int)codepageId, codepageChar, bTryToUseSystemCP);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult unicodeToCodepage(char sourceChar, OdCodePageId codepageId, char codepageChar)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_unicodeToCodepage__SWIG_1(sourceChar, (int)codepageId, codepageChar);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult unicodeToCodepage2(char sourceChar, OdCodePageId codepageId, char codepageChar)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_unicodeToCodepage2(sourceChar, (int)codepageId, codepageChar);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult codepageToUnicode(char sourceChar, OdCodePageId codepageId, char unicodeChar)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_codepageToUnicode(sourceChar, (int)codepageId, unicodeChar);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static bool isLeadByte(byte testByte, OdCodePageId codepageId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_isLeadByte(testByte, (int)codepageId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdResult codepageDescToId(string description, OdCodePageId codepageId)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_codepageDescToId(description, codepageId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult codepageIdToDesc(OdCodePageId codepageId, ref string description)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(description);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_codepageIdToDesc((int)codepageId, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				description = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static uint numValidCodepages()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_numValidCodepages();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdCodePageId ansiCpToAcadCp(uint ansiCodePage)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_ansiCpToAcadCp(ansiCodePage);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCodePageId)result;
	}

	public static uint acadCpToAnsiCp(OdCodePageId acadCodePageId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_acadCpToAnsiCp((int)acadCodePageId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdCodePageId getCodepageByCharset(ushort ansiCharacterSet)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_getCodepageByCharset(ansiCharacterSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCodePageId)result;
	}

	public static ushort getReorderCharsetByChar(char ch)
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_getReorderCharsetByChar(ch);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isConversionSupported(OdCodePageId codepageId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_isConversionSupported((int)codepageId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void wideCharToMultiByte(OdCodePageId codePage, string srcBuf, int srcSize, OdAnsiCharArray dstBuf)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_wideCharToMultiByte((int)codePage, srcBuf, srcSize, OdAnsiCharArray.getCPtr(dstBuf).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void multiByteToWideChar(OdCodePageId codePage, string srcBuf, int srcSize, OdCharArray dstBuf)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_multiByteToWideChar((int)codePage, srcBuf, srcSize, OdCharArray.getCPtr(dstBuf));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool utf8ToUnicode(string srcBuf, int srcSize, OdCharArray dstBuf)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_utf8ToUnicode(srcBuf, srcSize, OdCharArray.getCPtr(dstBuf));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void unicodeToUtf8(string srcBuf, int srcSize, OdAnsiCharArray dstBuf)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_unicodeToUtf8(srcBuf, srcSize, OdAnsiCharArray.getCPtr(dstBuf).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdResult addBigFontWithIndex(string bigFont, int cpIndex)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_addBigFontWithIndex(bigFont, cpIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult addBigFontWithCodepage(string bigFont, OdCodePageId codePageId)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_addBigFontWithCodepage(bigFont, (int)codePageId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult addBigFonts(OdStreamBuf io)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_addBigFonts(OdStreamBuf.getCPtr(io));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdCodePageId getCpByBigFont(string bigFont)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_getCpByBigFont(bigFont);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCodePageId)result;
	}

	public static int getCpIndexByBigFont(string bigFont)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_getCpIndexByBigFont(bigFont);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double getCheckSumAnsi(string str)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_getCheckSumAnsi(str);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double getCheckSumUnicode(string str)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_getCheckSumUnicode(str);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string convertCIFcoding(string strText)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_convertCIFcoding(strText);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string convertAlphaNumJapanese(string strText)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_convertAlphaNumJapanese(strText);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool containsSpecialSequence(ref string str, OdFont font, OdIntArray ulRanges)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(str);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_containsSpecialSequence(ref jarg, OdFont.getCPtr(font), OdIntArray.getCPtr(ulRanges).Handle);
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
				str = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static string embedTextRawData(string msg, OdIntArray ulFlags, int length, bool raw)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_embedTextRawData__SWIG_0(msg, OdIntArray.getCPtr(ulFlags).Handle, length, raw);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string embedTextRawData(string msg, OdIntArray ulFlags, int length)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_embedTextRawData__SWIG_1(msg, OdIntArray.getCPtr(ulFlags).Handle, length);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string embedTextRawData(string msg, OdIntArray ulFlags)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_embedTextRawData__SWIG_2(msg, OdIntArray.getCPtr(ulFlags).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdCodePageId systemCodePage()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharMapper_systemCodePage();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCodePageId)result;
	}
}

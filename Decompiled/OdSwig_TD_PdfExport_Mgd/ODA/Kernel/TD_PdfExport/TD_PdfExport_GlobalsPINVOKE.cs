using System;
using System.IO;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_PDFToolkit;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

internal class TD_PdfExport_GlobalsPINVOKE
{
	protected class SWIGExceptionHelper
	{
		public delegate void ExceptionDelegate(string message);

		public delegate void ExceptionArgumentDelegate(string message, string paramName);

		private static ExceptionDelegate applicationDelegate;

		private static ExceptionDelegate arithmeticDelegate;

		private static ExceptionDelegate divideByZeroDelegate;

		private static ExceptionDelegate indexOutOfRangeDelegate;

		private static ExceptionDelegate invalidCastDelegate;

		private static ExceptionDelegate invalidOperationDelegate;

		private static ExceptionDelegate ioDelegate;

		private static ExceptionDelegate nullReferenceDelegate;

		private static ExceptionDelegate outOfMemoryDelegate;

		private static ExceptionDelegate overflowDelegate;

		private static ExceptionDelegate systemDelegate;

		private static ExceptionArgumentDelegate argumentDelegate;

		private static ExceptionArgumentDelegate argumentNullDelegate;

		private static ExceptionArgumentDelegate argumentOutOfRangeDelegate;

		[DllImport("OdSwig_TD_PdfExport_26.10_17.dll")]
		public static extern void SWIGRegisterExceptionCallbacks_TD_PdfExport_Globals(ExceptionDelegate applicationDelegate, ExceptionDelegate arithmeticDelegate, ExceptionDelegate divideByZeroDelegate, ExceptionDelegate indexOutOfRangeDelegate, ExceptionDelegate invalidCastDelegate, ExceptionDelegate invalidOperationDelegate, ExceptionDelegate ioDelegate, ExceptionDelegate nullReferenceDelegate, ExceptionDelegate outOfMemoryDelegate, ExceptionDelegate overflowDelegate, ExceptionDelegate systemExceptionDelegate);

		[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_TD_PdfExport_Globals")]
		public static extern void SWIGRegisterExceptionCallbacksArgument_TD_PdfExport_Globals(ExceptionArgumentDelegate argumentDelegate, ExceptionArgumentDelegate argumentNullDelegate, ExceptionArgumentDelegate argumentOutOfRangeDelegate);

		private static void SetPendingApplicationException(string message)
		{
			SWIGPendingException.Set(new ApplicationException(message, SWIGPendingException.Retrieve()));
		}

		private static void SetPendingArithmeticException(string message)
		{
			SWIGPendingException.Set(new ArithmeticException(message, SWIGPendingException.Retrieve()));
		}

		private static void SetPendingDivideByZeroException(string message)
		{
			SWIGPendingException.Set(new DivideByZeroException(message, SWIGPendingException.Retrieve()));
		}

		private static void SetPendingIndexOutOfRangeException(string message)
		{
			SWIGPendingException.Set(new IndexOutOfRangeException(message, SWIGPendingException.Retrieve()));
		}

		private static void SetPendingInvalidCastException(string message)
		{
			SWIGPendingException.Set(new InvalidCastException(message, SWIGPendingException.Retrieve()));
		}

		private static void SetPendingInvalidOperationException(string message)
		{
			SWIGPendingException.Set(new InvalidOperationException(message, SWIGPendingException.Retrieve()));
		}

		private static void SetPendingIOException(string message)
		{
			SWIGPendingException.Set(new IOException(message, SWIGPendingException.Retrieve()));
		}

		private static void SetPendingNullReferenceException(string message)
		{
			SWIGPendingException.Set(new NullReferenceException(message, SWIGPendingException.Retrieve()));
		}

		private static void SetPendingOutOfMemoryException(string message)
		{
			SWIGPendingException.Set(new OutOfMemoryException(message, SWIGPendingException.Retrieve()));
		}

		private static void SetPendingOverflowException(string message)
		{
			SWIGPendingException.Set(new OverflowException(message, SWIGPendingException.Retrieve()));
		}

		private static void SetPendingSystemException(string message)
		{
			SWIGPendingException.Set(new SystemException(message, SWIGPendingException.Retrieve()));
		}

		private static void SetPendingArgumentException(string message, string paramName)
		{
			SWIGPendingException.Set(new ArgumentException(message, paramName, SWIGPendingException.Retrieve()));
		}

		private static void SetPendingArgumentNullException(string message, string paramName)
		{
			Exception ex = SWIGPendingException.Retrieve();
			if (ex != null)
			{
				message = message + " Inner Exception: " + ex.Message;
			}
			SWIGPendingException.Set(new ArgumentNullException(paramName, message));
		}

		private static void SetPendingArgumentOutOfRangeException(string message, string paramName)
		{
			Exception ex = SWIGPendingException.Retrieve();
			if (ex != null)
			{
				message = message + " Inner Exception: " + ex.Message;
			}
			SWIGPendingException.Set(new ArgumentOutOfRangeException(paramName, message));
		}

		static SWIGExceptionHelper()
		{
			applicationDelegate = SetPendingApplicationException;
			arithmeticDelegate = SetPendingArithmeticException;
			divideByZeroDelegate = SetPendingDivideByZeroException;
			indexOutOfRangeDelegate = SetPendingIndexOutOfRangeException;
			invalidCastDelegate = SetPendingInvalidCastException;
			invalidOperationDelegate = SetPendingInvalidOperationException;
			ioDelegate = SetPendingIOException;
			nullReferenceDelegate = SetPendingNullReferenceException;
			outOfMemoryDelegate = SetPendingOutOfMemoryException;
			overflowDelegate = SetPendingOverflowException;
			systemDelegate = SetPendingSystemException;
			argumentDelegate = SetPendingArgumentException;
			argumentNullDelegate = SetPendingArgumentNullException;
			argumentOutOfRangeDelegate = SetPendingArgumentOutOfRangeException;
			SWIGRegisterExceptionCallbacks_TD_PdfExport_Globals(applicationDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, outOfMemoryDelegate, overflowDelegate, systemDelegate);
			SWIGRegisterExceptionCallbacksArgument_TD_PdfExport_Globals(argumentDelegate, argumentNullDelegate, argumentOutOfRangeDelegate);
		}
	}

	public class SWIGPendingException
	{
		[ThreadStatic]
		private static Exception pendingException;

		private static int numExceptionsPending;

		private static object exceptionsLock;

		public static bool Pending
		{
			get
			{
				bool result = false;
				if (numExceptionsPending > 0 && pendingException != null)
				{
					result = true;
				}
				return result;
			}
		}

		public static void Set(Exception e)
		{
			if (pendingException != null)
			{
				throw new ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + pendingException.ToString() + ")", e);
			}
			pendingException = e;
			lock (exceptionsLock)
			{
				numExceptionsPending++;
			}
		}

		public static Exception Retrieve()
		{
			Exception result = null;
			if (numExceptionsPending > 0 && pendingException != null)
			{
				result = pendingException;
				pendingException = null;
				lock (exceptionsLock)
				{
					numExceptionsPending--;
				}
			}
			return result;
		}

		static SWIGPendingException()
		{
			exceptionsLock = new object();
		}
	}

	protected class SWIGStringHelper
	{
		public delegate string SWIGStringDelegate(string message);

		private static SWIGStringDelegate stringDelegate;

		[DllImport("OdSwig_TD_PdfExport_26.10_17.dll")]
		public static extern void SWIGRegisterStringCallback_TD_PdfExport_Globals(SWIGStringDelegate stringDelegate);

		private static string CreateString(string cString)
		{
			return cString;
		}

		static SWIGStringHelper()
		{
			stringDelegate = CreateString;
			SWIGRegisterStringCallback_TD_PdfExport_Globals(stringDelegate);
		}
	}

	private class CustomExceptionHelper
	{
		public delegate void CustomExceptionDelegate(IntPtr NewContext);

		private static CustomExceptionDelegate customDelegate;

		[DllImport("OdSwig_TD_PdfExport_26.10_17.dll")]
		public static extern void CustomExceptionRegisterCallback(CustomExceptionDelegate customCallback);

		private static void SetPendingCustomException(IntPtr NewContext)
		{
			SWIGPendingException.Set(new OdError(new OdErrorContext(NewContext, cMemoryOwn: true)));
		}

		static CustomExceptionHelper()
		{
			customDelegate = SetPendingCustomException;
			CustomExceptionRegisterCallback(customDelegate);
		}
	}

	protected static SWIGExceptionHelper swigExceptionHelper;

	protected static SWIGStringHelper swigStringHelper;

	private static CustomExceptionHelper exceptionHelper;

	static TD_PdfExport_GlobalsPINVOKE()
	{
		swigExceptionHelper = new SWIGExceptionHelper();
		swigStringHelper = new SWIGStringHelper();
		exceptionHelper = new CustomExceptionHelper();
	}

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_UINT_MAX_get___")]
	public static extern uint UINT_MAX_get();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_ULONG_MAX_get___")]
	public static extern uint ULONG_MAX_get();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport__MSC_VER_get___")]
	public static extern int _MSC_VER_get();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_ODCHAR_IS_INT16LE_get___")]
	public static extern int ODCHAR_IS_INT16LE_get();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OD_SIZEOF_INT_get___")]
	public static extern int OD_SIZEOF_INT_get();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OD_SIZEOF_LONG_get___")]
	public static extern int OD_SIZEOF_LONG_get();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PERCENT18LONG_get___")]
	public static extern string PERCENT18LONG_get();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_HANDLEFORMAT_get___")]
	public static extern string HANDLEFORMAT_get();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRId64_get___")]
	public static extern string PRId64_get();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRIu64_get___")]
	public static extern string PRIu64_get();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRIx64_get___")]
	public static extern string PRIx64_get();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRIX64_get___")]
	public static extern string PRIX64_get();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OD_SIZEOF_PTR_get___")]
	public static extern int OD_SIZEOF_PTR_get();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_throw_native_exception_string___")]
	public static extern void throw_native_exception_string([MarshalAs(UnmanagedType.LPWStr)] string jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_throw_native_OdError__SWIG_0___")]
	public static extern void throw_native_OdError__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_throw_native_OdError__SWIG_1___")]
	public static extern void throw_native_OdError__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_throw_native_OdError__SWIG_2___")]
	public static extern void throw_native_OdError__SWIG_2(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_sec_set___")]
	public static extern void tm_tm_sec_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_sec_get___")]
	public static extern int tm_tm_sec_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_min_set___")]
	public static extern void tm_tm_min_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_min_get___")]
	public static extern int tm_tm_min_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_hour_set___")]
	public static extern void tm_tm_hour_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_hour_get___")]
	public static extern int tm_tm_hour_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_mday_set___")]
	public static extern void tm_tm_mday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_mday_get___")]
	public static extern int tm_tm_mday_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_mon_set___")]
	public static extern void tm_tm_mon_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_mon_get___")]
	public static extern int tm_tm_mon_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_year_set___")]
	public static extern void tm_tm_year_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_year_get___")]
	public static extern int tm_tm_year_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_wday_set___")]
	public static extern void tm_tm_wday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_wday_get___")]
	public static extern int tm_tm_wday_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_yday_set___")]
	public static extern void tm_tm_yday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_yday_get___")]
	public static extern int tm_tm_yday_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_isdst_set___")]
	public static extern void tm_tm_isdst_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_tm_tm_isdst_get___")]
	public static extern int tm_tm_isdst_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_tm___")]
	public static extern IntPtr new_tm();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_tm___")]
	public static extern void delete_tm(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_PDFExportParams_setPalette")]
	public static extern void PDFExportParams_setPalette(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_PDFExportParams_getPalette")]
	public static extern IntPtr PDFExportParams_getPalette(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_cast___")]
	public static extern IntPtr OdPrcContextForPdfExport_cast(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_desc___")]
	public static extern IntPtr OdPrcContextForPdfExport_desc();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_isA___")]
	public static extern IntPtr OdPrcContextForPdfExport_isA(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_isASwigExplicitOdPrcContextForPdfExport___")]
	public static extern IntPtr OdPrcContextForPdfExport_isASwigExplicitOdPrcContextForPdfExport(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_queryX___")]
	public static extern IntPtr OdPrcContextForPdfExport_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_queryXSwigExplicitOdPrcContextForPdfExport___")]
	public static extern IntPtr OdPrcContextForPdfExport_queryXSwigExplicitOdPrcContextForPdfExport(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_OdPrcContextForPdfExport___")]
	public static extern IntPtr new_OdPrcContextForPdfExport();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_shouldExportAsPRC___")]
	public static extern bool OdPrcContextForPdfExport_shouldExportAsPRC(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4, out uint jarg5);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_shouldExportAsPRCSwigExplicitOdPrcContextForPdfExport___")]
	public static extern bool OdPrcContextForPdfExport_shouldExportAsPRCSwigExplicitOdPrcContextForPdfExport(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4, out uint jarg5);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_getExtents___")]
	public static extern void OdPrcContextForPdfExport_getExtents(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4, HandleRef jarg5, HandleRef jarg6, HandleRef jarg7);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_getExtentsSwigExplicitOdPrcContextForPdfExport___")]
	public static extern void OdPrcContextForPdfExport_getExtentsSwigExplicitOdPrcContextForPdfExport(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4, HandleRef jarg5, HandleRef jarg6, HandleRef jarg7);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_setUserData___")]
	public static extern void OdPrcContextForPdfExport_setUserData(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_setUserDataSwigExplicitOdPrcContextForPdfExport___")]
	public static extern void OdPrcContextForPdfExport_setUserDataSwigExplicitOdPrcContextForPdfExport(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_getWritePdfFile___")]
	public static extern bool OdPrcContextForPdfExport_getWritePdfFile(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_getWritePdfFileSwigExplicitOdPrcContextForPdfExport___")]
	public static extern bool OdPrcContextForPdfExport_getWritePdfFileSwigExplicitOdPrcContextForPdfExport(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_setWritePdfFile___")]
	public static extern void OdPrcContextForPdfExport_setWritePdfFile(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_setWritePdfFileSwigExplicitOdPrcContextForPdfExport___")]
	public static extern void OdPrcContextForPdfExport_setWritePdfFileSwigExplicitOdPrcContextForPdfExport(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_getRealClassName___")]
	public static extern string OdPrcContextForPdfExport_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_UserData___")]
	public static extern IntPtr OdPrcContextForPdfExport_UserData(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_createObject___")]
	public static extern IntPtr OdPrcContextForPdfExport_createObject();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_OdPrcContextForPdfExport___")]
	public static extern void delete_OdPrcContextForPdfExport(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_director_connect___")]
	public static extern void OdPrcContextForPdfExport_director_connect(HandleRef jarg1, OdPrcContextForPdfExport.SwigDelegateOdPrcContextForPdfExport_0 delegate0, OdPrcContextForPdfExport.SwigDelegateOdPrcContextForPdfExport_1 delegate1, OdPrcContextForPdfExport.SwigDelegateOdPrcContextForPdfExport_2 delegate2, OdPrcContextForPdfExport.SwigDelegateOdPrcContextForPdfExport_3 delegate3, OdPrcContextForPdfExport.SwigDelegateOdPrcContextForPdfExport_4 delegate4, OdPrcContextForPdfExport.SwigDelegateOdPrcContextForPdfExport_5 delegate5, OdPrcContextForPdfExport.SwigDelegateOdPrcContextForPdfExport_6 delegate6, OdPrcContextForPdfExport.SwigDelegateOdPrcContextForPdfExport_7 delegate7);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_cast___")]
	public static extern IntPtr OdPrcContextForPdfExportWrapper_cast(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_desc___")]
	public static extern IntPtr OdPrcContextForPdfExportWrapper_desc();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_isA___")]
	public static extern IntPtr OdPrcContextForPdfExportWrapper_isA(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_isASwigExplicitOdPrcContextForPdfExportWrapper___")]
	public static extern IntPtr OdPrcContextForPdfExportWrapper_isASwigExplicitOdPrcContextForPdfExportWrapper(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_queryX___")]
	public static extern IntPtr OdPrcContextForPdfExportWrapper_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_queryXSwigExplicitOdPrcContextForPdfExportWrapper___")]
	public static extern IntPtr OdPrcContextForPdfExportWrapper_queryXSwigExplicitOdPrcContextForPdfExportWrapper(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_getOutputPRC___")]
	public static extern IntPtr OdPrcContextForPdfExportWrapper_getOutputPRC(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_setOutputPRC___")]
	public static extern void OdPrcContextForPdfExportWrapper_setOutputPRC(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_getUserContext___")]
	public static extern IntPtr OdPrcContextForPdfExportWrapper_getUserContext(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_setUserContext___")]
	public static extern void OdPrcContextForPdfExportWrapper_setUserContext(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_shouldExportAsPRC___")]
	public static extern bool OdPrcContextForPdfExportWrapper_shouldExportAsPRC(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4, out uint jarg5);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_shouldExportAsPRCSwigExplicitOdPrcContextForPdfExportWrapper___")]
	public static extern bool OdPrcContextForPdfExportWrapper_shouldExportAsPRCSwigExplicitOdPrcContextForPdfExportWrapper(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4, out uint jarg5);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_setUserData___")]
	public static extern void OdPrcContextForPdfExportWrapper_setUserData(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_setUserDataSwigExplicitOdPrcContextForPdfExportWrapper___")]
	public static extern void OdPrcContextForPdfExportWrapper_setUserDataSwigExplicitOdPrcContextForPdfExportWrapper(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_getWritePdfFile___")]
	public static extern bool OdPrcContextForPdfExportWrapper_getWritePdfFile(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_getWritePdfFileSwigExplicitOdPrcContextForPdfExportWrapper___")]
	public static extern bool OdPrcContextForPdfExportWrapper_getWritePdfFileSwigExplicitOdPrcContextForPdfExportWrapper(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_getRealClassName___")]
	public static extern string OdPrcContextForPdfExportWrapper_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_UserData___")]
	public static extern IntPtr OdPrcContextForPdfExportWrapper_UserData(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_createObject___")]
	public static extern IntPtr OdPrcContextForPdfExportWrapper_createObject();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_OdPrcContextForPdfExportWrapper___")]
	public static extern IntPtr new_OdPrcContextForPdfExportWrapper();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_OdPrcContextForPdfExportWrapper___")]
	public static extern void delete_OdPrcContextForPdfExportWrapper(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_director_connect___")]
	public static extern void OdPrcContextForPdfExportWrapper_director_connect(HandleRef jarg1, OdPrcContextForPdfExportWrapper.SwigDelegateOdPrcContextForPdfExportWrapper_0 delegate0, OdPrcContextForPdfExportWrapper.SwigDelegateOdPrcContextForPdfExportWrapper_1 delegate1, OdPrcContextForPdfExportWrapper.SwigDelegateOdPrcContextForPdfExportWrapper_2 delegate2, OdPrcContextForPdfExportWrapper.SwigDelegateOdPrcContextForPdfExportWrapper_3 delegate3, OdPrcContextForPdfExportWrapper.SwigDelegateOdPrcContextForPdfExportWrapper_4 delegate4, OdPrcContextForPdfExportWrapper.SwigDelegateOdPrcContextForPdfExportWrapper_5 delegate5, OdPrcContextForPdfExportWrapper.SwigDelegateOdPrcContextForPdfExportWrapper_6 delegate6, OdPrcContextForPdfExportWrapper.SwigDelegateOdPrcContextForPdfExportWrapper_7 delegate7);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_odCreatePrcAllInSingleViewContextBase___")]
	public static extern IntPtr odCreatePrcAllInSingleViewContextBase();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_text_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_text_set(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_text_get___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_2D_EXPORT_Watermark_text_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_color_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_color_set(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_color_get___")]
	public static extern uint TD_PDF_2D_EXPORT_Watermark_color_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_fontSize_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_fontSize_set(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_fontSize_get___")]
	public static extern ushort TD_PDF_2D_EXPORT_Watermark_fontSize_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_opacity_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_opacity_set(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_opacity_get___")]
	public static extern ushort TD_PDF_2D_EXPORT_Watermark_opacity_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_font_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_font_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_font_get___")]
	public static extern int TD_PDF_2D_EXPORT_Watermark_font_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_position_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_position_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_position_get___")]
	public static extern int TD_PDF_2D_EXPORT_Watermark_position_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_scaleToPage_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_scaleToPage_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_scaleToPage_get___")]
	public static extern bool TD_PDF_2D_EXPORT_Watermark_scaleToPage_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_offset_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_offset_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_offset_get___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_Watermark_offset_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_rotation_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_rotation_set(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_rotation_get___")]
	public static extern double TD_PDF_2D_EXPORT_Watermark_rotation_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_pageIndex_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_pageIndex_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_pageIndex_get___")]
	public static extern int TD_PDF_2D_EXPORT_Watermark_pageIndex_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_fontName_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_fontName_set(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_fontName_get___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_2D_EXPORT_Watermark_fontName_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_imagePath_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_imagePath_set(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_imagePath_get___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_2D_EXPORT_Watermark_imagePath_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_imageWidth_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_imageWidth_set(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_imageWidth_get___")]
	public static extern ushort TD_PDF_2D_EXPORT_Watermark_imageWidth_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_imageHeight_set___")]
	public static extern void TD_PDF_2D_EXPORT_Watermark_imageHeight_set(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_Watermark_imageHeight_get___")]
	public static extern ushort TD_PDF_2D_EXPORT_Watermark_imageHeight_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_TD_PDF_2D_EXPORT_Watermark___")]
	public static extern IntPtr new_TD_PDF_2D_EXPORT_Watermark();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_TD_PDF_2D_EXPORT_Watermark___")]
	public static extern void delete_TD_PDF_2D_EXPORT_Watermark(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_TD_PDF_2D_EXPORT_PdfExportReactor___")]
	public static extern void delete_TD_PDF_2D_EXPORT_PdfExportReactor(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportReactor_beginViewVectorization___")]
	public static extern void TD_PDF_2D_EXPORT_PdfExportReactor_beginViewVectorization(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportReactor_endViewVectorization___")]
	public static extern void TD_PDF_2D_EXPORT_PdfExportReactor_endViewVectorization(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_PDFExportBaseParamsSwigImpl___")]
	public static extern void delete_PDFExportBaseParamsSwigImpl(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportBaseParamsSwigImpl_setDatabase___")]
	public static extern void PDFExportBaseParamsSwigImpl_setDatabase(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportBaseParamsSwigImpl_database___")]
	public static extern IntPtr PDFExportBaseParamsSwigImpl_database(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportBaseParamsSwigImpl_setSelectionSetsArray___")]
	public static extern void PDFExportBaseParamsSwigImpl_setSelectionSetsArray(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportBaseParamsSwigImpl_getSelectionSetsArray___")]
	public static extern IntPtr PDFExportBaseParamsSwigImpl_getSelectionSetsArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportBaseParamsSwigImpl_setLayouts__SWIG_0___")]
	public static extern void PDFExportBaseParamsSwigImpl_setLayouts__SWIG_0(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportBaseParamsSwigImpl_setLayouts__SWIG_1___")]
	public static extern void PDFExportBaseParamsSwigImpl_setLayouts__SWIG_1(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportBaseParamsSwigImpl_addLayout___")]
	public static extern void PDFExportBaseParamsSwigImpl_addLayout(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportBaseParamsSwigImpl_layouts___")]
	public static extern IntPtr PDFExportBaseParamsSwigImpl_layouts(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportBaseParamsSwigImpl_databases___")]
	public static extern IntPtr PDFExportBaseParamsSwigImpl_databases(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportBaseParamsSwigImpl_clearMultipleDbSettings___")]
	public static extern void PDFExportBaseParamsSwigImpl_clearMultipleDbSettings(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_PDFExportBaseParamsSwigImpl__SWIG_0___")]
	public static extern IntPtr new_PDFExportBaseParamsSwigImpl__SWIG_0();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_PDFExportBaseParamsSwigImpl__SWIG_1___")]
	public static extern IntPtr new_PDFExportBaseParamsSwigImpl__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportBaseParamsSwigImpl_director_connect___")]
	public static extern void PDFExportBaseParamsSwigImpl_director_connect(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_PRCExportParamsSwigImpl__SWIG_0___")]
	public static extern IntPtr new_PRCExportParamsSwigImpl__SWIG_0();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_PRCExportParamsSwigImpl___")]
	public static extern void delete_PRCExportParamsSwigImpl(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_setPRCMode___")]
	public static extern void PRCExportParamsSwigImpl_setPRCMode(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_setPRCModeSwigExplicitPRCExportParamsSwigImpl___")]
	public static extern void PRCExportParamsSwigImpl_setPRCModeSwigExplicitPRCExportParamsSwigImpl(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_getPRCMode___")]
	public static extern int PRCExportParamsSwigImpl_getPRCMode(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_getPRCContext___")]
	public static extern IntPtr PRCExportParamsSwigImpl_getPRCContext(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_setPRCContext___")]
	public static extern void PRCExportParamsSwigImpl_setPRCContext(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_hasPrcBrepCompression___")]
	public static extern bool PRCExportParamsSwigImpl_hasPrcBrepCompression(HandleRef jarg1, out PDF3D_ENUMS_PRCCompressionLevel jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_hasPrcTessellationCompression___")]
	public static extern bool PRCExportParamsSwigImpl_hasPrcTessellationCompression(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_setPRCCompression___")]
	public static extern void PRCExportParamsSwigImpl_setPRCCompression(HandleRef jarg1, int jarg2, bool jarg3, bool jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_getPrcExportAmbientColorBehavior___")]
	public static extern int PRCExportParamsSwigImpl_getPrcExportAmbientColorBehavior(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_setPrcExportAmbientColorBehavior___")]
	public static extern void PRCExportParamsSwigImpl_setPrcExportAmbientColorBehavior(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_PRCExportParamsSwigImpl__SWIG_1___")]
	public static extern IntPtr new_PRCExportParamsSwigImpl__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_setDatabase___")]
	public static extern void PRCExportParamsSwigImpl_setDatabase(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_database___")]
	public static extern IntPtr PRCExportParamsSwigImpl_database(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_setSelectionSetsArray___")]
	public static extern void PRCExportParamsSwigImpl_setSelectionSetsArray(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_getSelectionSetsArray___")]
	public static extern IntPtr PRCExportParamsSwigImpl_getSelectionSetsArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_setLayouts__SWIG_0___")]
	public static extern void PRCExportParamsSwigImpl_setLayouts__SWIG_0(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_setLayouts__SWIG_1___")]
	public static extern void PRCExportParamsSwigImpl_setLayouts__SWIG_1(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_addLayout___")]
	public static extern void PRCExportParamsSwigImpl_addLayout(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_layouts___")]
	public static extern IntPtr PRCExportParamsSwigImpl_layouts(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_databases___")]
	public static extern IntPtr PRCExportParamsSwigImpl_databases(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_clearMultipleDbSettings___")]
	public static extern void PRCExportParamsSwigImpl_clearMultipleDbSettings(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_director_connect___")]
	public static extern void PRCExportParamsSwigImpl_director_connect(HandleRef jarg1, PRCExportParamsSwigImpl.SwigDelegatePRCExportParamsSwigImpl_0 delegate0);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_hasPrcBackground___")]
	public static extern bool PDFExport3DParamsSwigImpl_hasPrcBackground(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_getPrcBackground___")]
	public static extern uint PDFExport3DParamsSwigImpl_getPrcBackground(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_setPrcBackground___")]
	public static extern void PDFExport3DParamsSwigImpl_setPrcBackground(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_clearPrcBackground___")]
	public static extern void PDFExport3DParamsSwigImpl_clearPrcBackground(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_getPrcRenderingMode___")]
	public static extern int PDFExport3DParamsSwigImpl_getPrcRenderingMode(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_setPrcRenderingMode___")]
	public static extern void PDFExport3DParamsSwigImpl_setPrcRenderingMode(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_PDFExport3DParamsSwigImpl__SWIG_0___")]
	public static extern IntPtr new_PDFExport3DParamsSwigImpl__SWIG_0();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_PDFExport3DParamsSwigImpl__SWIG_1___")]
	public static extern IntPtr new_PDFExport3DParamsSwigImpl__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_setPRCMode___")]
	public static extern void PDFExport3DParamsSwigImpl_setPRCMode(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_setPRCModeSwigExplicitPDFExport3DParamsSwigImpl___")]
	public static extern void PDFExport3DParamsSwigImpl_setPRCModeSwigExplicitPDFExport3DParamsSwigImpl(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_getPRCMode___")]
	public static extern int PDFExport3DParamsSwigImpl_getPRCMode(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_getPRCContext___")]
	public static extern IntPtr PDFExport3DParamsSwigImpl_getPRCContext(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_setPRCContext___")]
	public static extern void PDFExport3DParamsSwigImpl_setPRCContext(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_hasPrcBrepCompression___")]
	public static extern bool PDFExport3DParamsSwigImpl_hasPrcBrepCompression(HandleRef jarg1, out PDF3D_ENUMS_PRCCompressionLevel jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_hasPrcTessellationCompression___")]
	public static extern bool PDFExport3DParamsSwigImpl_hasPrcTessellationCompression(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_setPRCCompression___")]
	public static extern void PDFExport3DParamsSwigImpl_setPRCCompression(HandleRef jarg1, int jarg2, bool jarg3, bool jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_getPrcExportAmbientColorBehavior___")]
	public static extern int PDFExport3DParamsSwigImpl_getPrcExportAmbientColorBehavior(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_setPrcExportAmbientColorBehavior___")]
	public static extern void PDFExport3DParamsSwigImpl_setPrcExportAmbientColorBehavior(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_setDatabase___")]
	public static extern void PDFExport3DParamsSwigImpl_setDatabase(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_database___")]
	public static extern IntPtr PDFExport3DParamsSwigImpl_database(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_setSelectionSetsArray___")]
	public static extern void PDFExport3DParamsSwigImpl_setSelectionSetsArray(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_getSelectionSetsArray___")]
	public static extern IntPtr PDFExport3DParamsSwigImpl_getSelectionSetsArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_setLayouts__SWIG_0___")]
	public static extern void PDFExport3DParamsSwigImpl_setLayouts__SWIG_0(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_setLayouts__SWIG_1___")]
	public static extern void PDFExport3DParamsSwigImpl_setLayouts__SWIG_1(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_addLayout___")]
	public static extern void PDFExport3DParamsSwigImpl_addLayout(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_layouts___")]
	public static extern IntPtr PDFExport3DParamsSwigImpl_layouts(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_databases___")]
	public static extern IntPtr PDFExport3DParamsSwigImpl_databases(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_clearMultipleDbSettings___")]
	public static extern void PDFExport3DParamsSwigImpl_clearMultipleDbSettings(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_PDFExport3DParamsSwigImpl___")]
	public static extern void delete_PDFExport3DParamsSwigImpl(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_director_connect___")]
	public static extern void PDFExport3DParamsSwigImpl_director_connect(HandleRef jarg1, PDFExport3DParamsSwigImpl.SwigDelegatePDFExport3DParamsSwigImpl_0 delegate0);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_PDFExportDocumentParamsSwigImpl___")]
	public static extern void delete_PDFExportDocumentParamsSwigImpl(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_setVersion___")]
	public static extern void PDFExportDocumentParamsSwigImpl_setVersion(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_version___")]
	public static extern int PDFExportDocumentParamsSwigImpl_version(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_setArchived___")]
	public static extern void PDFExportDocumentParamsSwigImpl_setArchived(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_archived___")]
	public static extern int PDFExportDocumentParamsSwigImpl_archived(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_setPageParams___")]
	public static extern void PDFExportDocumentParamsSwigImpl_setPageParams(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_pageParams___")]
	public static extern IntPtr PDFExportDocumentParamsSwigImpl_pageParams(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_setTitle___")]
	public static extern void PDFExportDocumentParamsSwigImpl_setTitle(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_title___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string PDFExportDocumentParamsSwigImpl_title(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_setAuthor___")]
	public static extern void PDFExportDocumentParamsSwigImpl_setAuthor(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_author___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string PDFExportDocumentParamsSwigImpl_author(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_setSubject___")]
	public static extern void PDFExportDocumentParamsSwigImpl_setSubject(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_subject___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string PDFExportDocumentParamsSwigImpl_subject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_setKeywords___")]
	public static extern void PDFExportDocumentParamsSwigImpl_setKeywords(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_keywords___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string PDFExportDocumentParamsSwigImpl_keywords(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_setCreator___")]
	public static extern void PDFExportDocumentParamsSwigImpl_setCreator(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_creator___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string PDFExportDocumentParamsSwigImpl_creator(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_setProducer___")]
	public static extern void PDFExportDocumentParamsSwigImpl_setProducer(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_producer___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string PDFExportDocumentParamsSwigImpl_producer(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_setUserPassword___")]
	public static extern void PDFExportDocumentParamsSwigImpl_setUserPassword(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_userPassword___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string PDFExportDocumentParamsSwigImpl_userPassword(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_setOwnerPassword___")]
	public static extern void PDFExportDocumentParamsSwigImpl_setOwnerPassword(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_ownerPassword___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string PDFExportDocumentParamsSwigImpl_ownerPassword(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_setAccessPermissionFlags___")]
	public static extern void PDFExportDocumentParamsSwigImpl_setAccessPermissionFlags(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_accessPermissionFlags___")]
	public static extern int PDFExportDocumentParamsSwigImpl_accessPermissionFlags(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_addWatermark___")]
	public static extern void PDFExportDocumentParamsSwigImpl_addWatermark(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_watermarks___")]
	public static extern IntPtr PDFExportDocumentParamsSwigImpl_watermarks(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_clearWatermarks___")]
	public static extern void PDFExportDocumentParamsSwigImpl_clearWatermarks(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_PDFExportDocumentParamsSwigImpl___")]
	public static extern IntPtr new_PDFExportDocumentParamsSwigImpl();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_director_connect___")]
	public static extern void PDFExportDocumentParamsSwigImpl_director_connect(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_PDFExport2DParamsSwigImpl__SWIG_0___")]
	public static extern IntPtr new_PDFExport2DParamsSwigImpl__SWIG_0();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_PDFExport2DParamsSwigImpl___")]
	public static extern void delete_PDFExport2DParamsSwigImpl(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setExportFlags___")]
	public static extern void PDFExport2DParamsSwigImpl_setExportFlags(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_exportFlags___")]
	public static extern int PDFExport2DParamsSwigImpl_exportFlags(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setSearchableTextType___")]
	public static extern void PDFExport2DParamsSwigImpl_setSearchableTextType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_searchableTextType___")]
	public static extern int PDFExport2DParamsSwigImpl_searchableTextType(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setColorPolicy___")]
	public static extern void PDFExport2DParamsSwigImpl_setColorPolicy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_colorPolicy___")]
	public static extern int PDFExport2DParamsSwigImpl_colorPolicy(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setBackground___")]
	public static extern void PDFExport2DParamsSwigImpl_setBackground(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_background___")]
	public static extern uint PDFExport2DParamsSwigImpl_background(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setPalette___")]
	public static extern void PDFExport2DParamsSwigImpl_setPalette(HandleRef jarg1, [In][MarshalAs(UnmanagedType.LPArray)] uint[] jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_palette___")]
	public static extern IntPtr PDFExport2DParamsSwigImpl_palette(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setGeomDPI___")]
	public static extern void PDFExport2DParamsSwigImpl_setGeomDPI(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_getGeomDPI___")]
	public static extern ushort PDFExport2DParamsSwigImpl_getGeomDPI(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setHatchDPI___")]
	public static extern void PDFExport2DParamsSwigImpl_setHatchDPI(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_hatchDPI___")]
	public static extern ushort PDFExport2DParamsSwigImpl_hatchDPI(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setColorImagesDPI___")]
	public static extern void PDFExport2DParamsSwigImpl_setColorImagesDPI(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_colorImagesDPI___")]
	public static extern ushort PDFExport2DParamsSwigImpl_colorImagesDPI(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setBWImagesDPI___")]
	public static extern void PDFExport2DParamsSwigImpl_setBWImagesDPI(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_bwImagesDPI___")]
	public static extern ushort PDFExport2DParamsSwigImpl_bwImagesDPI(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setSolidHatchesExportType___")]
	public static extern void PDFExport2DParamsSwigImpl_setSolidHatchesExportType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_solidHatchesExportType___")]
	public static extern int PDFExport2DParamsSwigImpl_solidHatchesExportType(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setGradientHatchesExportType___")]
	public static extern void PDFExport2DParamsSwigImpl_setGradientHatchesExportType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_gradientHatchesExportType___")]
	public static extern int PDFExport2DParamsSwigImpl_gradientHatchesExportType(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setOtherHatchesExportType___")]
	public static extern void PDFExport2DParamsSwigImpl_setOtherHatchesExportType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_otherHatchesExportType___")]
	public static extern int PDFExport2DParamsSwigImpl_otherHatchesExportType(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_imageCropping___")]
	public static extern bool PDFExport2DParamsSwigImpl_imageCropping(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setImageCropping___")]
	public static extern void PDFExport2DParamsSwigImpl_setImageCropping(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_dctQuality___")]
	public static extern ushort PDFExport2DParamsSwigImpl_dctQuality(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setDCTQuality___")]
	public static extern void PDFExport2DParamsSwigImpl_setDCTQuality(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_monoImagesAsMask___")]
	public static extern bool PDFExport2DParamsSwigImpl_monoImagesAsMask(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setMonoImagesAsMask___")]
	public static extern void PDFExport2DParamsSwigImpl_setMonoImagesAsMask(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_get720DPIMode___")]
	public static extern bool PDFExport2DParamsSwigImpl_get720DPIMode(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_set720DPIMode___")]
	public static extern void PDFExport2DParamsSwigImpl_set720DPIMode(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_useViewExtents___")]
	public static extern bool PDFExport2DParamsSwigImpl_useViewExtents(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setUseViewExtents___")]
	public static extern void PDFExport2DParamsSwigImpl_setUseViewExtents(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_dctCompression___")]
	public static extern bool PDFExport2DParamsSwigImpl_dctCompression(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setDCTCompression___")]
	public static extern void PDFExport2DParamsSwigImpl_setDCTCompression(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_dctCompressionShadedViewports___")]
	public static extern bool PDFExport2DParamsSwigImpl_dctCompressionShadedViewports(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setDCTCompressionShadedViewports___")]
	public static extern void PDFExport2DParamsSwigImpl_setDCTCompressionShadedViewports(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_upscaleImages___")]
	public static extern bool PDFExport2DParamsSwigImpl_upscaleImages(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setUpscaleImages___")]
	public static extern void PDFExport2DParamsSwigImpl_setUpscaleImages(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setTransparentShadedVpBg___")]
	public static extern void PDFExport2DParamsSwigImpl_setTransparentShadedVpBg(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_transparentShadedVpBg___")]
	public static extern bool PDFExport2DParamsSwigImpl_transparentShadedVpBg(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setForceDisableGsDevice___")]
	public static extern void PDFExport2DParamsSwigImpl_setForceDisableGsDevice(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_forceDisableGsDevice___")]
	public static extern bool PDFExport2DParamsSwigImpl_forceDisableGsDevice(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setShadedVpExportMode___")]
	public static extern void PDFExport2DParamsSwigImpl_setShadedVpExportMode(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_shadedVpExportMode___")]
	public static extern int PDFExport2DParamsSwigImpl_shadedVpExportMode(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_export2XObject___")]
	public static extern bool PDFExport2DParamsSwigImpl_export2XObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_useGsCache___")]
	public static extern bool PDFExport2DParamsSwigImpl_useGsCache(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setUseGsCache___")]
	public static extern void PDFExport2DParamsSwigImpl_setUseGsCache(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_isParallelVectorization___")]
	public static extern bool PDFExport2DParamsSwigImpl_isParallelVectorization(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setParallelVectorization___")]
	public static extern void PDFExport2DParamsSwigImpl_setParallelVectorization(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setUsePdfBlocks___")]
	public static extern void PDFExport2DParamsSwigImpl_setUsePdfBlocks(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_isUsePdfBlocks___")]
	public static extern bool PDFExport2DParamsSwigImpl_isUsePdfBlocks(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setXrefsAsPdfBlocks___")]
	public static extern void PDFExport2DParamsSwigImpl_setXrefsAsPdfBlocks(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_isXrefsAsPdfBlocks___")]
	public static extern bool PDFExport2DParamsSwigImpl_isXrefsAsPdfBlocks(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_searchableTextAsHiddenText___")]
	public static extern bool PDFExport2DParamsSwigImpl_searchableTextAsHiddenText(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_searchableTextInRenderedViews___")]
	public static extern bool PDFExport2DParamsSwigImpl_searchableTextInRenderedViews(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setSearchableTextAsHiddenText___")]
	public static extern void PDFExport2DParamsSwigImpl_setSearchableTextAsHiddenText(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setSearchableTextInRenderedViews___")]
	public static extern void PDFExport2DParamsSwigImpl_setSearchableTextInRenderedViews(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_isTTFTextAsGeometry___")]
	public static extern bool PDFExport2DParamsSwigImpl_isTTFTextAsGeometry(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_isSHXTextAsGeometry___")]
	public static extern bool PDFExport2DParamsSwigImpl_isSHXTextAsGeometry(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_enableBookmarks___")]
	public static extern void PDFExport2DParamsSwigImpl_enableBookmarks(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_bookmarksEnabled___")]
	public static extern bool PDFExport2DParamsSwigImpl_bookmarksEnabled(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_layoutNames___")]
	public static extern IntPtr PDFExport2DParamsSwigImpl_layoutNames(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setLayoutNames___")]
	public static extern void PDFExport2DParamsSwigImpl_setLayoutNames(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setMeasuringType___")]
	public static extern void PDFExport2DParamsSwigImpl_setMeasuringType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_measuringType___")]
	public static extern int PDFExport2DParamsSwigImpl_measuringType(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_PDFExport2DParamsSwigImpl__SWIG_1___")]
	public static extern IntPtr new_PDFExport2DParamsSwigImpl__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setDatabase___")]
	public static extern void PDFExport2DParamsSwigImpl_setDatabase(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_database___")]
	public static extern IntPtr PDFExport2DParamsSwigImpl_database(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setSelectionSetsArray___")]
	public static extern void PDFExport2DParamsSwigImpl_setSelectionSetsArray(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_getSelectionSetsArray___")]
	public static extern IntPtr PDFExport2DParamsSwigImpl_getSelectionSetsArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setLayouts__SWIG_0___")]
	public static extern void PDFExport2DParamsSwigImpl_setLayouts__SWIG_0(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_setLayouts__SWIG_1___")]
	public static extern void PDFExport2DParamsSwigImpl_setLayouts__SWIG_1(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_addLayout___")]
	public static extern void PDFExport2DParamsSwigImpl_addLayout(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_layouts___")]
	public static extern IntPtr PDFExport2DParamsSwigImpl_layouts(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_databases___")]
	public static extern IntPtr PDFExport2DParamsSwigImpl_databases(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_clearMultipleDbSettings___")]
	public static extern void PDFExport2DParamsSwigImpl_clearMultipleDbSettings(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_director_connect___")]
	public static extern void PDFExport2DParamsSwigImpl_director_connect(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_TD_PDF_2D_EXPORT_PDFExportParams___")]
	public static extern IntPtr new_TD_PDF_2D_EXPORT_PDFExportParams();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_TD_PDF_2D_EXPORT_PDFExportParams___")]
	public static extern void delete_TD_PDF_2D_EXPORT_PDFExportParams(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setOutput___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setOutput(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_output___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_output(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_exportReactor___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_exportReactor(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setExportReactor___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setExportReactor(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setPRCMode___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setPRCMode(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setStopOnError___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setStopOnError(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_stopOnError___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_stopOnError(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setVersion___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setVersion(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_version___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_version(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setArchived___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setArchived(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_archived___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_archived(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setPageParams___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setPageParams(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_pageParams___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_pageParams(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setTitle___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setTitle(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_title___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_2D_EXPORT_PDFExportParams_title(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setAuthor___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setAuthor(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_author___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_2D_EXPORT_PDFExportParams_author(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setSubject___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setSubject(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_subject___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_2D_EXPORT_PDFExportParams_subject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setKeywords___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setKeywords(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_keywords___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_2D_EXPORT_PDFExportParams_keywords(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setCreator___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setCreator(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_creator___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_2D_EXPORT_PDFExportParams_creator(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setProducer___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setProducer(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_producer___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_2D_EXPORT_PDFExportParams_producer(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setUserPassword___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setUserPassword(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_userPassword___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_2D_EXPORT_PDFExportParams_userPassword(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setOwnerPassword___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setOwnerPassword(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_ownerPassword___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_2D_EXPORT_PDFExportParams_ownerPassword(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setAccessPermissionFlags___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setAccessPermissionFlags(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_accessPermissionFlags___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_accessPermissionFlags(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_addWatermark___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_addWatermark(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_watermarks___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_watermarks(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_clearWatermarks___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_clearWatermarks(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setExportFlags___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setExportFlags(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_exportFlags___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_exportFlags(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setSearchableTextType___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setSearchableTextType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_searchableTextType___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_searchableTextType(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setColorPolicy___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setColorPolicy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_colorPolicy___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_colorPolicy(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setBackground___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setBackground(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_background___")]
	public static extern uint TD_PDF_2D_EXPORT_PDFExportParams_background(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setPalette___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setPalette(HandleRef jarg1, [In][MarshalAs(UnmanagedType.LPArray)] uint[] jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_palette___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_palette(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setGeomDPI___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setGeomDPI(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_getGeomDPI___")]
	public static extern ushort TD_PDF_2D_EXPORT_PDFExportParams_getGeomDPI(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setHatchDPI___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setHatchDPI(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_hatchDPI___")]
	public static extern ushort TD_PDF_2D_EXPORT_PDFExportParams_hatchDPI(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setColorImagesDPI___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setColorImagesDPI(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_colorImagesDPI___")]
	public static extern ushort TD_PDF_2D_EXPORT_PDFExportParams_colorImagesDPI(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setBWImagesDPI___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setBWImagesDPI(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_bwImagesDPI___")]
	public static extern ushort TD_PDF_2D_EXPORT_PDFExportParams_bwImagesDPI(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setSolidHatchesExportType___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setSolidHatchesExportType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_solidHatchesExportType___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_solidHatchesExportType(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setGradientHatchesExportType___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setGradientHatchesExportType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_gradientHatchesExportType___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_gradientHatchesExportType(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setOtherHatchesExportType___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setOtherHatchesExportType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_otherHatchesExportType___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_otherHatchesExportType(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_imageCropping___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_imageCropping(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setImageCropping___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setImageCropping(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_dctQuality___")]
	public static extern ushort TD_PDF_2D_EXPORT_PDFExportParams_dctQuality(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setDCTQuality___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setDCTQuality(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_monoImagesAsMask___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_monoImagesAsMask(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setMonoImagesAsMask___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setMonoImagesAsMask(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_get720DPIMode___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_get720DPIMode(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_set720DPIMode___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_set720DPIMode(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_useViewExtents___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_useViewExtents(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setUseViewExtents___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setUseViewExtents(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_dctCompression___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_dctCompression(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setDCTCompression___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setDCTCompression(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_dctCompressionShadedViewports___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_dctCompressionShadedViewports(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setDCTCompressionShadedViewports___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setDCTCompressionShadedViewports(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_upscaleImages___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_upscaleImages(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setUpscaleImages___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setUpscaleImages(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setTransparentShadedVpBg___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setTransparentShadedVpBg(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_transparentShadedVpBg___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_transparentShadedVpBg(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setForceDisableGsDevice___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setForceDisableGsDevice(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_forceDisableGsDevice___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_forceDisableGsDevice(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setShadedVpExportMode___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setShadedVpExportMode(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_shadedVpExportMode___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_shadedVpExportMode(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_export2XObject___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_export2XObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_useGsCache___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_useGsCache(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setUseGsCache___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setUseGsCache(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_isParallelVectorization___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_isParallelVectorization(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setParallelVectorization___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setParallelVectorization(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setUsePdfBlocks___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setUsePdfBlocks(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_isUsePdfBlocks___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_isUsePdfBlocks(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setXrefsAsPdfBlocks___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setXrefsAsPdfBlocks(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_isXrefsAsPdfBlocks___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_isXrefsAsPdfBlocks(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_searchableTextAsHiddenText___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_searchableTextAsHiddenText(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_searchableTextInRenderedViews___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_searchableTextInRenderedViews(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setSearchableTextAsHiddenText___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setSearchableTextAsHiddenText(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setSearchableTextInRenderedViews___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setSearchableTextInRenderedViews(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_isTTFTextAsGeometry___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_isTTFTextAsGeometry(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_isSHXTextAsGeometry___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_isSHXTextAsGeometry(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_enableBookmarks___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_enableBookmarks(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_bookmarksEnabled___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_bookmarksEnabled(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_layoutNames___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_layoutNames(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setLayoutNames___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setLayoutNames(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setMeasuringType___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setMeasuringType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_measuringType___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_measuringType(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_hasPrcBackground___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_hasPrcBackground(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_getPrcBackground___")]
	public static extern uint TD_PDF_2D_EXPORT_PDFExportParams_getPrcBackground(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setPrcBackground___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setPrcBackground(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_clearPrcBackground___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_clearPrcBackground(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_getPrcRenderingMode___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_getPrcRenderingMode(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setPrcRenderingMode___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setPrcRenderingMode(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_getPRCMode___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_getPRCMode(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_getPRCContext___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_getPRCContext(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setPRCContext___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setPRCContext(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_hasPrcBrepCompression___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_hasPrcBrepCompression(HandleRef jarg1, out PDF3D_ENUMS_PRCCompressionLevel jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_hasPrcTessellationCompression___")]
	public static extern bool TD_PDF_2D_EXPORT_PDFExportParams_hasPrcTessellationCompression(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setPRCCompression___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setPRCCompression(HandleRef jarg1, int jarg2, bool jarg3, bool jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_getPrcExportAmbientColorBehavior___")]
	public static extern int TD_PDF_2D_EXPORT_PDFExportParams_getPrcExportAmbientColorBehavior(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setPrcExportAmbientColorBehavior___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setPrcExportAmbientColorBehavior(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setDatabase___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setDatabase(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_database___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_database(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setSelectionSetsArray___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setSelectionSetsArray(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_getSelectionSetsArray___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_getSelectionSetsArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setLayouts__SWIG_0___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setLayouts__SWIG_0(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_setLayouts__SWIG_1___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_setLayouts__SWIG_1(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_addLayout___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_addLayout(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_layouts___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_layouts(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_databases___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_databases(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_clearMultipleDbSettings___")]
	public static extern void TD_PDF_2D_EXPORT_PDFExportParams_clearMultipleDbSettings(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_extraOptions_set___")]
	public static extern void PDF2PRCExportParams_m_extraOptions_set(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_extraOptions_get___")]
	public static extern IntPtr PDF2PRCExportParams_m_extraOptions_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_compressionLevel_set___")]
	public static extern void PDF2PRCExportParams_m_compressionLevel_set(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_compressionLevel_get___")]
	public static extern uint PDF2PRCExportParams_m_compressionLevel_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_bodyTransformationMatr_set___")]
	public static extern void PDF2PRCExportParams_m_bodyTransformationMatr_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_bodyTransformationMatr_get___")]
	public static extern IntPtr PDF2PRCExportParams_m_bodyTransformationMatr_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_arrDeviation_set___")]
	public static extern void PDF2PRCExportParams_m_arrDeviation_set(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_arrDeviation_get___")]
	public static extern IntPtr PDF2PRCExportParams_m_arrDeviation_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_exportAsBrep_set___")]
	public static extern void PDF2PRCExportParams_m_exportAsBrep_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_exportAsBrep_get___")]
	public static extern bool PDF2PRCExportParams_m_exportAsBrep_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_viewportIdx_set___")]
	public static extern void PDF2PRCExportParams_m_viewportIdx_set(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_viewportIdx_get___")]
	public static extern uint PDF2PRCExportParams_m_viewportIdx_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_viewIdx_set___")]
	public static extern void PDF2PRCExportParams_m_viewIdx_set(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_viewIdx_get___")]
	public static extern uint PDF2PRCExportParams_m_viewIdx_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_pTraitsData_set___")]
	public static extern void PDF2PRCExportParams_m_pTraitsData_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_pTraitsData_get___")]
	public static extern IntPtr PDF2PRCExportParams_m_pTraitsData_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_pByBlockTraitsData_set___")]
	public static extern void PDF2PRCExportParams_m_pByBlockTraitsData_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_pByBlockTraitsData_get___")]
	public static extern IntPtr PDF2PRCExportParams_m_pByBlockTraitsData_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_ExportAmbientColorBehavior_set___")]
	public static extern void PDF2PRCExportParams_m_ExportAmbientColorBehavior_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_m_ExportAmbientColorBehavior_get___")]
	public static extern int PDF2PRCExportParams_m_ExportAmbientColorBehavior_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_PDF2PRCExportParams___")]
	public static extern IntPtr new_PDF2PRCExportParams();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_setPRCCompression___")]
	public static extern void PDF2PRCExportParams_setPRCCompression(HandleRef jarg1, int jarg2, bool jarg3, bool jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_hasPrcBrepCompression___")]
	public static extern bool PDF2PRCExportParams_hasPrcBrepCompression(HandleRef jarg1, out PDF3D_ENUMS_PRCCompressionLevel jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDF2PRCExportParams_hasPrcTessellationCompression___")]
	public static extern bool PDF2PRCExportParams_hasPrcTessellationCompression(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_PDF2PRCExportParams___")]
	public static extern void delete_PDF2PRCExportParams(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_ShellDrawable_numVertices___")]
	public static extern int ShellDrawable_numVertices(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_ShellDrawable_vertexList___")]
	public static extern IntPtr ShellDrawable_vertexList(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_ShellDrawable_faceListSize___")]
	public static extern int ShellDrawable_faceListSize(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_ShellDrawable_faceList___")]
	public static extern int ShellDrawable_faceList(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_ShellDrawable_edgeData___")]
	public static extern EdgeData ShellDrawable_edgeData(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_ShellDrawable_faceData___")]
	public static extern IntPtr ShellDrawable_faceData(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_ShellDrawable___")]
	public static extern void delete_ShellDrawable(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_TD_PDF_2D_EXPORT_PdfExportParamsForXObject___")]
	public static extern IntPtr new_TD_PDF_2D_EXPORT_PdfExportParamsForXObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_pCurrentPage_set___")]
	public static extern void TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_pCurrentPage_set(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_pCurrentPage_get___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_pCurrentPage_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_pXobjectForm_set___")]
	public static extern void TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_pXobjectForm_set(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_pXobjectForm_get___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_pXobjectForm_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_FontOptimizer_set___")]
	public static extern void TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_FontOptimizer_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_FontOptimizer_get___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_FontOptimizer_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_BookmarkNames_set___")]
	public static extern void TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_BookmarkNames_set(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_BookmarkNames_get___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_BookmarkNames_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_BookmarkPoints_set___")]
	public static extern void TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_BookmarkPoints_set(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_BookmarkPoints_get___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PdfExportParamsForXObject_m_BookmarkPoints_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_TD_PDF_2D_EXPORT_PdfExportParamsForXObject___")]
	public static extern void delete_TD_PDF_2D_EXPORT_PdfExportParamsForXObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportServiceInterface_cast___")]
	public static extern IntPtr PdfExportServiceInterface_cast(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportServiceInterface_desc___")]
	public static extern IntPtr PdfExportServiceInterface_desc();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportServiceInterface_isA___")]
	public static extern IntPtr PdfExportServiceInterface_isA(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportServiceInterface_isASwigExplicitPdfExportServiceInterface___")]
	public static extern IntPtr PdfExportServiceInterface_isASwigExplicitPdfExportServiceInterface(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportServiceInterface_queryX___")]
	public static extern IntPtr PdfExportServiceInterface_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportServiceInterface_queryXSwigExplicitPdfExportServiceInterface___")]
	public static extern IntPtr PdfExportServiceInterface_queryXSwigExplicitPdfExportServiceInterface(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportServiceInterface_createObject___")]
	public static extern IntPtr PdfExportServiceInterface_createObject();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportServiceInterface_createPrcExportContext___")]
	public static extern IntPtr PdfExportServiceInterface_createPrcExportContext(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportServiceInterface_serialize___")]
	public static extern int PdfExportServiceInterface_serialize(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_PdfExportServiceInterface___")]
	public static extern void delete_PdfExportServiceInterface(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportServiceInterface_getRealClassName___")]
	public static extern string PdfExportServiceInterface_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportServiceInterface_ExportPrc___")]
	public static extern int PdfExportServiceInterface_ExportPrc(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_PdfExportServiceInterface___")]
	public static extern IntPtr new_PdfExportServiceInterface();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportServiceInterface_director_connect___")]
	public static extern void PdfExportServiceInterface_director_connect(HandleRef jarg1, PdfExportServiceInterface.SwigDelegatePdfExportServiceInterface_0 delegate0, PdfExportServiceInterface.SwigDelegatePdfExportServiceInterface_1 delegate1, PdfExportServiceInterface.SwigDelegatePdfExportServiceInterface_2 delegate2, PdfExportServiceInterface.SwigDelegatePdfExportServiceInterface_3 delegate3, PdfExportServiceInterface.SwigDelegatePdfExportServiceInterface_4 delegate4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_getPdfExportService___")]
	public static extern IntPtr getPdfExportService();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_cast___")]
	public static extern IntPtr PdfExportGiDrawablePE_cast(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_desc___")]
	public static extern IntPtr PdfExportGiDrawablePE_desc();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_isA___")]
	public static extern IntPtr PdfExportGiDrawablePE_isA(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_isASwigExplicitPdfExportGiDrawablePE___")]
	public static extern IntPtr PdfExportGiDrawablePE_isASwigExplicitPdfExportGiDrawablePE(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_queryX___")]
	public static extern IntPtr PdfExportGiDrawablePE_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_queryXSwigExplicitPdfExportGiDrawablePE___")]
	public static extern IntPtr PdfExportGiDrawablePE_queryXSwigExplicitPdfExportGiDrawablePE(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_drawableToPRC__SWIG_0___")]
	public static extern int PdfExportGiDrawablePE_drawableToPRC__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_drawableToPRCSwigExplicitPdfExportGiDrawablePE__SWIG_0___")]
	public static extern int PdfExportGiDrawablePE_drawableToPRCSwigExplicitPdfExportGiDrawablePE__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_drawableToPRC__SWIG_1___")]
	public static extern int PdfExportGiDrawablePE_drawableToPRC__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4, HandleRef jarg5, HandleRef jarg6, bool jarg7);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_drawableToPRCSwigExplicitPdfExportGiDrawablePE__SWIG_1___")]
	public static extern int PdfExportGiDrawablePE_drawableToPRCSwigExplicitPdfExportGiDrawablePE__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4, HandleRef jarg5, HandleRef jarg6, bool jarg7);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_getColor___")]
	public static extern IntPtr PdfExportGiDrawablePE_getColor(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_getColorSwigExplicitPdfExportGiDrawablePE___")]
	public static extern IntPtr PdfExportGiDrawablePE_getColorSwigExplicitPdfExportGiDrawablePE(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_getMaterial___")]
	public static extern IntPtr PdfExportGiDrawablePE_getMaterial(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_getMaterialSwigExplicitPdfExportGiDrawablePE___")]
	public static extern IntPtr PdfExportGiDrawablePE_getMaterialSwigExplicitPdfExportGiDrawablePE(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_getTransparency___")]
	public static extern IntPtr PdfExportGiDrawablePE_getTransparency(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_getTransparencySwigExplicitPdfExportGiDrawablePE___")]
	public static extern IntPtr PdfExportGiDrawablePE_getTransparencySwigExplicitPdfExportGiDrawablePE(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_getRealClassName___")]
	public static extern string PdfExportGiDrawablePE_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_createObject___")]
	public static extern IntPtr PdfExportGiDrawablePE_createObject();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_PdfExportGiDrawablePE___")]
	public static extern IntPtr new_PdfExportGiDrawablePE();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_PdfExportGiDrawablePE___")]
	public static extern void delete_PdfExportGiDrawablePE(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_director_connect___")]
	public static extern void PdfExportGiDrawablePE_director_connect(HandleRef jarg1, PdfExportGiDrawablePE.SwigDelegatePdfExportGiDrawablePE_0 delegate0, PdfExportGiDrawablePE.SwigDelegatePdfExportGiDrawablePE_1 delegate1, PdfExportGiDrawablePE.SwigDelegatePdfExportGiDrawablePE_2 delegate2, PdfExportGiDrawablePE.SwigDelegatePdfExportGiDrawablePE_3 delegate3, PdfExportGiDrawablePE.SwigDelegatePdfExportGiDrawablePE_4 delegate4, PdfExportGiDrawablePE.SwigDelegatePdfExportGiDrawablePE_5 delegate5, PdfExportGiDrawablePE.SwigDelegatePdfExportGiDrawablePE_6 delegate6, PdfExportGiDrawablePE.SwigDelegatePdfExportGiDrawablePE_7 delegate7);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_cast___")]
	public static extern IntPtr PdfExportLayerPE_cast(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_desc___")]
	public static extern IntPtr PdfExportLayerPE_desc();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_isA___")]
	public static extern IntPtr PdfExportLayerPE_isA(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_isASwigExplicitPdfExportLayerPE___")]
	public static extern IntPtr PdfExportLayerPE_isASwigExplicitPdfExportLayerPE(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_queryX___")]
	public static extern IntPtr PdfExportLayerPE_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_queryXSwigExplicitPdfExportLayerPE___")]
	public static extern IntPtr PdfExportLayerPE_queryXSwigExplicitPdfExportLayerPE(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_getColor___")]
	public static extern IntPtr PdfExportLayerPE_getColor(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_getColorSwigExplicitPdfExportLayerPE___")]
	public static extern IntPtr PdfExportLayerPE_getColorSwigExplicitPdfExportLayerPE(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_getMaterial___")]
	public static extern IntPtr PdfExportLayerPE_getMaterial(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_getMaterialSwigExplicitPdfExportLayerPE___")]
	public static extern IntPtr PdfExportLayerPE_getMaterialSwigExplicitPdfExportLayerPE(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_getTransparency___")]
	public static extern IntPtr PdfExportLayerPE_getTransparency(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_getTransparencySwigExplicitPdfExportLayerPE___")]
	public static extern IntPtr PdfExportLayerPE_getTransparencySwigExplicitPdfExportLayerPE(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_getRealClassName___")]
	public static extern string PdfExportLayerPE_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_createObject___")]
	public static extern IntPtr PdfExportLayerPE_createObject();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_PdfExportLayerPE___")]
	public static extern IntPtr new_PdfExportLayerPE();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_PdfExportLayerPE___")]
	public static extern void delete_PdfExportLayerPE(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_director_connect___")]
	public static extern void PdfExportLayerPE_director_connect(HandleRef jarg1, PdfExportLayerPE.SwigDelegatePdfExportLayerPE_0 delegate0, PdfExportLayerPE.SwigDelegatePdfExportLayerPE_1 delegate1, PdfExportLayerPE.SwigDelegatePdfExportLayerPE_2 delegate2, PdfExportLayerPE.SwigDelegatePdfExportLayerPE_3 delegate3, PdfExportLayerPE.SwigDelegatePdfExportLayerPE_4 delegate4, PdfExportLayerPE.SwigDelegatePdfExportLayerPE_5 delegate5);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_cast___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExportPE_cast(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_desc___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExportPE_desc();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_isA___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExportPE_isA(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_isASwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExportPE_isASwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_queryX___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExportPE_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_queryXSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExportPE_queryXSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_createObject___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExportPE_createObject();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_createGiContext___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExportPE_createGiContext(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_createAuxDrawables___")]
	public static extern void TD_PDF_2D_EXPORT_OdPdfExportPE_createAuxDrawables(HandleRef jarg1, ref IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_filterDrawables___")]
	public static extern void TD_PDF_2D_EXPORT_OdPdfExportPE_filterDrawables(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_onBeginPage___")]
	public static extern bool TD_PDF_2D_EXPORT_OdPdfExportPE_onBeginPage(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, uint jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_onBeginPageSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE___")]
	public static extern bool TD_PDF_2D_EXPORT_OdPdfExportPE_onBeginPageSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, uint jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_onEndPage___")]
	public static extern void TD_PDF_2D_EXPORT_OdPdfExportPE_onEndPage(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, uint jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_onEndPageSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE___")]
	public static extern void TD_PDF_2D_EXPORT_OdPdfExportPE_onEndPageSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, uint jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_addDrawables___")]
	public static extern void TD_PDF_2D_EXPORT_OdPdfExportPE_addDrawables(HandleRef jarg1, IntPtr jarg2, HandleRef jarg3, HandleRef jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_addDrawablesSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE___")]
	public static extern void TD_PDF_2D_EXPORT_OdPdfExportPE_addDrawablesSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(HandleRef jarg1, IntPtr jarg2, HandleRef jarg3, HandleRef jarg4);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_evaluateFields___")]
	public static extern void TD_PDF_2D_EXPORT_OdPdfExportPE_evaluateFields(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_evaluateFieldsSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE___")]
	public static extern void TD_PDF_2D_EXPORT_OdPdfExportPE_evaluateFieldsSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_gsBitmapDevices___")]
	public static extern int TD_PDF_2D_EXPORT_OdPdfExportPE_gsBitmapDevices(HandleRef jarg1, IntPtr jarg2, HandleRef jarg3, uint jarg4, HandleRef jarg5);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_gsBitmapDevicesSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE___")]
	public static extern int TD_PDF_2D_EXPORT_OdPdfExportPE_gsBitmapDevicesSwigExplicitTD_PDF_2D_EXPORT_OdPdfExportPE(HandleRef jarg1, IntPtr jarg2, HandleRef jarg3, uint jarg4, HandleRef jarg5);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_getRealClassName___")]
	public static extern string TD_PDF_2D_EXPORT_OdPdfExportPE_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_TD_PDF_2D_EXPORT_OdPdfExportPE___")]
	public static extern IntPtr new_TD_PDF_2D_EXPORT_OdPdfExportPE();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_TD_PDF_2D_EXPORT_OdPdfExportPE___")]
	public static extern void delete_TD_PDF_2D_EXPORT_OdPdfExportPE(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_director_connect___")]
	public static extern void TD_PDF_2D_EXPORT_OdPdfExportPE_director_connect(HandleRef jarg1, TD_PDF_2D_EXPORT_OdPdfExportPE.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_0 delegate0, TD_PDF_2D_EXPORT_OdPdfExportPE.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_1 delegate1, TD_PDF_2D_EXPORT_OdPdfExportPE.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_2 delegate2, TD_PDF_2D_EXPORT_OdPdfExportPE.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_3 delegate3, TD_PDF_2D_EXPORT_OdPdfExportPE.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_4 delegate4, TD_PDF_2D_EXPORT_OdPdfExportPE.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_5 delegate5, TD_PDF_2D_EXPORT_OdPdfExportPE.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_6 delegate6, TD_PDF_2D_EXPORT_OdPdfExportPE.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_7 delegate7, TD_PDF_2D_EXPORT_OdPdfExportPE.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_8 delegate8, TD_PDF_2D_EXPORT_OdPdfExportPE.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_9 delegate9, TD_PDF_2D_EXPORT_OdPdfExportPE.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExportPE_10 delegate10);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PageProcessingCallback_isValidPage___")]
	public static extern bool PageProcessingCallback_isValidPage(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_cast___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExport_cast(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_desc___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExport_desc();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_isA___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExport_isA(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_isASwigExplicitTD_PDF_2D_EXPORT_OdPdfExport___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExport_isASwigExplicitTD_PDF_2D_EXPORT_OdPdfExport(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_queryX___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExport_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_queryXSwigExplicitTD_PDF_2D_EXPORT_OdPdfExport___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExport_queryXSwigExplicitTD_PDF_2D_EXPORT_OdPdfExport(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_createObject___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExport_createObject();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_exportPdf___")]
	public static extern uint TD_PDF_2D_EXPORT_OdPdfExport_exportPdf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_exportPdfErrorCode___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_2D_EXPORT_OdPdfExport_exportPdfErrorCode(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_exportToPRCStreams___")]
	public static extern uint TD_PDF_2D_EXPORT_OdPdfExport_exportToPRCStreams(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_export2XObject___")]
	public static extern uint TD_PDF_2D_EXPORT_OdPdfExport_export2XObject(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, double jarg4, double jarg5);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_getRealClassName___")]
	public static extern string TD_PDF_2D_EXPORT_OdPdfExport_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_new_TD_PDF_2D_EXPORT_OdPdfExport___")]
	public static extern IntPtr new_TD_PDF_2D_EXPORT_OdPdfExport();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_TD_PDF_2D_EXPORT_OdPdfExport___")]
	public static extern void delete_TD_PDF_2D_EXPORT_OdPdfExport(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_director_connect___")]
	public static extern void TD_PDF_2D_EXPORT_OdPdfExport_director_connect(HandleRef jarg1, TD_PDF_2D_EXPORT_OdPdfExport.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_0 delegate0, TD_PDF_2D_EXPORT_OdPdfExport.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_1 delegate1, TD_PDF_2D_EXPORT_OdPdfExport.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_2 delegate2, TD_PDF_2D_EXPORT_OdPdfExport.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_3 delegate3, TD_PDF_2D_EXPORT_OdPdfExport.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_4 delegate4, TD_PDF_2D_EXPORT_OdPdfExport.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_5 delegate5, TD_PDF_2D_EXPORT_OdPdfExport.SwigDelegateTD_PDF_2D_EXPORT_OdPdfExport_6 delegate6);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportModule_create___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PdfExportModule_create(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportModule_getRealClassName___")]
	public static extern string TD_PDF_2D_EXPORT_PdfExportModule_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_TD_PDF_2D_EXPORT_PdfExportModule___")]
	public static extern void delete_TD_PDF_2D_EXPORT_PdfExportModule(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator__SWIG_0")]
	public static extern IntPtr new_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator__SWIG_0();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator__SWIG_1")]
	public static extern IntPtr new_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator__SWIG_2")]
	public static extern IntPtr new_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator__SWIG_2(int jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_size___")]
	public static extern uint OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_size(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_capacity___")]
	public static extern uint OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_capacity(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_reserve___")]
	public static extern void OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_resize___")]
	public static extern void OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Clear___")]
	public static extern void OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Add___")]
	public static extern void OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_getitemcopy___")]
	public static extern IntPtr OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_getitem___")]
	public static extern IntPtr OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_setitem___")]
	public static extern void OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_AddRange___")]
	public static extern void OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_GetRange___")]
	public static extern IntPtr OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Insert___")]
	public static extern void OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_InsertRange___")]
	public static extern void OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_RemoveAt___")]
	public static extern void OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_RemoveRange___")]
	public static extern void OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Repeat___")]
	public static extern IntPtr OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Reverse__SWIG_0___")]
	public static extern void OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Reverse__SWIG_1___")]
	public static extern void OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_SetRange___")]
	public static extern void OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Contains___")]
	public static extern bool OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_IndexOf___")]
	public static extern int OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_LastIndexOf___")]
	public static extern int OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Remove___")]
	public static extern bool OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator___")]
	public static extern void delete_OdArray_OdSmartPtr_OdGsDevice_OdObjectsAllocator(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator__SWIG_0")]
	public static extern IntPtr new_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator__SWIG_0();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator__SWIG_1")]
	public static extern IntPtr new_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator__SWIG_2")]
	public static extern IntPtr new_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator__SWIG_2(int jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_size___")]
	public static extern uint OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_size(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_capacity___")]
	public static extern uint OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_capacity(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_reserve___")]
	public static extern void OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_resize___")]
	public static extern void OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Clear___")]
	public static extern void OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Add___")]
	public static extern void OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_getitemcopy___")]
	public static extern IntPtr OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_getitem___")]
	public static extern IntPtr OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_setitem___")]
	public static extern void OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_AddRange___")]
	public static extern void OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_GetRange___")]
	public static extern IntPtr OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Insert___")]
	public static extern void OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_InsertRange___")]
	public static extern void OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_RemoveAt___")]
	public static extern void OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_RemoveRange___")]
	public static extern void OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Repeat___")]
	public static extern IntPtr OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Reverse__SWIG_0___")]
	public static extern void OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Reverse__SWIG_1___")]
	public static extern void OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_SetRange___")]
	public static extern void OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Contains___")]
	public static extern bool OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_IndexOf___")]
	public static extern int OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_LastIndexOf___")]
	public static extern int OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Remove___")]
	public static extern bool OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator___")]
	public static extern void delete_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_OdGsPageParams_OdObjectsAllocator__SWIG_0")]
	public static extern IntPtr new_OdArray_OdGsPageParams_OdObjectsAllocator__SWIG_0();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_OdGsPageParams_OdObjectsAllocator__SWIG_1")]
	public static extern IntPtr new_OdArray_OdGsPageParams_OdObjectsAllocator__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_OdGsPageParams_OdObjectsAllocator__SWIG_2")]
	public static extern IntPtr new_OdArray_OdGsPageParams_OdObjectsAllocator__SWIG_2(int jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_size___")]
	public static extern uint OdArray_OdGsPageParams_OdObjectsAllocator_size(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_capacity___")]
	public static extern uint OdArray_OdGsPageParams_OdObjectsAllocator_capacity(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_reserve___")]
	public static extern void OdArray_OdGsPageParams_OdObjectsAllocator_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_resize___")]
	public static extern void OdArray_OdGsPageParams_OdObjectsAllocator_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_Clear___")]
	public static extern void OdArray_OdGsPageParams_OdObjectsAllocator_Clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_Add___")]
	public static extern void OdArray_OdGsPageParams_OdObjectsAllocator_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_getitemcopy___")]
	public static extern IntPtr OdArray_OdGsPageParams_OdObjectsAllocator_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_getitem___")]
	public static extern IntPtr OdArray_OdGsPageParams_OdObjectsAllocator_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_setitem___")]
	public static extern void OdArray_OdGsPageParams_OdObjectsAllocator_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_AddRange___")]
	public static extern void OdArray_OdGsPageParams_OdObjectsAllocator_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_GetRange___")]
	public static extern IntPtr OdArray_OdGsPageParams_OdObjectsAllocator_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_Insert___")]
	public static extern void OdArray_OdGsPageParams_OdObjectsAllocator_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_InsertRange___")]
	public static extern void OdArray_OdGsPageParams_OdObjectsAllocator_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_RemoveAt___")]
	public static extern void OdArray_OdGsPageParams_OdObjectsAllocator_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_RemoveRange___")]
	public static extern void OdArray_OdGsPageParams_OdObjectsAllocator_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_Repeat___")]
	public static extern IntPtr OdArray_OdGsPageParams_OdObjectsAllocator_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_Reverse__SWIG_0___")]
	public static extern void OdArray_OdGsPageParams_OdObjectsAllocator_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_Reverse__SWIG_1___")]
	public static extern void OdArray_OdGsPageParams_OdObjectsAllocator_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_SetRange___")]
	public static extern void OdArray_OdGsPageParams_OdObjectsAllocator_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_Contains___")]
	public static extern bool OdArray_OdGsPageParams_OdObjectsAllocator_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_IndexOf___")]
	public static extern int OdArray_OdGsPageParams_OdObjectsAllocator_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_LastIndexOf___")]
	public static extern int OdArray_OdGsPageParams_OdObjectsAllocator_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_OdGsPageParams_OdObjectsAllocator_Remove___")]
	public static extern bool OdArray_OdGsPageParams_OdObjectsAllocator_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_OdArray_OdGsPageParams_OdObjectsAllocator___")]
	public static extern void delete_OdArray_OdGsPageParams_OdObjectsAllocator(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator__SWIG_0")]
	public static extern IntPtr new_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator__SWIG_0();

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator__SWIG_1")]
	public static extern IntPtr new_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator__SWIG_2")]
	public static extern IntPtr new_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator__SWIG_2(int jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_size___")]
	public static extern uint OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_size(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_capacity___")]
	public static extern uint OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_capacity(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_reserve___")]
	public static extern void OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_resize___")]
	public static extern void OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Clear___")]
	public static extern void OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Add___")]
	public static extern void OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_getitemcopy___")]
	public static extern IntPtr OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_getitem___")]
	public static extern IntPtr OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_setitem___")]
	public static extern void OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_AddRange___")]
	public static extern void OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_GetRange___")]
	public static extern IntPtr OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Insert___")]
	public static extern void OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_InsertRange___")]
	public static extern void OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_RemoveAt___")]
	public static extern void OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_RemoveRange___")]
	public static extern void OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Repeat___")]
	public static extern IntPtr OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Reverse__SWIG_0___")]
	public static extern void OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Reverse__SWIG_1___")]
	public static extern void OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_SetRange___")]
	public static extern void OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Contains___")]
	public static extern bool OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_IndexOf___")]
	public static extern int OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_LastIndexOf___")]
	public static extern int OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Remove___")]
	public static extern bool OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_delete_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator___")]
	public static extern void delete_OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator(HandleRef jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExport_SWIGUpcast___")]
	public static extern IntPtr OdPrcContextForPdfExport_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_OdPrcContextForPdfExportWrapper_SWIGUpcast___")]
	public static extern IntPtr OdPrcContextForPdfExportWrapper_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportBaseParamsSwigImpl_PDFExportBaseParams_GetInterfaceCPtr___")]
	public static extern IntPtr PDFExportBaseParamsSwigImpl_PDFExportBaseParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_PRCExportParams_GetInterfaceCPtr___")]
	public static extern IntPtr PRCExportParamsSwigImpl_PRCExportParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PRCExportParamsSwigImpl_PDFExportBaseParams_GetInterfaceCPtr___")]
	public static extern IntPtr PRCExportParamsSwigImpl_PDFExportBaseParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_PDFExport3DParams_GetInterfaceCPtr___")]
	public static extern IntPtr PDFExport3DParamsSwigImpl_PDFExport3DParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_PRCExportParams_GetInterfaceCPtr___")]
	public static extern IntPtr PDFExport3DParamsSwigImpl_PRCExportParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport3DParamsSwigImpl_PDFExportBaseParams_GetInterfaceCPtr___")]
	public static extern IntPtr PDFExport3DParamsSwigImpl_PDFExportBaseParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExportDocumentParamsSwigImpl_PDFExportDocumentParams_GetInterfaceCPtr___")]
	public static extern IntPtr PDFExportDocumentParamsSwigImpl_PDFExportDocumentParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_PDFExport2DParams_GetInterfaceCPtr___")]
	public static extern IntPtr PDFExport2DParamsSwigImpl_PDFExport2DParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PDFExport2DParamsSwigImpl_PDFExportBaseParams_GetInterfaceCPtr___")]
	public static extern IntPtr PDFExport2DParamsSwigImpl_PDFExportBaseParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_PDFExportDocumentParams_GetInterfaceCPtr___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_PDFExportDocumentParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_PDFExport2DParams_GetInterfaceCPtr___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_PDFExport2DParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_PDFExport3DParams_GetInterfaceCPtr___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_PDFExport3DParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_PRCExportParams_GetInterfaceCPtr___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_PRCExportParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PDFExportParams_PDFExportBaseParams_GetInterfaceCPtr___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PDFExportParams_PDFExportBaseParams_GetInterfaceCPtr(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_ShellDrawable_SWIGUpcast___")]
	public static extern IntPtr ShellDrawable_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportServiceInterface_SWIGUpcast___")]
	public static extern IntPtr PdfExportServiceInterface_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportGiDrawablePE_SWIGUpcast___")]
	public static extern IntPtr PdfExportGiDrawablePE_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_PdfExportLayerPE_SWIGUpcast___")]
	public static extern IntPtr PdfExportLayerPE_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExportPE_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExportPE_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_OdPdfExport_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_OdPdfExport_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PdfExport_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PdfExport_TD_PDF_2D_EXPORT_PdfExportModule_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_2D_EXPORT_PdfExportModule_SWIGUpcast(IntPtr jarg1);
}

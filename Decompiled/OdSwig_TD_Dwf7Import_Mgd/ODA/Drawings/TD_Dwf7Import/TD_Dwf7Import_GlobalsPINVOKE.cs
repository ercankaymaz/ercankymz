using System;
using System.IO;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_Dwf7Import;

internal class TD_Dwf7Import_GlobalsPINVOKE
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

		[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll")]
		public static extern void SWIGRegisterExceptionCallbacks_TD_Dwf7Import_Globals(ExceptionDelegate applicationDelegate, ExceptionDelegate arithmeticDelegate, ExceptionDelegate divideByZeroDelegate, ExceptionDelegate indexOutOfRangeDelegate, ExceptionDelegate invalidCastDelegate, ExceptionDelegate invalidOperationDelegate, ExceptionDelegate ioDelegate, ExceptionDelegate nullReferenceDelegate, ExceptionDelegate outOfMemoryDelegate, ExceptionDelegate overflowDelegate, ExceptionDelegate systemExceptionDelegate);

		[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_TD_Dwf7Import_Globals")]
		public static extern void SWIGRegisterExceptionCallbacksArgument_TD_Dwf7Import_Globals(ExceptionArgumentDelegate argumentDelegate, ExceptionArgumentDelegate argumentNullDelegate, ExceptionArgumentDelegate argumentOutOfRangeDelegate);

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
			SWIGRegisterExceptionCallbacks_TD_Dwf7Import_Globals(applicationDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, outOfMemoryDelegate, overflowDelegate, systemDelegate);
			SWIGRegisterExceptionCallbacksArgument_TD_Dwf7Import_Globals(argumentDelegate, argumentNullDelegate, argumentOutOfRangeDelegate);
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

		[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll")]
		public static extern void SWIGRegisterStringCallback_TD_Dwf7Import_Globals(SWIGStringDelegate stringDelegate);

		private static string CreateString(string cString)
		{
			return cString;
		}

		static SWIGStringHelper()
		{
			stringDelegate = CreateString;
			SWIGRegisterStringCallback_TD_Dwf7Import_Globals(stringDelegate);
		}
	}

	private class CustomExceptionHelper
	{
		public delegate void CustomExceptionDelegate(IntPtr NewContext);

		private static CustomExceptionDelegate customDelegate;

		[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll")]
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

	static TD_Dwf7Import_GlobalsPINVOKE()
	{
		swigExceptionHelper = new SWIGExceptionHelper();
		swigStringHelper = new SWIGStringHelper();
		exceptionHelper = new CustomExceptionHelper();
	}

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_UINT_MAX_get___")]
	public static extern uint UINT_MAX_get();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_ULONG_MAX_get___")]
	public static extern uint ULONG_MAX_get();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import__MSC_VER_get___")]
	public static extern int _MSC_VER_get();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_ODCHAR_IS_INT16LE_get___")]
	public static extern int ODCHAR_IS_INT16LE_get();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_OD_SIZEOF_INT_get___")]
	public static extern int OD_SIZEOF_INT_get();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_OD_SIZEOF_LONG_get___")]
	public static extern int OD_SIZEOF_LONG_get();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_PERCENT18LONG_get___")]
	public static extern string PERCENT18LONG_get();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_HANDLEFORMAT_get___")]
	public static extern string HANDLEFORMAT_get();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_PRId64_get___")]
	public static extern string PRId64_get();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_PRIu64_get___")]
	public static extern string PRIu64_get();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_PRIx64_get___")]
	public static extern string PRIx64_get();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_PRIX64_get___")]
	public static extern string PRIX64_get();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_OD_SIZEOF_PTR_get___")]
	public static extern int OD_SIZEOF_PTR_get();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_throw_native_exception_string___")]
	public static extern void throw_native_exception_string([MarshalAs(UnmanagedType.LPWStr)] string jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_throw_native_OdError__SWIG_0___")]
	public static extern void throw_native_OdError__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_throw_native_OdError__SWIG_1___")]
	public static extern void throw_native_OdError__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_throw_native_OdError__SWIG_2___")]
	public static extern void throw_native_OdError__SWIG_2(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_sec_set___")]
	public static extern void tm_tm_sec_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_sec_get___")]
	public static extern int tm_tm_sec_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_min_set___")]
	public static extern void tm_tm_min_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_min_get___")]
	public static extern int tm_tm_min_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_hour_set___")]
	public static extern void tm_tm_hour_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_hour_get___")]
	public static extern int tm_tm_hour_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_mday_set___")]
	public static extern void tm_tm_mday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_mday_get___")]
	public static extern int tm_tm_mday_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_mon_set___")]
	public static extern void tm_tm_mon_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_mon_get___")]
	public static extern int tm_tm_mon_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_year_set___")]
	public static extern void tm_tm_year_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_year_get___")]
	public static extern int tm_tm_year_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_wday_set___")]
	public static extern void tm_tm_wday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_wday_get___")]
	public static extern int tm_tm_wday_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_yday_set___")]
	public static extern void tm_tm_yday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_yday_get___")]
	public static extern int tm_tm_yday_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_isdst_set___")]
	public static extern void tm_tm_isdst_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_tm_tm_isdst_get___")]
	public static extern int tm_tm_isdst_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_new_tm___")]
	public static extern IntPtr new_tm();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_delete_tm___")]
	public static extern void delete_tm(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_TD_DWF_IMPORT_OdDwfImport_import__SWIG_0___")]
	public static extern int TD_DWF_IMPORT_OdDwfImport_import__SWIG_0(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_TD_DWF_IMPORT_OdDwfImport_import__SWIG_1___")]
	public static extern int TD_DWF_IMPORT_OdDwfImport_import__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_TD_DWF_IMPORT_OdDwfImport_properties___")]
	public static extern IntPtr TD_DWF_IMPORT_OdDwfImport_properties(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_TD_DWF_IMPORT_OdDwfImport_getRealClassName___")]
	public static extern string TD_DWF_IMPORT_OdDwfImport_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_delete_TD_DWF_IMPORT_OdDwfImport___")]
	public static extern void delete_TD_DWF_IMPORT_OdDwfImport(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_TD_DWF_IMPORT_OdDwfImportModule_create___")]
	public static extern IntPtr TD_DWF_IMPORT_OdDwfImportModule_create(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_TD_DWF_IMPORT_OdDwfImportModule_getRealClassName___")]
	public static extern string TD_DWF_IMPORT_OdDwfImportModule_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_delete_TD_DWF_IMPORT_OdDwfImportModule___")]
	public static extern void delete_TD_DWF_IMPORT_OdDwfImportModule(HandleRef jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_createDwfImporter___")]
	public static extern IntPtr createDwfImporter();

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_TD_DWF_IMPORT_OdDwfImport_SWIGUpcast___")]
	public static extern IntPtr TD_DWF_IMPORT_OdDwfImport_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_Dwf7Import_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfTD_Dwf7Import_TD_DWF_IMPORT_OdDwfImportModule_SWIGUpcast___")]
	public static extern IntPtr TD_DWF_IMPORT_OdDwfImportModule_SWIGUpcast(IntPtr jarg1);
}

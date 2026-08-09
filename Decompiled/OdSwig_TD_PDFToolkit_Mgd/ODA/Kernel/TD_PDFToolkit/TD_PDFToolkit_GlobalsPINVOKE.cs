using System;
using System.IO;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

internal class TD_PDFToolkit_GlobalsPINVOKE
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

		[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll")]
		public static extern void SWIGRegisterExceptionCallbacks_TD_PDFToolkit_Globals(ExceptionDelegate applicationDelegate, ExceptionDelegate arithmeticDelegate, ExceptionDelegate divideByZeroDelegate, ExceptionDelegate indexOutOfRangeDelegate, ExceptionDelegate invalidCastDelegate, ExceptionDelegate invalidOperationDelegate, ExceptionDelegate ioDelegate, ExceptionDelegate nullReferenceDelegate, ExceptionDelegate outOfMemoryDelegate, ExceptionDelegate overflowDelegate, ExceptionDelegate systemExceptionDelegate);

		[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_TD_PDFToolkit_Globals")]
		public static extern void SWIGRegisterExceptionCallbacksArgument_TD_PDFToolkit_Globals(ExceptionArgumentDelegate argumentDelegate, ExceptionArgumentDelegate argumentNullDelegate, ExceptionArgumentDelegate argumentOutOfRangeDelegate);

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
			SWIGRegisterExceptionCallbacks_TD_PDFToolkit_Globals(applicationDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, outOfMemoryDelegate, overflowDelegate, systemDelegate);
			SWIGRegisterExceptionCallbacksArgument_TD_PDFToolkit_Globals(argumentDelegate, argumentNullDelegate, argumentOutOfRangeDelegate);
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

		[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll")]
		public static extern void SWIGRegisterStringCallback_TD_PDFToolkit_Globals(SWIGStringDelegate stringDelegate);

		private static string CreateString(string cString)
		{
			return cString;
		}

		static SWIGStringHelper()
		{
			stringDelegate = CreateString;
			SWIGRegisterStringCallback_TD_PDFToolkit_Globals(stringDelegate);
		}
	}

	private class CustomExceptionHelper
	{
		public delegate void CustomExceptionDelegate(IntPtr NewContext);

		private static CustomExceptionDelegate customDelegate;

		[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll")]
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

	static TD_PDFToolkit_GlobalsPINVOKE()
	{
		swigExceptionHelper = new SWIGExceptionHelper();
		swigStringHelper = new SWIGStringHelper();
		exceptionHelper = new CustomExceptionHelper();
	}

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_UINT_MAX_get___")]
	public static extern uint UINT_MAX_get();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_ULONG_MAX_get___")]
	public static extern uint ULONG_MAX_get();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit__MSC_VER_get___")]
	public static extern int _MSC_VER_get();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_ODCHAR_IS_INT16LE_get___")]
	public static extern int ODCHAR_IS_INT16LE_get();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OD_SIZEOF_INT_get___")]
	public static extern int OD_SIZEOF_INT_get();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OD_SIZEOF_LONG_get___")]
	public static extern int OD_SIZEOF_LONG_get();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_PERCENT18LONG_get___")]
	public static extern string PERCENT18LONG_get();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_HANDLEFORMAT_get___")]
	public static extern string HANDLEFORMAT_get();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_PRId64_get___")]
	public static extern string PRId64_get();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_PRIu64_get___")]
	public static extern string PRIu64_get();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_PRIx64_get___")]
	public static extern string PRIx64_get();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_PRIX64_get___")]
	public static extern string PRIX64_get();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OD_SIZEOF_PTR_get___")]
	public static extern int OD_SIZEOF_PTR_get();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_throw_native_exception_string___")]
	public static extern void throw_native_exception_string([MarshalAs(UnmanagedType.LPWStr)] string jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_throw_native_OdError__SWIG_0___")]
	public static extern void throw_native_OdError__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_throw_native_OdError__SWIG_1___")]
	public static extern void throw_native_OdError__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_throw_native_OdError__SWIG_2___")]
	public static extern void throw_native_OdError__SWIG_2(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_sec_set___")]
	public static extern void tm_tm_sec_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_sec_get___")]
	public static extern int tm_tm_sec_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_min_set___")]
	public static extern void tm_tm_min_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_min_get___")]
	public static extern int tm_tm_min_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_hour_set___")]
	public static extern void tm_tm_hour_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_hour_get___")]
	public static extern int tm_tm_hour_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_mday_set___")]
	public static extern void tm_tm_mday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_mday_get___")]
	public static extern int tm_tm_mday_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_mon_set___")]
	public static extern void tm_tm_mon_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_mon_get___")]
	public static extern int tm_tm_mon_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_year_set___")]
	public static extern void tm_tm_year_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_year_get___")]
	public static extern int tm_tm_year_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_wday_set___")]
	public static extern void tm_tm_wday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_wday_get___")]
	public static extern int tm_tm_wday_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_yday_set___")]
	public static extern void tm_tm_yday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_yday_get___")]
	public static extern int tm_tm_yday_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_isdst_set___")]
	public static extern void tm_tm_isdst_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_tm_tm_isdst_get___")]
	public static extern int tm_tm_isdst_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_tm___")]
	public static extern IntPtr new_tm();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_tm___")]
	public static extern void delete_tm(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_getUnicodeTextString___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_getUnicodeTextString([MarshalAs(UnmanagedType.LPWStr)] string jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBaseObjectPtr_get___")]
	public static extern IntPtr TD_PDF_PDFBaseObjectPtr_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBaseObjectPtr_isNull___")]
	public static extern bool TD_PDF_PDFBaseObjectPtr_isNull(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFBaseObjectPtr___")]
	public static extern void delete_TD_PDF_PDFBaseObjectPtr(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAbstractObject_isKindOf___")]
	public static extern bool TD_PDF_PDFAbstractObject_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAbstractObject_type___")]
	public static extern int TD_PDF_PDFAbstractObject_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_TD_PDF_PDFAbstractObject___")]
	public static extern IntPtr new_TD_PDF_PDFAbstractObject();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAbstractObject_InitObject___")]
	public static extern void TD_PDF_PDFAbstractObject_InitObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAbstractObject_InitObjectSwigExplicitTD_PDF_PDFAbstractObject___")]
	public static extern void TD_PDF_PDFAbstractObject_InitObjectSwigExplicitTD_PDF_PDFAbstractObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFAbstractObject___")]
	public static extern void delete_TD_PDF_PDFAbstractObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAbstractObject_director_connect___")]
	public static extern void TD_PDF_PDFAbstractObject_director_connect(HandleRef jarg1, TD_PDF_PDFAbstractObject.SwigDelegateTD_PDF_PDFAbstractObject_0 delegate0, TD_PDF_PDFAbstractObject.SwigDelegateTD_PDF_PDFAbstractObject_1 delegate1, TD_PDF_PDFAbstractObject.SwigDelegateTD_PDF_PDFAbstractObject_2 delegate2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBaseObject_isKindOf___")]
	public static extern bool TD_PDF_PDFBaseObject_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBaseObject_type___")]
	public static extern int TD_PDF_PDFBaseObject_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFBaseObject___")]
	public static extern void delete_TD_PDF_PDFBaseObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFObject_isKindOf___")]
	public static extern bool TD_PDF_PDFObject_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFObject_type___")]
	public static extern int TD_PDF_PDFObject_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFObject_IndirectObjectID___")]
	public static extern void TD_PDF_PDFObject_IndirectObjectID(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFObject_Export___")]
	public static extern bool TD_PDF_PDFObject_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFObject_ExportLikeRef___")]
	public static extern bool TD_PDF_PDFObject_ExportLikeRef(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFObject_ExportLikeRefObj___")]
	public static extern bool TD_PDF_PDFObject_ExportLikeRefObj(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFObject_isIndirect___")]
	public static extern bool TD_PDF_PDFObject_isIndirect(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFObject_document___")]
	public static extern IntPtr TD_PDF_PDFObject_document(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFObject_setDocument___")]
	public static extern void TD_PDF_PDFObject_setDocument(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFObject_clearDictionaries___")]
	public static extern void TD_PDF_PDFObject_clearDictionaries(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFObject_getRealClassName___")]
	public static extern string TD_PDF_PDFObject_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFObject___")]
	public static extern void delete_TD_PDF_PDFObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBaseString_isKindOf___")]
	public static extern bool TD_PDF_PDFBaseString_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBaseString_type___")]
	public static extern int TD_PDF_PDFBaseString_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBaseString_Assign___")]
	public static extern IntPtr TD_PDF_PDFBaseString_Assign(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBaseString_str__SWIG_0___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFBaseString_str__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBaseString_Export___")]
	public static extern bool TD_PDF_PDFBaseString_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBaseString_getRealClassName___")]
	public static extern string TD_PDF_PDFBaseString_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFBaseString___")]
	public static extern void delete_TD_PDF_PDFBaseString(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFName_isKindOf___")]
	public static extern bool TD_PDF_PDFName_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFName_type___")]
	public static extern int TD_PDF_PDFName_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFName_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFName_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFName_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFName_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFName_Assign___")]
	public static extern IntPtr TD_PDF_PDFName_Assign(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFName_Export___")]
	public static extern bool TD_PDF_PDFName_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFName_createObject__SWIG_2___")]
	public static extern IntPtr TD_PDF_PDFName_createObject__SWIG_2(HandleRef jarg1, string jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFName_createObject__SWIG_3___")]
	public static extern IntPtr TD_PDF_PDFName_createObject__SWIG_3(HandleRef jarg1, string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFName_setAsUnicodeString___")]
	public static extern void TD_PDF_PDFName_setAsUnicodeString(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFName_getRealClassName___")]
	public static extern string TD_PDF_PDFName_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFName___")]
	public static extern void delete_TD_PDF_PDFName(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBoolean_isKindOf___")]
	public static extern bool TD_PDF_PDFBoolean_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBoolean_type___")]
	public static extern int TD_PDF_PDFBoolean_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBoolean_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFBoolean_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBoolean_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFBoolean_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBoolean_createObject__SWIG_2___")]
	public static extern IntPtr TD_PDF_PDFBoolean_createObject__SWIG_2(HandleRef jarg1, bool jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBoolean_Export___")]
	public static extern bool TD_PDF_PDFBoolean_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBoolean_setBool___")]
	public static extern void TD_PDF_PDFBoolean_setBool(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBoolean_getBool___")]
	public static extern bool TD_PDF_PDFBoolean_getBool(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBoolean_getRealClassName___")]
	public static extern string TD_PDF_PDFBoolean_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFBoolean___")]
	public static extern void delete_TD_PDF_PDFBoolean(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_TD_PDF_PDFVersion__SWIG_0___")]
	public static extern IntPtr new_TD_PDF_PDFVersion__SWIG_0();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_TD_PDF_PDFVersion__SWIG_1___")]
	public static extern IntPtr new_TD_PDF_PDFVersion__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFVersion_Version___")]
	public static extern IntPtr TD_PDF_PDFVersion_Version(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFVersion_asString___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFVersion_asString(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFVersion_FromString___")]
	public static extern IntPtr TD_PDF_PDFVersion_FromString(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFVersion_Assign___")]
	public static extern IntPtr TD_PDF_PDFVersion_Assign(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFVersion_IsEqual__SWIG_0___")]
	public static extern bool TD_PDF_PDFVersion_IsEqual__SWIG_0(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFVersion_IsEqual__SWIG_1___")]
	public static extern bool TD_PDF_PDFVersion_IsEqual__SWIG_1(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFVersion___")]
	public static extern void delete_TD_PDF_PDFVersion(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRectangle_isKindOf___")]
	public static extern bool TD_PDF_PDFRectangle_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRectangle_type___")]
	public static extern int TD_PDF_PDFRectangle_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRectangle_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFRectangle_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRectangle_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFRectangle_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRectangle_set__SWIG_0___")]
	public static extern void TD_PDF_PDFRectangle_set__SWIG_0(HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRectangle_set__SWIG_1___")]
	public static extern void TD_PDF_PDFRectangle_set__SWIG_1(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRectangle_get___")]
	public static extern void TD_PDF_PDFRectangle_get(HandleRef jarg1, out int jarg2, out int jarg3, out int jarg4, out int jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRectangle_Export___")]
	public static extern bool TD_PDF_PDFRectangle_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRectangle_getRealClassName___")]
	public static extern string TD_PDF_PDFRectangle_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFRectangle___")]
	public static extern void delete_TD_PDF_PDFRectangle(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_type___")]
	public static extern int TD_PDF_PDFDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_Export___")]
	public static extern bool TD_PDF_PDFDictionary_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_RemoveItem___")]
	public static extern bool TD_PDF_PDFDictionary_RemoveItem(HandleRef jarg1, string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_Find__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFDictionary_Find__SWIG_0(HandleRef jarg1, string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_HasItem___")]
	public static extern bool TD_PDF_PDFDictionary_HasItem(HandleRef jarg1, string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_getUniqueName___")]
	public static extern IntPtr TD_PDF_PDFDictionary_getUniqueName(HandleRef jarg1, string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_clearDictionaries___")]
	public static extern void TD_PDF_PDFDictionary_clearDictionaries(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_isEmpty___")]
	public static extern bool TD_PDF_PDFDictionary_isEmpty(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_mergeWith___")]
	public static extern void TD_PDF_PDFDictionary_mergeWith(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFDictionary___")]
	public static extern void delete_TD_PDF_PDFDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDecodeParametersDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFDecodeParametersDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDecodeParametersDictionary_type___")]
	public static extern int TD_PDF_PDFDecodeParametersDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDecodeParametersDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFDecodeParametersDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFDecodeParametersDictionary___")]
	public static extern void delete_TD_PDF_PDFDecodeParametersDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_isKindOf___")]
	public static extern bool TD_PDF_PDFIStream_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_type___")]
	public static extern int TD_PDF_PDFIStream_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_createObject___")]
	public static extern IntPtr TD_PDF_PDFIStream_createObject();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_getByte___")]
	public static extern byte TD_PDF_PDFIStream_getByte(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_getBytes___")]
	public static extern void TD_PDF_PDFIStream_getBytes(HandleRef jarg1, IntPtr jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_setStreamBuf___")]
	public static extern void TD_PDF_PDFIStream_setStreamBuf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFIStream___")]
	public static extern void delete_TD_PDF_PDFIStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_fileName___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFIStream_fileName(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_isEof___")]
	public static extern bool TD_PDF_PDFIStream_isEof(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_tell___")]
	public static extern uint TD_PDF_PDFIStream_tell(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_length___")]
	public static extern uint TD_PDF_PDFIStream_length(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_truncate___")]
	public static extern void TD_PDF_PDFIStream_truncate(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_rewind___")]
	public static extern void TD_PDF_PDFIStream_rewind(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_seek___")]
	public static extern uint TD_PDF_PDFIStream_seek(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_copyDataTo___")]
	public static extern void TD_PDF_PDFIStream_copyDataTo(HandleRef jarg1, HandleRef jarg2, uint jarg3, uint jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_getShareMode___")]
	public static extern uint TD_PDF_PDFIStream_getShareMode(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_putEOL___")]
	public static extern void TD_PDF_PDFIStream_putEOL(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_putBool___")]
	public static extern void TD_PDF_PDFIStream_putBool(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_putDouble___")]
	public static extern void TD_PDF_PDFIStream_putDouble(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_putInt32___")]
	public static extern void TD_PDF_PDFIStream_putInt32(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_putString___")]
	public static extern void TD_PDF_PDFIStream_putString(HandleRef jarg1, string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_putByte___")]
	public static extern void TD_PDF_PDFIStream_putByte(HandleRef jarg1, byte jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_putBytes___")]
	public static extern void TD_PDF_PDFIStream_putBytes(HandleRef jarg1, IntPtr jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_Export___")]
	public static extern bool TD_PDF_PDFIStream_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_getRealClassName___")]
	public static extern string TD_PDF_PDFIStream_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFStreamDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamDictionary_type___")]
	public static extern int TD_PDF_PDFStreamDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFStreamDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFStreamDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFStreamDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFStreamDictionary___")]
	public static extern void delete_TD_PDF_PDFStreamDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLiteralString_isKindOf___")]
	public static extern bool TD_PDF_PDFLiteralString_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLiteralString_type___")]
	public static extern int TD_PDF_PDFLiteralString_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLiteralString_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFLiteralString_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLiteralString_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFLiteralString_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLiteralString_Export___")]
	public static extern bool TD_PDF_PDFLiteralString_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLiteralString_createObject__SWIG_2___")]
	public static extern IntPtr TD_PDF_PDFLiteralString_createObject__SWIG_2(HandleRef jarg1, string jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLiteralString_createObject__SWIG_3___")]
	public static extern IntPtr TD_PDF_PDFLiteralString_createObject__SWIG_3(HandleRef jarg1, string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLiteralString_getRealClassName___")]
	public static extern string TD_PDF_PDFLiteralString_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFLiteralString___")]
	public static extern void delete_TD_PDF_PDFLiteralString(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStream_isKindOf___")]
	public static extern bool TD_PDF_PDFStream_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStream_type___")]
	public static extern int TD_PDF_PDFStream_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStream_Export___")]
	public static extern bool TD_PDF_PDFStream_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStream_getLength___")]
	public static extern uint TD_PDF_PDFStream_getLength(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStream_AddFilter___")]
	public static extern bool TD_PDF_PDFStream_AddFilter(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStream_RemoveFilter___")]
	public static extern bool TD_PDF_PDFStream_RemoveFilter(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStream_getNumberOfFilters___")]
	public static extern uint TD_PDF_PDFStream_getNumberOfFilters(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStream_getFilterAt___")]
	public static extern bool TD_PDF_PDFStream_getFilterAt(HandleRef jarg1, uint jarg2, ref IntPtr jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStream_getDecodeParamsAt___")]
	public static extern bool TD_PDF_PDFStream_getDecodeParamsAt(HandleRef jarg1, uint jarg2, ref IntPtr jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStream_getRealClassName___")]
	public static extern string TD_PDF_PDFStream_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFStream___")]
	public static extern void delete_TD_PDF_PDFStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_setTraits___")]
	public static extern void TD_PDF_PDFIContentCommands_setTraits(HandleRef jarg1, double jarg2, uint jarg3, uint jarg4, ushort jarg5, ushort jarg6, int jarg7, int jarg8);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_getTraits___")]
	public static extern void TD_PDF_PDFIContentCommands_getTraits(HandleRef jarg1, out double jarg2, out uint jarg3, out uint jarg4, out ushort jarg5, out ushort jarg6, out TD_PDF_PDFLineCap jarg7, out TD_PDF_PDFLineJoin jarg8);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_Do___")]
	public static extern void TD_PDF_PDFIContentCommands_Do(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_q___")]
	public static extern void TD_PDF_PDFIContentCommands_q(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_Q___")]
	public static extern void TD_PDF_PDFIContentCommands_Q(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_gs___")]
	public static extern void TD_PDF_PDFIContentCommands_gs(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_cm___")]
	public static extern void TD_PDF_PDFIContentCommands_cm(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_w___")]
	public static extern void TD_PDF_PDFIContentCommands_w(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_J___")]
	public static extern void TD_PDF_PDFIContentCommands_J(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_j___")]
	public static extern void TD_PDF_PDFIContentCommands_j(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_d___")]
	public static extern void TD_PDF_PDFIContentCommands_d(HandleRef jarg1, HandleRef jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_cs___")]
	public static extern void TD_PDF_PDFIContentCommands_cs(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_CS___")]
	public static extern void TD_PDF_PDFIContentCommands_CS(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_sc___")]
	public static extern void TD_PDF_PDFIContentCommands_sc(HandleRef jarg1, byte jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_SC___")]
	public static extern void TD_PDF_PDFIContentCommands_SC(HandleRef jarg1, byte jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_RG__SWIG_0___")]
	public static extern void TD_PDF_PDFIContentCommands_RG__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, double jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_rg__SWIG_0___")]
	public static extern void TD_PDF_PDFIContentCommands_rg__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, double jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_RG__SWIG_1___")]
	public static extern void TD_PDF_PDFIContentCommands_RG__SWIG_1(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_rg__SWIG_1___")]
	public static extern void TD_PDF_PDFIContentCommands_rg__SWIG_1(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_g___")]
	public static extern void TD_PDF_PDFIContentCommands_g(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_G___")]
	public static extern void TD_PDF_PDFIContentCommands_G(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_scn___")]
	public static extern void TD_PDF_PDFIContentCommands_scn(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_SCN___")]
	public static extern void TD_PDF_PDFIContentCommands_SCN(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_m__SWIG_0___")]
	public static extern void TD_PDF_PDFIContentCommands_m__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, int jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_m__SWIG_1___")]
	public static extern void TD_PDF_PDFIContentCommands_m__SWIG_1(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_l__SWIG_0___")]
	public static extern void TD_PDF_PDFIContentCommands_l__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, int jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_l__SWIG_1___")]
	public static extern void TD_PDF_PDFIContentCommands_l__SWIG_1(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_c__SWIG_0___")]
	public static extern void TD_PDF_PDFIContentCommands_c__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7, int jarg8);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_c__SWIG_1___")]
	public static extern void TD_PDF_PDFIContentCommands_c__SWIG_1(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_v__SWIG_0___")]
	public static extern void TD_PDF_PDFIContentCommands_v__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_y__SWIG_0___")]
	public static extern void TD_PDF_PDFIContentCommands_y__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_m__SWIG_2___")]
	public static extern void TD_PDF_PDFIContentCommands_m__SWIG_2(HandleRef jarg1, HandleRef jarg2, int jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_m__SWIG_3___")]
	public static extern void TD_PDF_PDFIContentCommands_m__SWIG_3(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_l__SWIG_2___")]
	public static extern void TD_PDF_PDFIContentCommands_l__SWIG_2(HandleRef jarg1, HandleRef jarg2, int jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_l__SWIG_3___")]
	public static extern void TD_PDF_PDFIContentCommands_l__SWIG_3(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_c__SWIG_2___")]
	public static extern void TD_PDF_PDFIContentCommands_c__SWIG_2(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4, int jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_c__SWIG_3___")]
	public static extern void TD_PDF_PDFIContentCommands_c__SWIG_3(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_v__SWIG_1___")]
	public static extern void TD_PDF_PDFIContentCommands_v__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_y__SWIG_1___")]
	public static extern void TD_PDF_PDFIContentCommands_y__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_re___")]
	public static extern void TD_PDF_PDFIContentCommands_re(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_h___")]
	public static extern void TD_PDF_PDFIContentCommands_h(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_S___")]
	public static extern void TD_PDF_PDFIContentCommands_S(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_s___")]
	public static extern void TD_PDF_PDFIContentCommands_s(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_f___")]
	public static extern void TD_PDF_PDFIContentCommands_f(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_f_odd___")]
	public static extern void TD_PDF_PDFIContentCommands_f_odd(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_B___")]
	public static extern void TD_PDF_PDFIContentCommands_B(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_B_odd___")]
	public static extern void TD_PDF_PDFIContentCommands_B_odd(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_b___")]
	public static extern void TD_PDF_PDFIContentCommands_b(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_b_odd___")]
	public static extern void TD_PDF_PDFIContentCommands_b_odd(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_n___")]
	public static extern void TD_PDF_PDFIContentCommands_n(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_W___")]
	public static extern void TD_PDF_PDFIContentCommands_W(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_W_odd___")]
	public static extern void TD_PDF_PDFIContentCommands_W_odd(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_Tc___")]
	public static extern void TD_PDF_PDFIContentCommands_Tc(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_Tw___")]
	public static extern void TD_PDF_PDFIContentCommands_Tw(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_Tz___")]
	public static extern void TD_PDF_PDFIContentCommands_Tz(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_TL___")]
	public static extern void TD_PDF_PDFIContentCommands_TL(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_Tf___")]
	public static extern void TD_PDF_PDFIContentCommands_Tf(HandleRef jarg1, HandleRef jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_Tr___")]
	public static extern void TD_PDF_PDFIContentCommands_Tr(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_Ts___")]
	public static extern void TD_PDF_PDFIContentCommands_Ts(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_BT___")]
	public static extern void TD_PDF_PDFIContentCommands_BT(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_ET___")]
	public static extern void TD_PDF_PDFIContentCommands_ET(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_Td___")]
	public static extern void TD_PDF_PDFIContentCommands_Td(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_TD___")]
	public static extern void TD_PDF_PDFIContentCommands_TD(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_Tm___")]
	public static extern void TD_PDF_PDFIContentCommands_Tm(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_T_star___")]
	public static extern void TD_PDF_PDFIContentCommands_T_star(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_Tj___")]
	public static extern void TD_PDF_PDFIContentCommands_Tj(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_TJ___")]
	public static extern void TD_PDF_PDFIContentCommands_TJ(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_BDC___")]
	public static extern void TD_PDF_PDFIContentCommands_BDC(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_BMC___")]
	public static extern void TD_PDF_PDFIContentCommands_BMC(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_EMC___")]
	public static extern void TD_PDF_PDFIContentCommands_EMC(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_sh___")]
	public static extern void TD_PDF_PDFIContentCommands_sh(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFIContentCommands___")]
	public static extern void delete_TD_PDF_PDFIContentCommands(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_drawEllipse__SWIG_0___")]
	public static extern void TD_PDF_PDFIContentCommands_drawEllipse__SWIG_0(HandleRef jarg1, HandleRef jarg2, bool jarg3, double jarg4, int jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_drawEllipse__SWIG_1___")]
	public static extern void TD_PDF_PDFIContentCommands_drawEllipse__SWIG_1(HandleRef jarg1, HandleRef jarg2, bool jarg3, double jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_drawEllipse__SWIG_2___")]
	public static extern void TD_PDF_PDFIContentCommands_drawEllipse__SWIG_2(HandleRef jarg1, HandleRef jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_drawEllipse__SWIG_3___")]
	public static extern void TD_PDF_PDFIContentCommands_drawEllipse__SWIG_3(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_drawPolyline__SWIG_0___")]
	public static extern void TD_PDF_PDFIContentCommands_drawPolyline__SWIG_0(HandleRef jarg1, uint jarg2, HandleRef jarg3, int jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_drawPolyline__SWIG_1___")]
	public static extern void TD_PDF_PDFIContentCommands_drawPolyline__SWIG_1(HandleRef jarg1, uint jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_drawPolyline__SWIG_2___")]
	public static extern void TD_PDF_PDFIContentCommands_drawPolyline__SWIG_2(HandleRef jarg1, IntPtr jarg2, int jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_drawPolyline__SWIG_3___")]
	public static extern void TD_PDF_PDFIContentCommands_drawPolyline__SWIG_3(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_drawCurve__SWIG_0___")]
	public static extern void TD_PDF_PDFIContentCommands_drawCurve__SWIG_0(HandleRef jarg1, HandleRef jarg2, double jarg3, int jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_drawCurve__SWIG_1___")]
	public static extern void TD_PDF_PDFIContentCommands_drawCurve__SWIG_1(HandleRef jarg1, HandleRef jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_drawCurve__SWIG_2___")]
	public static extern void TD_PDF_PDFIContentCommands_drawCurve__SWIG_2(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_drawPoint__SWIG_0___")]
	public static extern void TD_PDF_PDFIContentCommands_drawPoint__SWIG_0(HandleRef jarg1, HandleRef jarg2, int jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands_drawPoint__SWIG_1___")]
	public static extern void TD_PDF_PDFIContentCommands_drawPoint__SWIG_1(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFXObjectDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectDictionary_type___")]
	public static extern int TD_PDF_PDFXObjectDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFXObjectDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFXObjectDictionary___")]
	public static extern void delete_TD_PDF_PDFXObjectDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPatternDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFTilingPatternDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPatternDictionary_type___")]
	public static extern int TD_PDF_PDFTilingPatternDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPatternDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFTilingPatternDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPatternDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFTilingPatternDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPatternDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFTilingPatternDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFTilingPatternDictionary___")]
	public static extern void delete_TD_PDF_PDFTilingPatternDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curLW_set___")]
	public static extern void TD_PDF_PDFStreamTraits_m_curLW_set(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curLW_get___")]
	public static extern double TD_PDF_PDFStreamTraits_m_curLW_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curRGB_strok_set___")]
	public static extern void TD_PDF_PDFStreamTraits_m_curRGB_strok_set(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curRGB_strok_get___")]
	public static extern uint TD_PDF_PDFStreamTraits_m_curRGB_strok_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curRGB_n_strok_set___")]
	public static extern void TD_PDF_PDFStreamTraits_m_curRGB_n_strok_set(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curRGB_n_strok_get___")]
	public static extern uint TD_PDF_PDFStreamTraits_m_curRGB_n_strok_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curCI_strok_set___")]
	public static extern void TD_PDF_PDFStreamTraits_m_curCI_strok_set(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curCI_strok_get___")]
	public static extern ushort TD_PDF_PDFStreamTraits_m_curCI_strok_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curCI_n_strok_set___")]
	public static extern void TD_PDF_PDFStreamTraits_m_curCI_n_strok_set(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curCI_n_strok_get___")]
	public static extern ushort TD_PDF_PDFStreamTraits_m_curCI_n_strok_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curCapStyle_set___")]
	public static extern void TD_PDF_PDFStreamTraits_m_curCapStyle_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curCapStyle_get___")]
	public static extern int TD_PDF_PDFStreamTraits_m_curCapStyle_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curJoinStyle_set___")]
	public static extern void TD_PDF_PDFStreamTraits_m_curJoinStyle_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamTraits_m_curJoinStyle_get___")]
	public static extern int TD_PDF_PDFStreamTraits_m_curJoinStyle_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_TD_PDF_PDFStreamTraits__SWIG_0___")]
	public static extern IntPtr new_TD_PDF_PDFStreamTraits__SWIG_0();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_TD_PDF_PDFStreamTraits__SWIG_1___")]
	public static extern IntPtr new_TD_PDF_PDFStreamTraits__SWIG_1(double jarg1, uint jarg2, uint jarg3, ushort jarg4, ushort jarg5, int jarg6, int jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFStreamTraits___")]
	public static extern void delete_TD_PDF_PDFStreamTraits(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_isKindOf___")]
	public static extern bool TD_PDF_PDFContentStream_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_type___")]
	public static extern int TD_PDF_PDFContentStream_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFContentStream_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFContentStream_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_setTraits___")]
	public static extern void TD_PDF_PDFContentStream_setTraits(HandleRef jarg1, double jarg2, uint jarg3, uint jarg4, ushort jarg5, ushort jarg6, int jarg7, int jarg8);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_getTraits___")]
	public static extern void TD_PDF_PDFContentStream_getTraits(HandleRef jarg1, out double jarg2, out uint jarg3, out uint jarg4, out ushort jarg5, out ushort jarg6, out TD_PDF_PDFLineCap jarg7, out TD_PDF_PDFLineJoin jarg8);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_Do___")]
	public static extern void TD_PDF_PDFContentStream_Do(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_q___")]
	public static extern void TD_PDF_PDFContentStream_q(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_Q___")]
	public static extern void TD_PDF_PDFContentStream_Q(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_gs___")]
	public static extern void TD_PDF_PDFContentStream_gs(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_cm___")]
	public static extern void TD_PDF_PDFContentStream_cm(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_w___")]
	public static extern void TD_PDF_PDFContentStream_w(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_J___")]
	public static extern void TD_PDF_PDFContentStream_J(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_j___")]
	public static extern void TD_PDF_PDFContentStream_j(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_d___")]
	public static extern void TD_PDF_PDFContentStream_d(HandleRef jarg1, HandleRef jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_cs___")]
	public static extern void TD_PDF_PDFContentStream_cs(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_CS___")]
	public static extern void TD_PDF_PDFContentStream_CS(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_sc___")]
	public static extern void TD_PDF_PDFContentStream_sc(HandleRef jarg1, byte jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_SC___")]
	public static extern void TD_PDF_PDFContentStream_SC(HandleRef jarg1, byte jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_RG__SWIG_0___")]
	public static extern void TD_PDF_PDFContentStream_RG__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, double jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_rg__SWIG_0___")]
	public static extern void TD_PDF_PDFContentStream_rg__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, double jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_RG__SWIG_1___")]
	public static extern void TD_PDF_PDFContentStream_RG__SWIG_1(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_rg__SWIG_1___")]
	public static extern void TD_PDF_PDFContentStream_rg__SWIG_1(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_g___")]
	public static extern void TD_PDF_PDFContentStream_g(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_G___")]
	public static extern void TD_PDF_PDFContentStream_G(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_scn___")]
	public static extern void TD_PDF_PDFContentStream_scn(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_SCN___")]
	public static extern void TD_PDF_PDFContentStream_SCN(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_m__SWIG_0___")]
	public static extern void TD_PDF_PDFContentStream_m__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, int jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_m__SWIG_1___")]
	public static extern void TD_PDF_PDFContentStream_m__SWIG_1(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_l__SWIG_0___")]
	public static extern void TD_PDF_PDFContentStream_l__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, int jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_l__SWIG_1___")]
	public static extern void TD_PDF_PDFContentStream_l__SWIG_1(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_c__SWIG_0___")]
	public static extern void TD_PDF_PDFContentStream_c__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7, int jarg8);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_c__SWIG_1___")]
	public static extern void TD_PDF_PDFContentStream_c__SWIG_1(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_v___")]
	public static extern void TD_PDF_PDFContentStream_v(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_y___")]
	public static extern void TD_PDF_PDFContentStream_y(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_re___")]
	public static extern void TD_PDF_PDFContentStream_re(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_h___")]
	public static extern void TD_PDF_PDFContentStream_h(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_S___")]
	public static extern void TD_PDF_PDFContentStream_S(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_s___")]
	public static extern void TD_PDF_PDFContentStream_s(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_f___")]
	public static extern void TD_PDF_PDFContentStream_f(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_f_odd___")]
	public static extern void TD_PDF_PDFContentStream_f_odd(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_B___")]
	public static extern void TD_PDF_PDFContentStream_B(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_B_odd___")]
	public static extern void TD_PDF_PDFContentStream_B_odd(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_b___")]
	public static extern void TD_PDF_PDFContentStream_b(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_b_odd___")]
	public static extern void TD_PDF_PDFContentStream_b_odd(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_n___")]
	public static extern void TD_PDF_PDFContentStream_n(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_W___")]
	public static extern void TD_PDF_PDFContentStream_W(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_W_odd___")]
	public static extern void TD_PDF_PDFContentStream_W_odd(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_Tc___")]
	public static extern void TD_PDF_PDFContentStream_Tc(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_Tw___")]
	public static extern void TD_PDF_PDFContentStream_Tw(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_Tz___")]
	public static extern void TD_PDF_PDFContentStream_Tz(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_TL___")]
	public static extern void TD_PDF_PDFContentStream_TL(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_Tf___")]
	public static extern void TD_PDF_PDFContentStream_Tf(HandleRef jarg1, HandleRef jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_Tr___")]
	public static extern void TD_PDF_PDFContentStream_Tr(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_Ts___")]
	public static extern void TD_PDF_PDFContentStream_Ts(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_BT___")]
	public static extern void TD_PDF_PDFContentStream_BT(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_ET___")]
	public static extern void TD_PDF_PDFContentStream_ET(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_Td___")]
	public static extern void TD_PDF_PDFContentStream_Td(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_TD___")]
	public static extern void TD_PDF_PDFContentStream_TD(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_Tm___")]
	public static extern void TD_PDF_PDFContentStream_Tm(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_T_star___")]
	public static extern void TD_PDF_PDFContentStream_T_star(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_Tj___")]
	public static extern void TD_PDF_PDFContentStream_Tj(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_TJ___")]
	public static extern void TD_PDF_PDFContentStream_TJ(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_BDC___")]
	public static extern void TD_PDF_PDFContentStream_BDC(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_BMC___")]
	public static extern void TD_PDF_PDFContentStream_BMC(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_EMC___")]
	public static extern void TD_PDF_PDFContentStream_EMC(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_sh___")]
	public static extern void TD_PDF_PDFContentStream_sh(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_getRealClassName___")]
	public static extern string TD_PDF_PDFContentStream_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFContentStream___")]
	public static extern void delete_TD_PDF_PDFContentStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_setTraits___")]
	public static extern void TD_PDF_PDFDummyContentStream_setTraits(HandleRef jarg1, double jarg2, uint jarg3, uint jarg4, ushort jarg5, ushort jarg6, int jarg7, int jarg8);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_getTraits___")]
	public static extern void TD_PDF_PDFDummyContentStream_getTraits(HandleRef jarg1, out double jarg2, out uint jarg3, out uint jarg4, out ushort jarg5, out ushort jarg6, out TD_PDF_PDFLineCap jarg7, out TD_PDF_PDFLineJoin jarg8);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_Do___")]
	public static extern void TD_PDF_PDFDummyContentStream_Do(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_q___")]
	public static extern void TD_PDF_PDFDummyContentStream_q(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_Q___")]
	public static extern void TD_PDF_PDFDummyContentStream_Q(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_cm___")]
	public static extern void TD_PDF_PDFDummyContentStream_cm(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_w___")]
	public static extern void TD_PDF_PDFDummyContentStream_w(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_J___")]
	public static extern void TD_PDF_PDFDummyContentStream_J(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_d___")]
	public static extern void TD_PDF_PDFDummyContentStream_d(HandleRef jarg1, HandleRef jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_j___")]
	public static extern void TD_PDF_PDFDummyContentStream_j(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_cs___")]
	public static extern void TD_PDF_PDFDummyContentStream_cs(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_gs___")]
	public static extern void TD_PDF_PDFDummyContentStream_gs(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_CS___")]
	public static extern void TD_PDF_PDFDummyContentStream_CS(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_sc___")]
	public static extern void TD_PDF_PDFDummyContentStream_sc(HandleRef jarg1, byte jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_SC___")]
	public static extern void TD_PDF_PDFDummyContentStream_SC(HandleRef jarg1, byte jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_RG__SWIG_0___")]
	public static extern void TD_PDF_PDFDummyContentStream_RG__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, double jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_rg__SWIG_0___")]
	public static extern void TD_PDF_PDFDummyContentStream_rg__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, double jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_RG__SWIG_1___")]
	public static extern void TD_PDF_PDFDummyContentStream_RG__SWIG_1(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_rg__SWIG_1___")]
	public static extern void TD_PDF_PDFDummyContentStream_rg__SWIG_1(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_g___")]
	public static extern void TD_PDF_PDFDummyContentStream_g(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_G___")]
	public static extern void TD_PDF_PDFDummyContentStream_G(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_m__SWIG_0___")]
	public static extern void TD_PDF_PDFDummyContentStream_m__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, int jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_m__SWIG_1___")]
	public static extern void TD_PDF_PDFDummyContentStream_m__SWIG_1(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_l__SWIG_0___")]
	public static extern void TD_PDF_PDFDummyContentStream_l__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, int jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_l__SWIG_1___")]
	public static extern void TD_PDF_PDFDummyContentStream_l__SWIG_1(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_c__SWIG_0___")]
	public static extern void TD_PDF_PDFDummyContentStream_c__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7, int jarg8);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_c__SWIG_1___")]
	public static extern void TD_PDF_PDFDummyContentStream_c__SWIG_1(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_v___")]
	public static extern void TD_PDF_PDFDummyContentStream_v(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_y___")]
	public static extern void TD_PDF_PDFDummyContentStream_y(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_re___")]
	public static extern void TD_PDF_PDFDummyContentStream_re(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_h___")]
	public static extern void TD_PDF_PDFDummyContentStream_h(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_S___")]
	public static extern void TD_PDF_PDFDummyContentStream_S(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_s___")]
	public static extern void TD_PDF_PDFDummyContentStream_s(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_f___")]
	public static extern void TD_PDF_PDFDummyContentStream_f(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_f_odd___")]
	public static extern void TD_PDF_PDFDummyContentStream_f_odd(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_B___")]
	public static extern void TD_PDF_PDFDummyContentStream_B(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_B_odd___")]
	public static extern void TD_PDF_PDFDummyContentStream_B_odd(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_b___")]
	public static extern void TD_PDF_PDFDummyContentStream_b(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_b_odd___")]
	public static extern void TD_PDF_PDFDummyContentStream_b_odd(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_n___")]
	public static extern void TD_PDF_PDFDummyContentStream_n(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_W___")]
	public static extern void TD_PDF_PDFDummyContentStream_W(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_W_odd___")]
	public static extern void TD_PDF_PDFDummyContentStream_W_odd(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_Tc___")]
	public static extern void TD_PDF_PDFDummyContentStream_Tc(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_Tw___")]
	public static extern void TD_PDF_PDFDummyContentStream_Tw(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_Tz___")]
	public static extern void TD_PDF_PDFDummyContentStream_Tz(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_TL___")]
	public static extern void TD_PDF_PDFDummyContentStream_TL(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_Tf___")]
	public static extern void TD_PDF_PDFDummyContentStream_Tf(HandleRef jarg1, HandleRef jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_Tr___")]
	public static extern void TD_PDF_PDFDummyContentStream_Tr(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_Ts___")]
	public static extern void TD_PDF_PDFDummyContentStream_Ts(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_BT___")]
	public static extern void TD_PDF_PDFDummyContentStream_BT(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_ET___")]
	public static extern void TD_PDF_PDFDummyContentStream_ET(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_Td___")]
	public static extern void TD_PDF_PDFDummyContentStream_Td(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_TD___")]
	public static extern void TD_PDF_PDFDummyContentStream_TD(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_Tm___")]
	public static extern void TD_PDF_PDFDummyContentStream_Tm(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_T_star___")]
	public static extern void TD_PDF_PDFDummyContentStream_T_star(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_Tj___")]
	public static extern void TD_PDF_PDFDummyContentStream_Tj(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_TJ___")]
	public static extern void TD_PDF_PDFDummyContentStream_TJ(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_BDC___")]
	public static extern void TD_PDF_PDFDummyContentStream_BDC(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_BMC___")]
	public static extern void TD_PDF_PDFDummyContentStream_BMC(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_EMC___")]
	public static extern void TD_PDF_PDFDummyContentStream_EMC(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_sh___")]
	public static extern void TD_PDF_PDFDummyContentStream_sh(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_scn___")]
	public static extern void TD_PDF_PDFDummyContentStream_scn(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_SCN___")]
	public static extern void TD_PDF_PDFDummyContentStream_SCN(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_TD_PDF_PDFDummyContentStream___")]
	public static extern IntPtr new_TD_PDF_PDFDummyContentStream();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFDummyContentStream___")]
	public static extern void delete_TD_PDF_PDFDummyContentStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectFormDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFXObjectFormDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectFormDictionary_type___")]
	public static extern int TD_PDF_PDFXObjectFormDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectFormDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFXObjectFormDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectFormDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFXObjectFormDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectFormDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFXObjectFormDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFXObjectFormDictionary___")]
	public static extern void delete_TD_PDF_PDFXObjectFormDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_TD_PDF_PDFUnicodeTextHelper___")]
	public static extern IntPtr new_TD_PDF_PDFUnicodeTextHelper();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnicodeTextHelper_enableFixParenthesis__SWIG_0___")]
	public static extern void TD_PDF_PDFUnicodeTextHelper_enableFixParenthesis__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnicodeTextHelper_enableFixParenthesis__SWIG_1___")]
	public static extern void TD_PDF_PDFUnicodeTextHelper_enableFixParenthesis__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnicodeTextHelper_exportUnicodeMarker___")]
	public static extern bool TD_PDF_PDFUnicodeTextHelper_exportUnicodeMarker(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnicodeTextHelper_setExportUnicodeMarker___")]
	public static extern void TD_PDF_PDFUnicodeTextHelper_setExportUnicodeMarker(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFUnicodeTextHelper___")]
	public static extern void delete_TD_PDF_PDFUnicodeTextHelper(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImageDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFImageDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImageDictionary_type___")]
	public static extern int TD_PDF_PDFImageDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImageDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFImageDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImageDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFImageDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImageDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFImageDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFImageDictionary___")]
	public static extern void delete_TD_PDF_PDFImageDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObject_isKindOf___")]
	public static extern bool TD_PDF_PDFXObject_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObject_type___")]
	public static extern int TD_PDF_PDFXObject_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObject_getRealClassName___")]
	public static extern string TD_PDF_PDFXObject_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFXObject___")]
	public static extern void delete_TD_PDF_PDFXObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteger_isKindOf___")]
	public static extern bool TD_PDF_PDFInteger_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteger_type___")]
	public static extern int TD_PDF_PDFInteger_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteger_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFInteger_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteger_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFInteger_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteger_createObject__SWIG_2___")]
	public static extern IntPtr TD_PDF_PDFInteger_createObject__SWIG_2(HandleRef jarg1, int jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteger_createObject__SWIG_3___")]
	public static extern IntPtr TD_PDF_PDFInteger_createObject__SWIG_3(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteger_Export___")]
	public static extern bool TD_PDF_PDFInteger_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteger_setInt32___")]
	public static extern void TD_PDF_PDFInteger_setInt32(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteger_getInt32___")]
	public static extern int TD_PDF_PDFInteger_getInt32(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteger_getRealClassName___")]
	public static extern string TD_PDF_PDFInteger_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFInteger___")]
	public static extern void delete_TD_PDF_PDFInteger(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands4Type3_d0___")]
	public static extern void TD_PDF_PDFIContentCommands4Type3_d0(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands4Type3_d1___")]
	public static extern void TD_PDF_PDFIContentCommands4Type3_d1(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_TD_PDF_PDFIContentCommands4Type3___")]
	public static extern IntPtr new_TD_PDF_PDFIContentCommands4Type3();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFIContentCommands4Type3___")]
	public static extern void delete_TD_PDF_PDFIContentCommands4Type3(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIContentCommands4Type3_director_connect___")]
	public static extern void TD_PDF_PDFIContentCommands4Type3_director_connect(HandleRef jarg1, TD_PDF_PDFIContentCommands4Type3.SwigDelegateTD_PDF_PDFIContentCommands4Type3_0 delegate0, TD_PDF_PDFIContentCommands4Type3.SwigDelegateTD_PDF_PDFIContentCommands4Type3_1 delegate1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPattern_isKindOf___")]
	public static extern bool TD_PDF_PDFTilingPattern_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPattern_type___")]
	public static extern int TD_PDF_PDFTilingPattern_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPattern_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFTilingPattern_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPattern_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFTilingPattern_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPattern_dictionary___")]
	public static extern IntPtr TD_PDF_PDFTilingPattern_dictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPattern_w___")]
	public static extern void TD_PDF_PDFTilingPattern_w(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPattern_getMaxLw___")]
	public static extern double TD_PDF_PDFTilingPattern_getMaxLw(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPattern_expandMaxLw___")]
	public static extern void TD_PDF_PDFTilingPattern_expandMaxLw(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPattern_setTraits___")]
	public static extern void TD_PDF_PDFTilingPattern_setTraits(HandleRef jarg1, double jarg2, uint jarg3, uint jarg4, ushort jarg5, ushort jarg6, int jarg7, int jarg8);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPattern_getRealClassName___")]
	public static extern string TD_PDF_PDFTilingPattern_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFTilingPattern___")]
	public static extern void delete_TD_PDF_PDFTilingPattern(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectForm_isKindOf___")]
	public static extern bool TD_PDF_PDFXObjectForm_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectForm_type___")]
	public static extern int TD_PDF_PDFXObjectForm_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectForm_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFXObjectForm_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectForm_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFXObjectForm_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectForm_dictionary___")]
	public static extern IntPtr TD_PDF_PDFXObjectForm_dictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectForm_w___")]
	public static extern void TD_PDF_PDFXObjectForm_w(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectForm_getMaxLw___")]
	public static extern double TD_PDF_PDFXObjectForm_getMaxLw(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectForm_expandMaxLw___")]
	public static extern void TD_PDF_PDFXObjectForm_expandMaxLw(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectForm_setTraits___")]
	public static extern void TD_PDF_PDFXObjectForm_setTraits(HandleRef jarg1, double jarg2, uint jarg3, uint jarg4, ushort jarg5, ushort jarg6, int jarg7, int jarg8);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectForm_getRealClassName___")]
	public static extern string TD_PDF_PDFXObjectForm_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFXObjectForm___")]
	public static extern void delete_TD_PDF_PDFXObjectForm(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSubDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFSubDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSubDictionary_type___")]
	public static extern int TD_PDF_PDFSubDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSubDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFSubDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSubDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFSubDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSubDictionary_getDefBase___")]
	public static extern string TD_PDF_PDFSubDictionary_getDefBase(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSubDictionary_AddItem___")]
	public static extern bool TD_PDF_PDFSubDictionary_AddItem(HandleRef jarg1, string jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSubDictionary_FindByValue___")]
	public static extern IntPtr TD_PDF_PDFSubDictionary_FindByValue(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSubDictionary_AddUniqueProperty___")]
	public static extern IntPtr TD_PDF_PDFSubDictionary_AddUniqueProperty(HandleRef jarg1, string jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSubDictionary_addItem___")]
	public static extern bool TD_PDF_PDFSubDictionary_addItem(HandleRef jarg1, string jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSubDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFSubDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFSubDictionary___")]
	public static extern void delete_TD_PDF_PDFSubDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArray_isKindOf___")]
	public static extern bool TD_PDF_PDFArray_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArray_type___")]
	public static extern int TD_PDF_PDFArray_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArray_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFArray_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArray_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFArray_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArray_push_int___")]
	public static extern void TD_PDF_PDFArray_push_int(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArray_push_bool___")]
	public static extern void TD_PDF_PDFArray_push_bool(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArray_push_number__SWIG_0___")]
	public static extern void TD_PDF_PDFArray_push_number__SWIG_0(HandleRef jarg1, double jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArray_push_number__SWIG_1___")]
	public static extern void TD_PDF_PDFArray_push_number__SWIG_1(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArray_Export___")]
	public static extern bool TD_PDF_PDFArray_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArray_getRealClassName___")]
	public static extern string TD_PDF_PDFArray_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFArray___")]
	public static extern void delete_TD_PDF_PDFArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumber_isKindOf___")]
	public static extern bool TD_PDF_PDFNumber_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumber_type___")]
	public static extern int TD_PDF_PDFNumber_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumber_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFNumber_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumber_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFNumber_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumber_createObject__SWIG_2___")]
	public static extern IntPtr TD_PDF_PDFNumber_createObject__SWIG_2(HandleRef jarg1, double jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumber_createObject__SWIG_3___")]
	public static extern IntPtr TD_PDF_PDFNumber_createObject__SWIG_3(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumber_Export___")]
	public static extern bool TD_PDF_PDFNumber_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumber_setDouble___")]
	public static extern void TD_PDF_PDFNumber_setDouble(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumber_getDouble___")]
	public static extern double TD_PDF_PDFNumber_getDouble(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumber_getRealClassName___")]
	public static extern string TD_PDF_PDFNumber_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFNumber___")]
	public static extern void delete_TD_PDF_PDFNumber(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_isKindOf___")]
	public static extern bool TD_PDF_PDFDate_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_type___")]
	public static extern int TD_PDF_PDFDate_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFDate_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFDate_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_set__SWIG_0___")]
	public static extern bool TD_PDF_PDFDate_set__SWIG_0(HandleRef jarg1, HandleRef jarg2, sbyte jarg3, sbyte jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_set__SWIG_1___")]
	public static extern bool TD_PDF_PDFDate_set__SWIG_1(HandleRef jarg1, HandleRef jarg2, sbyte jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_set__SWIG_2___")]
	public static extern bool TD_PDF_PDFDate_set__SWIG_2(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_get___")]
	public static extern void TD_PDF_PDFDate_get(HandleRef jarg1, HandleRef jarg2, out sbyte jarg3, out sbyte jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_isOffset2LocalDateValid___")]
	public static extern bool TD_PDF_PDFDate_isOffset2LocalDateValid(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_setOffset2Unknown___")]
	public static extern void TD_PDF_PDFDate_setOffset2Unknown(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_toString__SWIG_0___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFDate_toString__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_toString__SWIG_1___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFDate_toString__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_Export___")]
	public static extern bool TD_PDF_PDFDate_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_getRealClassName___")]
	public static extern string TD_PDF_PDFDate_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFDate___")]
	public static extern void delete_TD_PDF_PDFDate(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_isKindOf___")]
	public static extern bool TD_PDF_PDFTextString_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_type___")]
	public static extern int TD_PDF_PDFTextString_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFTextString_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFTextString_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_createObject__SWIG_2___")]
	public static extern IntPtr TD_PDF_PDFTextString_createObject__SWIG_2(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_createObject__SWIG_3___")]
	public static extern IntPtr TD_PDF_PDFTextString_createObject__SWIG_3(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_createObject_as_OdAnsiString__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFTextString_createObject_as_OdAnsiString__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_createObject_as_OdAnsiString__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFTextString_createObject_as_OdAnsiString__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_isEqualTo___")]
	public static extern bool TD_PDF_PDFTextString_isEqualTo(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_getAsUnicode___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFTextString_getAsUnicode(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_clear___")]
	public static extern void TD_PDF_PDFTextString_clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_isInUnicode___")]
	public static extern bool TD_PDF_PDFTextString_isInUnicode(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_set___")]
	public static extern IntPtr TD_PDF_PDFTextString_set(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_set_as_OdAnsiString___")]
	public static extern IntPtr TD_PDF_PDFTextString_set_as_OdAnsiString(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_Export___")]
	public static extern bool TD_PDF_PDFTextString_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_isAscii___")]
	public static extern bool TD_PDF_PDFTextString_isAscii(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_setRoundBrackets___")]
	public static extern void TD_PDF_PDFTextString_setRoundBrackets(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_getRealClassName___")]
	public static extern string TD_PDF_PDFTextString_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFTextString___")]
	public static extern void delete_TD_PDF_PDFTextString(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImage_isKindOf___")]
	public static extern bool TD_PDF_PDFImage_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImage_type___")]
	public static extern int TD_PDF_PDFImage_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImage_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFImage_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImage_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFImage_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImage_dictionary___")]
	public static extern IntPtr TD_PDF_PDFImage_dictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImage_getStreamData___")]
	public static extern IntPtr TD_PDF_PDFImage_getStreamData(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImage_setStreamData___")]
	public static extern void TD_PDF_PDFImage_setStreamData(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImage_getRealClassName___")]
	public static extern string TD_PDF_PDFImage_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFImage___")]
	public static extern void delete_TD_PDF_PDFImage(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldFlags_isKindOf___")]
	public static extern bool TD_PDF_PDFFieldFlags_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldFlags_type___")]
	public static extern int TD_PDF_PDFFieldFlags_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldFlags_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFFieldFlags_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldFlags_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFFieldFlags_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldFlags_setBit___")]
	public static extern void TD_PDF_PDFFieldFlags_setBit(HandleRef jarg1, int jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldFlags_getBit___")]
	public static extern bool TD_PDF_PDFFieldFlags_getBit(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldFlags_getRealClassName___")]
	public static extern string TD_PDF_PDFFieldFlags_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFieldFlags___")]
	public static extern void delete_TD_PDF_PDFFieldFlags(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_isKindOf___")]
	public static extern bool TD_PDF_PDFFont_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_type___")]
	public static extern int TD_PDF_PDFFont_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFFont_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFFont_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_truncateFont__SWIG_0___")]
	public static extern bool TD_PDF_PDFFont_truncateFont__SWIG_0(HandleRef jarg1, ushort jarg2, ushort jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_truncateFont__SWIG_1___")]
	public static extern bool TD_PDF_PDFFont_truncateFont__SWIG_1(HandleRef jarg1, ushort jarg2, ushort jarg3, IntPtr jarg4, bool jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_truncateFont__SWIG_2___")]
	public static extern bool TD_PDF_PDFFont_truncateFont__SWIG_2(HandleRef jarg1, ushort jarg2, ushort jarg3, IntPtr jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_setPseudoBold___")]
	public static extern void TD_PDF_PDFFont_setPseudoBold(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_setPseudoItalic___")]
	public static extern void TD_PDF_PDFFont_setPseudoItalic(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_isPseudoBold___")]
	public static extern bool TD_PDF_PDFFont_isPseudoBold(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_isPseudoItalic___")]
	public static extern bool TD_PDF_PDFFont_isPseudoItalic(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_setNonUnicodeTable___")]
	public static extern void TD_PDF_PDFFont_setNonUnicodeTable(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_isNonUnicodeTable___")]
	public static extern bool TD_PDF_PDFFont_isNonUnicodeTable(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_getRealClassName___")]
	public static extern string TD_PDF_PDFFont_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFont___")]
	public static extern void delete_TD_PDF_PDFFont(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream4Type3_isKindOf___")]
	public static extern bool TD_PDF_PDFContentStream4Type3_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream4Type3_type___")]
	public static extern int TD_PDF_PDFContentStream4Type3_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream4Type3_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFContentStream4Type3_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream4Type3_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFContentStream4Type3_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream4Type3_d0___")]
	public static extern void TD_PDF_PDFContentStream4Type3_d0(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream4Type3_d1___")]
	public static extern void TD_PDF_PDFContentStream4Type3_d1(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream4Type3_m__SWIG_0___")]
	public static extern void TD_PDF_PDFContentStream4Type3_m__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, int jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream4Type3_m__SWIG_1___")]
	public static extern void TD_PDF_PDFContentStream4Type3_m__SWIG_1(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream4Type3_l__SWIG_0___")]
	public static extern void TD_PDF_PDFContentStream4Type3_l__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, int jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream4Type3_l__SWIG_1___")]
	public static extern void TD_PDF_PDFContentStream4Type3_l__SWIG_1(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream4Type3_getRealClassName___")]
	public static extern string TD_PDF_PDFContentStream4Type3_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFContentStream4Type3___")]
	public static extern void delete_TD_PDF_PDFContentStream4Type3(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPropertiesSubDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFPropertiesSubDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPropertiesSubDictionary_type___")]
	public static extern int TD_PDF_PDFPropertiesSubDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPropertiesSubDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFPropertiesSubDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPropertiesSubDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFPropertiesSubDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPropertiesSubDictionary_getDefBase___")]
	public static extern string TD_PDF_PDFPropertiesSubDictionary_getDefBase(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPropertiesSubDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFPropertiesSubDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFPropertiesSubDictionary___")]
	public static extern void delete_TD_PDF_PDFPropertiesSubDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPatternSubDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFPatternSubDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPatternSubDictionary_type___")]
	public static extern int TD_PDF_PDFPatternSubDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPatternSubDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFPatternSubDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPatternSubDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFPatternSubDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPatternSubDictionary_getDefBase___")]
	public static extern string TD_PDF_PDFPatternSubDictionary_getDefBase(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPatternSubDictionary_hasForm___")]
	public static extern IntPtr TD_PDF_PDFPatternSubDictionary_hasForm(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPatternSubDictionary_getForms___")]
	public static extern void TD_PDF_PDFPatternSubDictionary_getForms(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPatternSubDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFPatternSubDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFPatternSubDictionary___")]
	public static extern void delete_TD_PDF_PDFPatternSubDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingSubDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFShadingSubDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingSubDictionary_type___")]
	public static extern int TD_PDF_PDFShadingSubDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingSubDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFShadingSubDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingSubDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFShadingSubDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingSubDictionary_getDefBase___")]
	public static extern string TD_PDF_PDFShadingSubDictionary_getDefBase(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingSubDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFShadingSubDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFShadingSubDictionary___")]
	public static extern void delete_TD_PDF_PDFShadingSubDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorSpaceSubDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFColorSpaceSubDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorSpaceSubDictionary_type___")]
	public static extern int TD_PDF_PDFColorSpaceSubDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorSpaceSubDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFColorSpaceSubDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorSpaceSubDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFColorSpaceSubDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorSpaceSubDictionary_getDefBase___")]
	public static extern string TD_PDF_PDFColorSpaceSubDictionary_getDefBase(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorSpaceSubDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFColorSpaceSubDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFColorSpaceSubDictionary___")]
	public static extern void delete_TD_PDF_PDFColorSpaceSubDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFExtGStateSubDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFExtGStateSubDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFExtGStateSubDictionary_type___")]
	public static extern int TD_PDF_PDFExtGStateSubDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFExtGStateSubDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFExtGStateSubDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFExtGStateSubDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFExtGStateSubDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFExtGStateSubDictionary_getDefBase___")]
	public static extern string TD_PDF_PDFExtGStateSubDictionary_getDefBase(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFExtGStateSubDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFExtGStateSubDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFExtGStateSubDictionary___")]
	public static extern void delete_TD_PDF_PDFExtGStateSubDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectSubDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFXObjectSubDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectSubDictionary_type___")]
	public static extern int TD_PDF_PDFXObjectSubDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectSubDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFXObjectSubDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectSubDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFXObjectSubDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectSubDictionary_getDefBase___")]
	public static extern string TD_PDF_PDFXObjectSubDictionary_getDefBase(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectSubDictionary_hasForm___")]
	public static extern IntPtr TD_PDF_PDFXObjectSubDictionary_hasForm(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectSubDictionary_getForms___")]
	public static extern void TD_PDF_PDFXObjectSubDictionary_getForms(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectSubDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFXObjectSubDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFXObjectSubDictionary___")]
	public static extern void delete_TD_PDF_PDFXObjectSubDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSchemaDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCollectionSchemaDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSchemaDictionary_type___")]
	public static extern int TD_PDF_PDFCollectionSchemaDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSchemaDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCollectionSchemaDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSchemaDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCollectionSchemaDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSchemaDictionary_getDefBase___")]
	public static extern string TD_PDF_PDFCollectionSchemaDictionary_getDefBase(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSchemaDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCollectionSchemaDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCollectionSchemaDictionary___")]
	public static extern void delete_TD_PDF_PDFCollectionSchemaDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionColorsDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCollectionColorsDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionColorsDictionary_type___")]
	public static extern int TD_PDF_PDFCollectionColorsDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionColorsDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCollectionColorsDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionColorsDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCollectionColorsDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionColorsDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCollectionColorsDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCollectionColorsDictionary___")]
	public static extern void delete_TD_PDF_PDFCollectionColorsDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSplitDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCollectionSplitDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSplitDictionary_type___")]
	public static extern int TD_PDF_PDFCollectionSplitDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSplitDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCollectionSplitDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSplitDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCollectionSplitDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSplitDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCollectionSplitDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCollectionSplitDictionary___")]
	public static extern void delete_TD_PDF_PDFCollectionSplitDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionFoldersDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCollectionFoldersDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionFoldersDictionary_type___")]
	public static extern int TD_PDF_PDFCollectionFoldersDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionFoldersDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCollectionFoldersDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionFoldersDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCollectionFoldersDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionFoldersDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCollectionFoldersDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCollectionFoldersDictionary___")]
	public static extern void delete_TD_PDF_PDFCollectionFoldersDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSortDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCollectionSortDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSortDictionary_type___")]
	public static extern int TD_PDF_PDFCollectionSortDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSortDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCollectionSortDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSortDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCollectionSortDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSortDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCollectionSortDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCollectionSortDictionary___")]
	public static extern void delete_TD_PDF_PDFCollectionSortDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFNameTreeNodeDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeDictionary_type___")]
	public static extern int TD_PDF_PDFNameTreeNodeDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFNameTreeNodeDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFNameTreeNodeDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFNameTreeNodeDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFNameTreeNodeDictionary___")]
	public static extern void delete_TD_PDF_PDFNameTreeNodeDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileParamsDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFEmbeddedFileParamsDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileParamsDictionary_type___")]
	public static extern int TD_PDF_PDFEmbeddedFileParamsDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileParamsDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFEmbeddedFileParamsDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileParamsDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFEmbeddedFileParamsDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileParamsDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFEmbeddedFileParamsDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFEmbeddedFileParamsDictionary___")]
	public static extern void delete_TD_PDF_PDFEmbeddedFileParamsDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFFieldDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldDictionary_type___")]
	public static extern int TD_PDF_PDFFieldDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFFieldDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFieldDictionary___")]
	public static extern void delete_TD_PDF_PDFFieldDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontSubDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFFontSubDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontSubDictionary_type___")]
	public static extern int TD_PDF_PDFFontSubDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontSubDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFFontSubDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontSubDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFFontSubDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontSubDictionary_hasFont___")]
	public static extern IntPtr TD_PDF_PDFFontSubDictionary_hasFont(HandleRef jarg1, string jarg2, ref IntPtr jarg3, [MarshalAs(UnmanagedType.LPWStr)] string jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontSubDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFFontSubDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFontSubDictionary___")]
	public static extern void delete_TD_PDF_PDFFontSubDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFPageDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageDictionary_type___")]
	public static extern int TD_PDF_PDFPageDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFPageDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFPageDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageDictionary_Export___")]
	public static extern bool TD_PDF_PDFPageDictionary_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageDictionary_setParent___")]
	public static extern void TD_PDF_PDFPageDictionary_setParent(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageDictionary_getParent___")]
	public static extern IntPtr TD_PDF_PDFPageDictionary_getParent(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFPageDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFPageDictionary___")]
	public static extern void delete_TD_PDF_PDFPageDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCGroupDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFOCGroupDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCGroupDictionary_type___")]
	public static extern int TD_PDF_PDFOCGroupDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCGroupDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFOCGroupDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCGroupDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFOCGroupDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCGroupDictionary_Export___")]
	public static extern bool TD_PDF_PDFOCGroupDictionary_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCGroupDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFOCGroupDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFOCGroupDictionary___")]
	public static extern void delete_TD_PDF_PDFOCGroupDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFNumberTreeNodeDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeDictionary_type___")]
	public static extern int TD_PDF_PDFNumberTreeNodeDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFNumberTreeNodeDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFNumberTreeNodeDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFNumberTreeNodeDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFNumberTreeNodeDictionary___")]
	public static extern void delete_TD_PDF_PDFNumberTreeNodeDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCollectionDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionDictionary_type___")]
	public static extern int TD_PDF_PDFCollectionDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCollectionDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCollectionDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCollectionDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCollectionDictionary___")]
	public static extern void delete_TD_PDF_PDFCollectionDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNamesDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFNamesDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNamesDictionary_type___")]
	public static extern int TD_PDF_PDFNamesDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNamesDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFNamesDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNamesDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFNamesDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNamesDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFNamesDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFNamesDictionary___")]
	public static extern void delete_TD_PDF_PDFNamesDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dAnimationStyleDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDF3dAnimationStyleDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dAnimationStyleDictionary_type___")]
	public static extern int TD_PDF_PDF3dAnimationStyleDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dAnimationStyleDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDF3dAnimationStyleDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dAnimationStyleDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDF3dAnimationStyleDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dAnimationStyleDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDF3dAnimationStyleDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDF3dAnimationStyleDictionary___")]
	public static extern void delete_TD_PDF_PDF3dAnimationStyleDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnicodeTextStream_isKindOf___")]
	public static extern bool TD_PDF_PDFUnicodeTextStream_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnicodeTextStream_type___")]
	public static extern int TD_PDF_PDFUnicodeTextStream_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnicodeTextStream_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFUnicodeTextStream_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnicodeTextStream_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFUnicodeTextStream_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnicodeTextStream_addString___")]
	public static extern void TD_PDF_PDFUnicodeTextStream_addString(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnicodeTextStream_getRealClassName___")]
	public static extern string TD_PDF_PDFUnicodeTextStream_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFUnicodeTextStream___")]
	public static extern void delete_TD_PDF_PDFUnicodeTextStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMarkupAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFMarkupAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMarkupAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFMarkupAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMarkupAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFMarkupAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMarkupAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFMarkupAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMarkupAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFMarkupAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFMarkupAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFMarkupAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolygonPolyLineAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFPolygonPolyLineAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolygonPolyLineAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFPolygonPolyLineAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolygonPolyLineAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFPolygonPolyLineAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolygonPolyLineAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFPolygonPolyLineAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolygonPolyLineAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFPolygonPolyLineAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFPolygonPolyLineAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFPolygonPolyLineAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextMarkupAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFTextMarkupAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextMarkupAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFTextMarkupAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextMarkupAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFTextMarkupAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextMarkupAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFTextMarkupAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextMarkupAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFTextMarkupAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFTextMarkupAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFTextMarkupAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineItemDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFOutlineItemDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineItemDictionary_type___")]
	public static extern int TD_PDF_PDFOutlineItemDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineItemDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFOutlineItemDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineItemDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFOutlineItemDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineItemDictionary_Export___")]
	public static extern bool TD_PDF_PDFOutlineItemDictionary_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineItemDictionary_AddOutlineItem___")]
	public static extern void TD_PDF_PDFOutlineItemDictionary_AddOutlineItem(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineItemDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFOutlineItemDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFOutlineItemDictionary___")]
	public static extern void delete_TD_PDF_PDFOutlineItemDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStreamDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFEmbeddedFileStreamDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStreamDictionary_type___")]
	public static extern int TD_PDF_PDFEmbeddedFileStreamDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStreamDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFEmbeddedFileStreamDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStreamDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFEmbeddedFileStreamDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStreamDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFEmbeddedFileStreamDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFEmbeddedFileStreamDictionary___")]
	public static extern void delete_TD_PDF_PDFEmbeddedFileStreamDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldChoiceDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFFieldChoiceDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldChoiceDictionary_type___")]
	public static extern int TD_PDF_PDFFieldChoiceDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldChoiceDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFFieldChoiceDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFieldChoiceDictionary___")]
	public static extern void delete_TD_PDF_PDFFieldChoiceDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTriggerEventsDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFTriggerEventsDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTriggerEventsDictionary_type___")]
	public static extern int TD_PDF_PDFTriggerEventsDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTriggerEventsDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFTriggerEventsDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTriggerEventsDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFTriggerEventsDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTriggerEventsDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFTriggerEventsDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFTriggerEventsDictionary___")]
	public static extern void delete_TD_PDF_PDFTriggerEventsDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStreamDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFICCBasedStreamDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStreamDictionary_type___")]
	public static extern int TD_PDF_PDFICCBasedStreamDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStreamDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFICCBasedStreamDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStreamDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFICCBasedStreamDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStreamDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFICCBasedStreamDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFICCBasedStreamDictionary___")]
	public static extern void delete_TD_PDF_PDFICCBasedStreamDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStreamDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFMetadataStreamDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStreamDictionary_type___")]
	public static extern int TD_PDF_PDFMetadataStreamDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStreamDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFMetadataStreamDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStreamDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFMetadataStreamDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStreamDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFMetadataStreamDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFMetadataStreamDictionary___")]
	public static extern void delete_TD_PDF_PDFMetadataStreamDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMemoryStream_isKindOf___")]
	public static extern bool TD_PDF_PDFMemoryStream_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMemoryStream_type___")]
	public static extern int TD_PDF_PDFMemoryStream_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMemoryStream_createObject___")]
	public static extern IntPtr TD_PDF_PDFMemoryStream_createObject();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMemoryStream_getRealClassName___")]
	public static extern string TD_PDF_PDFMemoryStream_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFMemoryStream___")]
	public static extern void delete_TD_PDF_PDFMemoryStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedColorSpace_isKindOf___")]
	public static extern bool TD_PDF_PDFIndexedColorSpace_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedColorSpace_type___")]
	public static extern int TD_PDF_PDFIndexedColorSpace_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedColorSpace_getBaseName___")]
	public static extern IntPtr TD_PDF_PDFIndexedColorSpace_getBaseName(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedColorSpace_getHiVal___")]
	public static extern IntPtr TD_PDF_PDFIndexedColorSpace_getHiVal(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedColorSpace_getLookup___")]
	public static extern IntPtr TD_PDF_PDFIndexedColorSpace_getLookup(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedColorSpace_Export___")]
	public static extern bool TD_PDF_PDFIndexedColorSpace_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedColorSpace_getRealClassName___")]
	public static extern string TD_PDF_PDFIndexedColorSpace_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFIndexedColorSpace___")]
	public static extern void delete_TD_PDF_PDFIndexedColorSpace(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptor_isKindOf___")]
	public static extern bool TD_PDF_PDFFontDescriptor_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptor_type___")]
	public static extern int TD_PDF_PDFFontDescriptor_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptor_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFFontDescriptor_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptor_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFFontDescriptor_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptor_getRealClassName___")]
	public static extern string TD_PDF_PDFFontDescriptor_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFontDescriptor___")]
	public static extern void delete_TD_PDF_PDFFontDescriptor(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFResourceDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFResourceDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFResourceDictionary_type___")]
	public static extern int TD_PDF_PDFResourceDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFResourceDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFResourceDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFResourceDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFResourceDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFResourceDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFResourceDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFResourceDictionary___")]
	public static extern void delete_TD_PDF_PDFResourceDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageNodeDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFPageNodeDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageNodeDictionary_type___")]
	public static extern int TD_PDF_PDFPageNodeDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageNodeDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFPageNodeDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageNodeDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFPageNodeDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageNodeDictionary_Export___")]
	public static extern bool TD_PDF_PDFPageNodeDictionary_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageNodeDictionary_setParent___")]
	public static extern void TD_PDF_PDFPageNodeDictionary_setParent(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageNodeDictionary_getParent___")]
	public static extern IntPtr TD_PDF_PDFPageNodeDictionary_getParent(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageNodeDictionary_AddKids__SWIG_0___")]
	public static extern void TD_PDF_PDFPageNodeDictionary_AddKids__SWIG_0(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageNodeDictionary_AddKids__SWIG_1___")]
	public static extern void TD_PDF_PDFPageNodeDictionary_AddKids__SWIG_1(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFPageNodeDictionary___")]
	public static extern void delete_TD_PDF_PDFPageNodeDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageNodeDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFPageNodeDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCConfigurationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFOCConfigurationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCConfigurationDictionary_type___")]
	public static extern int TD_PDF_PDFOCConfigurationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCConfigurationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFOCConfigurationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCConfigurationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFOCConfigurationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCConfigurationDictionary_addOC__SWIG_0___")]
	public static extern void TD_PDF_PDFOCConfigurationDictionary_addOC__SWIG_0(HandleRef jarg1, HandleRef jarg2, bool jarg3, bool jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCConfigurationDictionary_addOC__SWIG_1___")]
	public static extern void TD_PDF_PDFOCConfigurationDictionary_addOC__SWIG_1(HandleRef jarg1, HandleRef jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCConfigurationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFOCConfigurationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFOCConfigurationDictionary___")]
	public static extern void delete_TD_PDF_PDFOCConfigurationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont_isKindOf___")]
	public static extern bool TD_PDF_PDFCIDFont_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont_type___")]
	public static extern int TD_PDF_PDFCIDFont_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont_truncateFont___")]
	public static extern bool TD_PDF_PDFCIDFont_truncateFont(HandleRef jarg1, ushort jarg2, ushort jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont_getRealClassName___")]
	public static extern string TD_PDF_PDFCIDFont_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCIDFont___")]
	public static extern void delete_TD_PDF_PDFCIDFont(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocumentInformation_isKindOf___")]
	public static extern bool TD_PDF_PDFDocumentInformation_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocumentInformation_type___")]
	public static extern int TD_PDF_PDFDocumentInformation_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocumentInformation_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFDocumentInformation_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocumentInformation_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFDocumentInformation_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocumentInformation_getRealClassName___")]
	public static extern string TD_PDF_PDFDocumentInformation_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFDocumentInformation___")]
	public static extern void delete_TD_PDF_PDFDocumentInformation(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCatalogDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCatalogDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCatalogDictionary_type___")]
	public static extern int TD_PDF_PDFCatalogDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCatalogDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCatalogDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCatalogDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCatalogDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCatalogDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCatalogDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCatalogDictionary___")]
	public static extern void delete_TD_PDF_PDFCatalogDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamFilter_isKindOf___")]
	public static extern bool TD_PDF_PDFStreamFilter_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamFilter_type___")]
	public static extern int TD_PDF_PDFStreamFilter_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamFilter_getName___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFStreamFilter_getName(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamFilter_DecodeStream___")]
	public static extern bool TD_PDF_PDFStreamFilter_DecodeStream(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamFilter_EncodeStream___")]
	public static extern bool TD_PDF_PDFStreamFilter_EncodeStream(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamFilter_getRealClassName___")]
	public static extern string TD_PDF_PDFStreamFilter_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFStreamFilter___")]
	public static extern void delete_TD_PDF_PDFStreamFilter(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFShadingDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingDictionary_type___")]
	public static extern int TD_PDF_PDFShadingDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFShadingDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFShadingDictionary___")]
	public static extern void delete_TD_PDF_PDFShadingDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCMap_isKindOf___")]
	public static extern bool TD_PDF_PDFCMap_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCMap_type___")]
	public static extern int TD_PDF_PDFCMap_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCMap_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCMap_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCMap_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCMap_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCMap_getRealClassName___")]
	public static extern string TD_PDF_PDFCMap_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCMap___")]
	public static extern void delete_TD_PDF_PDFCMap(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStreamDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDF3dStreamDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStreamDictionary_type___")]
	public static extern int TD_PDF_PDF3dStreamDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStreamDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDF3dStreamDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStreamDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDF3dStreamDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStreamDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDF3dStreamDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDF3dStreamDictionary___")]
	public static extern void delete_TD_PDF_PDF3dStreamDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquareCircleAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFSquareCircleAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquareCircleAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFSquareCircleAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquareCircleAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFSquareCircleAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquareCircleAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFSquareCircleAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquareCircleAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFSquareCircleAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFSquareCircleAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFSquareCircleAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFActionDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFActionDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFActionDictionary_type___")]
	public static extern int TD_PDF_PDFActionDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFActionDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFActionDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFActionDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFActionDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFActionDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFActionDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFActionDictionary___")]
	public static extern void delete_TD_PDF_PDFActionDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBorderEffectDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFBorderEffectDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBorderEffectDictionary_type___")]
	public static extern int TD_PDF_PDFBorderEffectDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBorderEffectDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFBorderEffectDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBorderEffectDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFBorderEffectDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBorderEffectDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFBorderEffectDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFBorderEffectDictionary___")]
	public static extern void delete_TD_PDF_PDFBorderEffectDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolyLineAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFPolyLineAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolyLineAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFPolyLineAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolyLineAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFPolyLineAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolyLineAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFPolyLineAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolyLineAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFPolyLineAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFPolyLineAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFPolyLineAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolygonAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFPolygonAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolygonAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFPolygonAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolygonAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFPolygonAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolygonAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFPolygonAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolygonAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFPolygonAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFPolygonAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFPolygonAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCircleAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCircleAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCircleAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFCircleAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCircleAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCircleAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCircleAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCircleAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCircleAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCircleAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCircleAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFCircleAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLineAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFLineAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLineAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFLineAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLineAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFLineAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLineAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFLineAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLineAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFLineAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFLineAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFLineAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCaretAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCaretAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCaretAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFCaretAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCaretAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCaretAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCaretAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCaretAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCaretAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCaretAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCaretAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFCaretAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInkAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFInkAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInkAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFInkAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInkAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFInkAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInkAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFInkAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInkAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFInkAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFInkAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFInkAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStampAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFStampAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStampAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFStampAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStampAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFStampAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStampAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFStampAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStampAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFStampAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFStampAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFStampAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStrikeOutAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFStrikeOutAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStrikeOutAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFStrikeOutAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStrikeOutAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFStrikeOutAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStrikeOutAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFStrikeOutAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStrikeOutAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFStrikeOutAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFStrikeOutAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFStrikeOutAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquigglyAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFSquigglyAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquigglyAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFSquigglyAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquigglyAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFSquigglyAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquigglyAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFSquigglyAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquigglyAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFSquigglyAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFSquigglyAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFSquigglyAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnderlineAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFUnderlineAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnderlineAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFUnderlineAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnderlineAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFUnderlineAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnderlineAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFUnderlineAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnderlineAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFUnderlineAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFUnderlineAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFUnderlineAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFHighlightAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFHighlightAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFHighlightAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFHighlightAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFHighlightAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFHighlightAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFHighlightAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFHighlightAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFHighlightAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFHighlightAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFHighlightAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFHighlightAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionFieldDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCollectionFieldDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionFieldDictionary_type___")]
	public static extern int TD_PDF_PDFCollectionFieldDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionFieldDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCollectionFieldDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionFieldDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCollectionFieldDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionFieldDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCollectionFieldDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCollectionFieldDictionary___")]
	public static extern void delete_TD_PDF_PDFCollectionFieldDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArtifactDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFArtifactDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArtifactDictionary_type___")]
	public static extern int TD_PDF_PDFArtifactDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArtifactDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFArtifactDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArtifactDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFArtifactDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArtifactDictionary_createObject__SWIG_2___")]
	public static extern IntPtr TD_PDF_PDFArtifactDictionary_createObject__SWIG_2(HandleRef jarg1, string jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArtifactDictionary_createObject__SWIG_3___")]
	public static extern IntPtr TD_PDF_PDFArtifactDictionary_createObject__SWIG_3(HandleRef jarg1, string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArtifactDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFArtifactDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFArtifactDictionary___")]
	public static extern void delete_TD_PDF_PDFArtifactDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_CreateBookmark__SWIG_0___")]
	public static extern IntPtr TD_PDF_TD_PDF_HELPER_FUNCS_CreateBookmark__SWIG_0(HandleRef jarg1, HandleRef jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3, int jarg4, HandleRef jarg5, HandleRef jarg6);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_CreateBookmark__SWIG_1___")]
	public static extern IntPtr TD_PDF_TD_PDF_HELPER_FUNCS_CreateBookmark__SWIG_1(HandleRef jarg1, HandleRef jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3, int jarg4, HandleRef jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree__SWIG_0___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree__SWIG_0(HandleRef jarg1, HandleRef jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3, IntPtr jarg4, IntPtr jarg5, HandleRef jarg6);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree__SWIG_1___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree__SWIG_1(HandleRef jarg1, HandleRef jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3, IntPtr jarg4, IntPtr jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree__SWIG_2___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree__SWIG_2(HandleRef jarg1, HandleRef jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3, IntPtr jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree__SWIG_3___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree__SWIG_3(HandleRef jarg1, HandleRef jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_UpdateChildrenBookmarksTree___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_UpdateChildrenBookmarksTree(HandleRef jarg1, HandleRef jarg2, IntPtr jarg3, IntPtr jarg4, HandleRef jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_UpdateThumbnails___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_UpdateThumbnails(HandleRef jarg1, HandleRef jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3, bool jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowExtract_set___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowExtract_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowExtract_get___")]
	public static extern bool TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowExtract_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowAssemble_set___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowAssemble_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowAssemble_get___")]
	public static extern bool TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowAssemble_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowAnnotateAndForm_set___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowAnnotateAndForm_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowAnnotateAndForm_get___")]
	public static extern bool TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowAnnotateAndForm_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowFormFilling_set___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowFormFilling_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowFormFilling_get___")]
	public static extern bool TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowFormFilling_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowModifyOther_set___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowModifyOther_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowModifyOther_get___")]
	public static extern bool TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowModifyOther_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowPrintAll_set___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowPrintAll_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowPrintAll_get___")]
	public static extern bool TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowPrintAll_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowPrintLow_set___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowPrintLow_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowPrintLow_get___")]
	public static extern bool TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams_AllowPrintLow_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams___")]
	public static extern IntPtr new_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams___")]
	public static extern void delete_TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_QPDFHelper_process___")]
	public static extern bool TD_PDF_TD_PDF_HELPER_FUNCS_QPDFHelper_process(ref IntPtr jarg1, ref IntPtr jarg2, bool jarg3, [MarshalAs(UnmanagedType.LPWStr)] string jarg4, [MarshalAs(UnmanagedType.LPWStr)] string jarg5, HandleRef jarg6, HandleRef jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCoordinateSystemDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCoordinateSystemDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCoordinateSystemDictionary_type___")]
	public static extern int TD_PDF_PDFCoordinateSystemDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCoordinateSystemDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCoordinateSystemDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCoordinateSystemDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCoordinateSystemDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCoordinateSystemDictionary_Export___")]
	public static extern bool TD_PDF_PDFCoordinateSystemDictionary_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCoordinateSystemDictionary_SetType___")]
	public static extern void TD_PDF_PDFCoordinateSystemDictionary_SetType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCoordinateSystemDictionary_SetEPSG___")]
	public static extern void TD_PDF_PDFCoordinateSystemDictionary_SetEPSG(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCoordinateSystemDictionary_SetWKT___")]
	public static extern void TD_PDF_PDFCoordinateSystemDictionary_SetWKT(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCoordinateSystemDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCoordinateSystemDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCoordinateSystemDictionary___")]
	public static extern void delete_TD_PDF_PDFCoordinateSystemDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFTextAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFTextAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFTextAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFTextAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFTextAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFTextAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFTextAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPopupAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFPopupAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPopupAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFPopupAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPopupAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFPopupAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPopupAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFPopupAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPopupAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFPopupAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFPopupAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFPopupAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFOutlineDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineDictionary_type___")]
	public static extern int TD_PDF_PDFOutlineDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFOutlineDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFOutlineDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFOutlineDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFOutlineDictionary___")]
	public static extern void delete_TD_PDF_PDFOutlineDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStream_isKindOf___")]
	public static extern bool TD_PDF_PDFEmbeddedFileStream_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStream_type___")]
	public static extern int TD_PDF_PDFEmbeddedFileStream_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStream_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFEmbeddedFileStream_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStream_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFEmbeddedFileStream_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStream_getDictionary___")]
	public static extern IntPtr TD_PDF_PDFEmbeddedFileStream_getDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStream_putData___")]
	public static extern void TD_PDF_PDFEmbeddedFileStream_putData(HandleRef jarg1, string jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStream_getData___")]
	public static extern void TD_PDF_PDFEmbeddedFileStream_getData(HandleRef jarg1, string jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStream_Export___")]
	public static extern bool TD_PDF_PDFEmbeddedFileStream_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStream_getRealClassName___")]
	public static extern string TD_PDF_PDFEmbeddedFileStream_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFEmbeddedFileStream___")]
	public static extern void delete_TD_PDF_PDFEmbeddedFileStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFileSpecificationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFFileSpecificationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFileSpecificationDictionary_type___")]
	public static extern int TD_PDF_PDFFileSpecificationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFileSpecificationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFFileSpecificationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFileSpecificationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFFileSpecificationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFileSpecificationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFFileSpecificationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFileSpecificationDictionary___")]
	public static extern void delete_TD_PDF_PDFFileSpecificationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStateAppearanceSubDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFStateAppearanceSubDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStateAppearanceSubDictionary_type___")]
	public static extern int TD_PDF_PDFStateAppearanceSubDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStateAppearanceSubDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFStateAppearanceSubDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStateAppearanceSubDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFStateAppearanceSubDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStateAppearanceSubDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFStateAppearanceSubDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFStateAppearanceSubDictionary___")]
	public static extern void delete_TD_PDF_PDFStateAppearanceSubDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldComboBoxDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFFieldComboBoxDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldComboBoxDictionary_type___")]
	public static extern int TD_PDF_PDFFieldComboBoxDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldComboBoxDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFFieldComboBoxDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFieldComboBoxDictionary___")]
	public static extern void delete_TD_PDF_PDFFieldComboBoxDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_TD_PDF_PDFFontOptimizer___")]
	public static extern IntPtr new_TD_PDF_PDFFontOptimizer();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFontOptimizer___")]
	public static extern void delete_TD_PDF_PDFFontOptimizer(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontOptimizer_clear___")]
	public static extern void TD_PDF_PDFFontOptimizer_clear(HandleRef jarg1, bool jarg2, bool jarg3, bool jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontOptimizer_addText___")]
	public static extern void TD_PDF_PDFFontOptimizer_addText(HandleRef jarg1, HandleRef jarg2, string jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontOptimizer_addUnicodeText___")]
	public static extern void TD_PDF_PDFFontOptimizer_addUnicodeText(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontOptimizer_Optimize___")]
	public static extern void TD_PDF_PDFFontOptimizer_Optimize(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldListBoxDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFFieldListBoxDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldListBoxDictionary_type___")]
	public static extern int TD_PDF_PDFFieldListBoxDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldListBoxDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFFieldListBoxDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFieldListBoxDictionary___")]
	public static extern void delete_TD_PDF_PDFFieldListBoxDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_dcImageToPdfImage__SWIG_0___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_dcImageToPdfImage__SWIG_0(HandleRef jarg1, HandleRef jarg2, bool jarg3, double jarg4, double jarg5, double jarg6, uint jarg7, HandleRef jarg8, uint jarg9, ushort jarg10, HandleRef jarg11, bool jarg12);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_dcImageToPdfImage__SWIG_1___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_dcImageToPdfImage__SWIG_1(HandleRef jarg1, HandleRef jarg2, bool jarg3, double jarg4, double jarg5, double jarg6, uint jarg7, HandleRef jarg8, uint jarg9, ushort jarg10, HandleRef jarg11);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_addNewImage__SWIG_0___")]
	public static extern IntPtr TD_PDF_TD_PDF_HELPER_FUNCS_addNewImage__SWIG_0(HandleRef jarg1, HandleRef jarg2, bool jarg3, bool jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_addNewImage__SWIG_1___")]
	public static extern IntPtr TD_PDF_TD_PDF_HELPER_FUNCS_addNewImage__SWIG_1(HandleRef jarg1, HandleRef jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_addNewImage__SWIG_2___")]
	public static extern IntPtr TD_PDF_TD_PDF_HELPER_FUNCS_addNewImage__SWIG_2(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_TD_PDF_HELPER_FUNCS_addNewImageAsXobject___")]
	public static extern void TD_PDF_TD_PDF_HELPER_FUNCS_addNewImageAsXobject(HandleRef jarg1, ref IntPtr jarg2, ref IntPtr jarg3, ref IntPtr jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBorderStyleDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFBorderStyleDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBorderStyleDictionary_type___")]
	public static extern int TD_PDF_PDFBorderStyleDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBorderStyleDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFBorderStyleDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBorderStyleDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFBorderStyleDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBorderStyleDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFBorderStyleDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFBorderStyleDictionary___")]
	public static extern void delete_TD_PDF_PDFBorderStyleDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageLabelDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFPageLabelDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageLabelDictionary_type___")]
	public static extern int TD_PDF_PDFPageLabelDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageLabelDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFPageLabelDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageLabelDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFPageLabelDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageLabelDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFPageLabelDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFPageLabelDictionary___")]
	public static extern void delete_TD_PDF_PDFPageLabelDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeElement_isKindOf___")]
	public static extern bool TD_PDF_PDFNumberTreeNodeElement_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeElement_type___")]
	public static extern int TD_PDF_PDFNumberTreeNodeElement_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeElement_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFNumberTreeNodeElement_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeElement_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFNumberTreeNodeElement_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeElement_getIndex___")]
	public static extern int TD_PDF_PDFNumberTreeNodeElement_getIndex(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeElement_setIndex___")]
	public static extern void TD_PDF_PDFNumberTreeNodeElement_setIndex(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeElement_getObject___")]
	public static extern IntPtr TD_PDF_PDFNumberTreeNodeElement_getObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeElement_Export___")]
	public static extern bool TD_PDF_PDFNumberTreeNodeElement_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeElement_createObject__SWIG_2___")]
	public static extern IntPtr TD_PDF_PDFNumberTreeNodeElement_createObject__SWIG_2(HandleRef jarg1, uint jarg2, HandleRef jarg3, bool jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeElement_createObject__SWIG_3___")]
	public static extern IntPtr TD_PDF_PDFNumberTreeNodeElement_createObject__SWIG_3(HandleRef jarg1, uint jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeElement_getRealClassName___")]
	public static extern string TD_PDF_PDFNumberTreeNodeElement_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFNumberTreeNodeElement___")]
	public static extern void delete_TD_PDF_PDFNumberTreeNodeElement(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeNamesElement_isKindOf___")]
	public static extern bool TD_PDF_PDFNameTreeNodeNamesElement_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeNamesElement_type___")]
	public static extern int TD_PDF_PDFNameTreeNodeNamesElement_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeNamesElement_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFNameTreeNodeNamesElement_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeNamesElement_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFNameTreeNodeNamesElement_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeNamesElement_name__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFNameTreeNodeNamesElement_name__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeNamesElement_getObject___")]
	public static extern IntPtr TD_PDF_PDFNameTreeNodeNamesElement_getObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeNamesElement_Export___")]
	public static extern bool TD_PDF_PDFNameTreeNodeNamesElement_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeNamesElement_createObject__SWIG_2___")]
	public static extern IntPtr TD_PDF_PDFNameTreeNodeNamesElement_createObject__SWIG_2(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, HandleRef jarg3, bool jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeNamesElement_createObject__SWIG_3___")]
	public static extern IntPtr TD_PDF_PDFNameTreeNodeNamesElement_createObject__SWIG_3(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeNamesElement_getRealClassName___")]
	public static extern string TD_PDF_PDFNameTreeNodeNamesElement_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFNameTreeNodeNamesElement___")]
	public static extern void delete_TD_PDF_PDFNameTreeNodeNamesElement(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFGoTo3DViewActionDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFGoTo3DViewActionDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFGoTo3DViewActionDictionary_type___")]
	public static extern int TD_PDF_PDFGoTo3DViewActionDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFGoTo3DViewActionDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFGoTo3DViewActionDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFGoTo3DViewActionDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFGoTo3DViewActionDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFGoTo3DViewActionDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFGoTo3DViewActionDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFGoTo3DViewActionDictionary___")]
	public static extern void delete_TD_PDF_PDFGoTo3DViewActionDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFJavaScriptActionDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFJavaScriptActionDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFJavaScriptActionDictionary_type___")]
	public static extern int TD_PDF_PDFJavaScriptActionDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFJavaScriptActionDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFJavaScriptActionDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFJavaScriptActionDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFJavaScriptActionDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFJavaScriptActionDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFJavaScriptActionDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFJavaScriptActionDictionary___")]
	public static extern void delete_TD_PDF_PDFJavaScriptActionDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationFlags_isKindOf___")]
	public static extern bool TD_PDF_PDFAnnotationFlags_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationFlags_type___")]
	public static extern int TD_PDF_PDFAnnotationFlags_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationFlags_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFAnnotationFlags_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationFlags_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFAnnotationFlags_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationFlags_setBit___")]
	public static extern void TD_PDF_PDFAnnotationFlags_setBit(HandleRef jarg1, int jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationFlags_getBit___")]
	public static extern bool TD_PDF_PDFAnnotationFlags_getBit(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationFlags_getRealClassName___")]
	public static extern string TD_PDF_PDFAnnotationFlags_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFAnnotationFlags___")]
	public static extern void delete_TD_PDF_PDFAnnotationFlags(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType1Font_isKindOf___")]
	public static extern bool TD_PDF_PDFType1Font_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType1Font_type___")]
	public static extern int TD_PDF_PDFType1Font_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType1Font_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFType1Font_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType1Font_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFType1Font_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType1Font_setStandardType1Fonts___")]
	public static extern void TD_PDF_PDFType1Font_setStandardType1Fonts(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType1Font_getStandardType1FontsName___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFType1Font_getStandardType1FontsName(int jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType1Font_getTextCapHeight___")]
	public static extern double TD_PDF_PDFType1Font_getTextCapHeight(int jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType1Font_getTextAscender___")]
	public static extern double TD_PDF_PDFType1Font_getTextAscender(int jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType1Font_getTextDescender___")]
	public static extern double TD_PDF_PDFType1Font_getTextDescender(int jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType1Font_getTextBBox___")]
	public static extern IntPtr TD_PDF_PDFType1Font_getTextBBox(int jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType1Font_getTextBaseWidth___")]
	public static extern double TD_PDF_PDFType1Font_getTextBaseWidth(int jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType1Font_getRealClassName___")]
	public static extern string TD_PDF_PDFType1Font_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFType1Font___")]
	public static extern void delete_TD_PDF_PDFType1Font(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAppearanceCharacteristicsDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFAppearanceCharacteristicsDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAppearanceCharacteristicsDictionary_type___")]
	public static extern int TD_PDF_PDFAppearanceCharacteristicsDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAppearanceCharacteristicsDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFAppearanceCharacteristicsDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAppearanceCharacteristicsDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFAppearanceCharacteristicsDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAppearanceCharacteristicsDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFAppearanceCharacteristicsDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFAppearanceCharacteristicsDictionary___")]
	public static extern void delete_TD_PDF_PDFAppearanceCharacteristicsDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAppearanceDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFAppearanceDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAppearanceDictionary_type___")]
	public static extern int TD_PDF_PDFAppearanceDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAppearanceDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFAppearanceDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAppearanceDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFAppearanceDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAppearanceDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFAppearanceDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFAppearanceDictionary___")]
	public static extern void delete_TD_PDF_PDFAppearanceDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldSignDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFFieldSignDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldSignDictionary_type___")]
	public static extern int TD_PDF_PDFFieldSignDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldSignDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFFieldSignDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFieldSignDictionary___")]
	public static extern void delete_TD_PDF_PDFFieldSignDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldRadioBtnDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFFieldRadioBtnDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldRadioBtnDictionary_type___")]
	public static extern int TD_PDF_PDFFieldRadioBtnDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldRadioBtnDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFFieldRadioBtnDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFieldRadioBtnDictionary___")]
	public static extern void delete_TD_PDF_PDFFieldRadioBtnDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldCheckBoxDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFFieldCheckBoxDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldCheckBoxDictionary_type___")]
	public static extern int TD_PDF_PDFFieldCheckBoxDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldCheckBoxDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFFieldCheckBoxDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFieldCheckBoxDictionary___")]
	public static extern void delete_TD_PDF_PDFFieldCheckBoxDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldTextDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFFieldTextDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldTextDictionary_type___")]
	public static extern int TD_PDF_PDFFieldTextDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldTextDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFFieldTextDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFieldTextDictionary___")]
	public static extern void delete_TD_PDF_PDFFieldTextDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldBtnDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFFieldBtnDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldBtnDictionary_type___")]
	public static extern int TD_PDF_PDFFieldBtnDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldBtnDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFFieldBtnDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFieldBtnDictionary___")]
	public static extern void delete_TD_PDF_PDFFieldBtnDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFWidgetAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFWidgetAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFWidgetAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFWidgetAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFWidgetAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFWidgetAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFWidgetAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFWidgetAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFWidgetAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFWidgetAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFWidgetAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFWidgetAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteractiveFormDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFInteractiveFormDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteractiveFormDictionary_type___")]
	public static extern int TD_PDF_PDFInteractiveFormDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteractiveFormDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFInteractiveFormDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteractiveFormDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFInteractiveFormDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteractiveFormDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFInteractiveFormDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFInteractiveFormDictionary___")]
	public static extern void delete_TD_PDF_PDFInteractiveFormDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberFormatDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFNumberFormatDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberFormatDictionary_type___")]
	public static extern int TD_PDF_PDFNumberFormatDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberFormatDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFNumberFormatDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberFormatDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFNumberFormatDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberFormatDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFNumberFormatDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFNumberFormatDictionary___")]
	public static extern void delete_TD_PDF_PDFNumberFormatDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMeasureDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFMeasureDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMeasureDictionary_type___")]
	public static extern int TD_PDF_PDFMeasureDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMeasureDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFMeasureDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMeasureDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFMeasureDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMeasureDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFMeasureDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFMeasureDictionary___")]
	public static extern void delete_TD_PDF_PDFMeasureDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFViewportDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFViewportDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFViewportDictionary_type___")]
	public static extern int TD_PDF_PDFViewportDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFViewportDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFViewportDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFViewportDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFViewportDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFViewportDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFViewportDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFViewportDictionary___")]
	public static extern void delete_TD_PDF_PDFViewportDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStream_isKindOf___")]
	public static extern bool TD_PDF_PDFICCBasedStream_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStream_type___")]
	public static extern int TD_PDF_PDFICCBasedStream_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStream_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFICCBasedStream_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStream_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFICCBasedStream_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStream_getDictionary___")]
	public static extern IntPtr TD_PDF_PDFICCBasedStream_getDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStream_Export___")]
	public static extern bool TD_PDF_PDFICCBasedStream_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStream_getRealClassName___")]
	public static extern string TD_PDF_PDFICCBasedStream_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFICCBasedStream___")]
	public static extern void delete_TD_PDF_PDFICCBasedStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_isKindOf___")]
	public static extern bool TD_PDF_PDFMetadataStream_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_type___")]
	public static extern int TD_PDF_PDFMetadataStream_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFMetadataStream_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFMetadataStream_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_getDictionary___")]
	public static extern IntPtr TD_PDF_PDFMetadataStream_getDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_putData___")]
	public static extern void TD_PDF_PDFMetadataStream_putData(HandleRef jarg1, string jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_getData___")]
	public static extern void TD_PDF_PDFMetadataStream_getData(HandleRef jarg1, string jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_setTitle___")]
	public static extern void TD_PDF_PDFMetadataStream_setTitle(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_setAuthor___")]
	public static extern void TD_PDF_PDFMetadataStream_setAuthor(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_setSubject___")]
	public static extern void TD_PDF_PDFMetadataStream_setSubject(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_setKeywords___")]
	public static extern void TD_PDF_PDFMetadataStream_setKeywords(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_setCreator___")]
	public static extern void TD_PDF_PDFMetadataStream_setCreator(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_setProducer___")]
	public static extern void TD_PDF_PDFMetadataStream_setProducer(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_setCreationDate___")]
	public static extern void TD_PDF_PDFMetadataStream_setCreationDate(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_setPdfALevelConf___")]
	public static extern void TD_PDF_PDFMetadataStream_setPdfALevelConf(HandleRef jarg1, ushort jarg2, ushort jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_Export___")]
	public static extern bool TD_PDF_PDFMetadataStream_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_getRealClassName___")]
	public static extern string TD_PDF_PDFMetadataStream_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFMetadataStream___")]
	public static extern void delete_TD_PDF_PDFMetadataStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutputIntentsDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFOutputIntentsDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutputIntentsDictionary_type___")]
	public static extern int TD_PDF_PDFOutputIntentsDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutputIntentsDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFOutputIntentsDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutputIntentsDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFOutputIntentsDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutputIntentsDictionary_Export___")]
	public static extern bool TD_PDF_PDFOutputIntentsDictionary_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutputIntentsDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFOutputIntentsDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFOutputIntentsDictionary___")]
	public static extern void delete_TD_PDF_PDFOutputIntentsDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTempFileStream_isKindOf___")]
	public static extern bool TD_PDF_PDFTempFileStream_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTempFileStream_type___")]
	public static extern int TD_PDF_PDFTempFileStream_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTempFileStream_createObject___")]
	public static extern IntPtr TD_PDF_PDFTempFileStream_createObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTempFileStream_putBytes___")]
	public static extern void TD_PDF_PDFTempFileStream_putBytes(HandleRef jarg1, IntPtr jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTempFileStream_putByte___")]
	public static extern void TD_PDF_PDFTempFileStream_putByte(HandleRef jarg1, byte jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFTempFileStream___")]
	public static extern void delete_TD_PDF_PDFTempFileStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTempFileStream_getRealClassName___")]
	public static extern string TD_PDF_PDFTempFileStream_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeFilter_isKindOf___")]
	public static extern bool TD_PDF_PDFFlateDecodeFilter_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeFilter_type___")]
	public static extern int TD_PDF_PDFFlateDecodeFilter_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeFilter_createObject___")]
	public static extern IntPtr TD_PDF_PDFFlateDecodeFilter_createObject();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeFilter_setTmpStream___")]
	public static extern void TD_PDF_PDFFlateDecodeFilter_setTmpStream(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeFilter_getName___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFFlateDecodeFilter_getName(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeFilter_DecodeStream___")]
	public static extern bool TD_PDF_PDFFlateDecodeFilter_DecodeStream(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeFilter_EncodeStream___")]
	public static extern bool TD_PDF_PDFFlateDecodeFilter_EncodeStream(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeFilter_getRealClassName___")]
	public static extern string TD_PDF_PDFFlateDecodeFilter_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFlateDecodeFilter___")]
	public static extern void delete_TD_PDF_PDFFlateDecodeFilter(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeFilter_isKindOf___")]
	public static extern bool TD_PDF_PDFDCTDecodeFilter_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeFilter_type___")]
	public static extern int TD_PDF_PDFDCTDecodeFilter_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeFilter_createObject___")]
	public static extern IntPtr TD_PDF_PDFDCTDecodeFilter_createObject();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeFilter_getName___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFDCTDecodeFilter_getName(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeFilter_DecodeStream___")]
	public static extern bool TD_PDF_PDFDCTDecodeFilter_DecodeStream(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeFilter_EncodeStream___")]
	public static extern bool TD_PDF_PDFDCTDecodeFilter_EncodeStream(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeFilter_getRealClassName___")]
	public static extern string TD_PDF_PDFDCTDecodeFilter_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFDCTDecodeFilter___")]
	public static extern void delete_TD_PDF_PDFDCTDecodeFilter(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeFilter_isKindOf___")]
	public static extern bool TD_PDF_PDFCCITTFaxDecodeFilter_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeFilter_type___")]
	public static extern int TD_PDF_PDFCCITTFaxDecodeFilter_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeFilter_createObject___")]
	public static extern IntPtr TD_PDF_PDFCCITTFaxDecodeFilter_createObject();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeFilter_getName___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFCCITTFaxDecodeFilter_getName(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeFilter_DecodeStream___")]
	public static extern bool TD_PDF_PDFCCITTFaxDecodeFilter_DecodeStream(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeFilter_EncodeStream___")]
	public static extern bool TD_PDF_PDFCCITTFaxDecodeFilter_EncodeStream(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeFilter_getRealClassName___")]
	public static extern string TD_PDF_PDFCCITTFaxDecodeFilter_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCCITTFaxDecodeFilter___")]
	public static extern void delete_TD_PDF_PDFCCITTFaxDecodeFilter(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFontStreamDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFEmbeddedFontStreamDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFontStreamDictionary_type___")]
	public static extern int TD_PDF_PDFEmbeddedFontStreamDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFontStreamDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFEmbeddedFontStreamDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFontStreamDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFEmbeddedFontStreamDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFontStreamDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFEmbeddedFontStreamDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFEmbeddedFontStreamDictionary___")]
	public static extern void delete_TD_PDF_PDFEmbeddedFontStreamDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDifferencesArray_isKindOf___")]
	public static extern bool TD_PDF_PDFDifferencesArray_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDifferencesArray_type___")]
	public static extern int TD_PDF_PDFDifferencesArray_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDifferencesArray_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFDifferencesArray_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDifferencesArray_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFDifferencesArray_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDifferencesArray_add___")]
	public static extern bool TD_PDF_PDFDifferencesArray_add(HandleRef jarg1, ushort jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDifferencesArray_getRealClassName___")]
	public static extern string TD_PDF_PDFDifferencesArray_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFDifferencesArray___")]
	public static extern void delete_TD_PDF_PDFDifferencesArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedRGBColorSpace_isKindOf___")]
	public static extern bool TD_PDF_PDFIndexedRGBColorSpace_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedRGBColorSpace_type___")]
	public static extern int TD_PDF_PDFIndexedRGBColorSpace_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedRGBColorSpace_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFIndexedRGBColorSpace_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedRGBColorSpace_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFIndexedRGBColorSpace_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedRGBColorSpace_getRealClassName___")]
	public static extern string TD_PDF_PDFIndexedRGBColorSpace_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFIndexedRGBColorSpace___")]
	public static extern void delete_TD_PDF_PDFIndexedRGBColorSpace(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptorFlags_isKindOf___")]
	public static extern bool TD_PDF_PDFFontDescriptorFlags_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptorFlags_type___")]
	public static extern int TD_PDF_PDFFontDescriptorFlags_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptorFlags_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFFontDescriptorFlags_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptorFlags_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFFontDescriptorFlags_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptorFlags_setBit___")]
	public static extern void TD_PDF_PDFFontDescriptorFlags_setBit(HandleRef jarg1, int jarg2, bool jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptorFlags_getBit___")]
	public static extern bool TD_PDF_PDFFontDescriptorFlags_getBit(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptorFlags_getRealClassName___")]
	public static extern string TD_PDF_PDFFontDescriptorFlags_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFontDescriptorFlags___")]
	public static extern void delete_TD_PDF_PDFFontDescriptorFlags(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCPropertiesDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFOCPropertiesDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCPropertiesDictionary_type___")]
	public static extern int TD_PDF_PDFOCPropertiesDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCPropertiesDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFOCPropertiesDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCPropertiesDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFOCPropertiesDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCPropertiesDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFOCPropertiesDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFOCPropertiesDictionary___")]
	public static extern void delete_TD_PDF_PDFOCPropertiesDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptor4CIDFont_isKindOf___")]
	public static extern bool TD_PDF_PDFFontDescriptor4CIDFont_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptor4CIDFont_type___")]
	public static extern int TD_PDF_PDFFontDescriptor4CIDFont_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptor4CIDFont_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFFontDescriptor4CIDFont_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptor4CIDFont_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFFontDescriptor4CIDFont_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptor4CIDFont_truncateFont___")]
	public static extern bool TD_PDF_PDFFontDescriptor4CIDFont_truncateFont(HandleRef jarg1, ushort jarg2, ushort jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptor4CIDFont_getRealClassName___")]
	public static extern string TD_PDF_PDFFontDescriptor4CIDFont_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFontDescriptor4CIDFont___")]
	public static extern void delete_TD_PDF_PDFFontDescriptor4CIDFont(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRGBStream_isKindOf___")]
	public static extern bool TD_PDF_PDFRGBStream_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRGBStream_type___")]
	public static extern int TD_PDF_PDFRGBStream_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRGBStream_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFRGBStream_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRGBStream_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFRGBStream_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRGBStream_addRGB__SWIG_0___")]
	public static extern void TD_PDF_PDFRGBStream_addRGB__SWIG_0(HandleRef jarg1, IntPtr jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRGBStream_addRGB__SWIG_1___")]
	public static extern void TD_PDF_PDFRGBStream_addRGB__SWIG_1(HandleRef jarg1, byte jarg2, byte jarg3, byte jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRGBStream_getRealClassName___")]
	public static extern string TD_PDF_PDFRGBStream_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFRGBStream___")]
	public static extern void delete_TD_PDF_PDFRGBStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont0_isKindOf___")]
	public static extern bool TD_PDF_PDFCIDFont0_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont0_type___")]
	public static extern int TD_PDF_PDFCIDFont0_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont0_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCIDFont0_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont0_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCIDFont0_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont0_truncateFont__SWIG_0___")]
	public static extern bool TD_PDF_PDFCIDFont0_truncateFont__SWIG_0(HandleRef jarg1, ushort jarg2, ushort jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont0_truncateFont__SWIG_1___")]
	public static extern bool TD_PDF_PDFCIDFont0_truncateFont__SWIG_1(HandleRef jarg1, ushort jarg2, ushort jarg3, IntPtr jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont0_getRealClassName___")]
	public static extern string TD_PDF_PDFCIDFont0_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCIDFont0___")]
	public static extern void delete_TD_PDF_PDFCIDFont0(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCManager_clearLayersData___")]
	public static extern void TD_PDF_PDFOCManager_clearLayersData();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCManager_CreateOC4Layer__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFOCManager_CreateOC4Layer__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string jarg1, HandleRef jarg2, HandleRef jarg3, bool jarg4, bool jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCManager_CreateOC4Layer__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFOCManager_CreateOC4Layer__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string jarg1, HandleRef jarg2, HandleRef jarg3, bool jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCManager_createOCG___")]
	public static extern IntPtr TD_PDF_PDFOCManager_createOCG([MarshalAs(UnmanagedType.LPWStr)] string jarg1, HandleRef jarg2, bool jarg3, bool jarg4, HandleRef jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCManager_getOCGbyName___")]
	public static extern IntPtr TD_PDF_PDFOCManager_getOCGbyName([MarshalAs(UnmanagedType.LPWStr)] string jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCManager_getOCGNodeByName___")]
	public static extern IntPtr TD_PDF_PDFOCManager_getOCGNodeByName([MarshalAs(UnmanagedType.LPWStr)] string jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType3Font_isKindOf___")]
	public static extern bool TD_PDF_PDFType3Font_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType3Font_type___")]
	public static extern int TD_PDF_PDFType3Font_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType3Font_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFType3Font_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType3Font_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFType3Font_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType3Font_setLineWeigth___")]
	public static extern void TD_PDF_PDFType3Font_setLineWeigth(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType3Font_getLineWeigth___")]
	public static extern double TD_PDF_PDFType3Font_getLineWeigth(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType3Font_setScale___")]
	public static extern void TD_PDF_PDFType3Font_setScale(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType3Font_getScale___")]
	public static extern double TD_PDF_PDFType3Font_getScale(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType3Font_getRealClassName___")]
	public static extern string TD_PDF_PDFType3Font_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFType3Font___")]
	public static extern void delete_TD_PDF_PDFType3Font(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont2_isKindOf___")]
	public static extern bool TD_PDF_PDFCIDFont2_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont2_type___")]
	public static extern int TD_PDF_PDFCIDFont2_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont2_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCIDFont2_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont2_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCIDFont2_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont2_truncateFont__SWIG_0___")]
	public static extern bool TD_PDF_PDFCIDFont2_truncateFont__SWIG_0(HandleRef jarg1, ushort jarg2, ushort jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont2_truncateFont__SWIG_1___")]
	public static extern bool TD_PDF_PDFCIDFont2_truncateFont__SWIG_1(HandleRef jarg1, ushort jarg2, ushort jarg3, IntPtr jarg4, bool jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont2_truncateFont__SWIG_2___")]
	public static extern bool TD_PDF_PDFCIDFont2_truncateFont__SWIG_2(HandleRef jarg1, ushort jarg2, ushort jarg3, IntPtr jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont2_getRealClassName___")]
	public static extern string TD_PDF_PDFCIDFont2_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCIDFont2___")]
	public static extern void delete_TD_PDF_PDFCIDFont2(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCMapDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCMapDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCMapDictionary_type___")]
	public static extern int TD_PDF_PDFCMapDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCMapDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCMapDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCMapDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCMapDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCMapDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCMapDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCMapDictionary___")]
	public static extern void delete_TD_PDF_PDFCMapDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingPattern_isKindOf___")]
	public static extern bool TD_PDF_PDFShadingPattern_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingPattern_type___")]
	public static extern int TD_PDF_PDFShadingPattern_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingPattern_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFShadingPattern_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingPattern_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFShadingPattern_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingPattern_getRealClassName___")]
	public static extern string TD_PDF_PDFShadingPattern_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFShadingPattern___")]
	public static extern void delete_TD_PDF_PDFShadingPattern(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType0Font_isKindOf___")]
	public static extern bool TD_PDF_PDFType0Font_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType0Font_type___")]
	public static extern int TD_PDF_PDFType0Font_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType0Font_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFType0Font_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType0Font_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFType0Font_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType0Font_truncateFont__SWIG_0___")]
	public static extern bool TD_PDF_PDFType0Font_truncateFont__SWIG_0(HandleRef jarg1, ushort jarg2, ushort jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType0Font_truncateFont__SWIG_1___")]
	public static extern bool TD_PDF_PDFType0Font_truncateFont__SWIG_1(HandleRef jarg1, ushort jarg2, ushort jarg3, IntPtr jarg4, bool jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType0Font_truncateFont__SWIG_2___")]
	public static extern bool TD_PDF_PDFType0Font_truncateFont__SWIG_2(HandleRef jarg1, ushort jarg2, ushort jarg3, IntPtr jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType0Font_getRealClassName___")]
	public static extern string TD_PDF_PDFType0Font_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFType0Font___")]
	public static extern void delete_TD_PDF_PDFType0Font(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorKeyMaskArray_isKindOf___")]
	public static extern bool TD_PDF_PDFColorKeyMaskArray_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorKeyMaskArray_type___")]
	public static extern int TD_PDF_PDFColorKeyMaskArray_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorKeyMaskArray_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFColorKeyMaskArray_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorKeyMaskArray_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFColorKeyMaskArray_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorKeyMaskArray_AddSingleColorMask___")]
	public static extern void TD_PDF_PDFColorKeyMaskArray_AddSingleColorMask(HandleRef jarg1, byte jarg2, byte jarg3, byte jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorKeyMaskArray_AddColorRangeMask___")]
	public static extern void TD_PDF_PDFColorKeyMaskArray_AddColorRangeMask(HandleRef jarg1, byte jarg2, byte jarg3, byte jarg4, byte jarg5, byte jarg6, byte jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorKeyMaskArray_AddSingleColorIndexMask___")]
	public static extern void TD_PDF_PDFColorKeyMaskArray_AddSingleColorIndexMask(HandleRef jarg1, byte jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorKeyMaskArray_AddColorIndexRangeMask___")]
	public static extern void TD_PDF_PDFColorKeyMaskArray_AddColorIndexRangeMask(HandleRef jarg1, byte jarg2, byte jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorKeyMaskArray_getRealClassName___")]
	public static extern string TD_PDF_PDFColorKeyMaskArray_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFColorKeyMaskArray___")]
	public static extern void delete_TD_PDF_PDFColorKeyMaskArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_TD_PDF_PDFDocument___")]
	public static extern IntPtr new_TD_PDF_PDFDocument();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_clearDictionaries___")]
	public static extern void TD_PDF_PDFDocument_clearDictionaries(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_getUniqueTempPath___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFDocument_getUniqueTempPath(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_getUniqueKey___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFDocument_getUniqueKey(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_setTmpStream___")]
	public static extern void TD_PDF_PDFDocument_setTmpStream(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_encodingEnabled___")]
	public static extern bool TD_PDF_PDFDocument_encodingEnabled(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_enableEncoding___")]
	public static extern void TD_PDF_PDFDocument_enableEncoding(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_encodingASCIIHEXEnabled___")]
	public static extern bool TD_PDF_PDFDocument_encodingASCIIHEXEnabled(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_enableEncodingASCIIHEX___")]
	public static extern void TD_PDF_PDFDocument_enableEncodingASCIIHEX(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_encodingDCTEnabled___")]
	public static extern bool TD_PDF_PDFDocument_encodingDCTEnabled(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_enableEncodingDCT___")]
	public static extern void TD_PDF_PDFDocument_enableEncodingDCT(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_isPdfA___")]
	public static extern bool TD_PDF_PDFDocument_isPdfA(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_setPdfA___")]
	public static extern void TD_PDF_PDFDocument_setPdfA(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_useQPDF___")]
	public static extern bool TD_PDF_PDFDocument_useQPDF(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_setUseQPDF___")]
	public static extern void TD_PDF_PDFDocument_setUseQPDF(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_getVersion___")]
	public static extern IntPtr TD_PDF_PDFDocument_getVersion(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_Export___")]
	public static extern bool TD_PDF_PDFDocument_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_ExportSwigExplicitTD_PDF_PDFDocument___")]
	public static extern bool TD_PDF_PDFDocument_ExportSwigExplicitTD_PDF_PDFDocument(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_AddObject___")]
	public static extern bool TD_PDF_PDFDocument_AddObject(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_RemoveObject___")]
	public static extern void TD_PDF_PDFDocument_RemoveObject(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_setRoot___")]
	public static extern bool TD_PDF_PDFDocument_setRoot(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_Root___")]
	public static extern IntPtr TD_PDF_PDFDocument_Root(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_setDocumentInformation___")]
	public static extern bool TD_PDF_PDFDocument_setDocumentInformation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_getDocumentInformation___")]
	public static extern IntPtr TD_PDF_PDFDocument_getDocumentInformation(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_getNextObjectID___")]
	public static extern IntPtr TD_PDF_PDFDocument_getNextObjectID(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_getLastObjectID___")]
	public static extern IntPtr TD_PDF_PDFDocument_getLastObjectID(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_RegistryFilter___")]
	public static extern bool TD_PDF_PDFDocument_RegistryFilter(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_HasFilter___")]
	public static extern bool TD_PDF_PDFDocument_HasFilter(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_GetFilter___")]
	public static extern IntPtr TD_PDF_PDFDocument_GetFilter(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFDocument___")]
	public static extern void delete_TD_PDF_PDFDocument(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocument_director_connect___")]
	public static extern void TD_PDF_PDFDocument_director_connect(HandleRef jarg1, TD_PDF_PDFDocument.SwigDelegateTD_PDF_PDFDocument_0 delegate0);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTrueTypeFont_isKindOf___")]
	public static extern bool TD_PDF_PDFTrueTypeFont_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTrueTypeFont_type___")]
	public static extern int TD_PDF_PDFTrueTypeFont_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTrueTypeFont_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFTrueTypeFont_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTrueTypeFont_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFTrueTypeFont_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTrueTypeFont_truncateFont__SWIG_0___")]
	public static extern bool TD_PDF_PDFTrueTypeFont_truncateFont__SWIG_0(HandleRef jarg1, ushort jarg2, ushort jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTrueTypeFont_truncateFont__SWIG_1___")]
	public static extern bool TD_PDF_PDFTrueTypeFont_truncateFont__SWIG_1(HandleRef jarg1, ushort jarg2, ushort jarg3, IntPtr jarg4, bool jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTrueTypeFont_truncateFont__SWIG_2___")]
	public static extern bool TD_PDF_PDFTrueTypeFont_truncateFont__SWIG_2(HandleRef jarg1, ushort jarg2, ushort jarg3, IntPtr jarg4);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTrueTypeFont_getRealClassName___")]
	public static extern string TD_PDF_PDFTrueTypeFont_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFTrueTypeFont___")]
	public static extern void delete_TD_PDF_PDFTrueTypeFont(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEncodingDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFEncodingDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEncodingDictionary_type___")]
	public static extern int TD_PDF_PDFEncodingDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEncodingDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFEncodingDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEncodingDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFEncodingDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEncodingDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFEncodingDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFEncodingDictionary___")]
	public static extern void delete_TD_PDF_PDFEncodingDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDeviceGrayColorSpace_isKindOf___")]
	public static extern bool TD_PDF_PDFDeviceGrayColorSpace_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDeviceGrayColorSpace_type___")]
	public static extern int TD_PDF_PDFDeviceGrayColorSpace_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDeviceGrayColorSpace_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFDeviceGrayColorSpace_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDeviceGrayColorSpace_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFDeviceGrayColorSpace_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDeviceGrayColorSpace_Export___")]
	public static extern bool TD_PDF_PDFDeviceGrayColorSpace_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDeviceGrayColorSpace_getRealClassName___")]
	public static extern string TD_PDF_PDFDeviceGrayColorSpace_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFDeviceGrayColorSpace___")]
	public static extern void delete_TD_PDF_PDFDeviceGrayColorSpace(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontMatrix_isKindOf___")]
	public static extern bool TD_PDF_PDFFontMatrix_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontMatrix_type___")]
	public static extern int TD_PDF_PDFFontMatrix_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontMatrix_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFFontMatrix_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontMatrix_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFFontMatrix_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontMatrix_set___")]
	public static extern void TD_PDF_PDFFontMatrix_set(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, double jarg6, double jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontMatrix_get___")]
	public static extern void TD_PDF_PDFFontMatrix_get(HandleRef jarg1, out double jarg2, out double jarg3, out double jarg4, out double jarg5, out double jarg6, out double jarg7);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontMatrix_getRealClassName___")]
	public static extern string TD_PDF_PDFFontMatrix_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFontMatrix___")]
	public static extern void delete_TD_PDF_PDFFontMatrix(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNullObject_isKindOf___")]
	public static extern bool TD_PDF_PDFNullObject_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNullObject_type___")]
	public static extern int TD_PDF_PDFNullObject_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNullObject_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFNullObject_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNullObject_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFNullObject_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNullObject_Export___")]
	public static extern bool TD_PDF_PDFNullObject_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNullObject_getRealClassName___")]
	public static extern string TD_PDF_PDFNullObject_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFNullObject___")]
	public static extern void delete_TD_PDF_PDFNullObject(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFASCIIHexDecodeFilter_isKindOf___")]
	public static extern bool TD_PDF_PDFASCIIHexDecodeFilter_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFASCIIHexDecodeFilter_type___")]
	public static extern int TD_PDF_PDFASCIIHexDecodeFilter_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFASCIIHexDecodeFilter_createObject___")]
	public static extern IntPtr TD_PDF_PDFASCIIHexDecodeFilter_createObject();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFASCIIHexDecodeFilter_getName___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFASCIIHexDecodeFilter_getName(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFASCIIHexDecodeFilter_DecodeStream___")]
	public static extern bool TD_PDF_PDFASCIIHexDecodeFilter_DecodeStream(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFASCIIHexDecodeFilter_EncodeStream___")]
	public static extern bool TD_PDF_PDFASCIIHexDecodeFilter_EncodeStream(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFASCIIHexDecodeFilter_getRealClassName___")]
	public static extern string TD_PDF_PDFASCIIHexDecodeFilter_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFASCIIHexDecodeFilter___")]
	public static extern void delete_TD_PDF_PDFASCIIHexDecodeFilter(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDSystemInfo_isKindOf___")]
	public static extern bool TD_PDF_PDFCIDSystemInfo_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDSystemInfo_type___")]
	public static extern int TD_PDF_PDFCIDSystemInfo_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDSystemInfo_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCIDSystemInfo_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDSystemInfo_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCIDSystemInfo_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDSystemInfo_getRealClassName___")]
	public static extern string TD_PDF_PDFCIDSystemInfo_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCIDSystemInfo___")]
	public static extern void delete_TD_PDF_PDFCIDSystemInfo(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontFileStream_isKindOf___")]
	public static extern bool TD_PDF_PDFFontFileStream_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontFileStream_type___")]
	public static extern int TD_PDF_PDFFontFileStream_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontFileStream_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFFontFileStream_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontFileStream_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFFontFileStream_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontFileStream_setFontFileName___")]
	public static extern void TD_PDF_PDFFontFileStream_setFontFileName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontFileStream_getFontFileName___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFFontFileStream_getFontFileName(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontFileStream_putData___")]
	public static extern void TD_PDF_PDFFontFileStream_putData(HandleRef jarg1, string jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontFileStream_getData___")]
	public static extern void TD_PDF_PDFFontFileStream_getData(HandleRef jarg1, string jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontFileStream_getRealClassName___")]
	public static extern string TD_PDF_PDFFontFileStream_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFontFileStream___")]
	public static extern void delete_TD_PDF_PDFFontFileStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4StreamDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFShadingT4StreamDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4StreamDictionary_type___")]
	public static extern int TD_PDF_PDFShadingT4StreamDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4StreamDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFShadingT4StreamDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4StreamDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFShadingT4StreamDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4StreamDictionary_setDecode__SWIG_0___")]
	public static extern void TD_PDF_PDFShadingT4StreamDictionary_setDecode__SWIG_0(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5, bool jarg6);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4StreamDictionary_setDecode__SWIG_1___")]
	public static extern void TD_PDF_PDFShadingT4StreamDictionary_setDecode__SWIG_1(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4StreamDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFShadingT4StreamDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFShadingT4StreamDictionary___")]
	public static extern void delete_TD_PDF_PDFShadingT4StreamDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4_isKindOf___")]
	public static extern bool TD_PDF_PDFShadingT4_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4_type___")]
	public static extern int TD_PDF_PDFShadingT4_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFShadingT4_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFShadingT4_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4_preFill___")]
	public static extern void TD_PDF_PDFShadingT4_preFill(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4_postFill___")]
	public static extern void TD_PDF_PDFShadingT4_postFill(HandleRef jarg1, double jarg2, double jarg3, double jarg4, double jarg5);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4_addTriangle___")]
	public static extern void TD_PDF_PDFShadingT4_addTriangle(HandleRef jarg1, uint jarg2, uint jarg3, uint jarg4, uint jarg5, uint jarg6, uint jarg7, byte jarg8, byte jarg9, byte jarg10, byte jarg11, byte jarg12, byte jarg13, byte jarg14, byte jarg15, byte jarg16);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4_getRealClassName___")]
	public static extern string TD_PDF_PDFShadingT4_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFShadingT4___")]
	public static extern void delete_TD_PDF_PDFShadingT4(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharPair_nCharCode_set___")]
	public static extern void TD_PDF_PDFCharPair_nCharCode_set(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharPair_nCharCode_get___")]
	public static extern ushort TD_PDF_PDFCharPair_nCharCode_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharPair_nUnicodeCode_set___")]
	public static extern void TD_PDF_PDFCharPair_nUnicodeCode_set(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharPair_nUnicodeCode_get___")]
	public static extern ushort TD_PDF_PDFCharPair_nUnicodeCode_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_TD_PDF_PDFCharPair___")]
	public static extern IntPtr new_TD_PDF_PDFCharPair();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharPair_IsEqual___")]
	public static extern bool TD_PDF_PDFCharPair_IsEqual(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharPair_IsNotEqual___")]
	public static extern bool TD_PDF_PDFCharPair_IsNotEqual(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCharPair___")]
	public static extern void delete_TD_PDF_PDFCharPair(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharPairArray_sortByCharCode___")]
	public static extern void TD_PDF_PDFCharPairArray_sortByCharCode(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharPairArray_isValid4ToUnicodeCMap___")]
	public static extern int TD_PDF_PDFCharPairArray_isValid4ToUnicodeCMap(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_TD_PDF_PDFCharPairArray___")]
	public static extern IntPtr new_TD_PDF_PDFCharPairArray();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCharPairArray___")]
	public static extern void delete_TD_PDF_PDFCharPairArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFToUnicodeCMap_isKindOf___")]
	public static extern bool TD_PDF_PDFToUnicodeCMap_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFToUnicodeCMap_type___")]
	public static extern int TD_PDF_PDFToUnicodeCMap_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFToUnicodeCMap_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFToUnicodeCMap_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFToUnicodeCMap_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFToUnicodeCMap_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFToUnicodeCMap_fillStream___")]
	public static extern int TD_PDF_PDFToUnicodeCMap_fillStream(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFToUnicodeCMap_getRealClassName___")]
	public static extern string TD_PDF_PDFToUnicodeCMap_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFToUnicodeCMap___")]
	public static extern void delete_TD_PDF_PDFToUnicodeCMap(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUsageDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFUsageDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUsageDictionary_type___")]
	public static extern int TD_PDF_PDFUsageDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUsageDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFUsageDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUsageDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFUsageDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUsageDictionary_setViewState___")]
	public static extern void TD_PDF_PDFUsageDictionary_setViewState(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUsageDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFUsageDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFUsageDictionary___")]
	public static extern void delete_TD_PDF_PDFUsageDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharProcDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCharProcDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharProcDictionary_type___")]
	public static extern int TD_PDF_PDFCharProcDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharProcDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCharProcDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharProcDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCharProcDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharProcDictionary_addChar___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string TD_PDF_PDFCharProcDictionary_addChar(HandleRef jarg1, ushort jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharProcDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCharProcDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCharProcDictionary___")]
	public static extern void delete_TD_PDF_PDFCharProcDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontWidthsArray_isKindOf___")]
	public static extern bool TD_PDF_PDFFontWidthsArray_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontWidthsArray_type___")]
	public static extern int TD_PDF_PDFFontWidthsArray_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontWidthsArray_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFFontWidthsArray_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontWidthsArray_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFFontWidthsArray_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontWidthsArray_FillWidthsArray__SWIG_0___")]
	public static extern void TD_PDF_PDFFontWidthsArray_FillWidthsArray__SWIG_0(HandleRef jarg1, IntPtr jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontWidthsArray_FillWidthsArray__SWIG_1___")]
	public static extern void TD_PDF_PDFFontWidthsArray_FillWidthsArray__SWIG_1(HandleRef jarg1, int jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontWidthsArray_getRealClassName___")]
	public static extern string TD_PDF_PDFFontWidthsArray_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFontWidthsArray___")]
	public static extern void delete_TD_PDF_PDFFontWidthsArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCID2GIDStream_isKindOf___")]
	public static extern bool TD_PDF_PDFCID2GIDStream_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCID2GIDStream_type___")]
	public static extern int TD_PDF_PDFCID2GIDStream_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCID2GIDStream_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCID2GIDStream_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCID2GIDStream_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCID2GIDStream_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCID2GIDStream_getData___")]
	public static extern void TD_PDF_PDFCID2GIDStream_getData(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCID2GIDStream_fill___")]
	public static extern void TD_PDF_PDFCID2GIDStream_fill(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCID2GIDStream_getRealClassName___")]
	public static extern string TD_PDF_PDFCID2GIDStream_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCID2GIDStream___")]
	public static extern void delete_TD_PDF_PDFCID2GIDStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PdfExtGState_isKindOf___")]
	public static extern bool TD_PDF_PdfExtGState_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PdfExtGState_type___")]
	public static extern int TD_PDF_PdfExtGState_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PdfExtGState_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PdfExtGState_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PdfExtGState_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PdfExtGState_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PdfExtGState_getRealClassName___")]
	public static extern string TD_PDF_PdfExtGState_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PdfExtGState___")]
	public static extern void delete_TD_PDF_PdfExtGState(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_new_PDFObjectID___")]
	public static extern IntPtr new_PDFObjectID();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_PDFObjectID_ObjectNumber___")]
	public static extern uint PDFObjectID_ObjectNumber(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_PDFObjectID_isNull___")]
	public static extern bool PDFObjectID_isNull(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_PDFObjectID_OneStepUpper___")]
	public static extern IntPtr PDFObjectID_OneStepUpper(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_PDFObjectID___")]
	public static extern void delete_PDFObjectID(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeParameters_isKindOf___")]
	public static extern bool TD_PDF_PDFFlateDecodeParameters_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeParameters_type___")]
	public static extern int TD_PDF_PDFFlateDecodeParameters_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeParameters_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFFlateDecodeParameters_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeParameters_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFFlateDecodeParameters_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeParameters_getRealClassName___")]
	public static extern string TD_PDF_PDFFlateDecodeParameters_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFlateDecodeParameters___")]
	public static extern void delete_TD_PDF_PDFFlateDecodeParameters(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeParameters_isKindOf___")]
	public static extern bool TD_PDF_PDFDCTDecodeParameters_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeParameters_type___")]
	public static extern int TD_PDF_PDFDCTDecodeParameters_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeParameters_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFDCTDecodeParameters_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeParameters_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFDCTDecodeParameters_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeParameters_getRealClassName___")]
	public static extern string TD_PDF_PDFDCTDecodeParameters_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFDCTDecodeParameters___")]
	public static extern void delete_TD_PDF_PDFDCTDecodeParameters(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeParameters_isKindOf___")]
	public static extern bool TD_PDF_PDFCCITTFaxDecodeParameters_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeParameters_type___")]
	public static extern int TD_PDF_PDFCCITTFaxDecodeParameters_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeParameters_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCCITTFaxDecodeParameters_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeParameters_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCCITTFaxDecodeParameters_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeParameters_getRealClassName___")]
	public static extern string TD_PDF_PDFCCITTFaxDecodeParameters_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCCITTFaxDecodeParameters___")]
	public static extern void delete_TD_PDF_PDFCCITTFaxDecodeParameters(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFontWidthsArray_isKindOf___")]
	public static extern bool TD_PDF_PDFCIDFontWidthsArray_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFontWidthsArray_type___")]
	public static extern int TD_PDF_PDFCIDFontWidthsArray_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFontWidthsArray_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCIDFontWidthsArray_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFontWidthsArray_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCIDFontWidthsArray_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFontWidthsArray_FillWidthsArray___")]
	public static extern void TD_PDF_PDFCIDFontWidthsArray_FillWidthsArray(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFontWidthsArray_truncate__SWIG_0___")]
	public static extern bool TD_PDF_PDFCIDFontWidthsArray_truncate__SWIG_0(HandleRef jarg1, ushort jarg2, ushort jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFontWidthsArray_truncate__SWIG_1___")]
	public static extern bool TD_PDF_PDFCIDFontWidthsArray_truncate__SWIG_1(HandleRef jarg1, IntPtr jarg2, out uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFontWidthsArray_getRealClassName___")]
	public static extern string TD_PDF_PDFCIDFontWidthsArray_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCIDFontWidthsArray___")]
	public static extern void delete_TD_PDF_PDFCIDFontWidthsArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStream_isKindOf___")]
	public static extern bool TD_PDF_PDF3dStream_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStream_type___")]
	public static extern int TD_PDF_PDF3dStream_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStream_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDF3dStream_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStream_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDF3dStream_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStream_getDictionary___")]
	public static extern IntPtr TD_PDF_PDF3dStream_getDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStream_putData___")]
	public static extern void TD_PDF_PDF3dStream_putData(HandleRef jarg1, string jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStream_getData___")]
	public static extern void TD_PDF_PDF3dStream_getData(HandleRef jarg1, string jarg2, uint jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStream_getRealClassName___")]
	public static extern string TD_PDF_PDF3dStream_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDF3dStream___")]
	public static extern void delete_TD_PDF_PDF3dStream(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquareAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFSquareAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquareAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFSquareAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquareAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFSquareAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquareAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFSquareAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquareAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFSquareAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFSquareAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFSquareAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFixedPrintDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFFixedPrintDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFixedPrintDictionary_type___")]
	public static extern int TD_PDF_PDFFixedPrintDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFixedPrintDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFFixedPrintDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFixedPrintDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFFixedPrintDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFixedPrintDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFFixedPrintDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFFixedPrintDictionary___")]
	public static extern void delete_TD_PDF_PDFFixedPrintDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFWatermarkAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFWatermarkAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFWatermarkAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFWatermarkAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFWatermarkAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFWatermarkAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFWatermarkAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFWatermarkAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFWatermarkAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFWatermarkAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFWatermarkAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFWatermarkAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLinkAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFLinkAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLinkAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDFLinkAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLinkAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFLinkAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLinkAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFLinkAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLinkAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFLinkAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFLinkAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDFLinkAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dAnnotationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDF3dAnnotationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dAnnotationDictionary_type___")]
	public static extern int TD_PDF_PDF3dAnnotationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dAnnotationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDF3dAnnotationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dAnnotationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDF3dAnnotationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dAnnotationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDF3dAnnotationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDF3dAnnotationDictionary___")]
	public static extern void delete_TD_PDF_PDF3dAnnotationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dActivationDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDF3dActivationDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dActivationDictionary_type___")]
	public static extern int TD_PDF_PDF3dActivationDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dActivationDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDF3dActivationDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dActivationDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDF3dActivationDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dActivationDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDF3dActivationDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDF3dActivationDictionary___")]
	public static extern void delete_TD_PDF_PDF3dActivationDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFGoToActionDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFGoToActionDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFGoToActionDictionary_type___")]
	public static extern int TD_PDF_PDFGoToActionDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFGoToActionDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFGoToActionDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFGoToActionDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFGoToActionDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFGoToActionDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFGoToActionDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFGoToActionDictionary___")]
	public static extern void delete_TD_PDF_PDFGoToActionDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFURIActionDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFURIActionDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFURIActionDictionary_type___")]
	public static extern int TD_PDF_PDFURIActionDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFURIActionDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFURIActionDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFURIActionDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFURIActionDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFURIActionDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFURIActionDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFURIActionDictionary___")]
	public static extern void delete_TD_PDF_PDFURIActionDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dRenderModeDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDF3dRenderModeDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dRenderModeDictionary_type___")]
	public static extern int TD_PDF_PDF3dRenderModeDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dRenderModeDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDF3dRenderModeDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dRenderModeDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDF3dRenderModeDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dRenderModeDictionary_Export___")]
	public static extern bool TD_PDF_PDF3dRenderModeDictionary_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dRenderModeDictionary_setSubtype___")]
	public static extern void TD_PDF_PDF3dRenderModeDictionary_setSubtype(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dRenderModeDictionary_getSubtype___")]
	public static extern int TD_PDF_PDF3dRenderModeDictionary_getSubtype(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dRenderModeDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDF3dRenderModeDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDF3dRenderModeDictionary___")]
	public static extern void delete_TD_PDF_PDF3dRenderModeDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dLightingSchemeDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDF3dLightingSchemeDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dLightingSchemeDictionary_type___")]
	public static extern int TD_PDF_PDF3dLightingSchemeDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dLightingSchemeDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDF3dLightingSchemeDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dLightingSchemeDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDF3dLightingSchemeDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dLightingSchemeDictionary_Export___")]
	public static extern bool TD_PDF_PDF3dLightingSchemeDictionary_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dLightingSchemeDictionary_setSubtype___")]
	public static extern void TD_PDF_PDF3dLightingSchemeDictionary_setSubtype(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dLightingSchemeDictionary_getSubtype___")]
	public static extern int TD_PDF_PDF3dLightingSchemeDictionary_getSubtype(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dLightingSchemeDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDF3dLightingSchemeDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDF3dLightingSchemeDictionary___")]
	public static extern void delete_TD_PDF_PDF3dLightingSchemeDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dNodeDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDF3dNodeDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dNodeDictionary_type___")]
	public static extern int TD_PDF_PDF3dNodeDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dNodeDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDF3dNodeDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dNodeDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDF3dNodeDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dNodeDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDF3dNodeDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDF3dNodeDictionary___")]
	public static extern void delete_TD_PDF_PDF3dNodeDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCrossSectionDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFCrossSectionDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCrossSectionDictionary_type___")]
	public static extern int TD_PDF_PDFCrossSectionDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCrossSectionDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFCrossSectionDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCrossSectionDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFCrossSectionDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCrossSectionDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFCrossSectionDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFCrossSectionDictionary___")]
	public static extern void delete_TD_PDF_PDFCrossSectionDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dViewDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDF3dViewDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dViewDictionary_type___")]
	public static extern int TD_PDF_PDF3dViewDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dViewDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDF3dViewDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dViewDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDF3dViewDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dViewDictionary_Export___")]
	public static extern bool TD_PDF_PDF3dViewDictionary_Export(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dViewDictionary_setIN___")]
	public static extern void TD_PDF_PDF3dViewDictionary_setIN(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dViewDictionary_getIN___")]
	public static extern IntPtr TD_PDF_PDF3dViewDictionary_getIN(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dViewDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDF3dViewDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDF3dViewDictionary___")]
	public static extern void delete_TD_PDF_PDF3dViewDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFProjectionDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDFProjectionDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFProjectionDictionary_type___")]
	public static extern int TD_PDF_PDFProjectionDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFProjectionDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDFProjectionDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFProjectionDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDFProjectionDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFProjectionDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDFProjectionDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDFProjectionDictionary___")]
	public static extern void delete_TD_PDF_PDFProjectionDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dBackgroundDictionary_isKindOf___")]
	public static extern bool TD_PDF_PDF3dBackgroundDictionary_isKindOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dBackgroundDictionary_type___")]
	public static extern int TD_PDF_PDF3dBackgroundDictionary_type(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dBackgroundDictionary_createObject__SWIG_0___")]
	public static extern IntPtr TD_PDF_PDF3dBackgroundDictionary_createObject__SWIG_0(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dBackgroundDictionary_createObject__SWIG_1___")]
	public static extern IntPtr TD_PDF_PDF3dBackgroundDictionary_createObject__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dBackgroundDictionary_getRealClassName___")]
	public static extern string TD_PDF_PDF3dBackgroundDictionary_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_TD_PDF_PDF3dBackgroundDictionary___")]
	public static extern void delete_TD_PDF_PDF3dBackgroundDictionary(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator__SWIG_0")]
	public static extern IntPtr new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator__SWIG_0();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator__SWIG_1")]
	public static extern IntPtr new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator__SWIG_2")]
	public static extern IntPtr new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator__SWIG_2(int jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_size___")]
	public static extern uint OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_size(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_capacity___")]
	public static extern uint OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_capacity(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_reserve___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_resize___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Clear___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Add___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_getitemcopy___")]
	public static extern IntPtr OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_getitem___")]
	public static extern IntPtr OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_setitem___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_AddRange___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_GetRange___")]
	public static extern IntPtr OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Insert___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_InsertRange___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_RemoveAt___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_RemoveRange___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Repeat___")]
	public static extern IntPtr OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Reverse__SWIG_0___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Reverse__SWIG_1___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_SetRange___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Contains___")]
	public static extern bool OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_IndexOf___")]
	public static extern int OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_LastIndexOf___")]
	public static extern int OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Remove___")]
	public static extern bool OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator___")]
	public static extern void delete_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator__SWIG_0")]
	public static extern IntPtr new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator__SWIG_0();

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator__SWIG_1")]
	public static extern IntPtr new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator__SWIG_2")]
	public static extern IntPtr new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator__SWIG_2(int jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_size___")]
	public static extern uint OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_size(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_capacity___")]
	public static extern uint OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_capacity(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_reserve___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_resize___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_Clear___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_Clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_Add___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_getitemcopy___")]
	public static extern IntPtr OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_getitem___")]
	public static extern IntPtr OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_setitem___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_GetRange___")]
	public static extern IntPtr OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_Insert___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_RemoveAt___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_RemoveRange___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_Repeat___")]
	public static extern IntPtr OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_SetRange___")]
	public static extern void OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_Contains___")]
	public static extern bool OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_IndexOf___")]
	public static extern int OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_LastIndexOf___")]
	public static extern int OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_Remove___")]
	public static extern bool OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_delete_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator___")]
	public static extern void delete_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFTilingPattern_OdObjectsAllocator(HandleRef jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFObject_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFObject_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBaseString_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFBaseString_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFName_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFName_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBoolean_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFBoolean_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRectangle_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFRectangle_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDecodeParametersDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFDecodeParametersDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFIStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFStreamDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLiteralString_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFLiteralString_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFXObjectDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPatternDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFTilingPatternDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFContentStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDummyContentStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFDummyContentStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectFormDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFXObjectFormDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImageDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFImageDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObject_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFXObject_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteger_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFInteger_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTilingPattern_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFTilingPattern_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectForm_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFXObjectForm_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSubDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFSubDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArray_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFArray_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumber_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFNumber_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDate_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFDate_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextString_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFTextString_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFImage_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFImage_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldFlags_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFieldFlags_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFont_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFont_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFContentStream4Type3_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFContentStream4Type3_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPropertiesSubDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFPropertiesSubDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPatternSubDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFPatternSubDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingSubDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFShadingSubDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorSpaceSubDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFColorSpaceSubDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFExtGStateSubDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFExtGStateSubDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFXObjectSubDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFXObjectSubDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSchemaDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCollectionSchemaDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionColorsDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCollectionColorsDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSplitDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCollectionSplitDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionFoldersDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCollectionFoldersDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionSortDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCollectionSortDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFNameTreeNodeDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileParamsDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFEmbeddedFileParamsDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFieldDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontSubDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFontSubDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFPageDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCGroupDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFOCGroupDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFNumberTreeNodeDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCollectionDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNamesDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFNamesDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dAnimationStyleDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDF3dAnimationStyleDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnicodeTextStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFUnicodeTextStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMarkupAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFMarkupAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolygonPolyLineAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFPolygonPolyLineAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextMarkupAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFTextMarkupAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineItemDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFOutlineItemDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStreamDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFEmbeddedFileStreamDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldChoiceDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFieldChoiceDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTriggerEventsDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFTriggerEventsDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStreamDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFICCBasedStreamDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStreamDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFMetadataStreamDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMemoryStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFMemoryStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedColorSpace_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFIndexedColorSpace_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptor_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFontDescriptor_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFResourceDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFResourceDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageNodeDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFPageNodeDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCConfigurationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFOCConfigurationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCIDFont_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDocumentInformation_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFDocumentInformation_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCatalogDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCatalogDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStreamFilter_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFStreamFilter_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFShadingDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCMap_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCMap_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStreamDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDF3dStreamDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquareCircleAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFSquareCircleAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFActionDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFActionDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBorderEffectDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFBorderEffectDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolyLineAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFPolyLineAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPolygonAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFPolygonAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCircleAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCircleAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLineAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFLineAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCaretAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCaretAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInkAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFInkAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStampAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFStampAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStrikeOutAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFStrikeOutAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquigglyAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFSquigglyAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUnderlineAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFUnderlineAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFHighlightAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFHighlightAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCollectionFieldDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCollectionFieldDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFArtifactDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFArtifactDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCoordinateSystemDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCoordinateSystemDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTextAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFTextAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPopupAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFPopupAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutlineDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFOutlineDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFileStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFEmbeddedFileStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFileSpecificationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFileSpecificationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFStateAppearanceSubDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFStateAppearanceSubDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldComboBoxDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFieldComboBoxDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldListBoxDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFieldListBoxDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFBorderStyleDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFBorderStyleDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFPageLabelDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFPageLabelDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberTreeNodeElement_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFNumberTreeNodeElement_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNameTreeNodeNamesElement_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFNameTreeNodeNamesElement_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFGoTo3DViewActionDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFGoTo3DViewActionDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFJavaScriptActionDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFJavaScriptActionDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAnnotationFlags_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFAnnotationFlags_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType1Font_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFType1Font_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAppearanceCharacteristicsDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFAppearanceCharacteristicsDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFAppearanceDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFAppearanceDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldSignDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFieldSignDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldRadioBtnDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFieldRadioBtnDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldCheckBoxDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFieldCheckBoxDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldTextDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFieldTextDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFieldBtnDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFieldBtnDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFWidgetAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFWidgetAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFInteractiveFormDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFInteractiveFormDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNumberFormatDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFNumberFormatDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMeasureDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFMeasureDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFViewportDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFViewportDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFICCBasedStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFICCBasedStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFMetadataStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFMetadataStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOutputIntentsDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFOutputIntentsDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTempFileStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFTempFileStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeFilter_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFlateDecodeFilter_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeFilter_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFDCTDecodeFilter_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeFilter_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCCITTFaxDecodeFilter_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEmbeddedFontStreamDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFEmbeddedFontStreamDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDifferencesArray_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFDifferencesArray_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFIndexedRGBColorSpace_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFIndexedRGBColorSpace_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptorFlags_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFontDescriptorFlags_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFOCPropertiesDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFOCPropertiesDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontDescriptor4CIDFont_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFontDescriptor4CIDFont_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFRGBStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFRGBStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont0_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCIDFont0_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType3Font_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFType3Font_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFont2_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCIDFont2_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCMapDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCMapDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingPattern_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFShadingPattern_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFType0Font_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFType0Font_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFColorKeyMaskArray_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFColorKeyMaskArray_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFTrueTypeFont_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFTrueTypeFont_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFEncodingDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFEncodingDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDeviceGrayColorSpace_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFDeviceGrayColorSpace_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontMatrix_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFontMatrix_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFNullObject_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFNullObject_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFASCIIHexDecodeFilter_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFASCIIHexDecodeFilter_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDSystemInfo_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCIDSystemInfo_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontFileStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFontFileStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4StreamDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFShadingT4StreamDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFShadingT4_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFShadingT4_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFToUnicodeCMap_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFToUnicodeCMap_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFUsageDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFUsageDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCharProcDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCharProcDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFontWidthsArray_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFontWidthsArray_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCID2GIDStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCID2GIDStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PdfExtGState_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PdfExtGState_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFlateDecodeParameters_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFlateDecodeParameters_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFDCTDecodeParameters_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFDCTDecodeParameters_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCCITTFaxDecodeParameters_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCCITTFaxDecodeParameters_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCIDFontWidthsArray_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCIDFontWidthsArray_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dStream_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDF3dStream_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFSquareAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFSquareAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFFixedPrintDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFFixedPrintDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFWatermarkAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFWatermarkAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFLinkAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFLinkAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dAnnotationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDF3dAnnotationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dActivationDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDF3dActivationDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFGoToActionDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFGoToActionDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFURIActionDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFURIActionDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dRenderModeDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDF3dRenderModeDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dLightingSchemeDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDF3dLightingSchemeDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dNodeDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDF3dNodeDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFCrossSectionDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFCrossSectionDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dViewDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDF3dViewDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDFProjectionDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDFProjectionDictionary_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_TD_PDFToolkit_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_PDFToolkit_TD_PDF_PDF3dBackgroundDictionary_SWIGUpcast___")]
	public static extern IntPtr TD_PDF_PDF3dBackgroundDictionary_SWIGUpcast(IntPtr jarg1);
}

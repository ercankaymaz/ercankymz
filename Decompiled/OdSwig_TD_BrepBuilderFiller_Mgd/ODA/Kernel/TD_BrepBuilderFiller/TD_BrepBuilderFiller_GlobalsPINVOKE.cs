using System;
using System.IO;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

internal class TD_BrepBuilderFiller_GlobalsPINVOKE
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

		[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll")]
		public static extern void SWIGRegisterExceptionCallbacks_TD_BrepBuilderFiller_Globals(ExceptionDelegate applicationDelegate, ExceptionDelegate arithmeticDelegate, ExceptionDelegate divideByZeroDelegate, ExceptionDelegate indexOutOfRangeDelegate, ExceptionDelegate invalidCastDelegate, ExceptionDelegate invalidOperationDelegate, ExceptionDelegate ioDelegate, ExceptionDelegate nullReferenceDelegate, ExceptionDelegate outOfMemoryDelegate, ExceptionDelegate overflowDelegate, ExceptionDelegate systemExceptionDelegate);

		[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_TD_BrepBuilderFiller_Globals")]
		public static extern void SWIGRegisterExceptionCallbacksArgument_TD_BrepBuilderFiller_Globals(ExceptionArgumentDelegate argumentDelegate, ExceptionArgumentDelegate argumentNullDelegate, ExceptionArgumentDelegate argumentOutOfRangeDelegate);

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
			SWIGRegisterExceptionCallbacks_TD_BrepBuilderFiller_Globals(applicationDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, outOfMemoryDelegate, overflowDelegate, systemDelegate);
			SWIGRegisterExceptionCallbacksArgument_TD_BrepBuilderFiller_Globals(argumentDelegate, argumentNullDelegate, argumentOutOfRangeDelegate);
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

		[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll")]
		public static extern void SWIGRegisterStringCallback_TD_BrepBuilderFiller_Globals(SWIGStringDelegate stringDelegate);

		private static string CreateString(string cString)
		{
			return cString;
		}

		static SWIGStringHelper()
		{
			stringDelegate = CreateString;
			SWIGRegisterStringCallback_TD_BrepBuilderFiller_Globals(stringDelegate);
		}
	}

	private class CustomExceptionHelper
	{
		public delegate void CustomExceptionDelegate(IntPtr NewContext);

		private static CustomExceptionDelegate customDelegate;

		[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll")]
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

	static TD_BrepBuilderFiller_GlobalsPINVOKE()
	{
		swigExceptionHelper = new SWIGExceptionHelper();
		swigStringHelper = new SWIGStringHelper();
		exceptionHelper = new CustomExceptionHelper();
	}

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_UINT_MAX_get___")]
	public static extern uint UINT_MAX_get();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_ULONG_MAX_get___")]
	public static extern uint ULONG_MAX_get();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller__MSC_VER_get___")]
	public static extern int _MSC_VER_get();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_ODCHAR_IS_INT16LE_get___")]
	public static extern int ODCHAR_IS_INT16LE_get();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OD_SIZEOF_INT_get___")]
	public static extern int OD_SIZEOF_INT_get();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OD_SIZEOF_LONG_get___")]
	public static extern int OD_SIZEOF_LONG_get();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_PERCENT18LONG_get___")]
	public static extern string PERCENT18LONG_get();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_HANDLEFORMAT_get___")]
	public static extern string HANDLEFORMAT_get();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_PRId64_get___")]
	public static extern string PRId64_get();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_PRIu64_get___")]
	public static extern string PRIu64_get();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_PRIx64_get___")]
	public static extern string PRIx64_get();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_PRIX64_get___")]
	public static extern string PRIX64_get();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OD_SIZEOF_PTR_get___")]
	public static extern int OD_SIZEOF_PTR_get();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_throw_native_exception_string___")]
	public static extern void throw_native_exception_string([MarshalAs(UnmanagedType.LPWStr)] string jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_throw_native_OdError__SWIG_0___")]
	public static extern void throw_native_OdError__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_throw_native_OdError__SWIG_1___")]
	public static extern void throw_native_OdError__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_throw_native_OdError__SWIG_2___")]
	public static extern void throw_native_OdError__SWIG_2(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_sec_set___")]
	public static extern void tm_tm_sec_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_sec_get___")]
	public static extern int tm_tm_sec_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_min_set___")]
	public static extern void tm_tm_min_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_min_get___")]
	public static extern int tm_tm_min_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_hour_set___")]
	public static extern void tm_tm_hour_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_hour_get___")]
	public static extern int tm_tm_hour_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_mday_set___")]
	public static extern void tm_tm_mday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_mday_get___")]
	public static extern int tm_tm_mday_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_mon_set___")]
	public static extern void tm_tm_mon_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_mon_get___")]
	public static extern int tm_tm_mon_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_year_set___")]
	public static extern void tm_tm_year_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_year_get___")]
	public static extern int tm_tm_year_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_wday_set___")]
	public static extern void tm_tm_wday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_wday_get___")]
	public static extern int tm_tm_wday_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_yday_set___")]
	public static extern void tm_tm_yday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_yday_get___")]
	public static extern int tm_tm_yday_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_isdst_set___")]
	public static extern void tm_tm_isdst_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_tm_tm_isdst_get___")]
	public static extern int tm_tm_isdst_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_tm___")]
	public static extern IntPtr new_tm();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_tm___")]
	public static extern void delete_tm(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_std_pair_bool_long__SWIG_0___")]
	public static extern IntPtr new_std_pair_bool_long__SWIG_0();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_std_pair_bool_long__SWIG_1___")]
	public static extern IntPtr new_std_pair_bool_long__SWIG_1(bool jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_std_pair_bool_long__SWIG_2___")]
	public static extern IntPtr new_std_pair_bool_long__SWIG_2(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_std_pair_bool_long_first_set___")]
	public static extern void std_pair_bool_long_first_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_std_pair_bool_long_first_get___")]
	public static extern bool std_pair_bool_long_first_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_std_pair_bool_long_second_set___")]
	public static extern void std_pair_bool_long_second_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_std_pair_bool_long_second_get___")]
	public static extern int std_pair_bool_long_second_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_std_pair_bool_long___")]
	public static extern void delete_std_pair_bool_long(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_OdIMaterialAndColorHelper___")]
	public static extern void delete_OdIMaterialAndColorHelper(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdIMaterialAndColorHelper_init___")]
	public static extern int OdIMaterialAndColorHelper_init(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdIMaterialAndColorHelper_getFaceVisualInfo___")]
	public static extern int OdIMaterialAndColorHelper_getFaceVisualInfo(HandleRef jarg1, HandleRef jarg2, out IntPtr jarg3, HandleRef jarg4, out bool jarg5, HandleRef jarg6, out bool jarg7);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdIMaterialAndColorHelper_getEdgeVisualInfo___")]
	public static extern int OdIMaterialAndColorHelper_getEdgeVisualInfo(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, out bool jarg4);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_OdIMaterialAndColorHelper___")]
	public static extern IntPtr new_OdIMaterialAndColorHelper();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdIMaterialAndColorHelper_director_connect___")]
	public static extern void OdIMaterialAndColorHelper_director_connect(HandleRef jarg1, OdIMaterialAndColorHelper.SwigDelegateOdIMaterialAndColorHelper_0 delegate0, OdIMaterialAndColorHelper.SwigDelegateOdIMaterialAndColorHelper_1 delegate1, OdIMaterialAndColorHelper.SwigDelegateOdIMaterialAndColorHelper_2 delegate2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_OdBrepBuilderFillerParams___")]
	public static extern IntPtr new_OdBrepBuilderFillerParams();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setSkipNullSurface___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setSkipNullSurface(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isSkipNullSurface___")]
	public static extern bool OdBrepBuilderFillerParams_isSkipNullSurface(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setSkipCoedge2dCurve___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setSkipCoedge2dCurve(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isSkipCoedge2dCurve___")]
	public static extern bool OdBrepBuilderFillerParams_isSkipCoedge2dCurve(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setSkipCheckLoopType___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setSkipCheckLoopType(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isSkipCheckLoopType___")]
	public static extern bool OdBrepBuilderFillerParams_isSkipCheckLoopType(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setGenerateExplicitLoops___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setGenerateExplicitLoops(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isGenerateExplicitLoops___")]
	public static extern bool OdBrepBuilderFillerParams_isGenerateExplicitLoops(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setMakeEllipMajorGreaterMinor___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setMakeEllipMajorGreaterMinor(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isMakeEllipMajorGreaterMinor___")]
	public static extern bool OdBrepBuilderFillerParams_isMakeEllipMajorGreaterMinor(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setIgnoreComplexShell___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setIgnoreComplexShell(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isIgnoreComplexShell___")]
	public static extern bool OdBrepBuilderFillerParams_isIgnoreComplexShell(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setGenerateVertices___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setGenerateVertices(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isGenerateVertices___")]
	public static extern bool OdBrepBuilderFillerParams_isGenerateVertices(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setMake2dIntervalInclude3d___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setMake2dIntervalInclude3d(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isMake2dIntervalInclude3d___")]
	public static extern bool OdBrepBuilderFillerParams_isMake2dIntervalInclude3d(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setCheckShellsConnectivity___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setCheckShellsConnectivity(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isCheckShellsConnectivity___")]
	public static extern bool OdBrepBuilderFillerParams_isCheckShellsConnectivity(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setSetFaceGsMarkersTags___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setSetFaceGsMarkersTags(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isSetFaceGsMarkersTags___")]
	public static extern bool OdBrepBuilderFillerParams_isSetFaceGsMarkersTags(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setSetEdgeGsMarkersTags___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setSetEdgeGsMarkersTags(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isSetEdgeGsMarkersTags___")]
	public static extern bool OdBrepBuilderFillerParams_isSetEdgeGsMarkersTags(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setSetVertexGsMarkersTags___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setSetVertexGsMarkersTags(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isSetVertexGsMarkersTags___")]
	public static extern bool OdBrepBuilderFillerParams_isSetVertexGsMarkersTags(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setUseFaceRegions___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setUseFaceRegions(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isUseFaceRegions___")]
	public static extern bool OdBrepBuilderFillerParams_isUseFaceRegions(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setFixFaceRegionsConnections___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setFixFaceRegionsConnections(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isFixFaceRegionsConnections___")]
	public static extern bool OdBrepBuilderFillerParams_isFixFaceRegionsConnections(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setOldUvCurveHandling___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setOldUvCurveHandling(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isOldUvCurveHandling___")]
	public static extern bool OdBrepBuilderFillerParams_isOldUvCurveHandling(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setSplitEdgeByPole___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setSplitEdgeByPole(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isSplitEdgeByPole___")]
	public static extern bool OdBrepBuilderFillerParams_isSplitEdgeByPole(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setGlobalBrepTransform___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setGlobalBrepTransform(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_isGlobalBrepTransform___")]
	public static extern bool OdBrepBuilderFillerParams_isGlobalBrepTransform(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setupFor__SWIG_0___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setupFor__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setupFor__SWIG_1___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setupFor__SWIG_1(HandleRef jarg1, int jarg2, HandleRef jarg3, HandleRef jarg4);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setupFor__SWIG_2___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setupFor__SWIG_2(HandleRef jarg1, int jarg2, HandleRef jarg3, int jarg4, HandleRef jarg5);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setupFor__SWIG_3___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setupFor__SWIG_3(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setupFor__SWIG_4___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setupFor__SWIG_4(HandleRef jarg1, HandleRef jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_setupFor__SWIG_5___")]
	public static extern IntPtr OdBrepBuilderFillerParams_setupFor__SWIG_5(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_sourceDb___")]
	public static extern IntPtr OdBrepBuilderFillerParams_sourceDb(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_sourceBrepType___")]
	public static extern int OdBrepBuilderFillerParams_sourceBrepType(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_destinationDb___")]
	public static extern IntPtr OdBrepBuilderFillerParams_destinationDb(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFillerParams_destinationBrepType___")]
	public static extern int OdBrepBuilderFillerParams_destinationBrepType(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_OdBrepBuilderFillerParams___")]
	public static extern void delete_OdBrepBuilderFillerParams(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_OdBaseMaterialAndColorHelper__SWIG_0___")]
	public static extern IntPtr new_OdBaseMaterialAndColorHelper__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_OdBaseMaterialAndColorHelper__SWIG_1___")]
	public static extern IntPtr new_OdBaseMaterialAndColorHelper__SWIG_1();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_OdBaseMaterialAndColorHelper___")]
	public static extern void delete_OdBaseMaterialAndColorHelper(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBaseMaterialAndColorHelper_setSourceEntityMaterial___")]
	public static extern void OdBaseMaterialAndColorHelper_setSourceEntityMaterial(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBaseMaterialAndColorHelper_setSourceEntityMaterialMapping___")]
	public static extern void OdBaseMaterialAndColorHelper_setSourceEntityMaterialMapping(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBaseMaterialAndColorHelper_resetSourceEntityMapping___")]
	public static extern void OdBaseMaterialAndColorHelper_resetSourceEntityMapping(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBaseMaterialAndColorHelper_setSourceEntityColor___")]
	public static extern void OdBaseMaterialAndColorHelper_setSourceEntityColor(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBaseMaterialAndColorHelper_resetSourceEntityColor___")]
	public static extern void OdBaseMaterialAndColorHelper_resetSourceEntityColor(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBaseMaterialAndColorHelper_setSourceFaceColor___")]
	public static extern void OdBaseMaterialAndColorHelper_setSourceFaceColor(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBaseMaterialAndColorHelper_resetSourceFaceColor___")]
	public static extern void OdBaseMaterialAndColorHelper_resetSourceFaceColor(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBaseMaterialAndColorHelper_setSourceEdgeColor___")]
	public static extern void OdBaseMaterialAndColorHelper_setSourceEdgeColor(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBaseMaterialAndColorHelper_resetSourceEdgeColor___")]
	public static extern void OdBaseMaterialAndColorHelper_resetSourceEdgeColor(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBaseMaterialAndColorHelper_getFaceVisualInfo___")]
	public static extern int OdBaseMaterialAndColorHelper_getFaceVisualInfo(HandleRef jarg1, HandleRef jarg2, out IntPtr jarg3, HandleRef jarg4, out bool jarg5, HandleRef jarg6, out bool jarg7);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBaseMaterialAndColorHelper_getEdgeVisualInfo___")]
	public static extern int OdBaseMaterialAndColorHelper_getEdgeVisualInfo(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, out bool jarg4);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedge_direction_set___")]
	public static extern void BrepBuilderInitialCoedge_direction_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedge_direction_get___")]
	public static extern int BrepBuilderInitialCoedge_direction_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_BrepBuilderInitialCoedge__SWIG_0___")]
	public static extern IntPtr new_BrepBuilderInitialCoedge__SWIG_0();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_BrepBuilderInitialCoedge__SWIG_1___")]
	public static extern IntPtr new_BrepBuilderInitialCoedge__SWIG_1(HandleRef jarg1, int jarg2, uint jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedge_GetCurve___")]
	public static extern IntPtr BrepBuilderInitialCoedge_GetCurve(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedge_SetCurve___")]
	public static extern void BrepBuilderInitialCoedge_SetCurve(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedge_GetEdgeIndex___")]
	public static extern uint BrepBuilderInitialCoedge_GetEdgeIndex(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedge_SetEdgeIndex___")]
	public static extern void BrepBuilderInitialCoedge_SetEdgeIndex(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_BrepBuilderInitialCoedge___")]
	public static extern void delete_BrepBuilderInitialCoedge(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoop_coedges_set___")]
	public static extern void BrepBuilderInitialLoop_coedges_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoop_coedges_get___")]
	public static extern IntPtr BrepBuilderInitialLoop_coedges_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_BrepBuilderInitialLoop__SWIG_0___")]
	public static extern IntPtr new_BrepBuilderInitialLoop__SWIG_0();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_BrepBuilderInitialLoop__SWIG_1___")]
	public static extern IntPtr new_BrepBuilderInitialLoop__SWIG_1(HandleRef jarg1, uint jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_BrepBuilderInitialLoop___")]
	public static extern void delete_BrepBuilderInitialLoop(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_direction_set___")]
	public static extern void BrepBuilderInitialSurface_direction_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_direction_get___")]
	public static extern int BrepBuilderInitialSurface_direction_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_loops_set___")]
	public static extern void BrepBuilderInitialSurface_loops_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_loops_get___")]
	public static extern IntPtr BrepBuilderInitialSurface_loops_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_material_set___")]
	public static extern void BrepBuilderInitialSurface_material_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_material_get___")]
	public static extern IntPtr BrepBuilderInitialSurface_material_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_hasMaterialMapping_set___")]
	public static extern void BrepBuilderInitialSurface_hasMaterialMapping_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_hasMaterialMapping_get___")]
	public static extern bool BrepBuilderInitialSurface_hasMaterialMapping_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_materialMapper_set___")]
	public static extern void BrepBuilderInitialSurface_materialMapper_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_materialMapper_get___")]
	public static extern IntPtr BrepBuilderInitialSurface_materialMapper_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_hasColor_set___")]
	public static extern void BrepBuilderInitialSurface_hasColor_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_hasColor_get___")]
	public static extern bool BrepBuilderInitialSurface_hasColor_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_color_set___")]
	public static extern void BrepBuilderInitialSurface_color_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_color_get___")]
	public static extern IntPtr BrepBuilderInitialSurface_color_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_marker_set___")]
	public static extern void BrepBuilderInitialSurface_marker_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_marker_get___")]
	public static extern IntPtr BrepBuilderInitialSurface_marker_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_parentFaceIdx_set___")]
	public static extern void BrepBuilderInitialSurface_parentFaceIdx_set(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_parentFaceIdx_get___")]
	public static extern uint BrepBuilderInitialSurface_parentFaceIdx_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_BrepBuilderInitialSurface___")]
	public static extern IntPtr new_BrepBuilderInitialSurface();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_copyFaceExceptLoops___")]
	public static extern void BrepBuilderInitialSurface_copyFaceExceptLoops(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_get_pSurf___")]
	public static extern IntPtr BrepBuilderInitialSurface_get_pSurf(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurface_set_pSurf___")]
	public static extern void BrepBuilderInitialSurface_set_pSurf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_BrepBuilderInitialSurface___")]
	public static extern void delete_BrepBuilderInitialSurface(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_BrepBuilderInitialVertex___")]
	public static extern IntPtr new_BrepBuilderInitialVertex();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertex_point_set___")]
	public static extern void BrepBuilderInitialVertex_point_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertex_point_get___")]
	public static extern IntPtr BrepBuilderInitialVertex_point_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertex_marker_set___")]
	public static extern void BrepBuilderInitialVertex_marker_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertex_marker_get___")]
	public static extern IntPtr BrepBuilderInitialVertex_marker_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_BrepBuilderInitialVertex___")]
	public static extern void delete_BrepBuilderInitialVertex(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_marker_set___")]
	public static extern void BrepBuilderInitialEdge_marker_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_marker_get___")]
	public static extern IntPtr BrepBuilderInitialEdge_marker_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_hasColor_set___")]
	public static extern void BrepBuilderInitialEdge_hasColor_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_hasColor_get___")]
	public static extern bool BrepBuilderInitialEdge_hasColor_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_color_set___")]
	public static extern void BrepBuilderInitialEdge_color_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_color_get___")]
	public static extern IntPtr BrepBuilderInitialEdge_color_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_BrepBuilderInitialEdge__SWIG_0___")]
	public static extern IntPtr new_BrepBuilderInitialEdge__SWIG_0(HandleRef jarg1, uint jarg2, uint jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_BrepBuilderInitialEdge__SWIG_1___")]
	public static extern IntPtr new_BrepBuilderInitialEdge__SWIG_1(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_BrepBuilderInitialEdge__SWIG_2___")]
	public static extern IntPtr new_BrepBuilderInitialEdge__SWIG_2(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_BrepBuilderInitialEdge__SWIG_3___")]
	public static extern IntPtr new_BrepBuilderInitialEdge__SWIG_3();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_resetApproxLength___")]
	public static extern void BrepBuilderInitialEdge_resetApproxLength(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_Get_kInvalidIndex___")]
	public static extern uint BrepBuilderInitialEdge_Get_kInvalidIndex(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_GetCurve___")]
	public static extern IntPtr BrepBuilderInitialEdge_GetCurve(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_SetCurve___")]
	public static extern void BrepBuilderInitialEdge_SetCurve(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_getVertexIndex1___")]
	public static extern uint BrepBuilderInitialEdge_getVertexIndex1(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_setVertexIndex1___")]
	public static extern void BrepBuilderInitialEdge_setVertexIndex1(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_getVertexIndex2___")]
	public static extern uint BrepBuilderInitialEdge_getVertexIndex2(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdge_setVertexIndex2___")]
	public static extern void BrepBuilderInitialEdge_setVertexIndex2(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_BrepBuilderInitialEdge___")]
	public static extern void delete_BrepBuilderInitialEdge(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialData_vertices_set___")]
	public static extern void BrepBuilderInitialData_vertices_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialData_vertices_get___")]
	public static extern IntPtr BrepBuilderInitialData_vertices_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialData_edges_set___")]
	public static extern void BrepBuilderInitialData_edges_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialData_edges_get___")]
	public static extern IntPtr BrepBuilderInitialData_edges_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialData_complexes_set___")]
	public static extern void BrepBuilderInitialData_complexes_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialData_complexes_get___")]
	public static extern IntPtr BrepBuilderInitialData_complexes_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialData_get_transformation___")]
	public static extern IntPtr BrepBuilderInitialData_get_transformation(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialData_set_transformation___")]
	public static extern void BrepBuilderInitialData_set_transformation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_BrepBuilderInitialData___")]
	public static extern IntPtr new_BrepBuilderInitialData();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_BrepBuilderInitialData___")]
	public static extern void delete_BrepBuilderInitialData(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFiller_params___SWIG_0___")]
	public static extern IntPtr OdBrepBuilderFiller_params___SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFiller_initFrom__SWIG_0___")]
	public static extern int OdBrepBuilderFiller_initFrom__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFiller_initFrom__SWIG_1___")]
	public static extern int OdBrepBuilderFiller_initFrom__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFiller_initFrom__SWIG_2___")]
	public static extern int OdBrepBuilderFiller_initFrom__SWIG_2(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBrepBuilderFiller_initFromNURBSingleFace___")]
	public static extern int OdBrepBuilderFiller_initFromNURBSingleFace(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_OdBrepBuilderFiller___")]
	public static extern IntPtr new_OdBrepBuilderFiller();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_OdBrepBuilderFiller___")]
	public static extern void delete_OdBrepBuilderFiller(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialLoopArray__SWIG_0")]
	public static extern IntPtr new_BrepBuilderInitialLoopArray__SWIG_0();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialLoopArray__SWIG_1")]
	public static extern IntPtr new_BrepBuilderInitialLoopArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialLoopArray__SWIG_2")]
	public static extern IntPtr new_BrepBuilderInitialLoopArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_size___")]
	public static extern uint BrepBuilderInitialLoopArray_size(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_capacity___")]
	public static extern uint BrepBuilderInitialLoopArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_reserve___")]
	public static extern void BrepBuilderInitialLoopArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_resize___")]
	public static extern void BrepBuilderInitialLoopArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_Clear___")]
	public static extern void BrepBuilderInitialLoopArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_Add___")]
	public static extern void BrepBuilderInitialLoopArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_getitemcopy___")]
	public static extern IntPtr BrepBuilderInitialLoopArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_getitem___")]
	public static extern IntPtr BrepBuilderInitialLoopArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_setitem___")]
	public static extern void BrepBuilderInitialLoopArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_AddRange___")]
	public static extern void BrepBuilderInitialLoopArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_GetRange___")]
	public static extern IntPtr BrepBuilderInitialLoopArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_Insert___")]
	public static extern void BrepBuilderInitialLoopArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_InsertRange___")]
	public static extern void BrepBuilderInitialLoopArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_RemoveAt___")]
	public static extern void BrepBuilderInitialLoopArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_RemoveRange___")]
	public static extern void BrepBuilderInitialLoopArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_Repeat___")]
	public static extern IntPtr BrepBuilderInitialLoopArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_Reverse__SWIG_0___")]
	public static extern void BrepBuilderInitialLoopArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_Reverse__SWIG_1___")]
	public static extern void BrepBuilderInitialLoopArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_SetRange___")]
	public static extern void BrepBuilderInitialLoopArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_Contains___")]
	public static extern bool BrepBuilderInitialLoopArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_IndexOf___")]
	public static extern int BrepBuilderInitialLoopArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_LastIndexOf___")]
	public static extern int BrepBuilderInitialLoopArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialLoopArray_Remove___")]
	public static extern bool BrepBuilderInitialLoopArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_BrepBuilderInitialLoopArray___")]
	public static extern void delete_BrepBuilderInitialLoopArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialCoedgeArray__SWIG_0")]
	public static extern IntPtr new_BrepBuilderInitialCoedgeArray__SWIG_0();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialCoedgeArray__SWIG_1")]
	public static extern IntPtr new_BrepBuilderInitialCoedgeArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialCoedgeArray__SWIG_2")]
	public static extern IntPtr new_BrepBuilderInitialCoedgeArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_size___")]
	public static extern uint BrepBuilderInitialCoedgeArray_size(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_capacity___")]
	public static extern uint BrepBuilderInitialCoedgeArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_reserve___")]
	public static extern void BrepBuilderInitialCoedgeArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_resize___")]
	public static extern void BrepBuilderInitialCoedgeArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_Clear___")]
	public static extern void BrepBuilderInitialCoedgeArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_Add___")]
	public static extern void BrepBuilderInitialCoedgeArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_getitemcopy___")]
	public static extern IntPtr BrepBuilderInitialCoedgeArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_getitem___")]
	public static extern IntPtr BrepBuilderInitialCoedgeArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_setitem___")]
	public static extern void BrepBuilderInitialCoedgeArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_AddRange___")]
	public static extern void BrepBuilderInitialCoedgeArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_GetRange___")]
	public static extern IntPtr BrepBuilderInitialCoedgeArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_Insert___")]
	public static extern void BrepBuilderInitialCoedgeArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_InsertRange___")]
	public static extern void BrepBuilderInitialCoedgeArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_RemoveAt___")]
	public static extern void BrepBuilderInitialCoedgeArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_RemoveRange___")]
	public static extern void BrepBuilderInitialCoedgeArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_Repeat___")]
	public static extern IntPtr BrepBuilderInitialCoedgeArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_Reverse__SWIG_0___")]
	public static extern void BrepBuilderInitialCoedgeArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_Reverse__SWIG_1___")]
	public static extern void BrepBuilderInitialCoedgeArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_SetRange___")]
	public static extern void BrepBuilderInitialCoedgeArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_Contains___")]
	public static extern bool BrepBuilderInitialCoedgeArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_IndexOf___")]
	public static extern int BrepBuilderInitialCoedgeArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_LastIndexOf___")]
	public static extern int BrepBuilderInitialCoedgeArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialCoedgeArray_Remove___")]
	public static extern bool BrepBuilderInitialCoedgeArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_BrepBuilderInitialCoedgeArray___")]
	public static extern void delete_BrepBuilderInitialCoedgeArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialVertexArray__SWIG_0")]
	public static extern IntPtr new_BrepBuilderInitialVertexArray__SWIG_0();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialVertexArray__SWIG_1")]
	public static extern IntPtr new_BrepBuilderInitialVertexArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialVertexArray__SWIG_2")]
	public static extern IntPtr new_BrepBuilderInitialVertexArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_size___")]
	public static extern uint BrepBuilderInitialVertexArray_size(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_capacity___")]
	public static extern uint BrepBuilderInitialVertexArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_reserve___")]
	public static extern void BrepBuilderInitialVertexArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_resize___")]
	public static extern void BrepBuilderInitialVertexArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_Clear___")]
	public static extern void BrepBuilderInitialVertexArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_Add___")]
	public static extern void BrepBuilderInitialVertexArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_getitemcopy___")]
	public static extern IntPtr BrepBuilderInitialVertexArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_getitem___")]
	public static extern IntPtr BrepBuilderInitialVertexArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_setitem___")]
	public static extern void BrepBuilderInitialVertexArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_AddRange___")]
	public static extern void BrepBuilderInitialVertexArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_GetRange___")]
	public static extern IntPtr BrepBuilderInitialVertexArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_Insert___")]
	public static extern void BrepBuilderInitialVertexArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_InsertRange___")]
	public static extern void BrepBuilderInitialVertexArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_RemoveAt___")]
	public static extern void BrepBuilderInitialVertexArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_RemoveRange___")]
	public static extern void BrepBuilderInitialVertexArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_Repeat___")]
	public static extern IntPtr BrepBuilderInitialVertexArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_Reverse__SWIG_0___")]
	public static extern void BrepBuilderInitialVertexArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_Reverse__SWIG_1___")]
	public static extern void BrepBuilderInitialVertexArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_SetRange___")]
	public static extern void BrepBuilderInitialVertexArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_Contains___")]
	public static extern bool BrepBuilderInitialVertexArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_IndexOf___")]
	public static extern int BrepBuilderInitialVertexArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_LastIndexOf___")]
	public static extern int BrepBuilderInitialVertexArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialVertexArray_Remove___")]
	public static extern bool BrepBuilderInitialVertexArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_BrepBuilderInitialVertexArray___")]
	public static extern void delete_BrepBuilderInitialVertexArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialSurfaceArray__SWIG_0")]
	public static extern IntPtr new_BrepBuilderInitialSurfaceArray__SWIG_0();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialSurfaceArray__SWIG_1")]
	public static extern IntPtr new_BrepBuilderInitialSurfaceArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialSurfaceArray__SWIG_2")]
	public static extern IntPtr new_BrepBuilderInitialSurfaceArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_size___")]
	public static extern uint BrepBuilderInitialSurfaceArray_size(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_capacity___")]
	public static extern uint BrepBuilderInitialSurfaceArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_reserve___")]
	public static extern void BrepBuilderInitialSurfaceArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_resize___")]
	public static extern void BrepBuilderInitialSurfaceArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_Clear___")]
	public static extern void BrepBuilderInitialSurfaceArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_Add___")]
	public static extern void BrepBuilderInitialSurfaceArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_getitemcopy___")]
	public static extern IntPtr BrepBuilderInitialSurfaceArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_getitem___")]
	public static extern IntPtr BrepBuilderInitialSurfaceArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_setitem___")]
	public static extern void BrepBuilderInitialSurfaceArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_AddRange___")]
	public static extern void BrepBuilderInitialSurfaceArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_GetRange___")]
	public static extern IntPtr BrepBuilderInitialSurfaceArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_Insert___")]
	public static extern void BrepBuilderInitialSurfaceArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_InsertRange___")]
	public static extern void BrepBuilderInitialSurfaceArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_RemoveAt___")]
	public static extern void BrepBuilderInitialSurfaceArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_RemoveRange___")]
	public static extern void BrepBuilderInitialSurfaceArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_Repeat___")]
	public static extern IntPtr BrepBuilderInitialSurfaceArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_Reverse__SWIG_0___")]
	public static extern void BrepBuilderInitialSurfaceArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_Reverse__SWIG_1___")]
	public static extern void BrepBuilderInitialSurfaceArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_SetRange___")]
	public static extern void BrepBuilderInitialSurfaceArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_Contains___")]
	public static extern bool BrepBuilderInitialSurfaceArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_IndexOf___")]
	public static extern int BrepBuilderInitialSurfaceArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_LastIndexOf___")]
	public static extern int BrepBuilderInitialSurfaceArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialSurfaceArray_Remove___")]
	public static extern bool BrepBuilderInitialSurfaceArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_BrepBuilderInitialSurfaceArray___")]
	public static extern void delete_BrepBuilderInitialSurfaceArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialEdgeArray__SWIG_0")]
	public static extern IntPtr new_BrepBuilderInitialEdgeArray__SWIG_0();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialEdgeArray__SWIG_1")]
	public static extern IntPtr new_BrepBuilderInitialEdgeArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderInitialEdgeArray__SWIG_2")]
	public static extern IntPtr new_BrepBuilderInitialEdgeArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_size___")]
	public static extern uint BrepBuilderInitialEdgeArray_size(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_capacity___")]
	public static extern uint BrepBuilderInitialEdgeArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_reserve___")]
	public static extern void BrepBuilderInitialEdgeArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_resize___")]
	public static extern void BrepBuilderInitialEdgeArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_Clear___")]
	public static extern void BrepBuilderInitialEdgeArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_Add___")]
	public static extern void BrepBuilderInitialEdgeArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_getitemcopy___")]
	public static extern IntPtr BrepBuilderInitialEdgeArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_getitem___")]
	public static extern IntPtr BrepBuilderInitialEdgeArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_setitem___")]
	public static extern void BrepBuilderInitialEdgeArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_GetRange___")]
	public static extern IntPtr BrepBuilderInitialEdgeArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_Insert___")]
	public static extern void BrepBuilderInitialEdgeArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_RemoveAt___")]
	public static extern void BrepBuilderInitialEdgeArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_RemoveRange___")]
	public static extern void BrepBuilderInitialEdgeArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_Repeat___")]
	public static extern IntPtr BrepBuilderInitialEdgeArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_SetRange___")]
	public static extern void BrepBuilderInitialEdgeArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_Contains___")]
	public static extern bool BrepBuilderInitialEdgeArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_IndexOf___")]
	public static extern int BrepBuilderInitialEdgeArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_LastIndexOf___")]
	public static extern int BrepBuilderInitialEdgeArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderInitialEdgeArray_Remove___")]
	public static extern bool BrepBuilderInitialEdgeArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_BrepBuilderInitialEdgeArray___")]
	public static extern void delete_BrepBuilderInitialEdgeArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderShellsArray__SWIG_0")]
	public static extern IntPtr new_BrepBuilderShellsArray__SWIG_0();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderShellsArray__SWIG_1")]
	public static extern IntPtr new_BrepBuilderShellsArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderShellsArray__SWIG_2")]
	public static extern IntPtr new_BrepBuilderShellsArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_size___")]
	public static extern uint BrepBuilderShellsArray_size(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_capacity___")]
	public static extern uint BrepBuilderShellsArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_reserve___")]
	public static extern void BrepBuilderShellsArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_resize___")]
	public static extern void BrepBuilderShellsArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_Clear___")]
	public static extern void BrepBuilderShellsArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_Add___")]
	public static extern void BrepBuilderShellsArray_Add(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_getitemcopy___")]
	public static extern IntPtr BrepBuilderShellsArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_getitem___")]
	public static extern IntPtr BrepBuilderShellsArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_setitem___")]
	public static extern void BrepBuilderShellsArray_setitem(HandleRef jarg1, int jarg2, IntPtr jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_AddRange___")]
	public static extern void BrepBuilderShellsArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_GetRange___")]
	public static extern IntPtr BrepBuilderShellsArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_Insert___")]
	public static extern void BrepBuilderShellsArray_Insert(HandleRef jarg1, int jarg2, IntPtr jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_InsertRange___")]
	public static extern void BrepBuilderShellsArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_RemoveAt___")]
	public static extern void BrepBuilderShellsArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_RemoveRange___")]
	public static extern void BrepBuilderShellsArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_Repeat___")]
	public static extern IntPtr BrepBuilderShellsArray_Repeat(IntPtr jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_Reverse__SWIG_0___")]
	public static extern void BrepBuilderShellsArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_Reverse__SWIG_1___")]
	public static extern void BrepBuilderShellsArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_SetRange___")]
	public static extern void BrepBuilderShellsArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_Contains___")]
	public static extern bool BrepBuilderShellsArray_Contains(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_IndexOf___")]
	public static extern int BrepBuilderShellsArray_IndexOf(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_LastIndexOf___")]
	public static extern int BrepBuilderShellsArray_LastIndexOf(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderShellsArray_Remove___")]
	public static extern bool BrepBuilderShellsArray_Remove(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_BrepBuilderShellsArray___")]
	public static extern void delete_BrepBuilderShellsArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderComplexArray__SWIG_0")]
	public static extern IntPtr new_BrepBuilderComplexArray__SWIG_0();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderComplexArray__SWIG_1")]
	public static extern IntPtr new_BrepBuilderComplexArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_new_BrepBuilderComplexArray__SWIG_2")]
	public static extern IntPtr new_BrepBuilderComplexArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_size___")]
	public static extern uint BrepBuilderComplexArray_size(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_capacity___")]
	public static extern uint BrepBuilderComplexArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_reserve___")]
	public static extern void BrepBuilderComplexArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_resize___")]
	public static extern void BrepBuilderComplexArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_Clear___")]
	public static extern void BrepBuilderComplexArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_Add___")]
	public static extern void BrepBuilderComplexArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_getitemcopy___")]
	public static extern IntPtr BrepBuilderComplexArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_getitem___")]
	public static extern IntPtr BrepBuilderComplexArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_setitem___")]
	public static extern void BrepBuilderComplexArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_AddRange___")]
	public static extern void BrepBuilderComplexArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_GetRange___")]
	public static extern IntPtr BrepBuilderComplexArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_Insert___")]
	public static extern void BrepBuilderComplexArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_InsertRange___")]
	public static extern void BrepBuilderComplexArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_RemoveAt___")]
	public static extern void BrepBuilderComplexArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_RemoveRange___")]
	public static extern void BrepBuilderComplexArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_Repeat___")]
	public static extern IntPtr BrepBuilderComplexArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_Reverse__SWIG_0___")]
	public static extern void BrepBuilderComplexArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_Reverse__SWIG_1___")]
	public static extern void BrepBuilderComplexArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_SetRange___")]
	public static extern void BrepBuilderComplexArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_Contains___")]
	public static extern bool BrepBuilderComplexArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_IndexOf___")]
	public static extern int BrepBuilderComplexArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_LastIndexOf___")]
	public static extern int BrepBuilderComplexArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_BrepBuilderComplexArray_Remove___")]
	public static extern bool BrepBuilderComplexArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_BrepBuilderComplexArray___")]
	public static extern void delete_BrepBuilderComplexArray(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_std_pair_bool_OdInt64__SWIG_0___")]
	public static extern IntPtr new_std_pair_bool_OdInt64__SWIG_0();

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_std_pair_bool_OdInt64__SWIG_1___")]
	public static extern IntPtr new_std_pair_bool_OdInt64__SWIG_1(bool jarg1, long jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_new_std_pair_bool_OdInt64__SWIG_2___")]
	public static extern IntPtr new_std_pair_bool_OdInt64__SWIG_2(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_std_pair_bool_OdInt64_first_set___")]
	public static extern void std_pair_bool_OdInt64_first_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_std_pair_bool_OdInt64_first_get___")]
	public static extern bool std_pair_bool_OdInt64_first_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_std_pair_bool_OdInt64_second_set___")]
	public static extern void std_pair_bool_OdInt64_second_set(HandleRef jarg1, long jarg2);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_std_pair_bool_OdInt64_second_get___")]
	public static extern long std_pair_bool_OdInt64_second_get(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_delete_std_pair_bool_OdInt64___")]
	public static extern void delete_std_pair_bool_OdInt64(HandleRef jarg1);

	[DllImport("OdSwig_TD_BrepBuilderFiller_26.10_17.dll", EntryPoint = "CSharp_ODAfKernelfTD_BrepBuilderFiller_OdBaseMaterialAndColorHelper_SWIGUpcast___")]
	public static extern IntPtr OdBaseMaterialAndColorHelper_SWIGUpcast(IntPtr jarg1);
}

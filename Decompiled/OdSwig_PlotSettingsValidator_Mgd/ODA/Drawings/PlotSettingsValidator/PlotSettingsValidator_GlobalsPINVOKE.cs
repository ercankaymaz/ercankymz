using System;
using System.IO;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.PlotSettingsValidator;

internal class PlotSettingsValidator_GlobalsPINVOKE
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

		[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll")]
		public static extern void SWIGRegisterExceptionCallbacks_PlotSettingsValidator_Globals(ExceptionDelegate applicationDelegate, ExceptionDelegate arithmeticDelegate, ExceptionDelegate divideByZeroDelegate, ExceptionDelegate indexOutOfRangeDelegate, ExceptionDelegate invalidCastDelegate, ExceptionDelegate invalidOperationDelegate, ExceptionDelegate ioDelegate, ExceptionDelegate nullReferenceDelegate, ExceptionDelegate outOfMemoryDelegate, ExceptionDelegate overflowDelegate, ExceptionDelegate systemExceptionDelegate);

		[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_PlotSettingsValidator_Globals")]
		public static extern void SWIGRegisterExceptionCallbacksArgument_PlotSettingsValidator_Globals(ExceptionArgumentDelegate argumentDelegate, ExceptionArgumentDelegate argumentNullDelegate, ExceptionArgumentDelegate argumentOutOfRangeDelegate);

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
			SWIGRegisterExceptionCallbacks_PlotSettingsValidator_Globals(applicationDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, outOfMemoryDelegate, overflowDelegate, systemDelegate);
			SWIGRegisterExceptionCallbacksArgument_PlotSettingsValidator_Globals(argumentDelegate, argumentNullDelegate, argumentOutOfRangeDelegate);
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

		[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll")]
		public static extern void SWIGRegisterStringCallback_PlotSettingsValidator_Globals(SWIGStringDelegate stringDelegate);

		private static string CreateString(string cString)
		{
			return cString;
		}

		static SWIGStringHelper()
		{
			stringDelegate = CreateString;
			SWIGRegisterStringCallback_PlotSettingsValidator_Globals(stringDelegate);
		}
	}

	private class CustomExceptionHelper
	{
		public delegate void CustomExceptionDelegate(IntPtr NewContext);

		private static CustomExceptionDelegate customDelegate;

		[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll")]
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

	static PlotSettingsValidator_GlobalsPINVOKE()
	{
		swigExceptionHelper = new SWIGExceptionHelper();
		swigStringHelper = new SWIGStringHelper();
		exceptionHelper = new CustomExceptionHelper();
	}

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_UINT_MAX_get___")]
	public static extern uint UINT_MAX_get();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_ULONG_MAX_get___")]
	public static extern uint ULONG_MAX_get();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator__MSC_VER_get___")]
	public static extern int _MSC_VER_get();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_ODCHAR_IS_INT16LE_get___")]
	public static extern int ODCHAR_IS_INT16LE_get();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OD_SIZEOF_INT_get___")]
	public static extern int OD_SIZEOF_INT_get();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OD_SIZEOF_LONG_get___")]
	public static extern int OD_SIZEOF_LONG_get();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_PERCENT18LONG_get___")]
	public static extern string PERCENT18LONG_get();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_HANDLEFORMAT_get___")]
	public static extern string HANDLEFORMAT_get();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_PRId64_get___")]
	public static extern string PRId64_get();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_PRIu64_get___")]
	public static extern string PRIu64_get();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_PRIx64_get___")]
	public static extern string PRIx64_get();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_PRIX64_get___")]
	public static extern string PRIX64_get();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OD_SIZEOF_PTR_get___")]
	public static extern int OD_SIZEOF_PTR_get();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_throw_native_exception_string___")]
	public static extern void throw_native_exception_string([MarshalAs(UnmanagedType.LPWStr)] string jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_throw_native_OdError__SWIG_0___")]
	public static extern void throw_native_OdError__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_throw_native_OdError__SWIG_1___")]
	public static extern void throw_native_OdError__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_throw_native_OdError__SWIG_2___")]
	public static extern void throw_native_OdError__SWIG_2(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_sec_set___")]
	public static extern void tm_tm_sec_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_sec_get___")]
	public static extern int tm_tm_sec_get(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_min_set___")]
	public static extern void tm_tm_min_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_min_get___")]
	public static extern int tm_tm_min_get(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_hour_set___")]
	public static extern void tm_tm_hour_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_hour_get___")]
	public static extern int tm_tm_hour_get(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_mday_set___")]
	public static extern void tm_tm_mday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_mday_get___")]
	public static extern int tm_tm_mday_get(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_mon_set___")]
	public static extern void tm_tm_mon_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_mon_get___")]
	public static extern int tm_tm_mon_get(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_year_set___")]
	public static extern void tm_tm_year_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_year_get___")]
	public static extern int tm_tm_year_get(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_wday_set___")]
	public static extern void tm_tm_wday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_wday_get___")]
	public static extern int tm_tm_wday_get(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_yday_set___")]
	public static extern void tm_tm_yday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_yday_get___")]
	public static extern int tm_tm_yday_get(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_isdst_set___")]
	public static extern void tm_tm_isdst_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_tm_tm_isdst_get___")]
	public static extern int tm_tm_isdst_get(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_new_tm___")]
	public static extern IntPtr new_tm();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_delete_tm___")]
	public static extern void delete_tm(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_cast___")]
	public static extern IntPtr OdDbPlotSettingsValidatorCustomMediaPE_cast(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_desc___")]
	public static extern IntPtr OdDbPlotSettingsValidatorCustomMediaPE_desc();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_isA___")]
	public static extern IntPtr OdDbPlotSettingsValidatorCustomMediaPE_isA(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_isASwigExplicitOdDbPlotSettingsValidatorCustomMediaPE___")]
	public static extern IntPtr OdDbPlotSettingsValidatorCustomMediaPE_isASwigExplicitOdDbPlotSettingsValidatorCustomMediaPE(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_queryX___")]
	public static extern IntPtr OdDbPlotSettingsValidatorCustomMediaPE_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_queryXSwigExplicitOdDbPlotSettingsValidatorCustomMediaPE___")]
	public static extern IntPtr OdDbPlotSettingsValidatorCustomMediaPE_queryXSwigExplicitOdDbPlotSettingsValidatorCustomMediaPE(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_createObject___")]
	public static extern IntPtr OdDbPlotSettingsValidatorCustomMediaPE_createObject();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_addMedia___")]
	public static extern int OdDbPlotSettingsValidatorCustomMediaPE_addMedia(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_editMedia___")]
	public static extern int OdDbPlotSettingsValidatorCustomMediaPE_editMedia(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_removeMedia___")]
	public static extern int OdDbPlotSettingsValidatorCustomMediaPE_removeMedia(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_getMedia__SWIG_0___")]
	public static extern int OdDbPlotSettingsValidatorCustomMediaPE_getMedia__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_getMedia__SWIG_1___")]
	public static extern int OdDbPlotSettingsValidatorCustomMediaPE_getMedia__SWIG_1(HandleRef jarg1, ushort jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_clear___")]
	public static extern int OdDbPlotSettingsValidatorCustomMediaPE_clear(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_size___")]
	public static extern ushort OdDbPlotSettingsValidatorCustomMediaPE_size(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_getRealClassName___")]
	public static extern string OdDbPlotSettingsValidatorCustomMediaPE_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_new_OdDbPlotSettingsValidatorCustomMediaPE___")]
	public static extern IntPtr new_OdDbPlotSettingsValidatorCustomMediaPE();

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_delete_OdDbPlotSettingsValidatorCustomMediaPE___")]
	public static extern void delete_OdDbPlotSettingsValidatorCustomMediaPE(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_director_connect___")]
	public static extern void OdDbPlotSettingsValidatorCustomMediaPE_director_connect(HandleRef jarg1, OdDbPlotSettingsValidatorCustomMediaPE.SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_0 delegate0, OdDbPlotSettingsValidatorCustomMediaPE.SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_1 delegate1, OdDbPlotSettingsValidatorCustomMediaPE.SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_2 delegate2, OdDbPlotSettingsValidatorCustomMediaPE.SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_3 delegate3, OdDbPlotSettingsValidatorCustomMediaPE.SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_4 delegate4, OdDbPlotSettingsValidatorCustomMediaPE.SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_5 delegate5, OdDbPlotSettingsValidatorCustomMediaPE.SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_6 delegate6, OdDbPlotSettingsValidatorCustomMediaPE.SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_7 delegate7, OdDbPlotSettingsValidatorCustomMediaPE.SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_8 delegate8, OdDbPlotSettingsValidatorCustomMediaPE.SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_9 delegate9);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdPlotSettingsValidatorCustomMediaPEImpl_getRealClassName___")]
	public static extern string OdPlotSettingsValidatorCustomMediaPEImpl_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_delete_OdPlotSettingsValidatorCustomMediaPEImpl___")]
	public static extern void delete_OdPlotSettingsValidatorCustomMediaPEImpl(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdPlotSettingsValidatorPEImpl_getMediaList___")]
	public static extern int OdPlotSettingsValidatorPEImpl_getMediaList(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, IntPtr jarg3, bool jarg4);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdPlotSettingsValidatorPEImpl_getRealClassName___")]
	public static extern string OdPlotSettingsValidatorPEImpl_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_delete_OdPlotSettingsValidatorPEImpl___")]
	public static extern void delete_OdPlotSettingsValidatorPEImpl(HandleRef jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdDbPlotSettingsValidatorCustomMediaPE_SWIGUpcast___")]
	public static extern IntPtr OdDbPlotSettingsValidatorCustomMediaPE_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdPlotSettingsValidatorCustomMediaPEImpl_SWIGUpcast___")]
	public static extern IntPtr OdPlotSettingsValidatorCustomMediaPEImpl_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdPlotSettingsValidatorPEImpl_SWIGUpcast___")]
	public static extern IntPtr OdPlotSettingsValidatorPEImpl_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PlotSettingsValidator_26.10_17.dll", EntryPoint = "CSharp_ODAfDrawingsfPlotSettingsValidator_OdPlotSettingsValidatorModule_SWIGUpcast___")]
	public static extern IntPtr OdPlotSettingsValidatorModule_SWIGUpcast(IntPtr jarg1);
}

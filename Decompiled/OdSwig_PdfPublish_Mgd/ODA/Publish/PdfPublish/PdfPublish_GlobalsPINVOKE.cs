using System;
using System.IO;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

internal class PdfPublish_GlobalsPINVOKE
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

		[DllImport("OdSwig_PdfPublish_26.10_17.dll")]
		public static extern void SWIGRegisterExceptionCallbacks_PdfPublish_Globals(ExceptionDelegate applicationDelegate, ExceptionDelegate arithmeticDelegate, ExceptionDelegate divideByZeroDelegate, ExceptionDelegate indexOutOfRangeDelegate, ExceptionDelegate invalidCastDelegate, ExceptionDelegate invalidOperationDelegate, ExceptionDelegate ioDelegate, ExceptionDelegate nullReferenceDelegate, ExceptionDelegate outOfMemoryDelegate, ExceptionDelegate overflowDelegate, ExceptionDelegate systemExceptionDelegate);

		[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_PdfPublish_Globals")]
		public static extern void SWIGRegisterExceptionCallbacksArgument_PdfPublish_Globals(ExceptionArgumentDelegate argumentDelegate, ExceptionArgumentDelegate argumentNullDelegate, ExceptionArgumentDelegate argumentOutOfRangeDelegate);

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
			SWIGRegisterExceptionCallbacks_PdfPublish_Globals(applicationDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, outOfMemoryDelegate, overflowDelegate, systemDelegate);
			SWIGRegisterExceptionCallbacksArgument_PdfPublish_Globals(argumentDelegate, argumentNullDelegate, argumentOutOfRangeDelegate);
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

		[DllImport("OdSwig_PdfPublish_26.10_17.dll")]
		public static extern void SWIGRegisterStringCallback_PdfPublish_Globals(SWIGStringDelegate stringDelegate);

		private static string CreateString(string cString)
		{
			return cString;
		}

		static SWIGStringHelper()
		{
			stringDelegate = CreateString;
			SWIGRegisterStringCallback_PdfPublish_Globals(stringDelegate);
		}
	}

	private class CustomExceptionHelper
	{
		public delegate void CustomExceptionDelegate(IntPtr NewContext);

		private static CustomExceptionDelegate customDelegate;

		[DllImport("OdSwig_PdfPublish_26.10_17.dll")]
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

	static PdfPublish_GlobalsPINVOKE()
	{
		swigExceptionHelper = new SWIGExceptionHelper();
		swigStringHelper = new SWIGStringHelper();
		exceptionHelper = new CustomExceptionHelper();
	}

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_UINT_MAX_get___")]
	public static extern uint UINT_MAX_get();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_ULONG_MAX_get___")]
	public static extern uint ULONG_MAX_get();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish__MSC_VER_get___")]
	public static extern int _MSC_VER_get();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_ODCHAR_IS_INT16LE_get___")]
	public static extern int ODCHAR_IS_INT16LE_get();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OD_SIZEOF_INT_get___")]
	public static extern int OD_SIZEOF_INT_get();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OD_SIZEOF_LONG_get___")]
	public static extern int OD_SIZEOF_LONG_get();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_PERCENT18LONG_get___")]
	public static extern string PERCENT18LONG_get();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_HANDLEFORMAT_get___")]
	public static extern string HANDLEFORMAT_get();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_PRId64_get___")]
	public static extern string PRId64_get();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_PRIu64_get___")]
	public static extern string PRIu64_get();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_PRIx64_get___")]
	public static extern string PRIx64_get();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_PRIX64_get___")]
	public static extern string PRIX64_get();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OD_SIZEOF_PTR_get___")]
	public static extern int OD_SIZEOF_PTR_get();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_throw_native_exception_string___")]
	public static extern void throw_native_exception_string([MarshalAs(UnmanagedType.LPWStr)] string jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_throw_native_OdError__SWIG_0___")]
	public static extern void throw_native_OdError__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_throw_native_OdError__SWIG_1___")]
	public static extern void throw_native_OdError__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_throw_native_OdError__SWIG_2___")]
	public static extern void throw_native_OdError__SWIG_2(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_sec_set___")]
	public static extern void tm_tm_sec_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_sec_get___")]
	public static extern int tm_tm_sec_get(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_min_set___")]
	public static extern void tm_tm_min_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_min_get___")]
	public static extern int tm_tm_min_get(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_hour_set___")]
	public static extern void tm_tm_hour_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_hour_get___")]
	public static extern int tm_tm_hour_get(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_mday_set___")]
	public static extern void tm_tm_mday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_mday_get___")]
	public static extern int tm_tm_mday_get(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_mon_set___")]
	public static extern void tm_tm_mon_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_mon_get___")]
	public static extern int tm_tm_mon_get(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_year_set___")]
	public static extern void tm_tm_year_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_year_get___")]
	public static extern int tm_tm_year_get(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_wday_set___")]
	public static extern void tm_tm_wday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_wday_get___")]
	public static extern int tm_tm_wday_get(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_yday_set___")]
	public static extern void tm_tm_yday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_yday_get___")]
	public static extern int tm_tm_yday_get(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_isdst_set___")]
	public static extern void tm_tm_isdst_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_tm_tm_isdst_get___")]
	public static extern int tm_tm_isdst_get(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_tm___")]
	public static extern IntPtr new_tm();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_tm___")]
	public static extern void delete_tm(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObject_cast___")]
	public static extern IntPtr OdPdfPublish_OdObject_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObject_desc___")]
	public static extern IntPtr OdPdfPublish_OdObject_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObject_isA___")]
	public static extern IntPtr OdPdfPublish_OdObject_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObject_queryX___")]
	public static extern IntPtr OdPdfPublish_OdObject_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObject_createObject___")]
	public static extern IntPtr OdPdfPublish_OdObject_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdObject___")]
	public static extern void delete_OdPdfPublish_OdObject(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObject_isEmpty___")]
	public static extern bool OdPdfPublish_OdObject_isEmpty(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObject_isValid___")]
	public static extern bool OdPdfPublish_OdObject_isValid(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObject_clear___")]
	public static extern void OdPdfPublish_OdObject_clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObject_getRealClassName___")]
	public static extern string OdPdfPublish_OdObject_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_Od2dGeometryLayer___")]
	public static extern IntPtr new_OdPdfPublish_Od2dGeometryLayer();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_cast___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryLayer_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_desc___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryLayer_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_isA___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryLayer_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_isASwigExplicitOdPdfPublish_Od2dGeometryLayer___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryLayer_isASwigExplicitOdPdfPublish_Od2dGeometryLayer(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_queryX___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryLayer_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_queryXSwigExplicitOdPdfPublish_Od2dGeometryLayer___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryLayer_queryXSwigExplicitOdPdfPublish_Od2dGeometryLayer(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_createObject___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryLayer_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_Od2dGeometryLayer___")]
	public static extern void delete_OdPdfPublish_Od2dGeometryLayer(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_setName___")]
	public static extern void OdPdfPublish_Od2dGeometryLayer_setName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_setVisible___")]
	public static extern void OdPdfPublish_Od2dGeometryLayer_setVisible(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_setLocked___")]
	public static extern void OdPdfPublish_Od2dGeometryLayer_setLocked(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_getName___")]
	public static extern void OdPdfPublish_Od2dGeometryLayer_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_getVisible___")]
	public static extern void OdPdfPublish_Od2dGeometryLayer_getVisible(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_getLocked___")]
	public static extern void OdPdfPublish_Od2dGeometryLayer_getLocked(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_getRealClassName___")]
	public static extern string OdPdfPublish_Od2dGeometryLayer_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_director_connect___")]
	public static extern void OdPdfPublish_Od2dGeometryLayer_director_connect(HandleRef jarg1, OdPdfPublish_Od2dGeometryLayer.SwigDelegateOdPdfPublish_Od2dGeometryLayer_0 delegate0, OdPdfPublish_Od2dGeometryLayer.SwigDelegateOdPdfPublish_Od2dGeometryLayer_1 delegate1, OdPdfPublish_Od2dGeometryLayer.SwigDelegateOdPdfPublish_Od2dGeometryLayer_2 delegate2, OdPdfPublish_Od2dGeometryLayer.SwigDelegateOdPdfPublish_Od2dGeometryLayer_3 delegate3, OdPdfPublish_Od2dGeometryLayer.SwigDelegateOdPdfPublish_Od2dGeometryLayer_4 delegate4, OdPdfPublish_Od2dGeometryLayer.SwigDelegateOdPdfPublish_Od2dGeometryLayer_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdMarkupAnnotation___")]
	public static extern IntPtr new_OdPdfPublish_OdMarkupAnnotation();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_cast___")]
	public static extern IntPtr OdPdfPublish_OdMarkupAnnotation_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_desc___")]
	public static extern IntPtr OdPdfPublish_OdMarkupAnnotation_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_isA___")]
	public static extern IntPtr OdPdfPublish_OdMarkupAnnotation_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_isASwigExplicitOdPdfPublish_OdMarkupAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdMarkupAnnotation_isASwigExplicitOdPdfPublish_OdMarkupAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_queryX___")]
	public static extern IntPtr OdPdfPublish_OdMarkupAnnotation_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_queryXSwigExplicitOdPdfPublish_OdMarkupAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdMarkupAnnotation_queryXSwigExplicitOdPdfPublish_OdMarkupAnnotation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_createObject___")]
	public static extern IntPtr OdPdfPublish_OdMarkupAnnotation_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdMarkupAnnotation___")]
	public static extern void delete_OdPdfPublish_OdMarkupAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_setPopupLocation___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_setPopupLocation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_setOpen___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_setOpen(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_setContents___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_setContents(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_setTitle___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_setTitle(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_setDescription___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_setDescription(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_setCreationDate___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_setCreationDate(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_setOpacity___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_setOpacity(HandleRef jarg1, byte jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_setColor___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_setColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_setLock___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_setLock(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_setMarkedState___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_setMarkedState(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_setReviewState___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_setReviewState(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_getPopupLocation___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_getPopupLocation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_getOpen___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_getOpen(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_getContents___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_getContents(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_getTitle___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_getTitle(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_getDescription___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_getDescription(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_getCreationDate___")]
	public static extern bool OdPdfPublish_OdMarkupAnnotation_getCreationDate(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_getOpacity___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_getOpacity(HandleRef jarg1, out byte jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_getColor___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_getColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_getLock___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_getLock(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_getMarkedState___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_getMarkedState(HandleRef jarg1, out OdPdfPublish_MarkupAnnotations_MarkupAnnotationMarkedStates jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_getReviewState___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_getReviewState(HandleRef jarg1, out OdPdfPublish_MarkupAnnotations_MarkupAnnotationReviewStates jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_getRealClassName___")]
	public static extern string OdPdfPublish_OdMarkupAnnotation_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_director_connect___")]
	public static extern void OdPdfPublish_OdMarkupAnnotation_director_connect(HandleRef jarg1, OdPdfPublish_OdMarkupAnnotation.SwigDelegateOdPdfPublish_OdMarkupAnnotation_0 delegate0, OdPdfPublish_OdMarkupAnnotation.SwigDelegateOdPdfPublish_OdMarkupAnnotation_1 delegate1, OdPdfPublish_OdMarkupAnnotation.SwigDelegateOdPdfPublish_OdMarkupAnnotation_2 delegate2, OdPdfPublish_OdMarkupAnnotation.SwigDelegateOdPdfPublish_OdMarkupAnnotation_3 delegate3, OdPdfPublish_OdMarkupAnnotation.SwigDelegateOdPdfPublish_OdMarkupAnnotation_4 delegate4, OdPdfPublish_OdMarkupAnnotation.SwigDelegateOdPdfPublish_OdMarkupAnnotation_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdImage___")]
	public static extern IntPtr new_OdPdfPublish_OdImage();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_cast___")]
	public static extern IntPtr OdPdfPublish_OdImage_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_desc___")]
	public static extern IntPtr OdPdfPublish_OdImage_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_isA___")]
	public static extern IntPtr OdPdfPublish_OdImage_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_isASwigExplicitOdPdfPublish_OdImage___")]
	public static extern IntPtr OdPdfPublish_OdImage_isASwigExplicitOdPdfPublish_OdImage(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_queryX___")]
	public static extern IntPtr OdPdfPublish_OdImage_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_queryXSwigExplicitOdPdfPublish_OdImage___")]
	public static extern IntPtr OdPdfPublish_OdImage_queryXSwigExplicitOdPdfPublish_OdImage(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_createObject___")]
	public static extern IntPtr OdPdfPublish_OdImage_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdImage___")]
	public static extern void delete_OdPdfPublish_OdImage(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_setFile___")]
	public static extern void OdPdfPublish_OdImage_setFile(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_setImage___")]
	public static extern void OdPdfPublish_OdImage_setImage(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_setSize___")]
	public static extern void OdPdfPublish_OdImage_setSize(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_getFile___")]
	public static extern void OdPdfPublish_OdImage_getFile(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_getImage___")]
	public static extern void OdPdfPublish_OdImage_getImage(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_getSize___")]
	public static extern void OdPdfPublish_OdImage_getSize(HandleRef jarg1, out int jarg2, out int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_setLayer___")]
	public static extern void OdPdfPublish_OdImage_setLayer(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_getLayer___")]
	public static extern void OdPdfPublish_OdImage_getLayer(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_getRealClassName___")]
	public static extern string OdPdfPublish_OdImage_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_director_connect___")]
	public static extern void OdPdfPublish_OdImage_director_connect(HandleRef jarg1, OdPdfPublish_OdImage.SwigDelegateOdPdfPublish_OdImage_0 delegate0, OdPdfPublish_OdImage.SwigDelegateOdPdfPublish_OdImage_1 delegate1, OdPdfPublish_OdImage.SwigDelegateOdPdfPublish_OdImage_2 delegate2, OdPdfPublish_OdImage.SwigDelegateOdPdfPublish_OdImage_3 delegate3, OdPdfPublish_OdImage.SwigDelegateOdPdfPublish_OdImage_4 delegate4, OdPdfPublish_OdImage.SwigDelegateOdPdfPublish_OdImage_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdCaretAnnotation___")]
	public static extern IntPtr new_OdPdfPublish_OdCaretAnnotation();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotation_cast___")]
	public static extern IntPtr OdPdfPublish_OdCaretAnnotation_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotation_desc___")]
	public static extern IntPtr OdPdfPublish_OdCaretAnnotation_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotation_isA___")]
	public static extern IntPtr OdPdfPublish_OdCaretAnnotation_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotation_isASwigExplicitOdPdfPublish_OdCaretAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdCaretAnnotation_isASwigExplicitOdPdfPublish_OdCaretAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotation_queryX___")]
	public static extern IntPtr OdPdfPublish_OdCaretAnnotation_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotation_queryXSwigExplicitOdPdfPublish_OdCaretAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdCaretAnnotation_queryXSwigExplicitOdPdfPublish_OdCaretAnnotation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotation_createObject___")]
	public static extern IntPtr OdPdfPublish_OdCaretAnnotation_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCaretAnnotation___")]
	public static extern void delete_OdPdfPublish_OdCaretAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotation_getRealClassName___")]
	public static extern string OdPdfPublish_OdCaretAnnotation_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotation_director_connect___")]
	public static extern void OdPdfPublish_OdCaretAnnotation_director_connect(HandleRef jarg1, OdPdfPublish_OdCaretAnnotation.SwigDelegateOdPdfPublish_OdCaretAnnotation_0 delegate0, OdPdfPublish_OdCaretAnnotation.SwigDelegateOdPdfPublish_OdCaretAnnotation_1 delegate1, OdPdfPublish_OdCaretAnnotation.SwigDelegateOdPdfPublish_OdCaretAnnotation_2 delegate2, OdPdfPublish_OdCaretAnnotation.SwigDelegateOdPdfPublish_OdCaretAnnotation_3 delegate3, OdPdfPublish_OdCaretAnnotation.SwigDelegateOdPdfPublish_OdCaretAnnotation_4 delegate4, OdPdfPublish_OdCaretAnnotation.SwigDelegateOdPdfPublish_OdCaretAnnotation_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdTextMarkupAnnotation___")]
	public static extern IntPtr new_OdPdfPublish_OdTextMarkupAnnotation();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotation_cast___")]
	public static extern IntPtr OdPdfPublish_OdTextMarkupAnnotation_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotation_desc___")]
	public static extern IntPtr OdPdfPublish_OdTextMarkupAnnotation_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotation_isA___")]
	public static extern IntPtr OdPdfPublish_OdTextMarkupAnnotation_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotation_isASwigExplicitOdPdfPublish_OdTextMarkupAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdTextMarkupAnnotation_isASwigExplicitOdPdfPublish_OdTextMarkupAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotation_queryX___")]
	public static extern IntPtr OdPdfPublish_OdTextMarkupAnnotation_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotation_queryXSwigExplicitOdPdfPublish_OdTextMarkupAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdTextMarkupAnnotation_queryXSwigExplicitOdPdfPublish_OdTextMarkupAnnotation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotation_createObject___")]
	public static extern IntPtr OdPdfPublish_OdTextMarkupAnnotation_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdTextMarkupAnnotation___")]
	public static extern void delete_OdPdfPublish_OdTextMarkupAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotation_setTextMarkupAnnotationType___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotation_setTextMarkupAnnotationType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotation_getTextMarkupAnnotationType___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotation_getTextMarkupAnnotationType(HandleRef jarg1, out OdPdfPublish_TextMarkupAnnotations_TextMarkupAnnotationTypes jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotation_getRealClassName___")]
	public static extern string OdPdfPublish_OdTextMarkupAnnotation_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotation_director_connect___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotation_director_connect(HandleRef jarg1, OdPdfPublish_OdTextMarkupAnnotation.SwigDelegateOdPdfPublish_OdTextMarkupAnnotation_0 delegate0, OdPdfPublish_OdTextMarkupAnnotation.SwigDelegateOdPdfPublish_OdTextMarkupAnnotation_1 delegate1, OdPdfPublish_OdTextMarkupAnnotation.SwigDelegateOdPdfPublish_OdTextMarkupAnnotation_2 delegate2, OdPdfPublish_OdTextMarkupAnnotation.SwigDelegateOdPdfPublish_OdTextMarkupAnnotation_3 delegate3, OdPdfPublish_OdTextMarkupAnnotation.SwigDelegateOdPdfPublish_OdTextMarkupAnnotation_4 delegate4, OdPdfPublish_OdTextMarkupAnnotation.SwigDelegateOdPdfPublish_OdTextMarkupAnnotation_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdBaseNodeMotion___")]
	public static extern IntPtr new_OdPdfPublish_OdBaseNodeMotion();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdBaseNodeMotion___")]
	public static extern void delete_OdPdfPublish_OdBaseNodeMotion(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_getName___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotion_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_getNameSwigExplicitOdPdfPublish_OdBaseNodeMotion___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotion_getNameSwigExplicitOdPdfPublish_OdBaseNodeMotion(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_getTransformation___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotion_getTransformation(HandleRef jarg1, out OdGeMatrix3d jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_getTransformationSwigExplicitOdPdfPublish_OdBaseNodeMotion___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotion_getTransformationSwigExplicitOdPdfPublish_OdBaseNodeMotion(HandleRef jarg1, out OdGeMatrix3d jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_getColor___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotion_getColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_getColorSwigExplicitOdPdfPublish_OdBaseNodeMotion___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotion_getColorSwigExplicitOdPdfPublish_OdBaseNodeMotion(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_getOpacity___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotion_getOpacity(HandleRef jarg1, out double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_getOpacitySwigExplicitOdPdfPublish_OdBaseNodeMotion___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotion_getOpacitySwigExplicitOdPdfPublish_OdBaseNodeMotion(HandleRef jarg1, out double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_getVisible___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotion_getVisible(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_getVisibleSwigExplicitOdPdfPublish_OdBaseNodeMotion___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotion_getVisibleSwigExplicitOdPdfPublish_OdBaseNodeMotion(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_step___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotion_step(HandleRef jarg1, ulong jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_stepSwigExplicitOdPdfPublish_OdBaseNodeMotion___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotion_stepSwigExplicitOdPdfPublish_OdBaseNodeMotion(HandleRef jarg1, ulong jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_getRealClassName___")]
	public static extern string OdPdfPublish_OdBaseNodeMotion_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotion_director_connect___")]
	public static extern void OdPdfPublish_OdBaseNodeMotion_director_connect(HandleRef jarg1, OdPdfPublish_OdBaseNodeMotion.SwigDelegateOdPdfPublish_OdBaseNodeMotion_0 delegate0, OdPdfPublish_OdBaseNodeMotion.SwigDelegateOdPdfPublish_OdBaseNodeMotion_1 delegate1, OdPdfPublish_OdBaseNodeMotion.SwigDelegateOdPdfPublish_OdBaseNodeMotion_2 delegate2, OdPdfPublish_OdBaseNodeMotion.SwigDelegateOdPdfPublish_OdBaseNodeMotion_3 delegate3, OdPdfPublish_OdBaseNodeMotion.SwigDelegateOdPdfPublish_OdBaseNodeMotion_4 delegate4, OdPdfPublish_OdBaseNodeMotion.SwigDelegateOdPdfPublish_OdBaseNodeMotion_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdBaseCameraMotion___")]
	public static extern IntPtr new_OdPdfPublish_OdBaseCameraMotion();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdBaseCameraMotion___")]
	public static extern void delete_OdPdfPublish_OdBaseCameraMotion(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getProjection___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getProjection(HandleRef jarg1, out OdPdfPublish_Camera_Projection jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getProjectionSwigExplicitOdPdfPublish_OdBaseCameraMotion___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getProjectionSwigExplicitOdPdfPublish_OdBaseCameraMotion(HandleRef jarg1, out OdPdfPublish_Camera_Projection jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getPosition___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getPosition(HandleRef jarg1, out OdGePoint3d jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getPositionSwigExplicitOdPdfPublish_OdBaseCameraMotion___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getPositionSwigExplicitOdPdfPublish_OdBaseCameraMotion(HandleRef jarg1, out OdGePoint3d jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getTarget___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getTarget(HandleRef jarg1, out OdGePoint3d jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getTargetSwigExplicitOdPdfPublish_OdBaseCameraMotion___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getTargetSwigExplicitOdPdfPublish_OdBaseCameraMotion(HandleRef jarg1, out OdGePoint3d jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getUpVector___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getUpVector(HandleRef jarg1, out OdGeVector3d jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getUpVectorSwigExplicitOdPdfPublish_OdBaseCameraMotion___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getUpVectorSwigExplicitOdPdfPublish_OdBaseCameraMotion(HandleRef jarg1, out OdGeVector3d jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getTargetNode___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getTargetNode(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getTargetNodeSwigExplicitOdPdfPublish_OdBaseCameraMotion___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getTargetNodeSwigExplicitOdPdfPublish_OdBaseCameraMotion(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getViewPlaneSize___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getViewPlaneSize(HandleRef jarg1, out double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getViewPlaneSizeSwigExplicitOdPdfPublish_OdBaseCameraMotion___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getViewPlaneSizeSwigExplicitOdPdfPublish_OdBaseCameraMotion(HandleRef jarg1, out double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getFov___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getFov(HandleRef jarg1, out double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getFovSwigExplicitOdPdfPublish_OdBaseCameraMotion___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_getFovSwigExplicitOdPdfPublish_OdBaseCameraMotion(HandleRef jarg1, out double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_step___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_step(HandleRef jarg1, ulong jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_stepSwigExplicitOdPdfPublish_OdBaseCameraMotion___")]
	public static extern bool OdPdfPublish_OdBaseCameraMotion_stepSwigExplicitOdPdfPublish_OdBaseCameraMotion(HandleRef jarg1, ulong jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_getRealClassName___")]
	public static extern string OdPdfPublish_OdBaseCameraMotion_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseCameraMotion_director_connect___")]
	public static extern void OdPdfPublish_OdBaseCameraMotion_director_connect(HandleRef jarg1, OdPdfPublish_OdBaseCameraMotion.SwigDelegateOdPdfPublish_OdBaseCameraMotion_0 delegate0, OdPdfPublish_OdBaseCameraMotion.SwigDelegateOdPdfPublish_OdBaseCameraMotion_1 delegate1, OdPdfPublish_OdBaseCameraMotion.SwigDelegateOdPdfPublish_OdBaseCameraMotion_2 delegate2, OdPdfPublish_OdBaseCameraMotion.SwigDelegateOdPdfPublish_OdBaseCameraMotion_3 delegate3, OdPdfPublish_OdBaseCameraMotion.SwigDelegateOdPdfPublish_OdBaseCameraMotion_4 delegate4, OdPdfPublish_OdBaseCameraMotion.SwigDelegateOdPdfPublish_OdBaseCameraMotion_5 delegate5, OdPdfPublish_OdBaseCameraMotion.SwigDelegateOdPdfPublish_OdBaseCameraMotion_6 delegate6, OdPdfPublish_OdBaseCameraMotion.SwigDelegateOdPdfPublish_OdBaseCameraMotion_7 delegate7);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdCamera___")]
	public static extern IntPtr new_OdPdfPublish_OdCamera();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_cast___")]
	public static extern IntPtr OdPdfPublish_OdCamera_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_desc___")]
	public static extern IntPtr OdPdfPublish_OdCamera_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_isA___")]
	public static extern IntPtr OdPdfPublish_OdCamera_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_isASwigExplicitOdPdfPublish_OdCamera___")]
	public static extern IntPtr OdPdfPublish_OdCamera_isASwigExplicitOdPdfPublish_OdCamera(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_queryX___")]
	public static extern IntPtr OdPdfPublish_OdCamera_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_queryXSwigExplicitOdPdfPublish_OdCamera___")]
	public static extern IntPtr OdPdfPublish_OdCamera_queryXSwigExplicitOdPdfPublish_OdCamera(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_createObject___")]
	public static extern IntPtr OdPdfPublish_OdCamera_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCamera___")]
	public static extern void delete_OdPdfPublish_OdCamera(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_dolly___")]
	public static extern void OdPdfPublish_OdCamera_dolly(HandleRef jarg1, double jarg2, double jarg3, double jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_orbit___")]
	public static extern void OdPdfPublish_OdCamera_orbit(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_pan___")]
	public static extern void OdPdfPublish_OdCamera_pan(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_roll___")]
	public static extern void OdPdfPublish_OdCamera_roll(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_zoom___")]
	public static extern void OdPdfPublish_OdCamera_zoom(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_setField___")]
	public static extern void OdPdfPublish_OdCamera_setField(HandleRef jarg1, double jarg2, double jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_setNearLimit___")]
	public static extern void OdPdfPublish_OdCamera_setNearLimit(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_setPosition___")]
	public static extern void OdPdfPublish_OdCamera_setPosition(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_setProjection__SWIG_0___")]
	public static extern void OdPdfPublish_OdCamera_setProjection__SWIG_0(HandleRef jarg1, int jarg2, double jarg3, double jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_setProjection__SWIG_1___")]
	public static extern void OdPdfPublish_OdCamera_setProjection__SWIG_1(HandleRef jarg1, int jarg2, double jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_setProjection__SWIG_2___")]
	public static extern void OdPdfPublish_OdCamera_setProjection__SWIG_2(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_setTarget___")]
	public static extern void OdPdfPublish_OdCamera_setTarget(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_setUpVector___")]
	public static extern void OdPdfPublish_OdCamera_setUpVector(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_getField___")]
	public static extern void OdPdfPublish_OdCamera_getField(HandleRef jarg1, out double jarg2, out double jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_getNearLimit___")]
	public static extern void OdPdfPublish_OdCamera_getNearLimit(HandleRef jarg1, out double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_getProjection___")]
	public static extern void OdPdfPublish_OdCamera_getProjection(HandleRef jarg1, out OdPdfPublish_Camera_Projection jarg2, out double jarg3, out double jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_getRealClassName___")]
	public static extern string OdPdfPublish_OdCamera_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_getPosition___")]
	public static extern IntPtr OdPdfPublish_OdCamera_getPosition(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_getTarget___")]
	public static extern IntPtr OdPdfPublish_OdCamera_getTarget(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_getUpVector___")]
	public static extern IntPtr OdPdfPublish_OdCamera_getUpVector(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_director_connect___")]
	public static extern void OdPdfPublish_OdCamera_director_connect(HandleRef jarg1, OdPdfPublish_OdCamera.SwigDelegateOdPdfPublish_OdCamera_0 delegate0, OdPdfPublish_OdCamera.SwigDelegateOdPdfPublish_OdCamera_1 delegate1, OdPdfPublish_OdCamera.SwigDelegateOdPdfPublish_OdCamera_2 delegate2, OdPdfPublish_OdCamera.SwigDelegateOdPdfPublish_OdCamera_3 delegate3, OdPdfPublish_OdCamera.SwigDelegateOdPdfPublish_OdCamera_4 delegate4, OdPdfPublish_OdCamera.SwigDelegateOdPdfPublish_OdCamera_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdTilingPattern___")]
	public static extern IntPtr new_OdPdfPublish_OdTilingPattern();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_cast___")]
	public static extern IntPtr OdPdfPublish_OdTilingPattern_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_desc___")]
	public static extern IntPtr OdPdfPublish_OdTilingPattern_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_isA___")]
	public static extern IntPtr OdPdfPublish_OdTilingPattern_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_isASwigExplicitOdPdfPublish_OdTilingPattern___")]
	public static extern IntPtr OdPdfPublish_OdTilingPattern_isASwigExplicitOdPdfPublish_OdTilingPattern(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_queryX___")]
	public static extern IntPtr OdPdfPublish_OdTilingPattern_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_queryXSwigExplicitOdPdfPublish_OdTilingPattern___")]
	public static extern IntPtr OdPdfPublish_OdTilingPattern_queryXSwigExplicitOdPdfPublish_OdTilingPattern(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_createObject___")]
	public static extern IntPtr OdPdfPublish_OdTilingPattern_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdTilingPattern___")]
	public static extern void delete_OdPdfPublish_OdTilingPattern(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_setGeometryBlock___")]
	public static extern void OdPdfPublish_OdTilingPattern_setGeometryBlock(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_setSize___")]
	public static extern void OdPdfPublish_OdTilingPattern_setSize(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_setXStep___")]
	public static extern void OdPdfPublish_OdTilingPattern_setXStep(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_setYStep___")]
	public static extern void OdPdfPublish_OdTilingPattern_setYStep(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_getGeometryBlock___")]
	public static extern void OdPdfPublish_OdTilingPattern_getGeometryBlock(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_getSize___")]
	public static extern void OdPdfPublish_OdTilingPattern_getSize(HandleRef jarg1, out int jarg2, out int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_getXStep___")]
	public static extern void OdPdfPublish_OdTilingPattern_getXStep(HandleRef jarg1, out int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_getYStep___")]
	public static extern void OdPdfPublish_OdTilingPattern_getYStep(HandleRef jarg1, out int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_getRealClassName___")]
	public static extern string OdPdfPublish_OdTilingPattern_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_director_connect___")]
	public static extern void OdPdfPublish_OdTilingPattern_director_connect(HandleRef jarg1, OdPdfPublish_OdTilingPattern.SwigDelegateOdPdfPublish_OdTilingPattern_0 delegate0, OdPdfPublish_OdTilingPattern.SwigDelegateOdPdfPublish_OdTilingPattern_1 delegate1, OdPdfPublish_OdTilingPattern.SwigDelegateOdPdfPublish_OdTilingPattern_2 delegate2, OdPdfPublish_OdTilingPattern.SwigDelegateOdPdfPublish_OdTilingPattern_3 delegate3, OdPdfPublish_OdTilingPattern.SwigDelegateOdPdfPublish_OdTilingPattern_4 delegate4, OdPdfPublish_OdTilingPattern.SwigDelegateOdPdfPublish_OdTilingPattern_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdButton___")]
	public static extern IntPtr new_OdPdfPublish_OdButton();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_cast___")]
	public static extern IntPtr OdPdfPublish_OdButton_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_desc___")]
	public static extern IntPtr OdPdfPublish_OdButton_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_isA___")]
	public static extern IntPtr OdPdfPublish_OdButton_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_isASwigExplicitOdPdfPublish_OdButton___")]
	public static extern IntPtr OdPdfPublish_OdButton_isASwigExplicitOdPdfPublish_OdButton(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_queryX___")]
	public static extern IntPtr OdPdfPublish_OdButton_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_queryXSwigExplicitOdPdfPublish_OdButton___")]
	public static extern IntPtr OdPdfPublish_OdButton_queryXSwigExplicitOdPdfPublish_OdButton(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_createObject___")]
	public static extern IntPtr OdPdfPublish_OdButton_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdButton___")]
	public static extern void delete_OdPdfPublish_OdButton(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setName___")]
	public static extern void OdPdfPublish_OdButton_setName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setLabel___")]
	public static extern void OdPdfPublish_OdButton_setLabel(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setFont__SWIG_0___")]
	public static extern void OdPdfPublish_OdButton_setFont__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4, bool jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setFont__SWIG_1___")]
	public static extern void OdPdfPublish_OdButton_setFont__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setFont__SWIG_2___")]
	public static extern void OdPdfPublish_OdButton_setFont__SWIG_2(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setFont__SWIG_3___")]
	public static extern void OdPdfPublish_OdButton_setFont__SWIG_3(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setFont__SWIG_4___")]
	public static extern void OdPdfPublish_OdButton_setFont__SWIG_4(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setFontSize___")]
	public static extern void OdPdfPublish_OdButton_setFontSize(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setTextColor___")]
	public static extern void OdPdfPublish_OdButton_setTextColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setTooltip___")]
	public static extern void OdPdfPublish_OdButton_setTooltip(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setVisibility___")]
	public static extern void OdPdfPublish_OdButton_setVisibility(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setPrintability___")]
	public static extern void OdPdfPublish_OdButton_setPrintability(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setTextRotation___")]
	public static extern void OdPdfPublish_OdButton_setTextRotation(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setLock___")]
	public static extern void OdPdfPublish_OdButton_setLock(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setBorder___")]
	public static extern void OdPdfPublish_OdButton_setBorder(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setBorderColor___")]
	public static extern void OdPdfPublish_OdButton_setBorderColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setBorderThickness___")]
	public static extern void OdPdfPublish_OdButton_setBorderThickness(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setBorderStyle___")]
	public static extern void OdPdfPublish_OdButton_setBorderStyle(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setFillColor___")]
	public static extern void OdPdfPublish_OdButton_setFillColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setLabelPosition___")]
	public static extern void OdPdfPublish_OdButton_setLabelPosition(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setHighlighting___")]
	public static extern void OdPdfPublish_OdButton_setHighlighting(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_setIconImage___")]
	public static extern void OdPdfPublish_OdButton_setIconImage(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getName___")]
	public static extern void OdPdfPublish_OdButton_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getLabel___")]
	public static extern void OdPdfPublish_OdButton_getLabel(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getFont___")]
	public static extern void OdPdfPublish_OdButton_getFont(HandleRef jarg1, out OdPdfPublish_Text_StorageType jarg2, out OdPdfPublish_Text_StandardFontsType jarg3, ref IntPtr jarg4, out OdPdfPublish_Text_FontStyle jarg5, out OdPdfPublish_Text_Language jarg6, out bool jarg7);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getFontSize___")]
	public static extern void OdPdfPublish_OdButton_getFontSize(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getTextColor___")]
	public static extern void OdPdfPublish_OdButton_getTextColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getTooltip___")]
	public static extern void OdPdfPublish_OdButton_getTooltip(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getVisibility___")]
	public static extern void OdPdfPublish_OdButton_getVisibility(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getPrintability___")]
	public static extern void OdPdfPublish_OdButton_getPrintability(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getTextRotation___")]
	public static extern void OdPdfPublish_OdButton_getTextRotation(HandleRef jarg1, out OdPdfPublish_Text_Rotation jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getLock___")]
	public static extern void OdPdfPublish_OdButton_getLock(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getBorder___")]
	public static extern void OdPdfPublish_OdButton_getBorder(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getBorderColor___")]
	public static extern void OdPdfPublish_OdButton_getBorderColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getBorderThickness___")]
	public static extern void OdPdfPublish_OdButton_getBorderThickness(HandleRef jarg1, out OdPdfPublish_Border_Thickness jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getBorderStyle___")]
	public static extern void OdPdfPublish_OdButton_getBorderStyle(HandleRef jarg1, out OdPdfPublish_Border_Style jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getFillColor___")]
	public static extern void OdPdfPublish_OdButton_getFillColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getLabelPosition___")]
	public static extern void OdPdfPublish_OdButton_getLabelPosition(HandleRef jarg1, out OdPdfPublish_Label_Position jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getHighlighting___")]
	public static extern void OdPdfPublish_OdButton_getHighlighting(HandleRef jarg1, out OdPdfPublish_Highlighting_Mode jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getIconImage___")]
	public static extern void OdPdfPublish_OdButton_getIconImage(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_getRealClassName___")]
	public static extern string OdPdfPublish_OdButton_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_director_connect___")]
	public static extern void OdPdfPublish_OdButton_director_connect(HandleRef jarg1, OdPdfPublish_OdButton.SwigDelegateOdPdfPublish_OdButton_0 delegate0, OdPdfPublish_OdButton.SwigDelegateOdPdfPublish_OdButton_1 delegate1, OdPdfPublish_OdButton.SwigDelegateOdPdfPublish_OdButton_2 delegate2, OdPdfPublish_OdButton.SwigDelegateOdPdfPublish_OdButton_3 delegate3, OdPdfPublish_OdButton.SwigDelegateOdPdfPublish_OdButton_4 delegate4, OdPdfPublish_OdButton.SwigDelegateOdPdfPublish_OdButton_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdLink___")]
	public static extern IntPtr new_OdPdfPublish_OdLink();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_cast___")]
	public static extern IntPtr OdPdfPublish_OdLink_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_desc___")]
	public static extern IntPtr OdPdfPublish_OdLink_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_isA___")]
	public static extern IntPtr OdPdfPublish_OdLink_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_isASwigExplicitOdPdfPublish_OdLink___")]
	public static extern IntPtr OdPdfPublish_OdLink_isASwigExplicitOdPdfPublish_OdLink(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_queryX___")]
	public static extern IntPtr OdPdfPublish_OdLink_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_queryXSwigExplicitOdPdfPublish_OdLink___")]
	public static extern IntPtr OdPdfPublish_OdLink_queryXSwigExplicitOdPdfPublish_OdLink(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_createObject___")]
	public static extern IntPtr OdPdfPublish_OdLink_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdLink___")]
	public static extern void delete_OdPdfPublish_OdLink(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_setJavaScript__SWIG_0___")]
	public static extern void OdPdfPublish_OdLink_setJavaScript__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_setJavaScript__SWIG_1___")]
	public static extern void OdPdfPublish_OdLink_setJavaScript__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_setBorderWidth___")]
	public static extern void OdPdfPublish_OdLink_setBorderWidth(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_setHighlighting___")]
	public static extern void OdPdfPublish_OdLink_setHighlighting(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_setBorderColor___")]
	public static extern void OdPdfPublish_OdLink_setBorderColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_getJavaScript___")]
	public static extern void OdPdfPublish_OdLink_getJavaScript(HandleRef jarg1, ref IntPtr jarg2, out OdPdfPublish_Source_Type jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_getBorderWidth___")]
	public static extern void OdPdfPublish_OdLink_getBorderWidth(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_getHighlighting___")]
	public static extern void OdPdfPublish_OdLink_getHighlighting(HandleRef jarg1, out OdPdfPublish_Highlighting_Mode jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_getBorderColor___")]
	public static extern void OdPdfPublish_OdLink_getBorderColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_getRealClassName___")]
	public static extern string OdPdfPublish_OdLink_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_director_connect___")]
	public static extern void OdPdfPublish_OdLink_director_connect(HandleRef jarg1, OdPdfPublish_OdLink.SwigDelegateOdPdfPublish_OdLink_0 delegate0, OdPdfPublish_OdLink.SwigDelegateOdPdfPublish_OdLink_1 delegate1, OdPdfPublish_OdLink.SwigDelegateOdPdfPublish_OdLink_2 delegate2, OdPdfPublish_OdLink.SwigDelegateOdPdfPublish_OdLink_3 delegate3, OdPdfPublish_OdLink.SwigDelegateOdPdfPublish_OdLink_4 delegate4, OdPdfPublish_OdLink.SwigDelegateOdPdfPublish_OdLink_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdTextField___")]
	public static extern IntPtr new_OdPdfPublish_OdTextField();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_cast___")]
	public static extern IntPtr OdPdfPublish_OdTextField_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_desc___")]
	public static extern IntPtr OdPdfPublish_OdTextField_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_isA___")]
	public static extern IntPtr OdPdfPublish_OdTextField_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_isASwigExplicitOdPdfPublish_OdTextField___")]
	public static extern IntPtr OdPdfPublish_OdTextField_isASwigExplicitOdPdfPublish_OdTextField(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_queryX___")]
	public static extern IntPtr OdPdfPublish_OdTextField_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_queryXSwigExplicitOdPdfPublish_OdTextField___")]
	public static extern IntPtr OdPdfPublish_OdTextField_queryXSwigExplicitOdPdfPublish_OdTextField(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_createObject___")]
	public static extern IntPtr OdPdfPublish_OdTextField_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdTextField___")]
	public static extern void delete_OdPdfPublish_OdTextField(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setName___")]
	public static extern void OdPdfPublish_OdTextField_setName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setFont__SWIG_0___")]
	public static extern void OdPdfPublish_OdTextField_setFont__SWIG_0(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setFont__SWIG_1___")]
	public static extern void OdPdfPublish_OdTextField_setFont__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4, bool jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setFont__SWIG_2___")]
	public static extern void OdPdfPublish_OdTextField_setFont__SWIG_2(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setFont__SWIG_3___")]
	public static extern void OdPdfPublish_OdTextField_setFont__SWIG_3(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setFont__SWIG_4___")]
	public static extern void OdPdfPublish_OdTextField_setFont__SWIG_4(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setFontSize___")]
	public static extern void OdPdfPublish_OdTextField_setFontSize(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setTextColor___")]
	public static extern void OdPdfPublish_OdTextField_setTextColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setTooltip___")]
	public static extern void OdPdfPublish_OdTextField_setTooltip(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setVisibility___")]
	public static extern void OdPdfPublish_OdTextField_setVisibility(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setPrintability___")]
	public static extern void OdPdfPublish_OdTextField_setPrintability(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setLock___")]
	public static extern void OdPdfPublish_OdTextField_setLock(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setBorder___")]
	public static extern void OdPdfPublish_OdTextField_setBorder(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setBorderColor___")]
	public static extern void OdPdfPublish_OdTextField_setBorderColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setBorderThickness___")]
	public static extern void OdPdfPublish_OdTextField_setBorderThickness(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setBorderStyle___")]
	public static extern void OdPdfPublish_OdTextField_setBorderStyle(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setFillColor___")]
	public static extern void OdPdfPublish_OdTextField_setFillColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setDefaultValue___")]
	public static extern void OdPdfPublish_OdTextField_setDefaultValue(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setTextJustification___")]
	public static extern void OdPdfPublish_OdTextField_setTextJustification(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setMultiline___")]
	public static extern void OdPdfPublish_OdTextField_setMultiline(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setScrolling___")]
	public static extern void OdPdfPublish_OdTextField_setScrolling(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setReadOnly___")]
	public static extern void OdPdfPublish_OdTextField_setReadOnly(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setTextRotation___")]
	public static extern void OdPdfPublish_OdTextField_setTextRotation(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setRichText___")]
	public static extern void OdPdfPublish_OdTextField_setRichText(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_setDefaultStyle___")]
	public static extern void OdPdfPublish_OdTextField_setDefaultStyle(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getName___")]
	public static extern void OdPdfPublish_OdTextField_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getFont___")]
	public static extern void OdPdfPublish_OdTextField_getFont(HandleRef jarg1, out OdPdfPublish_Text_StorageType jarg2, out OdPdfPublish_Text_StandardFontsType jarg3, ref IntPtr jarg4, out OdPdfPublish_Text_FontStyle jarg5, out OdPdfPublish_Text_Language jarg6, out bool jarg7);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getFontSize___")]
	public static extern void OdPdfPublish_OdTextField_getFontSize(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getTextColor___")]
	public static extern void OdPdfPublish_OdTextField_getTextColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getTooltip___")]
	public static extern void OdPdfPublish_OdTextField_getTooltip(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getVisibility___")]
	public static extern void OdPdfPublish_OdTextField_getVisibility(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getPrintability___")]
	public static extern void OdPdfPublish_OdTextField_getPrintability(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getLock___")]
	public static extern void OdPdfPublish_OdTextField_getLock(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getBorder___")]
	public static extern void OdPdfPublish_OdTextField_getBorder(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getBorderColor___")]
	public static extern void OdPdfPublish_OdTextField_getBorderColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getBorderThickness___")]
	public static extern void OdPdfPublish_OdTextField_getBorderThickness(HandleRef jarg1, out OdPdfPublish_Border_Thickness jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getBorderStyle___")]
	public static extern void OdPdfPublish_OdTextField_getBorderStyle(HandleRef jarg1, out OdPdfPublish_Border_Style jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getFillColor___")]
	public static extern void OdPdfPublish_OdTextField_getFillColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getDefaultValue___")]
	public static extern void OdPdfPublish_OdTextField_getDefaultValue(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getTextJustification___")]
	public static extern void OdPdfPublish_OdTextField_getTextJustification(HandleRef jarg1, out OdPdfPublish_Text_Justification jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getMultiline___")]
	public static extern void OdPdfPublish_OdTextField_getMultiline(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getScrolling___")]
	public static extern void OdPdfPublish_OdTextField_getScrolling(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getReadOnly___")]
	public static extern void OdPdfPublish_OdTextField_getReadOnly(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getTextRotation___")]
	public static extern void OdPdfPublish_OdTextField_getTextRotation(HandleRef jarg1, out OdPdfPublish_Text_Rotation jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getRichText___")]
	public static extern void OdPdfPublish_OdTextField_getRichText(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getDefaultStyle___")]
	public static extern void OdPdfPublish_OdTextField_getDefaultStyle(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_getRealClassName___")]
	public static extern string OdPdfPublish_OdTextField_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_director_connect___")]
	public static extern void OdPdfPublish_OdTextField_director_connect(HandleRef jarg1, OdPdfPublish_OdTextField.SwigDelegateOdPdfPublish_OdTextField_0 delegate0, OdPdfPublish_OdTextField.SwigDelegateOdPdfPublish_OdTextField_1 delegate1, OdPdfPublish_OdTextField.SwigDelegateOdPdfPublish_OdTextField_2 delegate2, OdPdfPublish_OdTextField.SwigDelegateOdPdfPublish_OdTextField_3 delegate3, OdPdfPublish_OdTextField.SwigDelegateOdPdfPublish_OdTextField_4 delegate4, OdPdfPublish_OdTextField.SwigDelegateOdPdfPublish_OdTextField_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdText___")]
	public static extern IntPtr new_OdPdfPublish_OdText();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_cast___")]
	public static extern IntPtr OdPdfPublish_OdText_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_desc___")]
	public static extern IntPtr OdPdfPublish_OdText_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_isA___")]
	public static extern IntPtr OdPdfPublish_OdText_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_isASwigExplicitOdPdfPublish_OdText___")]
	public static extern IntPtr OdPdfPublish_OdText_isASwigExplicitOdPdfPublish_OdText(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_queryX___")]
	public static extern IntPtr OdPdfPublish_OdText_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_queryXSwigExplicitOdPdfPublish_OdText___")]
	public static extern IntPtr OdPdfPublish_OdText_queryXSwigExplicitOdPdfPublish_OdText(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_createObject___")]
	public static extern IntPtr OdPdfPublish_OdText_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdText___")]
	public static extern void delete_OdPdfPublish_OdText(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_setText___")]
	public static extern void OdPdfPublish_OdText_setText(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_setFont__SWIG_0___")]
	public static extern void OdPdfPublish_OdText_setFont__SWIG_0(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_setFont__SWIG_1___")]
	public static extern void OdPdfPublish_OdText_setFont__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4, bool jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_setFont__SWIG_2___")]
	public static extern void OdPdfPublish_OdText_setFont__SWIG_2(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_setFont__SWIG_3___")]
	public static extern void OdPdfPublish_OdText_setFont__SWIG_3(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_setFont__SWIG_4___")]
	public static extern void OdPdfPublish_OdText_setFont__SWIG_4(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_setSize___")]
	public static extern void OdPdfPublish_OdText_setSize(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_setColor___")]
	public static extern void OdPdfPublish_OdText_setColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_addTextMarkupAnnotation___")]
	public static extern void OdPdfPublish_OdText_addTextMarkupAnnotation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_addCaretAnnotation___")]
	public static extern void OdPdfPublish_OdText_addCaretAnnotation(HandleRef jarg1, HandleRef jarg2, ushort jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_getText___")]
	public static extern void OdPdfPublish_OdText_getText(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_getFont___")]
	public static extern void OdPdfPublish_OdText_getFont(HandleRef jarg1, out OdPdfPublish_Text_StorageType jarg2, out OdPdfPublish_Text_StandardFontsType jarg3, ref IntPtr jarg4, out OdPdfPublish_Text_FontStyle jarg5, out OdPdfPublish_Text_Language jarg6, out bool jarg7);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_getSize___")]
	public static extern void OdPdfPublish_OdText_getSize(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_getColor___")]
	public static extern void OdPdfPublish_OdText_getColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_setLayer___")]
	public static extern void OdPdfPublish_OdText_setLayer(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_getLayer___")]
	public static extern void OdPdfPublish_OdText_getLayer(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_getTextMarkupAnnotations___")]
	public static extern void OdPdfPublish_OdText_getTextMarkupAnnotations(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_getCaretAnnotations___")]
	public static extern void OdPdfPublish_OdText_getCaretAnnotations(HandleRef jarg1, HandleRef jarg2, IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_getRealClassName___")]
	public static extern string OdPdfPublish_OdText_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_director_connect___")]
	public static extern void OdPdfPublish_OdText_director_connect(HandleRef jarg1, OdPdfPublish_OdText.SwigDelegateOdPdfPublish_OdText_0 delegate0, OdPdfPublish_OdText.SwigDelegateOdPdfPublish_OdText_1 delegate1, OdPdfPublish_OdText.SwigDelegateOdPdfPublish_OdText_2 delegate2, OdPdfPublish_OdText.SwigDelegateOdPdfPublish_OdText_3 delegate3, OdPdfPublish_OdText.SwigDelegateOdPdfPublish_OdText_4 delegate4, OdPdfPublish_OdText.SwigDelegateOdPdfPublish_OdText_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdAnimation___")]
	public static extern IntPtr new_OdPdfPublish_OdAnimation();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_cast___")]
	public static extern IntPtr OdPdfPublish_OdAnimation_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_desc___")]
	public static extern IntPtr OdPdfPublish_OdAnimation_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_isA___")]
	public static extern IntPtr OdPdfPublish_OdAnimation_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_isASwigExplicitOdPdfPublish_OdAnimation___")]
	public static extern IntPtr OdPdfPublish_OdAnimation_isASwigExplicitOdPdfPublish_OdAnimation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_queryX___")]
	public static extern IntPtr OdPdfPublish_OdAnimation_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_queryXSwigExplicitOdPdfPublish_OdAnimation___")]
	public static extern IntPtr OdPdfPublish_OdAnimation_queryXSwigExplicitOdPdfPublish_OdAnimation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_createObject___")]
	public static extern IntPtr OdPdfPublish_OdAnimation_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdAnimation___")]
	public static extern void delete_OdPdfPublish_OdAnimation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_setName___")]
	public static extern void OdPdfPublish_OdAnimation_setName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_setPlayOnOpenDocument___")]
	public static extern void OdPdfPublish_OdAnimation_setPlayOnOpenDocument(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_setAutoReplay___")]
	public static extern void OdPdfPublish_OdAnimation_setAutoReplay(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_setFramesPerSecond___")]
	public static extern void OdPdfPublish_OdAnimation_setFramesPerSecond(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_setFramesCount___")]
	public static extern void OdPdfPublish_OdAnimation_setFramesCount(HandleRef jarg1, ulong jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_setCameraMotion___")]
	public static extern void OdPdfPublish_OdAnimation_setCameraMotion(HandleRef jarg1, ulong jarg2, ulong jarg3, HandleRef jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_addNodeMotion___")]
	public static extern void OdPdfPublish_OdAnimation_addNodeMotion(HandleRef jarg1, ulong jarg2, ulong jarg3, HandleRef jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_getName___")]
	public static extern void OdPdfPublish_OdAnimation_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_getPlayOnOpenDocument___")]
	public static extern void OdPdfPublish_OdAnimation_getPlayOnOpenDocument(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_getAutoReplay___")]
	public static extern void OdPdfPublish_OdAnimation_getAutoReplay(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_getFramesPerSecond___")]
	public static extern void OdPdfPublish_OdAnimation_getFramesPerSecond(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_getFramesCount___")]
	public static extern void OdPdfPublish_OdAnimation_getFramesCount(HandleRef jarg1, out ulong jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_getCameraMotion___")]
	public static extern void OdPdfPublish_OdAnimation_getCameraMotion(HandleRef jarg1, out ulong jarg2, out ulong jarg3, ref IntPtr jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_getNodeMotions___")]
	public static extern void OdPdfPublish_OdAnimation_getNodeMotions(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3, HandleRef jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_getRealClassName___")]
	public static extern string OdPdfPublish_OdAnimation_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_director_connect___")]
	public static extern void OdPdfPublish_OdAnimation_director_connect(HandleRef jarg1, OdPdfPublish_OdAnimation.SwigDelegateOdPdfPublish_OdAnimation_0 delegate0, OdPdfPublish_OdAnimation.SwigDelegateOdPdfPublish_OdAnimation_1 delegate1, OdPdfPublish_OdAnimation.SwigDelegateOdPdfPublish_OdAnimation_2 delegate2, OdPdfPublish_OdAnimation.SwigDelegateOdPdfPublish_OdAnimation_3 delegate3, OdPdfPublish_OdAnimation.SwigDelegateOdPdfPublish_OdAnimation_4 delegate4, OdPdfPublish_OdAnimation.SwigDelegateOdPdfPublish_OdAnimation_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdView___")]
	public static extern IntPtr new_OdPdfPublish_OdView();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_cast___")]
	public static extern IntPtr OdPdfPublish_OdView_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_desc___")]
	public static extern IntPtr OdPdfPublish_OdView_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_isA___")]
	public static extern IntPtr OdPdfPublish_OdView_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_isASwigExplicitOdPdfPublish_OdView___")]
	public static extern IntPtr OdPdfPublish_OdView_isASwigExplicitOdPdfPublish_OdView(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_queryX___")]
	public static extern IntPtr OdPdfPublish_OdView_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_queryXSwigExplicitOdPdfPublish_OdView___")]
	public static extern IntPtr OdPdfPublish_OdView_queryXSwigExplicitOdPdfPublish_OdView(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_createObject___")]
	public static extern IntPtr OdPdfPublish_OdView_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdView___")]
	public static extern void delete_OdPdfPublish_OdView(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_setInternalName___")]
	public static extern void OdPdfPublish_OdView_setInternalName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_setExternalName___")]
	public static extern void OdPdfPublish_OdView_setExternalName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_setCamera___")]
	public static extern void OdPdfPublish_OdView_setCamera(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_setBackgroundColor___")]
	public static extern void OdPdfPublish_OdView_setBackgroundColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_setDefault___")]
	public static extern void OdPdfPublish_OdView_setDefault(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_setLighting___")]
	public static extern void OdPdfPublish_OdView_setLighting(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_setRendering___")]
	public static extern void OdPdfPublish_OdView_setRendering(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_getInternalName___")]
	public static extern void OdPdfPublish_OdView_getInternalName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_getExternalName___")]
	public static extern void OdPdfPublish_OdView_getExternalName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_getCamera___")]
	public static extern void OdPdfPublish_OdView_getCamera(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_getDefault___")]
	public static extern void OdPdfPublish_OdView_getDefault(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_getBackgroundColor___")]
	public static extern void OdPdfPublish_OdView_getBackgroundColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_getLighting___")]
	public static extern void OdPdfPublish_OdView_getLighting(HandleRef jarg1, out OdPdfPublish_Lighting_Mode jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_getRendering___")]
	public static extern void OdPdfPublish_OdView_getRendering(HandleRef jarg1, out OdPdfPublish_Rendering_Mode jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_getRealClassName___")]
	public static extern string OdPdfPublish_OdView_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_director_connect___")]
	public static extern void OdPdfPublish_OdView_director_connect(HandleRef jarg1, OdPdfPublish_OdView.SwigDelegateOdPdfPublish_OdView_0 delegate0, OdPdfPublish_OdView.SwigDelegateOdPdfPublish_OdView_1 delegate1, OdPdfPublish_OdView.SwigDelegateOdPdfPublish_OdView_2 delegate2, OdPdfPublish_OdView.SwigDelegateOdPdfPublish_OdView_3 delegate3, OdPdfPublish_OdView.SwigDelegateOdPdfPublish_OdView_4 delegate4, OdPdfPublish_OdView.SwigDelegateOdPdfPublish_OdView_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdAnnotationBorderEffect___")]
	public static extern IntPtr new_OdPdfPublish_OdAnnotationBorderEffect();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_cast___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderEffect_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_desc___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderEffect_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_isA___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderEffect_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_isASwigExplicitOdPdfPublish_OdAnnotationBorderEffect___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderEffect_isASwigExplicitOdPdfPublish_OdAnnotationBorderEffect(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_queryX___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderEffect_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_queryXSwigExplicitOdPdfPublish_OdAnnotationBorderEffect___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderEffect_queryXSwigExplicitOdPdfPublish_OdAnnotationBorderEffect(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_createObject___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderEffect_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdAnnotationBorderEffect___")]
	public static extern void delete_OdPdfPublish_OdAnnotationBorderEffect(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_setEffect___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffect_setEffect(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_setIntensity___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffect_setIntensity(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_getEffect___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffect_getEffect(HandleRef jarg1, out OdPdfPublish_Border_Effect jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_getIntensity___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffect_getIntensity(HandleRef jarg1, out double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_getRealClassName___")]
	public static extern string OdPdfPublish_OdAnnotationBorderEffect_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_director_connect___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffect_director_connect(HandleRef jarg1, OdPdfPublish_OdAnnotationBorderEffect.SwigDelegateOdPdfPublish_OdAnnotationBorderEffect_0 delegate0, OdPdfPublish_OdAnnotationBorderEffect.SwigDelegateOdPdfPublish_OdAnnotationBorderEffect_1 delegate1, OdPdfPublish_OdAnnotationBorderEffect.SwigDelegateOdPdfPublish_OdAnnotationBorderEffect_2 delegate2, OdPdfPublish_OdAnnotationBorderEffect.SwigDelegateOdPdfPublish_OdAnnotationBorderEffect_3 delegate3, OdPdfPublish_OdAnnotationBorderEffect.SwigDelegateOdPdfPublish_OdAnnotationBorderEffect_4 delegate4, OdPdfPublish_OdAnnotationBorderEffect.SwigDelegateOdPdfPublish_OdAnnotationBorderEffect_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdAnnotationBorderStyle___")]
	public static extern IntPtr new_OdPdfPublish_OdAnnotationBorderStyle();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_cast___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderStyle_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_desc___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderStyle_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_isA___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderStyle_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_isASwigExplicitOdPdfPublish_OdAnnotationBorderStyle___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderStyle_isASwigExplicitOdPdfPublish_OdAnnotationBorderStyle(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_queryX___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderStyle_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_queryXSwigExplicitOdPdfPublish_OdAnnotationBorderStyle___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderStyle_queryXSwigExplicitOdPdfPublish_OdAnnotationBorderStyle(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_createObject___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderStyle_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdAnnotationBorderStyle___")]
	public static extern void delete_OdPdfPublish_OdAnnotationBorderStyle(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_setWidth___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStyle_setWidth(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_setStyle___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStyle_setStyle(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_setDashPattern___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStyle_setDashPattern(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_getWidth___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStyle_getWidth(HandleRef jarg1, out double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_getStyle___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStyle_getStyle(HandleRef jarg1, out OdPdfPublish_Border_Style jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_getDashPattern___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStyle_getDashPattern(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_getRealClassName___")]
	public static extern string OdPdfPublish_OdAnnotationBorderStyle_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_director_connect___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStyle_director_connect(HandleRef jarg1, OdPdfPublish_OdAnnotationBorderStyle.SwigDelegateOdPdfPublish_OdAnnotationBorderStyle_0 delegate0, OdPdfPublish_OdAnnotationBorderStyle.SwigDelegateOdPdfPublish_OdAnnotationBorderStyle_1 delegate1, OdPdfPublish_OdAnnotationBorderStyle.SwigDelegateOdPdfPublish_OdAnnotationBorderStyle_2 delegate2, OdPdfPublish_OdAnnotationBorderStyle.SwigDelegateOdPdfPublish_OdAnnotationBorderStyle_3 delegate3, OdPdfPublish_OdAnnotationBorderStyle.SwigDelegateOdPdfPublish_OdAnnotationBorderStyle_4 delegate4, OdPdfPublish_OdAnnotationBorderStyle.SwigDelegateOdPdfPublish_OdAnnotationBorderStyle_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_cast___")]
	public static extern IntPtr OdPdfPublish_OdCADDefinition_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_desc___")]
	public static extern IntPtr OdPdfPublish_OdCADDefinition_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_isA___")]
	public static extern IntPtr OdPdfPublish_OdCADDefinition_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_queryX___")]
	public static extern IntPtr OdPdfPublish_OdCADDefinition_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_createObject___")]
	public static extern IntPtr OdPdfPublish_OdCADDefinition_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCADDefinition___")]
	public static extern void delete_OdPdfPublish_OdCADDefinition(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setDatabase___")]
	public static extern void OdPdfPublish_OdCADDefinition_setDatabase(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setDatabaseWrapper___")]
	public static extern void OdPdfPublish_OdCADDefinition_setDatabaseWrapper(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setLayoutName___")]
	public static extern void OdPdfPublish_OdCADDefinition_setLayoutName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setMediaSize___")]
	public static extern void OdPdfPublish_OdCADDefinition_setMediaSize(HandleRef jarg1, int jarg2, double jarg3, double jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setEmbededTrueTypeFonts___")]
	public static extern void OdPdfPublish_OdCADDefinition_setEmbededTrueTypeFonts(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setTrueTypeFontAsGeometry___")]
	public static extern void OdPdfPublish_OdCADDefinition_setTrueTypeFontAsGeometry(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setSHXTextAsGeometry___")]
	public static extern void OdPdfPublish_OdCADDefinition_setSHXTextAsGeometry(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setTextSearchable___")]
	public static extern void OdPdfPublish_OdCADDefinition_setTextSearchable(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setSearchableTextAsHiddenText___")]
	public static extern void OdPdfPublish_OdCADDefinition_setSearchableTextAsHiddenText(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setSearchableTextInRenderedViews___")]
	public static extern void OdPdfPublish_OdCADDefinition_setSearchableTextInRenderedViews(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setExportHyperlinks___")]
	public static extern void OdPdfPublish_OdCADDefinition_setExportHyperlinks(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setGeomDPI___")]
	public static extern void OdPdfPublish_OdCADDefinition_setGeomDPI(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setBWImagesDPI___")]
	public static extern void OdPdfPublish_OdCADDefinition_setBWImagesDPI(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setColorImagesDPI___")]
	public static extern void OdPdfPublish_OdCADDefinition_setColorImagesDPI(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setMeasuring___")]
	public static extern void OdPdfPublish_OdCADDefinition_setMeasuring(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setColorPolicy___")]
	public static extern void OdPdfPublish_OdCADDefinition_setColorPolicy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setUseSimpleGeomOptimization___")]
	public static extern void OdPdfPublish_OdCADDefinition_setUseSimpleGeomOptimization(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setUseHLR___")]
	public static extern void OdPdfPublish_OdCADDefinition_setUseHLR(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setUseFlateCompression___")]
	public static extern void OdPdfPublish_OdCADDefinition_setUseFlateCompression(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setUseDctCompression___")]
	public static extern void OdPdfPublish_OdCADDefinition_setUseDctCompression(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setDctCompressionQuality___")]
	public static extern void OdPdfPublish_OdCADDefinition_setDctCompressionQuality(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setUseASCIIHexEncoding___")]
	public static extern void OdPdfPublish_OdCADDefinition_setUseASCIIHexEncoding(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setUseGsCache___")]
	public static extern void OdPdfPublish_OdCADDefinition_setUseGsCache(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setUseParallelVectorization___")]
	public static extern void OdPdfPublish_OdCADDefinition_setUseParallelVectorization(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setEnableLayers___")]
	public static extern void OdPdfPublish_OdCADDefinition_setEnableLayers(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setIncludeOffLayers___")]
	public static extern void OdPdfPublish_OdCADDefinition_setIncludeOffLayers(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_setSelectionSet___")]
	public static extern void OdPdfPublish_OdCADDefinition_setSelectionSet(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getDatabase___")]
	public static extern IntPtr OdPdfPublish_OdCADDefinition_getDatabase(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getDatabaseWrapper___")]
	public static extern IntPtr OdPdfPublish_OdCADDefinition_getDatabaseWrapper(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getLayoutName___")]
	public static extern void OdPdfPublish_OdCADDefinition_getLayoutName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getMediaSize___")]
	public static extern void OdPdfPublish_OdCADDefinition_getMediaSize(HandleRef jarg1, out OdPdfPublish_Page_PaperUnits jarg2, out double jarg3, out double jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getEmbededTrueTypeFonts___")]
	public static extern void OdPdfPublish_OdCADDefinition_getEmbededTrueTypeFonts(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getTrueTypeFontAsGeometry___")]
	public static extern void OdPdfPublish_OdCADDefinition_getTrueTypeFontAsGeometry(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getSHXTextAsGeometry___")]
	public static extern void OdPdfPublish_OdCADDefinition_getSHXTextAsGeometry(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getTextSearchable___")]
	public static extern void OdPdfPublish_OdCADDefinition_getTextSearchable(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getSearchableTextAsHiddenText___")]
	public static extern void OdPdfPublish_OdCADDefinition_getSearchableTextAsHiddenText(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getSearchableTextInRenderedViews___")]
	public static extern void OdPdfPublish_OdCADDefinition_getSearchableTextInRenderedViews(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getExportHyperlinks___")]
	public static extern void OdPdfPublish_OdCADDefinition_getExportHyperlinks(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getGeomDPI___")]
	public static extern void OdPdfPublish_OdCADDefinition_getGeomDPI(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getBWImagesDPI___")]
	public static extern void OdPdfPublish_OdCADDefinition_getBWImagesDPI(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getColorImagesDPI___")]
	public static extern void OdPdfPublish_OdCADDefinition_getColorImagesDPI(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getMeasuring___")]
	public static extern void OdPdfPublish_OdCADDefinition_getMeasuring(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getColorPolicy___")]
	public static extern void OdPdfPublish_OdCADDefinition_getColorPolicy(HandleRef jarg1, out OdPdfPublish_CAD_ColorPolicy jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getUseSimpleGeomOptimization___")]
	public static extern void OdPdfPublish_OdCADDefinition_getUseSimpleGeomOptimization(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getUseHLR___")]
	public static extern void OdPdfPublish_OdCADDefinition_getUseHLR(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getUseFlateCompression___")]
	public static extern void OdPdfPublish_OdCADDefinition_getUseFlateCompression(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getUseDctCompression___")]
	public static extern void OdPdfPublish_OdCADDefinition_getUseDctCompression(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getDctCompressionQuality___")]
	public static extern void OdPdfPublish_OdCADDefinition_getDctCompressionQuality(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getUseASCIIHexEncoding___")]
	public static extern void OdPdfPublish_OdCADDefinition_getUseASCIIHexEncoding(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getUseGsCache___")]
	public static extern void OdPdfPublish_OdCADDefinition_getUseGsCache(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getUseParallelVectorization___")]
	public static extern void OdPdfPublish_OdCADDefinition_getUseParallelVectorization(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getEnableLayers___")]
	public static extern void OdPdfPublish_OdCADDefinition_getEnableLayers(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getIncludeOffLayers___")]
	public static extern void OdPdfPublish_OdCADDefinition_getIncludeOffLayers(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getSelectionSet___")]
	public static extern void OdPdfPublish_OdCADDefinition_getSelectionSet(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_getRealClassName___")]
	public static extern string OdPdfPublish_OdCADDefinition_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_Od2dGeometryBlock___")]
	public static extern IntPtr new_OdPdfPublish_Od2dGeometryBlock();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_cast___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryBlock_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_desc___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryBlock_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_isA___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryBlock_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_isASwigExplicitOdPdfPublish_Od2dGeometryBlock___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryBlock_isASwigExplicitOdPdfPublish_Od2dGeometryBlock(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_queryX___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryBlock_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_queryXSwigExplicitOdPdfPublish_Od2dGeometryBlock___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryBlock_queryXSwigExplicitOdPdfPublish_Od2dGeometryBlock(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_createObject___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryBlock_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_Od2dGeometryBlock___")]
	public static extern void delete_OdPdfPublish_Od2dGeometryBlock(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_setOrigin___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_setOrigin(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_addLine__SWIG_0___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_addLine__SWIG_0(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_addLine__SWIG_1___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_addLine__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_addLine__SWIG_2___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_addLine__SWIG_2(HandleRef jarg1, uint jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_addCircle___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_addCircle(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_addEllipse___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_addEllipse(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_addCurve___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_addCurve(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_putColor___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_putColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_putTilingPattern___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_putTilingPattern(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_putLineWeight___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_putLineWeight(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_putLineCap___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_putLineCap(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_putLineJoin___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_putLineJoin(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_putTransform___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_putTransform(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_startContour___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_startContour(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_finishContour___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_finishContour(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_addText___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_addText(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_addImage___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_addImage(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_addGeometryReference___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_addGeometryReference(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_startLayer___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_startLayer(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_finishLayer___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_finishLayer(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_getRealClassName___")]
	public static extern string OdPdfPublish_Od2dGeometryBlock_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_director_connect___")]
	public static extern void OdPdfPublish_Od2dGeometryBlock_director_connect(HandleRef jarg1, OdPdfPublish_Od2dGeometryBlock.SwigDelegateOdPdfPublish_Od2dGeometryBlock_0 delegate0, OdPdfPublish_Od2dGeometryBlock.SwigDelegateOdPdfPublish_Od2dGeometryBlock_1 delegate1, OdPdfPublish_Od2dGeometryBlock.SwigDelegateOdPdfPublish_Od2dGeometryBlock_2 delegate2, OdPdfPublish_Od2dGeometryBlock.SwigDelegateOdPdfPublish_Od2dGeometryBlock_3 delegate3, OdPdfPublish_Od2dGeometryBlock.SwigDelegateOdPdfPublish_Od2dGeometryBlock_4 delegate4, OdPdfPublish_Od2dGeometryBlock.SwigDelegateOdPdfPublish_Od2dGeometryBlock_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdTable___")]
	public static extern IntPtr new_OdPdfPublish_OdTable();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_cast___")]
	public static extern IntPtr OdPdfPublish_OdTable_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_desc___")]
	public static extern IntPtr OdPdfPublish_OdTable_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_isA___")]
	public static extern IntPtr OdPdfPublish_OdTable_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_isASwigExplicitOdPdfPublish_OdTable___")]
	public static extern IntPtr OdPdfPublish_OdTable_isASwigExplicitOdPdfPublish_OdTable(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_queryX___")]
	public static extern IntPtr OdPdfPublish_OdTable_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_queryXSwigExplicitOdPdfPublish_OdTable___")]
	public static extern IntPtr OdPdfPublish_OdTable_queryXSwigExplicitOdPdfPublish_OdTable(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_createObject___")]
	public static extern IntPtr OdPdfPublish_OdTable_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdTable___")]
	public static extern void delete_OdPdfPublish_OdTable(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_setLink___")]
	public static extern void OdPdfPublish_OdTable_setLink(HandleRef jarg1, uint jarg2, uint jarg3, HandleRef jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_setText__SWIG_0___")]
	public static extern void OdPdfPublish_OdTable_setText__SWIG_0(HandleRef jarg1, uint jarg2, uint jarg3, HandleRef jarg4, double jarg5, int jarg6);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_setText__SWIG_1___")]
	public static extern void OdPdfPublish_OdTable_setText__SWIG_1(HandleRef jarg1, uint jarg2, uint jarg3, HandleRef jarg4, double jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_setText__SWIG_2___")]
	public static extern void OdPdfPublish_OdTable_setText__SWIG_2(HandleRef jarg1, uint jarg2, uint jarg3, HandleRef jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_setTextMargins___")]
	public static extern void OdPdfPublish_OdTable_setTextMargins(HandleRef jarg1, uint jarg2, uint jarg3, uint jarg4, uint jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_setButton___")]
	public static extern void OdPdfPublish_OdTable_setButton(HandleRef jarg1, uint jarg2, uint jarg3, HandleRef jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_setTextField___")]
	public static extern void OdPdfPublish_OdTable_setTextField(HandleRef jarg1, uint jarg2, uint jarg3, HandleRef jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_getLink___")]
	public static extern void OdPdfPublish_OdTable_getLink(HandleRef jarg1, uint jarg2, uint jarg3, ref IntPtr jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_getText___")]
	public static extern void OdPdfPublish_OdTable_getText(HandleRef jarg1, uint jarg2, uint jarg3, ref IntPtr jarg4, out double jarg5, out OdPdfPublish_Table_TextAlignment jarg6);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_getTextMargins___")]
	public static extern void OdPdfPublish_OdTable_getTextMargins(HandleRef jarg1, out uint jarg2, out uint jarg3, out uint jarg4, out uint jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_getButton___")]
	public static extern void OdPdfPublish_OdTable_getButton(HandleRef jarg1, uint jarg2, uint jarg3, ref IntPtr jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_getTextField___")]
	public static extern void OdPdfPublish_OdTable_getTextField(HandleRef jarg1, uint jarg2, uint jarg3, ref IntPtr jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_getRealClassName___")]
	public static extern string OdPdfPublish_OdTable_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_director_connect___")]
	public static extern void OdPdfPublish_OdTable_director_connect(HandleRef jarg1, OdPdfPublish_OdTable.SwigDelegateOdPdfPublish_OdTable_0 delegate0, OdPdfPublish_OdTable.SwigDelegateOdPdfPublish_OdTable_1 delegate1, OdPdfPublish_OdTable.SwigDelegateOdPdfPublish_OdTable_2 delegate2, OdPdfPublish_OdTable.SwigDelegateOdPdfPublish_OdTable_3 delegate3, OdPdfPublish_OdTable.SwigDelegateOdPdfPublish_OdTable_4 delegate4, OdPdfPublish_OdTable.SwigDelegateOdPdfPublish_OdTable_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdListBox___")]
	public static extern IntPtr new_OdPdfPublish_OdListBox();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_cast___")]
	public static extern IntPtr OdPdfPublish_OdListBox_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_desc___")]
	public static extern IntPtr OdPdfPublish_OdListBox_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_isA___")]
	public static extern IntPtr OdPdfPublish_OdListBox_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_isASwigExplicitOdPdfPublish_OdListBox___")]
	public static extern IntPtr OdPdfPublish_OdListBox_isASwigExplicitOdPdfPublish_OdListBox(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_queryX___")]
	public static extern IntPtr OdPdfPublish_OdListBox_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_queryXSwigExplicitOdPdfPublish_OdListBox___")]
	public static extern IntPtr OdPdfPublish_OdListBox_queryXSwigExplicitOdPdfPublish_OdListBox(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_createObject___")]
	public static extern IntPtr OdPdfPublish_OdListBox_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdListBox___")]
	public static extern void delete_OdPdfPublish_OdListBox(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setName___")]
	public static extern void OdPdfPublish_OdListBox_setName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setFont__SWIG_0___")]
	public static extern void OdPdfPublish_OdListBox_setFont__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4, bool jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setFont__SWIG_1___")]
	public static extern void OdPdfPublish_OdListBox_setFont__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setFont__SWIG_2___")]
	public static extern void OdPdfPublish_OdListBox_setFont__SWIG_2(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setFont__SWIG_3___")]
	public static extern void OdPdfPublish_OdListBox_setFont__SWIG_3(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setFont__SWIG_4___")]
	public static extern void OdPdfPublish_OdListBox_setFont__SWIG_4(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setFontSize___")]
	public static extern void OdPdfPublish_OdListBox_setFontSize(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setTextColor___")]
	public static extern void OdPdfPublish_OdListBox_setTextColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setTooltip___")]
	public static extern void OdPdfPublish_OdListBox_setTooltip(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setVisibility___")]
	public static extern void OdPdfPublish_OdListBox_setVisibility(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setPrintability___")]
	public static extern void OdPdfPublish_OdListBox_setPrintability(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setTextRotation___")]
	public static extern void OdPdfPublish_OdListBox_setTextRotation(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setLock___")]
	public static extern void OdPdfPublish_OdListBox_setLock(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setBorder___")]
	public static extern void OdPdfPublish_OdListBox_setBorder(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setBorderColor___")]
	public static extern void OdPdfPublish_OdListBox_setBorderColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setBorderThickness___")]
	public static extern void OdPdfPublish_OdListBox_setBorderThickness(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setBorderStyle___")]
	public static extern void OdPdfPublish_OdListBox_setBorderStyle(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setFillColor___")]
	public static extern void OdPdfPublish_OdListBox_setFillColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setMultipleSelection___")]
	public static extern void OdPdfPublish_OdListBox_setMultipleSelection(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_setContents___")]
	public static extern void OdPdfPublish_OdListBox_setContents(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getName___")]
	public static extern void OdPdfPublish_OdListBox_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getFont___")]
	public static extern void OdPdfPublish_OdListBox_getFont(HandleRef jarg1, out OdPdfPublish_Text_StorageType jarg2, out OdPdfPublish_Text_StandardFontsType jarg3, ref IntPtr jarg4, out OdPdfPublish_Text_FontStyle jarg5, out OdPdfPublish_Text_Language jarg6, out bool jarg7);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getFontSize___")]
	public static extern void OdPdfPublish_OdListBox_getFontSize(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getTextColor___")]
	public static extern void OdPdfPublish_OdListBox_getTextColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getTooltip___")]
	public static extern void OdPdfPublish_OdListBox_getTooltip(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getVisibility___")]
	public static extern void OdPdfPublish_OdListBox_getVisibility(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getPrintability___")]
	public static extern void OdPdfPublish_OdListBox_getPrintability(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getTextRotation___")]
	public static extern void OdPdfPublish_OdListBox_getTextRotation(HandleRef jarg1, out OdPdfPublish_Text_Rotation jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getLock___")]
	public static extern void OdPdfPublish_OdListBox_getLock(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getBorder___")]
	public static extern void OdPdfPublish_OdListBox_getBorder(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getBorderColor___")]
	public static extern void OdPdfPublish_OdListBox_getBorderColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getBorderThickness___")]
	public static extern void OdPdfPublish_OdListBox_getBorderThickness(HandleRef jarg1, out OdPdfPublish_Border_Thickness jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getBorderStyle___")]
	public static extern void OdPdfPublish_OdListBox_getBorderStyle(HandleRef jarg1, out OdPdfPublish_Border_Style jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getFillColor___")]
	public static extern void OdPdfPublish_OdListBox_getFillColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getMultipleSelection___")]
	public static extern void OdPdfPublish_OdListBox_getMultipleSelection(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getContents___")]
	public static extern void OdPdfPublish_OdListBox_getContents(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_getRealClassName___")]
	public static extern string OdPdfPublish_OdListBox_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_director_connect___")]
	public static extern void OdPdfPublish_OdListBox_director_connect(HandleRef jarg1, OdPdfPublish_OdListBox.SwigDelegateOdPdfPublish_OdListBox_0 delegate0, OdPdfPublish_OdListBox.SwigDelegateOdPdfPublish_OdListBox_1 delegate1, OdPdfPublish_OdListBox.SwigDelegateOdPdfPublish_OdListBox_2 delegate2, OdPdfPublish_OdListBox.SwigDelegateOdPdfPublish_OdListBox_3 delegate3, OdPdfPublish_OdListBox.SwigDelegateOdPdfPublish_OdListBox_4 delegate4, OdPdfPublish_OdListBox.SwigDelegateOdPdfPublish_OdListBox_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdCADModel___")]
	public static extern IntPtr new_OdPdfPublish_OdCADModel();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_cast___")]
	public static extern IntPtr OdPdfPublish_OdCADModel_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_desc___")]
	public static extern IntPtr OdPdfPublish_OdCADModel_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_isA___")]
	public static extern IntPtr OdPdfPublish_OdCADModel_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_isASwigExplicitOdPdfPublish_OdCADModel___")]
	public static extern IntPtr OdPdfPublish_OdCADModel_isASwigExplicitOdPdfPublish_OdCADModel(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_queryX___")]
	public static extern IntPtr OdPdfPublish_OdCADModel_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_queryXSwigExplicitOdPdfPublish_OdCADModel___")]
	public static extern IntPtr OdPdfPublish_OdCADModel_queryXSwigExplicitOdPdfPublish_OdCADModel(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_createObject___")]
	public static extern IntPtr OdPdfPublish_OdCADModel_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCADModel___")]
	public static extern void delete_OdPdfPublish_OdCADModel(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_setSource__SWIG_0___")]
	public static extern void OdPdfPublish_OdCADModel_setSource__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_setSource__SWIG_1___")]
	public static extern void OdPdfPublish_OdCADModel_setSource__SWIG_1(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_getSource__SWIG_0___")]
	public static extern void OdPdfPublish_OdCADModel_getSource__SWIG_0(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_getSourceName___")]
	public static extern void OdPdfPublish_OdCADModel_getSourceName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_getSource__SWIG_1___")]
	public static extern void OdPdfPublish_OdCADModel_getSource__SWIG_1(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_getRealClassName___")]
	public static extern string OdPdfPublish_OdCADModel_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_director_connect___")]
	public static extern void OdPdfPublish_OdCADModel_director_connect(HandleRef jarg1, OdPdfPublish_OdCADModel.SwigDelegateOdPdfPublish_OdCADModel_0 delegate0, OdPdfPublish_OdCADModel.SwigDelegateOdPdfPublish_OdCADModel_1 delegate1, OdPdfPublish_OdCADModel.SwigDelegateOdPdfPublish_OdCADModel_2 delegate2, OdPdfPublish_OdCADModel.SwigDelegateOdPdfPublish_OdCADModel_3 delegate3, OdPdfPublish_OdCADModel.SwigDelegateOdPdfPublish_OdCADModel_4 delegate4, OdPdfPublish_OdCADModel.SwigDelegateOdPdfPublish_OdCADModel_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdArtwork___")]
	public static extern IntPtr new_OdPdfPublish_OdArtwork();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_cast___")]
	public static extern IntPtr OdPdfPublish_OdArtwork_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_desc___")]
	public static extern IntPtr OdPdfPublish_OdArtwork_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_isA___")]
	public static extern IntPtr OdPdfPublish_OdArtwork_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_isASwigExplicitOdPdfPublish_OdArtwork___")]
	public static extern IntPtr OdPdfPublish_OdArtwork_isASwigExplicitOdPdfPublish_OdArtwork(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_queryX___")]
	public static extern IntPtr OdPdfPublish_OdArtwork_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_queryXSwigExplicitOdPdfPublish_OdArtwork___")]
	public static extern IntPtr OdPdfPublish_OdArtwork_queryXSwigExplicitOdPdfPublish_OdArtwork(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_createObject___")]
	public static extern IntPtr OdPdfPublish_OdArtwork_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdArtwork___")]
	public static extern void delete_OdPdfPublish_OdArtwork(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_setAnimationStyle___")]
	public static extern void OdPdfPublish_OdArtwork_setAnimationStyle(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_setJavaScript__SWIG_0___")]
	public static extern void OdPdfPublish_OdArtwork_setJavaScript__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_setJavaScript__SWIG_1___")]
	public static extern void OdPdfPublish_OdArtwork_setJavaScript__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_setPMICrossHighlighting___")]
	public static extern void OdPdfPublish_OdArtwork_setPMICrossHighlighting(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_setPMISemanticInformation___")]
	public static extern void OdPdfPublish_OdArtwork_setPMISemanticInformation(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_setDefaultViewPreference___")]
	public static extern void OdPdfPublish_OdArtwork_setDefaultViewPreference(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_setDisplayPreference___")]
	public static extern void OdPdfPublish_OdArtwork_setDisplayPreference(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_addView___")]
	public static extern void OdPdfPublish_OdArtwork_addView(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_setPMIColor___")]
	public static extern void OdPdfPublish_OdArtwork_setPMIColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_addAnimation___")]
	public static extern void OdPdfPublish_OdArtwork_addAnimation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_getAnimationStyle___")]
	public static extern void OdPdfPublish_OdArtwork_getAnimationStyle(HandleRef jarg1, out OdPdfPublish_Artwork_AnimationStyle jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_getJavaScript___")]
	public static extern void OdPdfPublish_OdArtwork_getJavaScript(HandleRef jarg1, ref IntPtr jarg2, out OdPdfPublish_Source_Type jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_getPMICrossHighlighting___")]
	public static extern void OdPdfPublish_OdArtwork_getPMICrossHighlighting(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_getPMISemanticInformation___")]
	public static extern void OdPdfPublish_OdArtwork_getPMISemanticInformation(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_getDefaultViewPreference___")]
	public static extern void OdPdfPublish_OdArtwork_getDefaultViewPreference(HandleRef jarg1, out OdPdfPublish_Artwork_ViewPreference jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_getDisplayPreference___")]
	public static extern void OdPdfPublish_OdArtwork_getDisplayPreference(HandleRef jarg1, out OdPdfPublish_Artwork_DisplayPreference jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_getViews___")]
	public static extern void OdPdfPublish_OdArtwork_getViews(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_getPMIColor___")]
	public static extern void OdPdfPublish_OdArtwork_getPMIColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_getAnimations___")]
	public static extern void OdPdfPublish_OdArtwork_getAnimations(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_getRealClassName___")]
	public static extern string OdPdfPublish_OdArtwork_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_director_connect___")]
	public static extern void OdPdfPublish_OdArtwork_director_connect(HandleRef jarg1, OdPdfPublish_OdArtwork.SwigDelegateOdPdfPublish_OdArtwork_0 delegate0, OdPdfPublish_OdArtwork.SwigDelegateOdPdfPublish_OdArtwork_1 delegate1, OdPdfPublish_OdArtwork.SwigDelegateOdPdfPublish_OdArtwork_2 delegate2, OdPdfPublish_OdArtwork.SwigDelegateOdPdfPublish_OdArtwork_3 delegate3, OdPdfPublish_OdArtwork.SwigDelegateOdPdfPublish_OdArtwork_4 delegate4, OdPdfPublish_OdArtwork.SwigDelegateOdPdfPublish_OdArtwork_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdAttachedFolder___")]
	public static extern IntPtr new_OdPdfPublish_OdAttachedFolder();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_cast___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFolder_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_desc___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFolder_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_isA___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFolder_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_isASwigExplicitOdPdfPublish_OdAttachedFolder___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFolder_isASwigExplicitOdPdfPublish_OdAttachedFolder(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_queryX___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFolder_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_queryXSwigExplicitOdPdfPublish_OdAttachedFolder___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFolder_queryXSwigExplicitOdPdfPublish_OdAttachedFolder(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_createObject___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFolder_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdAttachedFolder___")]
	public static extern void delete_OdPdfPublish_OdAttachedFolder(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_setName___")]
	public static extern void OdPdfPublish_OdAttachedFolder_setName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_setDescription___")]
	public static extern void OdPdfPublish_OdAttachedFolder_setDescription(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_setCreationDate___")]
	public static extern void OdPdfPublish_OdAttachedFolder_setCreationDate(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_setModDate___")]
	public static extern void OdPdfPublish_OdAttachedFolder_setModDate(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_setThumb___")]
	public static extern void OdPdfPublish_OdAttachedFolder_setThumb(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_addTextCollectionItem___")]
	public static extern void OdPdfPublish_OdAttachedFolder_addTextCollectionItem(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_addDateCollectionItem___")]
	public static extern void OdPdfPublish_OdAttachedFolder_addDateCollectionItem(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_addNumberCollectionItem___")]
	public static extern void OdPdfPublish_OdAttachedFolder_addNumberCollectionItem(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, double jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_addChildFolder___")]
	public static extern void OdPdfPublish_OdAttachedFolder_addChildFolder(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_addFile___")]
	public static extern void OdPdfPublish_OdAttachedFolder_addFile(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_getName___")]
	public static extern void OdPdfPublish_OdAttachedFolder_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_getDescription___")]
	public static extern void OdPdfPublish_OdAttachedFolder_getDescription(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_getCreationDate___")]
	public static extern void OdPdfPublish_OdAttachedFolder_getCreationDate(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_getModDate___")]
	public static extern void OdPdfPublish_OdAttachedFolder_getModDate(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_getThumb___")]
	public static extern void OdPdfPublish_OdAttachedFolder_getThumb(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_getTextCollectionItems___")]
	public static extern void OdPdfPublish_OdAttachedFolder_getTextCollectionItems(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_getDateCollectionItems___")]
	public static extern void OdPdfPublish_OdAttachedFolder_getDateCollectionItems(HandleRef jarg1, IntPtr jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_getNumberCollectionItems___")]
	public static extern void OdPdfPublish_OdAttachedFolder_getNumberCollectionItems(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_getChildFolders___")]
	public static extern void OdPdfPublish_OdAttachedFolder_getChildFolders(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_getFiles___")]
	public static extern void OdPdfPublish_OdAttachedFolder_getFiles(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_getRealClassName___")]
	public static extern string OdPdfPublish_OdAttachedFolder_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_director_connect___")]
	public static extern void OdPdfPublish_OdAttachedFolder_director_connect(HandleRef jarg1, OdPdfPublish_OdAttachedFolder.SwigDelegateOdPdfPublish_OdAttachedFolder_0 delegate0, OdPdfPublish_OdAttachedFolder.SwigDelegateOdPdfPublish_OdAttachedFolder_1 delegate1, OdPdfPublish_OdAttachedFolder.SwigDelegateOdPdfPublish_OdAttachedFolder_2 delegate2, OdPdfPublish_OdAttachedFolder.SwigDelegateOdPdfPublish_OdAttachedFolder_3 delegate3, OdPdfPublish_OdAttachedFolder.SwigDelegateOdPdfPublish_OdAttachedFolder_4 delegate4, OdPdfPublish_OdAttachedFolder.SwigDelegateOdPdfPublish_OdAttachedFolder_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdAttachedFile___")]
	public static extern IntPtr new_OdPdfPublish_OdAttachedFile();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_cast___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFile_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_desc___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFile_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_isA___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFile_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_isASwigExplicitOdPdfPublish_OdAttachedFile___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFile_isASwigExplicitOdPdfPublish_OdAttachedFile(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_queryX___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFile_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_queryXSwigExplicitOdPdfPublish_OdAttachedFile___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFile_queryXSwigExplicitOdPdfPublish_OdAttachedFile(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_createObject___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFile_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdAttachedFile___")]
	public static extern void delete_OdPdfPublish_OdAttachedFile(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_setName___")]
	public static extern void OdPdfPublish_OdAttachedFile_setName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_setDescription___")]
	public static extern void OdPdfPublish_OdAttachedFile_setDescription(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_setCreationDate___")]
	public static extern void OdPdfPublish_OdAttachedFile_setCreationDate(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_setModDate___")]
	public static extern void OdPdfPublish_OdAttachedFile_setModDate(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_setThumb___")]
	public static extern void OdPdfPublish_OdAttachedFile_setThumb(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_addTextCollectionItem___")]
	public static extern void OdPdfPublish_OdAttachedFile_addTextCollectionItem(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_addDateCollectionItem___")]
	public static extern void OdPdfPublish_OdAttachedFile_addDateCollectionItem(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_addNumberCollectionItem___")]
	public static extern void OdPdfPublish_OdAttachedFile_addNumberCollectionItem(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, double jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_setFile___")]
	public static extern void OdPdfPublish_OdAttachedFile_setFile(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_setFileStream___")]
	public static extern void OdPdfPublish_OdAttachedFile_setFileStream(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_getName___")]
	public static extern void OdPdfPublish_OdAttachedFile_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_getDescription___")]
	public static extern void OdPdfPublish_OdAttachedFile_getDescription(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_getCreationDate___")]
	public static extern void OdPdfPublish_OdAttachedFile_getCreationDate(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_getModDate___")]
	public static extern void OdPdfPublish_OdAttachedFile_getModDate(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_getThumb___")]
	public static extern void OdPdfPublish_OdAttachedFile_getThumb(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_getTextCollectionItems___")]
	public static extern void OdPdfPublish_OdAttachedFile_getTextCollectionItems(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_getDateCollectionItems___")]
	public static extern void OdPdfPublish_OdAttachedFile_getDateCollectionItems(HandleRef jarg1, IntPtr jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_getNumberCollectionItems___")]
	public static extern void OdPdfPublish_OdAttachedFile_getNumberCollectionItems(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_getFile___")]
	public static extern void OdPdfPublish_OdAttachedFile_getFile(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_getFileStream___")]
	public static extern void OdPdfPublish_OdAttachedFile_getFileStream(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_getRealClassName___")]
	public static extern string OdPdfPublish_OdAttachedFile_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_director_connect___")]
	public static extern void OdPdfPublish_OdAttachedFile_director_connect(HandleRef jarg1, OdPdfPublish_OdAttachedFile.SwigDelegateOdPdfPublish_OdAttachedFile_0 delegate0, OdPdfPublish_OdAttachedFile.SwigDelegateOdPdfPublish_OdAttachedFile_1 delegate1, OdPdfPublish_OdAttachedFile.SwigDelegateOdPdfPublish_OdAttachedFile_2 delegate2, OdPdfPublish_OdAttachedFile.SwigDelegateOdPdfPublish_OdAttachedFile_3 delegate3, OdPdfPublish_OdAttachedFile.SwigDelegateOdPdfPublish_OdAttachedFile_4 delegate4, OdPdfPublish_OdAttachedFile.SwigDelegateOdPdfPublish_OdAttachedFile_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdPolygonAnnotation___")]
	public static extern IntPtr new_OdPdfPublish_OdPolygonAnnotation();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_cast___")]
	public static extern IntPtr OdPdfPublish_OdPolygonAnnotation_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_desc___")]
	public static extern IntPtr OdPdfPublish_OdPolygonAnnotation_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_isA___")]
	public static extern IntPtr OdPdfPublish_OdPolygonAnnotation_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_isASwigExplicitOdPdfPublish_OdPolygonAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdPolygonAnnotation_isASwigExplicitOdPdfPublish_OdPolygonAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_queryX___")]
	public static extern IntPtr OdPdfPublish_OdPolygonAnnotation_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_queryXSwigExplicitOdPdfPublish_OdPolygonAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdPolygonAnnotation_queryXSwigExplicitOdPdfPublish_OdPolygonAnnotation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_createObject___")]
	public static extern IntPtr OdPdfPublish_OdPolygonAnnotation_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdPolygonAnnotation___")]
	public static extern void delete_OdPdfPublish_OdPolygonAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_setVertices___")]
	public static extern void OdPdfPublish_OdPolygonAnnotation_setVertices(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_setLineStyle___")]
	public static extern void OdPdfPublish_OdPolygonAnnotation_setLineStyle(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_setLineEffect___")]
	public static extern void OdPdfPublish_OdPolygonAnnotation_setLineEffect(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_getVertices___")]
	public static extern void OdPdfPublish_OdPolygonAnnotation_getVertices(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_getLineStyle___")]
	public static extern void OdPdfPublish_OdPolygonAnnotation_getLineStyle(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_getLineEffect___")]
	public static extern void OdPdfPublish_OdPolygonAnnotation_getLineEffect(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_getRealClassName___")]
	public static extern string OdPdfPublish_OdPolygonAnnotation_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_director_connect___")]
	public static extern void OdPdfPublish_OdPolygonAnnotation_director_connect(HandleRef jarg1, OdPdfPublish_OdPolygonAnnotation.SwigDelegateOdPdfPublish_OdPolygonAnnotation_0 delegate0, OdPdfPublish_OdPolygonAnnotation.SwigDelegateOdPdfPublish_OdPolygonAnnotation_1 delegate1, OdPdfPublish_OdPolygonAnnotation.SwigDelegateOdPdfPublish_OdPolygonAnnotation_2 delegate2, OdPdfPublish_OdPolygonAnnotation.SwigDelegateOdPdfPublish_OdPolygonAnnotation_3 delegate3, OdPdfPublish_OdPolygonAnnotation.SwigDelegateOdPdfPublish_OdPolygonAnnotation_4 delegate4, OdPdfPublish_OdPolygonAnnotation.SwigDelegateOdPdfPublish_OdPolygonAnnotation_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdPolylineAnnotation___")]
	public static extern IntPtr new_OdPdfPublish_OdPolylineAnnotation();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_cast___")]
	public static extern IntPtr OdPdfPublish_OdPolylineAnnotation_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_desc___")]
	public static extern IntPtr OdPdfPublish_OdPolylineAnnotation_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_isA___")]
	public static extern IntPtr OdPdfPublish_OdPolylineAnnotation_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_isASwigExplicitOdPdfPublish_OdPolylineAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdPolylineAnnotation_isASwigExplicitOdPdfPublish_OdPolylineAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_queryX___")]
	public static extern IntPtr OdPdfPublish_OdPolylineAnnotation_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_queryXSwigExplicitOdPdfPublish_OdPolylineAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdPolylineAnnotation_queryXSwigExplicitOdPdfPublish_OdPolylineAnnotation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_createObject___")]
	public static extern IntPtr OdPdfPublish_OdPolylineAnnotation_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdPolylineAnnotation___")]
	public static extern void delete_OdPdfPublish_OdPolylineAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_setVertices___")]
	public static extern void OdPdfPublish_OdPolylineAnnotation_setVertices(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_setLineStyle___")]
	public static extern void OdPdfPublish_OdPolylineAnnotation_setLineStyle(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_setEndings___")]
	public static extern void OdPdfPublish_OdPolylineAnnotation_setEndings(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_getVertices___")]
	public static extern void OdPdfPublish_OdPolylineAnnotation_getVertices(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_getLineStyle___")]
	public static extern void OdPdfPublish_OdPolylineAnnotation_getLineStyle(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_getEndings___")]
	public static extern void OdPdfPublish_OdPolylineAnnotation_getEndings(HandleRef jarg1, out OdPdfPublish_LineEnding_Style jarg2, out OdPdfPublish_LineEnding_Style jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_getRealClassName___")]
	public static extern string OdPdfPublish_OdPolylineAnnotation_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_director_connect___")]
	public static extern void OdPdfPublish_OdPolylineAnnotation_director_connect(HandleRef jarg1, OdPdfPublish_OdPolylineAnnotation.SwigDelegateOdPdfPublish_OdPolylineAnnotation_0 delegate0, OdPdfPublish_OdPolylineAnnotation.SwigDelegateOdPdfPublish_OdPolylineAnnotation_1 delegate1, OdPdfPublish_OdPolylineAnnotation.SwigDelegateOdPdfPublish_OdPolylineAnnotation_2 delegate2, OdPdfPublish_OdPolylineAnnotation.SwigDelegateOdPdfPublish_OdPolylineAnnotation_3 delegate3, OdPdfPublish_OdPolylineAnnotation.SwigDelegateOdPdfPublish_OdPolylineAnnotation_4 delegate4, OdPdfPublish_OdPolylineAnnotation.SwigDelegateOdPdfPublish_OdPolylineAnnotation_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdSquareAnnotation___")]
	public static extern IntPtr new_OdPdfPublish_OdSquareAnnotation();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_cast___")]
	public static extern IntPtr OdPdfPublish_OdSquareAnnotation_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_desc___")]
	public static extern IntPtr OdPdfPublish_OdSquareAnnotation_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_isA___")]
	public static extern IntPtr OdPdfPublish_OdSquareAnnotation_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_isASwigExplicitOdPdfPublish_OdSquareAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdSquareAnnotation_isASwigExplicitOdPdfPublish_OdSquareAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_queryX___")]
	public static extern IntPtr OdPdfPublish_OdSquareAnnotation_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_queryXSwigExplicitOdPdfPublish_OdSquareAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdSquareAnnotation_queryXSwigExplicitOdPdfPublish_OdSquareAnnotation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_createObject___")]
	public static extern IntPtr OdPdfPublish_OdSquareAnnotation_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdSquareAnnotation___")]
	public static extern void delete_OdPdfPublish_OdSquareAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_setLineStyle___")]
	public static extern void OdPdfPublish_OdSquareAnnotation_setLineStyle(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_setLineEffect___")]
	public static extern void OdPdfPublish_OdSquareAnnotation_setLineEffect(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_getLineStyle___")]
	public static extern void OdPdfPublish_OdSquareAnnotation_getLineStyle(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_getLineEffect___")]
	public static extern void OdPdfPublish_OdSquareAnnotation_getLineEffect(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_getRealClassName___")]
	public static extern string OdPdfPublish_OdSquareAnnotation_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_director_connect___")]
	public static extern void OdPdfPublish_OdSquareAnnotation_director_connect(HandleRef jarg1, OdPdfPublish_OdSquareAnnotation.SwigDelegateOdPdfPublish_OdSquareAnnotation_0 delegate0, OdPdfPublish_OdSquareAnnotation.SwigDelegateOdPdfPublish_OdSquareAnnotation_1 delegate1, OdPdfPublish_OdSquareAnnotation.SwigDelegateOdPdfPublish_OdSquareAnnotation_2 delegate2, OdPdfPublish_OdSquareAnnotation.SwigDelegateOdPdfPublish_OdSquareAnnotation_3 delegate3, OdPdfPublish_OdSquareAnnotation.SwigDelegateOdPdfPublish_OdSquareAnnotation_4 delegate4, OdPdfPublish_OdSquareAnnotation.SwigDelegateOdPdfPublish_OdSquareAnnotation_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdCircleAnnotation___")]
	public static extern IntPtr new_OdPdfPublish_OdCircleAnnotation();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_cast___")]
	public static extern IntPtr OdPdfPublish_OdCircleAnnotation_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_desc___")]
	public static extern IntPtr OdPdfPublish_OdCircleAnnotation_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_isA___")]
	public static extern IntPtr OdPdfPublish_OdCircleAnnotation_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_isASwigExplicitOdPdfPublish_OdCircleAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdCircleAnnotation_isASwigExplicitOdPdfPublish_OdCircleAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_queryX___")]
	public static extern IntPtr OdPdfPublish_OdCircleAnnotation_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_queryXSwigExplicitOdPdfPublish_OdCircleAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdCircleAnnotation_queryXSwigExplicitOdPdfPublish_OdCircleAnnotation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_createObject___")]
	public static extern IntPtr OdPdfPublish_OdCircleAnnotation_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCircleAnnotation___")]
	public static extern void delete_OdPdfPublish_OdCircleAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_setLineStyle___")]
	public static extern void OdPdfPublish_OdCircleAnnotation_setLineStyle(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_setLineEffect___")]
	public static extern void OdPdfPublish_OdCircleAnnotation_setLineEffect(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_getLineStyle___")]
	public static extern void OdPdfPublish_OdCircleAnnotation_getLineStyle(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_getLineEffect___")]
	public static extern void OdPdfPublish_OdCircleAnnotation_getLineEffect(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_getRealClassName___")]
	public static extern string OdPdfPublish_OdCircleAnnotation_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_director_connect___")]
	public static extern void OdPdfPublish_OdCircleAnnotation_director_connect(HandleRef jarg1, OdPdfPublish_OdCircleAnnotation.SwigDelegateOdPdfPublish_OdCircleAnnotation_0 delegate0, OdPdfPublish_OdCircleAnnotation.SwigDelegateOdPdfPublish_OdCircleAnnotation_1 delegate1, OdPdfPublish_OdCircleAnnotation.SwigDelegateOdPdfPublish_OdCircleAnnotation_2 delegate2, OdPdfPublish_OdCircleAnnotation.SwigDelegateOdPdfPublish_OdCircleAnnotation_3 delegate3, OdPdfPublish_OdCircleAnnotation.SwigDelegateOdPdfPublish_OdCircleAnnotation_4 delegate4, OdPdfPublish_OdCircleAnnotation.SwigDelegateOdPdfPublish_OdCircleAnnotation_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdLineAnnotation___")]
	public static extern IntPtr new_OdPdfPublish_OdLineAnnotation();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_cast___")]
	public static extern IntPtr OdPdfPublish_OdLineAnnotation_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_desc___")]
	public static extern IntPtr OdPdfPublish_OdLineAnnotation_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_isA___")]
	public static extern IntPtr OdPdfPublish_OdLineAnnotation_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_isASwigExplicitOdPdfPublish_OdLineAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdLineAnnotation_isASwigExplicitOdPdfPublish_OdLineAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_queryX___")]
	public static extern IntPtr OdPdfPublish_OdLineAnnotation_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_queryXSwigExplicitOdPdfPublish_OdLineAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdLineAnnotation_queryXSwigExplicitOdPdfPublish_OdLineAnnotation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_createObject___")]
	public static extern IntPtr OdPdfPublish_OdLineAnnotation_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdLineAnnotation___")]
	public static extern void delete_OdPdfPublish_OdLineAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_setPoints___")]
	public static extern void OdPdfPublish_OdLineAnnotation_setPoints(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_setLineStyle___")]
	public static extern void OdPdfPublish_OdLineAnnotation_setLineStyle(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_setEndings___")]
	public static extern void OdPdfPublish_OdLineAnnotation_setEndings(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_setLeaderLinesSize___")]
	public static extern void OdPdfPublish_OdLineAnnotation_setLeaderLinesSize(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_setLeaderLinesExtSize___")]
	public static extern void OdPdfPublish_OdLineAnnotation_setLeaderLinesExtSize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_setLeaderLinesOffsetSize___")]
	public static extern void OdPdfPublish_OdLineAnnotation_setLeaderLinesOffsetSize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_setLineIntent___")]
	public static extern void OdPdfPublish_OdLineAnnotation_setLineIntent(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_setCaptionPosition___")]
	public static extern void OdPdfPublish_OdLineAnnotation_setCaptionPosition(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_setCaptionOffset___")]
	public static extern void OdPdfPublish_OdLineAnnotation_setCaptionOffset(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_setCaption___")]
	public static extern void OdPdfPublish_OdLineAnnotation_setCaption(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_getPoints___")]
	public static extern void OdPdfPublish_OdLineAnnotation_getPoints(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_getLineStyle___")]
	public static extern void OdPdfPublish_OdLineAnnotation_getLineStyle(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_getEndings___")]
	public static extern void OdPdfPublish_OdLineAnnotation_getEndings(HandleRef jarg1, out OdPdfPublish_LineEnding_Style jarg2, out OdPdfPublish_LineEnding_Style jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_getLeaderLinesSize___")]
	public static extern void OdPdfPublish_OdLineAnnotation_getLeaderLinesSize(HandleRef jarg1, out int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_getLeaderLinesExtSize___")]
	public static extern void OdPdfPublish_OdLineAnnotation_getLeaderLinesExtSize(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_getLeaderLinesOffsetSize___")]
	public static extern void OdPdfPublish_OdLineAnnotation_getLeaderLinesOffsetSize(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_getLineIntent___")]
	public static extern void OdPdfPublish_OdLineAnnotation_getLineIntent(HandleRef jarg1, out OdPdfPublish_LineOptions_Intent jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_getCaptionPosition___")]
	public static extern void OdPdfPublish_OdLineAnnotation_getCaptionPosition(HandleRef jarg1, out OdPdfPublish_LineOptions_CaptionPosition jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_getCaptionOffset___")]
	public static extern void OdPdfPublish_OdLineAnnotation_getCaptionOffset(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_getCaption___")]
	public static extern void OdPdfPublish_OdLineAnnotation_getCaption(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_getRealClassName___")]
	public static extern string OdPdfPublish_OdLineAnnotation_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_director_connect___")]
	public static extern void OdPdfPublish_OdLineAnnotation_director_connect(HandleRef jarg1, OdPdfPublish_OdLineAnnotation.SwigDelegateOdPdfPublish_OdLineAnnotation_0 delegate0, OdPdfPublish_OdLineAnnotation.SwigDelegateOdPdfPublish_OdLineAnnotation_1 delegate1, OdPdfPublish_OdLineAnnotation.SwigDelegateOdPdfPublish_OdLineAnnotation_2 delegate2, OdPdfPublish_OdLineAnnotation.SwigDelegateOdPdfPublish_OdLineAnnotation_3 delegate3, OdPdfPublish_OdLineAnnotation.SwigDelegateOdPdfPublish_OdLineAnnotation_4 delegate4, OdPdfPublish_OdLineAnnotation.SwigDelegateOdPdfPublish_OdLineAnnotation_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdInkAnnotation___")]
	public static extern IntPtr new_OdPdfPublish_OdInkAnnotation();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_cast___")]
	public static extern IntPtr OdPdfPublish_OdInkAnnotation_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_desc___")]
	public static extern IntPtr OdPdfPublish_OdInkAnnotation_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_isA___")]
	public static extern IntPtr OdPdfPublish_OdInkAnnotation_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_isASwigExplicitOdPdfPublish_OdInkAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdInkAnnotation_isASwigExplicitOdPdfPublish_OdInkAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_queryX___")]
	public static extern IntPtr OdPdfPublish_OdInkAnnotation_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_queryXSwigExplicitOdPdfPublish_OdInkAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdInkAnnotation_queryXSwigExplicitOdPdfPublish_OdInkAnnotation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_createObject___")]
	public static extern IntPtr OdPdfPublish_OdInkAnnotation_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdInkAnnotation___")]
	public static extern void delete_OdPdfPublish_OdInkAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_setInkList___")]
	public static extern void OdPdfPublish_OdInkAnnotation_setInkList(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_addStroke___")]
	public static extern void OdPdfPublish_OdInkAnnotation_addStroke(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_setLineStyle___")]
	public static extern void OdPdfPublish_OdInkAnnotation_setLineStyle(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_getInkList___")]
	public static extern void OdPdfPublish_OdInkAnnotation_getInkList(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_getLineStyle___")]
	public static extern void OdPdfPublish_OdInkAnnotation_getLineStyle(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_getRealClassName___")]
	public static extern string OdPdfPublish_OdInkAnnotation_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_director_connect___")]
	public static extern void OdPdfPublish_OdInkAnnotation_director_connect(HandleRef jarg1, OdPdfPublish_OdInkAnnotation.SwigDelegateOdPdfPublish_OdInkAnnotation_0 delegate0, OdPdfPublish_OdInkAnnotation.SwigDelegateOdPdfPublish_OdInkAnnotation_1 delegate1, OdPdfPublish_OdInkAnnotation.SwigDelegateOdPdfPublish_OdInkAnnotation_2 delegate2, OdPdfPublish_OdInkAnnotation.SwigDelegateOdPdfPublish_OdInkAnnotation_3 delegate3, OdPdfPublish_OdInkAnnotation.SwigDelegateOdPdfPublish_OdInkAnnotation_4 delegate4, OdPdfPublish_OdInkAnnotation.SwigDelegateOdPdfPublish_OdInkAnnotation_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdStampAnnotation___")]
	public static extern IntPtr new_OdPdfPublish_OdStampAnnotation();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotation_cast___")]
	public static extern IntPtr OdPdfPublish_OdStampAnnotation_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotation_desc___")]
	public static extern IntPtr OdPdfPublish_OdStampAnnotation_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotation_isA___")]
	public static extern IntPtr OdPdfPublish_OdStampAnnotation_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotation_isASwigExplicitOdPdfPublish_OdStampAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdStampAnnotation_isASwigExplicitOdPdfPublish_OdStampAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotation_queryX___")]
	public static extern IntPtr OdPdfPublish_OdStampAnnotation_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotation_queryXSwigExplicitOdPdfPublish_OdStampAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdStampAnnotation_queryXSwigExplicitOdPdfPublish_OdStampAnnotation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotation_createObject___")]
	public static extern IntPtr OdPdfPublish_OdStampAnnotation_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdStampAnnotation___")]
	public static extern void delete_OdPdfPublish_OdStampAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotation_setStampAnnotationType___")]
	public static extern void OdPdfPublish_OdStampAnnotation_setStampAnnotationType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotation_getStampAnnotationType___")]
	public static extern void OdPdfPublish_OdStampAnnotation_getStampAnnotationType(HandleRef jarg1, out OdPdfPublish_StampAnnotations_StampAnnotationTypes jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotation_getRealClassName___")]
	public static extern string OdPdfPublish_OdStampAnnotation_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotation_director_connect___")]
	public static extern void OdPdfPublish_OdStampAnnotation_director_connect(HandleRef jarg1, OdPdfPublish_OdStampAnnotation.SwigDelegateOdPdfPublish_OdStampAnnotation_0 delegate0, OdPdfPublish_OdStampAnnotation.SwigDelegateOdPdfPublish_OdStampAnnotation_1 delegate1, OdPdfPublish_OdStampAnnotation.SwigDelegateOdPdfPublish_OdStampAnnotation_2 delegate2, OdPdfPublish_OdStampAnnotation.SwigDelegateOdPdfPublish_OdStampAnnotation_3 delegate3, OdPdfPublish_OdStampAnnotation.SwigDelegateOdPdfPublish_OdStampAnnotation_4 delegate4, OdPdfPublish_OdStampAnnotation.SwigDelegateOdPdfPublish_OdStampAnnotation_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdWatermark___")]
	public static extern IntPtr new_OdPdfPublish_OdWatermark();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_cast___")]
	public static extern IntPtr OdPdfPublish_OdWatermark_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_desc___")]
	public static extern IntPtr OdPdfPublish_OdWatermark_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_isA___")]
	public static extern IntPtr OdPdfPublish_OdWatermark_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_isASwigExplicitOdPdfPublish_OdWatermark___")]
	public static extern IntPtr OdPdfPublish_OdWatermark_isASwigExplicitOdPdfPublish_OdWatermark(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_queryX___")]
	public static extern IntPtr OdPdfPublish_OdWatermark_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_queryXSwigExplicitOdPdfPublish_OdWatermark___")]
	public static extern IntPtr OdPdfPublish_OdWatermark_queryXSwigExplicitOdPdfPublish_OdWatermark(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_createObject___")]
	public static extern IntPtr OdPdfPublish_OdWatermark_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdWatermark___")]
	public static extern void delete_OdPdfPublish_OdWatermark(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_setSize___")]
	public static extern void OdPdfPublish_OdWatermark_setSize(HandleRef jarg1, uint jarg2, uint jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_setOpacity___")]
	public static extern void OdPdfPublish_OdWatermark_setOpacity(HandleRef jarg1, byte jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_addText__SWIG_0___")]
	public static extern void OdPdfPublish_OdWatermark_addText__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, double jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_addText__SWIG_1___")]
	public static extern void OdPdfPublish_OdWatermark_addText__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_addImage__SWIG_0___")]
	public static extern void OdPdfPublish_OdWatermark_addImage__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, double jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_addImage__SWIG_1___")]
	public static extern void OdPdfPublish_OdWatermark_addImage__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_getSize___")]
	public static extern void OdPdfPublish_OdWatermark_getSize(HandleRef jarg1, out uint jarg2, out uint jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_getOpacity___")]
	public static extern void OdPdfPublish_OdWatermark_getOpacity(HandleRef jarg1, out byte jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_getTexts___")]
	public static extern void OdPdfPublish_OdWatermark_getTexts(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, IntPtr jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_getImages___")]
	public static extern void OdPdfPublish_OdWatermark_getImages(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, IntPtr jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_getRealClassName___")]
	public static extern string OdPdfPublish_OdWatermark_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_director_connect___")]
	public static extern void OdPdfPublish_OdWatermark_director_connect(HandleRef jarg1, OdPdfPublish_OdWatermark.SwigDelegateOdPdfPublish_OdWatermark_0 delegate0, OdPdfPublish_OdWatermark.SwigDelegateOdPdfPublish_OdWatermark_1 delegate1, OdPdfPublish_OdWatermark.SwigDelegateOdPdfPublish_OdWatermark_2 delegate2, OdPdfPublish_OdWatermark.SwigDelegateOdPdfPublish_OdWatermark_3 delegate3, OdPdfPublish_OdWatermark.SwigDelegateOdPdfPublish_OdWatermark_4 delegate4, OdPdfPublish_OdWatermark.SwigDelegateOdPdfPublish_OdWatermark_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdStickyNote___")]
	public static extern IntPtr new_OdPdfPublish_OdStickyNote();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNote_cast___")]
	public static extern IntPtr OdPdfPublish_OdStickyNote_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNote_desc___")]
	public static extern IntPtr OdPdfPublish_OdStickyNote_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNote_isA___")]
	public static extern IntPtr OdPdfPublish_OdStickyNote_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNote_isASwigExplicitOdPdfPublish_OdStickyNote___")]
	public static extern IntPtr OdPdfPublish_OdStickyNote_isASwigExplicitOdPdfPublish_OdStickyNote(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNote_queryX___")]
	public static extern IntPtr OdPdfPublish_OdStickyNote_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNote_queryXSwigExplicitOdPdfPublish_OdStickyNote___")]
	public static extern IntPtr OdPdfPublish_OdStickyNote_queryXSwigExplicitOdPdfPublish_OdStickyNote(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNote_createObject___")]
	public static extern IntPtr OdPdfPublish_OdStickyNote_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdStickyNote___")]
	public static extern void delete_OdPdfPublish_OdStickyNote(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNote_setStickyNoteType___")]
	public static extern void OdPdfPublish_OdStickyNote_setStickyNoteType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNote_getStickyNoteType___")]
	public static extern void OdPdfPublish_OdStickyNote_getStickyNoteType(HandleRef jarg1, out OdPdfPublish_StickyNotes_StickyNoteTypes jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNote_getRealClassName___")]
	public static extern string OdPdfPublish_OdStickyNote_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNote_director_connect___")]
	public static extern void OdPdfPublish_OdStickyNote_director_connect(HandleRef jarg1, OdPdfPublish_OdStickyNote.SwigDelegateOdPdfPublish_OdStickyNote_0 delegate0, OdPdfPublish_OdStickyNote.SwigDelegateOdPdfPublish_OdStickyNote_1 delegate1, OdPdfPublish_OdStickyNote.SwigDelegateOdPdfPublish_OdStickyNote_2 delegate2, OdPdfPublish_OdStickyNote.SwigDelegateOdPdfPublish_OdStickyNote_3 delegate3, OdPdfPublish_OdStickyNote.SwigDelegateOdPdfPublish_OdStickyNote_4 delegate4, OdPdfPublish_OdStickyNote.SwigDelegateOdPdfPublish_OdStickyNote_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdCADReference___")]
	public static extern IntPtr new_OdPdfPublish_OdCADReference();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_cast___")]
	public static extern IntPtr OdPdfPublish_OdCADReference_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_desc___")]
	public static extern IntPtr OdPdfPublish_OdCADReference_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_isA___")]
	public static extern IntPtr OdPdfPublish_OdCADReference_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_isASwigExplicitOdPdfPublish_OdCADReference___")]
	public static extern IntPtr OdPdfPublish_OdCADReference_isASwigExplicitOdPdfPublish_OdCADReference(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_queryX___")]
	public static extern IntPtr OdPdfPublish_OdCADReference_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_queryXSwigExplicitOdPdfPublish_OdCADReference___")]
	public static extern IntPtr OdPdfPublish_OdCADReference_queryXSwigExplicitOdPdfPublish_OdCADReference(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_createObject___")]
	public static extern IntPtr OdPdfPublish_OdCADReference_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCADReference___")]
	public static extern void delete_OdPdfPublish_OdCADReference(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setCADDefinition___")]
	public static extern void OdPdfPublish_OdCADReference_setCADDefinition(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setBorder___")]
	public static extern void OdPdfPublish_OdCADReference_setBorder(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setBorderColor___")]
	public static extern void OdPdfPublish_OdCADReference_setBorderColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setBorderWidth___")]
	public static extern void OdPdfPublish_OdCADReference_setBorderWidth(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setRotation___")]
	public static extern void OdPdfPublish_OdCADReference_setRotation(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setClipBoundary___")]
	public static extern void OdPdfPublish_OdCADReference_setClipBoundary(HandleRef jarg1, int jarg2, IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setClipBoundaryBorder___")]
	public static extern void OdPdfPublish_OdCADReference_setClipBoundaryBorder(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setClipBoundaryBorderColor___")]
	public static extern void OdPdfPublish_OdCADReference_setClipBoundaryBorderColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setClipBoundaryBorderWidth___")]
	public static extern void OdPdfPublish_OdCADReference_setClipBoundaryBorderWidth(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setTransform___")]
	public static extern void OdPdfPublish_OdCADReference_setTransform(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setScale___")]
	public static extern void OdPdfPublish_OdCADReference_setScale(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setTranslation___")]
	public static extern void OdPdfPublish_OdCADReference_setTranslation(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setEnableBookmarks___")]
	public static extern void OdPdfPublish_OdCADReference_setEnableBookmarks(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_setCADReferenceName___")]
	public static extern void OdPdfPublish_OdCADReference_setCADReferenceName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getCADDefinition___")]
	public static extern void OdPdfPublish_OdCADReference_getCADDefinition(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getBorder___")]
	public static extern void OdPdfPublish_OdCADReference_getBorder(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getBorderColor___")]
	public static extern void OdPdfPublish_OdCADReference_getBorderColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getBorderWidth___")]
	public static extern void OdPdfPublish_OdCADReference_getBorderWidth(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getRotation___")]
	public static extern void OdPdfPublish_OdCADReference_getRotation(HandleRef jarg1, out double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getClipBoundary___")]
	public static extern void OdPdfPublish_OdCADReference_getClipBoundary(HandleRef jarg1, out OdPdfPublish_Page_PaperUnits jarg2, IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getClipBoundaryBorder___")]
	public static extern void OdPdfPublish_OdCADReference_getClipBoundaryBorder(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getClipBoundaryBorderColor___")]
	public static extern void OdPdfPublish_OdCADReference_getClipBoundaryBorderColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getClipBoundaryBorderWidth___")]
	public static extern void OdPdfPublish_OdCADReference_getClipBoundaryBorderWidth(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getTransform___")]
	public static extern void OdPdfPublish_OdCADReference_getTransform(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getScale___")]
	public static extern void OdPdfPublish_OdCADReference_getScale(HandleRef jarg1, out double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getTranslation___")]
	public static extern void OdPdfPublish_OdCADReference_getTranslation(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getEnableBookmarks___")]
	public static extern void OdPdfPublish_OdCADReference_getEnableBookmarks(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getCADReferenceName___")]
	public static extern void OdPdfPublish_OdCADReference_getCADReferenceName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_getRealClassName___")]
	public static extern string OdPdfPublish_OdCADReference_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_director_connect___")]
	public static extern void OdPdfPublish_OdCADReference_director_connect(HandleRef jarg1, OdPdfPublish_OdCADReference.SwigDelegateOdPdfPublish_OdCADReference_0 delegate0, OdPdfPublish_OdCADReference.SwigDelegateOdPdfPublish_OdCADReference_1 delegate1, OdPdfPublish_OdCADReference.SwigDelegateOdPdfPublish_OdCADReference_2 delegate2, OdPdfPublish_OdCADReference.SwigDelegateOdPdfPublish_OdCADReference_3 delegate3, OdPdfPublish_OdCADReference.SwigDelegateOdPdfPublish_OdCADReference_4 delegate4, OdPdfPublish_OdCADReference.SwigDelegateOdPdfPublish_OdCADReference_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_Od2dGeometryReference___")]
	public static extern IntPtr new_OdPdfPublish_Od2dGeometryReference();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_cast___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryReference_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_desc___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryReference_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_isA___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryReference_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_isASwigExplicitOdPdfPublish_Od2dGeometryReference___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryReference_isASwigExplicitOdPdfPublish_Od2dGeometryReference(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_queryX___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryReference_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_queryXSwigExplicitOdPdfPublish_Od2dGeometryReference___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryReference_queryXSwigExplicitOdPdfPublish_Od2dGeometryReference(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_createObject___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryReference_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_Od2dGeometryReference___")]
	public static extern void delete_OdPdfPublish_Od2dGeometryReference(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_setBorder___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_setBorder(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_setBorderColor___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_setBorderColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_getBorder___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_getBorder(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_getBorderColor___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_getBorderColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_setTransform___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_setTransform(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_getTransform___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_getTransform(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_setGeometryBlock___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_setGeometryBlock(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_getGeometryBlock___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_getGeometryBlock(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_setScale___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_setScale(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_getScale___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_getScale(HandleRef jarg1, out double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_setRotation__SWIG_0___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_setRotation__SWIG_0(HandleRef jarg1, double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_setRotation__SWIG_1___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_setRotation__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_getRotation___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_getRotation(HandleRef jarg1, out double jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_setTranslation___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_setTranslation(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_getTranslation___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_getTranslation(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_setLayer___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_setLayer(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_getLayer___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_getLayer(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_getRealClassName___")]
	public static extern string OdPdfPublish_Od2dGeometryReference_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_director_connect___")]
	public static extern void OdPdfPublish_Od2dGeometryReference_director_connect(HandleRef jarg1, OdPdfPublish_Od2dGeometryReference.SwigDelegateOdPdfPublish_Od2dGeometryReference_0 delegate0, OdPdfPublish_Od2dGeometryReference.SwigDelegateOdPdfPublish_Od2dGeometryReference_1 delegate1, OdPdfPublish_Od2dGeometryReference.SwigDelegateOdPdfPublish_Od2dGeometryReference_2 delegate2, OdPdfPublish_Od2dGeometryReference.SwigDelegateOdPdfPublish_Od2dGeometryReference_3 delegate3, OdPdfPublish_Od2dGeometryReference.SwigDelegateOdPdfPublish_Od2dGeometryReference_4 delegate4, OdPdfPublish_Od2dGeometryReference.SwigDelegateOdPdfPublish_Od2dGeometryReference_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdTableCreator___")]
	public static extern IntPtr new_OdPdfPublish_OdTableCreator();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_cast___")]
	public static extern IntPtr OdPdfPublish_OdTableCreator_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_desc___")]
	public static extern IntPtr OdPdfPublish_OdTableCreator_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_isA___")]
	public static extern IntPtr OdPdfPublish_OdTableCreator_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_isASwigExplicitOdPdfPublish_OdTableCreator___")]
	public static extern IntPtr OdPdfPublish_OdTableCreator_isASwigExplicitOdPdfPublish_OdTableCreator(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_queryX___")]
	public static extern IntPtr OdPdfPublish_OdTableCreator_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_queryXSwigExplicitOdPdfPublish_OdTableCreator___")]
	public static extern IntPtr OdPdfPublish_OdTableCreator_queryXSwigExplicitOdPdfPublish_OdTableCreator(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_createObject___")]
	public static extern IntPtr OdPdfPublish_OdTableCreator_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_isEmpty___")]
	public static extern bool OdPdfPublish_OdTableCreator_isEmpty(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_clear___")]
	public static extern void OdPdfPublish_OdTableCreator_clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_isValid___")]
	public static extern bool OdPdfPublish_OdTableCreator_isValid(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdTableCreator___")]
	public static extern void delete_OdPdfPublish_OdTableCreator(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_setColumnCount___")]
	public static extern void OdPdfPublish_OdTableCreator_setColumnCount(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_setRowCount___")]
	public static extern void OdPdfPublish_OdTableCreator_setRowCount(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_setParticularColumnWidth___")]
	public static extern void OdPdfPublish_OdTableCreator_setParticularColumnWidth(HandleRef jarg1, uint jarg2, uint jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_setParticularRowHeight___")]
	public static extern void OdPdfPublish_OdTableCreator_setParticularRowHeight(HandleRef jarg1, uint jarg2, uint jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_setCellFillColor___")]
	public static extern void OdPdfPublish_OdTableCreator_setCellFillColor(HandleRef jarg1, uint jarg2, uint jarg3, uint jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_setCellBorderColor___")]
	public static extern void OdPdfPublish_OdTableCreator_setCellBorderColor(HandleRef jarg1, uint jarg2, uint jarg3, uint jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_setCellBorderThickness___")]
	public static extern void OdPdfPublish_OdTableCreator_setCellBorderThickness(HandleRef jarg1, uint jarg2, uint jarg3, int jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_setCellBackgroundImage___")]
	public static extern void OdPdfPublish_OdTableCreator_setCellBackgroundImage(HandleRef jarg1, uint jarg2, uint jarg3, HandleRef jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_setCellTilingPattern___")]
	public static extern void OdPdfPublish_OdTableCreator_setCellTilingPattern(HandleRef jarg1, uint jarg2, uint jarg3, HandleRef jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_getColumnCount___")]
	public static extern void OdPdfPublish_OdTableCreator_getColumnCount(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_getRowCount___")]
	public static extern void OdPdfPublish_OdTableCreator_getRowCount(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_getParticularColumnWidth___")]
	public static extern bool OdPdfPublish_OdTableCreator_getParticularColumnWidth(HandleRef jarg1, uint jarg2, out uint jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_getParticularRowHeight___")]
	public static extern bool OdPdfPublish_OdTableCreator_getParticularRowHeight(HandleRef jarg1, uint jarg2, out uint jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_getCellFillColor___")]
	public static extern void OdPdfPublish_OdTableCreator_getCellFillColor(HandleRef jarg1, uint jarg2, uint jarg3, out uint jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_getCellBorderColor___")]
	public static extern void OdPdfPublish_OdTableCreator_getCellBorderColor(HandleRef jarg1, uint jarg2, uint jarg3, out uint jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_getCellBorderThickness___")]
	public static extern void OdPdfPublish_OdTableCreator_getCellBorderThickness(HandleRef jarg1, uint jarg2, uint jarg3, out OdPdfPublish_Border_Thickness jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_getCellBackgroundImage___")]
	public static extern void OdPdfPublish_OdTableCreator_getCellBackgroundImage(HandleRef jarg1, uint jarg2, uint jarg3, ref IntPtr jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_getCellTilingPattern___")]
	public static extern void OdPdfPublish_OdTableCreator_getCellTilingPattern(HandleRef jarg1, uint jarg2, uint jarg3, ref IntPtr jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_createTable___")]
	public static extern IntPtr OdPdfPublish_OdTableCreator_createTable(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_getRealClassName___")]
	public static extern string OdPdfPublish_OdTableCreator_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_director_connect___")]
	public static extern void OdPdfPublish_OdTableCreator_director_connect(HandleRef jarg1, OdPdfPublish_OdTableCreator.SwigDelegateOdPdfPublish_OdTableCreator_0 delegate0, OdPdfPublish_OdTableCreator.SwigDelegateOdPdfPublish_OdTableCreator_1 delegate1, OdPdfPublish_OdTableCreator.SwigDelegateOdPdfPublish_OdTableCreator_2 delegate2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdSlideTable___")]
	public static extern IntPtr new_OdPdfPublish_OdSlideTable();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_cast___")]
	public static extern IntPtr OdPdfPublish_OdSlideTable_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_desc___")]
	public static extern IntPtr OdPdfPublish_OdSlideTable_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_isA___")]
	public static extern IntPtr OdPdfPublish_OdSlideTable_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_isASwigExplicitOdPdfPublish_OdSlideTable___")]
	public static extern IntPtr OdPdfPublish_OdSlideTable_isASwigExplicitOdPdfPublish_OdSlideTable(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_queryX___")]
	public static extern IntPtr OdPdfPublish_OdSlideTable_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_queryXSwigExplicitOdPdfPublish_OdSlideTable___")]
	public static extern IntPtr OdPdfPublish_OdSlideTable_queryXSwigExplicitOdPdfPublish_OdSlideTable(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_createObject___")]
	public static extern IntPtr OdPdfPublish_OdSlideTable_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdSlideTable___")]
	public static extern void delete_OdPdfPublish_OdSlideTable(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_setDimensions___")]
	public static extern void OdPdfPublish_OdSlideTable_setDimensions(HandleRef jarg1, IntPtr jarg2, uint jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_setButtons___")]
	public static extern void OdPdfPublish_OdSlideTable_setButtons(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_setText___")]
	public static extern void OdPdfPublish_OdSlideTable_setText(HandleRef jarg1, uint jarg2, uint jarg3, HandleRef jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_setHeader___")]
	public static extern void OdPdfPublish_OdSlideTable_setHeader(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_getDimensions___")]
	public static extern void OdPdfPublish_OdSlideTable_getDimensions(HandleRef jarg1, IntPtr jarg2, out uint jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_getButtons___")]
	public static extern void OdPdfPublish_OdSlideTable_getButtons(HandleRef jarg1, ref IntPtr jarg2, ref IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_getText___")]
	public static extern void OdPdfPublish_OdSlideTable_getText(HandleRef jarg1, out uint jarg2, out uint jarg3, HandleRef jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_getHeader___")]
	public static extern void OdPdfPublish_OdSlideTable_getHeader(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_getRealClassName___")]
	public static extern string OdPdfPublish_OdSlideTable_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_director_connect___")]
	public static extern void OdPdfPublish_OdSlideTable_director_connect(HandleRef jarg1, OdPdfPublish_OdSlideTable.SwigDelegateOdPdfPublish_OdSlideTable_0 delegate0, OdPdfPublish_OdSlideTable.SwigDelegateOdPdfPublish_OdSlideTable_1 delegate1, OdPdfPublish_OdSlideTable.SwigDelegateOdPdfPublish_OdSlideTable_2 delegate2, OdPdfPublish_OdSlideTable.SwigDelegateOdPdfPublish_OdSlideTable_3 delegate3, OdPdfPublish_OdSlideTable.SwigDelegateOdPdfPublish_OdSlideTable_4 delegate4, OdPdfPublish_OdSlideTable.SwigDelegateOdPdfPublish_OdSlideTable_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdCheckBox___")]
	public static extern IntPtr new_OdPdfPublish_OdCheckBox();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_cast___")]
	public static extern IntPtr OdPdfPublish_OdCheckBox_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_desc___")]
	public static extern IntPtr OdPdfPublish_OdCheckBox_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_isA___")]
	public static extern IntPtr OdPdfPublish_OdCheckBox_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_isASwigExplicitOdPdfPublish_OdCheckBox___")]
	public static extern IntPtr OdPdfPublish_OdCheckBox_isASwigExplicitOdPdfPublish_OdCheckBox(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_queryX___")]
	public static extern IntPtr OdPdfPublish_OdCheckBox_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_queryXSwigExplicitOdPdfPublish_OdCheckBox___")]
	public static extern IntPtr OdPdfPublish_OdCheckBox_queryXSwigExplicitOdPdfPublish_OdCheckBox(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_createObject___")]
	public static extern IntPtr OdPdfPublish_OdCheckBox_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCheckBox___")]
	public static extern void delete_OdPdfPublish_OdCheckBox(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setName___")]
	public static extern void OdPdfPublish_OdCheckBox_setName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setFont__SWIG_0___")]
	public static extern void OdPdfPublish_OdCheckBox_setFont__SWIG_0(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setFont__SWIG_1___")]
	public static extern void OdPdfPublish_OdCheckBox_setFont__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4, bool jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setFont__SWIG_2___")]
	public static extern void OdPdfPublish_OdCheckBox_setFont__SWIG_2(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setFont__SWIG_3___")]
	public static extern void OdPdfPublish_OdCheckBox_setFont__SWIG_3(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setFont__SWIG_4___")]
	public static extern void OdPdfPublish_OdCheckBox_setFont__SWIG_4(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setFontSize___")]
	public static extern void OdPdfPublish_OdCheckBox_setFontSize(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setTextColor___")]
	public static extern void OdPdfPublish_OdCheckBox_setTextColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setTooltip___")]
	public static extern void OdPdfPublish_OdCheckBox_setTooltip(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setVisibility___")]
	public static extern void OdPdfPublish_OdCheckBox_setVisibility(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setPrintability___")]
	public static extern void OdPdfPublish_OdCheckBox_setPrintability(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setTextRotation___")]
	public static extern void OdPdfPublish_OdCheckBox_setTextRotation(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setLock___")]
	public static extern void OdPdfPublish_OdCheckBox_setLock(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setBorder___")]
	public static extern void OdPdfPublish_OdCheckBox_setBorder(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setBorderColor___")]
	public static extern void OdPdfPublish_OdCheckBox_setBorderColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setBorderThickness___")]
	public static extern void OdPdfPublish_OdCheckBox_setBorderThickness(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setBorderStyle___")]
	public static extern void OdPdfPublish_OdCheckBox_setBorderStyle(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setFillColor___")]
	public static extern void OdPdfPublish_OdCheckBox_setFillColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setExportValue___")]
	public static extern void OdPdfPublish_OdCheckBox_setExportValue(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_setDefaultState___")]
	public static extern void OdPdfPublish_OdCheckBox_setDefaultState(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getName___")]
	public static extern void OdPdfPublish_OdCheckBox_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getFont___")]
	public static extern void OdPdfPublish_OdCheckBox_getFont(HandleRef jarg1, out OdPdfPublish_Text_StorageType jarg2, out OdPdfPublish_Text_StandardFontsType jarg3, ref IntPtr jarg4, out OdPdfPublish_Text_FontStyle jarg5, out OdPdfPublish_Text_Language jarg6, out bool jarg7);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getFontSize___")]
	public static extern void OdPdfPublish_OdCheckBox_getFontSize(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getTextColor___")]
	public static extern void OdPdfPublish_OdCheckBox_getTextColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getTooltip___")]
	public static extern void OdPdfPublish_OdCheckBox_getTooltip(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getVisibility___")]
	public static extern void OdPdfPublish_OdCheckBox_getVisibility(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getPrintability___")]
	public static extern void OdPdfPublish_OdCheckBox_getPrintability(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getTextRotation___")]
	public static extern void OdPdfPublish_OdCheckBox_getTextRotation(HandleRef jarg1, out OdPdfPublish_Text_Rotation jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getLock___")]
	public static extern void OdPdfPublish_OdCheckBox_getLock(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getBorder___")]
	public static extern void OdPdfPublish_OdCheckBox_getBorder(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getBorderColor___")]
	public static extern void OdPdfPublish_OdCheckBox_getBorderColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getBorderThickness___")]
	public static extern void OdPdfPublish_OdCheckBox_getBorderThickness(HandleRef jarg1, out OdPdfPublish_Border_Thickness jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getBorderStyle___")]
	public static extern void OdPdfPublish_OdCheckBox_getBorderStyle(HandleRef jarg1, out OdPdfPublish_Border_Style jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getFillColor___")]
	public static extern void OdPdfPublish_OdCheckBox_getFillColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getExportValue___")]
	public static extern void OdPdfPublish_OdCheckBox_getExportValue(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getDefaultState___")]
	public static extern void OdPdfPublish_OdCheckBox_getDefaultState(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_getRealClassName___")]
	public static extern string OdPdfPublish_OdCheckBox_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_director_connect___")]
	public static extern void OdPdfPublish_OdCheckBox_director_connect(HandleRef jarg1, OdPdfPublish_OdCheckBox.SwigDelegateOdPdfPublish_OdCheckBox_0 delegate0, OdPdfPublish_OdCheckBox.SwigDelegateOdPdfPublish_OdCheckBox_1 delegate1, OdPdfPublish_OdCheckBox.SwigDelegateOdPdfPublish_OdCheckBox_2 delegate2, OdPdfPublish_OdCheckBox.SwigDelegateOdPdfPublish_OdCheckBox_3 delegate3, OdPdfPublish_OdCheckBox.SwigDelegateOdPdfPublish_OdCheckBox_4 delegate4, OdPdfPublish_OdCheckBox.SwigDelegateOdPdfPublish_OdCheckBox_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdRadioButton___")]
	public static extern IntPtr new_OdPdfPublish_OdRadioButton();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_cast___")]
	public static extern IntPtr OdPdfPublish_OdRadioButton_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_desc___")]
	public static extern IntPtr OdPdfPublish_OdRadioButton_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_isA___")]
	public static extern IntPtr OdPdfPublish_OdRadioButton_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_isASwigExplicitOdPdfPublish_OdRadioButton___")]
	public static extern IntPtr OdPdfPublish_OdRadioButton_isASwigExplicitOdPdfPublish_OdRadioButton(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_queryX___")]
	public static extern IntPtr OdPdfPublish_OdRadioButton_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_queryXSwigExplicitOdPdfPublish_OdRadioButton___")]
	public static extern IntPtr OdPdfPublish_OdRadioButton_queryXSwigExplicitOdPdfPublish_OdRadioButton(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_createObject___")]
	public static extern IntPtr OdPdfPublish_OdRadioButton_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdRadioButton___")]
	public static extern void delete_OdPdfPublish_OdRadioButton(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setName___")]
	public static extern void OdPdfPublish_OdRadioButton_setName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setFont__SWIG_0___")]
	public static extern void OdPdfPublish_OdRadioButton_setFont__SWIG_0(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setFont__SWIG_1___")]
	public static extern void OdPdfPublish_OdRadioButton_setFont__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4, bool jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setFont__SWIG_2___")]
	public static extern void OdPdfPublish_OdRadioButton_setFont__SWIG_2(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setFont__SWIG_3___")]
	public static extern void OdPdfPublish_OdRadioButton_setFont__SWIG_3(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setFont__SWIG_4___")]
	public static extern void OdPdfPublish_OdRadioButton_setFont__SWIG_4(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setFontSize___")]
	public static extern void OdPdfPublish_OdRadioButton_setFontSize(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setTextColor___")]
	public static extern void OdPdfPublish_OdRadioButton_setTextColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setTooltip___")]
	public static extern void OdPdfPublish_OdRadioButton_setTooltip(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setVisibility___")]
	public static extern void OdPdfPublish_OdRadioButton_setVisibility(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setPrintability___")]
	public static extern void OdPdfPublish_OdRadioButton_setPrintability(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setTextRotation___")]
	public static extern void OdPdfPublish_OdRadioButton_setTextRotation(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setLock___")]
	public static extern void OdPdfPublish_OdRadioButton_setLock(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setBorder___")]
	public static extern void OdPdfPublish_OdRadioButton_setBorder(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setBorderColor___")]
	public static extern void OdPdfPublish_OdRadioButton_setBorderColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setBorderThickness___")]
	public static extern void OdPdfPublish_OdRadioButton_setBorderThickness(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setBorderStyle___")]
	public static extern void OdPdfPublish_OdRadioButton_setBorderStyle(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setFillColor___")]
	public static extern void OdPdfPublish_OdRadioButton_setFillColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setExportValue___")]
	public static extern void OdPdfPublish_OdRadioButton_setExportValue(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setDefaultState___")]
	public static extern void OdPdfPublish_OdRadioButton_setDefaultState(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_setGrouping___")]
	public static extern void OdPdfPublish_OdRadioButton_setGrouping(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getName___")]
	public static extern void OdPdfPublish_OdRadioButton_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getFont___")]
	public static extern void OdPdfPublish_OdRadioButton_getFont(HandleRef jarg1, out OdPdfPublish_Text_StorageType jarg2, out OdPdfPublish_Text_StandardFontsType jarg3, ref IntPtr jarg4, out OdPdfPublish_Text_FontStyle jarg5, out OdPdfPublish_Text_Language jarg6, out bool jarg7);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getFontSize___")]
	public static extern void OdPdfPublish_OdRadioButton_getFontSize(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getTextColor___")]
	public static extern void OdPdfPublish_OdRadioButton_getTextColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getTooltip___")]
	public static extern void OdPdfPublish_OdRadioButton_getTooltip(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getVisibility___")]
	public static extern void OdPdfPublish_OdRadioButton_getVisibility(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getPrintability___")]
	public static extern void OdPdfPublish_OdRadioButton_getPrintability(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getTextRotation___")]
	public static extern void OdPdfPublish_OdRadioButton_getTextRotation(HandleRef jarg1, out OdPdfPublish_Text_Rotation jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getLock___")]
	public static extern void OdPdfPublish_OdRadioButton_getLock(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getBorder___")]
	public static extern void OdPdfPublish_OdRadioButton_getBorder(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getBorderColor___")]
	public static extern void OdPdfPublish_OdRadioButton_getBorderColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getBorderThickness___")]
	public static extern void OdPdfPublish_OdRadioButton_getBorderThickness(HandleRef jarg1, out OdPdfPublish_Border_Thickness jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getBorderStyle___")]
	public static extern void OdPdfPublish_OdRadioButton_getBorderStyle(HandleRef jarg1, out OdPdfPublish_Border_Style jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getFillColor___")]
	public static extern void OdPdfPublish_OdRadioButton_getFillColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getExportValue___")]
	public static extern void OdPdfPublish_OdRadioButton_getExportValue(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getDefaultState___")]
	public static extern void OdPdfPublish_OdRadioButton_getDefaultState(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getGrouping___")]
	public static extern void OdPdfPublish_OdRadioButton_getGrouping(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_getRealClassName___")]
	public static extern string OdPdfPublish_OdRadioButton_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_director_connect___")]
	public static extern void OdPdfPublish_OdRadioButton_director_connect(HandleRef jarg1, OdPdfPublish_OdRadioButton.SwigDelegateOdPdfPublish_OdRadioButton_0 delegate0, OdPdfPublish_OdRadioButton.SwigDelegateOdPdfPublish_OdRadioButton_1 delegate1, OdPdfPublish_OdRadioButton.SwigDelegateOdPdfPublish_OdRadioButton_2 delegate2, OdPdfPublish_OdRadioButton.SwigDelegateOdPdfPublish_OdRadioButton_3 delegate3, OdPdfPublish_OdRadioButton.SwigDelegateOdPdfPublish_OdRadioButton_4 delegate4, OdPdfPublish_OdRadioButton.SwigDelegateOdPdfPublish_OdRadioButton_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdDropDownList___")]
	public static extern IntPtr new_OdPdfPublish_OdDropDownList();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_cast___")]
	public static extern IntPtr OdPdfPublish_OdDropDownList_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_desc___")]
	public static extern IntPtr OdPdfPublish_OdDropDownList_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_isA___")]
	public static extern IntPtr OdPdfPublish_OdDropDownList_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_isASwigExplicitOdPdfPublish_OdDropDownList___")]
	public static extern IntPtr OdPdfPublish_OdDropDownList_isASwigExplicitOdPdfPublish_OdDropDownList(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_queryX___")]
	public static extern IntPtr OdPdfPublish_OdDropDownList_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_queryXSwigExplicitOdPdfPublish_OdDropDownList___")]
	public static extern IntPtr OdPdfPublish_OdDropDownList_queryXSwigExplicitOdPdfPublish_OdDropDownList(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_createObject___")]
	public static extern IntPtr OdPdfPublish_OdDropDownList_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdDropDownList___")]
	public static extern void delete_OdPdfPublish_OdDropDownList(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setName___")]
	public static extern void OdPdfPublish_OdDropDownList_setName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setFont__SWIG_0___")]
	public static extern void OdPdfPublish_OdDropDownList_setFont__SWIG_0(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setFont__SWIG_1___")]
	public static extern void OdPdfPublish_OdDropDownList_setFont__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4, bool jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setFont__SWIG_2___")]
	public static extern void OdPdfPublish_OdDropDownList_setFont__SWIG_2(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setFont__SWIG_3___")]
	public static extern void OdPdfPublish_OdDropDownList_setFont__SWIG_3(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setFont__SWIG_4___")]
	public static extern void OdPdfPublish_OdDropDownList_setFont__SWIG_4(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setFontSize___")]
	public static extern void OdPdfPublish_OdDropDownList_setFontSize(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setTextColor___")]
	public static extern void OdPdfPublish_OdDropDownList_setTextColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setTooltip___")]
	public static extern void OdPdfPublish_OdDropDownList_setTooltip(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setVisibility___")]
	public static extern void OdPdfPublish_OdDropDownList_setVisibility(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setPrintability___")]
	public static extern void OdPdfPublish_OdDropDownList_setPrintability(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setTextRotation___")]
	public static extern void OdPdfPublish_OdDropDownList_setTextRotation(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setLock___")]
	public static extern void OdPdfPublish_OdDropDownList_setLock(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setBorder___")]
	public static extern void OdPdfPublish_OdDropDownList_setBorder(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setBorderColor___")]
	public static extern void OdPdfPublish_OdDropDownList_setBorderColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setBorderThickness___")]
	public static extern void OdPdfPublish_OdDropDownList_setBorderThickness(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setBorderStyle___")]
	public static extern void OdPdfPublish_OdDropDownList_setBorderStyle(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setFillColor___")]
	public static extern void OdPdfPublish_OdDropDownList_setFillColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setCustomText___")]
	public static extern void OdPdfPublish_OdDropDownList_setCustomText(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setSpellChecking___")]
	public static extern void OdPdfPublish_OdDropDownList_setSpellChecking(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setImmediateCommit___")]
	public static extern void OdPdfPublish_OdDropDownList_setImmediateCommit(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_setContents___")]
	public static extern void OdPdfPublish_OdDropDownList_setContents(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getName___")]
	public static extern void OdPdfPublish_OdDropDownList_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getFont___")]
	public static extern void OdPdfPublish_OdDropDownList_getFont(HandleRef jarg1, out OdPdfPublish_Text_StorageType jarg2, out OdPdfPublish_Text_StandardFontsType jarg3, ref IntPtr jarg4, out OdPdfPublish_Text_FontStyle jarg5, out OdPdfPublish_Text_Language jarg6, out bool jarg7);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getFontSize___")]
	public static extern void OdPdfPublish_OdDropDownList_getFontSize(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getTextColor___")]
	public static extern void OdPdfPublish_OdDropDownList_getTextColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getTooltip___")]
	public static extern void OdPdfPublish_OdDropDownList_getTooltip(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getVisibility___")]
	public static extern void OdPdfPublish_OdDropDownList_getVisibility(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getPrintability___")]
	public static extern void OdPdfPublish_OdDropDownList_getPrintability(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getTextRotation___")]
	public static extern void OdPdfPublish_OdDropDownList_getTextRotation(HandleRef jarg1, out OdPdfPublish_Text_Rotation jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getLock___")]
	public static extern void OdPdfPublish_OdDropDownList_getLock(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getBorder___")]
	public static extern void OdPdfPublish_OdDropDownList_getBorder(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getBorderColor___")]
	public static extern void OdPdfPublish_OdDropDownList_getBorderColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getBorderThickness___")]
	public static extern void OdPdfPublish_OdDropDownList_getBorderThickness(HandleRef jarg1, out OdPdfPublish_Border_Thickness jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getBorderStyle___")]
	public static extern void OdPdfPublish_OdDropDownList_getBorderStyle(HandleRef jarg1, out OdPdfPublish_Border_Style jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getFillColor___")]
	public static extern void OdPdfPublish_OdDropDownList_getFillColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getCustomText___")]
	public static extern void OdPdfPublish_OdDropDownList_getCustomText(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getSpellChecking___")]
	public static extern void OdPdfPublish_OdDropDownList_getSpellChecking(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getImmediateCommit___")]
	public static extern void OdPdfPublish_OdDropDownList_getImmediateCommit(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getContents___")]
	public static extern void OdPdfPublish_OdDropDownList_getContents(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_getRealClassName___")]
	public static extern string OdPdfPublish_OdDropDownList_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_director_connect___")]
	public static extern void OdPdfPublish_OdDropDownList_director_connect(HandleRef jarg1, OdPdfPublish_OdDropDownList.SwigDelegateOdPdfPublish_OdDropDownList_0 delegate0, OdPdfPublish_OdDropDownList.SwigDelegateOdPdfPublish_OdDropDownList_1 delegate1, OdPdfPublish_OdDropDownList.SwigDelegateOdPdfPublish_OdDropDownList_2 delegate2, OdPdfPublish_OdDropDownList.SwigDelegateOdPdfPublish_OdDropDownList_3 delegate3, OdPdfPublish_OdDropDownList.SwigDelegateOdPdfPublish_OdDropDownList_4 delegate4, OdPdfPublish_OdDropDownList.SwigDelegateOdPdfPublish_OdDropDownList_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdSignatureField___")]
	public static extern IntPtr new_OdPdfPublish_OdSignatureField();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_cast___")]
	public static extern IntPtr OdPdfPublish_OdSignatureField_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_desc___")]
	public static extern IntPtr OdPdfPublish_OdSignatureField_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_isA___")]
	public static extern IntPtr OdPdfPublish_OdSignatureField_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_isASwigExplicitOdPdfPublish_OdSignatureField___")]
	public static extern IntPtr OdPdfPublish_OdSignatureField_isASwigExplicitOdPdfPublish_OdSignatureField(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_queryX___")]
	public static extern IntPtr OdPdfPublish_OdSignatureField_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_queryXSwigExplicitOdPdfPublish_OdSignatureField___")]
	public static extern IntPtr OdPdfPublish_OdSignatureField_queryXSwigExplicitOdPdfPublish_OdSignatureField(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_createObject___")]
	public static extern IntPtr OdPdfPublish_OdSignatureField_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdSignatureField___")]
	public static extern void delete_OdPdfPublish_OdSignatureField(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setName___")]
	public static extern void OdPdfPublish_OdSignatureField_setName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setFont__SWIG_0___")]
	public static extern void OdPdfPublish_OdSignatureField_setFont__SWIG_0(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setFont__SWIG_1___")]
	public static extern void OdPdfPublish_OdSignatureField_setFont__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4, bool jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setFont__SWIG_2___")]
	public static extern void OdPdfPublish_OdSignatureField_setFont__SWIG_2(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setFont__SWIG_3___")]
	public static extern void OdPdfPublish_OdSignatureField_setFont__SWIG_3(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setFont__SWIG_4___")]
	public static extern void OdPdfPublish_OdSignatureField_setFont__SWIG_4(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setFontSize___")]
	public static extern void OdPdfPublish_OdSignatureField_setFontSize(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setTextColor___")]
	public static extern void OdPdfPublish_OdSignatureField_setTextColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setTooltip___")]
	public static extern void OdPdfPublish_OdSignatureField_setTooltip(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setVisibility___")]
	public static extern void OdPdfPublish_OdSignatureField_setVisibility(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setPrintability___")]
	public static extern void OdPdfPublish_OdSignatureField_setPrintability(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setTextRotation___")]
	public static extern void OdPdfPublish_OdSignatureField_setTextRotation(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setLock___")]
	public static extern void OdPdfPublish_OdSignatureField_setLock(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setBorder___")]
	public static extern void OdPdfPublish_OdSignatureField_setBorder(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setBorderColor___")]
	public static extern void OdPdfPublish_OdSignatureField_setBorderColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setBorderThickness___")]
	public static extern void OdPdfPublish_OdSignatureField_setBorderThickness(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setBorderStyle___")]
	public static extern void OdPdfPublish_OdSignatureField_setBorderStyle(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_setFillColor___")]
	public static extern void OdPdfPublish_OdSignatureField_setFillColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getName___")]
	public static extern void OdPdfPublish_OdSignatureField_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getFont___")]
	public static extern void OdPdfPublish_OdSignatureField_getFont(HandleRef jarg1, out OdPdfPublish_Text_StorageType jarg2, out OdPdfPublish_Text_StandardFontsType jarg3, ref IntPtr jarg4, out OdPdfPublish_Text_FontStyle jarg5, out OdPdfPublish_Text_Language jarg6, out bool jarg7);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getFontSize___")]
	public static extern void OdPdfPublish_OdSignatureField_getFontSize(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getTextColor___")]
	public static extern void OdPdfPublish_OdSignatureField_getTextColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getTooltip___")]
	public static extern void OdPdfPublish_OdSignatureField_getTooltip(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getVisibility___")]
	public static extern void OdPdfPublish_OdSignatureField_getVisibility(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getPrintability___")]
	public static extern void OdPdfPublish_OdSignatureField_getPrintability(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getTextRotation___")]
	public static extern void OdPdfPublish_OdSignatureField_getTextRotation(HandleRef jarg1, out OdPdfPublish_Text_Rotation jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getLock___")]
	public static extern void OdPdfPublish_OdSignatureField_getLock(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getBorder___")]
	public static extern void OdPdfPublish_OdSignatureField_getBorder(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getBorderColor___")]
	public static extern void OdPdfPublish_OdSignatureField_getBorderColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getBorderThickness___")]
	public static extern void OdPdfPublish_OdSignatureField_getBorderThickness(HandleRef jarg1, out OdPdfPublish_Border_Thickness jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getBorderStyle___")]
	public static extern void OdPdfPublish_OdSignatureField_getBorderStyle(HandleRef jarg1, out OdPdfPublish_Border_Style jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getFillColor___")]
	public static extern void OdPdfPublish_OdSignatureField_getFillColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_getRealClassName___")]
	public static extern string OdPdfPublish_OdSignatureField_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_director_connect___")]
	public static extern void OdPdfPublish_OdSignatureField_director_connect(HandleRef jarg1, OdPdfPublish_OdSignatureField.SwigDelegateOdPdfPublish_OdSignatureField_0 delegate0, OdPdfPublish_OdSignatureField.SwigDelegateOdPdfPublish_OdSignatureField_1 delegate1, OdPdfPublish_OdSignatureField.SwigDelegateOdPdfPublish_OdSignatureField_2 delegate2, OdPdfPublish_OdSignatureField.SwigDelegateOdPdfPublish_OdSignatureField_3 delegate3, OdPdfPublish_OdSignatureField.SwigDelegateOdPdfPublish_OdSignatureField_4 delegate4, OdPdfPublish_OdSignatureField.SwigDelegateOdPdfPublish_OdSignatureField_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdAnnotation___")]
	public static extern IntPtr new_OdPdfPublish_OdAnnotation();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_cast___")]
	public static extern IntPtr OdPdfPublish_OdAnnotation_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_desc___")]
	public static extern IntPtr OdPdfPublish_OdAnnotation_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_isA___")]
	public static extern IntPtr OdPdfPublish_OdAnnotation_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_isASwigExplicitOdPdfPublish_OdAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdAnnotation_isASwigExplicitOdPdfPublish_OdAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_queryX___")]
	public static extern IntPtr OdPdfPublish_OdAnnotation_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_queryXSwigExplicitOdPdfPublish_OdAnnotation___")]
	public static extern IntPtr OdPdfPublish_OdAnnotation_queryXSwigExplicitOdPdfPublish_OdAnnotation(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_createObject___")]
	public static extern IntPtr OdPdfPublish_OdAnnotation_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdAnnotation___")]
	public static extern void delete_OdPdfPublish_OdAnnotation(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setSource___")]
	public static extern void OdPdfPublish_OdAnnotation_setSource(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setName___")]
	public static extern void OdPdfPublish_OdAnnotation_setName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setArtwork___")]
	public static extern void OdPdfPublish_OdAnnotation_setArtwork(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setToolbarVisibility___")]
	public static extern void OdPdfPublish_OdAnnotation_setToolbarVisibility(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setModelTreeVisibility___")]
	public static extern void OdPdfPublish_OdAnnotation_setModelTreeVisibility(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setInteractivity___")]
	public static extern void OdPdfPublish_OdAnnotation_setInteractivity(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setBorderWidth___")]
	public static extern void OdPdfPublish_OdAnnotation_setBorderWidth(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setTransparentBackground___")]
	public static extern void OdPdfPublish_OdAnnotation_setTransparentBackground(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setPosterImage___")]
	public static extern void OdPdfPublish_OdAnnotation_setPosterImage(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setActivation___")]
	public static extern void OdPdfPublish_OdAnnotation_setActivation(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setDeactivation___")]
	public static extern void OdPdfPublish_OdAnnotation_setDeactivation(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setCarouselButtons___")]
	public static extern void OdPdfPublish_OdAnnotation_setCarouselButtons(HandleRef jarg1, IntPtr jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3, [MarshalAs(UnmanagedType.LPWStr)] string jarg4, ushort jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setCarouselViews___")]
	public static extern void OdPdfPublish_OdAnnotation_setCarouselViews(HandleRef jarg1, IntPtr jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setCarouselScrollButtonsImages___")]
	public static extern void OdPdfPublish_OdAnnotation_setCarouselScrollButtonsImages(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setCarouselButtonsFillColor___")]
	public static extern void OdPdfPublish_OdAnnotation_setCarouselButtonsFillColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setCarouselButtonsOffset___")]
	public static extern void OdPdfPublish_OdAnnotation_setCarouselButtonsOffset(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_0___")]
	public static extern void OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4, bool jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_1___")]
	public static extern void OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, int jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_2___")]
	public static extern void OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_2(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_3___")]
	public static extern void OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_3(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_4___")]
	public static extern void OdPdfPublish_OdAnnotation_setCarouselButtonsFont__SWIG_4(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setCarouselButtonsFontSize___")]
	public static extern void OdPdfPublish_OdAnnotation_setCarouselButtonsFontSize(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setCarouselButtonsAlignment___")]
	public static extern void OdPdfPublish_OdAnnotation_setCarouselButtonsAlignment(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setViewListByField___")]
	public static extern void OdPdfPublish_OdAnnotation_setViewListByField(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setViewList___")]
	public static extern void OdPdfPublish_OdAnnotation_setViewList(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setPartsList__SWIG_0___")]
	public static extern void OdPdfPublish_OdAnnotation_setPartsList__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, IntPtr jarg4, IntPtr jarg5, HandleRef jarg6, HandleRef jarg7);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setPartsList__SWIG_1___")]
	public static extern void OdPdfPublish_OdAnnotation_setPartsList__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, IntPtr jarg4, IntPtr jarg5, HandleRef jarg6);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setPartsList__SWIG_2___")]
	public static extern void OdPdfPublish_OdAnnotation_setPartsList__SWIG_2(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, IntPtr jarg4, IntPtr jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setPropertyList___")]
	public static extern void OdPdfPublish_OdAnnotation_setPropertyList(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_setPropertyToTextField___")]
	public static extern void OdPdfPublish_OdAnnotation_setPropertyToTextField(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getSource___")]
	public static extern void OdPdfPublish_OdAnnotation_getSource(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getName___")]
	public static extern void OdPdfPublish_OdAnnotation_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getArtwork___")]
	public static extern void OdPdfPublish_OdAnnotation_getArtwork(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getToolbarVisibility___")]
	public static extern void OdPdfPublish_OdAnnotation_getToolbarVisibility(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getModelTreeVisibility___")]
	public static extern void OdPdfPublish_OdAnnotation_getModelTreeVisibility(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getInteractivity___")]
	public static extern void OdPdfPublish_OdAnnotation_getInteractivity(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getBorderWidth___")]
	public static extern void OdPdfPublish_OdAnnotation_getBorderWidth(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getTransparentBackground___")]
	public static extern void OdPdfPublish_OdAnnotation_getTransparentBackground(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getPosterImage___")]
	public static extern void OdPdfPublish_OdAnnotation_getPosterImage(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getActivation___")]
	public static extern void OdPdfPublish_OdAnnotation_getActivation(HandleRef jarg1, out OdPdfPublish_Activation_When jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getDeactivation___")]
	public static extern void OdPdfPublish_OdAnnotation_getDeactivation(HandleRef jarg1, out OdPdfPublish_Deactivation_When jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getCarouselButtons___")]
	public static extern void OdPdfPublish_OdAnnotation_getCarouselButtons(HandleRef jarg1, IntPtr jarg2, ref IntPtr jarg3, ref IntPtr jarg4, out ushort jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getCarouselViews___")]
	public static extern void OdPdfPublish_OdAnnotation_getCarouselViews(HandleRef jarg1, IntPtr jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getCarouselScrollButtonsImages___")]
	public static extern void OdPdfPublish_OdAnnotation_getCarouselScrollButtonsImages(HandleRef jarg1, ref IntPtr jarg2, ref IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getCarouselButtonsFillColor___")]
	public static extern void OdPdfPublish_OdAnnotation_getCarouselButtonsFillColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getCarouselButtonsOffset___")]
	public static extern void OdPdfPublish_OdAnnotation_getCarouselButtonsOffset(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getCarouselButtonsFont___")]
	public static extern void OdPdfPublish_OdAnnotation_getCarouselButtonsFont(HandleRef jarg1, out OdPdfPublish_Text_StorageType jarg2, out OdPdfPublish_Text_StandardFontsType jarg3, ref IntPtr jarg4, out OdPdfPublish_Text_FontStyle jarg5, out OdPdfPublish_Text_Language jarg6, out bool jarg7);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getCarouselButtonsFontSize___")]
	public static extern void OdPdfPublish_OdAnnotation_getCarouselButtonsFontSize(HandleRef jarg1, out ushort jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getCarouselButtonsAlignment___")]
	public static extern void OdPdfPublish_OdAnnotation_getCarouselButtonsAlignment(HandleRef jarg1, out OdPdfPublish_CarouselButtons_Alignment jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getViewListField___")]
	public static extern void OdPdfPublish_OdAnnotation_getViewListField(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getViewList___")]
	public static extern void OdPdfPublish_OdAnnotation_getViewList(HandleRef jarg1, HandleRef jarg2, ref IntPtr jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getPartsList___")]
	public static extern void OdPdfPublish_OdAnnotation_getPartsList(HandleRef jarg1, IntPtr jarg2, HandleRef jarg3, IntPtr jarg4, IntPtr jarg5, ref IntPtr jarg6, ref IntPtr jarg7);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getPropertyList___")]
	public static extern void OdPdfPublish_OdAnnotation_getPropertyList(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getPropertyToTextField___")]
	public static extern void OdPdfPublish_OdAnnotation_getPropertyToTextField(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_getRealClassName___")]
	public static extern string OdPdfPublish_OdAnnotation_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_director_connect___")]
	public static extern void OdPdfPublish_OdAnnotation_director_connect(HandleRef jarg1, OdPdfPublish_OdAnnotation.SwigDelegateOdPdfPublish_OdAnnotation_0 delegate0, OdPdfPublish_OdAnnotation.SwigDelegateOdPdfPublish_OdAnnotation_1 delegate1, OdPdfPublish_OdAnnotation.SwigDelegateOdPdfPublish_OdAnnotation_2 delegate2, OdPdfPublish_OdAnnotation.SwigDelegateOdPdfPublish_OdAnnotation_3 delegate3, OdPdfPublish_OdAnnotation.SwigDelegateOdPdfPublish_OdAnnotation_4 delegate4, OdPdfPublish_OdAnnotation.SwigDelegateOdPdfPublish_OdAnnotation_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdCollectionColumn___")]
	public static extern IntPtr new_OdPdfPublish_OdCollectionColumn();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_cast___")]
	public static extern IntPtr OdPdfPublish_OdCollectionColumn_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_desc___")]
	public static extern IntPtr OdPdfPublish_OdCollectionColumn_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_isA___")]
	public static extern IntPtr OdPdfPublish_OdCollectionColumn_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_isASwigExplicitOdPdfPublish_OdCollectionColumn___")]
	public static extern IntPtr OdPdfPublish_OdCollectionColumn_isASwigExplicitOdPdfPublish_OdCollectionColumn(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_queryX___")]
	public static extern IntPtr OdPdfPublish_OdCollectionColumn_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_queryXSwigExplicitOdPdfPublish_OdCollectionColumn___")]
	public static extern IntPtr OdPdfPublish_OdCollectionColumn_queryXSwigExplicitOdPdfPublish_OdCollectionColumn(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_createObject___")]
	public static extern IntPtr OdPdfPublish_OdCollectionColumn_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCollectionColumn___")]
	public static extern void delete_OdPdfPublish_OdCollectionColumn(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_setName___")]
	public static extern void OdPdfPublish_OdCollectionColumn_setName(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_setCaption___")]
	public static extern void OdPdfPublish_OdCollectionColumn_setCaption(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_setColumnType___")]
	public static extern void OdPdfPublish_OdCollectionColumn_setColumnType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_setVisibleOnStart___")]
	public static extern void OdPdfPublish_OdCollectionColumn_setVisibleOnStart(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_setEnableEdit___")]
	public static extern void OdPdfPublish_OdCollectionColumn_setEnableEdit(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_setSortOrder___")]
	public static extern void OdPdfPublish_OdCollectionColumn_setSortOrder(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_getName___")]
	public static extern void OdPdfPublish_OdCollectionColumn_getName(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_getCaption___")]
	public static extern void OdPdfPublish_OdCollectionColumn_getCaption(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_getColumnType___")]
	public static extern void OdPdfPublish_OdCollectionColumn_getColumnType(HandleRef jarg1, out OdPdfPublish_CollectionSchema_ColumnType jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_getVisibleOnStart___")]
	public static extern void OdPdfPublish_OdCollectionColumn_getVisibleOnStart(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_getEnableEdit___")]
	public static extern void OdPdfPublish_OdCollectionColumn_getEnableEdit(HandleRef jarg1, out bool jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_getSortOrder___")]
	public static extern void OdPdfPublish_OdCollectionColumn_getSortOrder(HandleRef jarg1, out OdPdfPublish_CollectionSchema_SortOrder jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_getRealClassName___")]
	public static extern string OdPdfPublish_OdCollectionColumn_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_director_connect___")]
	public static extern void OdPdfPublish_OdCollectionColumn_director_connect(HandleRef jarg1, OdPdfPublish_OdCollectionColumn.SwigDelegateOdPdfPublish_OdCollectionColumn_0 delegate0, OdPdfPublish_OdCollectionColumn.SwigDelegateOdPdfPublish_OdCollectionColumn_1 delegate1, OdPdfPublish_OdCollectionColumn.SwigDelegateOdPdfPublish_OdCollectionColumn_2 delegate2, OdPdfPublish_OdCollectionColumn.SwigDelegateOdPdfPublish_OdCollectionColumn_3 delegate3, OdPdfPublish_OdCollectionColumn.SwigDelegateOdPdfPublish_OdCollectionColumn_4 delegate4, OdPdfPublish_OdCollectionColumn.SwigDelegateOdPdfPublish_OdCollectionColumn_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdPage___")]
	public static extern IntPtr new_OdPdfPublish_OdPage();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_cast___")]
	public static extern IntPtr OdPdfPublish_OdPage_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_desc___")]
	public static extern IntPtr OdPdfPublish_OdPage_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_isA___")]
	public static extern IntPtr OdPdfPublish_OdPage_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_isASwigExplicitOdPdfPublish_OdPage___")]
	public static extern IntPtr OdPdfPublish_OdPage_isASwigExplicitOdPdfPublish_OdPage(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_queryX___")]
	public static extern IntPtr OdPdfPublish_OdPage_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_queryXSwigExplicitOdPdfPublish_OdPage___")]
	public static extern IntPtr OdPdfPublish_OdPage_queryXSwigExplicitOdPdfPublish_OdPage(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_createObject___")]
	public static extern IntPtr OdPdfPublish_OdPage_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdPage___")]
	public static extern void delete_OdPdfPublish_OdPage(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_setFormat___")]
	public static extern void OdPdfPublish_OdPage_setFormat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_setOrientation___")]
	public static extern void OdPdfPublish_OdPage_setOrientation(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_setPaperSize___")]
	public static extern void OdPdfPublish_OdPage_setPaperSize(HandleRef jarg1, int jarg2, double jarg3, double jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addAnnotation___")]
	public static extern void OdPdfPublish_OdPage_addAnnotation(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addText__SWIG_0___")]
	public static extern void OdPdfPublish_OdPage_addText__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, double jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addText__SWIG_1___")]
	public static extern void OdPdfPublish_OdPage_addText__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addImage__SWIG_0___")]
	public static extern void OdPdfPublish_OdPage_addImage__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, double jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addImage__SWIG_1___")]
	public static extern void OdPdfPublish_OdPage_addImage__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addTable___")]
	public static extern void OdPdfPublish_OdPage_addTable(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addLink___")]
	public static extern void OdPdfPublish_OdPage_addLink(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addButton___")]
	public static extern void OdPdfPublish_OdPage_addButton(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addTextField___")]
	public static extern void OdPdfPublish_OdPage_addTextField(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addSlideTable___")]
	public static extern void OdPdfPublish_OdPage_addSlideTable(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addCheckBox___")]
	public static extern void OdPdfPublish_OdPage_addCheckBox(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addRadioButton___")]
	public static extern void OdPdfPublish_OdPage_addRadioButton(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addListBox___")]
	public static extern void OdPdfPublish_OdPage_addListBox(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addDropDownList___")]
	public static extern void OdPdfPublish_OdPage_addDropDownList(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addSignatureField___")]
	public static extern void OdPdfPublish_OdPage_addSignatureField(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_add2dGeometry__SWIG_0___")]
	public static extern void OdPdfPublish_OdPage_add2dGeometry__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_add2dGeometry__SWIG_1___")]
	public static extern void OdPdfPublish_OdPage_add2dGeometry__SWIG_1(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addCADReference__SWIG_0___")]
	public static extern void OdPdfPublish_OdPage_addCADReference__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addCADReference__SWIG_1___")]
	public static extern void OdPdfPublish_OdPage_addCADReference__SWIG_1(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addStickyNote___")]
	public static extern void OdPdfPublish_OdPage_addStickyNote(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addStampAnnotation___")]
	public static extern void OdPdfPublish_OdPage_addStampAnnotation(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addInkAnnotation___")]
	public static extern void OdPdfPublish_OdPage_addInkAnnotation(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addLineAnnotation___")]
	public static extern void OdPdfPublish_OdPage_addLineAnnotation(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addCircleAnnotation___")]
	public static extern void OdPdfPublish_OdPage_addCircleAnnotation(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addSquareAnnotation___")]
	public static extern void OdPdfPublish_OdPage_addSquareAnnotation(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addPolylineAnnotation___")]
	public static extern void OdPdfPublish_OdPage_addPolylineAnnotation(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addPolygonAnnotation___")]
	public static extern void OdPdfPublish_OdPage_addPolygonAnnotation(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addWatermark___")]
	public static extern void OdPdfPublish_OdPage_addWatermark(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addJavaScriptActionByField__SWIG_0___")]
	public static extern void OdPdfPublish_OdPage_addJavaScriptActionByField__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3, int jarg4, int jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_addJavaScriptActionByField__SWIG_1___")]
	public static extern void OdPdfPublish_OdPage_addJavaScriptActionByField__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3, int jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getFormat___")]
	public static extern void OdPdfPublish_OdPage_getFormat(HandleRef jarg1, out OdPdfPublish_Page_Format jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getOrientation___")]
	public static extern void OdPdfPublish_OdPage_getOrientation(HandleRef jarg1, out OdPdfPublish_Page_Orientation jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getPaperSize___")]
	public static extern void OdPdfPublish_OdPage_getPaperSize(HandleRef jarg1, int jarg2, out double jarg3, out double jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getAnnotations___")]
	public static extern void OdPdfPublish_OdPage_getAnnotations(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getTexts___")]
	public static extern void OdPdfPublish_OdPage_getTexts(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, IntPtr jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getImages___")]
	public static extern void OdPdfPublish_OdPage_getImages(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, IntPtr jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getTables___")]
	public static extern void OdPdfPublish_OdPage_getTables(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getLinks___")]
	public static extern void OdPdfPublish_OdPage_getLinks(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getButtons___")]
	public static extern void OdPdfPublish_OdPage_getButtons(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getCheckBoxes___")]
	public static extern void OdPdfPublish_OdPage_getCheckBoxes(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getRadioButtons___")]
	public static extern void OdPdfPublish_OdPage_getRadioButtons(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getListBoxes___")]
	public static extern void OdPdfPublish_OdPage_getListBoxes(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getDropDownLists___")]
	public static extern void OdPdfPublish_OdPage_getDropDownLists(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getSignatureFields___")]
	public static extern void OdPdfPublish_OdPage_getSignatureFields(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getTextFields___")]
	public static extern void OdPdfPublish_OdPage_getTextFields(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getSlideTables___")]
	public static extern void OdPdfPublish_OdPage_getSlideTables(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getJavaScriptActionsByField___")]
	public static extern void OdPdfPublish_OdPage_getJavaScriptActionsByField(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, IntPtr jarg3, HandleRef jarg4, HandleRef jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_get2dGeoms___")]
	public static extern void OdPdfPublish_OdPage_get2dGeoms(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getCADReferences___")]
	public static extern void OdPdfPublish_OdPage_getCADReferences(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getStickyNotes___")]
	public static extern void OdPdfPublish_OdPage_getStickyNotes(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getWatermarks___")]
	public static extern void OdPdfPublish_OdPage_getWatermarks(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getStampAnnotations___")]
	public static extern void OdPdfPublish_OdPage_getStampAnnotations(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getInkAnnotations___")]
	public static extern void OdPdfPublish_OdPage_getInkAnnotations(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getLineAnnotations___")]
	public static extern void OdPdfPublish_OdPage_getLineAnnotations(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getCircleAnnotations___")]
	public static extern void OdPdfPublish_OdPage_getCircleAnnotations(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getSquareAnnotations___")]
	public static extern void OdPdfPublish_OdPage_getSquareAnnotations(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getPolylineAnnotations___")]
	public static extern void OdPdfPublish_OdPage_getPolylineAnnotations(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getPolygonAnnotations___")]
	public static extern void OdPdfPublish_OdPage_getPolygonAnnotations(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_getRealClassName___")]
	public static extern string OdPdfPublish_OdPage_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_director_connect___")]
	public static extern void OdPdfPublish_OdPage_director_connect(HandleRef jarg1, OdPdfPublish_OdPage.SwigDelegateOdPdfPublish_OdPage_0 delegate0, OdPdfPublish_OdPage.SwigDelegateOdPdfPublish_OdPage_1 delegate1, OdPdfPublish_OdPage.SwigDelegateOdPdfPublish_OdPage_2 delegate2, OdPdfPublish_OdPage.SwigDelegateOdPdfPublish_OdPage_3 delegate3, OdPdfPublish_OdPage.SwigDelegateOdPdfPublish_OdPage_4 delegate4, OdPdfPublish_OdPage.SwigDelegateOdPdfPublish_OdPage_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdCollection___")]
	public static extern IntPtr new_OdPdfPublish_OdCollection();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_cast___")]
	public static extern IntPtr OdPdfPublish_OdCollection_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_desc___")]
	public static extern IntPtr OdPdfPublish_OdCollection_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_isA___")]
	public static extern IntPtr OdPdfPublish_OdCollection_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_isASwigExplicitOdPdfPublish_OdCollection___")]
	public static extern IntPtr OdPdfPublish_OdCollection_isASwigExplicitOdPdfPublish_OdCollection(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_queryX___")]
	public static extern IntPtr OdPdfPublish_OdCollection_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_queryXSwigExplicitOdPdfPublish_OdCollection___")]
	public static extern IntPtr OdPdfPublish_OdCollection_queryXSwigExplicitOdPdfPublish_OdCollection(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_createObject___")]
	public static extern IntPtr OdPdfPublish_OdCollection_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCollection___")]
	public static extern void delete_OdPdfPublish_OdCollection(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_addColumn___")]
	public static extern void OdPdfPublish_OdCollection_addColumn(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_setColumns___")]
	public static extern void OdPdfPublish_OdCollection_setColumns(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_setInitialFile___")]
	public static extern void OdPdfPublish_OdCollection_setInitialFile(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_setInitalViewType___")]
	public static extern void OdPdfPublish_OdCollection_setInitalViewType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_setBackgroundColor___")]
	public static extern void OdPdfPublish_OdCollection_setBackgroundColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_setCardBackgroundColor___")]
	public static extern void OdPdfPublish_OdCollection_setCardBackgroundColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_setCardBorderColor___")]
	public static extern void OdPdfPublish_OdCollection_setCardBorderColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_setPrimaryTextColor___")]
	public static extern void OdPdfPublish_OdCollection_setPrimaryTextColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_setSecondaryTextColor___")]
	public static extern void OdPdfPublish_OdCollection_setSecondaryTextColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_setRootFolder___")]
	public static extern void OdPdfPublish_OdCollection_setRootFolder(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_getColumns___")]
	public static extern void OdPdfPublish_OdCollection_getColumns(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_getInitialFile___")]
	public static extern void OdPdfPublish_OdCollection_getInitialFile(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_getInitalViewType___")]
	public static extern void OdPdfPublish_OdCollection_getInitalViewType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_getBackgroundColor___")]
	public static extern void OdPdfPublish_OdCollection_getBackgroundColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_getCardBackgroundColor___")]
	public static extern void OdPdfPublish_OdCollection_getCardBackgroundColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_getCardBorderColor___")]
	public static extern void OdPdfPublish_OdCollection_getCardBorderColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_getPrimaryTextColor___")]
	public static extern void OdPdfPublish_OdCollection_getPrimaryTextColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_getSecondaryTextColor___")]
	public static extern void OdPdfPublish_OdCollection_getSecondaryTextColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_getRootFolder___")]
	public static extern void OdPdfPublish_OdCollection_getRootFolder(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_getRealClassName___")]
	public static extern string OdPdfPublish_OdCollection_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_director_connect___")]
	public static extern void OdPdfPublish_OdCollection_director_connect(HandleRef jarg1, OdPdfPublish_OdCollection.SwigDelegateOdPdfPublish_OdCollection_0 delegate0, OdPdfPublish_OdCollection.SwigDelegateOdPdfPublish_OdCollection_1 delegate1, OdPdfPublish_OdCollection.SwigDelegateOdPdfPublish_OdCollection_2 delegate2, OdPdfPublish_OdCollection.SwigDelegateOdPdfPublish_OdCollection_3 delegate3, OdPdfPublish_OdCollection.SwigDelegateOdPdfPublish_OdCollection_4 delegate4, OdPdfPublish_OdCollection.SwigDelegateOdPdfPublish_OdCollection_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdBookmark___")]
	public static extern IntPtr new_OdPdfPublish_OdBookmark();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_cast___")]
	public static extern IntPtr OdPdfPublish_OdBookmark_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_desc___")]
	public static extern IntPtr OdPdfPublish_OdBookmark_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_isA___")]
	public static extern IntPtr OdPdfPublish_OdBookmark_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_isASwigExplicitOdPdfPublish_OdBookmark___")]
	public static extern IntPtr OdPdfPublish_OdBookmark_isASwigExplicitOdPdfPublish_OdBookmark(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_queryX___")]
	public static extern IntPtr OdPdfPublish_OdBookmark_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_queryXSwigExplicitOdPdfPublish_OdBookmark___")]
	public static extern IntPtr OdPdfPublish_OdBookmark_queryXSwigExplicitOdPdfPublish_OdBookmark(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_createObject___")]
	public static extern IntPtr OdPdfPublish_OdBookmark_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdBookmark___")]
	public static extern void delete_OdPdfPublish_OdBookmark(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_setTitle___")]
	public static extern void OdPdfPublish_OdBookmark_setTitle(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_setPage___")]
	public static extern void OdPdfPublish_OdBookmark_setPage(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_setBookmarkType___")]
	public static extern void OdPdfPublish_OdBookmark_setBookmarkType(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_setTextStyle___")]
	public static extern void OdPdfPublish_OdBookmark_setTextStyle(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_setTextColor___")]
	public static extern void OdPdfPublish_OdBookmark_setTextColor(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_appendChild___")]
	public static extern void OdPdfPublish_OdBookmark_appendChild(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_setChildren___")]
	public static extern void OdPdfPublish_OdBookmark_setChildren(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_setParametrs___")]
	public static extern void OdPdfPublish_OdBookmark_setParametrs(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_getTitle___")]
	public static extern void OdPdfPublish_OdBookmark_getTitle(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_getPage___")]
	public static extern void OdPdfPublish_OdBookmark_getPage(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_getBookmarkType___")]
	public static extern void OdPdfPublish_OdBookmark_getBookmarkType(HandleRef jarg1, out OdPdfPublish_Bookmarks_BookmarkType jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_getTextStyle___")]
	public static extern void OdPdfPublish_OdBookmark_getTextStyle(HandleRef jarg1, out OdPdfPublish_Text_FontStyle jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_getTextColor___")]
	public static extern void OdPdfPublish_OdBookmark_getTextColor(HandleRef jarg1, out uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_getChildren___")]
	public static extern void OdPdfPublish_OdBookmark_getChildren(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_getParametrs___")]
	public static extern void OdPdfPublish_OdBookmark_getParametrs(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_getRealClassName___")]
	public static extern string OdPdfPublish_OdBookmark_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_director_connect___")]
	public static extern void OdPdfPublish_OdBookmark_director_connect(HandleRef jarg1, OdPdfPublish_OdBookmark.SwigDelegateOdPdfPublish_OdBookmark_0 delegate0, OdPdfPublish_OdBookmark.SwigDelegateOdPdfPublish_OdBookmark_1 delegate1, OdPdfPublish_OdBookmark.SwigDelegateOdPdfPublish_OdBookmark_2 delegate2, OdPdfPublish_OdBookmark.SwigDelegateOdPdfPublish_OdBookmark_3 delegate3, OdPdfPublish_OdBookmark.SwigDelegateOdPdfPublish_OdBookmark_4 delegate4, OdPdfPublish_OdBookmark.SwigDelegateOdPdfPublish_OdBookmark_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdDocument___")]
	public static extern IntPtr new_OdPdfPublish_OdDocument();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_cast___")]
	public static extern IntPtr OdPdfPublish_OdDocument_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_desc___")]
	public static extern IntPtr OdPdfPublish_OdDocument_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_isA___")]
	public static extern IntPtr OdPdfPublish_OdDocument_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_isASwigExplicitOdPdfPublish_OdDocument___")]
	public static extern IntPtr OdPdfPublish_OdDocument_isASwigExplicitOdPdfPublish_OdDocument(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_queryX___")]
	public static extern IntPtr OdPdfPublish_OdDocument_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_queryXSwigExplicitOdPdfPublish_OdDocument___")]
	public static extern IntPtr OdPdfPublish_OdDocument_queryXSwigExplicitOdPdfPublish_OdDocument(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_createObject___")]
	public static extern IntPtr OdPdfPublish_OdDocument_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdDocument___")]
	public static extern void delete_OdPdfPublish_OdDocument(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_setVersion___")]
	public static extern void OdPdfPublish_OdDocument_setVersion(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_setInformation___")]
	public static extern void OdPdfPublish_OdDocument_setInformation(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3, [MarshalAs(UnmanagedType.LPWStr)] string jarg4, [MarshalAs(UnmanagedType.LPWStr)] string jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_addJavaScript__SWIG_0___")]
	public static extern void OdPdfPublish_OdDocument_addJavaScript__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3, int jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_addJavaScript__SWIG_1___")]
	public static extern void OdPdfPublish_OdDocument_addJavaScript__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_addIconImage___")]
	public static extern void OdPdfPublish_OdDocument_addIconImage(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_addPage___")]
	public static extern void OdPdfPublish_OdDocument_addPage(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_addAttachment___")]
	public static extern void OdPdfPublish_OdDocument_addAttachment(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_setCollection___")]
	public static extern void OdPdfPublish_OdDocument_setCollection(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_setUserPassword___")]
	public static extern void OdPdfPublish_OdDocument_setUserPassword(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_setOwnerPassword___")]
	public static extern void OdPdfPublish_OdDocument_setOwnerPassword(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_setAccessPermissionFlags___")]
	public static extern void OdPdfPublish_OdDocument_setAccessPermissionFlags(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_appendRootBookmark___")]
	public static extern void OdPdfPublish_OdDocument_appendRootBookmark(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_setRootBookmarks___")]
	public static extern void OdPdfPublish_OdDocument_setRootBookmarks(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_getVersion___")]
	public static extern void OdPdfPublish_OdDocument_getVersion(HandleRef jarg1, out OdPDF_PDFFormatVersions jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_getInformation___")]
	public static extern void OdPdfPublish_OdDocument_getInformation(HandleRef jarg1, ref IntPtr jarg2, ref IntPtr jarg3, ref IntPtr jarg4, ref IntPtr jarg5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_getJavaScripts___")]
	public static extern void OdPdfPublish_OdDocument_getJavaScripts(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3, HandleRef jarg4);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_getIconImages___")]
	public static extern void OdPdfPublish_OdDocument_getIconImages(HandleRef jarg1, IntPtr jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_getPages___")]
	public static extern void OdPdfPublish_OdDocument_getPages(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_getAttachments___")]
	public static extern void OdPdfPublish_OdDocument_getAttachments(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_getCollection___")]
	public static extern void OdPdfPublish_OdDocument_getCollection(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_getUserPassword___")]
	public static extern void OdPdfPublish_OdDocument_getUserPassword(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_getOwnerPassword___")]
	public static extern void OdPdfPublish_OdDocument_getOwnerPassword(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_getAccessPermissionFlags___")]
	public static extern int OdPdfPublish_OdDocument_getAccessPermissionFlags(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_getRootBookmarks___")]
	public static extern void OdPdfPublish_OdDocument_getRootBookmarks(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_setHostServices___")]
	public static extern void OdPdfPublish_OdDocument_setHostServices(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_appServices___")]
	public static extern IntPtr OdPdfPublish_OdDocument_appServices(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_getRealClassName___")]
	public static extern string OdPdfPublish_OdDocument_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_director_connect___")]
	public static extern void OdPdfPublish_OdDocument_director_connect(HandleRef jarg1, OdPdfPublish_OdDocument.SwigDelegateOdPdfPublish_OdDocument_0 delegate0, OdPdfPublish_OdDocument.SwigDelegateOdPdfPublish_OdDocument_1 delegate1, OdPdfPublish_OdDocument.SwigDelegateOdPdfPublish_OdDocument_2 delegate2, OdPdfPublish_OdDocument.SwigDelegateOdPdfPublish_OdDocument_3 delegate3, OdPdfPublish_OdDocument.SwigDelegateOdPdfPublish_OdDocument_4 delegate4, OdPdfPublish_OdDocument.SwigDelegateOdPdfPublish_OdDocument_5 delegate5);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFile_cast___")]
	public static extern IntPtr OdPdfPublish_OdFile_cast(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFile_desc___")]
	public static extern IntPtr OdPdfPublish_OdFile_desc();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFile_isA___")]
	public static extern IntPtr OdPdfPublish_OdFile_isA(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFile_isASwigExplicitOdPdfPublish_OdFile___")]
	public static extern IntPtr OdPdfPublish_OdFile_isASwigExplicitOdPdfPublish_OdFile(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFile_queryX___")]
	public static extern IntPtr OdPdfPublish_OdFile_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFile_queryXSwigExplicitOdPdfPublish_OdFile___")]
	public static extern IntPtr OdPdfPublish_OdFile_queryXSwigExplicitOdPdfPublish_OdFile(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_new_OdPdfPublish_OdFile___")]
	public static extern IntPtr new_OdPdfPublish_OdFile();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdFile___")]
	public static extern void delete_OdPdfPublish_OdFile(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFile_getRealClassName___")]
	public static extern string OdPdfPublish_OdFile_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFile_createObject___")]
	public static extern IntPtr OdPdfPublish_OdFile_createObject();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFile_exportPdf__SWIG_0___")]
	public static extern uint OdPdfPublish_OdFile_exportPdf__SWIG_0(HandleRef jarg1, HandleRef jarg2, [MarshalAs(UnmanagedType.LPWStr)] string jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFile_exportPdf__SWIG_1___")]
	public static extern uint OdPdfPublish_OdFile_exportPdf__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFile_director_connect___")]
	public static extern void OdPdfPublish_OdFile_director_connect(HandleRef jarg1, OdPdfPublish_OdFile.SwigDelegateOdPdfPublish_OdFile_0 delegate0, OdPdfPublish_OdFile.SwigDelegateOdPdfPublish_OdFile_1 delegate1, OdPdfPublish_OdFile.SwigDelegateOdPdfPublish_OdFile_2 delegate2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdRectArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdRectArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdRectArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdRectArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdRectArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdRectArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_size___")]
	public static extern uint OdPdfPublish_OdRectArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_capacity___")]
	public static extern uint OdPdfPublish_OdRectArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_reserve___")]
	public static extern void OdPdfPublish_OdRectArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_resize___")]
	public static extern void OdPdfPublish_OdRectArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_Clear___")]
	public static extern void OdPdfPublish_OdRectArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_Add___")]
	public static extern void OdPdfPublish_OdRectArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdRectArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdRectArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_setitem___")]
	public static extern void OdPdfPublish_OdRectArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_AddRange___")]
	public static extern void OdPdfPublish_OdRectArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdRectArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_Insert___")]
	public static extern void OdPdfPublish_OdRectArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_InsertRange___")]
	public static extern void OdPdfPublish_OdRectArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdRectArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdRectArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdRectArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdRectArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdRectArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_SetRange___")]
	public static extern void OdPdfPublish_OdRectArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_Contains___")]
	public static extern bool OdPdfPublish_OdRectArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_IndexOf___")]
	public static extern int OdPdfPublish_OdRectArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdRectArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRectArray_Remove___")]
	public static extern bool OdPdfPublish_OdRectArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdRectArray___")]
	public static extern void delete_OdPdfPublish_OdRectArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_OdTimeStamp_OdObjectsAllocator__SWIG_0")]
	public static extern IntPtr new_OdArray_OdTimeStamp_OdObjectsAllocator__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_OdTimeStamp_OdObjectsAllocator__SWIG_1")]
	public static extern IntPtr new_OdArray_OdTimeStamp_OdObjectsAllocator__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdArray_OdTimeStamp_OdObjectsAllocator__SWIG_2")]
	public static extern IntPtr new_OdArray_OdTimeStamp_OdObjectsAllocator__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_size___")]
	public static extern uint OdArray_OdTimeStamp_OdObjectsAllocator_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_capacity___")]
	public static extern uint OdArray_OdTimeStamp_OdObjectsAllocator_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_reserve___")]
	public static extern void OdArray_OdTimeStamp_OdObjectsAllocator_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_resize___")]
	public static extern void OdArray_OdTimeStamp_OdObjectsAllocator_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_Clear___")]
	public static extern void OdArray_OdTimeStamp_OdObjectsAllocator_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_Add___")]
	public static extern void OdArray_OdTimeStamp_OdObjectsAllocator_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_getitemcopy___")]
	public static extern IntPtr OdArray_OdTimeStamp_OdObjectsAllocator_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_getitem___")]
	public static extern IntPtr OdArray_OdTimeStamp_OdObjectsAllocator_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_setitem___")]
	public static extern void OdArray_OdTimeStamp_OdObjectsAllocator_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_AddRange___")]
	public static extern void OdArray_OdTimeStamp_OdObjectsAllocator_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_GetRange___")]
	public static extern IntPtr OdArray_OdTimeStamp_OdObjectsAllocator_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_Insert___")]
	public static extern void OdArray_OdTimeStamp_OdObjectsAllocator_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_InsertRange___")]
	public static extern void OdArray_OdTimeStamp_OdObjectsAllocator_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_RemoveAt___")]
	public static extern void OdArray_OdTimeStamp_OdObjectsAllocator_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_RemoveRange___")]
	public static extern void OdArray_OdTimeStamp_OdObjectsAllocator_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_Repeat___")]
	public static extern IntPtr OdArray_OdTimeStamp_OdObjectsAllocator_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_Reverse__SWIG_0___")]
	public static extern void OdArray_OdTimeStamp_OdObjectsAllocator_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_Reverse__SWIG_1___")]
	public static extern void OdArray_OdTimeStamp_OdObjectsAllocator_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_SetRange___")]
	public static extern void OdArray_OdTimeStamp_OdObjectsAllocator_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_Contains___")]
	public static extern bool OdArray_OdTimeStamp_OdObjectsAllocator_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_IndexOf___")]
	public static extern int OdArray_OdTimeStamp_OdObjectsAllocator_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_LastIndexOf___")]
	public static extern int OdArray_OdTimeStamp_OdObjectsAllocator_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdArray_OdTimeStamp_OdObjectsAllocator_Remove___")]
	public static extern bool OdArray_OdTimeStamp_OdObjectsAllocator_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdArray_OdTimeStamp_OdObjectsAllocator___")]
	public static extern void delete_OdArray_OdTimeStamp_OdObjectsAllocator(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdActionTypeArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdActionTypeArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdActionTypeArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdActionTypeArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdActionTypeArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdActionTypeArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_size___")]
	public static extern uint OdPdfPublish_OdActionTypeArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_capacity___")]
	public static extern uint OdPdfPublish_OdActionTypeArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_reserve___")]
	public static extern void OdPdfPublish_OdActionTypeArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_resize___")]
	public static extern void OdPdfPublish_OdActionTypeArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_Clear___")]
	public static extern void OdPdfPublish_OdActionTypeArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_Add___")]
	public static extern void OdPdfPublish_OdActionTypeArray_Add(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_getitemcopy___")]
	public static extern int OdPdfPublish_OdActionTypeArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_getitem___")]
	public static extern int OdPdfPublish_OdActionTypeArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_setitem___")]
	public static extern void OdPdfPublish_OdActionTypeArray_setitem(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_AddRange___")]
	public static extern void OdPdfPublish_OdActionTypeArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdActionTypeArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_Insert___")]
	public static extern void OdPdfPublish_OdActionTypeArray_Insert(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_InsertRange___")]
	public static extern void OdPdfPublish_OdActionTypeArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdActionTypeArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdActionTypeArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdActionTypeArray_Repeat(int jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdActionTypeArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdActionTypeArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_SetRange___")]
	public static extern void OdPdfPublish_OdActionTypeArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_Contains___")]
	public static extern bool OdPdfPublish_OdActionTypeArray_Contains(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_IndexOf___")]
	public static extern int OdPdfPublish_OdActionTypeArray_IndexOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdActionTypeArray_LastIndexOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdActionTypeArray_Remove___")]
	public static extern bool OdPdfPublish_OdActionTypeArray_Remove(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdActionTypeArray___")]
	public static extern void delete_OdPdfPublish_OdActionTypeArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdSourceTypeArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdSourceTypeArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdSourceTypeArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdSourceTypeArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdSourceTypeArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdSourceTypeArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_size___")]
	public static extern uint OdPdfPublish_OdSourceTypeArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_capacity___")]
	public static extern uint OdPdfPublish_OdSourceTypeArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_reserve___")]
	public static extern void OdPdfPublish_OdSourceTypeArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_resize___")]
	public static extern void OdPdfPublish_OdSourceTypeArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_Clear___")]
	public static extern void OdPdfPublish_OdSourceTypeArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_Add___")]
	public static extern void OdPdfPublish_OdSourceTypeArray_Add(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_getitemcopy___")]
	public static extern int OdPdfPublish_OdSourceTypeArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_getitem___")]
	public static extern int OdPdfPublish_OdSourceTypeArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_setitem___")]
	public static extern void OdPdfPublish_OdSourceTypeArray_setitem(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_AddRange___")]
	public static extern void OdPdfPublish_OdSourceTypeArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdSourceTypeArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_Insert___")]
	public static extern void OdPdfPublish_OdSourceTypeArray_Insert(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_InsertRange___")]
	public static extern void OdPdfPublish_OdSourceTypeArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdSourceTypeArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdSourceTypeArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdSourceTypeArray_Repeat(int jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdSourceTypeArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdSourceTypeArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_SetRange___")]
	public static extern void OdPdfPublish_OdSourceTypeArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_Contains___")]
	public static extern bool OdPdfPublish_OdSourceTypeArray_Contains(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_IndexOf___")]
	public static extern int OdPdfPublish_OdSourceTypeArray_IndexOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdSourceTypeArray_LastIndexOf(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSourceTypeArray_Remove___")]
	public static extern bool OdPdfPublish_OdSourceTypeArray_Remove(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdSourceTypeArray___")]
	public static extern void delete_OdPdfPublish_OdSourceTypeArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdLinkPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdLinkPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdLinkPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdLinkPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdLinkPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdLinkPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_size___")]
	public static extern uint OdPdfPublish_OdLinkPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdLinkPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdLinkPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_resize___")]
	public static extern void OdPdfPublish_OdLinkPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdLinkPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_Add___")]
	public static extern void OdPdfPublish_OdLinkPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdLinkPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdLinkPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdLinkPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdLinkPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdLinkPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdLinkPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdLinkPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdLinkPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdLinkPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdLinkPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdLinkPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdLinkPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdLinkPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdLinkPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdLinkPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdLinkPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLinkPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdLinkPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdLinkPtrArray___")]
	public static extern void delete_OdPdfPublish_OdLinkPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdPagePtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdPagePtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdPagePtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdPagePtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdPagePtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdPagePtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_size___")]
	public static extern uint OdPdfPublish_OdPagePtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdPagePtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_reserve___")]
	public static extern void OdPdfPublish_OdPagePtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_resize___")]
	public static extern void OdPdfPublish_OdPagePtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_Clear___")]
	public static extern void OdPdfPublish_OdPagePtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_Add___")]
	public static extern void OdPdfPublish_OdPagePtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdPagePtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdPagePtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_setitem___")]
	public static extern void OdPdfPublish_OdPagePtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdPagePtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdPagePtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_Insert___")]
	public static extern void OdPdfPublish_OdPagePtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdPagePtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdPagePtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdPagePtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdPagePtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdPagePtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdPagePtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdPagePtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdPagePtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdPagePtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdPagePtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPagePtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdPagePtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdPagePtrArray___")]
	public static extern void delete_OdPdfPublish_OdPagePtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdViewPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdViewPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdViewPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdViewPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdViewPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdViewPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_size___")]
	public static extern uint OdPdfPublish_OdViewPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdViewPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdViewPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_resize___")]
	public static extern void OdPdfPublish_OdViewPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdViewPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_Add___")]
	public static extern void OdPdfPublish_OdViewPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdViewPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdViewPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdViewPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdViewPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdViewPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdViewPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdViewPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdViewPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdViewPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdViewPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdViewPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdViewPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdViewPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdViewPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdViewPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdViewPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdViewPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdViewPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdViewPtrArray___")]
	public static extern void delete_OdPdfPublish_OdViewPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdFilePtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdFilePtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdFilePtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdFilePtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdFilePtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdFilePtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_size___")]
	public static extern uint OdPdfPublish_OdFilePtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdFilePtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_reserve___")]
	public static extern void OdPdfPublish_OdFilePtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_resize___")]
	public static extern void OdPdfPublish_OdFilePtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_Clear___")]
	public static extern void OdPdfPublish_OdFilePtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_Add___")]
	public static extern void OdPdfPublish_OdFilePtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdFilePtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdFilePtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_setitem___")]
	public static extern void OdPdfPublish_OdFilePtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdFilePtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdFilePtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_Insert___")]
	public static extern void OdPdfPublish_OdFilePtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdFilePtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdFilePtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdFilePtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdFilePtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdFilePtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdFilePtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdFilePtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdFilePtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdFilePtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdFilePtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFilePtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdFilePtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdFilePtrArray___")]
	public static extern void delete_OdPdfPublish_OdFilePtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTextPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdTextPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTextPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdTextPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTextPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdTextPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_size___")]
	public static extern uint OdPdfPublish_OdTextPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdTextPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdTextPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_resize___")]
	public static extern void OdPdfPublish_OdTextPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdTextPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_Add___")]
	public static extern void OdPdfPublish_OdTextPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdTextPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdTextPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdTextPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdTextPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdTextPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdTextPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdTextPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdTextPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdTextPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdTextPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdTextPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdTextPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdTextPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdTextPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdTextPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdTextPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdTextPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdTextPtrArray___")]
	public static extern void delete_OdPdfPublish_OdTextPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTablePtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdTablePtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTablePtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdTablePtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTablePtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdTablePtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_size___")]
	public static extern uint OdPdfPublish_OdTablePtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdTablePtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_reserve___")]
	public static extern void OdPdfPublish_OdTablePtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_resize___")]
	public static extern void OdPdfPublish_OdTablePtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_Clear___")]
	public static extern void OdPdfPublish_OdTablePtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_Add___")]
	public static extern void OdPdfPublish_OdTablePtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdTablePtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdTablePtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_setitem___")]
	public static extern void OdPdfPublish_OdTablePtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdTablePtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdTablePtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_Insert___")]
	public static extern void OdPdfPublish_OdTablePtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdTablePtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdTablePtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdTablePtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdTablePtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdTablePtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdTablePtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdTablePtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdTablePtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdTablePtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdTablePtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTablePtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdTablePtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdTablePtrArray___")]
	public static extern void delete_OdPdfPublish_OdTablePtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdImagePtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdImagePtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdImagePtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdImagePtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdImagePtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdImagePtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_size___")]
	public static extern uint OdPdfPublish_OdImagePtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdImagePtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_reserve___")]
	public static extern void OdPdfPublish_OdImagePtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_resize___")]
	public static extern void OdPdfPublish_OdImagePtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_Clear___")]
	public static extern void OdPdfPublish_OdImagePtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_Add___")]
	public static extern void OdPdfPublish_OdImagePtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdImagePtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdImagePtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_setitem___")]
	public static extern void OdPdfPublish_OdImagePtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdImagePtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdImagePtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_Insert___")]
	public static extern void OdPdfPublish_OdImagePtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdImagePtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdImagePtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdImagePtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdImagePtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdImagePtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdImagePtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdImagePtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdImagePtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdImagePtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdImagePtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImagePtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdImagePtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdImagePtrArray___")]
	public static extern void delete_OdPdfPublish_OdImagePtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdObjectPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdObjectPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdObjectPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdObjectPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdObjectPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdObjectPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_size___")]
	public static extern uint OdPdfPublish_OdObjectPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdObjectPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdObjectPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_resize___")]
	public static extern void OdPdfPublish_OdObjectPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdObjectPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_Add___")]
	public static extern void OdPdfPublish_OdObjectPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdObjectPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdObjectPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdObjectPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdObjectPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdObjectPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdObjectPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdObjectPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdObjectPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdObjectPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdObjectPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdObjectPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdObjectPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdObjectPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdObjectPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdObjectPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdObjectPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObjectPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdObjectPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdObjectPtrArray___")]
	public static extern void delete_OdPdfPublish_OdObjectPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdButtonPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdButtonPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdButtonPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdButtonPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdButtonPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdButtonPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_size___")]
	public static extern uint OdPdfPublish_OdButtonPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdButtonPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdButtonPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_resize___")]
	public static extern void OdPdfPublish_OdButtonPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdButtonPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_Add___")]
	public static extern void OdPdfPublish_OdButtonPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdButtonPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdButtonPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdButtonPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdButtonPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdButtonPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdButtonPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdButtonPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdButtonPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdButtonPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdButtonPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdButtonPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdButtonPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdButtonPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdButtonPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdButtonPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdButtonPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButtonPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdButtonPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdButtonPtrArray___")]
	public static extern void delete_OdPdfPublish_OdButtonPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCameraPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdCameraPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCameraPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdCameraPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCameraPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdCameraPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_size___")]
	public static extern uint OdPdfPublish_OdCameraPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdCameraPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdCameraPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_resize___")]
	public static extern void OdPdfPublish_OdCameraPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdCameraPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_Add___")]
	public static extern void OdPdfPublish_OdCameraPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdCameraPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdCameraPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdCameraPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdCameraPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdCameraPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdCameraPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdCameraPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdCameraPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdCameraPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdCameraPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdCameraPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdCameraPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdCameraPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdCameraPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdCameraPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdCameraPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCameraPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdCameraPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCameraPtrArray___")]
	public static extern void delete_OdPdfPublish_OdCameraPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdListBoxPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdListBoxPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdListBoxPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdListBoxPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdListBoxPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdListBoxPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_size___")]
	public static extern uint OdPdfPublish_OdListBoxPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdListBoxPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdListBoxPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_resize___")]
	public static extern void OdPdfPublish_OdListBoxPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdListBoxPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_Add___")]
	public static extern void OdPdfPublish_OdListBoxPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdListBoxPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdListBoxPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdListBoxPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdListBoxPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdListBoxPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdListBoxPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdListBoxPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdListBoxPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdListBoxPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdListBoxPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdListBoxPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdListBoxPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdListBoxPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdListBoxPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdListBoxPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdListBoxPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBoxPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdListBoxPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdListBoxPtrArray___")]
	public static extern void delete_OdPdfPublish_OdListBoxPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdArtworkPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdArtworkPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdArtworkPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdArtworkPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdArtworkPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdArtworkPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_size___")]
	public static extern uint OdPdfPublish_OdArtworkPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdArtworkPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdArtworkPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_resize___")]
	public static extern void OdPdfPublish_OdArtworkPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdArtworkPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_Add___")]
	public static extern void OdPdfPublish_OdArtworkPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdArtworkPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdArtworkPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdArtworkPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdArtworkPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdArtworkPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdArtworkPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdArtworkPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdArtworkPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdArtworkPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdArtworkPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdArtworkPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdArtworkPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdArtworkPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdArtworkPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdArtworkPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdArtworkPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtworkPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdArtworkPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdArtworkPtrArray___")]
	public static extern void delete_OdPdfPublish_OdArtworkPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdDocumentPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdDocumentPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdDocumentPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdDocumentPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdDocumentPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdDocumentPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_size___")]
	public static extern uint OdPdfPublish_OdDocumentPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdDocumentPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdDocumentPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_resize___")]
	public static extern void OdPdfPublish_OdDocumentPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdDocumentPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_Add___")]
	public static extern void OdPdfPublish_OdDocumentPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdDocumentPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdDocumentPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdDocumentPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdDocumentPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdDocumentPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdDocumentPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdDocumentPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdDocumentPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdDocumentPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdDocumentPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdDocumentPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdDocumentPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdDocumentPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdDocumentPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdDocumentPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdDocumentPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocumentPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdDocumentPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdDocumentPtrArray___")]
	public static extern void delete_OdPdfPublish_OdDocumentPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCADModelPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdCADModelPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCADModelPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdCADModelPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCADModelPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdCADModelPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_size___")]
	public static extern uint OdPdfPublish_OdCADModelPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdCADModelPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdCADModelPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_resize___")]
	public static extern void OdPdfPublish_OdCADModelPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdCADModelPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_Add___")]
	public static extern void OdPdfPublish_OdCADModelPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdCADModelPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdCADModelPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdCADModelPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdCADModelPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdCADModelPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdCADModelPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdCADModelPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdCADModelPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdCADModelPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdCADModelPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdCADModelPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdCADModelPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdCADModelPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdCADModelPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdCADModelPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdCADModelPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModelPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdCADModelPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCADModelPtrArray___")]
	public static extern void delete_OdPdfPublish_OdCADModelPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCheckBoxPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdCheckBoxPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCheckBoxPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdCheckBoxPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCheckBoxPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdCheckBoxPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_size___")]
	public static extern uint OdPdfPublish_OdCheckBoxPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdCheckBoxPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdCheckBoxPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_resize___")]
	public static extern void OdPdfPublish_OdCheckBoxPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdCheckBoxPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_Add___")]
	public static extern void OdPdfPublish_OdCheckBoxPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdCheckBoxPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdCheckBoxPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdCheckBoxPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdCheckBoxPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdCheckBoxPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdCheckBoxPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdCheckBoxPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdCheckBoxPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdCheckBoxPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdCheckBoxPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdCheckBoxPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdCheckBoxPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdCheckBoxPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdCheckBoxPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdCheckBoxPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdCheckBoxPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBoxPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdCheckBoxPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCheckBoxPtrArray___")]
	public static extern void delete_OdPdfPublish_OdCheckBoxPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdBookmarkPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdBookmarkPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdBookmarkPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdBookmarkPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdBookmarkPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdBookmarkPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_size___")]
	public static extern uint OdPdfPublish_OdBookmarkPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdBookmarkPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdBookmarkPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_resize___")]
	public static extern void OdPdfPublish_OdBookmarkPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdBookmarkPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_Add___")]
	public static extern void OdPdfPublish_OdBookmarkPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdBookmarkPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdBookmarkPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdBookmarkPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdBookmarkPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdBookmarkPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdBookmarkPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdBookmarkPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdBookmarkPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdBookmarkPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdBookmarkPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdBookmarkPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdBookmarkPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdBookmarkPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdBookmarkPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdBookmarkPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdBookmarkPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmarkPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdBookmarkPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdBookmarkPtrArray___")]
	public static extern void delete_OdPdfPublish_OdBookmarkPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTextFieldPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdTextFieldPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTextFieldPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdTextFieldPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTextFieldPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdTextFieldPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_size___")]
	public static extern uint OdPdfPublish_OdTextFieldPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdTextFieldPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdTextFieldPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_resize___")]
	public static extern void OdPdfPublish_OdTextFieldPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdTextFieldPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_Add___")]
	public static extern void OdPdfPublish_OdTextFieldPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdTextFieldPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdTextFieldPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdTextFieldPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdTextFieldPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdTextFieldPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdTextFieldPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdTextFieldPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdTextFieldPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdTextFieldPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdTextFieldPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdTextFieldPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdTextFieldPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdTextFieldPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdTextFieldPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdTextFieldPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdTextFieldPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextFieldPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdTextFieldPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdTextFieldPtrArray___")]
	public static extern void delete_OdPdfPublish_OdTextFieldPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdWatermarkPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdWatermarkPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdWatermarkPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdWatermarkPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdWatermarkPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdWatermarkPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_size___")]
	public static extern uint OdPdfPublish_OdWatermarkPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdWatermarkPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdWatermarkPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_resize___")]
	public static extern void OdPdfPublish_OdWatermarkPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdWatermarkPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_Add___")]
	public static extern void OdPdfPublish_OdWatermarkPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdWatermarkPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdWatermarkPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdWatermarkPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdWatermarkPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdWatermarkPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdWatermarkPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdWatermarkPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdWatermarkPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdWatermarkPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdWatermarkPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdWatermarkPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdWatermarkPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdWatermarkPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdWatermarkPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdWatermarkPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdWatermarkPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermarkPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdWatermarkPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdWatermarkPtrArray___")]
	public static extern void delete_OdPdfPublish_OdWatermarkPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAnimationPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdAnimationPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAnimationPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdAnimationPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAnimationPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdAnimationPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_size___")]
	public static extern uint OdPdfPublish_OdAnimationPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdAnimationPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdAnimationPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_resize___")]
	public static extern void OdPdfPublish_OdAnimationPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdAnimationPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_Add___")]
	public static extern void OdPdfPublish_OdAnimationPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdAnimationPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdAnimationPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdAnimationPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdAnimationPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdAnimationPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdAnimationPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdAnimationPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdAnimationPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdAnimationPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdAnimationPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdAnimationPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdAnimationPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdAnimationPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdAnimationPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdAnimationPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdAnimationPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimationPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdAnimationPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdAnimationPtrArray___")]
	public static extern void delete_OdPdfPublish_OdAnimationPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdSlideTablePtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdSlideTablePtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdSlideTablePtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdSlideTablePtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdSlideTablePtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdSlideTablePtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_size___")]
	public static extern uint OdPdfPublish_OdSlideTablePtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdSlideTablePtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_reserve___")]
	public static extern void OdPdfPublish_OdSlideTablePtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_resize___")]
	public static extern void OdPdfPublish_OdSlideTablePtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_Clear___")]
	public static extern void OdPdfPublish_OdSlideTablePtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_Add___")]
	public static extern void OdPdfPublish_OdSlideTablePtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdSlideTablePtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdSlideTablePtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_setitem___")]
	public static extern void OdPdfPublish_OdSlideTablePtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdSlideTablePtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdSlideTablePtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_Insert___")]
	public static extern void OdPdfPublish_OdSlideTablePtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdSlideTablePtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdSlideTablePtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdSlideTablePtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdSlideTablePtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdSlideTablePtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdSlideTablePtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdSlideTablePtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdSlideTablePtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdSlideTablePtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdSlideTablePtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTablePtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdSlideTablePtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdSlideTablePtrArray___")]
	public static extern void delete_OdPdfPublish_OdSlideTablePtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAnnotationPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdAnnotationPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAnnotationPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdAnnotationPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAnnotationPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdAnnotationPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_size___")]
	public static extern uint OdPdfPublish_OdAnnotationPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdAnnotationPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdAnnotationPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_resize___")]
	public static extern void OdPdfPublish_OdAnnotationPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdAnnotationPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_Add___")]
	public static extern void OdPdfPublish_OdAnnotationPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdAnnotationPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdAnnotationPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdAnnotationPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdAnnotationPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdAnnotationPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdAnnotationPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdAnnotationPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdAnnotationPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdAnnotationPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdAnnotationPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdAnnotationPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdAnnotationPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdAnnotationPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdAnnotationPtrArray___")]
	public static extern void delete_OdPdfPublish_OdAnnotationPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdStickyNotePtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdStickyNotePtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdStickyNotePtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdStickyNotePtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdStickyNotePtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdStickyNotePtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_size___")]
	public static extern uint OdPdfPublish_OdStickyNotePtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdStickyNotePtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_reserve___")]
	public static extern void OdPdfPublish_OdStickyNotePtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_resize___")]
	public static extern void OdPdfPublish_OdStickyNotePtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_Clear___")]
	public static extern void OdPdfPublish_OdStickyNotePtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_Add___")]
	public static extern void OdPdfPublish_OdStickyNotePtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdStickyNotePtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdStickyNotePtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_setitem___")]
	public static extern void OdPdfPublish_OdStickyNotePtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdStickyNotePtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdStickyNotePtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_Insert___")]
	public static extern void OdPdfPublish_OdStickyNotePtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdStickyNotePtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdStickyNotePtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdStickyNotePtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdStickyNotePtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdStickyNotePtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdStickyNotePtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdStickyNotePtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdStickyNotePtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdStickyNotePtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdStickyNotePtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNotePtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdStickyNotePtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdStickyNotePtrArray___")]
	public static extern void delete_OdPdfPublish_OdStickyNotePtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCollectionPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdCollectionPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCollectionPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdCollectionPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCollectionPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdCollectionPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_size___")]
	public static extern uint OdPdfPublish_OdCollectionPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdCollectionPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdCollectionPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_resize___")]
	public static extern void OdPdfPublish_OdCollectionPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdCollectionPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_Add___")]
	public static extern void OdPdfPublish_OdCollectionPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdCollectionPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdCollectionPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdCollectionPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdCollectionPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdCollectionPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdCollectionPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdCollectionPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdCollectionPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdCollectionPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdCollectionPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdCollectionPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdCollectionPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdCollectionPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdCollectionPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdCollectionPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdCollectionPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdCollectionPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCollectionPtrArray___")]
	public static extern void delete_OdPdfPublish_OdCollectionPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdRadioButtonPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdRadioButtonPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdRadioButtonPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdRadioButtonPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdRadioButtonPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdRadioButtonPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_size___")]
	public static extern uint OdPdfPublish_OdRadioButtonPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdRadioButtonPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdRadioButtonPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_resize___")]
	public static extern void OdPdfPublish_OdRadioButtonPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdRadioButtonPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_Add___")]
	public static extern void OdPdfPublish_OdRadioButtonPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdRadioButtonPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdRadioButtonPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdRadioButtonPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdRadioButtonPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdRadioButtonPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdRadioButtonPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdRadioButtonPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdRadioButtonPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdRadioButtonPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdRadioButtonPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdRadioButtonPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdRadioButtonPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdRadioButtonPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdRadioButtonPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdRadioButtonPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdRadioButtonPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButtonPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdRadioButtonPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdRadioButtonPtrArray___")]
	public static extern void delete_OdPdfPublish_OdRadioButtonPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAttachedFilePtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdAttachedFilePtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAttachedFilePtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdAttachedFilePtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAttachedFilePtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdAttachedFilePtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_size___")]
	public static extern uint OdPdfPublish_OdAttachedFilePtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdAttachedFilePtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_reserve___")]
	public static extern void OdPdfPublish_OdAttachedFilePtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_resize___")]
	public static extern void OdPdfPublish_OdAttachedFilePtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_Clear___")]
	public static extern void OdPdfPublish_OdAttachedFilePtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_Add___")]
	public static extern void OdPdfPublish_OdAttachedFilePtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFilePtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFilePtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_setitem___")]
	public static extern void OdPdfPublish_OdAttachedFilePtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdAttachedFilePtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFilePtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_Insert___")]
	public static extern void OdPdfPublish_OdAttachedFilePtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdAttachedFilePtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdAttachedFilePtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdAttachedFilePtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFilePtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdAttachedFilePtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdAttachedFilePtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdAttachedFilePtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdAttachedFilePtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdAttachedFilePtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdAttachedFilePtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFilePtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdAttachedFilePtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdAttachedFilePtrArray___")]
	public static extern void delete_OdPdfPublish_OdAttachedFilePtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCADReferencePtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdCADReferencePtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCADReferencePtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdCADReferencePtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCADReferencePtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdCADReferencePtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_size___")]
	public static extern uint OdPdfPublish_OdCADReferencePtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdCADReferencePtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_reserve___")]
	public static extern void OdPdfPublish_OdCADReferencePtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_resize___")]
	public static extern void OdPdfPublish_OdCADReferencePtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_Clear___")]
	public static extern void OdPdfPublish_OdCADReferencePtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_Add___")]
	public static extern void OdPdfPublish_OdCADReferencePtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdCADReferencePtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdCADReferencePtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_setitem___")]
	public static extern void OdPdfPublish_OdCADReferencePtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdCADReferencePtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdCADReferencePtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_Insert___")]
	public static extern void OdPdfPublish_OdCADReferencePtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdCADReferencePtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdCADReferencePtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdCADReferencePtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdCADReferencePtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdCADReferencePtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdCADReferencePtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdCADReferencePtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdCADReferencePtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdCADReferencePtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdCADReferencePtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReferencePtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdCADReferencePtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCADReferencePtrArray___")]
	public static extern void delete_OdPdfPublish_OdCADReferencePtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdDropDownListPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdDropDownListPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdDropDownListPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdDropDownListPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdDropDownListPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdDropDownListPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_size___")]
	public static extern uint OdPdfPublish_OdDropDownListPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdDropDownListPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdDropDownListPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_resize___")]
	public static extern void OdPdfPublish_OdDropDownListPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdDropDownListPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_Add___")]
	public static extern void OdPdfPublish_OdDropDownListPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdDropDownListPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdDropDownListPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdDropDownListPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdDropDownListPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdDropDownListPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdDropDownListPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdDropDownListPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdDropDownListPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdDropDownListPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdDropDownListPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdDropDownListPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdDropDownListPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdDropDownListPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdDropDownListPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdDropDownListPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdDropDownListPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownListPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdDropDownListPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdDropDownListPtrArray___")]
	public static extern void delete_OdPdfPublish_OdDropDownListPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTableCreatorPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdTableCreatorPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTableCreatorPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdTableCreatorPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTableCreatorPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdTableCreatorPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_size___")]
	public static extern uint OdPdfPublish_OdTableCreatorPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdTableCreatorPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdTableCreatorPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_resize___")]
	public static extern void OdPdfPublish_OdTableCreatorPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdTableCreatorPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_Add___")]
	public static extern void OdPdfPublish_OdTableCreatorPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdTableCreatorPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdTableCreatorPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdTableCreatorPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdTableCreatorPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdTableCreatorPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdTableCreatorPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdTableCreatorPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdTableCreatorPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdTableCreatorPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdTableCreatorPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdTableCreatorPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdTableCreatorPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdTableCreatorPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdTableCreatorPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdTableCreatorPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdTableCreatorPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreatorPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdTableCreatorPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdTableCreatorPtrArray___")]
	public static extern void delete_OdPdfPublish_OdTableCreatorPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCADDefinitionPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdCADDefinitionPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCADDefinitionPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdCADDefinitionPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCADDefinitionPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdCADDefinitionPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_size___")]
	public static extern uint OdPdfPublish_OdCADDefinitionPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdCADDefinitionPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdCADDefinitionPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_resize___")]
	public static extern void OdPdfPublish_OdCADDefinitionPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdCADDefinitionPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_Add___")]
	public static extern void OdPdfPublish_OdCADDefinitionPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdCADDefinitionPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdCADDefinitionPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdCADDefinitionPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdCADDefinitionPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdCADDefinitionPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdCADDefinitionPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdCADDefinitionPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdCADDefinitionPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdCADDefinitionPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdCADDefinitionPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdCADDefinitionPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdCADDefinitionPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdCADDefinitionPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdCADDefinitionPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdCADDefinitionPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdCADDefinitionPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinitionPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdCADDefinitionPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCADDefinitionPtrArray___")]
	public static extern void delete_OdPdfPublish_OdCADDefinitionPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTilingPatternPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdTilingPatternPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTilingPatternPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdTilingPatternPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTilingPatternPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdTilingPatternPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_size___")]
	public static extern uint OdPdfPublish_OdTilingPatternPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdTilingPatternPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdTilingPatternPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_resize___")]
	public static extern void OdPdfPublish_OdTilingPatternPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdTilingPatternPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_Add___")]
	public static extern void OdPdfPublish_OdTilingPatternPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdTilingPatternPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdTilingPatternPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdTilingPatternPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdTilingPatternPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdTilingPatternPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdTilingPatternPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdTilingPatternPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdTilingPatternPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdTilingPatternPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdTilingPatternPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdTilingPatternPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdTilingPatternPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdTilingPatternPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdTilingPatternPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdTilingPatternPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdTilingPatternPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPatternPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdTilingPatternPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdTilingPatternPtrArray___")]
	public static extern void delete_OdPdfPublish_OdTilingPatternPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdInkAnnotationPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdInkAnnotationPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdInkAnnotationPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdInkAnnotationPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdInkAnnotationPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdInkAnnotationPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_size___")]
	public static extern uint OdPdfPublish_OdInkAnnotationPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdInkAnnotationPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdInkAnnotationPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_resize___")]
	public static extern void OdPdfPublish_OdInkAnnotationPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdInkAnnotationPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_Add___")]
	public static extern void OdPdfPublish_OdInkAnnotationPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdInkAnnotationPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdInkAnnotationPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdInkAnnotationPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdInkAnnotationPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdInkAnnotationPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdInkAnnotationPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdInkAnnotationPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdInkAnnotationPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdInkAnnotationPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdInkAnnotationPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdInkAnnotationPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdInkAnnotationPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdInkAnnotationPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdInkAnnotationPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdInkAnnotationPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdInkAnnotationPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotationPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdInkAnnotationPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdInkAnnotationPtrArray___")]
	public static extern void delete_OdPdfPublish_OdInkAnnotationPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdLineAnnotationPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdLineAnnotationPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdLineAnnotationPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdLineAnnotationPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdLineAnnotationPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdLineAnnotationPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_size___")]
	public static extern uint OdPdfPublish_OdLineAnnotationPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdLineAnnotationPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdLineAnnotationPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_resize___")]
	public static extern void OdPdfPublish_OdLineAnnotationPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdLineAnnotationPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_Add___")]
	public static extern void OdPdfPublish_OdLineAnnotationPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdLineAnnotationPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdLineAnnotationPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdLineAnnotationPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdLineAnnotationPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdLineAnnotationPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdLineAnnotationPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdLineAnnotationPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdLineAnnotationPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdLineAnnotationPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdLineAnnotationPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdLineAnnotationPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdLineAnnotationPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdLineAnnotationPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdLineAnnotationPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdLineAnnotationPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdLineAnnotationPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotationPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdLineAnnotationPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdLineAnnotationPtrArray___")]
	public static extern void delete_OdPdfPublish_OdLineAnnotationPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAttachedFolderPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdAttachedFolderPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAttachedFolderPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdAttachedFolderPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAttachedFolderPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdAttachedFolderPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_size___")]
	public static extern uint OdPdfPublish_OdAttachedFolderPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdAttachedFolderPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdAttachedFolderPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_resize___")]
	public static extern void OdPdfPublish_OdAttachedFolderPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdAttachedFolderPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_Add___")]
	public static extern void OdPdfPublish_OdAttachedFolderPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFolderPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFolderPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdAttachedFolderPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdAttachedFolderPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFolderPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdAttachedFolderPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdAttachedFolderPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdAttachedFolderPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdAttachedFolderPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFolderPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdAttachedFolderPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdAttachedFolderPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdAttachedFolderPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdAttachedFolderPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdAttachedFolderPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdAttachedFolderPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolderPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdAttachedFolderPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdAttachedFolderPtrArray___")]
	public static extern void delete_OdPdfPublish_OdAttachedFolderPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdSignatureFieldPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdSignatureFieldPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdSignatureFieldPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdSignatureFieldPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdSignatureFieldPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdSignatureFieldPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_size___")]
	public static extern uint OdPdfPublish_OdSignatureFieldPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdSignatureFieldPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdSignatureFieldPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_resize___")]
	public static extern void OdPdfPublish_OdSignatureFieldPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdSignatureFieldPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_Add___")]
	public static extern void OdPdfPublish_OdSignatureFieldPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdSignatureFieldPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdSignatureFieldPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdSignatureFieldPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdSignatureFieldPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdSignatureFieldPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdSignatureFieldPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdSignatureFieldPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdSignatureFieldPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdSignatureFieldPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdSignatureFieldPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdSignatureFieldPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdSignatureFieldPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdSignatureFieldPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdSignatureFieldPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdSignatureFieldPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdSignatureFieldPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureFieldPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdSignatureFieldPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdSignatureFieldPtrArray___")]
	public static extern void delete_OdPdfPublish_OdSignatureFieldPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_Od2dGeometryBlockPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_Od2dGeometryBlockPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_Od2dGeometryBlockPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_Od2dGeometryBlockPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_Od2dGeometryBlockPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_Od2dGeometryBlockPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_size___")]
	public static extern uint OdPdfPublish_Od2dGeometryBlockPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_capacity___")]
	public static extern uint OdPdfPublish_Od2dGeometryBlockPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_reserve___")]
	public static extern void OdPdfPublish_Od2dGeometryBlockPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_resize___")]
	public static extern void OdPdfPublish_Od2dGeometryBlockPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_Clear___")]
	public static extern void OdPdfPublish_Od2dGeometryBlockPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_Add___")]
	public static extern void OdPdfPublish_Od2dGeometryBlockPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryBlockPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryBlockPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_setitem___")]
	public static extern void OdPdfPublish_Od2dGeometryBlockPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_AddRange___")]
	public static extern void OdPdfPublish_Od2dGeometryBlockPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryBlockPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_Insert___")]
	public static extern void OdPdfPublish_Od2dGeometryBlockPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_Od2dGeometryBlockPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_Od2dGeometryBlockPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_Od2dGeometryBlockPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryBlockPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_Od2dGeometryBlockPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_Od2dGeometryBlockPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_SetRange___")]
	public static extern void OdPdfPublish_Od2dGeometryBlockPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_Contains___")]
	public static extern bool OdPdfPublish_Od2dGeometryBlockPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_Od2dGeometryBlockPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_Od2dGeometryBlockPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlockPtrArray_Remove___")]
	public static extern bool OdPdfPublish_Od2dGeometryBlockPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_Od2dGeometryBlockPtrArray___")]
	public static extern void delete_OdPdfPublish_Od2dGeometryBlockPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdStampAnnotationPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdStampAnnotationPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdStampAnnotationPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdStampAnnotationPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdStampAnnotationPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdStampAnnotationPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_size___")]
	public static extern uint OdPdfPublish_OdStampAnnotationPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdStampAnnotationPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdStampAnnotationPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_resize___")]
	public static extern void OdPdfPublish_OdStampAnnotationPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdStampAnnotationPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_Add___")]
	public static extern void OdPdfPublish_OdStampAnnotationPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdStampAnnotationPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdStampAnnotationPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdStampAnnotationPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdStampAnnotationPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdStampAnnotationPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdStampAnnotationPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdStampAnnotationPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdStampAnnotationPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdStampAnnotationPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdStampAnnotationPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdStampAnnotationPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdStampAnnotationPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdStampAnnotationPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdStampAnnotationPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdStampAnnotationPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdStampAnnotationPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotationPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdStampAnnotationPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdStampAnnotationPtrArray___")]
	public static extern void delete_OdPdfPublish_OdStampAnnotationPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCaretAnnotationPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdCaretAnnotationPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCaretAnnotationPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdCaretAnnotationPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCaretAnnotationPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdCaretAnnotationPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_size___")]
	public static extern uint OdPdfPublish_OdCaretAnnotationPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdCaretAnnotationPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdCaretAnnotationPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_resize___")]
	public static extern void OdPdfPublish_OdCaretAnnotationPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdCaretAnnotationPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_Add___")]
	public static extern void OdPdfPublish_OdCaretAnnotationPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdCaretAnnotationPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdCaretAnnotationPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdCaretAnnotationPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdCaretAnnotationPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdCaretAnnotationPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdCaretAnnotationPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdCaretAnnotationPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdCaretAnnotationPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdCaretAnnotationPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdCaretAnnotationPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdCaretAnnotationPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdCaretAnnotationPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdCaretAnnotationPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdCaretAnnotationPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdCaretAnnotationPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdCaretAnnotationPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotationPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdCaretAnnotationPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCaretAnnotationPtrArray___")]
	public static extern void delete_OdPdfPublish_OdCaretAnnotationPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_Od2dGeometryLayerPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_Od2dGeometryLayerPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_Od2dGeometryLayerPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_Od2dGeometryLayerPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_Od2dGeometryLayerPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_Od2dGeometryLayerPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_size___")]
	public static extern uint OdPdfPublish_Od2dGeometryLayerPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_capacity___")]
	public static extern uint OdPdfPublish_Od2dGeometryLayerPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_reserve___")]
	public static extern void OdPdfPublish_Od2dGeometryLayerPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_resize___")]
	public static extern void OdPdfPublish_Od2dGeometryLayerPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_Clear___")]
	public static extern void OdPdfPublish_Od2dGeometryLayerPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_Add___")]
	public static extern void OdPdfPublish_Od2dGeometryLayerPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryLayerPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryLayerPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_setitem___")]
	public static extern void OdPdfPublish_Od2dGeometryLayerPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_AddRange___")]
	public static extern void OdPdfPublish_Od2dGeometryLayerPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryLayerPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_Insert___")]
	public static extern void OdPdfPublish_Od2dGeometryLayerPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_Od2dGeometryLayerPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_Od2dGeometryLayerPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_Od2dGeometryLayerPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryLayerPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_Od2dGeometryLayerPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_Od2dGeometryLayerPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_SetRange___")]
	public static extern void OdPdfPublish_Od2dGeometryLayerPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_Contains___")]
	public static extern bool OdPdfPublish_Od2dGeometryLayerPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_Od2dGeometryLayerPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_Od2dGeometryLayerPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayerPtrArray_Remove___")]
	public static extern bool OdPdfPublish_Od2dGeometryLayerPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_Od2dGeometryLayerPtrArray___")]
	public static extern void delete_OdPdfPublish_Od2dGeometryLayerPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCollectionColumnPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdCollectionColumnPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCollectionColumnPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdCollectionColumnPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCollectionColumnPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdCollectionColumnPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_size___")]
	public static extern uint OdPdfPublish_OdCollectionColumnPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdCollectionColumnPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdCollectionColumnPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_resize___")]
	public static extern void OdPdfPublish_OdCollectionColumnPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdCollectionColumnPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_Add___")]
	public static extern void OdPdfPublish_OdCollectionColumnPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdCollectionColumnPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdCollectionColumnPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdCollectionColumnPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdCollectionColumnPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdCollectionColumnPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdCollectionColumnPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdCollectionColumnPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdCollectionColumnPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdCollectionColumnPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdCollectionColumnPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdCollectionColumnPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdCollectionColumnPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdCollectionColumnPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdCollectionColumnPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdCollectionColumnPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdCollectionColumnPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumnPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdCollectionColumnPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCollectionColumnPtrArray___")]
	public static extern void delete_OdPdfPublish_OdCollectionColumnPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCircleAnnotationPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdCircleAnnotationPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCircleAnnotationPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdCircleAnnotationPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdCircleAnnotationPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdCircleAnnotationPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_size___")]
	public static extern uint OdPdfPublish_OdCircleAnnotationPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdCircleAnnotationPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdCircleAnnotationPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_resize___")]
	public static extern void OdPdfPublish_OdCircleAnnotationPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdCircleAnnotationPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_Add___")]
	public static extern void OdPdfPublish_OdCircleAnnotationPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdCircleAnnotationPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdCircleAnnotationPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdCircleAnnotationPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdCircleAnnotationPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdCircleAnnotationPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdCircleAnnotationPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdCircleAnnotationPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdCircleAnnotationPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdCircleAnnotationPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdCircleAnnotationPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdCircleAnnotationPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdCircleAnnotationPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdCircleAnnotationPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdCircleAnnotationPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdCircleAnnotationPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdCircleAnnotationPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotationPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdCircleAnnotationPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdCircleAnnotationPtrArray___")]
	public static extern void delete_OdPdfPublish_OdCircleAnnotationPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdSquareAnnotationPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdSquareAnnotationPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdSquareAnnotationPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdSquareAnnotationPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdSquareAnnotationPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdSquareAnnotationPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_size___")]
	public static extern uint OdPdfPublish_OdSquareAnnotationPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdSquareAnnotationPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdSquareAnnotationPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_resize___")]
	public static extern void OdPdfPublish_OdSquareAnnotationPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdSquareAnnotationPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_Add___")]
	public static extern void OdPdfPublish_OdSquareAnnotationPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdSquareAnnotationPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdSquareAnnotationPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdSquareAnnotationPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdSquareAnnotationPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdSquareAnnotationPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdSquareAnnotationPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdSquareAnnotationPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdSquareAnnotationPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdSquareAnnotationPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdSquareAnnotationPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdSquareAnnotationPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdSquareAnnotationPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdSquareAnnotationPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdSquareAnnotationPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdSquareAnnotationPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdSquareAnnotationPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotationPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdSquareAnnotationPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdSquareAnnotationPtrArray___")]
	public static extern void delete_OdPdfPublish_OdSquareAnnotationPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdMarkupAnnotationPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdMarkupAnnotationPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdMarkupAnnotationPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdMarkupAnnotationPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdMarkupAnnotationPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdMarkupAnnotationPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_size___")]
	public static extern uint OdPdfPublish_OdMarkupAnnotationPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdMarkupAnnotationPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdMarkupAnnotationPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_resize___")]
	public static extern void OdPdfPublish_OdMarkupAnnotationPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdMarkupAnnotationPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_Add___")]
	public static extern void OdPdfPublish_OdMarkupAnnotationPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdMarkupAnnotationPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdMarkupAnnotationPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdMarkupAnnotationPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdMarkupAnnotationPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdMarkupAnnotationPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdMarkupAnnotationPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdMarkupAnnotationPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdMarkupAnnotationPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdMarkupAnnotationPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdMarkupAnnotationPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdMarkupAnnotationPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdMarkupAnnotationPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdMarkupAnnotationPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdMarkupAnnotationPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdMarkupAnnotationPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdMarkupAnnotationPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotationPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdMarkupAnnotationPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdMarkupAnnotationPtrArray___")]
	public static extern void delete_OdPdfPublish_OdMarkupAnnotationPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdPolygonAnnotationPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdPolygonAnnotationPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdPolygonAnnotationPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdPolygonAnnotationPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdPolygonAnnotationPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdPolygonAnnotationPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_size___")]
	public static extern uint OdPdfPublish_OdPolygonAnnotationPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdPolygonAnnotationPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdPolygonAnnotationPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_resize___")]
	public static extern void OdPdfPublish_OdPolygonAnnotationPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdPolygonAnnotationPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_Add___")]
	public static extern void OdPdfPublish_OdPolygonAnnotationPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdPolygonAnnotationPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdPolygonAnnotationPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdPolygonAnnotationPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdPolygonAnnotationPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdPolygonAnnotationPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdPolygonAnnotationPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdPolygonAnnotationPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdPolygonAnnotationPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdPolygonAnnotationPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdPolygonAnnotationPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdPolygonAnnotationPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdPolygonAnnotationPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdPolygonAnnotationPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdPolygonAnnotationPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdPolygonAnnotationPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdPolygonAnnotationPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotationPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdPolygonAnnotationPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdPolygonAnnotationPtrArray___")]
	public static extern void delete_OdPdfPublish_OdPolygonAnnotationPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdPolylineAnnotationPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdPolylineAnnotationPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdPolylineAnnotationPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdPolylineAnnotationPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdPolylineAnnotationPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdPolylineAnnotationPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_size___")]
	public static extern uint OdPdfPublish_OdPolylineAnnotationPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdPolylineAnnotationPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdPolylineAnnotationPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_resize___")]
	public static extern void OdPdfPublish_OdPolylineAnnotationPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdPolylineAnnotationPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_Add___")]
	public static extern void OdPdfPublish_OdPolylineAnnotationPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdPolylineAnnotationPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdPolylineAnnotationPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdPolylineAnnotationPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdPolylineAnnotationPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdPolylineAnnotationPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdPolylineAnnotationPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdPolylineAnnotationPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdPolylineAnnotationPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdPolylineAnnotationPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdPolylineAnnotationPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdPolylineAnnotationPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdPolylineAnnotationPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdPolylineAnnotationPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdPolylineAnnotationPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdPolylineAnnotationPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdPolylineAnnotationPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotationPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdPolylineAnnotationPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdPolylineAnnotationPtrArray___")]
	public static extern void delete_OdPdfPublish_OdPolylineAnnotationPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_Od2dGeometryReferencePtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_Od2dGeometryReferencePtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_Od2dGeometryReferencePtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_Od2dGeometryReferencePtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_Od2dGeometryReferencePtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_Od2dGeometryReferencePtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_size___")]
	public static extern uint OdPdfPublish_Od2dGeometryReferencePtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_capacity___")]
	public static extern uint OdPdfPublish_Od2dGeometryReferencePtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_reserve___")]
	public static extern void OdPdfPublish_Od2dGeometryReferencePtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_resize___")]
	public static extern void OdPdfPublish_Od2dGeometryReferencePtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_Clear___")]
	public static extern void OdPdfPublish_Od2dGeometryReferencePtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_Add___")]
	public static extern void OdPdfPublish_Od2dGeometryReferencePtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryReferencePtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryReferencePtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_setitem___")]
	public static extern void OdPdfPublish_Od2dGeometryReferencePtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_AddRange___")]
	public static extern void OdPdfPublish_Od2dGeometryReferencePtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryReferencePtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_Insert___")]
	public static extern void OdPdfPublish_Od2dGeometryReferencePtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_InsertRange___")]
	public static extern void OdPdfPublish_Od2dGeometryReferencePtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_Od2dGeometryReferencePtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_Od2dGeometryReferencePtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryReferencePtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_Od2dGeometryReferencePtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_Od2dGeometryReferencePtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_SetRange___")]
	public static extern void OdPdfPublish_Od2dGeometryReferencePtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_Contains___")]
	public static extern bool OdPdfPublish_Od2dGeometryReferencePtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_IndexOf___")]
	public static extern int OdPdfPublish_Od2dGeometryReferencePtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_Od2dGeometryReferencePtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReferencePtrArray_Remove___")]
	public static extern bool OdPdfPublish_Od2dGeometryReferencePtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_Od2dGeometryReferencePtrArray___")]
	public static extern void delete_OdPdfPublish_Od2dGeometryReferencePtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTextMarkupAnnotationPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdTextMarkupAnnotationPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTextMarkupAnnotationPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdTextMarkupAnnotationPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdTextMarkupAnnotationPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdTextMarkupAnnotationPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_size___")]
	public static extern uint OdPdfPublish_OdTextMarkupAnnotationPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdTextMarkupAnnotationPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotationPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_resize___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotationPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotationPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_Add___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotationPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdTextMarkupAnnotationPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdTextMarkupAnnotationPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotationPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotationPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdTextMarkupAnnotationPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotationPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotationPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotationPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotationPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdTextMarkupAnnotationPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotationPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotationPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdTextMarkupAnnotationPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdTextMarkupAnnotationPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdTextMarkupAnnotationPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdTextMarkupAnnotationPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotationPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdTextMarkupAnnotationPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdTextMarkupAnnotationPtrArray___")]
	public static extern void delete_OdPdfPublish_OdTextMarkupAnnotationPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAnnotationBorderStylePtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdAnnotationBorderStylePtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAnnotationBorderStylePtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdAnnotationBorderStylePtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAnnotationBorderStylePtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdAnnotationBorderStylePtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_size___")]
	public static extern uint OdPdfPublish_OdAnnotationBorderStylePtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdAnnotationBorderStylePtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_reserve___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStylePtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_resize___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStylePtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_Clear___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStylePtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_Add___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStylePtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderStylePtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderStylePtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_setitem___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStylePtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStylePtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderStylePtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_Insert___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStylePtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStylePtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStylePtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStylePtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderStylePtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStylePtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStylePtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdAnnotationBorderStylePtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdAnnotationBorderStylePtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdAnnotationBorderStylePtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdAnnotationBorderStylePtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStylePtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdAnnotationBorderStylePtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdAnnotationBorderStylePtrArray___")]
	public static extern void delete_OdPdfPublish_OdAnnotationBorderStylePtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAnnotationBorderEffectPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdAnnotationBorderEffectPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAnnotationBorderEffectPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdAnnotationBorderEffectPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdAnnotationBorderEffectPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdAnnotationBorderEffectPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_size___")]
	public static extern uint OdPdfPublish_OdAnnotationBorderEffectPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdAnnotationBorderEffectPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffectPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_resize___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffectPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffectPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_Add___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffectPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderEffectPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderEffectPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffectPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_AddRange___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffectPtrArray_AddRange(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderEffectPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffectPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_InsertRange___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffectPtrArray_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffectPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffectPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderEffectPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_Reverse__SWIG_0___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffectPtrArray_Reverse__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_Reverse__SWIG_1___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffectPtrArray_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdAnnotationBorderEffectPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdAnnotationBorderEffectPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdAnnotationBorderEffectPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdAnnotationBorderEffectPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffectPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdAnnotationBorderEffectPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdAnnotationBorderEffectPtrArray___")]
	public static extern void delete_OdPdfPublish_OdAnnotationBorderEffectPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdBaseNodeMotionPtrArray__SWIG_0")]
	public static extern IntPtr new_OdPdfPublish_OdBaseNodeMotionPtrArray__SWIG_0();

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdBaseNodeMotionPtrArray__SWIG_1")]
	public static extern IntPtr new_OdPdfPublish_OdBaseNodeMotionPtrArray__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_new_OdPdfPublish_OdBaseNodeMotionPtrArray__SWIG_2")]
	public static extern IntPtr new_OdPdfPublish_OdBaseNodeMotionPtrArray__SWIG_2(int jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_size___")]
	public static extern uint OdPdfPublish_OdBaseNodeMotionPtrArray_size(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_capacity___")]
	public static extern uint OdPdfPublish_OdBaseNodeMotionPtrArray_capacity(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_reserve___")]
	public static extern void OdPdfPublish_OdBaseNodeMotionPtrArray_reserve(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_resize___")]
	public static extern void OdPdfPublish_OdBaseNodeMotionPtrArray_resize(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_Clear___")]
	public static extern void OdPdfPublish_OdBaseNodeMotionPtrArray_Clear(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_Add___")]
	public static extern void OdPdfPublish_OdBaseNodeMotionPtrArray_Add(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_getitemcopy___")]
	public static extern IntPtr OdPdfPublish_OdBaseNodeMotionPtrArray_getitemcopy(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_getitem___")]
	public static extern IntPtr OdPdfPublish_OdBaseNodeMotionPtrArray_getitem(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_setitem___")]
	public static extern void OdPdfPublish_OdBaseNodeMotionPtrArray_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_GetRange___")]
	public static extern IntPtr OdPdfPublish_OdBaseNodeMotionPtrArray_GetRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_Insert___")]
	public static extern void OdPdfPublish_OdBaseNodeMotionPtrArray_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_RemoveAt___")]
	public static extern void OdPdfPublish_OdBaseNodeMotionPtrArray_RemoveAt(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_RemoveRange___")]
	public static extern void OdPdfPublish_OdBaseNodeMotionPtrArray_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_Repeat___")]
	public static extern IntPtr OdPdfPublish_OdBaseNodeMotionPtrArray_Repeat(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_SetRange___")]
	public static extern void OdPdfPublish_OdBaseNodeMotionPtrArray_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_Contains___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotionPtrArray_Contains(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_IndexOf___")]
	public static extern int OdPdfPublish_OdBaseNodeMotionPtrArray_IndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_LastIndexOf___")]
	public static extern int OdPdfPublish_OdBaseNodeMotionPtrArray_LastIndexOf(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBaseNodeMotionPtrArray_Remove___")]
	public static extern bool OdPdfPublish_OdBaseNodeMotionPtrArray_Remove(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_delete_OdPdfPublish_OdBaseNodeMotionPtrArray___")]
	public static extern void delete_OdPdfPublish_OdBaseNodeMotionPtrArray(HandleRef jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdObject_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdObject_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryLayer_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryLayer_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdMarkupAnnotation_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdMarkupAnnotation_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdImage_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdImage_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCaretAnnotation_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdCaretAnnotation_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextMarkupAnnotation_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdTextMarkupAnnotation_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCamera_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdCamera_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTilingPattern_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdTilingPattern_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdButton_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdButton_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLink_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdLink_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTextField_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdTextField_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdText_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdText_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnimation_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdAnimation_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdView_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdView_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderEffect_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderEffect_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotationBorderStyle_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdAnnotationBorderStyle_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADDefinition_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdCADDefinition_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryBlock_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryBlock_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTable_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdTable_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdListBox_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdListBox_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADModel_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdCADModel_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdArtwork_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdArtwork_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFolder_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFolder_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAttachedFile_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdAttachedFile_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolygonAnnotation_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdPolygonAnnotation_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPolylineAnnotation_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdPolylineAnnotation_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSquareAnnotation_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdSquareAnnotation_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCircleAnnotation_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdCircleAnnotation_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdLineAnnotation_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdLineAnnotation_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdInkAnnotation_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdInkAnnotation_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStampAnnotation_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdStampAnnotation_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdWatermark_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdWatermark_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdStickyNote_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdStickyNote_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCADReference_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdCADReference_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_Od2dGeometryReference_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_Od2dGeometryReference_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdTableCreator_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdTableCreator_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSlideTable_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdSlideTable_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCheckBox_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdCheckBox_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdRadioButton_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdRadioButton_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDropDownList_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdDropDownList_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdSignatureField_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdSignatureField_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdAnnotation_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdAnnotation_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollectionColumn_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdCollectionColumn_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdPage_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdPage_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdCollection_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdCollection_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdBookmark_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdBookmark_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdDocument_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdDocument_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_PdfPublish_26.10_17.dll", EntryPoint = "CSharp_ODAfPublishfPdfPublish_OdPdfPublish_OdFile_SWIGUpcast___")]
	public static extern IntPtr OdPdfPublish_OdFile_SWIGUpcast(IntPtr jarg1);
}

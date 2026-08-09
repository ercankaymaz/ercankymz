using System;
using System.IO;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

internal class RcsFileServices_GlobalsPINVOKE
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

		[DllImport("OdSwig_RcsFileServices_26.10_17.dll")]
		public static extern void SWIGRegisterExceptionCallbacks_RcsFileServices_Globals(ExceptionDelegate applicationDelegate, ExceptionDelegate arithmeticDelegate, ExceptionDelegate divideByZeroDelegate, ExceptionDelegate indexOutOfRangeDelegate, ExceptionDelegate invalidCastDelegate, ExceptionDelegate invalidOperationDelegate, ExceptionDelegate ioDelegate, ExceptionDelegate nullReferenceDelegate, ExceptionDelegate outOfMemoryDelegate, ExceptionDelegate overflowDelegate, ExceptionDelegate systemExceptionDelegate);

		[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_RcsFileServices_Globals")]
		public static extern void SWIGRegisterExceptionCallbacksArgument_RcsFileServices_Globals(ExceptionArgumentDelegate argumentDelegate, ExceptionArgumentDelegate argumentNullDelegate, ExceptionArgumentDelegate argumentOutOfRangeDelegate);

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
			SWIGRegisterExceptionCallbacks_RcsFileServices_Globals(applicationDelegate, arithmeticDelegate, divideByZeroDelegate, indexOutOfRangeDelegate, invalidCastDelegate, invalidOperationDelegate, ioDelegate, nullReferenceDelegate, outOfMemoryDelegate, overflowDelegate, systemDelegate);
			SWIGRegisterExceptionCallbacksArgument_RcsFileServices_Globals(argumentDelegate, argumentNullDelegate, argumentOutOfRangeDelegate);
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

		[DllImport("OdSwig_RcsFileServices_26.10_17.dll")]
		public static extern void SWIGRegisterStringCallback_RcsFileServices_Globals(SWIGStringDelegate stringDelegate);

		private static string CreateString(string cString)
		{
			return cString;
		}

		static SWIGStringHelper()
		{
			stringDelegate = CreateString;
			SWIGRegisterStringCallback_RcsFileServices_Globals(stringDelegate);
		}
	}

	private class CustomExceptionHelper
	{
		public delegate void CustomExceptionDelegate(IntPtr NewContext);

		private static CustomExceptionDelegate customDelegate;

		[DllImport("OdSwig_RcsFileServices_26.10_17.dll")]
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

	static RcsFileServices_GlobalsPINVOKE()
	{
		swigExceptionHelper = new SWIGExceptionHelper();
		swigStringHelper = new SWIGStringHelper();
		exceptionHelper = new CustomExceptionHelper();
	}

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_UINT_MAX_get___")]
	public static extern uint UINT_MAX_get();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_ULONG_MAX_get___")]
	public static extern uint ULONG_MAX_get();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices__MSC_VER_get___")]
	public static extern int _MSC_VER_get();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_ODCHAR_IS_INT16LE_get___")]
	public static extern int ODCHAR_IS_INT16LE_get();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OD_SIZEOF_INT_get___")]
	public static extern int OD_SIZEOF_INT_get();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OD_SIZEOF_LONG_get___")]
	public static extern int OD_SIZEOF_LONG_get();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_PERCENT18LONG_get___")]
	public static extern string PERCENT18LONG_get();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_HANDLEFORMAT_get___")]
	public static extern string HANDLEFORMAT_get();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_PRId64_get___")]
	public static extern string PRId64_get();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_PRIu64_get___")]
	public static extern string PRIu64_get();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_PRIx64_get___")]
	public static extern string PRIx64_get();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_PRIX64_get___")]
	public static extern string PRIX64_get();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OD_SIZEOF_PTR_get___")]
	public static extern int OD_SIZEOF_PTR_get();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_throw_native_exception_string___")]
	public static extern void throw_native_exception_string([MarshalAs(UnmanagedType.LPWStr)] string jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_throw_native_OdError__SWIG_0___")]
	public static extern void throw_native_OdError__SWIG_0(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_throw_native_OdError__SWIG_1___")]
	public static extern void throw_native_OdError__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_throw_native_OdError__SWIG_2___")]
	public static extern void throw_native_OdError__SWIG_2(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_sec_set___")]
	public static extern void tm_tm_sec_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_sec_get___")]
	public static extern int tm_tm_sec_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_min_set___")]
	public static extern void tm_tm_min_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_min_get___")]
	public static extern int tm_tm_min_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_hour_set___")]
	public static extern void tm_tm_hour_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_hour_get___")]
	public static extern int tm_tm_hour_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_mday_set___")]
	public static extern void tm_tm_mday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_mday_get___")]
	public static extern int tm_tm_mday_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_mon_set___")]
	public static extern void tm_tm_mon_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_mon_get___")]
	public static extern int tm_tm_mon_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_year_set___")]
	public static extern void tm_tm_year_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_year_get___")]
	public static extern int tm_tm_year_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_wday_set___")]
	public static extern void tm_tm_wday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_wday_get___")]
	public static extern int tm_tm_wday_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_yday_set___")]
	public static extern void tm_tm_yday_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_yday_get___")]
	public static extern int tm_tm_yday_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_isdst_set___")]
	public static extern void tm_tm_isdst_set(HandleRef jarg1, int jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_tm_tm_isdst_get___")]
	public static extern int tm_tm_isdst_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_tm___")]
	public static extern IntPtr new_tm();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_tm___")]
	public static extern void delete_tm(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdRcsPointDataReceiver___")]
	public static extern void delete_OdRcsPointDataReceiver(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsPointDataReceiver_setNumberOfPoints___")]
	public static extern void OdRcsPointDataReceiver_setNumberOfPoints(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsPointDataReceiver_setPoint___")]
	public static extern void OdRcsPointDataReceiver_setPoint(HandleRef jarg1, uint jarg2, float jarg3, float jarg4, float jarg5, byte jarg6, byte jarg7, byte jarg8, ushort jarg9, byte jarg10);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdRcsPointDataIterator___")]
	public static extern void delete_OdRcsPointDataIterator(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsPointDataIterator_start___")]
	public static extern void OdRcsPointDataIterator_start(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsPointDataIterator_done___")]
	public static extern bool OdRcsPointDataIterator_done(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsPointDataIterator_getPoints__SWIG_0___")]
	public static extern uint OdRcsPointDataIterator_getPoints__SWIG_0(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3, uint jarg4);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsPointDataIterator_getPoints__SWIG_1___")]
	public static extern uint OdRcsPointDataIterator_getPoints__SWIG_1(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4, uint jarg5);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsPointDataIterator_getPoints__SWIG_2___")]
	public static extern uint OdRcsPointDataIterator_getPoints__SWIG_2(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4, IntPtr jarg5, uint jarg6);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsPointDataIterator_getPoints__SWIG_3___")]
	public static extern uint OdRcsPointDataIterator_getPoints__SWIG_3(HandleRef jarg1, HandleRef jarg2, uint jarg3);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsPointDataIterator_getRealClassName___")]
	public static extern string OdRcsPointDataIterator_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdRcsPointDataIterator___")]
	public static extern IntPtr new_OdRcsPointDataIterator();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsPointDataIterator_director_connect___")]
	public static extern void OdRcsPointDataIterator_director_connect(HandleRef jarg1, OdRcsPointDataIterator.SwigDelegateOdRcsPointDataIterator_0 delegate0, OdRcsPointDataIterator.SwigDelegateOdRcsPointDataIterator_1 delegate1, OdRcsPointDataIterator.SwigDelegateOdRcsPointDataIterator_2 delegate2, OdRcsPointDataIterator.SwigDelegateOdRcsPointDataIterator_3 delegate3, OdRcsPointDataIterator.SwigDelegateOdRcsPointDataIterator_4 delegate4, OdRcsPointDataIterator.SwigDelegateOdRcsPointDataIterator_5 delegate5);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdRcsVoxel___")]
	public static extern void delete_OdRcsVoxel(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxel_getTotalNumberOfPoints___")]
	public static extern uint OdRcsVoxel_getTotalNumberOfPoints(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxel_getPointDataIterator___")]
	public static extern IntPtr OdRcsVoxel_getPointDataIterator(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxel_getExtents___")]
	public static extern IntPtr OdRcsVoxel_getExtents(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxel_getAccumulatedExtents___")]
	public static extern IntPtr OdRcsVoxel_getAccumulatedExtents(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxel_getAccumulatedExtentsSwigExplicitOdRcsVoxel___")]
	public static extern IntPtr OdRcsVoxel_getAccumulatedExtentsSwigExplicitOdRcsVoxel(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxel_getNumberOfPointsForLOD___")]
	public static extern uint OdRcsVoxel_getNumberOfPointsForLOD(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxel_getNumberOfPointsForLODSwigExplicitOdRcsVoxel___")]
	public static extern uint OdRcsVoxel_getNumberOfPointsForLODSwigExplicitOdRcsVoxel(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxel_getRealClassName___")]
	public static extern string OdRcsVoxel_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdRcsVoxel___")]
	public static extern IntPtr new_OdRcsVoxel();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxel_director_connect___")]
	public static extern void OdRcsVoxel_director_connect(HandleRef jarg1, OdRcsVoxel.SwigDelegateOdRcsVoxel_0 delegate0, OdRcsVoxel.SwigDelegateOdRcsVoxel_1 delegate1, OdRcsVoxel.SwigDelegateOdRcsVoxel_2 delegate2, OdRcsVoxel.SwigDelegateOdRcsVoxel_3 delegate3, OdRcsVoxel.SwigDelegateOdRcsVoxel_4 delegate4);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdRcsVoxelIterator___")]
	public static extern void delete_OdRcsVoxelIterator(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxelIterator_start___")]
	public static extern void OdRcsVoxelIterator_start(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxelIterator_step___")]
	public static extern void OdRcsVoxelIterator_step(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxelIterator_done___")]
	public static extern bool OdRcsVoxelIterator_done(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxelIterator_getVoxel___")]
	public static extern IntPtr OdRcsVoxelIterator_getVoxel(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxelIterator_getRealClassName___")]
	public static extern string OdRcsVoxelIterator_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdRcsVoxelIterator___")]
	public static extern IntPtr new_OdRcsVoxelIterator();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVoxelIterator_director_connect___")]
	public static extern void OdRcsVoxelIterator_director_connect(HandleRef jarg1, OdRcsVoxelIterator.SwigDelegateOdRcsVoxelIterator_0 delegate0, OdRcsVoxelIterator.SwigDelegateOdRcsVoxelIterator_1 delegate1, OdRcsVoxelIterator.SwigDelegateOdRcsVoxelIterator_2 delegate2, OdRcsVoxelIterator.SwigDelegateOdRcsVoxelIterator_3 delegate3);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdPointCloudScanDatabase___")]
	public static extern void delete_OdPointCloudScanDatabase(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getScanDatabaseFilePath___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string OdPointCloudScanDatabase_getScanDatabaseFilePath(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getTotalAmountOfPoints___")]
	public static extern ulong OdPointCloudScanDatabase_getTotalAmountOfPoints(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getScanId___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string OdPointCloudScanDatabase_getScanId(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_isLidarData___")]
	public static extern bool OdPointCloudScanDatabase_isLidarData(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getVoxelIterator___")]
	public static extern IntPtr OdPointCloudScanDatabase_getVoxelIterator(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getAmountOfVoxels___")]
	public static extern ulong OdPointCloudScanDatabase_getAmountOfVoxels(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getTranslation___")]
	public static extern IntPtr OdPointCloudScanDatabase_getTranslation(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getRotation___")]
	public static extern IntPtr OdPointCloudScanDatabase_getRotation(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getScale___")]
	public static extern IntPtr OdPointCloudScanDatabase_getScale(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getTransformMatrix___")]
	public static extern IntPtr OdPointCloudScanDatabase_getTransformMatrix(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_hasRGB___")]
	public static extern bool OdPointCloudScanDatabase_hasRGB(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_hasNormals___")]
	public static extern bool OdPointCloudScanDatabase_hasNormals(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_hasIntensity___")]
	public static extern bool OdPointCloudScanDatabase_hasIntensity(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getExtents___")]
	public static extern IntPtr OdPointCloudScanDatabase_getExtents(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getTransformedExtents___")]
	public static extern IntPtr OdPointCloudScanDatabase_getTransformedExtents(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getNormalizeIntensity___")]
	public static extern bool OdPointCloudScanDatabase_getNormalizeIntensity(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getMaxIntensity___")]
	public static extern float OdPointCloudScanDatabase_getMaxIntensity(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getMinIntensity___")]
	public static extern float OdPointCloudScanDatabase_getMinIntensity(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getRangeImageWidth___")]
	public static extern uint OdPointCloudScanDatabase_getRangeImageWidth(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getRangeImageHeight___")]
	public static extern uint OdPointCloudScanDatabase_getRangeImageHeight(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_getRealClassName___")]
	public static extern string OdPointCloudScanDatabase_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdPointCloudScanDatabase___")]
	public static extern IntPtr new_OdPointCloudScanDatabase();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanDatabase_director_connect___")]
	public static extern void OdPointCloudScanDatabase_director_connect(HandleRef jarg1, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_0 delegate0, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_1 delegate1, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_2 delegate2, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_3 delegate3, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_4 delegate4, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_5 delegate5, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_6 delegate6, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_7 delegate7, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_8 delegate8, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_9 delegate9, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_10 delegate10, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_11 delegate11, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_12 delegate12, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_13 delegate13, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_14 delegate14, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_15 delegate15, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_16 delegate16, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_17 delegate17, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_18 delegate18, OdPointCloudScanDatabase.SwigDelegateOdPointCloudScanDatabase_19 delegate19);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdPointCloudScanIterator___")]
	public static extern void delete_OdPointCloudScanIterator(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanIterator_start___")]
	public static extern void OdPointCloudScanIterator_start(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanIterator_step___")]
	public static extern void OdPointCloudScanIterator_step(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanIterator_done___")]
	public static extern bool OdPointCloudScanIterator_done(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanIterator_getScanDb___")]
	public static extern IntPtr OdPointCloudScanIterator_getScanDb(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanIterator_getScanTitle___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string OdPointCloudScanIterator_getScanTitle(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanIterator_getScanIsVisible___")]
	public static extern bool OdPointCloudScanIterator_getScanIsVisible(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanIterator_getScanTransform___")]
	public static extern IntPtr OdPointCloudScanIterator_getScanTransform(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanIterator_getRealClassName___")]
	public static extern string OdPointCloudScanIterator_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdPointCloudScanIterator___")]
	public static extern IntPtr new_OdPointCloudScanIterator();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudScanIterator_director_connect___")]
	public static extern void OdPointCloudScanIterator_director_connect(HandleRef jarg1, OdPointCloudScanIterator.SwigDelegateOdPointCloudScanIterator_0 delegate0, OdPointCloudScanIterator.SwigDelegateOdPointCloudScanIterator_1 delegate1, OdPointCloudScanIterator.SwigDelegateOdPointCloudScanIterator_2 delegate2, OdPointCloudScanIterator.SwigDelegateOdPointCloudScanIterator_3 delegate3, OdPointCloudScanIterator.SwigDelegateOdPointCloudScanIterator_4 delegate4, OdPointCloudScanIterator.SwigDelegateOdPointCloudScanIterator_5 delegate5, OdPointCloudScanIterator.SwigDelegateOdPointCloudScanIterator_6 delegate6);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdRcsVisibleVoxelsIterator___")]
	public static extern void delete_OdRcsVisibleVoxelsIterator(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVisibleVoxelsIterator_start___")]
	public static extern void OdRcsVisibleVoxelsIterator_start(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVisibleVoxelsIterator_step___")]
	public static extern void OdRcsVisibleVoxelsIterator_step(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVisibleVoxelsIterator_done___")]
	public static extern bool OdRcsVisibleVoxelsIterator_done(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVisibleVoxelsIterator_getVoxelBuffer___")]
	public static extern void OdRcsVisibleVoxelsIterator_getVoxelBuffer(HandleRef jarg1, uint jarg2, out IntPtr jarg3, out uint jarg4, out uint jarg5, out ulong jarg6, out uint jarg7, out uint jarg8);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVisibleVoxelsIterator_getNumberOfLoadedPointsToDraw___")]
	public static extern uint OdRcsVisibleVoxelsIterator_getNumberOfLoadedPointsToDraw(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVisibleVoxelsIterator_hasPointsLoaded___")]
	public static extern bool OdRcsVisibleVoxelsIterator_hasPointsLoaded(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVisibleVoxelsIterator_getRealClassName___")]
	public static extern string OdRcsVisibleVoxelsIterator_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdRcsVisibleVoxelsIterator___")]
	public static extern IntPtr new_OdRcsVisibleVoxelsIterator();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsVisibleVoxelsIterator_director_connect___")]
	public static extern void OdRcsVisibleVoxelsIterator_director_connect(HandleRef jarg1, OdRcsVisibleVoxelsIterator.SwigDelegateOdRcsVisibleVoxelsIterator_0 delegate0, OdRcsVisibleVoxelsIterator.SwigDelegateOdRcsVisibleVoxelsIterator_1 delegate1, OdRcsVisibleVoxelsIterator.SwigDelegateOdRcsVisibleVoxelsIterator_2 delegate2, OdRcsVisibleVoxelsIterator.SwigDelegateOdRcsVisibleVoxelsIterator_3 delegate3, OdRcsVisibleVoxelsIterator.SwigDelegateOdRcsVisibleVoxelsIterator_4 delegate4, OdRcsVisibleVoxelsIterator.SwigDelegateOdRcsVisibleVoxelsIterator_5 delegate5);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdPointCloudProjectDatabase___")]
	public static extern void delete_OdPointCloudProjectDatabase(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getProjectDatabaseFilePath___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string OdPointCloudProjectDatabase_getProjectDatabaseFilePath(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getScanIterator___")]
	public static extern IntPtr OdPointCloudProjectDatabase_getScanIterator(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getAllRcsFilePaths___")]
	public static extern void OdPointCloudProjectDatabase_getAllRcsFilePaths(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getAllRcsRelativeFilePaths___")]
	public static extern void OdPointCloudProjectDatabase_getAllRcsRelativeFilePaths(HandleRef jarg1, IntPtr jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getGlobalTransformation___")]
	public static extern IntPtr OdPointCloudProjectDatabase_getGlobalTransformation(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getScanTransform___")]
	public static extern IntPtr OdPointCloudProjectDatabase_getScanTransform(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getTotalRegionsCount___")]
	public static extern uint OdPointCloudProjectDatabase_getTotalRegionsCount(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getTotalScansCount___")]
	public static extern uint OdPointCloudProjectDatabase_getTotalScansCount(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getCoordinateSystemName___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string OdPointCloudProjectDatabase_getCoordinateSystemName(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_hasRGB___")]
	public static extern sbyte OdPointCloudProjectDatabase_hasRGB(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_hasNormals___")]
	public static extern sbyte OdPointCloudProjectDatabase_hasNormals(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_hasIntensity___")]
	public static extern sbyte OdPointCloudProjectDatabase_hasIntensity(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getRcsFilePath___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string OdPointCloudProjectDatabase_getRcsFilePath(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getRcsRelativeFilePath___")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string OdPointCloudProjectDatabase_getRcsRelativeFilePath(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getTotalAmountOfPoints___")]
	public static extern ulong OdPointCloudProjectDatabase_getTotalAmountOfPoints(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getExtents___")]
	public static extern IntPtr OdPointCloudProjectDatabase_getExtents(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_writeAllXmlDataToStream___")]
	public static extern void OdPointCloudProjectDatabase_writeAllXmlDataToStream(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_getRealClassName___")]
	public static extern string OdPointCloudProjectDatabase_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdPointCloudProjectDatabase___")]
	public static extern IntPtr new_OdPointCloudProjectDatabase();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectDatabase_director_connect___")]
	public static extern void OdPointCloudProjectDatabase_director_connect(HandleRef jarg1, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_0 delegate0, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_1 delegate1, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_2 delegate2, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_3 delegate3, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_4 delegate4, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_5 delegate5, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_6 delegate6, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_7 delegate7, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_8 delegate8, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_9 delegate9, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_10 delegate10, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_11 delegate11, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_12 delegate12, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_13 delegate13, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_14 delegate14, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_15 delegate15, OdPointCloudProjectDatabase.SwigDelegateOdPointCloudProjectDatabase_16 delegate16);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdPointCloudProjectScanStorage___")]
	public static extern void delete_OdPointCloudProjectScanStorage(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectScanStorage_getScanStreamByPath___")]
	public static extern IntPtr OdPointCloudProjectScanStorage_getScanStreamByPath(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdPointCloudProjectScanStorage___")]
	public static extern IntPtr new_OdPointCloudProjectScanStorage();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudProjectScanStorage_director_connect___")]
	public static extern void OdPointCloudProjectScanStorage_director_connect(HandleRef jarg1, OdPointCloudProjectScanStorage.SwigDelegateOdPointCloudProjectScanStorage_0 delegate0);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_cast___")]
	public static extern IntPtr OdPointCloudDatabaseReceiver_cast(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_desc___")]
	public static extern IntPtr OdPointCloudDatabaseReceiver_desc();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_isA___")]
	public static extern IntPtr OdPointCloudDatabaseReceiver_isA(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_isASwigExplicitOdPointCloudDatabaseReceiver___")]
	public static extern IntPtr OdPointCloudDatabaseReceiver_isASwigExplicitOdPointCloudDatabaseReceiver(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_queryX___")]
	public static extern IntPtr OdPointCloudDatabaseReceiver_queryX(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_queryXSwigExplicitOdPointCloudDatabaseReceiver___")]
	public static extern IntPtr OdPointCloudDatabaseReceiver_queryXSwigExplicitOdPointCloudDatabaseReceiver(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_createObject___")]
	public static extern IntPtr OdPointCloudDatabaseReceiver_createObject();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdPointCloudDatabaseReceiver___")]
	public static extern void delete_OdPointCloudDatabaseReceiver(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_receiveIndividualScanDb__SWIG_0___")]
	public static extern void OdPointCloudDatabaseReceiver_receiveIndividualScanDb__SWIG_0(HandleRef jarg1, HandleRef jarg2, bool jarg3);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_receiveIndividualScanDb__SWIG_1___")]
	public static extern void OdPointCloudDatabaseReceiver_receiveIndividualScanDb__SWIG_1(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_receiveProjDb__SWIG_0___")]
	public static extern void OdPointCloudDatabaseReceiver_receiveProjDb__SWIG_0(HandleRef jarg1, HandleRef jarg2, bool jarg3);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_receiveProjDb__SWIG_1___")]
	public static extern void OdPointCloudDatabaseReceiver_receiveProjDb__SWIG_1(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_getRealClassName___")]
	public static extern string OdPointCloudDatabaseReceiver_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdPointCloudDatabaseReceiver___")]
	public static extern IntPtr new_OdPointCloudDatabaseReceiver();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_director_connect___")]
	public static extern void OdPointCloudDatabaseReceiver_director_connect(HandleRef jarg1, OdPointCloudDatabaseReceiver.SwigDelegateOdPointCloudDatabaseReceiver_0 delegate0, OdPointCloudDatabaseReceiver.SwigDelegateOdPointCloudDatabaseReceiver_1 delegate1, OdPointCloudDatabaseReceiver.SwigDelegateOdPointCloudDatabaseReceiver_2 delegate2, OdPointCloudDatabaseReceiver.SwigDelegateOdPointCloudDatabaseReceiver_3 delegate3, OdPointCloudDatabaseReceiver.SwigDelegateOdPointCloudDatabaseReceiver_4 delegate4, OdPointCloudDatabaseReceiver.SwigDelegateOdPointCloudDatabaseReceiver_5 delegate5, OdPointCloudDatabaseReceiver.SwigDelegateOdPointCloudDatabaseReceiver_6 delegate6);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdRcsDataManager___")]
	public static extern void delete_OdRcsDataManager(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsDataManager_getScanDb___")]
	public static extern IntPtr OdRcsDataManager_getScanDb(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsDataManager_pointsCount___")]
	public static extern ulong OdRcsDataManager_pointsCount(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsDataManager_updateListOfVisibleVoxels___")]
	public static extern void OdRcsDataManager_updateListOfVisibleVoxels(HandleRef jarg1, HandleRef jarg2, ushort jarg3);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsDataManager_loadPointsForVisibleVoxels__SWIG_0___")]
	public static extern void OdRcsDataManager_loadPointsForVisibleVoxels__SWIG_0(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsDataManager_loadPointsForVisibleVoxels__SWIG_1___")]
	public static extern void OdRcsDataManager_loadPointsForVisibleVoxels__SWIG_1(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsDataManager_newVisibleVoxelsIterator___")]
	public static extern IntPtr OdRcsDataManager_newVisibleVoxelsIterator(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsDataManager_newGiPointCloud___")]
	public static extern IntPtr OdRcsDataManager_newGiPointCloud(HandleRef jarg1, ushort jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsDataManager_getRealClassName___")]
	public static extern string OdRcsDataManager_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdRcsDataManager___")]
	public static extern IntPtr new_OdRcsDataManager();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRcsDataManager_director_connect___")]
	public static extern void OdRcsDataManager_director_connect(HandleRef jarg1, OdRcsDataManager.SwigDelegateOdRcsDataManager_0 delegate0, OdRcsDataManager.SwigDelegateOdRcsDataManager_1 delegate1, OdRcsDataManager.SwigDelegateOdRcsDataManager_2 delegate2, OdRcsDataManager.SwigDelegateOdRcsDataManager_3 delegate3, OdRcsDataManager.SwigDelegateOdRcsDataManager_4 delegate4, OdRcsDataManager.SwigDelegateOdRcsDataManager_5 delegate5, OdRcsDataManager.SwigDelegateOdRcsDataManager_6 delegate6);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdSourcePoint___")]
	public static extern IntPtr new_OdSourcePoint();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdSourcePoint___")]
	public static extern void delete_OdSourcePoint(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdSourcePoint_m_coord_set___")]
	public static extern void OdSourcePoint_m_coord_set(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdSourcePoint_m_coord_get___")]
	public static extern IntPtr OdSourcePoint_m_coord_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdSourcePoint_m_color_set___")]
	public static extern void OdSourcePoint_m_color_set(HandleRef jarg1, uint jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdSourcePoint_m_color_get___")]
	public static extern uint OdSourcePoint_m_color_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdSourcePoint_m_intensity_set___")]
	public static extern void OdSourcePoint_m_intensity_set(HandleRef jarg1, float jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdSourcePoint_m_intensity_get___")]
	public static extern float OdSourcePoint_m_intensity_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdSourcePoint_getRealClassName___")]
	public static extern string OdSourcePoint_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdPointCloudConverterParams___")]
	public static extern IntPtr new_OdPointCloudConverterParams();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdPointCloudConverterParams___")]
	public static extern void delete_OdPointCloudConverterParams(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudConverterParams_m_intensityBottom_set___")]
	public static extern void OdPointCloudConverterParams_m_intensityBottom_set(HandleRef jarg1, float jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudConverterParams_m_intensityBottom_get___")]
	public static extern float OdPointCloudConverterParams_m_intensityBottom_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudConverterParams_m_intensityUpper_set___")]
	public static extern void OdPointCloudConverterParams_m_intensityUpper_set(HandleRef jarg1, float jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudConverterParams_m_intensityUpper_get___")]
	public static extern float OdPointCloudConverterParams_m_intensityUpper_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudConverterParams_m_isTerrestrial_set___")]
	public static extern void OdPointCloudConverterParams_m_isTerrestrial_set(HandleRef jarg1, bool jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudConverterParams_m_isTerrestrial_get___")]
	public static extern bool OdPointCloudConverterParams_m_isTerrestrial_get(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudConverterParams_getRealClassName___")]
	public static extern string OdPointCloudConverterParams_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdSourcePointIterator___")]
	public static extern void delete_OdSourcePointIterator(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdSourcePointIterator_start___")]
	public static extern void OdSourcePointIterator_start(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdSourcePointIterator_done___")]
	public static extern bool OdSourcePointIterator_done(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdSourcePointIterator_getPoint___")]
	public static extern bool OdSourcePointIterator_getPoint(HandleRef jarg1, ref IntPtr jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdSourcePointIterator_getRealClassName___")]
	public static extern string OdSourcePointIterator_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdSourcePointIterator___")]
	public static extern IntPtr new_OdSourcePointIterator();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdSourcePointIterator_director_connect___")]
	public static extern void OdSourcePointIterator_director_connect(HandleRef jarg1, OdSourcePointIterator.SwigDelegateOdSourcePointIterator_0 delegate0, OdSourcePointIterator.SwigDelegateOdSourcePointIterator_1 delegate1, OdSourcePointIterator.SwigDelegateOdSourcePointIterator_2 delegate2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdPointCloudDataSource___")]
	public static extern void delete_OdPointCloudDataSource(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDataSource_pointsCount___")]
	public static extern ulong OdPointCloudDataSource_pointsCount(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDataSource_getUnits___")]
	public static extern int OdPointCloudDataSource_getUnits(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDataSource_newSourcePointIterator___")]
	public static extern IntPtr OdPointCloudDataSource_newSourcePointIterator(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDataSource_getRealClassName___")]
	public static extern string OdPointCloudDataSource_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdPointCloudDataSource___")]
	public static extern IntPtr new_OdPointCloudDataSource();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDataSource_director_connect___")]
	public static extern void OdPointCloudDataSource_director_connect(HandleRef jarg1, OdPointCloudDataSource.SwigDelegateOdPointCloudDataSource_0 delegate0, OdPointCloudDataSource.SwigDelegateOdPointCloudDataSource_1 delegate1, OdPointCloudDataSource.SwigDelegateOdPointCloudDataSource_2 delegate2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdPointCloudConverter___")]
	public static extern void delete_OdPointCloudConverter(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudConverter_convertToRcsFormat__SWIG_0___")]
	public static extern void OdPointCloudConverter_convertToRcsFormat__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, bool jarg3);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudConverter_convertToRcsFormat__SWIG_1___")]
	public static extern void OdPointCloudConverter_convertToRcsFormat__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudConverter_getRealClassName___")]
	public static extern string OdPointCloudConverter_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdPointCloudConverter___")]
	public static extern IntPtr new_OdPointCloudConverter();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudConverter_director_connect___")]
	public static extern void OdPointCloudConverter_director_connect(HandleRef jarg1, OdPointCloudConverter.SwigDelegateOdPointCloudConverter_0 delegate0, OdPointCloudConverter.SwigDelegateOdPointCloudConverter_1 delegate1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_readRcsFile__SWIG_0___")]
	public static extern IntPtr OdRxRcsFileServices_readRcsFile__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, HandleRef jarg3);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_readRcsFile__SWIG_1___")]
	public static extern IntPtr OdRxRcsFileServices_readRcsFile__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_readRcsFile__SWIG_2___")]
	public static extern IntPtr OdRxRcsFileServices_readRcsFile__SWIG_2(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_readRcsFile__SWIG_3___")]
	public static extern IntPtr OdRxRcsFileServices_readRcsFile__SWIG_3(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_readRcpFile__SWIG_0___")]
	public static extern IntPtr OdRxRcsFileServices_readRcpFile__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, HandleRef jarg3, HandleRef jarg4);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_readRcpFile__SWIG_1___")]
	public static extern IntPtr OdRxRcsFileServices_readRcpFile__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, HandleRef jarg3);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_readRcpFile__SWIG_2___")]
	public static extern IntPtr OdRxRcsFileServices_readRcpFile__SWIG_2(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_readRcpFile__SWIG_3___")]
	public static extern IntPtr OdRxRcsFileServices_readRcpFile__SWIG_3(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getPointCloudConverter__SWIG_0___")]
	public static extern IntPtr OdRxRcsFileServices_getPointCloudConverter__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getPointCloudConverter__SWIG_1___")]
	public static extern IntPtr OdRxRcsFileServices_getPointCloudConverter__SWIG_1(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getRcsDataManager__SWIG_0___")]
	public static extern IntPtr OdRxRcsFileServices_getRcsDataManager__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getRcsDataManager__SWIG_1___")]
	public static extern IntPtr OdRxRcsFileServices_getRcsDataManager__SWIG_1(HandleRef jarg1, HandleRef jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getPointCloudDataSource__SWIG_0___")]
	public static extern IntPtr OdRxRcsFileServices_getPointCloudDataSource__SWIG_0(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, uint jarg4, int jarg5, IntPtr jarg6, IntPtr jarg7, uint jarg8, uint jarg9, [MarshalAs(UnmanagedType.LPWStr)] string jarg10);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getPointCloudDataSource__SWIG_1___")]
	public static extern IntPtr OdRxRcsFileServices_getPointCloudDataSource__SWIG_1(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, uint jarg4, int jarg5, IntPtr jarg6, IntPtr jarg7, uint jarg8, uint jarg9);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getPointCloudDataSource__SWIG_2___")]
	public static extern IntPtr OdRxRcsFileServices_getPointCloudDataSource__SWIG_2(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, uint jarg4, int jarg5, IntPtr jarg6, IntPtr jarg7, uint jarg8);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getPointCloudDataSource__SWIG_3___")]
	public static extern IntPtr OdRxRcsFileServices_getPointCloudDataSource__SWIG_3(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, uint jarg4, int jarg5, IntPtr jarg6, IntPtr jarg7);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getPointCloudDataSource__SWIG_4___")]
	public static extern IntPtr OdRxRcsFileServices_getPointCloudDataSource__SWIG_4(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, uint jarg4, int jarg5, IntPtr jarg6);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getPointCloudDataSource__SWIG_5___")]
	public static extern IntPtr OdRxRcsFileServices_getPointCloudDataSource__SWIG_5(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, uint jarg4, int jarg5);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getPointCloudDataSource__SWIG_6___")]
	public static extern IntPtr OdRxRcsFileServices_getPointCloudDataSource__SWIG_6(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3, uint jarg4);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getPointCloudDataSource__SWIG_7___")]
	public static extern IntPtr OdRxRcsFileServices_getPointCloudDataSource__SWIG_7(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2, int jarg3);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getPointCloudDataSource__SWIG_8___")]
	public static extern IntPtr OdRxRcsFileServices_getPointCloudDataSource__SWIG_8(HandleRef jarg1, [MarshalAs(UnmanagedType.LPWStr)] string jarg2);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getRcpFileWriter___")]
	public static extern IntPtr OdRxRcsFileServices_getRcpFileWriter(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_getRealClassName___")]
	public static extern string OdRxRcsFileServices_getRealClassName(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_new_OdRxRcsFileServices___")]
	public static extern IntPtr new_OdRxRcsFileServices();

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_delete_OdRxRcsFileServices___")]
	public static extern void delete_OdRxRcsFileServices(HandleRef jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_director_connect___")]
	public static extern void OdRxRcsFileServices_director_connect(HandleRef jarg1, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_0 delegate0, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_1 delegate1, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_2 delegate2, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_3 delegate3, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_4 delegate4, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_5 delegate5, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_6 delegate6, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_7 delegate7, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_8 delegate8, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_9 delegate9, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_10 delegate10, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_11 delegate11, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_12 delegate12, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_13 delegate13, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_14 delegate14, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_15 delegate15, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_16 delegate16, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_17 delegate17, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_18 delegate18, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_19 delegate19, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_20 delegate20, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_21 delegate21, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_22 delegate22, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_23 delegate23, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_24 delegate24, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_25 delegate25, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_26 delegate26, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_27 delegate27, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_28 delegate28, OdRxRcsFileServices.SwigDelegateOdRxRcsFileServices_29 delegate29);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdPointCloudDatabaseReceiver_SWIGUpcast___")]
	public static extern IntPtr OdPointCloudDatabaseReceiver_SWIGUpcast(IntPtr jarg1);

	[DllImport("OdSwig_RcsFileServices_26.10_17.dll", EntryPoint = "CSharp_ODAfPointCloudfRcsFileServices_OdRxRcsFileServices_SWIGUpcast___")]
	public static extern IntPtr OdRxRcsFileServices_SWIGUpcast(IntPtr jarg1);
}

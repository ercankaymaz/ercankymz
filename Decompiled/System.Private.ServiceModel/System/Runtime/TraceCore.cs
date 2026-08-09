using System.Globalization;
using System.Resources;
using System.Runtime.Diagnostics;
using System.ServiceModel;

namespace System.Runtime;

internal class TraceCore
{
	private const int MaxExceptionStringLength = 28672;

	private static ResourceManager resourceManager;

	private static CultureInfo resourceCulture;

	private static object syncLock = new object();

	private static ResourceManager ResourceManager
	{
		get
		{
			if (resourceManager == null)
			{
				resourceManager = new ResourceManager("System.Runtime.TraceCore", typeof(TraceCore).Assembly());
			}
			return resourceManager;
		}
	}

	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	private TraceCore()
	{
	}

	internal static bool HandledExceptionIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.HandledExceptionIsEnabled();
	}

	internal static void HandledException(EtwDiagnosticTrace trace, string param0, Exception exception)
	{
		string serializedException = EtwDiagnosticTrace.ExceptionToTraceString(exception, 28672);
		WcfEventSource.Instance.HandledException(param0, serializedException);
	}

	internal static void ShipAssertExceptionMessage(EtwDiagnosticTrace trace, string param0)
	{
		WcfEventSource.Instance.ShipAssertExceptionMessage(param0);
	}

	internal static bool ThrowingExceptionIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.ThrowingExceptionIsEnabled();
	}

	internal static void ThrowingException(EtwDiagnosticTrace trace, string param0, string param1, Exception exception)
	{
		string serializedException = EtwDiagnosticTrace.ExceptionToTraceString(exception, 28672);
		WcfEventSource.Instance.ThrowingException(param0, param1, serializedException);
	}

	internal static bool UnhandledExceptionIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.UnhandledExceptionIsEnabled();
	}

	internal static void UnhandledException(EtwDiagnosticTrace trace, string param0, Exception exception)
	{
		string serializedException = EtwDiagnosticTrace.ExceptionToTraceString(exception, 28672);
		WcfEventSource.Instance.UnhandledException(param0, serializedException);
	}

	internal static bool TraceCodeEventLogCriticalIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.TraceCodeEventLogCriticalIsEnabled();
	}

	internal static void TraceCodeEventLogCritical(EtwDiagnosticTrace trace, TraceRecord traceRecord)
	{
		WcfEventSource.Instance.TraceCodeEventLogCritical(traceRecord.EventId);
	}

	internal static bool TraceCodeEventLogErrorIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.TraceCodeEventLogErrorIsEnabled();
	}

	internal static void TraceCodeEventLogError(EtwDiagnosticTrace trace, TraceRecord traceRecord)
	{
		WcfEventSource.Instance.TraceCodeEventLogError(traceRecord.EventId);
	}

	internal static bool TraceCodeEventLogInfoIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.TraceCodeEventLogInfoIsEnabled();
	}

	internal static void TraceCodeEventLogInfo(EtwDiagnosticTrace trace, TraceRecord traceRecord)
	{
		WcfEventSource.Instance.TraceCodeEventLogInfo(traceRecord.EventId);
	}

	internal static bool TraceCodeEventLogVerboseIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.TraceCodeEventLogVerboseIsEnabled();
	}

	internal static void TraceCodeEventLogVerbose(EtwDiagnosticTrace trace, TraceRecord traceRecord)
	{
		WcfEventSource.Instance.TraceCodeEventLogVerbose(traceRecord.EventId);
	}

	internal static bool TraceCodeEventLogWarningIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.TraceCodeEventLogWarningIsEnabled();
	}

	internal static void TraceCodeEventLogWarning(EtwDiagnosticTrace trace, TraceRecord traceRecord)
	{
		WcfEventSource.Instance.TraceCodeEventLogWarning(traceRecord.EventId);
	}

	internal static bool HandledExceptionWarningIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.HandledExceptionWarningIsEnabled();
	}

	internal static void HandledExceptionWarning(EtwDiagnosticTrace trace, string param0, Exception exception)
	{
		string serializedException = EtwDiagnosticTrace.ExceptionToTraceString(exception, 28672);
		WcfEventSource.Instance.HandledExceptionWarning(param0, serializedException);
	}

	internal static bool BufferPoolAllocationIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.BufferPoolAllocationIsEnabled();
	}

	internal static void BufferPoolAllocation(EtwDiagnosticTrace trace, int Size)
	{
		WcfEventSource.Instance.BufferPoolAllocation(Size);
	}

	internal static bool BufferPoolChangeQuotaIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.BufferPoolChangeQuotaIsEnabled();
	}

	internal static void BufferPoolChangeQuota(EtwDiagnosticTrace trace, int PoolSize, int Delta)
	{
		WcfEventSource.Instance.BufferPoolChangeQuota(PoolSize, Delta);
	}

	internal static bool ActionItemScheduledIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.ActionItemScheduledIsEnabled();
	}

	internal static void ActionItemScheduled(EtwDiagnosticTrace trace, EventTraceActivity eventTraceActivity)
	{
		WcfEventSource.Instance.ActionItemScheduled();
	}

	internal static bool ActionItemCallbackInvokedIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.ActionItemCallbackInvokedIsEnabled();
	}

	internal static void ActionItemCallbackInvoked(EtwDiagnosticTrace trace, EventTraceActivity eventTraceActivity)
	{
		WcfEventSource.Instance.ActionItemCallbackInvoked();
	}

	internal static bool HandledExceptionErrorIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.HandledExceptionErrorIsEnabled();
	}

	internal static void HandledExceptionError(EtwDiagnosticTrace trace, string param0, Exception exception)
	{
		string serializedException = EtwDiagnosticTrace.ExceptionToTraceString(exception, 28672);
		WcfEventSource.Instance.HandledExceptionError(param0, serializedException);
	}

	internal static bool HandledExceptionVerboseIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.HandledExceptionVerboseIsEnabled();
	}

	internal static void HandledExceptionVerbose(EtwDiagnosticTrace trace, string param0, Exception exception)
	{
		string serializedException = EtwDiagnosticTrace.ExceptionToTraceString(exception, 28672);
		WcfEventSource.Instance.HandledExceptionVerbose(param0, serializedException);
	}

	internal static bool EtwUnhandledExceptionIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.EtwUnhandledExceptionIsEnabled();
	}

	internal static void EtwUnhandledException(EtwDiagnosticTrace trace, string param0, Exception exception)
	{
		string serializedException = EtwDiagnosticTrace.ExceptionToTraceString(exception, 28672);
		WcfEventSource.Instance.EtwUnhandledException(param0, serializedException);
	}

	internal static bool ThrowingEtwExceptionIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.ThrowingEtwExceptionIsEnabled();
	}

	internal static void ThrowingEtwException(EtwDiagnosticTrace trace, string param0, string param1, Exception exception)
	{
		string serializedException = EtwDiagnosticTrace.ExceptionToTraceString(exception, 28672);
		WcfEventSource.Instance.ThrowingEtwException(param0, param1, serializedException);
	}

	internal static bool ThrowingEtwExceptionVerboseIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.ThrowingEtwExceptionVerboseIsEnabled();
	}

	internal static void ThrowingEtwExceptionVerbose(EtwDiagnosticTrace trace, string param0, string param1, Exception exception)
	{
		string serializedException = EtwDiagnosticTrace.ExceptionToTraceString(exception, 28672);
		WcfEventSource.Instance.ThrowingEtwExceptionVerbose(param0, param1, serializedException);
	}

	internal static bool ThrowingExceptionVerboseIsEnabled(EtwDiagnosticTrace trace)
	{
		return WcfEventSource.Instance.ThrowingExceptionVerboseIsEnabled();
	}

	internal static void ThrowingExceptionVerbose(EtwDiagnosticTrace trace, string param0, string param1, Exception exception)
	{
		string serializedException = EtwDiagnosticTrace.ExceptionToTraceString(exception, 28672);
		WcfEventSource.Instance.ThrowingExceptionVerbose(param0, param1, serializedException);
	}
}

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel;

internal static class DiagnosticUtility
{
	internal const string DefaultTraceListenerName = "Default";

	private static bool s_shouldUseActivity = false;

	private const string TraceSourceName = "TraceSourceNameToReplace";

	internal const string EventSourceName = "TraceSourceNameToReplace [COR_BUILD_MAJOR].[COR_BUILD_MINOR].[CLR_OFFICIAL_ASSEMBLY_NUMBER].0";

	private static ExceptionUtility s_exceptionUtility = null;

	private static object s_lockObject = new object();

	internal static bool ShouldUseActivity => s_shouldUseActivity;

	internal static bool ShouldTraceCritical => false;

	internal static bool ShouldTraceError => false;

	internal static bool ShouldTraceWarning => false;

	internal static bool ShouldTraceInformation => false;

	internal static bool ShouldTraceVerbose => false;

	internal static bool TracingEnabled => false;

	public static ExceptionUtility ExceptionUtility => s_exceptionUtility ?? GetExceptionUtility();

	internal static void TraceHandledException(Exception exception, TraceEventType traceEventType)
	{
		FxTrace.Exception.TraceHandledException(exception, traceEventType);
	}

	[Conditional("DEBUG")]
	internal static void DebugAssert(bool condition, string message)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	internal static void DebugAssert(string message)
	{
	}

	internal static bool ShouldTrace(TraceEventType type)
	{
		bool result = false;
		if (TracingEnabled)
		{
			switch (type)
			{
			case TraceEventType.Critical:
				result = ShouldTraceCritical;
				break;
			case TraceEventType.Error:
				result = ShouldTraceError;
				break;
			case TraceEventType.Warning:
				result = ShouldTraceWarning;
				break;
			case TraceEventType.Information:
				result = ShouldTraceInformation;
				break;
			case TraceEventType.Verbose:
				result = ShouldTraceVerbose;
				break;
			}
		}
		return result;
	}

	private static ExceptionUtility GetExceptionUtility()
	{
		lock (s_lockObject)
		{
			if (s_exceptionUtility == null)
			{
				s_exceptionUtility = new ExceptionUtility();
			}
		}
		return s_exceptionUtility;
	}
}

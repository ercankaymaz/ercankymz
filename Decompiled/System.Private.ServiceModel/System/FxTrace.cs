using System.Runtime;
using System.Runtime.Diagnostics;

namespace System;

internal static class FxTrace
{
	private static ExceptionTrace s_exceptionTrace;

	private const string baseEventSourceName = "System.ServiceModel";

	private const string EventSourceVersion = "4.0.0.0";

	private static string s_eventSourceName;

	private static EtwDiagnosticTrace s_diagnosticTrace;

	private static readonly object s_lockObject = new object();

	public static ExceptionTrace Exception
	{
		get
		{
			if (s_exceptionTrace == null)
			{
				s_exceptionTrace = new ExceptionTrace(EventSourceName, Trace);
			}
			return s_exceptionTrace;
		}
	}

	private static string EventSourceName
	{
		get
		{
			if (s_eventSourceName == null)
			{
				s_eventSourceName = "System.ServiceModel" + " " + "4.0.0.0";
			}
			return s_eventSourceName;
		}
	}

	public static EtwDiagnosticTrace Trace
	{
		get
		{
			EnsureEtwProviderInitialized();
			return s_diagnosticTrace;
		}
	}

	private static void EnsureEtwProviderInitialized()
	{
		if (s_diagnosticTrace != null)
		{
			return;
		}
		lock (s_lockObject)
		{
			if (s_diagnosticTrace == null)
			{
				s_diagnosticTrace = InitializeTracing();
			}
		}
	}

	private static EtwDiagnosticTrace InitializeTracing()
	{
		return new EtwDiagnosticTrace();
	}
}

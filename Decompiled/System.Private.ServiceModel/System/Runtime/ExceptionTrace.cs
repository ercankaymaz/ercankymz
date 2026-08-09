using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Diagnostics;

namespace System.Runtime;

internal class ExceptionTrace
{
	private const ushort FailFastEventLogCategory = 6;

	private string _eventSourceName;

	private readonly EtwDiagnosticTrace _diagnosticTrace;

	public void AsInformation(Exception exception)
	{
	}

	public void AsWarning(Exception exception)
	{
	}

	public Exception AsError(Exception exception)
	{
		if (exception is AggregateException aggregateException)
		{
			return AsError<Exception>(aggregateException);
		}
		if (exception is TargetInvocationException { InnerException: not null } ex)
		{
			return AsError(ex.InnerException);
		}
		return TraceException(exception);
	}

	public Exception AsError(Exception exception, string eventSource)
	{
		if (exception is AggregateException aggregateException)
		{
			return AsError<Exception>(aggregateException, eventSource);
		}
		if (exception is TargetInvocationException { InnerException: not null } ex)
		{
			return AsError(ex.InnerException, eventSource);
		}
		return TraceException(exception, eventSource);
	}

	public Exception AsError(TargetInvocationException targetInvocationException, string eventSource)
	{
		if (Fx.IsFatal(targetInvocationException))
		{
			return targetInvocationException;
		}
		Exception innerException = targetInvocationException.InnerException;
		if (innerException != null)
		{
			return AsError(innerException, eventSource);
		}
		return TraceException((Exception)targetInvocationException, eventSource);
	}

	public Exception AsError<TPreferredException>(AggregateException aggregateException)
	{
		return AsError<TPreferredException>(aggregateException, _eventSourceName);
	}

	public Exception AsError<TPreferredException>(AggregateException aggregateException, string eventSource)
	{
		if (Fx.IsFatal(aggregateException))
		{
			return aggregateException;
		}
		ReadOnlyCollection<Exception> innerExceptions = aggregateException.Flatten().InnerExceptions;
		if (innerExceptions.Count == 0)
		{
			return TraceException(aggregateException, eventSource);
		}
		Exception ex = null;
		foreach (Exception item in innerExceptions)
		{
			Exception ex2 = ((item is TargetInvocationException { InnerException: not null } ex3) ? ex3.InnerException : item);
			if (ex2 is TPreferredException && ex == null)
			{
				ex = ex2;
			}
			TraceException(ex2, eventSource);
		}
		if (ex == null)
		{
			ex = innerExceptions[0];
		}
		return ex;
	}

	public ArgumentException Argument(string paramName, string message)
	{
		return TraceException(new ArgumentException(message, paramName));
	}

	public ArgumentNullException ArgumentNull(string paramName)
	{
		return TraceException(new ArgumentNullException(paramName));
	}

	public ArgumentNullException ArgumentNull(string paramName, string message)
	{
		return TraceException(new ArgumentNullException(paramName, message));
	}

	public ArgumentException ArgumentNullOrEmpty(string paramName)
	{
		return Argument(paramName, InternalSR.ArgumentNullOrEmpty(paramName));
	}

	public ArgumentOutOfRangeException ArgumentOutOfRange(string paramName, object actualValue, string message)
	{
		return TraceException(new ArgumentOutOfRangeException(paramName, actualValue, message));
	}

	public ObjectDisposedException ObjectDisposed(string message)
	{
		return TraceException(new ObjectDisposedException(null, message));
	}

	public void TraceHandledException(Exception exception, TraceEventType traceEventType)
	{
		switch (traceEventType)
		{
		case TraceEventType.Error:
			if (TraceCore.HandledExceptionErrorIsEnabled(_diagnosticTrace))
			{
				TraceCore.HandledExceptionError(_diagnosticTrace, (exception != null) ? exception.ToString() : string.Empty, exception);
			}
			break;
		case TraceEventType.Warning:
			if (TraceCore.HandledExceptionWarningIsEnabled(_diagnosticTrace))
			{
				TraceCore.HandledExceptionWarning(_diagnosticTrace, (exception != null) ? exception.ToString() : string.Empty, exception);
			}
			break;
		case TraceEventType.Verbose:
			if (TraceCore.HandledExceptionVerboseIsEnabled(_diagnosticTrace))
			{
				TraceCore.HandledExceptionVerbose(_diagnosticTrace, (exception != null) ? exception.ToString() : string.Empty, exception);
			}
			break;
		default:
			if (TraceCore.HandledExceptionIsEnabled(_diagnosticTrace))
			{
				TraceCore.HandledException(_diagnosticTrace, (exception != null) ? exception.ToString() : string.Empty, exception);
			}
			break;
		}
	}

	public void TraceUnhandledException(Exception exception)
	{
		TraceCore.UnhandledException(_diagnosticTrace, (exception != null) ? exception.ToString() : string.Empty, exception);
	}

	private TException TraceException<TException>(TException exception) where TException : Exception
	{
		return TraceException(exception, _eventSourceName);
	}

	private TException TraceException<TException>(TException exception, string eventSource) where TException : Exception
	{
		if (TraceCore.ThrowingExceptionIsEnabled(_diagnosticTrace))
		{
			TraceCore.ThrowingException(_diagnosticTrace, eventSource, (exception != null) ? exception.ToString() : string.Empty, exception);
		}
		BreakOnException(exception);
		return exception;
	}

	private void BreakOnException(Exception exception)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void TraceFailFast(string message)
	{
	}

	public ExceptionTrace(string eventSourceName, EtwDiagnosticTrace diagnosticTrace)
	{
		_eventSourceName = eventSourceName;
		_diagnosticTrace = diagnosticTrace;
	}

	public void TraceEtwException(Exception exception, EventLevel eventLevel)
	{
		switch (eventLevel)
		{
		case EventLevel.Error:
		case EventLevel.Warning:
			if (WcfEventSource.Instance.ThrowingEtwExceptionIsEnabled())
			{
				string serializedException2 = EtwDiagnosticTrace.ExceptionToTraceString(exception, int.MaxValue);
				WcfEventSource.Instance.ThrowingEtwException(_eventSourceName, (exception != null) ? exception.ToString() : string.Empty, serializedException2);
			}
			break;
		case EventLevel.Critical:
			if (WcfEventSource.Instance.EtwUnhandledExceptionIsEnabled())
			{
				string serializedException3 = EtwDiagnosticTrace.ExceptionToTraceString(exception, int.MaxValue);
				WcfEventSource.Instance.EtwUnhandledException((exception != null) ? exception.ToString() : string.Empty, serializedException3);
			}
			break;
		default:
			if (WcfEventSource.Instance.ThrowingEtwExceptionVerboseIsEnabled())
			{
				string serializedException = EtwDiagnosticTrace.ExceptionToTraceString(exception, int.MaxValue);
				WcfEventSource.Instance.ThrowingEtwExceptionVerbose(_eventSourceName, (exception != null) ? exception.ToString() : string.Empty, serializedException);
			}
			break;
		}
	}
}

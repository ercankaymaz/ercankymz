using System;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace Opc.Ua;

[ComVisible(true)]
public class TraceEventLogger : ILogger
{
	public LogLevel LogLevel { get; set; }

	public IDisposable BeginScope<TState>(TState state)
	{
		return null;
	}

	public bool IsEnabled(LogLevel logLevel)
	{
		return logLevel >= LogLevel;
	}

	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
	{
		if (IsEnabled(logLevel))
		{
			int traceMask = Utils.GetTraceMask(eventId, logLevel);
			Utils.Trace(state, exception, traceMask, formatter);
		}
	}
}

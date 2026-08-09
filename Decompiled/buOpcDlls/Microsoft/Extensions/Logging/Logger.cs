using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Internal;

namespace Microsoft.Extensions.Logging;

[ComVisible(true)]
public class Logger<[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] T> : ILogger<T>, ILogger
{
	private readonly ILogger _logger;

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
	public Logger(ILoggerFactory factory)
	{
		if (factory == null)
		{
			throw new ArgumentNullException("factory");
		}
		_logger = factory.CreateLogger(TypeNameHelper.GetTypeDisplayName(typeof(T), fullName: true, includeGenericParameterNames: false, includeGenericParameters: false, '.'));
	}

	IDisposable ILogger.BeginScope<TState>(TState state)
	{
		return _logger.BeginScope(state);
	}

	bool ILogger.IsEnabled(LogLevel logLevel)
	{
		return _logger.IsEnabled(logLevel);
	}

	void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
	{
		_logger.Log(logLevel, eventId, state, exception, formatter);
	}
}

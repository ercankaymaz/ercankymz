using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Extensions.Logging;

[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(0)]
[ComVisible(true)]
public static class LoggerExtensions
{
	private static readonly Func<FormattedLogValues, Exception, string> _messageFormatter = MessageFormatter;

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void LogDebug([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, EventId eventId, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Debug, eventId, exception, message, args);
	}

	public static void LogDebug(this ILogger logger, EventId eventId, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Debug, eventId, message, args);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void LogDebug([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Debug, exception, message, args);
	}

	public static void LogDebug(this ILogger logger, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Debug, message, args);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void LogTrace([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, EventId eventId, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Trace, eventId, exception, message, args);
	}

	public static void LogTrace(this ILogger logger, EventId eventId, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Trace, eventId, message, args);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void LogTrace([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Trace, exception, message, args);
	}

	public static void LogTrace(this ILogger logger, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Trace, message, args);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void LogInformation([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, EventId eventId, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Information, eventId, exception, message, args);
	}

	public static void LogInformation(this ILogger logger, EventId eventId, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Information, eventId, message, args);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void LogInformation([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Information, exception, message, args);
	}

	public static void LogInformation(this ILogger logger, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Information, message, args);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void LogWarning([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, EventId eventId, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Warning, eventId, exception, message, args);
	}

	public static void LogWarning(this ILogger logger, EventId eventId, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Warning, eventId, message, args);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void LogWarning([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Warning, exception, message, args);
	}

	public static void LogWarning(this ILogger logger, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Warning, message, args);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void LogError([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, EventId eventId, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Error, eventId, exception, message, args);
	}

	public static void LogError(this ILogger logger, EventId eventId, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Error, eventId, message, args);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void LogError([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Error, exception, message, args);
	}

	public static void LogError(this ILogger logger, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Error, message, args);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void LogCritical([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, EventId eventId, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Critical, eventId, exception, message, args);
	}

	public static void LogCritical(this ILogger logger, EventId eventId, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Critical, eventId, message, args);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void LogCritical([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Critical, exception, message, args);
	}

	public static void LogCritical(this ILogger logger, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(LogLevel.Critical, message, args);
	}

	public static void Log(this ILogger logger, LogLevel logLevel, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(logLevel, 0, null, message, args);
	}

	public static void Log(this ILogger logger, LogLevel logLevel, EventId eventId, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(logLevel, eventId, null, message, args);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void Log([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, LogLevel logLevel, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		logger.Log(logLevel, 0, exception, message, args);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public static void Log([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] this ILogger logger, LogLevel logLevel, EventId eventId, Exception exception, string message, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		if (logger == null)
		{
			throw new ArgumentNullException("logger");
		}
		logger.Log(logLevel, eventId, new FormattedLogValues(message, args), exception, _messageFormatter);
	}

	public static IDisposable BeginScope(this ILogger logger, string messageFormat, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2 })] params object[] args)
	{
		if (logger == null)
		{
			throw new ArgumentNullException("logger");
		}
		return logger.BeginScope(new FormattedLogValues(messageFormat, args));
	}

	private static string MessageFormatter(FormattedLogValues state, Exception error)
	{
		return state.ToString();
	}
}

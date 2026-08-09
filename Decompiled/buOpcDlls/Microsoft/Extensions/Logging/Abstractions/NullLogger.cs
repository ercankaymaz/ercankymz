using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Extensions.Logging.Abstractions;

[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(0)]
[ComVisible(true)]
public class NullLogger : ILogger
{
	public static NullLogger Instance { get; } = new NullLogger();

	private NullLogger()
	{
	}

	public IDisposable BeginScope<[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] TState>(TState state)
	{
		return NullScope.Instance;
	}

	public bool IsEnabled(LogLevel logLevel)
	{
		return false;
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public void Log<TState>(LogLevel logLevel, EventId eventId, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] TState state, Exception exception, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 1, 2, 1 })] Func<TState, Exception, string> formatter)
	{
	}
}
[ComVisible(true)]
public class NullLogger<[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] T> : ILogger<T>, ILogger
{
	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)]
	public static readonly NullLogger<T> Instance = new NullLogger<T>();

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
	public IDisposable BeginScope<[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] TState>(TState state)
	{
		return NullScope.Instance;
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	public void Log<TState>(LogLevel logLevel, EventId eventId, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] TState state, Exception exception, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 1, 2, 1 })] Func<TState, Exception, string> formatter)
	{
	}

	public bool IsEnabled(LogLevel logLevel)
	{
		return false;
	}
}

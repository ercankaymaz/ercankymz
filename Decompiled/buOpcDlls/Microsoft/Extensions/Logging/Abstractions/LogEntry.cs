using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Extensions.Logging.Abstractions;

[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(0)]
[ComVisible(true)]
public readonly struct LogEntry<[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] TState>(LogLevel logLevel, string category, EventId eventId, TState state, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] Exception exception, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 1, 2, 1 })] Func<TState, Exception, string> formatter)
{
	public LogLevel LogLevel { get; } = logLevel;

	public string Category { get; } = category;

	public EventId EventId { get; } = eventId;

	public TState State { get; } = state;

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)]
	public Exception Exception
	{
		[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
		get;
	} = exception;

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 2, 1, 2, 1 })]
	public Func<TState, Exception, string> Formatter
	{
		[return: Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 2, 1, 2, 1 })]
		get;
	} = formatter;
}

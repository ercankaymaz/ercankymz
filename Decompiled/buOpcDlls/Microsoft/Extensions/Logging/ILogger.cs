using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Extensions.Logging;

[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
[ComVisible(true)]
public interface ILogger
{
	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	void Log<TState>(LogLevel logLevel, EventId eventId, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] TState state, Exception exception, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 1, 2, 1 })] Func<TState, Exception, string> formatter);

	bool IsEnabled(LogLevel logLevel);

	IDisposable BeginScope<[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] TState>(TState state);
}
[ComVisible(true)]
public interface ILogger<[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] out TCategoryName> : ILogger
{
}

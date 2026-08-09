using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Extensions.Logging.Abstractions;

[ComVisible(true)]
public class NullLoggerProvider : ILoggerProvider, IDisposable
{
	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)]
	public static NullLoggerProvider Instance
	{
		[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
		get;
	} = new NullLoggerProvider();

	private NullLoggerProvider()
	{
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
	public ILogger CreateLogger(string categoryName)
	{
		return NullLogger.Instance;
	}

	public void Dispose()
	{
	}
}

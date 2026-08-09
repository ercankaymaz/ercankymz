using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Extensions.Logging.Abstractions;

[ComVisible(true)]
public class NullLoggerFactory : ILoggerFactory, IDisposable
{
	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)]
	public static readonly NullLoggerFactory Instance = new NullLoggerFactory();

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
	public ILogger CreateLogger(string name)
	{
		return NullLogger.Instance;
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
	public void AddProvider(ILoggerProvider provider)
	{
	}

	public void Dispose()
	{
	}
}

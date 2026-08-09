using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Extensions.Logging;

[ComVisible(true)]
public interface ILoggerProvider : IDisposable
{
	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
	ILogger CreateLogger(string categoryName);
}

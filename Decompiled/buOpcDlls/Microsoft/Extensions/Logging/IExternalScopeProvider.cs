using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Extensions.Logging;

[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
[ComVisible(true)]
public interface IExternalScopeProvider
{
	void ForEachScope<[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] TState>([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2, 1 })] Action<object, TState> callback, TState state);

	IDisposable Push([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] object state);
}

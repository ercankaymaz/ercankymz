using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Extensions.Logging;

internal sealed class NullExternalScopeProvider : IExternalScopeProvider
{
	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)]
	public static IExternalScopeProvider Instance
	{
		[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
		get;
	} = new NullExternalScopeProvider();

	private NullExternalScopeProvider()
	{
	}

	void IExternalScopeProvider.ForEachScope<TState>(Action<object, TState> callback, TState state)
	{
	}

	IDisposable IExternalScopeProvider.Push(object state)
	{
		return NullScope.Instance;
	}
}

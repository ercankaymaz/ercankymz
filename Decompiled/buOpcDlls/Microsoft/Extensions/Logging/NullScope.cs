using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Extensions.Logging;

internal sealed class NullScope : IDisposable
{
	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)]
	public static NullScope Instance
	{
		[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
		get;
	} = new NullScope();

	private NullScope()
	{
	}

	public void Dispose()
	{
	}
}

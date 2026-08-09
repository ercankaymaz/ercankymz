using System;

namespace Microsoft.Extensions.Logging.Abstractions.Internal;

public class NullScope : IDisposable
{
	public static NullScope Instance { get; } = new NullScope();

	private NullScope()
	{
	}

	public void Dispose()
	{
	}
}

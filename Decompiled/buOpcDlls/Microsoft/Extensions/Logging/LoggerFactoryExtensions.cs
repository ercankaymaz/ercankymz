using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Internal;

namespace Microsoft.Extensions.Logging;

[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(0)]
[ComVisible(true)]
public static class LoggerFactoryExtensions
{
	public static ILogger<T> CreateLogger<[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] T>(this ILoggerFactory factory)
	{
		if (factory == null)
		{
			throw new ArgumentNullException("factory");
		}
		return new Logger<T>(factory);
	}

	public static ILogger CreateLogger(this ILoggerFactory factory, Type type)
	{
		if (factory == null)
		{
			throw new ArgumentNullException("factory");
		}
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		return factory.CreateLogger(TypeNameHelper.GetTypeDisplayName(type, fullName: true, includeGenericParameterNames: false, includeGenericParameters: false, '.'));
	}
}

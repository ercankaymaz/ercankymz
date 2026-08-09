using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Xbim.Common.Configuration;

public static class XbimServiceCollectionExtensions
{
	internal static IServiceCollection AddXbimLogging(this IServiceCollection services)
	{
		services.TryAddSingleton<ILoggerFactory, NullLoggerFactory>();
		services.TryAddSingleton((ILogger)NullLogger.Instance);
		services.TryAddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
		return services;
	}
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Xbim.Common.Configuration;

public static class XbimServiceExtensions
{
	public static ILoggerFactory GetLoggerFactory(this XbimServices services)
	{
		return services.ServiceProvider.GetRequiredService<ILoggerFactory>();
	}

	public static ILogger<T> CreateLogger<T>(this XbimServices services)
	{
		return services.ServiceProvider.GetRequiredService<ILogger<T>>();
	}
}

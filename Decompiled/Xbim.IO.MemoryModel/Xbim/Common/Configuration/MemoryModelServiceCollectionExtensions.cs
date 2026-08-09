using System;
using Microsoft.Extensions.DependencyInjection;

namespace Xbim.Common.Configuration;

public static class MemoryModelServiceCollectionExtensions
{
	public static IServiceCollection AddXbimToolkit(this IServiceCollection services)
	{
		return services.AddXbimToolkit(delegate
		{
		});
	}

	public static IServiceCollection AddXbimToolkit(this IServiceCollection services, Action<IXbimConfigurationBuilder> configure)
	{
		XbimConfigurationBuilder xbimConfigurationBuilder = new XbimConfigurationBuilder(services);
		configure(xbimConfigurationBuilder);
		xbimConfigurationBuilder.AddMemoryModel();
		return services;
	}
}

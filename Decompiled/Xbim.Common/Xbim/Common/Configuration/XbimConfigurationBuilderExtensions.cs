using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Xbim.IO;

namespace Xbim.Common.Configuration;

public static class XbimConfigurationBuilderExtensions
{
	public static IXbimConfigurationBuilder AddLoggerFactory(this IXbimConfigurationBuilder builder, ILoggerFactory loggerFactory)
	{
		builder.Services.RemoveAll<ILoggerFactory>();
		builder.Services.TryAdd(ServiceDescriptor.Singleton(loggerFactory));
		builder.Services.TryAdd(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(Logger<>)));
		return builder;
	}

	public static IXbimConfigurationBuilder AddModelProvider<T>(this IXbimConfigurationBuilder builder) where T : IModelProvider
	{
		builder.Services.TryAddSingleton(typeof(IModelProvider), typeof(T));
		return builder;
	}
}

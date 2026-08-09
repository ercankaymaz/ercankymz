using Microsoft.Extensions.DependencyInjection.Extensions;
using Xbim.IO;
using Xbim.IO.Esent;
using Xbim.Ifc;

namespace Xbim.Common.Configuration;

public static class EsentModelConfigurationBuilderExtensions
{
	public static IXbimConfigurationBuilder AddEsentModel(this IXbimConfigurationBuilder builder)
	{
		builder.Services.TryAddSingleton<IModelProvider, EsentModelProvider>();
		return builder;
	}

	public static IXbimConfigurationBuilder AddHeuristicModel(this IXbimConfigurationBuilder builder)
	{
		builder.Services.TryAddSingleton<IModelProvider, HeuristicModelProvider>();
		return builder;
	}
}

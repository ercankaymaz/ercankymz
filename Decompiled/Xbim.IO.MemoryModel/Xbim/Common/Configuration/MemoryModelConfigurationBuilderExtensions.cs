using Microsoft.Extensions.DependencyInjection.Extensions;
using Xbim.IO;
using Xbim.IO.Memory;

namespace Xbim.Common.Configuration;

public static class MemoryModelConfigurationBuilderExtensions
{
	public static IXbimConfigurationBuilder AddMemoryModel(this IXbimConfigurationBuilder builder)
	{
		builder.Services.TryAddSingleton<IModelProvider, MemoryModelProvider>();
		return builder;
	}
}

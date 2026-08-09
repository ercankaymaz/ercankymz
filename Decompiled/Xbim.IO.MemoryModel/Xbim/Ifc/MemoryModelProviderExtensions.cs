using System;
using Microsoft.Extensions.DependencyInjection;
using Xbim.Common.Configuration;
using Xbim.IO;

namespace Xbim.Ifc;

public static class MemoryModelProviderExtensions
{
	[Obsolete("Use XbimServices.Current.ConfigureServices(s => s.AddXbimToolkit(opt => opt.UseMemoryModel())) instead")]
	public static IModelProviderFactory UseMemoryModelProvider(this IModelProviderFactory providerFactory)
	{
		XbimServices.Current.ConfigureServices(delegate(IServiceCollection s)
		{
			s.AddXbimToolkit(delegate(IXbimConfigurationBuilder opt)
			{
				opt.AddMemoryModel();
			});
		});
		return providerFactory;
	}
}

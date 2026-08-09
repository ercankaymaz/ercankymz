using System;
using Microsoft.Extensions.DependencyInjection;
using Xbim.Common.Configuration;
using Xbim.IO;

namespace Xbim.Ifc;

public static class EsentModelProviderExtensions
{
	[Obsolete("Use XbimServices.Current.ConfigureServices(s => s.AddXbimToolkit(opt => opt.AddHeuristicModel())) instead")]
	public static IModelProviderFactory UseHeuristicModelProvider(this IModelProviderFactory providerFactory)
	{
		XbimServices.Current.ConfigureServices(delegate(IServiceCollection s)
		{
			s.AddXbimToolkit(delegate(IXbimConfigurationBuilder opt)
			{
				opt.AddHeuristicModel();
			});
		});
		return providerFactory;
	}

	[Obsolete("Use XbimServices.Current.ConfigureServices(s => s.AddXbimToolkit(opt => opt.AddEsentModel())) instead")]
	public static IModelProviderFactory UseEsentModelProvider(this IModelProviderFactory providerFactory)
	{
		XbimServices.Current.ConfigureServices(delegate(IServiceCollection s)
		{
			s.AddXbimToolkit(delegate(IXbimConfigurationBuilder opt)
			{
				opt.AddEsentModel();
			});
		});
		return providerFactory;
	}
}

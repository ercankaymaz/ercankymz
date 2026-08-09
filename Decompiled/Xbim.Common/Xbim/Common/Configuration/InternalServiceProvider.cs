using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Xbim.Common.Configuration;

internal class InternalServiceProvider
{
	private static readonly Lazy<InternalServiceProvider> lazySingleton;

	public IServiceProvider ServiceProvider { get; }

	public static InternalServiceProvider Current => lazySingleton.Value;

	static InternalServiceProvider()
	{
		lazySingleton = new Lazy<InternalServiceProvider>(() => new InternalServiceProvider());
	}

	private InternalServiceProvider()
	{
		ServiceCollection serviceCollection = new ServiceCollection();
		serviceCollection.AddSingleton<ILoggerFactory, NullLoggerFactory>();
		serviceCollection.TryAdd(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(NullLogger<>)));
		ServiceProvider = serviceCollection.BuildServiceProvider();
		string value = "NOTE: The xbim InternalServices are being used because Xbim.Common.Configuration.XbimServices has not yet been configured. This fallback service provider has no logging support so you may miss useful output from xbim. To see xbim logs ensure you provide a LoggerFactory to " + typeof(XbimServices).FullName + " at startup - or provide an existing ServiceProvider to the XbimServices. e.g.\r\n\r\nXbimServices.Current.ConfigureServices(s => s.AddXbimToolkit(c => c.AddLoggerFactory(loggerFactory)));\r\n// or\r\nXbimServices.Current.UseExternalServiceProvider(serviceProvider);";
		Console.Error.WriteLine(value);
	}
}

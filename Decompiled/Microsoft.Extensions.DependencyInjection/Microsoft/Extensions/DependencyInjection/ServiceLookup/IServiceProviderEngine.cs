using System;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal interface IServiceProviderEngine : IDisposable, IServiceProvider
{
	IServiceScope RootScope { get; }
}

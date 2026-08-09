using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal abstract class CompiledServiceProviderEngine : ServiceProviderEngine
{
	public ExpressionResolverBuilder ExpressionResolverBuilder { get; }

	public CompiledServiceProviderEngine(IEnumerable<ServiceDescriptor> serviceDescriptors, IServiceProviderEngineCallback callback)
		: base(serviceDescriptors, callback)
	{
		ExpressionResolverBuilder = new ExpressionResolverBuilder(base.RuntimeResolver, this, base.Root);
	}

	protected override Func<ServiceProviderEngineScope, object> RealizeService(IServiceCallSite callSite)
	{
		Func<ServiceProviderEngineScope, object> func = ExpressionResolverBuilder.Build(callSite);
		base.RealizedServices[callSite.ServiceType] = func;
		return func;
	}
}

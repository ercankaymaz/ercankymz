using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal class ExpressionsServiceProviderEngine : ServiceProviderEngine
{
	private readonly ExpressionResolverBuilder _expressionResolverBuilder;

	public ExpressionsServiceProviderEngine(IEnumerable<ServiceDescriptor> serviceDescriptors, IServiceProviderEngineCallback callback)
		: base(serviceDescriptors, callback)
	{
		_expressionResolverBuilder = new ExpressionResolverBuilder(base.RuntimeResolver, this, base.Root);
	}

	protected override Func<ServiceProviderEngineScope, object> RealizeService(IServiceCallSite callSite)
	{
		Func<ServiceProviderEngineScope, object> func = _expressionResolverBuilder.Build(callSite);
		base.RealizedServices[callSite.ServiceType] = func;
		return func;
	}
}

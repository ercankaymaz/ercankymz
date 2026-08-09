using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal class DynamicServiceProviderEngine : CompiledServiceProviderEngine
{
	public DynamicServiceProviderEngine(IEnumerable<ServiceDescriptor> serviceDescriptors, IServiceProviderEngineCallback callback)
		: base(serviceDescriptors, callback)
	{
	}

	protected override Func<ServiceProviderEngineScope, object> RealizeService(IServiceCallSite callSite)
	{
		int callCount = 0;
		return delegate(ServiceProviderEngineScope scope)
		{
			if (Interlocked.Increment(ref callCount) == 2)
			{
				Task.Run(() => base.RealizeService(callSite));
			}
			return base.RuntimeResolver.Resolve(callSite, scope);
		};
	}
}

using System;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal class ScopedCallSite : IServiceCallSite
{
	internal IServiceCallSite ServiceCallSite { get; }

	public object CacheKey { get; }

	public Type ServiceType => ServiceCallSite.ServiceType;

	public Type ImplementationType => ServiceCallSite.ImplementationType;

	public virtual CallSiteKind Kind { get; } = CallSiteKind.Scope;

	public ScopedCallSite(IServiceCallSite serviceCallSite, object cacheKey)
	{
		ServiceCallSite = serviceCallSite;
		CacheKey = cacheKey;
	}
}

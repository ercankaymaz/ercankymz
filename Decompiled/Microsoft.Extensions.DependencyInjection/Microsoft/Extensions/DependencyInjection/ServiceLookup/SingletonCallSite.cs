namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal class SingletonCallSite(IServiceCallSite serviceCallSite, object cacheKey) : ScopedCallSite(serviceCallSite, cacheKey)
{
	public override CallSiteKind Kind { get; } = CallSiteKind.Singleton;
}

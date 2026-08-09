using System;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal class TransientCallSite : IServiceCallSite
{
	internal IServiceCallSite ServiceCallSite { get; }

	public Type ServiceType => ServiceCallSite.ServiceType;

	public Type ImplementationType => ServiceCallSite.ImplementationType;

	public CallSiteKind Kind { get; } = CallSiteKind.Transient;

	public TransientCallSite(IServiceCallSite serviceCallSite)
	{
		ServiceCallSite = serviceCallSite;
	}
}

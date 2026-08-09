using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal class IEnumerableCallSite : IServiceCallSite
{
	internal Type ItemType { get; }

	internal IServiceCallSite[] ServiceCallSites { get; }

	public Type ServiceType => typeof(IEnumerable<>).MakeGenericType(ItemType);

	public Type ImplementationType => ItemType.MakeArrayType();

	public CallSiteKind Kind { get; } = CallSiteKind.IEnumerable;

	public IEnumerableCallSite(Type itemType, IServiceCallSite[] serviceCallSites)
	{
		ItemType = itemType;
		ServiceCallSites = serviceCallSites;
	}
}

using System;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal interface IServiceCallSite
{
	Type ServiceType { get; }

	Type ImplementationType { get; }

	CallSiteKind Kind { get; }
}

using System;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal class ConstantCallSite : IServiceCallSite
{
	internal object DefaultValue { get; }

	public Type ServiceType => DefaultValue.GetType();

	public Type ImplementationType => DefaultValue.GetType();

	public CallSiteKind Kind { get; } = CallSiteKind.Constant;

	public ConstantCallSite(Type serviceType, object defaultValue)
	{
		DefaultValue = defaultValue;
	}
}

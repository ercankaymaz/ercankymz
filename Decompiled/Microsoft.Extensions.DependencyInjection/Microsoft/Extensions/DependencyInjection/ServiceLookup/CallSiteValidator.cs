using System;
using System.Collections.Concurrent;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal class CallSiteValidator : CallSiteVisitor<CallSiteValidator.CallSiteValidatorState, Type>
{
	internal struct CallSiteValidatorState
	{
		public SingletonCallSite Singleton { get; set; }
	}

	private readonly ConcurrentDictionary<Type, Type> _scopedServices = new ConcurrentDictionary<Type, Type>();

	public void ValidateCallSite(IServiceCallSite callSite)
	{
		Type type = VisitCallSite(callSite, default(CallSiteValidatorState));
		if (type != null)
		{
			_scopedServices[callSite.ServiceType] = type;
		}
	}

	public void ValidateResolution(Type serviceType, IServiceScope scope, IServiceScope rootScope)
	{
		if (scope == rootScope && _scopedServices.TryGetValue(serviceType, out var value))
		{
			if (serviceType == value)
			{
				throw new InvalidOperationException(Resources.FormatDirectScopedResolvedFromRootException(serviceType, "Scoped".ToLowerInvariant()));
			}
			throw new InvalidOperationException(Resources.FormatScopedResolvedFromRootException(serviceType, value, "Scoped".ToLowerInvariant()));
		}
	}

	protected override Type VisitTransient(TransientCallSite transientCallSite, CallSiteValidatorState state)
	{
		return VisitCallSite(transientCallSite.ServiceCallSite, state);
	}

	protected override Type VisitConstructor(ConstructorCallSite constructorCallSite, CallSiteValidatorState state)
	{
		Type type = null;
		IServiceCallSite[] parameterCallSites = constructorCallSite.ParameterCallSites;
		foreach (IServiceCallSite callSite in parameterCallSites)
		{
			Type type2 = VisitCallSite(callSite, state);
			if (type == null)
			{
				type = type2;
			}
		}
		return type;
	}

	protected override Type VisitIEnumerable(IEnumerableCallSite enumerableCallSite, CallSiteValidatorState state)
	{
		Type type = null;
		IServiceCallSite[] serviceCallSites = enumerableCallSite.ServiceCallSites;
		foreach (IServiceCallSite callSite in serviceCallSites)
		{
			Type type2 = VisitCallSite(callSite, state);
			if (type == null)
			{
				type = type2;
			}
		}
		return type;
	}

	protected override Type VisitSingleton(SingletonCallSite singletonCallSite, CallSiteValidatorState state)
	{
		state.Singleton = singletonCallSite;
		return VisitCallSite(singletonCallSite.ServiceCallSite, state);
	}

	protected override Type VisitScoped(ScopedCallSite scopedCallSite, CallSiteValidatorState state)
	{
		if (scopedCallSite.ServiceCallSite is ServiceScopeFactoryCallSite)
		{
			return null;
		}
		if (state.Singleton != null)
		{
			throw new InvalidOperationException(Resources.FormatScopedInSingletonException(scopedCallSite.ServiceType, state.Singleton.ServiceType, "Scoped".ToLowerInvariant(), "Singleton".ToLowerInvariant()));
		}
		VisitCallSite(scopedCallSite.ServiceCallSite, state);
		return scopedCallSite.ServiceType;
	}

	protected override Type VisitConstant(ConstantCallSite constantCallSite, CallSiteValidatorState state)
	{
		return null;
	}

	protected override Type VisitCreateInstance(CreateInstanceCallSite createInstanceCallSite, CallSiteValidatorState state)
	{
		return null;
	}

	protected override Type VisitServiceProvider(ServiceProviderCallSite serviceProviderCallSite, CallSiteValidatorState state)
	{
		return null;
	}

	protected override Type VisitServiceScopeFactory(ServiceScopeFactoryCallSite serviceScopeFactoryCallSite, CallSiteValidatorState state)
	{
		return null;
	}

	protected override Type VisitFactory(FactoryCallSite factoryCallSite, CallSiteValidatorState state)
	{
		return null;
	}
}

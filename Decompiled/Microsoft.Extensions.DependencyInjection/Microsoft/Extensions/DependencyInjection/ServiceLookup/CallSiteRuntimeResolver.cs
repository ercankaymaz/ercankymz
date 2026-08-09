using System;
using System.Runtime.ExceptionServices;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal class CallSiteRuntimeResolver : CallSiteVisitor<ServiceProviderEngineScope, object>
{
	public object Resolve(IServiceCallSite callSite, ServiceProviderEngineScope scope)
	{
		return VisitCallSite(callSite, scope);
	}

	protected override object VisitTransient(TransientCallSite transientCallSite, ServiceProviderEngineScope scope)
	{
		return scope.CaptureDisposable(VisitCallSite(transientCallSite.ServiceCallSite, scope));
	}

	protected override object VisitConstructor(ConstructorCallSite constructorCallSite, ServiceProviderEngineScope scope)
	{
		object[] array = new object[constructorCallSite.ParameterCallSites.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = VisitCallSite(constructorCallSite.ParameterCallSites[i], scope);
		}
		try
		{
			return constructorCallSite.ConstructorInfo.Invoke(array);
		}
		catch (Exception ex) when (ex.InnerException != null)
		{
			ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			throw;
		}
	}

	protected override object VisitSingleton(SingletonCallSite singletonCallSite, ServiceProviderEngineScope scope)
	{
		return VisitScoped(singletonCallSite, scope.Engine.Root);
	}

	protected override object VisitScoped(ScopedCallSite scopedCallSite, ServiceProviderEngineScope scope)
	{
		lock (scope.ResolvedServices)
		{
			if (!scope.ResolvedServices.TryGetValue(scopedCallSite.CacheKey, out var value))
			{
				value = VisitCallSite(scopedCallSite.ServiceCallSite, scope);
				scope.CaptureDisposable(value);
				scope.ResolvedServices.Add(scopedCallSite.CacheKey, value);
			}
			return value;
		}
	}

	protected override object VisitConstant(ConstantCallSite constantCallSite, ServiceProviderEngineScope scope)
	{
		return constantCallSite.DefaultValue;
	}

	protected override object VisitCreateInstance(CreateInstanceCallSite createInstanceCallSite, ServiceProviderEngineScope scope)
	{
		try
		{
			return Activator.CreateInstance(createInstanceCallSite.ImplementationType);
		}
		catch (Exception ex) when (ex.InnerException != null)
		{
			ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
			throw;
		}
	}

	protected override object VisitServiceProvider(ServiceProviderCallSite serviceProviderCallSite, ServiceProviderEngineScope scope)
	{
		return scope;
	}

	protected override object VisitServiceScopeFactory(ServiceScopeFactoryCallSite serviceScopeFactoryCallSite, ServiceProviderEngineScope scope)
	{
		return scope.Engine;
	}

	protected override object VisitIEnumerable(IEnumerableCallSite enumerableCallSite, ServiceProviderEngineScope scope)
	{
		Array array = Array.CreateInstance(enumerableCallSite.ItemType, enumerableCallSite.ServiceCallSites.Length);
		for (int i = 0; i < enumerableCallSite.ServiceCallSites.Length; i++)
		{
			object value = VisitCallSite(enumerableCallSite.ServiceCallSites[i], scope);
			array.SetValue(value, i);
		}
		return array;
	}

	protected override object VisitFactory(FactoryCallSite factoryCallSite, ServiceProviderEngineScope scope)
	{
		return factoryCallSite.Factory(scope);
	}
}

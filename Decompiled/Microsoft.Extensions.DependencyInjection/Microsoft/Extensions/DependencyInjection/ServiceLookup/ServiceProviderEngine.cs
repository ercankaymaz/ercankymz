using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal abstract class ServiceProviderEngine : IServiceProviderEngine, IDisposable, IServiceProvider, IServiceScopeFactory
{
	private readonly IServiceProviderEngineCallback _callback;

	private readonly Func<Type, Func<ServiceProviderEngineScope, object>> _createServiceAccessor;

	private bool _disposed;

	internal ConcurrentDictionary<Type, Func<ServiceProviderEngineScope, object>> RealizedServices { get; }

	internal CallSiteFactory CallSiteFactory { get; }

	protected CallSiteRuntimeResolver RuntimeResolver { get; }

	public ServiceProviderEngineScope Root { get; }

	public IServiceScope RootScope => Root;

	protected ServiceProviderEngine(IEnumerable<ServiceDescriptor> serviceDescriptors, IServiceProviderEngineCallback callback)
	{
		_createServiceAccessor = CreateServiceAccessor;
		_callback = callback;
		Root = new ServiceProviderEngineScope(this);
		RuntimeResolver = new CallSiteRuntimeResolver();
		CallSiteFactory = new CallSiteFactory(serviceDescriptors);
		CallSiteFactory.Add(typeof(IServiceProvider), new ServiceProviderCallSite());
		CallSiteFactory.Add(typeof(IServiceScopeFactory), new ServiceScopeFactoryCallSite());
		RealizedServices = new ConcurrentDictionary<Type, Func<ServiceProviderEngineScope, object>>();
	}

	public object GetService(Type serviceType)
	{
		return GetService(serviceType, Root);
	}

	protected abstract Func<ServiceProviderEngineScope, object> RealizeService(IServiceCallSite callSite);

	public void Dispose()
	{
		_disposed = true;
		Root.Dispose();
	}

	internal object GetService(Type serviceType, ServiceProviderEngineScope serviceProviderEngineScope)
	{
		if (_disposed)
		{
			ThrowHelper.ThrowObjectDisposedException();
		}
		Func<ServiceProviderEngineScope, object> orAdd = RealizedServices.GetOrAdd(serviceType, _createServiceAccessor);
		_callback?.OnResolve(serviceType, serviceProviderEngineScope);
		return orAdd(serviceProviderEngineScope);
	}

	public IServiceScope CreateScope()
	{
		if (_disposed)
		{
			ThrowHelper.ThrowObjectDisposedException();
		}
		return new ServiceProviderEngineScope(this);
	}

	private Func<ServiceProviderEngineScope, object> CreateServiceAccessor(Type serviceType)
	{
		IServiceCallSite serviceCallSite = CallSiteFactory.CreateCallSite(serviceType, new CallSiteChain());
		if (serviceCallSite != null)
		{
			_callback?.OnCreate(serviceCallSite);
			return RealizeService(serviceCallSite);
		}
		return (ServiceProviderEngineScope _) => (object)null;
	}
}

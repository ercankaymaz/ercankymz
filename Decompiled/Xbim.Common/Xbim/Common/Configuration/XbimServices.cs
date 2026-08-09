using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Xbim.Common.Configuration;

public class XbimServices : IDisposable
{
	private bool isBuilt;

	private IServiceCollection servicesCollection = new ServiceCollection();

	private IServiceProvider externalServiceProvider;

	private static Lazy<XbimServices> lazySingleton = new Lazy<XbimServices>(() => new XbimServices());

	private Lazy<IServiceProvider> serviceProviderBuilder;

	private bool disposedValue;

	public static XbimServices Current { get; private set; } = lazySingleton.Value;

	public bool IsBuilt => isBuilt;

	public bool IsConfigured
	{
		get
		{
			if (!servicesCollection.Any())
			{
				return externalServiceProvider != null;
			}
			return true;
		}
	}

	public IServiceProvider ServiceProvider
	{
		get
		{
			IServiceProvider value = externalServiceProvider;
			if (value == null)
			{
				if (!IsConfigured)
				{
					return InternalServiceProvider.Current.ServiceProvider;
				}
				value = serviceProviderBuilder.Value;
			}
			return value;
		}
	}

	private XbimServices()
	{
		Rebuild();
	}

	public static XbimServices CreateInstanceInternal()
	{
		return new XbimServices();
	}

	public void UseExternalServiceCollection(IServiceCollection collection)
	{
		if (isBuilt)
		{
			throw new InvalidOperationException("The xbim internal ServiceCollection has already been built");
		}
		servicesCollection = collection;
	}

	public void UseExternalServiceProvider(IServiceProvider provider)
	{
		if (isBuilt)
		{
			throw new InvalidOperationException("The xbim internal ServiceProvider has already been built");
		}
		isBuilt = true;
		externalServiceProvider = provider;
	}

	public void ConfigureServices(Action<IServiceCollection> configure)
	{
		if (isBuilt)
		{
			throw new InvalidOperationException("The xbim internal ServiceCollection has already been built");
		}
		configure(servicesCollection);
	}

	internal void Rebuild()
	{
		servicesCollection.Clear();
		isBuilt = false;
		DisposeServiceProvider();
		serviceProviderBuilder = new Lazy<IServiceProvider>(delegate
		{
			isBuilt = true;
			return servicesCollection.AddXbimLogging().BuildServiceProvider();
		});
	}

	private void DisposeServiceProvider()
	{
		if (serviceProviderBuilder != null && serviceProviderBuilder.IsValueCreated && serviceProviderBuilder.Value is ServiceProvider serviceProvider)
		{
			serviceProvider.Dispose();
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				Rebuild();
			}
			disposedValue = true;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}

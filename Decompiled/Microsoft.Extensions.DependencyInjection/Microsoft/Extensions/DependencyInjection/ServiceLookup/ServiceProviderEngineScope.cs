using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal class ServiceProviderEngineScope : IServiceScope, IDisposable, IServiceProvider
{
	internal Action<object> _captureDisposableCallback;

	private List<IDisposable> _disposables;

	private bool _disposed;

	internal Dictionary<object, object> ResolvedServices { get; } = new Dictionary<object, object>();

	public ServiceProviderEngine Engine { get; }

	public IServiceProvider ServiceProvider => this;

	public ServiceProviderEngineScope(ServiceProviderEngine engine)
	{
		Engine = engine;
	}

	public object GetService(Type serviceType)
	{
		if (_disposed)
		{
			ThrowHelper.ThrowObjectDisposedException();
		}
		return Engine.GetService(serviceType, this);
	}

	public void Dispose()
	{
		lock (ResolvedServices)
		{
			if (_disposed)
			{
				return;
			}
			_disposed = true;
			if (_disposables != null)
			{
				for (int num = _disposables.Count - 1; num >= 0; num--)
				{
					_disposables[num].Dispose();
				}
				_disposables.Clear();
			}
			ResolvedServices.Clear();
		}
	}

	internal object CaptureDisposable(object service)
	{
		_captureDisposableCallback?.Invoke(service);
		if (this != service && service is IDisposable item)
		{
			lock (ResolvedServices)
			{
				if (_disposables == null)
				{
					_disposables = new List<IDisposable>();
				}
				_disposables.Add(item);
			}
		}
		return service;
	}
}

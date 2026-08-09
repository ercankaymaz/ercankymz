using System;
using System.Collections.Generic;

namespace Microsoft.Windows.Design.Features;

public abstract class FeatureConnector<TFeatureProviderType> : IDisposable, IFeatureConnectorMarker where TFeatureProviderType : FeatureProvider
{
	private EditingContext _context;

	private FeatureManager _manager;

	protected EditingContext Context => _context;

	protected FeatureManager Manager => _manager;

	~FeatureConnector()
	{
		Dispose(disposing: false);
	}

	protected FeatureConnector(FeatureManager manager)
	{
		if (manager == null)
		{
			throw new ArgumentNullException("manager");
		}
		_manager = manager;
		_context = manager.Context;
	}

	protected IEnumerable<TFeatureProviderType> CreateFeatureProviders(Type type)
	{
		foreach (TFeatureProviderType item in _manager.CreateFeatureProviders(typeof(TFeatureProviderType), type))
		{
			yield return item;
		}
	}

	protected IEnumerable<TSubtype> CreateFeatureProviders<TSubtype>(Type type) where TSubtype : TFeatureProviderType
	{
		foreach (TSubtype item in _manager.CreateFeatureProviders(typeof(TSubtype), type))
		{
			yield return item;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
	}
}

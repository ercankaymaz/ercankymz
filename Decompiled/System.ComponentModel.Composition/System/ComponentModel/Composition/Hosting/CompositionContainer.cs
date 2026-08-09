using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Threading;
using Microsoft.Internal;

namespace System.ComponentModel.Composition.Hosting;

public class CompositionContainer : ExportProvider, ICompositionService, IDisposable
{
	private sealed class CompositionServiceShim : ICompositionService
	{
		private readonly CompositionContainer _innerContainer;

		public CompositionServiceShim(CompositionContainer innerContainer)
		{
			ArgumentNullException.ThrowIfNull(innerContainer, "innerContainer");
			_innerContainer = innerContainer;
		}

		void ICompositionService.SatisfyImportsOnce(ComposablePart part)
		{
			_innerContainer.SatisfyImportsOnce(part);
		}
	}

	private readonly CompositionOptions _compositionOptions;

	private ImportEngine _importEngine;

	private ComposablePartExportProvider _partExportProvider;

	private ExportProvider _rootProvider;

	private IDisposable _disposableRootProvider;

	private CatalogExportProvider _catalogExportProvider;

	private ExportProvider _localExportProvider;

	private IDisposable _disposableLocalExportProvider;

	private ExportProvider _ancestorExportProvider;

	private IDisposable _disposableAncestorExportProvider;

	private readonly ReadOnlyCollection<ExportProvider> _providers;

	private volatile bool _isDisposed;

	private readonly object _lock = new object();

	private static readonly ReadOnlyCollection<ExportProvider> EmptyProviders = new ReadOnlyCollection<ExportProvider>(Array.Empty<ExportProvider>());

	internal CompositionOptions CompositionOptions
	{
		get
		{
			ThrowIfDisposed();
			return _compositionOptions;
		}
	}

	public ComposablePartCatalog? Catalog
	{
		get
		{
			ThrowIfDisposed();
			return _catalogExportProvider?.Catalog;
		}
	}

	internal CatalogExportProvider? CatalogExportProvider
	{
		get
		{
			ThrowIfDisposed();
			return _catalogExportProvider;
		}
	}

	public ReadOnlyCollection<ExportProvider> Providers
	{
		get
		{
			ThrowIfDisposed();
			return _providers;
		}
	}

	public CompositionContainer()
		: this(null, Array.Empty<ExportProvider>())
	{
	}

	public CompositionContainer(params ExportProvider[]? providers)
		: this(null, providers)
	{
	}

	public CompositionContainer(CompositionOptions compositionOptions, params ExportProvider[]? providers)
		: this(null, compositionOptions, providers)
	{
	}

	public CompositionContainer(ComposablePartCatalog? catalog, params ExportProvider[]? providers)
		: this(catalog, isThreadSafe: false, providers)
	{
	}

	public CompositionContainer(ComposablePartCatalog? catalog, bool isThreadSafe, params ExportProvider[]? providers)
		: this(catalog, isThreadSafe ? CompositionOptions.IsThreadSafe : CompositionOptions.Default, providers)
	{
	}

	public CompositionContainer(ComposablePartCatalog? catalog, CompositionOptions compositionOptions, params ExportProvider[]? providers)
	{
		if (compositionOptions > (CompositionOptions.DisableSilentRejection | CompositionOptions.IsThreadSafe | CompositionOptions.ExportCompositionService))
		{
			throw new ArgumentOutOfRangeException("compositionOptions");
		}
		_compositionOptions = compositionOptions;
		_partExportProvider = new ComposablePartExportProvider(compositionOptions);
		_partExportProvider.SourceProvider = this;
		if (catalog != null)
		{
			_catalogExportProvider = new CatalogExportProvider(catalog, compositionOptions);
			_catalogExportProvider.SourceProvider = this;
		}
		if (_catalogExportProvider != null)
		{
			_localExportProvider = new AggregateExportProvider(_partExportProvider, _catalogExportProvider);
			_disposableLocalExportProvider = _localExportProvider as IDisposable;
		}
		else
		{
			_localExportProvider = _partExportProvider;
		}
		if (providers != null && providers.Length != 0)
		{
			if (providers.Length > 1)
			{
				_ancestorExportProvider = new AggregateExportProvider(providers);
				_disposableAncestorExportProvider = _ancestorExportProvider as IDisposable;
			}
			else
			{
				if (providers[0] == null)
				{
					throw ExceptionBuilder.CreateContainsNullElement("providers");
				}
				_ancestorExportProvider = providers[0];
			}
		}
		if (_ancestorExportProvider == null)
		{
			_rootProvider = _localExportProvider;
		}
		else
		{
			ExportProvider[] array = new ExportProvider[1 + ((catalog != null) ? 1 : 0) + ((providers != null) ? providers.Length : 0)];
			array[0] = _partExportProvider;
			int num = 1;
			if (catalog != null)
			{
				array[1] = _catalogExportProvider;
				num = 2;
			}
			if (providers != null)
			{
				for (int i = 0; i < providers.Length; i++)
				{
					array[num + i] = providers[i];
				}
			}
			_rootProvider = new AggregateExportProvider(array);
			_disposableRootProvider = _rootProvider as IDisposable;
		}
		if (compositionOptions.HasFlag(CompositionOptions.ExportCompositionService))
		{
			this.ComposeExportedValue((ICompositionService)new CompositionServiceShim(this));
		}
		_rootProvider.ExportsChanged += OnExportsChangedInternal;
		_rootProvider.ExportsChanging += OnExportsChangingInternal;
		_providers = ((providers != null) ? Array.AsReadOnly((ExportProvider[])providers.Clone()) : EmptyProviders);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposing || _isDisposed)
		{
			return;
		}
		ExportProvider exportProvider = null;
		IDisposable disposable = null;
		IDisposable disposable2 = null;
		IDisposable disposable3 = null;
		ComposablePartExportProvider composablePartExportProvider = null;
		CatalogExportProvider catalogExportProvider = null;
		ImportEngine importEngine = null;
		lock (_lock)
		{
			if (!_isDisposed)
			{
				exportProvider = _rootProvider;
				_rootProvider = null;
				disposable3 = _disposableRootProvider;
				_disposableRootProvider = null;
				disposable2 = _disposableLocalExportProvider;
				_disposableLocalExportProvider = null;
				_localExportProvider = null;
				disposable = _disposableAncestorExportProvider;
				_disposableAncestorExportProvider = null;
				_ancestorExportProvider = null;
				composablePartExportProvider = _partExportProvider;
				_partExportProvider = null;
				catalogExportProvider = _catalogExportProvider;
				_catalogExportProvider = null;
				importEngine = _importEngine;
				_importEngine = null;
				_isDisposed = true;
			}
		}
		if (exportProvider != null)
		{
			exportProvider.ExportsChanged -= OnExportsChangedInternal;
			exportProvider.ExportsChanging -= OnExportsChangingInternal;
		}
		disposable3?.Dispose();
		disposable?.Dispose();
		disposable2?.Dispose();
		catalogExportProvider?.Dispose();
		composablePartExportProvider?.Dispose();
		importEngine?.Dispose();
	}

	public void Compose(CompositionBatch batch)
	{
		Requires.NotNull(batch, "batch");
		ThrowIfDisposed();
		_partExportProvider.Compose(batch);
	}

	public void ReleaseExport(Export export)
	{
		Requires.NotNull(export, "export");
		if (export is IDisposable disposable)
		{
			disposable.Dispose();
		}
	}

	public void ReleaseExport<T>(Lazy<T> export)
	{
		Requires.NotNull(export, "export");
		if (export is IDisposable disposable)
		{
			disposable.Dispose();
		}
	}

	public void ReleaseExports(IEnumerable<Export> exports)
	{
		Requires.NotNullOrNullElements(exports, "exports");
		foreach (Export export in exports)
		{
			ReleaseExport(export);
		}
	}

	public void ReleaseExports<T>(IEnumerable<Lazy<T>> exports)
	{
		Requires.NotNullOrNullElements(exports, "exports");
		foreach (Lazy<T> export in exports)
		{
			ReleaseExport(export);
		}
	}

	public void ReleaseExports<T, TMetadataView>(IEnumerable<Lazy<T, TMetadataView>> exports)
	{
		Requires.NotNullOrNullElements(exports, "exports");
		foreach (Lazy<T, TMetadataView> export in exports)
		{
			ReleaseExport(export);
		}
	}

	public void SatisfyImportsOnce(ComposablePart part)
	{
		ThrowIfDisposed();
		if (_importEngine == null)
		{
			ImportEngine importEngine = new ImportEngine(this, _compositionOptions);
			lock (_lock)
			{
				if (_importEngine == null)
				{
					Thread.MemoryBarrier();
					_importEngine = importEngine;
					importEngine = null;
				}
			}
			importEngine?.Dispose();
		}
		_importEngine.SatisfyImportsOnce(part);
	}

	internal void OnExportsChangedInternal(object? sender, ExportsChangeEventArgs e)
	{
		OnExportsChanged(e);
	}

	internal void OnExportsChangingInternal(object? sender, ExportsChangeEventArgs e)
	{
		OnExportsChanging(e);
	}

	protected override IEnumerable<Export>? GetExportsCore(ImportDefinition definition, AtomicComposition? atomicComposition)
	{
		ThrowIfDisposed();
		IEnumerable<Export> exports = null;
		if (!definition.Metadata.TryGetValue("System.ComponentModel.Composition.ImportSource", out object value))
		{
			value = ImportSource.Any;
		}
		switch ((ImportSource)value)
		{
		case ImportSource.Any:
			if (_rootProvider == null)
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			_rootProvider.TryGetExports(definition, atomicComposition, out exports);
			break;
		case ImportSource.Local:
			if (_localExportProvider == null)
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			_localExportProvider.TryGetExports(definition.RemoveImportSource(), atomicComposition, out exports);
			break;
		case ImportSource.NonLocal:
			_ancestorExportProvider?.TryGetExports(definition.RemoveImportSource(), atomicComposition, out exports);
			break;
		}
		return exports;
	}

	[DebuggerStepThrough]
	private void ThrowIfDisposed()
	{
		if (_isDisposed)
		{
			throw ExceptionBuilder.CreateObjectDisposed(this);
		}
	}
}

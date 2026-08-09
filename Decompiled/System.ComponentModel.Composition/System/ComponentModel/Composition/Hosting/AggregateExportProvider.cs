using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.Internal.Collections;

namespace System.ComponentModel.Composition.Hosting;

public class AggregateExportProvider : ExportProvider, IDisposable
{
	private readonly ReadOnlyCollection<ExportProvider> _readOnlyProviders;

	private readonly ExportProvider[] _providers;

	private volatile int _isDisposed;

	public ReadOnlyCollection<ExportProvider> Providers
	{
		get
		{
			ThrowIfDisposed();
			return _readOnlyProviders;
		}
	}

	public AggregateExportProvider(params ExportProvider[]? providers)
	{
		ExportProvider[] array = null;
		if (providers != null)
		{
			array = new ExportProvider[providers.Length];
			for (int i = 0; i < providers.Length; i++)
			{
				ExportProvider exportProvider = providers[i];
				if (exportProvider == null)
				{
					throw ExceptionBuilder.CreateContainsNullElement("providers");
				}
				array[i] = exportProvider;
				exportProvider.ExportsChanged += OnExportChangedInternal;
				exportProvider.ExportsChanging += OnExportChangingInternal;
			}
		}
		else
		{
			array = Array.Empty<ExportProvider>();
		}
		_providers = array;
		_readOnlyProviders = Array.AsReadOnly(_providers);
	}

	public AggregateExportProvider(IEnumerable<ExportProvider>? providers)
		: this(providers?.AsArray())
	{
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && Interlocked.CompareExchange(ref _isDisposed, 1, 0) == 0)
		{
			ExportProvider[] providers = _providers;
			foreach (ExportProvider exportProvider in providers)
			{
				exportProvider.ExportsChanged -= OnExportChangedInternal;
				exportProvider.ExportsChanging -= OnExportChangingInternal;
			}
		}
	}

	protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition? atomicComposition)
	{
		ThrowIfDisposed();
		if (definition.Cardinality == ImportCardinality.ZeroOrMore)
		{
			List<Export> list = new List<Export>();
			ExportProvider[] providers = _providers;
			foreach (ExportProvider exportProvider in providers)
			{
				foreach (Export export in exportProvider.GetExports(definition, atomicComposition))
				{
					list.Add(export);
				}
			}
			return list;
		}
		IEnumerable<Export> enumerable = null;
		ExportProvider[] providers2 = _providers;
		foreach (ExportProvider exportProvider2 in providers2)
		{
			IEnumerable<Export> exports;
			bool flag = exportProvider2.TryGetExports(definition, atomicComposition, out exports);
			bool flag2 = exports.Any();
			if (flag && flag2)
			{
				return exports;
			}
			if (flag2)
			{
				IEnumerable<Export> enumerable3;
				if (enumerable == null)
				{
					IEnumerable<Export> enumerable2 = exports;
					enumerable3 = enumerable2;
				}
				else
				{
					enumerable3 = enumerable.Concat(exports);
				}
				enumerable = enumerable3;
			}
		}
		return enumerable;
	}

	private void OnExportChangedInternal(object sender, ExportsChangeEventArgs e)
	{
		OnExportsChanged(e);
	}

	private void OnExportChangingInternal(object sender, ExportsChangeEventArgs e)
	{
		OnExportsChanging(e);
	}

	[DebuggerStepThrough]
	private void ThrowIfDisposed()
	{
		if (_isDisposed == 1)
		{
			throw ExceptionBuilder.CreateObjectDisposed(this);
		}
	}
}

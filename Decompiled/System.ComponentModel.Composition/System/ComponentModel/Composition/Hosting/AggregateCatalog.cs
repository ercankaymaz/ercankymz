using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.Internal;

namespace System.ComponentModel.Composition.Hosting;

public class AggregateCatalog : ComposablePartCatalog, INotifyComposablePartCatalogChanged
{
	private readonly ComposablePartCatalogCollection _catalogs;

	private volatile int _isDisposed;

	public ICollection<ComposablePartCatalog> Catalogs
	{
		get
		{
			ThrowIfDisposed();
			return _catalogs;
		}
	}

	public event EventHandler<ComposablePartCatalogChangeEventArgs>? Changed
	{
		add
		{
			_catalogs.Changed += value;
		}
		remove
		{
			_catalogs.Changed -= value;
		}
	}

	public event EventHandler<ComposablePartCatalogChangeEventArgs>? Changing
	{
		add
		{
			_catalogs.Changing += value;
		}
		remove
		{
			_catalogs.Changing -= value;
		}
	}

	public AggregateCatalog()
		: this((IEnumerable<ComposablePartCatalog>?)null)
	{
	}

	public AggregateCatalog(params ComposablePartCatalog[]? catalogs)
		: this((IEnumerable<ComposablePartCatalog>?)catalogs)
	{
	}

	public AggregateCatalog(IEnumerable<ComposablePartCatalog>? catalogs)
	{
		Requires.NullOrNotNullElements(catalogs, "catalogs");
		_catalogs = new ComposablePartCatalogCollection(catalogs, OnChanged, OnChanging);
	}

	public override IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> GetExports(ImportDefinition definition)
	{
		ThrowIfDisposed();
		Requires.NotNull(definition, "definition");
		IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> enumerable = null;
		List<Tuple<ComposablePartDefinition, ExportDefinition>> list = null;
		foreach (ComposablePartCatalog catalog in _catalogs)
		{
			IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> exports = catalog.GetExports(definition);
			if (exports == ComposablePartCatalog._EmptyExportsList)
			{
				continue;
			}
			if (enumerable == null)
			{
				enumerable = exports;
				continue;
			}
			if (list == null)
			{
				list = new List<Tuple<ComposablePartDefinition, ExportDefinition>>(enumerable);
				enumerable = list;
			}
			list.AddRange(exports);
		}
		return enumerable ?? ComposablePartCatalog._EmptyExportsList;
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && Interlocked.CompareExchange(ref _isDisposed, 1, 0) == 0)
			{
				_catalogs.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	public override IEnumerator<ComposablePartDefinition> GetEnumerator()
	{
		return _catalogs.SelectMany((ComposablePartCatalog catalog) => catalog).GetEnumerator();
	}

	protected virtual void OnChanged(ComposablePartCatalogChangeEventArgs e)
	{
		_catalogs.OnChanged(this, e);
	}

	protected virtual void OnChanging(ComposablePartCatalogChangeEventArgs e)
	{
		_catalogs.OnChanging(this, e);
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

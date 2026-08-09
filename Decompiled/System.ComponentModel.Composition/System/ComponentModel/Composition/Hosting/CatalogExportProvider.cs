using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.Composition.Diagnostics;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Internal;
using Microsoft.Internal.Collections;

namespace System.ComponentModel.Composition.Hosting;

public class CatalogExportProvider : ExportProvider, IDisposable
{
	private sealed class CatalogChangeProxy : ComposablePartCatalog
	{
		private readonly ComposablePartCatalog _originalCatalog;

		private readonly List<ComposablePartDefinition> _addedParts;

		private readonly HashSet<ComposablePartDefinition> _removedParts;

		public CatalogChangeProxy(ComposablePartCatalog originalCatalog, IEnumerable<ComposablePartDefinition> addedParts, IEnumerable<ComposablePartDefinition> removedParts)
		{
			_originalCatalog = originalCatalog;
			_addedParts = new List<ComposablePartDefinition>(addedParts);
			_removedParts = new HashSet<ComposablePartDefinition>(removedParts);
		}

		public override IEnumerator<ComposablePartDefinition> GetEnumerator()
		{
			return _originalCatalog.Concat(_addedParts).Except(_removedParts).GetEnumerator();
		}

		public override IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> GetExports(ImportDefinition definition)
		{
			Requires.NotNull(definition, "definition");
			IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> exports = _originalCatalog.GetExports(definition);
			IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> first = exports.Where((Tuple<ComposablePartDefinition, ExportDefinition> partAndExport) => !_removedParts.Contains(partAndExport.Item1));
			List<Tuple<ComposablePartDefinition, ExportDefinition>> list = new List<Tuple<ComposablePartDefinition, ExportDefinition>>();
			foreach (ComposablePartDefinition addedPart in _addedParts)
			{
				foreach (ExportDefinition exportDefinition in addedPart.ExportDefinitions)
				{
					if (definition.IsConstraintSatisfiedBy(exportDefinition))
					{
						list.Add(new Tuple<ComposablePartDefinition, ExportDefinition>(addedPart, exportDefinition));
					}
				}
			}
			return first.Concat(list);
		}
	}

	private class CatalogExport : Export
	{
		protected readonly CatalogExportProvider _catalogExportProvider;

		protected readonly ComposablePartDefinition _partDefinition;

		protected readonly ExportDefinition _definition;

		public override ExportDefinition Definition => _definition;

		protected virtual bool IsSharedPart => true;

		public CatalogExport(CatalogExportProvider catalogExportProvider, ComposablePartDefinition partDefinition, ExportDefinition definition)
		{
			_catalogExportProvider = catalogExportProvider;
			_partDefinition = partDefinition;
			_definition = definition;
		}

		protected CatalogPart GetPartCore()
		{
			return _catalogExportProvider.GetComposablePart(_partDefinition, IsSharedPart);
		}

		protected void DisposePartCore(CatalogPart part, object value)
		{
			_catalogExportProvider.DisposePart(value, part, null);
		}

		protected virtual CatalogPart GetPart()
		{
			return GetPartCore();
		}

		protected override object GetExportedValueCore()
		{
			return _catalogExportProvider.GetExportedValue(GetPart(), _definition, IsSharedPart);
		}

		public static CatalogExport CreateExport(CatalogExportProvider catalogExportProvider, ComposablePartDefinition partDefinition, ExportDefinition definition, CreationPolicy importCreationPolicy)
		{
			CreationPolicy value = partDefinition.Metadata.GetValue<CreationPolicy>("System.ComponentModel.Composition.CreationPolicy");
			if (ShouldUseSharedPart(value, importCreationPolicy))
			{
				return new CatalogExport(catalogExportProvider, partDefinition, definition);
			}
			return new NonSharedCatalogExport(catalogExportProvider, partDefinition, definition);
		}

		private static bool ShouldUseSharedPart(CreationPolicy partPolicy, CreationPolicy importPolicy)
		{
			switch (partPolicy)
			{
			case CreationPolicy.Any:
				if (importPolicy == CreationPolicy.Any || importPolicy == CreationPolicy.Shared)
				{
					return true;
				}
				return false;
			case CreationPolicy.NonShared:
				if (importPolicy == CreationPolicy.Shared)
				{
					throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
				}
				return false;
			case CreationPolicy.Shared:
				if (importPolicy != CreationPolicy.NonShared)
				{
					return true;
				}
				goto default;
			default:
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
		}
	}

	private sealed class NonSharedCatalogExport(CatalogExportProvider catalogExportProvider, ComposablePartDefinition partDefinition, ExportDefinition definition) : CatalogExport(catalogExportProvider, partDefinition, definition), IDisposable
	{
		private CatalogPart _part;

		private readonly object _lock = new object();

		protected override bool IsSharedPart => false;

		protected override CatalogPart GetPart()
		{
			if (_part == null)
			{
				CatalogPart catalogPart = GetPartCore();
				lock (_lock)
				{
					if (_part == null)
					{
						Thread.MemoryBarrier();
						_part = catalogPart;
						catalogPart = null;
					}
				}
				if (catalogPart != null)
				{
					DisposePartCore(catalogPart, null);
				}
			}
			return _part;
		}

		void IDisposable.Dispose()
		{
			if (_part != null)
			{
				DisposePartCore(_part, base.Value);
				_part = null;
			}
		}
	}

	private sealed class InnerCatalogExportProvider : ExportProvider
	{
		private readonly CatalogExportProvider _outerExportProvider;

		public InnerCatalogExportProvider(CatalogExportProvider outerExportProvider)
		{
			ArgumentNullException.ThrowIfNull(outerExportProvider, "outerExportProvider");
			_outerExportProvider = outerExportProvider;
		}

		protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition atomicComposition)
		{
			return _outerExportProvider.InternalGetExportsCore(definition, atomicComposition);
		}
	}

	private enum AtomicCompositionQueryState
	{
		Unknown,
		TreatAsRejected,
		TreatAsValidated,
		NeedsTesting
	}

	private abstract class PartQueryStateNode
	{
		private readonly PartQueryStateNode _previousNode;

		private readonly AtomicCompositionQueryState _state;

		protected PartQueryStateNode(PartQueryStateNode previousNode, AtomicCompositionQueryState state)
		{
			_previousNode = previousNode;
			_state = state;
		}

		protected abstract bool IsMatchingDefinition(ComposablePartDefinition part, int partHashCode);

		public AtomicCompositionQueryState GetQueryState(ComposablePartDefinition definition)
		{
			int hashCode = definition.GetHashCode();
			PartQueryStateNode partQueryStateNode = this;
			do
			{
				if (partQueryStateNode.IsMatchingDefinition(definition, hashCode))
				{
					return partQueryStateNode._state;
				}
				partQueryStateNode = partQueryStateNode._previousNode;
			}
			while (partQueryStateNode != null);
			return AtomicCompositionQueryState.Unknown;
		}
	}

	private sealed class PartEqualsQueryStateNode : PartQueryStateNode
	{
		private readonly ComposablePartDefinition _part;

		private readonly int _hashCode;

		public PartEqualsQueryStateNode(ComposablePartDefinition part, PartQueryStateNode previousNode, AtomicCompositionQueryState state)
			: base(previousNode, state)
		{
			_part = part;
			_hashCode = part.GetHashCode();
		}

		protected override bool IsMatchingDefinition(ComposablePartDefinition part, int partHashCode)
		{
			if (partHashCode != _hashCode)
			{
				return false;
			}
			return _part.Equals(part);
		}
	}

	private sealed class PartInHashSetQueryStateNode : PartQueryStateNode
	{
		private readonly HashSet<ComposablePartDefinition> _parts;

		public PartInHashSetQueryStateNode(HashSet<ComposablePartDefinition> parts, PartQueryStateNode previousNode, AtomicCompositionQueryState state)
			: base(previousNode, state)
		{
			_parts = parts;
		}

		protected override bool IsMatchingDefinition(ComposablePartDefinition part, int partHashCode)
		{
			return _parts.Contains(part);
		}
	}

	private sealed class CatalogPart
	{
		private volatile bool _importsSatisfied;

		public ComposablePart Part { get; private set; }

		public bool ImportsSatisfied
		{
			get
			{
				return _importsSatisfied;
			}
			set
			{
				_importsSatisfied = value;
			}
		}

		public CatalogPart(ComposablePart part)
		{
			Part = part;
		}
	}

	internal abstract class FactoryExport : Export
	{
		private sealed class FactoryExportPartDefinition : ComposablePartDefinition
		{
			private readonly FactoryExport _FactoryExport;

			public override IEnumerable<ExportDefinition> ExportDefinitions => new ExportDefinition[1] { _FactoryExport.Definition };

			public override IEnumerable<ImportDefinition> ImportDefinitions => Enumerable.Empty<ImportDefinition>();

			public ExportDefinition FactoryExportDefinition => _FactoryExport.Definition;

			public FactoryExportPartDefinition(FactoryExport FactoryExport)
			{
				_FactoryExport = FactoryExport;
			}

			public Export CreateProductExport()
			{
				return _FactoryExport.CreateExportProduct();
			}

			public override ComposablePart CreatePart()
			{
				return new FactoryExportPart(this);
			}
		}

		private sealed class FactoryExportPart : ComposablePart, IDisposable
		{
			private readonly FactoryExportPartDefinition _definition;

			private readonly Export _export;

			public override IEnumerable<ExportDefinition> ExportDefinitions => _definition.ExportDefinitions;

			public override IEnumerable<ImportDefinition> ImportDefinitions => _definition.ImportDefinitions;

			public FactoryExportPart(FactoryExportPartDefinition definition)
			{
				_definition = definition;
				_export = definition.CreateProductExport();
			}

			public override object GetExportedValue(ExportDefinition definition)
			{
				if (definition != _definition.FactoryExportDefinition)
				{
					throw ExceptionBuilder.CreateExportDefinitionNotOnThisComposablePart("definition");
				}
				return _export.Value;
			}

			public override void SetImport(ImportDefinition definition, IEnumerable<Export> exports)
			{
				throw ExceptionBuilder.CreateImportDefinitionNotOnThisComposablePart("definition");
			}

			public void Dispose()
			{
				if (_export is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
		}

		private readonly ComposablePartDefinition _partDefinition;

		private readonly ExportDefinition _exportDefinition;

		private readonly ExportDefinition _factoryExportDefinition;

		private FactoryExportPartDefinition _factoryExportPartDefinition;

		public override ExportDefinition Definition => _factoryExportDefinition;

		protected ComposablePartDefinition UnderlyingPartDefinition => _partDefinition;

		protected ExportDefinition UnderlyingExportDefinition => _exportDefinition;

		public FactoryExport(ComposablePartDefinition partDefinition, ExportDefinition exportDefinition)
		{
			_partDefinition = partDefinition;
			_exportDefinition = exportDefinition;
			_factoryExportDefinition = new PartCreatorExportDefinition(_exportDefinition);
		}

		protected override object GetExportedValueCore()
		{
			return _factoryExportPartDefinition ?? (_factoryExportPartDefinition = new FactoryExportPartDefinition(this));
		}

		public abstract Export CreateExportProduct();
	}

	internal sealed class PartCreatorExport : FactoryExport
	{
		private readonly CatalogExportProvider _catalogExportProvider;

		public PartCreatorExport(CatalogExportProvider catalogExportProvider, ComposablePartDefinition partDefinition, ExportDefinition exportDefinition)
			: base(partDefinition, exportDefinition)
		{
			_catalogExportProvider = catalogExportProvider;
		}

		public override Export CreateExportProduct()
		{
			return new NonSharedCatalogExport(_catalogExportProvider, base.UnderlyingPartDefinition, base.UnderlyingExportDefinition);
		}
	}

	internal sealed class ScopeFactoryExport : FactoryExport
	{
		private sealed class ScopeCatalogExport : Export, IDisposable
		{
			private readonly ScopeFactoryExport _scopeFactoryExport;

			private CompositionContainer _childContainer;

			private Export _export;

			private readonly object _lock = new object();

			public override ExportDefinition Definition => _scopeFactoryExport.UnderlyingExportDefinition;

			public ScopeCatalogExport(ScopeFactoryExport scopeFactoryExport)
			{
				_scopeFactoryExport = scopeFactoryExport;
			}

			protected override object GetExportedValueCore()
			{
				if (_export == null)
				{
					CompositionContainer compositionContainer = _scopeFactoryExport._scopeManager.CreateChildContainer(_scopeFactoryExport._catalog);
					Export export = compositionContainer.CatalogExportProvider.CreateExport(_scopeFactoryExport.UnderlyingPartDefinition, _scopeFactoryExport.UnderlyingExportDefinition, isExportFactory: false, CreationPolicy.Any);
					lock (_lock)
					{
						if (_export == null)
						{
							_childContainer = compositionContainer;
							Thread.MemoryBarrier();
							_export = export;
							compositionContainer = null;
							export = null;
						}
					}
					compositionContainer?.Dispose();
				}
				return _export.Value;
			}

			public void Dispose()
			{
				CompositionContainer compositionContainer = null;
				if (_export != null)
				{
					lock (_lock)
					{
						Export export = _export;
						compositionContainer = _childContainer;
						_childContainer = null;
						Thread.MemoryBarrier();
						_export = null;
					}
				}
				compositionContainer?.Dispose();
			}
		}

		private readonly ScopeManager _scopeManager;

		private readonly CompositionScopeDefinition _catalog;

		internal ScopeFactoryExport(ScopeManager scopeManager, CompositionScopeDefinition catalog, ComposablePartDefinition partDefinition, ExportDefinition exportDefinition)
			: base(partDefinition, exportDefinition)
		{
			_scopeManager = scopeManager;
			_catalog = catalog;
		}

		public override Export CreateExportProduct()
		{
			return new ScopeCatalogExport(this);
		}
	}

	internal sealed class ScopeManager : ExportProvider
	{
		private readonly CompositionScopeDefinition _scopeDefinition;

		private readonly CatalogExportProvider _catalogExportProvider;

		public ScopeManager(CatalogExportProvider catalogExportProvider, CompositionScopeDefinition scopeDefinition)
		{
			ArgumentNullException.ThrowIfNull(catalogExportProvider, "catalogExportProvider");
			ArgumentNullException.ThrowIfNull(scopeDefinition, "scopeDefinition");
			_scopeDefinition = scopeDefinition;
			_catalogExportProvider = catalogExportProvider;
		}

		protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition? atomicComposition)
		{
			List<Export> list = new List<Export>();
			ImportDefinition importDefinition = TranslateImport(definition);
			if (importDefinition == null)
			{
				return list;
			}
			foreach (CompositionScopeDefinition child in _scopeDefinition.Children)
			{
				foreach (Tuple<ComposablePartDefinition, ExportDefinition> item in child.GetExportsFromPublicSurface(importDefinition))
				{
					bool flag = false;
					if (_catalogExportProvider.EnsureRejection(atomicComposition))
					{
						using CompositionContainer compositionContainer = CreateChildContainer(child);
						using AtomicComposition parentAtomicComposition = new AtomicComposition(atomicComposition);
						flag = compositionContainer.CatalogExportProvider.DetermineRejection(item.Item1, parentAtomicComposition);
					}
					if (!flag)
					{
						list.Add(CreateScopeExport(child, item.Item1, item.Item2));
					}
				}
			}
			return list;
		}

		private ScopeFactoryExport CreateScopeExport(CompositionScopeDefinition childCatalog, ComposablePartDefinition partDefinition, ExportDefinition exportDefinition)
		{
			return new ScopeFactoryExport(this, childCatalog, partDefinition, exportDefinition);
		}

		internal CompositionContainer CreateChildContainer(ComposablePartCatalog childCatalog)
		{
			return new CompositionContainer(childCatalog, _catalogExportProvider._compositionOptions, _catalogExportProvider._sourceProvider);
		}

		private static ImportDefinition TranslateImport(ImportDefinition definition)
		{
			if (!(definition is IPartCreatorImportDefinition partCreatorImportDefinition))
			{
				return null;
			}
			ContractBasedImportDefinition productImportDefinition = partCreatorImportDefinition.ProductImportDefinition;
			ImportDefinition result = null;
			switch (productImportDefinition.RequiredCreationPolicy)
			{
			case CreationPolicy.NonShared:
				result = new ContractBasedImportDefinition(productImportDefinition.ContractName, productImportDefinition.RequiredTypeIdentity, productImportDefinition.RequiredMetadata, productImportDefinition.Cardinality, productImportDefinition.IsRecomposable, productImportDefinition.IsPrerequisite, CreationPolicy.Any, productImportDefinition.Metadata);
				break;
			case CreationPolicy.Any:
				result = productImportDefinition;
				break;
			}
			return result;
		}
	}

	private readonly CompositionLock _lock;

	private readonly Dictionary<ComposablePartDefinition, CatalogPart> _activatedParts = new Dictionary<ComposablePartDefinition, CatalogPart>();

	private readonly HashSet<ComposablePartDefinition> _rejectedParts = new HashSet<ComposablePartDefinition>();

	private ConditionalWeakTable<object, List<ComposablePart>> _gcRoots;

	private readonly HashSet<IDisposable> _partsToDispose = new HashSet<IDisposable>();

	private ComposablePartCatalog _catalog;

	private volatile bool _isDisposed;

	private volatile bool _isRunning;

	private readonly bool _disableSilentRejection;

	private ExportProvider _sourceProvider;

	private ImportEngine _importEngine;

	private readonly CompositionOptions _compositionOptions;

	private ExportProvider _innerExportProvider;

	public ComposablePartCatalog Catalog
	{
		get
		{
			ThrowIfDisposed();
			return _catalog;
		}
	}

	public ExportProvider? SourceProvider
	{
		get
		{
			ThrowIfDisposed();
			using (_lock.LockStateForRead())
			{
				return _sourceProvider;
			}
		}
		[param: DisallowNull]
		set
		{
			ThrowIfDisposed();
			Requires.NotNull(value, "value");
			ImportEngine importEngine = null;
			AggregateExportProvider aggregateExportProvider = null;
			bool flag = true;
			try
			{
				importEngine = new ImportEngine(value, _compositionOptions);
				value.ExportsChanging += OnExportsChangingInternal;
				using (_lock.LockStateForWrite())
				{
					EnsureCanSet(_sourceProvider);
					_sourceProvider = value;
					_importEngine = importEngine;
					flag = false;
				}
			}
			finally
			{
				if (flag)
				{
					value.ExportsChanging -= OnExportsChangingInternal;
					importEngine.Dispose();
					aggregateExportProvider?.Dispose();
				}
			}
		}
	}

	public CatalogExportProvider(ComposablePartCatalog catalog)
		: this(catalog, CompositionOptions.Default)
	{
	}

	public CatalogExportProvider(ComposablePartCatalog catalog, bool isThreadSafe)
		: this(catalog, isThreadSafe ? CompositionOptions.IsThreadSafe : CompositionOptions.Default)
	{
	}

	public CatalogExportProvider(ComposablePartCatalog catalog, CompositionOptions compositionOptions)
	{
		Requires.NotNull(catalog, "catalog");
		if (compositionOptions > (CompositionOptions.DisableSilentRejection | CompositionOptions.IsThreadSafe | CompositionOptions.ExportCompositionService))
		{
			throw new ArgumentOutOfRangeException("compositionOptions");
		}
		_catalog = catalog;
		_compositionOptions = compositionOptions;
		if (_catalog is INotifyComposablePartCatalogChanged notifyComposablePartCatalogChanged)
		{
			notifyComposablePartCatalogChanged.Changing += OnCatalogChanging;
		}
		if (_catalog is CompositionScopeDefinition scopeDefinition)
		{
			_innerExportProvider = new AggregateExportProvider(new ScopeManager(this, scopeDefinition), new InnerCatalogExportProvider(this));
		}
		else
		{
			_innerExportProvider = new InnerCatalogExportProvider(this);
		}
		_lock = new CompositionLock(compositionOptions.HasFlag(CompositionOptions.IsThreadSafe));
		_disableSilentRejection = compositionOptions.HasFlag(CompositionOptions.DisableSilentRejection);
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
		INotifyComposablePartCatalogChanged notifyComposablePartCatalogChanged = null;
		HashSet<IDisposable> hashSet = null;
		ImportEngine importEngine = null;
		ExportProvider exportProvider = null;
		AggregateExportProvider aggregateExportProvider = null;
		try
		{
			using (_lock.LockStateForWrite())
			{
				if (!_isDisposed)
				{
					notifyComposablePartCatalogChanged = _catalog as INotifyComposablePartCatalogChanged;
					_catalog = null;
					aggregateExportProvider = _innerExportProvider as AggregateExportProvider;
					_innerExportProvider = null;
					exportProvider = _sourceProvider;
					_sourceProvider = null;
					importEngine = _importEngine;
					_importEngine = null;
					hashSet = _partsToDispose;
					_gcRoots = null;
					_isDisposed = true;
				}
			}
		}
		finally
		{
			if (notifyComposablePartCatalogChanged != null)
			{
				notifyComposablePartCatalogChanged.Changing -= OnCatalogChanging;
			}
			aggregateExportProvider?.Dispose();
			if (exportProvider != null)
			{
				exportProvider.ExportsChanging -= OnExportsChangingInternal;
			}
			importEngine?.Dispose();
			if (hashSet != null)
			{
				foreach (IDisposable item in hashSet)
				{
					item.Dispose();
				}
			}
		}
	}

	protected override IEnumerable<Export> GetExportsCore(ImportDefinition definition, AtomicComposition? atomicComposition)
	{
		ThrowIfDisposed();
		EnsureRunning();
		if (_innerExportProvider == null)
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		_innerExportProvider.TryGetExports(definition, atomicComposition, out IEnumerable<Export> exports);
		return exports;
	}

	private List<Export> InternalGetExportsCore(ImportDefinition definition, AtomicComposition atomicComposition)
	{
		ThrowIfDisposed();
		EnsureRunning();
		ComposablePartCatalog valueAllowNull = atomicComposition.GetValueAllowNull(_catalog);
		bool isExportFactory = false;
		if (definition is IPartCreatorImportDefinition partCreatorImportDefinition)
		{
			definition = partCreatorImportDefinition.ProductImportDefinition;
			isExportFactory = true;
		}
		CreationPolicy requiredCreationPolicy = definition.GetRequiredCreationPolicy();
		List<Export> list = new List<Export>();
		bool flag = EnsureRejection(atomicComposition);
		foreach (Tuple<ComposablePartDefinition, ExportDefinition> export in valueAllowNull.GetExports(definition))
		{
			if (!flag || !IsRejected(export.Item1, atomicComposition))
			{
				list.Add(CreateExport(export.Item1, export.Item2, isExportFactory, requiredCreationPolicy));
			}
		}
		return list;
	}

	private Export CreateExport(ComposablePartDefinition partDefinition, ExportDefinition exportDefinition, bool isExportFactory, CreationPolicy importPolicy)
	{
		if (isExportFactory)
		{
			return new PartCreatorExport(this, partDefinition, exportDefinition);
		}
		return CatalogExport.CreateExport(this, partDefinition, exportDefinition, importPolicy);
	}

	private void OnExportsChangingInternal(object sender, ExportsChangeEventArgs e)
	{
		UpdateRejections(e.AddedExports.Concat(e.RemovedExports), e.AtomicComposition);
	}

	private static ExportDefinition[] GetExportsFromPartDefinitions(IEnumerable<ComposablePartDefinition> partDefinitions)
	{
		List<ExportDefinition> list = new List<ExportDefinition>();
		foreach (ComposablePartDefinition partDefinition in partDefinitions)
		{
			foreach (ExportDefinition exportDefinition in partDefinition.ExportDefinitions)
			{
				list.Add(exportDefinition);
				list.Add(new PartCreatorExportDefinition(exportDefinition));
			}
		}
		return list.ToArray();
	}

	private void OnCatalogChanging(object sender, ComposablePartCatalogChangeEventArgs e)
	{
		using AtomicComposition atomicComposition = new AtomicComposition(e.AtomicComposition);
		atomicComposition.SetValue(_catalog, new CatalogChangeProxy(_catalog, e.AddedDefinitions, e.RemovedDefinitions));
		IEnumerable<ExportDefinition> addedExports = GetExportsFromPartDefinitions(e.AddedDefinitions);
		IEnumerable<ExportDefinition> removedExports = GetExportsFromPartDefinitions(e.RemovedDefinitions);
		foreach (ComposablePartDefinition removedDefinition in e.RemovedDefinitions)
		{
			CatalogPart value = null;
			bool flag = false;
			using (_lock.LockStateForRead())
			{
				flag = _activatedParts.TryGetValue(removedDefinition, out value);
			}
			if (!flag)
			{
				continue;
			}
			ComposablePartDefinition capturedDefinition = removedDefinition;
			DisposePart(null, value, atomicComposition);
			atomicComposition.AddCompleteActionAllowNull(delegate
			{
				using (_lock.LockStateForWrite())
				{
					_activatedParts.Remove(capturedDefinition);
				}
			});
		}
		UpdateRejections(addedExports.ConcatAllowingNull(removedExports), atomicComposition);
		OnExportsChanging(new ExportsChangeEventArgs(addedExports, removedExports, atomicComposition));
		atomicComposition.AddCompleteAction(delegate
		{
			OnExportsChanged(new ExportsChangeEventArgs(addedExports, removedExports, null));
		});
		atomicComposition.Complete();
	}

	private CatalogPart GetComposablePart(ComposablePartDefinition partDefinition, bool isSharedPart)
	{
		ThrowIfDisposed();
		EnsureRunning();
		CatalogPart result;
		if (isSharedPart)
		{
			result = GetSharedPart(partDefinition);
		}
		else
		{
			ComposablePart composablePart = partDefinition.CreatePart();
			result = new CatalogPart(composablePart);
			if (composablePart is IDisposable item)
			{
				using (_lock.LockStateForWrite())
				{
					_partsToDispose.Add(item);
				}
			}
		}
		return result;
	}

	private CatalogPart GetSharedPart(ComposablePartDefinition partDefinition)
	{
		CatalogPart value = null;
		using (_lock.LockStateForRead())
		{
			if (_activatedParts.TryGetValue(partDefinition, out value))
			{
				return value;
			}
		}
		ComposablePart composablePart = partDefinition.CreatePart();
		IDisposable disposable = composablePart as IDisposable;
		using (_lock.LockStateForWrite())
		{
			if (!_activatedParts.TryGetValue(partDefinition, out value))
			{
				value = new CatalogPart(composablePart);
				_activatedParts.Add(partDefinition, value);
				if (disposable != null)
				{
					_partsToDispose.Add(disposable);
				}
				composablePart = null;
				disposable = null;
			}
		}
		disposable?.Dispose();
		return value;
	}

	private object GetExportedValue(CatalogPart part, ExportDefinition export, bool isSharedPart)
	{
		ThrowIfDisposed();
		EnsureRunning();
		if (part == null)
		{
			throw new ArgumentNullException("part");
		}
		if (export == null)
		{
			throw new ArgumentNullException("export");
		}
		bool importsSatisfied = part.ImportsSatisfied;
		ImportEngine engine = (importsSatisfied ? null : _importEngine);
		object exportedValueFromComposedPart = CompositionServices.GetExportedValueFromComposedPart(engine, part.Part, export);
		if (!importsSatisfied)
		{
			part.ImportsSatisfied = true;
		}
		if (exportedValueFromComposedPart != null && !isSharedPart && part.Part.IsRecomposable())
		{
			PreventPartCollection(exportedValueFromComposedPart, part.Part);
		}
		return exportedValueFromComposedPart;
	}

	private void ReleasePart(object exportedValue, CatalogPart catalogPart, AtomicComposition atomicComposition)
	{
		ThrowIfDisposed();
		EnsureRunning();
		DisposePart(exportedValue, catalogPart, atomicComposition);
	}

	private void DisposePart(object exportedValue, CatalogPart catalogPart, AtomicComposition atomicComposition)
	{
		ArgumentNullException.ThrowIfNull(catalogPart, "catalogPart");
		if (_isDisposed)
		{
			return;
		}
		ImportEngine importEngine = null;
		using (_lock.LockStateForWrite())
		{
			if (_isDisposed)
			{
				return;
			}
			importEngine = _importEngine;
		}
		importEngine?.ReleaseImports(catalogPart.Part, atomicComposition);
		if (exportedValue != null)
		{
			atomicComposition.AddCompleteActionAllowNull(delegate
			{
				AllowPartCollection(exportedValue);
			});
		}
		ComposablePart part = catalogPart.Part;
		IDisposable diposablePart = part as IDisposable;
		if (diposablePart == null)
		{
			return;
		}
		atomicComposition.AddCompleteActionAllowNull(delegate
		{
			bool flag = false;
			if (!_isDisposed)
			{
				using (_lock.LockStateForWrite())
				{
					if (_isDisposed)
					{
						return;
					}
					flag = _partsToDispose.Remove(diposablePart);
				}
				if (flag)
				{
					diposablePart.Dispose();
				}
			}
		});
	}

	private void PreventPartCollection(object exportedValue, ComposablePart part)
	{
		ArgumentNullException.ThrowIfNull(exportedValue, "exportedValue");
		ArgumentNullException.ThrowIfNull(part, "part");
		using (_lock.LockStateForWrite())
		{
			ConditionalWeakTable<object, List<ComposablePart>> conditionalWeakTable = _gcRoots;
			if (conditionalWeakTable == null)
			{
				conditionalWeakTable = new ConditionalWeakTable<object, List<ComposablePart>>();
			}
			if (!conditionalWeakTable.TryGetValue(exportedValue, out var value))
			{
				value = new List<ComposablePart>();
				conditionalWeakTable.Add(exportedValue, value);
			}
			value.Add(part);
			if (_gcRoots == null)
			{
				Thread.MemoryBarrier();
				_gcRoots = conditionalWeakTable;
			}
		}
	}

	private void AllowPartCollection(object gcRoot)
	{
		if (_gcRoots != null)
		{
			using (_lock.LockStateForWrite())
			{
				_gcRoots.Remove(gcRoot);
			}
		}
	}

	private bool IsRejected(ComposablePartDefinition definition, AtomicComposition atomicComposition)
	{
		bool flag = false;
		if (atomicComposition != null)
		{
			switch (QueryPartState(atomicComposition, definition))
			{
			case AtomicCompositionQueryState.TreatAsRejected:
				return true;
			case AtomicCompositionQueryState.TreatAsValidated:
				return false;
			case AtomicCompositionQueryState.NeedsTesting:
				flag = true;
				break;
			default:
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			case AtomicCompositionQueryState.Unknown:
				break;
			}
		}
		if (!flag)
		{
			using (_lock.LockStateForRead())
			{
				if (_activatedParts.ContainsKey(definition))
				{
					return false;
				}
				if (_rejectedParts.Contains(definition))
				{
					return true;
				}
			}
		}
		return DetermineRejection(definition, atomicComposition);
	}

	private bool EnsureRejection(AtomicComposition atomicComposition)
	{
		if (_disableSilentRejection)
		{
			return atomicComposition != null;
		}
		return true;
	}

	private bool DetermineRejection(ComposablePartDefinition definition, AtomicComposition parentAtomicComposition)
	{
		ChangeRejectedException exception = null;
		if (!EnsureRejection(parentAtomicComposition))
		{
			return false;
		}
		using (AtomicComposition atomicComposition = new AtomicComposition(parentAtomicComposition))
		{
			UpdateAtomicCompositionQueryForPartEquals(atomicComposition, definition, AtomicCompositionQueryState.TreatAsValidated);
			ComposablePart newPart = definition.CreatePart();
			try
			{
				_importEngine.PreviewImports(newPart, atomicComposition);
				atomicComposition.AddCompleteActionAllowNull(delegate
				{
					using (_lock.LockStateForWrite())
					{
						if (!_activatedParts.ContainsKey(definition))
						{
							_activatedParts.Add(definition, new CatalogPart(newPart));
							if (newPart is IDisposable item)
							{
								_partsToDispose.Add(item);
							}
						}
					}
				});
				atomicComposition.Complete();
				return false;
			}
			catch (ChangeRejectedException ex)
			{
				exception = ex;
			}
		}
		parentAtomicComposition.AddCompleteActionAllowNull(delegate
		{
			using (_lock.LockStateForWrite())
			{
				_rejectedParts.Add(definition);
			}
			CompositionTrace.PartDefinitionRejected(definition, exception);
		});
		if (parentAtomicComposition != null)
		{
			UpdateAtomicCompositionQueryForPartEquals(parentAtomicComposition, definition, AtomicCompositionQueryState.TreatAsRejected);
		}
		return true;
	}

	private void UpdateRejections(IEnumerable<ExportDefinition> changedExports, AtomicComposition atomicComposition)
	{
		using AtomicComposition atomicComposition2 = new AtomicComposition(atomicComposition);
		HashSet<ComposablePartDefinition> hashSet = new HashSet<ComposablePartDefinition>();
		ComposablePartDefinition[] array;
		using (_lock.LockStateForRead())
		{
			array = _rejectedParts.ToArray();
		}
		ComposablePartDefinition[] array2 = array;
		foreach (ComposablePartDefinition composablePartDefinition in array2)
		{
			if (QueryPartState(atomicComposition2, composablePartDefinition) == AtomicCompositionQueryState.TreatAsValidated)
			{
				continue;
			}
			foreach (ImportDefinition item in composablePartDefinition.ImportDefinitions.Where(ImportEngine.IsRequiredImportForPreview))
			{
				if (changedExports.Any(item.IsConstraintSatisfiedBy))
				{
					hashSet.Add(composablePartDefinition);
					break;
				}
			}
		}
		UpdateAtomicCompositionQueryForPartInHashSet(atomicComposition2, hashSet, AtomicCompositionQueryState.NeedsTesting);
		List<ExportDefinition> resurrectedExports = new List<ExportDefinition>();
		foreach (ComposablePartDefinition item2 in hashSet)
		{
			if (IsRejected(item2, atomicComposition2))
			{
				continue;
			}
			resurrectedExports.AddRange(item2.ExportDefinitions);
			ComposablePartDefinition capturedPartDefinition = item2;
			atomicComposition2.AddCompleteAction(delegate
			{
				using (_lock.LockStateForWrite())
				{
					_rejectedParts.Remove(capturedPartDefinition);
				}
				CompositionTrace.PartDefinitionResurrected(capturedPartDefinition);
			});
		}
		if (resurrectedExports.Count != 0)
		{
			OnExportsChanging(new ExportsChangeEventArgs(resurrectedExports, Array.Empty<ExportDefinition>(), atomicComposition2));
			atomicComposition2.AddCompleteAction(delegate
			{
				OnExportsChanged(new ExportsChangeEventArgs(resurrectedExports, Array.Empty<ExportDefinition>(), null));
			});
		}
		atomicComposition2.Complete();
	}

	[DebuggerStepThrough]
	private void ThrowIfDisposed()
	{
		if (_isDisposed)
		{
			throw ExceptionBuilder.CreateObjectDisposed(this);
		}
	}

	[DebuggerStepThrough]
	private void EnsureCanRun()
	{
		if (_sourceProvider == null || _importEngine == null)
		{
			throw new InvalidOperationException(System.SR.Format(System.SR.ObjectMustBeInitialized, "SourceProvider"));
		}
	}

	[DebuggerStepThrough]
	private void EnsureRunning()
	{
		if (_isRunning)
		{
			return;
		}
		using (_lock.LockStateForWrite())
		{
			if (!_isRunning)
			{
				EnsureCanRun();
				_isRunning = true;
			}
		}
	}

	[DebuggerStepThrough]
	private void EnsureCanSet<T>(T currentValue) where T : class
	{
		if (_isRunning || currentValue != null)
		{
			throw new InvalidOperationException(System.SR.ObjectAlreadyInitialized);
		}
	}

	private AtomicCompositionQueryState QueryPartState(AtomicComposition atomicComposition, ComposablePartDefinition definition)
	{
		return GetPartQueryStateNode(atomicComposition)?.GetQueryState(definition) ?? AtomicCompositionQueryState.Unknown;
	}

	private PartQueryStateNode GetPartQueryStateNode(AtomicComposition atomicComposition)
	{
		atomicComposition.TryGetValue<PartQueryStateNode>(this, out var value);
		return value;
	}

	private void UpdateAtomicCompositionQueryForPartEquals(AtomicComposition atomicComposition, ComposablePartDefinition part, AtomicCompositionQueryState state)
	{
		PartQueryStateNode partQueryStateNode = GetPartQueryStateNode(atomicComposition);
		atomicComposition.SetValue(this, new PartEqualsQueryStateNode(part, partQueryStateNode, state));
	}

	private void UpdateAtomicCompositionQueryForPartInHashSet(AtomicComposition atomicComposition, HashSet<ComposablePartDefinition> hashset, AtomicCompositionQueryState state)
	{
		PartQueryStateNode partQueryStateNode = GetPartQueryStateNode(atomicComposition);
		atomicComposition.SetValue(this, new PartInHashSetQueryStateNode(hashset, partQueryStateNode, state));
	}
}

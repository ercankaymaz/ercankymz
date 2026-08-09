using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Internal;

namespace System.ComponentModel.Composition.Hosting;

public abstract class ExportProvider
{
	[CompilerGenerated]
	private EventHandler<ExportsChangeEventArgs> ExportsChanged;

	[CompilerGenerated]
	private EventHandler<ExportsChangeEventArgs> ExportsChanging;

	public event EventHandler<ExportsChangeEventArgs>? ExportsChanged;

	public event EventHandler<ExportsChangeEventArgs>? ExportsChanging;

	public IEnumerable<Export> GetExports(ImportDefinition definition)
	{
		return GetExports(definition, null);
	}

	public IEnumerable<Export> GetExports(ImportDefinition definition, AtomicComposition? atomicComposition)
	{
		Requires.NotNull(definition, "definition");
		IEnumerable<Export> exports;
		return TryGetExportsCore(definition, atomicComposition, out exports) switch
		{
			ExportCardinalityCheckResult.Match => exports, 
			ExportCardinalityCheckResult.NoExports => throw new ImportCardinalityMismatchException(System.SR.Format(System.SR.CardinalityMismatch_NoExports, definition)), 
			ExportCardinalityCheckResult.TooManyExports => throw new ImportCardinalityMismatchException(System.SR.Format(System.SR.CardinalityMismatch_TooManyExports_Constraint, definition)), 
			_ => throw new Exception(System.SR.Diagnostic_InternalExceptionMessage), 
		};
	}

	public bool TryGetExports(ImportDefinition definition, AtomicComposition? atomicComposition, out IEnumerable<Export>? exports)
	{
		Requires.NotNull(definition, "definition");
		ExportCardinalityCheckResult exportCardinalityCheckResult = TryGetExportsCore(definition, atomicComposition, out exports);
		return exportCardinalityCheckResult == ExportCardinalityCheckResult.Match;
	}

	protected abstract IEnumerable<Export>? GetExportsCore(ImportDefinition definition, AtomicComposition? atomicComposition);

	protected virtual void OnExportsChanged(ExportsChangeEventArgs e)
	{
		EventHandler<ExportsChangeEventArgs> eventHandler = this.ExportsChanged;
		if (eventHandler != null)
		{
			CompositionServices.TryFire(eventHandler, this, e).ThrowOnErrors(e.AtomicComposition);
		}
	}

	protected virtual void OnExportsChanging(ExportsChangeEventArgs e)
	{
		EventHandler<ExportsChangeEventArgs> eventHandler = this.ExportsChanging;
		if (eventHandler != null)
		{
			CompositionServices.TryFire(eventHandler, this, e).ThrowOnErrors(e.AtomicComposition);
		}
	}

	private ExportCardinalityCheckResult TryGetExportsCore(ImportDefinition definition, AtomicComposition atomicComposition, out IEnumerable<Export> exports)
	{
		ArgumentNullException.ThrowIfNull(definition, "definition");
		exports = GetExportsCore(definition, atomicComposition);
		ExportCardinalityCheckResult exportCardinalityCheckResult = ExportServices.CheckCardinality(definition, exports);
		if (exportCardinalityCheckResult == ExportCardinalityCheckResult.TooManyExports && definition.Cardinality == ImportCardinality.ZeroOrOne)
		{
			exportCardinalityCheckResult = ExportCardinalityCheckResult.Match;
			exports = null;
		}
		if (exports == null)
		{
			exports = Array.Empty<Export>();
		}
		return exportCardinalityCheckResult;
	}

	public Lazy<T>? GetExport<T>()
	{
		return GetExport<T>(null);
	}

	public Lazy<T>? GetExport<T>(string? contractName)
	{
		return GetExportCore<T>(contractName);
	}

	public Lazy<T, TMetadataView>? GetExport<T, TMetadataView>()
	{
		return GetExport<T, TMetadataView>(null);
	}

	public Lazy<T, TMetadataView>? GetExport<T, TMetadataView>(string? contractName)
	{
		return GetExportCore<T, TMetadataView>(contractName);
	}

	public IEnumerable<Lazy<object, object>> GetExports(Type type, Type? metadataViewType, string? contractName)
	{
		IEnumerable<Export> exportsCore = GetExportsCore(type, metadataViewType, contractName, ImportCardinality.ZeroOrMore);
		Collection<Lazy<object, object>> collection = new Collection<Lazy<object, object>>();
		Func<Export, Lazy<object, object>> func = ExportServices.CreateSemiStronglyTypedLazyFactory(type, metadataViewType);
		foreach (Export item in exportsCore)
		{
			collection.Add(func(item));
		}
		return collection;
	}

	public IEnumerable<Lazy<T>> GetExports<T>()
	{
		return GetExports<T>(null);
	}

	public IEnumerable<Lazy<T>> GetExports<T>(string? contractName)
	{
		return GetExportsCore<T>(contractName);
	}

	public IEnumerable<Lazy<T, TMetadataView>> GetExports<T, TMetadataView>()
	{
		return GetExports<T, TMetadataView>(null);
	}

	public IEnumerable<Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(string? contractName)
	{
		return GetExportsCore<T, TMetadataView>(contractName);
	}

	public T? GetExportedValue<T>()
	{
		return GetExportedValue<T>(null);
	}

	public T? GetExportedValue<T>(string? contractName)
	{
		return GetExportedValueCore<T>(contractName, ImportCardinality.ExactlyOne);
	}

	public T? GetExportedValueOrDefault<T>()
	{
		return GetExportedValueOrDefault<T>(null);
	}

	public T? GetExportedValueOrDefault<T>(string? contractName)
	{
		return GetExportedValueCore<T>(contractName, ImportCardinality.ZeroOrOne);
	}

	public IEnumerable<T> GetExportedValues<T>()
	{
		return GetExportedValues<T>(null);
	}

	public IEnumerable<T> GetExportedValues<T>(string? contractName)
	{
		return GetExportedValuesCore<T>(contractName);
	}

	private Collection<T> GetExportedValuesCore<T>(string contractName)
	{
		IEnumerable<Export> exportsCore = GetExportsCore(typeof(T), null, contractName, ImportCardinality.ZeroOrMore);
		Collection<T> collection = new Collection<T>();
		foreach (Export item in exportsCore)
		{
			collection.Add(ExportServices.GetCastedExportedValue<T>(item));
		}
		return collection;
	}

	private T GetExportedValueCore<T>(string contractName, ImportCardinality cardinality)
	{
		if (!cardinality.IsAtMostOne())
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		Export export = GetExportsCore(typeof(T), null, contractName, cardinality).SingleOrDefault();
		if (export == null)
		{
			return default(T);
		}
		return ExportServices.GetCastedExportedValue<T>(export);
	}

	private Collection<Lazy<T>> GetExportsCore<T>(string contractName)
	{
		IEnumerable<Export> exportsCore = GetExportsCore(typeof(T), null, contractName, ImportCardinality.ZeroOrMore);
		Collection<Lazy<T>> collection = new Collection<Lazy<T>>();
		foreach (Export item in exportsCore)
		{
			collection.Add(ExportServices.CreateStronglyTypedLazyOfT<T>(item));
		}
		return collection;
	}

	private Collection<Lazy<T, TMetadataView>> GetExportsCore<T, TMetadataView>(string contractName)
	{
		IEnumerable<Export> exportsCore = GetExportsCore(typeof(T), typeof(TMetadataView), contractName, ImportCardinality.ZeroOrMore);
		Collection<Lazy<T, TMetadataView>> collection = new Collection<Lazy<T, TMetadataView>>();
		foreach (Export item in exportsCore)
		{
			collection.Add(ExportServices.CreateStronglyTypedLazyOfTM<T, TMetadataView>(item));
		}
		return collection;
	}

	private Lazy<T, TMetadataView> GetExportCore<T, TMetadataView>(string contractName)
	{
		Export export = GetExportsCore(typeof(T), typeof(TMetadataView), contractName, ImportCardinality.ExactlyOne).SingleOrDefault();
		if (export == null)
		{
			return null;
		}
		return ExportServices.CreateStronglyTypedLazyOfTM<T, TMetadataView>(export);
	}

	private Lazy<T> GetExportCore<T>(string contractName)
	{
		Export export = GetExportsCore(typeof(T), null, contractName, ImportCardinality.ExactlyOne).SingleOrDefault();
		if (export == null)
		{
			return null;
		}
		return ExportServices.CreateStronglyTypedLazyOfT<T>(export);
	}

	private IEnumerable<Export> GetExportsCore(Type type, Type metadataViewType, string contractName, ImportCardinality cardinality)
	{
		Requires.NotNull(type, "type");
		if (string.IsNullOrEmpty(contractName))
		{
			contractName = AttributedModelServices.GetContractName(type);
		}
		if ((object)metadataViewType == null)
		{
			metadataViewType = ExportServices.DefaultMetadataViewType;
		}
		if (!MetadataViewProvider.IsViewTypeValid(metadataViewType))
		{
			throw new InvalidOperationException(System.SR.Format(System.SR.InvalidMetadataView, metadataViewType.Name));
		}
		ContractBasedImportDefinition definition = BuildImportDefinition(type, metadataViewType, contractName, cardinality);
		return GetExports(definition, null);
	}

	private static ContractBasedImportDefinition BuildImportDefinition(Type type, Type metadataViewType, string contractName, ImportCardinality cardinality)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		ArgumentNullException.ThrowIfNull(metadataViewType, "metadataViewType");
		ArgumentNullException.ThrowIfNull(contractName, "contractName");
		IEnumerable<KeyValuePair<string, Type>> requiredMetadata = CompositionServices.GetRequiredMetadata(metadataViewType);
		IDictionary<string, object> importMetadata = CompositionServices.GetImportMetadata(type, null);
		string requiredTypeIdentity = null;
		if (type != typeof(object))
		{
			requiredTypeIdentity = AttributedModelServices.GetTypeIdentity(type);
		}
		return new ContractBasedImportDefinition(contractName, requiredTypeIdentity, requiredMetadata, cardinality, isRecomposable: false, isPrerequisite: true, CreationPolicy.Any, importMetadata);
	}
}

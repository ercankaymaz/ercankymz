using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using Microsoft.Internal;
using Microsoft.Internal.Collections;

namespace System.ComponentModel.Composition.ReflectionModel;

internal class ReflectionComposablePart : ComposablePart, ICompositionElement
{
	private readonly ReflectionComposablePartDefinition _definition;

	private volatile Dictionary<ImportDefinition, object> _importValues;

	private volatile Dictionary<ImportDefinition, ImportingItem> _importsCache;

	private volatile Dictionary<int, ExportingMember> _exportsCache;

	private volatile bool _invokeImportsSatisfied = true;

	private bool _initialCompositionComplete;

	private volatile object _cachedInstance;

	private readonly object _lock = new object();

	private Dictionary<ImportDefinition, object?> ImportValues
	{
		get
		{
			Dictionary<ImportDefinition, object> dictionary = _importValues;
			if (dictionary == null)
			{
				lock (_lock)
				{
					dictionary = _importValues;
					if (dictionary == null)
					{
						dictionary = (_importValues = new Dictionary<ImportDefinition, object>());
					}
				}
			}
			return dictionary;
		}
	}

	private Dictionary<ImportDefinition, ImportingItem> ImportsCache
	{
		get
		{
			Dictionary<ImportDefinition, ImportingItem> dictionary = _importsCache;
			if (dictionary == null)
			{
				lock (_lock)
				{
					if (dictionary == null)
					{
						dictionary = (_importsCache = new Dictionary<ImportDefinition, ImportingItem>());
					}
				}
			}
			return dictionary;
		}
	}

	protected object? CachedInstance
	{
		get
		{
			lock (_lock)
			{
				return _cachedInstance;
			}
		}
	}

	public ReflectionComposablePartDefinition Definition
	{
		get
		{
			RequiresRunning();
			return _definition;
		}
	}

	public override IDictionary<string, object?> Metadata
	{
		get
		{
			RequiresRunning();
			return Definition.Metadata;
		}
	}

	public sealed override IEnumerable<ImportDefinition> ImportDefinitions
	{
		get
		{
			RequiresRunning();
			return Definition.ImportDefinitions;
		}
	}

	public sealed override IEnumerable<ExportDefinition> ExportDefinitions
	{
		get
		{
			RequiresRunning();
			return Definition.ExportDefinitions;
		}
	}

	string ICompositionElement.DisplayName => GetDisplayName();

	ICompositionElement ICompositionElement.Origin => Definition;

	public ReflectionComposablePart(ReflectionComposablePartDefinition definition)
	{
		Requires.NotNull(definition, "definition");
		_definition = definition;
	}

	public ReflectionComposablePart(ReflectionComposablePartDefinition definition, object attributedPart)
	{
		Requires.NotNull(definition, "definition");
		Requires.NotNull(attributedPart, "attributedPart");
		_definition = definition;
		if (attributedPart is ValueType)
		{
			throw new ArgumentException(System.SR.ArgumentValueType, "attributedPart");
		}
		_cachedInstance = attributedPart;
	}

	protected virtual void EnsureRunning()
	{
	}

	protected void RequiresRunning()
	{
		EnsureRunning();
	}

	protected virtual void ReleaseInstanceIfNecessary(object? instance)
	{
	}

	public override object? GetExportedValue(ExportDefinition definition)
	{
		RequiresRunning();
		Requires.NotNull(definition, "definition");
		ExportingMember exportingMember = null;
		lock (_lock)
		{
			exportingMember = GetExportingMemberFromDefinition(definition);
			if (exportingMember == null)
			{
				throw ExceptionBuilder.CreateExportDefinitionNotOnThisComposablePart("definition");
			}
			EnsureGettable();
		}
		return GetExportedValue(exportingMember);
	}

	public override void SetImport(ImportDefinition definition, IEnumerable<Export> exports)
	{
		RequiresRunning();
		Requires.NotNull(definition, "definition");
		Requires.NotNull(exports, "exports");
		ImportingItem importingItemFromDefinition = GetImportingItemFromDefinition(definition);
		if (importingItemFromDefinition == null)
		{
			throw ExceptionBuilder.CreateImportDefinitionNotOnThisComposablePart("definition");
		}
		EnsureSettable(definition);
		Export[] exports2 = exports.AsArray();
		EnsureCardinality(definition, exports2);
		SetImport(importingItemFromDefinition, exports2);
	}

	public override void Activate()
	{
		RequiresRunning();
		SetNonPrerequisiteImports();
		NotifyImportSatisfied();
		lock (_lock)
		{
			_initialCompositionComplete = true;
			_importValues = null;
			_importsCache = null;
		}
	}

	public override string ToString()
	{
		return GetDisplayName();
	}

	private object GetExportedValue(ExportingMember member)
	{
		object instance = null;
		if (member.RequiresInstance)
		{
			instance = GetInstanceActivatingIfNeeded();
		}
		return member.GetExportedValue(instance, _lock);
	}

	private void SetImport(ImportingItem item, Export[] exports)
	{
		object value = item.CastExportsToImportType(exports);
		lock (_lock)
		{
			_invokeImportsSatisfied = true;
			ImportValues[item.Definition] = value;
		}
	}

	private object GetInstanceActivatingIfNeeded()
	{
		object cachedInstance = _cachedInstance;
		if (cachedInstance != null)
		{
			return cachedInstance;
		}
		ConstructorInfo constructorInfo = null;
		object[] arguments = null;
		lock (_lock)
		{
			if (!RequiresActivation())
			{
				return null;
			}
			constructorInfo = Definition.GetConstructor();
			if (constructorInfo == null)
			{
				throw new ComposablePartException(System.SR.Format(System.SR.ReflectionModel_PartConstructorMissing, Definition.GetPartType().FullName), Definition.ToElement());
			}
			arguments = GetConstructorArguments();
		}
		object obj = CreateInstance(constructorInfo, arguments);
		SetPrerequisiteImports();
		if (_cachedInstance == null)
		{
			lock (_lock)
			{
				if (_cachedInstance == null)
				{
					_cachedInstance = obj;
					obj = null;
				}
			}
		}
		if (obj != null)
		{
			ReleaseInstanceIfNecessary(obj);
		}
		return _cachedInstance;
	}

	private object[] GetConstructorArguments()
	{
		ReflectionParameterImportDefinition[] array = ImportDefinitions.OfType<ReflectionParameterImportDefinition>().ToArray();
		object[] arguments = new object[array.Length];
		UseImportedValues(array, delegate(ImportingItem import, ReflectionParameterImportDefinition definition, object value)
		{
			if (definition.Cardinality == ImportCardinality.ZeroOrMore && !import.ImportType.IsAssignableCollectionType)
			{
				throw new ComposablePartException(System.SR.Format(System.SR.ReflectionModel_ImportManyOnParameterCanOnlyBeAssigned, Definition.GetPartType().FullName, definition.ImportingLazyParameter.Value.Name), Definition.ToElement());
			}
			arguments[definition.ImportingLazyParameter.Value.Position] = value;
		}, errorIfMissing: true);
		return arguments;
	}

	private bool RequiresActivation()
	{
		if (ImportDefinitions.Any())
		{
			return true;
		}
		return ExportDefinitions.Any(delegate(ExportDefinition definition)
		{
			ExportingMember exportingMemberFromDefinition = GetExportingMemberFromDefinition(definition);
			return exportingMemberFromDefinition.RequiresInstance;
		});
	}

	private void EnsureGettable()
	{
		if (_initialCompositionComplete)
		{
			return;
		}
		foreach (ImportDefinition item in ImportDefinitions.Where((ImportDefinition definition) => definition.IsPrerequisite))
		{
			if (_importValues == null || !ImportValues.ContainsKey(item))
			{
				throw new InvalidOperationException(System.SR.Format(System.SR.InvalidOperation_GetExportedValueBeforePrereqImportSet, item.ToElement().DisplayName));
			}
		}
	}

	private void EnsureSettable(ImportDefinition definition)
	{
		lock (_lock)
		{
			if (_initialCompositionComplete && !definition.IsRecomposable)
			{
				throw new InvalidOperationException(System.SR.InvalidOperation_DefinitionCannotBeRecomposed);
			}
		}
	}

	private static void EnsureCardinality(ImportDefinition definition, Export[] exports)
	{
		Requires.NullOrNotNullElements(exports, "exports");
		switch (ExportServices.CheckCardinality(definition, exports))
		{
		case ExportCardinalityCheckResult.NoExports:
			throw new ArgumentException(System.SR.Argument_ExportsEmpty, "exports");
		case ExportCardinalityCheckResult.TooManyExports:
			throw new ArgumentException(System.SR.Argument_ExportsTooMany, "exports");
		default:
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		case ExportCardinalityCheckResult.Match:
			break;
		}
	}

	private object CreateInstance(ConstructorInfo constructor, object[] arguments)
	{
		Exception ex = null;
		object result = null;
		try
		{
			result = constructor.SafeInvoke(arguments);
		}
		catch (TypeInitializationException ex2)
		{
			ex = ex2;
		}
		catch (TargetInvocationException ex3)
		{
			ex = ex3.InnerException;
		}
		if (ex != null)
		{
			throw new ComposablePartException(System.SR.Format(System.SR.ReflectionModel_PartConstructorThrewException, Definition.GetPartType().FullName), Definition.ToElement(), ex);
		}
		return result;
	}

	private void SetNonPrerequisiteImports()
	{
		IEnumerable<ImportDefinition> definitions = ImportDefinitions.Where((ImportDefinition import) => !import.IsPrerequisite);
		UseImportedValues(definitions, SetExportedValueForImport, errorIfMissing: false);
	}

	private void SetPrerequisiteImports()
	{
		IEnumerable<ImportDefinition> definitions = ImportDefinitions.Where((ImportDefinition import) => import.IsPrerequisite);
		UseImportedValues(definitions, SetExportedValueForImport, errorIfMissing: false);
	}

	private void SetExportedValueForImport(ImportingItem import, ImportDefinition definition, object value)
	{
		ImportingMember importingMember = (ImportingMember)import;
		object instanceActivatingIfNeeded = GetInstanceActivatingIfNeeded();
		importingMember.SetExportedValue(instanceActivatingIfNeeded, value);
	}

	private void UseImportedValues<TImportDefinition>(IEnumerable<TImportDefinition> definitions, Action<ImportingItem, TImportDefinition, object> useImportValue, bool errorIfMissing) where TImportDefinition : ImportDefinition
	{
		CompositionResult compositionResult = CompositionResult.SucceededResult;
		foreach (TImportDefinition definition in definitions)
		{
			ImportingItem importingItemFromDefinition = GetImportingItemFromDefinition(definition);
			if (!TryGetImportValue(definition, out var value))
			{
				if (!errorIfMissing)
				{
					continue;
				}
				if (definition.Cardinality == ImportCardinality.ExactlyOne)
				{
					CompositionError error = CompositionError.Create(CompositionErrorId.ImportNotSetOnPart, System.SR.ImportNotSetOnPart, Definition.GetPartType().FullName, definition.ToString());
					compositionResult = compositionResult.MergeError(error);
					continue;
				}
				value = importingItemFromDefinition.CastExportsToImportType(Array.Empty<Export>());
			}
			useImportValue(importingItemFromDefinition, definition, value);
		}
		compositionResult.ThrowOnErrors();
	}

	private bool TryGetImportValue(ImportDefinition definition, out object value)
	{
		lock (_lock)
		{
			if (_importValues != null && ImportValues.TryGetValue(definition, out value))
			{
				ImportValues.Remove(definition);
				return true;
			}
		}
		value = null;
		return false;
	}

	private void NotifyImportSatisfied()
	{
		if (!_invokeImportsSatisfied)
		{
			return;
		}
		IPartImportsSatisfiedNotification partImportsSatisfiedNotification = GetInstanceActivatingIfNeeded() as IPartImportsSatisfiedNotification;
		lock (_lock)
		{
			if (!_invokeImportsSatisfied)
			{
				return;
			}
			_invokeImportsSatisfied = false;
		}
		if (partImportsSatisfiedNotification != null)
		{
			try
			{
				partImportsSatisfiedNotification.OnImportsSatisfied();
			}
			catch (Exception innerException)
			{
				throw new ComposablePartException(System.SR.Format(System.SR.ReflectionModel_PartOnImportsSatisfiedThrewException, Definition.GetPartType().FullName), Definition.ToElement(), innerException);
			}
		}
	}

	private ExportingMember GetExportingMemberFromDefinition(ExportDefinition definition)
	{
		if (!(definition is ReflectionMemberExportDefinition reflectionMemberExportDefinition))
		{
			return null;
		}
		int index = reflectionMemberExportDefinition.GetIndex();
		if (_exportsCache == null)
		{
			_exportsCache = new Dictionary<int, ExportingMember>();
		}
		if (!_exportsCache.TryGetValue(index, out var value))
		{
			value = GetExportingMember(definition);
			if (value != null)
			{
				_exportsCache[index] = value;
			}
		}
		return value;
	}

	private ImportingItem GetImportingItemFromDefinition(ImportDefinition definition)
	{
		if (!ImportsCache.TryGetValue(definition, out ImportingItem value))
		{
			value = GetImportingItem(definition);
			if (value != null)
			{
				ImportsCache[definition] = value;
			}
		}
		return value;
	}

	private static ImportingItem GetImportingItem(ImportDefinition definition)
	{
		if (definition is ReflectionImportDefinition reflectionImportDefinition)
		{
			return reflectionImportDefinition.ToImportingItem();
		}
		return null;
	}

	private static ExportingMember GetExportingMember(ExportDefinition definition)
	{
		if (definition is ReflectionMemberExportDefinition reflectionMemberExportDefinition)
		{
			return reflectionMemberExportDefinition.ToExportingMember();
		}
		return null;
	}

	private string GetDisplayName()
	{
		return _definition.GetPartType().GetDisplayName();
	}
}

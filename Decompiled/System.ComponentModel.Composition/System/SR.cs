using System.Resources;
using FxResources.System.ComponentModel.Composition;

namespace System;

internal static class SR
{
	private static readonly bool s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out var isEnabled) && isEnabled;

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string ArgumentException_EmptyString => GetResourceString("ArgumentException_EmptyString");

	internal static string ArgumentOutOfRange_InvalidEnum => GetResourceString("ArgumentOutOfRange_InvalidEnum");

	internal static string ArgumentValueType => GetResourceString("ArgumentValueType");

	internal static string Argument_AssemblyReflectionOnly => GetResourceString("Argument_AssemblyReflectionOnly");

	internal static string Argument_NullElement => GetResourceString("Argument_NullElement");

	internal static string CardinalityMismatch_NoExports => GetResourceString("CardinalityMismatch_NoExports");

	internal static string CardinalityMismatch_TooManyExports_Constraint => GetResourceString("CardinalityMismatch_TooManyExports_Constraint");

	internal static string ImportEngine_ComposeTookTooManyIterations => GetResourceString("ImportEngine_ComposeTookTooManyIterations");

	internal static string ContractMismatch_ExportedValueCannotBeCastToT => GetResourceString("ContractMismatch_ExportedValueCannotBeCastToT");

	internal static string DirectoryNotFound => GetResourceString("DirectoryNotFound");

	internal static string ReflectionModel_PartConstructorThrewException => GetResourceString("ReflectionModel_PartConstructorThrewException");

	internal static string ReflectionModel_ExportThrewException => GetResourceString("ReflectionModel_ExportThrewException");

	internal static string ReflectionModel_PartOnImportsSatisfiedThrewException => GetResourceString("ReflectionModel_PartOnImportsSatisfiedThrewException");

	internal static string ReflectionModel_ImportThrewException => GetResourceString("ReflectionModel_ImportThrewException");

	internal static string ExportDefinitionNotOnThisComposablePart => GetResourceString("ExportDefinitionNotOnThisComposablePart");

	internal static string ReflectionModel_ImportCollectionNotWritable => GetResourceString("ReflectionModel_ImportCollectionNotWritable");

	internal static string ReflectionModel_ImportCollectionNull => GetResourceString("ReflectionModel_ImportCollectionNull");

	internal static string ImportEngine_PartCycle => GetResourceString("ImportEngine_PartCycle");

	internal static string ImportDefinitionNotOnThisComposablePart => GetResourceString("ImportDefinitionNotOnThisComposablePart");

	internal static string ImportNotSetOnPart => GetResourceString("ImportNotSetOnPart");

	internal static string ReflectionModel_ImportNotWritable => GetResourceString("ReflectionModel_ImportNotWritable");

	internal static string InternalExceptionMessage => GetResourceString("InternalExceptionMessage");

	internal static string InvalidMetadataView => GetResourceString("InvalidMetadataView");

	internal static string NotSupportedInterfaceMetadataView => GetResourceString("NotSupportedInterfaceMetadataView");

	internal static string ReflectionModel_PartConstructorMissing => GetResourceString("ReflectionModel_PartConstructorMissing");

	internal static string NotImplemented_NotOverriddenByDerived => GetResourceString("NotImplemented_NotOverriddenByDerived");

	internal static string ObjectAlreadyInitialized => GetResourceString("ObjectAlreadyInitialized");

	internal static string ObjectMustBeInitialized => GetResourceString("ObjectMustBeInitialized");

	internal static string ReflectionModel_ImportNotAssignableFromExport => GetResourceString("ReflectionModel_ImportNotAssignableFromExport");

	internal static string ReflectionModel_ExportNotReadable => GetResourceString("ReflectionModel_ExportNotReadable");

	internal static string Argument_ElementReflectionOnlyType => GetResourceString("Argument_ElementReflectionOnlyType");

	internal static string InvalidOperation_DefinitionCannotBeRecomposed => GetResourceString("InvalidOperation_DefinitionCannotBeRecomposed");

	internal static string Argument_ExportsEmpty => GetResourceString("Argument_ExportsEmpty");

	internal static string Argument_ExportsTooMany => GetResourceString("Argument_ExportsTooMany");

	internal static string CompositionElement_UnknownOrigin => GetResourceString("CompositionElement_UnknownOrigin");

	internal static string ImportEngine_PartCannotActivate => GetResourceString("ImportEngine_PartCannotActivate");

	internal static string ImportEngine_PartCannotSetImport => GetResourceString("ImportEngine_PartCannotSetImport");

	internal static string ImportEngine_PartCannotGetExportedValue => GetResourceString("ImportEngine_PartCannotGetExportedValue");

	internal static string TypeCatalog_Empty => GetResourceString("TypeCatalog_Empty");

	internal static string InvalidOperation_GetExportedValueBeforePrereqImportSet => GetResourceString("InvalidOperation_GetExportedValueBeforePrereqImportSet");

	internal static string CompositionException_ErrorPrefix => GetResourceString("CompositionException_ErrorPrefix");

	internal static string CompositionException_MultipleErrorsWithMultiplePaths => GetResourceString("CompositionException_MultipleErrorsWithMultiplePaths");

	internal static string CompositionException_ReviewErrorProperty => GetResourceString("CompositionException_ReviewErrorProperty");

	internal static string CompositionException_SingleErrorWithMultiplePaths => GetResourceString("CompositionException_SingleErrorWithMultiplePaths");

	internal static string CompositionException_SingleErrorWithSinglePath => GetResourceString("CompositionException_SingleErrorWithSinglePath");

	internal static string ReflectionModel_ImportCollectionGetThrewException => GetResourceString("ReflectionModel_ImportCollectionGetThrewException");

	internal static string ReflectionModel_ImportCollectionAddThrewException => GetResourceString("ReflectionModel_ImportCollectionAddThrewException");

	internal static string ReflectionModel_ImportCollectionClearThrewException => GetResourceString("ReflectionModel_ImportCollectionClearThrewException");

	internal static string ReflectionModel_ImportCollectionIsReadOnlyThrewException => GetResourceString("ReflectionModel_ImportCollectionIsReadOnlyThrewException");

	internal static string ReflectionModel_ImportCollectionConstructionThrewException => GetResourceString("ReflectionModel_ImportCollectionConstructionThrewException");

	internal static string CompositionTrace_Discovery_MemberMarkedWithMultipleImportAndImportMany => GetResourceString("CompositionTrace_Discovery_MemberMarkedWithMultipleImportAndImportMany");

	internal static string Discovery_MetadataContainsValueWithInvalidType => GetResourceString("Discovery_MetadataContainsValueWithInvalidType");

	internal static string Discovery_DuplicateMetadataNameValues => GetResourceString("Discovery_DuplicateMetadataNameValues");

	internal static string Discovery_ReservedMetadataNameUsed => GetResourceString("Discovery_ReservedMetadataNameUsed");

	internal static string ReflectionModel_InvalidExportDefinition => GetResourceString("ReflectionModel_InvalidExportDefinition");

	internal static string ImportEngine_PreventedByExistingImport => GetResourceString("ImportEngine_PreventedByExistingImport");

	internal static string ReflectionModel_InvalidImportDefinition => GetResourceString("ReflectionModel_InvalidImportDefinition");

	internal static string ReflectionModel_InvalidPartDefinition => GetResourceString("ReflectionModel_InvalidPartDefinition");

	internal static string ArgumentOutOfRange_InvalidEnumInSet => GetResourceString("ArgumentOutOfRange_InvalidEnumInSet");

	internal static string ReflectionModel_InvalidMemberImportDefinition => GetResourceString("ReflectionModel_InvalidMemberImportDefinition");

	internal static string ReflectionModel_InvalidParameterImportDefinition => GetResourceString("ReflectionModel_InvalidParameterImportDefinition");

	internal static string LazyMemberInfo_AccessorsNull => GetResourceString("LazyMemberInfo_AccessorsNull");

	internal static string LazyMemberInfo_InvalidAccessorOnSimpleMember => GetResourceString("LazyMemberInfo_InvalidAccessorOnSimpleMember");

	internal static string LazyMemberinfo_InvalidEventAccessors_AccessorType => GetResourceString("LazyMemberinfo_InvalidEventAccessors_AccessorType");

	internal static string LazyMemberInfo_InvalidEventAccessors_Cardinality => GetResourceString("LazyMemberInfo_InvalidEventAccessors_Cardinality");

	internal static string LazyMemberinfo_InvalidPropertyAccessors_AccessorType => GetResourceString("LazyMemberinfo_InvalidPropertyAccessors_AccessorType");

	internal static string LazyMemberInfo_InvalidPropertyAccessors_Cardinality => GetResourceString("LazyMemberInfo_InvalidPropertyAccessors_Cardinality");

	internal static string LazyMemberInfo_NoAccessors => GetResourceString("LazyMemberInfo_NoAccessors");

	internal static string LazyServices_LazyResolvesToNull => GetResourceString("LazyServices_LazyResolvesToNull");

	internal static string InvalidMetadataValue => GetResourceString("InvalidMetadataValue");

	internal static string ContractMismatch_InvalidCastOnMetadataField => GetResourceString("ContractMismatch_InvalidCastOnMetadataField");

	internal static string ContractMismatch_NullReferenceOnMetadataField => GetResourceString("ContractMismatch_NullReferenceOnMetadataField");

	internal static string InvalidSetterOnMetadataField => GetResourceString("InvalidSetterOnMetadataField");

	internal static string CompositionException_ChangesRejected => GetResourceString("CompositionException_ChangesRejected");

	internal static string ImportEngine_InvalidStateForRecomposition => GetResourceString("ImportEngine_InvalidStateForRecomposition");

	internal static string AtomicComposition_AlreadyCompleted => GetResourceString("AtomicComposition_AlreadyCompleted");

	internal static string AtomicComposition_PartOfAnotherAtomicComposition => GetResourceString("AtomicComposition_PartOfAnotherAtomicComposition");

	internal static string AtomicComposition_AlreadyNested => GetResourceString("AtomicComposition_AlreadyNested");

	internal static string ReentrantCompose => GetResourceString("ReentrantCompose");

	internal static string ReflectionModel_ImportManyOnParameterCanOnlyBeAssigned => GetResourceString("ReflectionModel_ImportManyOnParameterCanOnlyBeAssigned");

	internal static string CompositionException_ElementPrefix => GetResourceString("CompositionException_ElementPrefix");

	internal static string CompositionException_OriginSeparator => GetResourceString("CompositionException_OriginSeparator");

	internal static string CompositionTrace_Rejection_DefinitionRejected => GetResourceString("CompositionTrace_Rejection_DefinitionRejected");

	internal static string CompositionTrace_Rejection_DefinitionResurrected => GetResourceString("CompositionTrace_Rejection_DefinitionResurrected");

	internal static string CompositionTrace_Discovery_AssemblyLoadFailed => GetResourceString("CompositionTrace_Discovery_AssemblyLoadFailed");

	internal static string CompositionTrace_Discovery_DefinitionContainsNoExports => GetResourceString("CompositionTrace_Discovery_DefinitionContainsNoExports");

	internal static string CompositionTrace_Discovery_DefinitionMarkedWithPartNotDiscoverableAttribute => GetResourceString("CompositionTrace_Discovery_DefinitionMarkedWithPartNotDiscoverableAttribute");

	internal static string CompositionException_MetadataViewInvalidConstructor => GetResourceString("CompositionException_MetadataViewInvalidConstructor");

	internal static string CompositionException_PathsCountSeparator => GetResourceString("CompositionException_PathsCountSeparator");

	internal static string CompositionException_OriginFormat => GetResourceString("CompositionException_OriginFormat");

	internal static string TypeCatalog_DisplayNameFormat => GetResourceString("TypeCatalog_DisplayNameFormat");

	internal static string ImportNotValidOnIndexers => GetResourceString("ImportNotValidOnIndexers");

	internal static string ExportNotValidOnIndexers => GetResourceString("ExportNotValidOnIndexers");

	internal static string ReflectionContext_Requires_DefaultConstructor => GetResourceString("ReflectionContext_Requires_DefaultConstructor");

	internal static string ReflectionContext_Type_Required => GetResourceString("ReflectionContext_Type_Required");

	internal static string CompositionTrace_Discovery_DefinitionMismatchedExportArity => GetResourceString("CompositionTrace_Discovery_DefinitionMismatchedExportArity");

	internal static string Argument_ReflectionContextReturnsReflectionOnlyType => GetResourceString("Argument_ReflectionContextReturnsReflectionOnlyType");

	internal static string ContractMismatch_MetadataViewImplementationDoesNotImplementViewInterface => GetResourceString("ContractMismatch_MetadataViewImplementationDoesNotImplementViewInterface");

	internal static string ContractMismatch_MetadataViewImplementationCanNotBeNull => GetResourceString("ContractMismatch_MetadataViewImplementationCanNotBeNull");

	internal static string ExportFactory_TooManyGenericParameters => GetResourceString("ExportFactory_TooManyGenericParameters");

	internal static string NotSupportedCatalogChanges => GetResourceString("NotSupportedCatalogChanges");

	internal static string InvalidOperation_RevertAndCompleteActionsMustNotThrow => GetResourceString("InvalidOperation_RevertAndCompleteActionsMustNotThrow");

	internal static string PlatformNotSupported_ComponentModel_Composition => GetResourceString("PlatformNotSupported_ComponentModel_Composition");

	internal static string Expecting_AtleastOne_Type => GetResourceString("Expecting_AtleastOne_Type");

	internal static string Expecting_Empty_Queue => GetResourceString("Expecting_Empty_Queue");

	internal static string Expecting_Generic_Type => GetResourceString("Expecting_Generic_Type");

	internal static string Diagnostic_InternalExceptionMessage => GetResourceString("Diagnostic_InternalExceptionMessage");

	internal static string Diagnostic_TraceUnnecessaryWork => GetResourceString("Diagnostic_TraceUnnecessaryWork");

	internal static bool UsingResourceKeys()
	{
		return s_usingResourceKeys;
	}

	private static string GetResourceString(string resourceKey)
	{
		if (UsingResourceKeys())
		{
			return resourceKey;
		}
		string result = null;
		try
		{
			result = ResourceManager.GetString(resourceKey);
		}
		catch (MissingManifestResourceException)
		{
		}
		return result;
	}

	private static string GetResourceString(string resourceKey, string defaultString)
	{
		string resourceString = GetResourceString(resourceKey);
		if (!(resourceKey == resourceString) && resourceString != null)
		{
			return resourceString;
		}
		return defaultString;
	}

	internal static string Format(string resourceFormat, object? p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object? p1, object? p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(resourceFormat, p1, p2);
	}

	internal static string Format(string resourceFormat, object? p1, object? p2, object? p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(resourceFormat, p1, p2, p3);
	}

	internal static string Format(string resourceFormat, params object?[]? args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + ", " + string.Join(", ", args);
			}
			return string.Format(resourceFormat, args);
		}
		return resourceFormat;
	}

	internal static string Format(IFormatProvider? provider, string resourceFormat, object? p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(provider, resourceFormat, p1);
	}

	internal static string Format(IFormatProvider? provider, string resourceFormat, object? p1, object? p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(provider, resourceFormat, p1, p2);
	}

	internal static string Format(IFormatProvider? provider, string resourceFormat, object? p1, object? p2, object? p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(provider, resourceFormat, p1, p2, p3);
	}

	internal static string Format(IFormatProvider? provider, string resourceFormat, params object?[]? args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + ", " + string.Join(", ", args);
			}
			return string.Format(provider, resourceFormat, args);
		}
		return resourceFormat;
	}
}

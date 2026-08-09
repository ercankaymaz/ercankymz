namespace System.Composition.Diagnostics;

internal enum CompositionTraceId : ushort
{
	Rejection_DefinitionRejected = 1,
	Rejection_DefinitionResurrected = 2,
	Discovery_AssemblyLoadFailed = 3,
	Discovery_DefinitionMarkedWithPartNotDiscoverableAttribute = 4,
	Discovery_DefinitionMismatchedExportArity = 5,
	Discovery_DefinitionContainsNoExports = 6,
	Discovery_MemberMarkedWithMultipleImportAndImportMany = 7,
	Registration_ConstructorConventionOverridden = 101,
	Registration_TypeExportConventionOverridden = 102,
	Registration_MemberExportConventionOverridden = 103,
	Registration_MemberImportConventionOverridden = 104,
	Registration_PartCreationConventionOverridden = 105,
	Registration_MemberImportConventionMatchedTwice = 106,
	Registration_PartMetadataConventionOverridden = 107,
	Registration_ParameterImportConventionOverridden = 108,
	Registration_OnSatisfiedImportNotificationOverridden = 109
}

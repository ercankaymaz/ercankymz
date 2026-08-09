using System.Resources;
using FxResources.System.DirectoryServices.AccountManagement;

namespace System;

internal static class SR
{
	private static readonly bool s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out var isEnabled) && isEnabled;

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string ContextNoWellKnownObjects => GetResourceString("ContextNoWellKnownObjects");

	internal static string ContextNoContainerForMachineCtx => GetResourceString("ContextNoContainerForMachineCtx");

	internal static string ContextNoContainerForApplicationDirectoryCtx => GetResourceString("ContextNoContainerForApplicationDirectoryCtx");

	internal static string ContextBadUserPwdCombo => GetResourceString("ContextBadUserPwdCombo");

	internal static string StoreNotSupportMethod => GetResourceString("StoreNotSupportMethod");

	internal static string PrincipalUnsupportPropertyForPlatform => GetResourceString("PrincipalUnsupportPropertyForPlatform");

	internal static string PrincipalUnsupportPropertyForType => GetResourceString("PrincipalUnsupportPropertyForType");

	internal static string PrincipalMustSetContextForSave => GetResourceString("PrincipalMustSetContextForSave");

	internal static string PrincipalMustSetContextForNative => GetResourceString("PrincipalMustSetContextForNative");

	internal static string PrincipalMustSetContextForProperty => GetResourceString("PrincipalMustSetContextForProperty");

	internal static string PrincipalCantDeleteUnpersisted => GetResourceString("PrincipalCantDeleteUnpersisted");

	internal static string PrincipalAccessedAfterBeingDeleted => GetResourceString("PrincipalAccessedAfterBeingDeleted");

	internal static string PrincipalNotSupportedOnFakePrincipal => GetResourceString("PrincipalNotSupportedOnFakePrincipal");

	internal static string PrincipalMustPersistFirst => GetResourceString("PrincipalMustPersistFirst");

	internal static string PrincipalSearcherPersistedPrincipal => GetResourceString("PrincipalSearcherPersistedPrincipal");

	internal static string PrincipalSearcherMustSetFilter => GetResourceString("PrincipalSearcherMustSetFilter");

	internal static string PrincipalSearcherNoUnderlying => GetResourceString("PrincipalSearcherNoUnderlying");

	internal static string PrincipalSearcherNonReferentialProps => GetResourceString("PrincipalSearcherNonReferentialProps");

	internal static string FindResultEnumInvalidPos => GetResourceString("FindResultEnumInvalidPos");

	internal static string TrackedCollectionNotOneDimensional => GetResourceString("TrackedCollectionNotOneDimensional");

	internal static string TrackedCollectionIndexNotInArray => GetResourceString("TrackedCollectionIndexNotInArray");

	internal static string TrackedCollectionArrayTooSmall => GetResourceString("TrackedCollectionArrayTooSmall");

	internal static string TrackedCollectionEnumHasChanged => GetResourceString("TrackedCollectionEnumHasChanged");

	internal static string TrackedCollectionEnumInvalidPos => GetResourceString("TrackedCollectionEnumInvalidPos");

	internal static string MultipleMatchingPrincipals => GetResourceString("MultipleMatchingPrincipals");

	internal static string NoMatchingPrincipalExceptionText => GetResourceString("NoMatchingPrincipalExceptionText");

	internal static string NoMatchingGroupExceptionText => GetResourceString("NoMatchingGroupExceptionText");

	internal static string PrincipalExistsExceptionText => GetResourceString("PrincipalExistsExceptionText");

	internal static string PrincipalCollectionNotOneDimensional => GetResourceString("PrincipalCollectionNotOneDimensional");

	internal static string PrincipalCollectionIndexNotInArray => GetResourceString("PrincipalCollectionIndexNotInArray");

	internal static string PrincipalCollectionArrayTooSmall => GetResourceString("PrincipalCollectionArrayTooSmall");

	internal static string PrincipalCollectionEnumHasChanged => GetResourceString("PrincipalCollectionEnumHasChanged");

	internal static string PrincipalCollectionEnumInvalidPos => GetResourceString("PrincipalCollectionEnumInvalidPos");

	internal static string AuthenticablePrincipalMustBeSubtypeOfAuthPrinc => GetResourceString("AuthenticablePrincipalMustBeSubtypeOfAuthPrinc");

	internal static string PasswordInfoChangePwdOnUnpersistedPrinc => GetResourceString("PasswordInfoChangePwdOnUnpersistedPrinc");

	internal static string UserMustSetContextForMethod => GetResourceString("UserMustSetContextForMethod");

	internal static string UserCouldNotFindCurrent => GetResourceString("UserCouldNotFindCurrent");

	internal static string UnableToRetrieveDomainInfo => GetResourceString("UnableToRetrieveDomainInfo");

	internal static string UnableToOpenToken => GetResourceString("UnableToOpenToken");

	internal static string UnableToRetrieveTokenInfo => GetResourceString("UnableToRetrieveTokenInfo");

	internal static string UnableToRetrievePolicy => GetResourceString("UnableToRetrievePolicy");

	internal static string UnableToImpersonateCredentials => GetResourceString("UnableToImpersonateCredentials");

	internal static string StoreCtxUnsupportedPrincipalTypeForSave => GetResourceString("StoreCtxUnsupportedPrincipalTypeForSave");

	internal static string StoreCtxUnsupportedPrincipalTypeForGroupInsert => GetResourceString("StoreCtxUnsupportedPrincipalTypeForGroupInsert");

	internal static string StoreCtxUnsupportedPrincipalTypeForQuery => GetResourceString("StoreCtxUnsupportedPrincipalTypeForQuery");

	internal static string StoreCtxUnsupportedPropertyForQuery => GetResourceString("StoreCtxUnsupportedPropertyForQuery");

	internal static string StoreCtxUnsupportedIdentityClaimForQuery => GetResourceString("StoreCtxUnsupportedIdentityClaimForQuery");

	internal static string StoreCtxIdentityClaimMustHaveScheme => GetResourceString("StoreCtxIdentityClaimMustHaveScheme");

	internal static string StoreCtxSecurityIdentityClaimBadFormat => GetResourceString("StoreCtxSecurityIdentityClaimBadFormat");

	internal static string StoreCtxGuidIdentityClaimBadFormat => GetResourceString("StoreCtxGuidIdentityClaimBadFormat");

	internal static string StoreCtxNT4IdentityClaimWrongForm => GetResourceString("StoreCtxNT4IdentityClaimWrongForm");

	internal static string StoreCtxGroupHasUnpersistedInsertedPrincipal => GetResourceString("StoreCtxGroupHasUnpersistedInsertedPrincipal");

	internal static string StoreCtxNeedValueSecurityIdentityClaimToQuery => GetResourceString("StoreCtxNeedValueSecurityIdentityClaimToQuery");

	internal static string ADStoreCtxUnsupportedPrincipalContextForGroupInsert => GetResourceString("ADStoreCtxUnsupportedPrincipalContextForGroupInsert");

	internal static string ADStoreCtxCouldntGetSIDForGroupMember => GetResourceString("ADStoreCtxCouldntGetSIDForGroupMember");

	internal static string ADStoreCtxMustBeContainer => GetResourceString("ADStoreCtxMustBeContainer");

	internal static string ADStoreCtxCantRetrieveObjectSidForCrossStore => GetResourceString("ADStoreCtxCantRetrieveObjectSidForCrossStore");

	internal static string ADStoreCtxCantResolveSidForCrossStore => GetResourceString("ADStoreCtxCantResolveSidForCrossStore");

	internal static string ADStoreCtxFailedFindCrossStoreTarget => GetResourceString("ADStoreCtxFailedFindCrossStoreTarget");

	internal static string ADStoreCtxUnableToReadExistingAccountControlFlagsToEnable => GetResourceString("ADStoreCtxUnableToReadExistingAccountControlFlagsToEnable");

	internal static string ADStoreCtxUnableToReadExistingAccountControlFlagsForUpdate => GetResourceString("ADStoreCtxUnableToReadExistingAccountControlFlagsForUpdate");

	internal static string ADStoreCtxUnableToReadExistingGroupTypeFlagsForUpdate => GetResourceString("ADStoreCtxUnableToReadExistingGroupTypeFlagsForUpdate");

	internal static string ADStoreCtxCantClearGroup => GetResourceString("ADStoreCtxCantClearGroup");

	internal static string ADStoreCtxCantRemoveMemberFromGroup => GetResourceString("ADStoreCtxCantRemoveMemberFromGroup");

	internal static string ADStoreCtxNoComputerPasswordChange => GetResourceString("ADStoreCtxNoComputerPasswordChange");

	internal static string SAMStoreCtxUnableToRetrieveVersion => GetResourceString("SAMStoreCtxUnableToRetrieveVersion");

	internal static string SAMStoreCtxUnableToRetrieveMachineName => GetResourceString("SAMStoreCtxUnableToRetrieveMachineName");

	internal static string SAMStoreCtxUnableToRetrieveFlatMachineName => GetResourceString("SAMStoreCtxUnableToRetrieveFlatMachineName");

	internal static string SAMStoreCtxNoComputerPasswordSet => GetResourceString("SAMStoreCtxNoComputerPasswordSet");

	internal static string SAMStoreCtxNoComputerPasswordExpire => GetResourceString("SAMStoreCtxNoComputerPasswordExpire");

	internal static string SAMStoreCtxCouldntGetSIDForGroupMember => GetResourceString("SAMStoreCtxCouldntGetSIDForGroupMember");

	internal static string SAMStoreCtxFailedToClearGroup => GetResourceString("SAMStoreCtxFailedToClearGroup");

	internal static string SAMStoreCtxCantRetrieveObjectSidForCrossStore => GetResourceString("SAMStoreCtxCantRetrieveObjectSidForCrossStore");

	internal static string SAMStoreCtxCantResolveSidForCrossStore => GetResourceString("SAMStoreCtxCantResolveSidForCrossStore");

	internal static string SAMStoreCtxFailedFindCrossStoreTarget => GetResourceString("SAMStoreCtxFailedFindCrossStoreTarget");

	internal static string SAMStoreCtxErrorEnumeratingGroup => GetResourceString("SAMStoreCtxErrorEnumeratingGroup");

	internal static string SAMStoreCtxLocalGroupsOnly => GetResourceString("SAMStoreCtxLocalGroupsOnly");

	internal static string AuthZFailedToRetrieveGroupList => GetResourceString("AuthZFailedToRetrieveGroupList");

	internal static string AuthZNotSupported => GetResourceString("AuthZNotSupported");

	internal static string AuthZErrorEnumeratingGroups => GetResourceString("AuthZErrorEnumeratingGroups");

	internal static string AuthZCantFindGroup => GetResourceString("AuthZCantFindGroup");

	internal static string ContextOptionsNotValidForMachineStore => GetResourceString("ContextOptionsNotValidForMachineStore");

	internal static string PassedContextTypeDoesNotMatchDetectedType => GetResourceString("PassedContextTypeDoesNotMatchDetectedType");

	internal static string NullArguments => GetResourceString("NullArguments");

	internal static string InvalidStringValueForStore => GetResourceString("InvalidStringValueForStore");

	internal static string ServerDown => GetResourceString("ServerDown");

	internal static string InvalidPropertyForStore => GetResourceString("InvalidPropertyForStore");

	internal static string NameMustBeSetToPersistPrincipal => GetResourceString("NameMustBeSetToPersistPrincipal");

	internal static string ExtensionInvalidClassDefinitionConstructor => GetResourceString("ExtensionInvalidClassDefinitionConstructor");

	internal static string ExtensionInvalidClassAttributes => GetResourceString("ExtensionInvalidClassAttributes");

	internal static string SaveToMustHaveSamecontextType => GetResourceString("SaveToMustHaveSamecontextType");

	internal static string ComputerInvalidForAppDirectoryStore => GetResourceString("ComputerInvalidForAppDirectoryStore");

	internal static string SaveToNotSupportedAgainstMachineStore => GetResourceString("SaveToNotSupportedAgainstMachineStore");

	internal static string InvalidContextOptionsForMachine => GetResourceString("InvalidContextOptionsForMachine");

	internal static string InvalidContextOptionsForAD => GetResourceString("InvalidContextOptionsForAD");

	internal static string InvalidExtensionCollectionType => GetResourceString("InvalidExtensionCollectionType");

	internal static string ADAMStoreUnableToPopulateSchemaList => GetResourceString("ADAMStoreUnableToPopulateSchemaList");

	internal static string StoreCtxMultipleFiltersForPropertyUnsupported => GetResourceString("StoreCtxMultipleFiltersForPropertyUnsupported");

	internal static string AdsiNotInstalled => GetResourceString("AdsiNotInstalled");

	internal static string DirectoryServicesAccountManagement_PlatformNotSupported => GetResourceString("DirectoryServicesAccountManagement_PlatformNotSupported");

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

	internal static string Format(string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(resourceFormat, p1, p2);
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(resourceFormat, p1, p2, p3);
	}

	internal static string Format(string resourceFormat, params object[] args)
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

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(provider, resourceFormat, p1);
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(provider, resourceFormat, p1, p2);
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(provider, resourceFormat, p1, p2, p3);
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, params object[] args)
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

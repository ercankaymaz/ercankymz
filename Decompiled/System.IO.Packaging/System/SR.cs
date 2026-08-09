using System.Resources;
using FxResources.System.IO.Packaging;

namespace System;

internal static class SR
{
	private static readonly bool s_usingResourceKeys = GetUsingResourceKeysSwitchValue();

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string BadPackageFormat => GetResourceString("BadPackageFormat");

	internal static string CannotModifyReadOnlyContainer => GetResourceString("CannotModifyReadOnlyContainer");

	internal static string CannotRetrievePartsOfWriteOnlyContainer => GetResourceString("CannotRetrievePartsOfWriteOnlyContainer");

	internal static string ContainerAndPartModeIncompatible => GetResourceString("ContainerAndPartModeIncompatible");

	internal static string ContentTypeCannotHaveLeadingTrailingLWS => GetResourceString("ContentTypeCannotHaveLeadingTrailingLWS");

	internal static string CorePropertiesElementExpected => GetResourceString("CorePropertiesElementExpected");

	internal static string CreateNewNotSupported => GetResourceString("CreateNewNotSupported");

	internal static string DanglingMetadataRelationship => GetResourceString("DanglingMetadataRelationship");

	internal static string DefaultTagDoesNotMatchSchema => GetResourceString("DefaultTagDoesNotMatchSchema");

	internal static string DuplicateCorePropertyName => GetResourceString("DuplicateCorePropertyName");

	internal static string ElementIsNotEmptyElement => GetResourceString("ElementIsNotEmptyElement");

	internal static string EncodingNotSupported => GetResourceString("EncodingNotSupported");

	internal static string ExpectedRelationshipsElementTag => GetResourceString("ExpectedRelationshipsElementTag");

	internal static string ExpectingParameterValuePairs => GetResourceString("ExpectingParameterValuePairs");

	internal static string ExpectingSemicolon => GetResourceString("ExpectingSemicolon");

	internal static string FileFormatException => GetResourceString("FileFormatException");

	internal static string FileFormatExceptionWithFileName => GetResourceString("FileFormatExceptionWithFileName");

	internal static string GetContentTypeCoreNotImplemented => GetResourceString("GetContentTypeCoreNotImplemented");

	internal static string InvalidLinearWhiteSpaceCharacter => GetResourceString("InvalidLinearWhiteSpaceCharacter");

	internal static string InvalidParameterValue => GetResourceString("InvalidParameterValue");

	internal static string InvalidParameterValuePair => GetResourceString("InvalidParameterValuePair");

	internal static string InvalidPartUri => GetResourceString("InvalidPartUri");

	internal static string InvalidPropertyNameInCorePropertiesPart => GetResourceString("InvalidPropertyNameInCorePropertiesPart");

	internal static string InvalidRelationshipType => GetResourceString("InvalidRelationshipType");

	internal static string InvalidToken_ContentType => GetResourceString("InvalidToken_ContentType");

	internal static string InvalidTypeSubType => GetResourceString("InvalidTypeSubType");

	internal static string InvalidValueForTheAttribute => GetResourceString("InvalidValueForTheAttribute");

	internal static string InvalidXmlBaseAttributePresent => GetResourceString("InvalidXmlBaseAttributePresent");

	internal static string MoreThanOneMetadataRelationships => GetResourceString("MoreThanOneMetadataRelationships");

	internal static string NoExternalTargetForMetadataRelationship => GetResourceString("NoExternalTargetForMetadataRelationship");

	internal static string NoStructuredContentInsideProperties => GetResourceString("NoStructuredContentInsideProperties");

	internal static string NotAUniqueRelationshipId => GetResourceString("NotAUniqueRelationshipId");

	internal static string NotAValidRelationshipPartUri => GetResourceString("NotAValidRelationshipPartUri");

	internal static string NotAValidXmlIdString => GetResourceString("NotAValidXmlIdString");

	internal static string NullContentTypeProvided => GetResourceString("NullContentTypeProvided");

	internal static string NullStreamReturned => GetResourceString("NullStreamReturned");

	internal static string ObjectDisposed => GetResourceString("ObjectDisposed");

	internal static string OverrideTagDoesNotMatchSchema => GetResourceString("OverrideTagDoesNotMatchSchema");

	internal static string PackagePartDeleted => GetResourceString("PackagePartDeleted");

	internal static string PackagePartRelationshipDoesNotExist => GetResourceString("PackagePartRelationshipDoesNotExist");

	internal static string PackageRelationshipDoesNotExist => GetResourceString("PackageRelationshipDoesNotExist");

	internal static string ParentContainerClosed => GetResourceString("ParentContainerClosed");

	internal static string PartAlreadyExists => GetResourceString("PartAlreadyExists");

	internal static string PartDoesNotExist => GetResourceString("PartDoesNotExist");

	internal static string PartNamePrefixExists => GetResourceString("PartNamePrefixExists");

	internal static string PartUriCannotHaveAFragment => GetResourceString("PartUriCannotHaveAFragment");

	internal static string PartUriIsEmpty => GetResourceString("PartUriIsEmpty");

	internal static string PartUriShouldNotEndWithForwardSlash => GetResourceString("PartUriShouldNotEndWithForwardSlash");

	internal static string PartUriShouldNotStartWithTwoForwardSlashes => GetResourceString("PartUriShouldNotStartWithTwoForwardSlashes");

	internal static string PartUriShouldStartWithForwardSlash => GetResourceString("PartUriShouldStartWithForwardSlash");

	internal static string PropertyStartTagExpected => GetResourceString("PropertyStartTagExpected");

	internal static string PropertyWrongNumbOfAttribsDefinedOn => GetResourceString("PropertyWrongNumbOfAttribsDefinedOn");

	internal static string RelationshipPartIncorrectContentType => GetResourceString("RelationshipPartIncorrectContentType");

	internal static string RelationshipPartsCannotHaveRelationships => GetResourceString("RelationshipPartsCannotHaveRelationships");

	internal static string RelationshipPartUriExpected => GetResourceString("RelationshipPartUriExpected");

	internal static string RelationshipPartUriNotExpected => GetResourceString("RelationshipPartUriNotExpected");

	internal static string RelationshipsTagHasExtraAttributes => GetResourceString("RelationshipsTagHasExtraAttributes");

	internal static string RelationshipTagDoesntMatchSchema => GetResourceString("RelationshipTagDoesntMatchSchema");

	internal static string RelationshipTargetMustBeRelative => GetResourceString("RelationshipTargetMustBeRelative");

	internal static string RelationshipToRelationshipIllegal => GetResourceString("RelationshipToRelationshipIllegal");

	internal static string RequiredAttributeEmpty => GetResourceString("RequiredAttributeEmpty");

	internal static string RequiredAttributeMissing => GetResourceString("RequiredAttributeMissing");

	internal static string RequiredRelationshipAttributeMissing => GetResourceString("RequiredRelationshipAttributeMissing");

	internal static string StreamObjectDisposed => GetResourceString("StreamObjectDisposed");

	internal static string TruncateNotSupported => GetResourceString("TruncateNotSupported");

	internal static string TypesElementExpected => GetResourceString("TypesElementExpected");

	internal static string TypesTagHasExtraAttributes => GetResourceString("TypesTagHasExtraAttributes");

	internal static string TypesXmlDoesNotMatchSchema => GetResourceString("TypesXmlDoesNotMatchSchema");

	internal static string UnknownDCDateTimeXsiType => GetResourceString("UnknownDCDateTimeXsiType");

	internal static string UnknownNamespaceInCorePropertiesPart => GetResourceString("UnknownNamespaceInCorePropertiesPart");

	internal static string UnknownTagEncountered => GetResourceString("UnknownTagEncountered");

	internal static string UnsupportedCombinationOfModeAccess => GetResourceString("UnsupportedCombinationOfModeAccess");

	internal static string URIShouldNotBeAbsolute => GetResourceString("URIShouldNotBeAbsolute");

	internal static string WrongContentTypeForPropertyPart => GetResourceString("WrongContentTypeForPropertyPart");

	internal static string XCRChoiceAfterFallback => GetResourceString("XCRChoiceAfterFallback");

	internal static string XCRChoiceNotFound => GetResourceString("XCRChoiceNotFound");

	internal static string XCRChoiceOnlyInAC => GetResourceString("XCRChoiceOnlyInAC");

	internal static string XCRCompatCycle => GetResourceString("XCRCompatCycle");

	internal static string XCRDuplicatePreserve => GetResourceString("XCRDuplicatePreserve");

	internal static string XCRDuplicateProcessContent => GetResourceString("XCRDuplicateProcessContent");

	internal static string XCRDuplicateWildcardPreserve => GetResourceString("XCRDuplicateWildcardPreserve");

	internal static string XCRDuplicateWildcardProcessContent => GetResourceString("XCRDuplicateWildcardProcessContent");

	internal static string XCRFallbackOnlyInAC => GetResourceString("XCRFallbackOnlyInAC");

	internal static string XCRInvalidACChild => GetResourceString("XCRInvalidACChild");

	internal static string XCRInvalidAttribInElement => GetResourceString("XCRInvalidAttribInElement");

	internal static string XCRInvalidFormat => GetResourceString("XCRInvalidFormat");

	internal static string XCRInvalidPreserve => GetResourceString("XCRInvalidPreserve");

	internal static string XCRInvalidProcessContent => GetResourceString("XCRInvalidProcessContent");

	internal static string XCRInvalidRequiresAttribute => GetResourceString("XCRInvalidRequiresAttribute");

	internal static string XCRInvalidXMLName => GetResourceString("XCRInvalidXMLName");

	internal static string XCRMultipleFallbackFound => GetResourceString("XCRMultipleFallbackFound");

	internal static string XCRMustUnderstandFailed => GetResourceString("XCRMustUnderstandFailed");

	internal static string XCRNSPreserveNotIgnorable => GetResourceString("XCRNSPreserveNotIgnorable");

	internal static string XCRNSProcessContentNotIgnorable => GetResourceString("XCRNSProcessContentNotIgnorable");

	internal static string XCRRequiresAttribNotFound => GetResourceString("XCRRequiresAttribNotFound");

	internal static string XCRUndefinedPrefix => GetResourceString("XCRUndefinedPrefix");

	internal static string XCRUnknownCompatAttrib => GetResourceString("XCRUnknownCompatAttrib");

	internal static string XCRUnknownCompatElement => GetResourceString("XCRUnknownCompatElement");

	internal static string XsdDateTimeExpected => GetResourceString("XsdDateTimeExpected");

	internal static string CreateNewOnNonEmptyStream => GetResourceString("CreateNewOnNonEmptyStream");

	internal static string ZipZeroSizeFileIsNotValidArchive => GetResourceString("ZipZeroSizeFileIsNotValidArchive");

	internal static string InnerPackageUriHasFragment => GetResourceString("InnerPackageUriHasFragment");

	internal static string FragmentMustStartWithHash => GetResourceString("FragmentMustStartWithHash");

	internal static string UriShouldBePackScheme => GetResourceString("UriShouldBePackScheme");

	internal static string UriShouldBeAbsolute => GetResourceString("UriShouldBeAbsolute");

	internal static string FileContainsCorruptedData => GetResourceString("FileContainsCorruptedData");

	internal static string DuplicatePiecesFound => GetResourceString("DuplicatePiecesFound");

	internal static string OffsetNegative => GetResourceString("OffsetNegative");

	internal static string PieceDoesNotExist => GetResourceString("PieceDoesNotExist");

	internal static string ReadBufferTooSmall => GetResourceString("ReadBufferTooSmall");

	internal static string ReadCountNegative => GetResourceString("ReadCountNegative");

	internal static string ReadNotSupported => GetResourceString("ReadNotSupported");

	internal static string SeekNegative => GetResourceString("SeekNegative");

	internal static string SeekNotSupported => GetResourceString("SeekNotSupported");

	internal static string StreamDoesNotSupportWrite => GetResourceString("StreamDoesNotSupportWrite");

	internal static string WriteBufferTooSmall => GetResourceString("WriteBufferTooSmall");

	internal static string WriteCountNegative => GetResourceString("WriteCountNegative");

	internal static string WriteNotSupported => GetResourceString("WriteNotSupported");

	internal static string UnexpectedPartPieceUri => GetResourceString("UnexpectedPartPieceUri");

	private static bool GetUsingResourceKeysSwitchValue()
	{
		if (!AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out var isEnabled))
		{
			return false;
		}
		return isEnabled;
	}

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

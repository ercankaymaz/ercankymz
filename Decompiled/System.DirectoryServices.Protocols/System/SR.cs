using System.Resources;
using FxResources.System.DirectoryServices.Protocols;

namespace System;

internal static class SR
{
	private static readonly bool s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out var isEnabled) && isEnabled;

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string NoNegativeTimeLimit => GetResourceString("NoNegativeTimeLimit");

	internal static string NoNegativeSizeLimit => GetResourceString("NoNegativeSizeLimit");

	internal static string InvalidDocument => GetResourceString("InvalidDocument");

	internal static string MissingResponse => GetResourceString("MissingResponse");

	internal static string ErrorResponse => GetResourceString("ErrorResponse");

	internal static string NullDirectoryAttribute => GetResourceString("NullDirectoryAttribute");

	internal static string NullDirectoryAttributeCollection => GetResourceString("NullDirectoryAttributeCollection");

	internal static string WhiteSpaceServerName => GetResourceString("WhiteSpaceServerName");

	internal static string DirectoryAttributeConversion => GetResourceString("DirectoryAttributeConversion");

	internal static string WrongNumValuesCompare => GetResourceString("WrongNumValuesCompare");

	internal static string WrongAssertionCompare => GetResourceString("WrongAssertionCompare");

	internal static string DefaultOperationsError => GetResourceString("DefaultOperationsError");

	internal static string ReadOnlyProperty => GetResourceString("ReadOnlyProperty");

	internal static string InvalidClientCertificates => GetResourceString("InvalidClientCertificates");

	internal static string InvalidAuthCredential => GetResourceString("InvalidAuthCredential");

	internal static string InvalidLdapSearchRequestFilter => GetResourceString("InvalidLdapSearchRequestFilter");

	internal static string PartialResultsNotSupported => GetResourceString("PartialResultsNotSupported");

	internal static string BerConverterNotMatch => GetResourceString("BerConverterNotMatch");

	internal static string BerConverterUndefineChar => GetResourceString("BerConverterUndefineChar");

	internal static string BerConversionError => GetResourceString("BerConversionError");

	internal static string TLSStopFailure => GetResourceString("TLSStopFailure");

	internal static string NoPartialResults => GetResourceString("NoPartialResults");

	internal static string DefaultLdapError => GetResourceString("DefaultLdapError");

	internal static string LDAP_PARTIAL_RESULTS => GetResourceString("LDAP_PARTIAL_RESULTS");

	internal static string LDAP_IS_LEAF => GetResourceString("LDAP_IS_LEAF");

	internal static string LDAP_SORT_CONTROL_MISSING => GetResourceString("LDAP_SORT_CONTROL_MISSING");

	internal static string LDAP_OFFSET_RANGE_ERROR => GetResourceString("LDAP_OFFSET_RANGE_ERROR");

	internal static string LDAP_RESULTS_TOO_LARGE => GetResourceString("LDAP_RESULTS_TOO_LARGE");

	internal static string LDAP_SERVER_DOWN => GetResourceString("LDAP_SERVER_DOWN");

	internal static string LDAP_LOCAL_ERROR => GetResourceString("LDAP_LOCAL_ERROR");

	internal static string LDAP_ENCODING_ERROR => GetResourceString("LDAP_ENCODING_ERROR");

	internal static string LDAP_DECODING_ERROR => GetResourceString("LDAP_DECODING_ERROR");

	internal static string LDAP_TIMEOUT => GetResourceString("LDAP_TIMEOUT");

	internal static string LDAP_AUTH_UNKNOWN => GetResourceString("LDAP_AUTH_UNKNOWN");

	internal static string LDAP_FILTER_ERROR => GetResourceString("LDAP_FILTER_ERROR");

	internal static string LDAP_USER_CANCELLED => GetResourceString("LDAP_USER_CANCELLED");

	internal static string LDAP_PARAM_ERROR => GetResourceString("LDAP_PARAM_ERROR");

	internal static string LDAP_NO_MEMORY => GetResourceString("LDAP_NO_MEMORY");

	internal static string LDAP_CONNECT_ERROR => GetResourceString("LDAP_CONNECT_ERROR");

	internal static string LDAP_NOT_SUPPORTED => GetResourceString("LDAP_NOT_SUPPORTED");

	internal static string LDAP_NO_RESULTS_RETURNED => GetResourceString("LDAP_NO_RESULTS_RETURNED");

	internal static string LDAP_CONTROL_NOT_FOUND => GetResourceString("LDAP_CONTROL_NOT_FOUND");

	internal static string LDAP_MORE_RESULTS_TO_RETURN => GetResourceString("LDAP_MORE_RESULTS_TO_RETURN");

	internal static string LDAP_CLIENT_LOOP => GetResourceString("LDAP_CLIENT_LOOP");

	internal static string LDAP_REFERRAL_LIMIT_EXCEEDED => GetResourceString("LDAP_REFERRAL_LIMIT_EXCEEDED");

	internal static string LDAP_INVALID_CREDENTIALS => GetResourceString("LDAP_INVALID_CREDENTIALS");

	internal static string LDAP_SUCCESS => GetResourceString("LDAP_SUCCESS");

	internal static string LDAP_OPERATIONS_ERROR => GetResourceString("LDAP_OPERATIONS_ERROR");

	internal static string LDAP_PROTOCOL_ERROR => GetResourceString("LDAP_PROTOCOL_ERROR");

	internal static string LDAP_TIMELIMIT_EXCEEDED => GetResourceString("LDAP_TIMELIMIT_EXCEEDED");

	internal static string LDAP_SIZELIMIT_EXCEEDED => GetResourceString("LDAP_SIZELIMIT_EXCEEDED");

	internal static string LDAP_COMPARE_FALSE => GetResourceString("LDAP_COMPARE_FALSE");

	internal static string LDAP_COMPARE_TRUE => GetResourceString("LDAP_COMPARE_TRUE");

	internal static string LDAP_AUTH_METHOD_NOT_SUPPORTED => GetResourceString("LDAP_AUTH_METHOD_NOT_SUPPORTED");

	internal static string LDAP_STRONG_AUTH_REQUIRED => GetResourceString("LDAP_STRONG_AUTH_REQUIRED");

	internal static string LDAP_REFERRAL => GetResourceString("LDAP_REFERRAL");

	internal static string LDAP_ADMIN_LIMIT_EXCEEDED => GetResourceString("LDAP_ADMIN_LIMIT_EXCEEDED");

	internal static string LDAP_UNAVAILABLE_CRIT_EXTENSION => GetResourceString("LDAP_UNAVAILABLE_CRIT_EXTENSION");

	internal static string LDAP_CONFIDENTIALITY_REQUIRED => GetResourceString("LDAP_CONFIDENTIALITY_REQUIRED");

	internal static string LDAP_SASL_BIND_IN_PROGRESS => GetResourceString("LDAP_SASL_BIND_IN_PROGRESS");

	internal static string LDAP_NO_SUCH_ATTRIBUTE => GetResourceString("LDAP_NO_SUCH_ATTRIBUTE");

	internal static string LDAP_UNDEFINED_TYPE => GetResourceString("LDAP_UNDEFINED_TYPE");

	internal static string LDAP_INAPPROPRIATE_MATCHING => GetResourceString("LDAP_INAPPROPRIATE_MATCHING");

	internal static string LDAP_CONSTRAINT_VIOLATION => GetResourceString("LDAP_CONSTRAINT_VIOLATION");

	internal static string LDAP_ATTRIBUTE_OR_VALUE_EXISTS => GetResourceString("LDAP_ATTRIBUTE_OR_VALUE_EXISTS");

	internal static string LDAP_INVALID_SYNTAX => GetResourceString("LDAP_INVALID_SYNTAX");

	internal static string LDAP_NO_SUCH_OBJECT => GetResourceString("LDAP_NO_SUCH_OBJECT");

	internal static string LDAP_ALIAS_PROBLEM => GetResourceString("LDAP_ALIAS_PROBLEM");

	internal static string LDAP_INVALID_DN_SYNTAX => GetResourceString("LDAP_INVALID_DN_SYNTAX");

	internal static string LDAP_ALIAS_DEREF_PROBLEM => GetResourceString("LDAP_ALIAS_DEREF_PROBLEM");

	internal static string LDAP_INAPPROPRIATE_AUTH => GetResourceString("LDAP_INAPPROPRIATE_AUTH");

	internal static string LDAP_INSUFFICIENT_RIGHTS => GetResourceString("LDAP_INSUFFICIENT_RIGHTS");

	internal static string LDAP_BUSY => GetResourceString("LDAP_BUSY");

	internal static string LDAP_UNAVAILABLE => GetResourceString("LDAP_UNAVAILABLE");

	internal static string LDAP_UNWILLING_TO_PERFORM => GetResourceString("LDAP_UNWILLING_TO_PERFORM");

	internal static string LDAP_LOOP_DETECT => GetResourceString("LDAP_LOOP_DETECT");

	internal static string LDAP_NAMING_VIOLATION => GetResourceString("LDAP_NAMING_VIOLATION");

	internal static string LDAP_OBJECT_CLASS_VIOLATION => GetResourceString("LDAP_OBJECT_CLASS_VIOLATION");

	internal static string LDAP_NOT_ALLOWED_ON_NONLEAF => GetResourceString("LDAP_NOT_ALLOWED_ON_NONLEAF");

	internal static string LDAP_NOT_ALLOWED_ON_RDN => GetResourceString("LDAP_NOT_ALLOWED_ON_RDN");

	internal static string LDAP_ALREADY_EXISTS => GetResourceString("LDAP_ALREADY_EXISTS");

	internal static string LDAP_NO_OBJECT_CLASS_MODS => GetResourceString("LDAP_NO_OBJECT_CLASS_MODS");

	internal static string LDAP_AFFECTS_MULTIPLE_DSAS => GetResourceString("LDAP_AFFECTS_MULTIPLE_DSAS");

	internal static string LDAP_VIRTUAL_LIST_VIEW_ERROR => GetResourceString("LDAP_VIRTUAL_LIST_VIEW_ERROR");

	internal static string LDAP_OTHER => GetResourceString("LDAP_OTHER");

	internal static string LDAP_SEND_TIMEOUT => GetResourceString("LDAP_SEND_TIMEOUT");

	internal static string InvalidAsyncResult => GetResourceString("InvalidAsyncResult");

	internal static string ValidDirectoryAttributeType => GetResourceString("ValidDirectoryAttributeType");

	internal static string ValidFilterType => GetResourceString("ValidFilterType");

	internal static string ValidValuesType => GetResourceString("ValidValuesType");

	internal static string ValidValueType => GetResourceString("ValidValueType");

	internal static string InvalidValueType => GetResourceString("InvalidValueType");

	internal static string ValidValue => GetResourceString("ValidValue");

	internal static string ContainNullControl => GetResourceString("ContainNullControl");

	internal static string NotReturnedAsyncResult => GetResourceString("NotReturnedAsyncResult");

	internal static string DsmlAuthRequestNotSupported => GetResourceString("DsmlAuthRequestNotSupported");

	internal static string CallBackIsNull => GetResourceString("CallBackIsNull");

	internal static string NullValueArray => GetResourceString("NullValueArray");

	internal static string TimespanExceedMax => GetResourceString("TimespanExceedMax");

	internal static string InvliadRequestType => GetResourceString("InvliadRequestType");

	internal static string DirectoryServicesProtocols_PlatformNotSupported => GetResourceString("DirectoryServicesProtocols_PlatformNotSupported");

	internal static string QuotaControlNotSupported => GetResourceString("QuotaControlNotSupported");

	internal static string ReferralChasingOptionsNotSupported => GetResourceString("ReferralChasingOptionsNotSupported");

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

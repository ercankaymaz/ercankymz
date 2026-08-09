using System.Resources;
using FxResources.System.ComponentModel.Composition.Registration;

namespace System;

internal static class SR
{
	private static readonly bool s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out var isEnabled) && isEnabled;

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string Registration_ConstructorConventionOverridden => GetResourceString("Registration_ConstructorConventionOverridden");

	internal static string Registration_TypeExportConventionOverridden => GetResourceString("Registration_TypeExportConventionOverridden");

	internal static string Registration_MemberExportConventionOverridden => GetResourceString("Registration_MemberExportConventionOverridden");

	internal static string Registration_MemberImportConventionOverridden => GetResourceString("Registration_MemberImportConventionOverridden");

	internal static string Registration_MemberImportConventionMatchedTwice => GetResourceString("Registration_MemberImportConventionMatchedTwice");

	internal static string Registration_ParameterImportConventionOverridden => GetResourceString("Registration_ParameterImportConventionOverridden");

	internal static string Registration_PartCreationConventionOverridden => GetResourceString("Registration_PartCreationConventionOverridden");

	internal static string Registration_PartMetadataConventionOverridden => GetResourceString("Registration_PartMetadataConventionOverridden");

	internal static string Diagnostic_InternalExceptionMessage => GetResourceString("Diagnostic_InternalExceptionMessage");

	internal static string Argument_ExpressionMustBeNew => GetResourceString("Argument_ExpressionMustBeNew");

	internal static string Argument_ExpressionMustBePropertyMember => GetResourceString("Argument_ExpressionMustBePropertyMember");

	internal static string Diagnostic_TraceUnnecessaryWork => GetResourceString("Diagnostic_TraceUnnecessaryWork");

	internal static string PlatformNotSupported_ComponentModel_Composition_Registration => GetResourceString("PlatformNotSupported_ComponentModel_Composition_Registration");

	internal static string Registration_OnSatisfiedImportNotificationOverridden => GetResourceString("Registration_OnSatisfiedImportNotificationOverridden");

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

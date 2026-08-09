using System.Resources;
using FxResources.System.Runtime.Caching;

namespace System;

internal static class SR
{
	private static readonly bool s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out var isEnabled) && isEnabled;

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string TimeSpan_invalid_format => GetResourceString("TimeSpan_invalid_format");

	internal static string Value_must_be_non_negative_integer => GetResourceString("Value_must_be_non_negative_integer");

	internal static string Value_must_be_positive_integer => GetResourceString("Value_must_be_positive_integer");

	internal static string Value_too_big => GetResourceString("Value_too_big");

	internal static string Empty_collection => GetResourceString("Empty_collection");

	internal static string Collection_contains_null_element => GetResourceString("Collection_contains_null_element");

	internal static string Collection_contains_null_or_empty_string => GetResourceString("Collection_contains_null_or_empty_string");

	internal static string Method_already_invoked => GetResourceString("Method_already_invoked");

	internal static string Property_already_set => GetResourceString("Property_already_set");

	internal static string Invalid_state => GetResourceString("Invalid_state");

	internal static string Init_not_complete => GetResourceString("Init_not_complete");

	internal static string Default_is_reserved => GetResourceString("Default_is_reserved");

	internal static string Invalid_expiration_combination => GetResourceString("Invalid_expiration_combination");

	internal static string Invalid_callback_combination => GetResourceString("Invalid_callback_combination");

	internal static string Invalid_argument_combination => GetResourceString("Invalid_argument_combination");

	internal static string Update_callback_must_be_null => GetResourceString("Update_callback_must_be_null");

	internal static string Argument_out_of_range => GetResourceString("Argument_out_of_range");

	internal static string Empty_string_invalid => GetResourceString("Empty_string_invalid");

	internal static string RegionName_not_supported => GetResourceString("RegionName_not_supported");

	internal static string Value_must_be_boolean => GetResourceString("Value_must_be_boolean");

	internal static string PlatformNotSupported_Caching => GetResourceString("PlatformNotSupported_Caching");

	internal static string PlatformNotSupported_PhysicalMemoryLimitPercentage => GetResourceString("PlatformNotSupported_PhysicalMemoryLimitPercentage");

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

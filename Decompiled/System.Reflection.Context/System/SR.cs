using System.Resources;
using FxResources.System.Reflection.Context;

namespace System;

internal static class SR
{
	private static readonly bool s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out var isEnabled) && isEnabled;

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string ArgumentNull_GetterOrSetterMustBeSpecified => GetResourceString("ArgumentNull_GetterOrSetterMustBeSpecified");

	internal static string Argument_GetMethNotFnd => GetResourceString("Argument_GetMethNotFnd");

	internal static string Argument_PropertyTypeFromDifferentContext => GetResourceString("Argument_PropertyTypeFromDifferentContext");

	internal static string Format_AttributeUsage => GetResourceString("Format_AttributeUsage");

	internal static string InvalidOperation_AddNullProperty => GetResourceString("InvalidOperation_AddNullProperty");

	internal static string InvalidOperation_AddPropertyDifferentContext => GetResourceString("InvalidOperation_AddPropertyDifferentContext");

	internal static string InvalidOperation_AddPropertyDifferentType => GetResourceString("InvalidOperation_AddPropertyDifferentType");

	internal static string InvalidOperation_EnumLitValueNotFound => GetResourceString("InvalidOperation_EnumLitValueNotFound");

	internal static string InvalidOperation_InvalidMemberType => GetResourceString("InvalidOperation_InvalidMemberType");

	internal static string InvalidOperation_InvalidMethodType => GetResourceString("InvalidOperation_InvalidMethodType");

	internal static string InvalidOperation_NotGenericMethodDefinition => GetResourceString("InvalidOperation_NotGenericMethodDefinition");

	internal static string InvalidOperation_NoTypeInfoForThisType => GetResourceString("InvalidOperation_NoTypeInfoForThisType");

	internal static string InvalidOperation_NullAttribute => GetResourceString("InvalidOperation_NullAttribute");

	internal static string PlatformNotSupported_ReflectionContext => GetResourceString("PlatformNotSupported_ReflectionContext");

	internal static string Target_InstanceMethodRequiresTarget => GetResourceString("Target_InstanceMethodRequiresTarget");

	internal static string Target_ObjectTargetMismatch => GetResourceString("Target_ObjectTargetMismatch");

	internal static string Argument_ObjectArgumentMismatch => GetResourceString("Argument_ObjectArgumentMismatch");

	internal static string Arg_AmbiguousMatchException_MemberInfo => GetResourceString("Arg_AmbiguousMatchException_MemberInfo");

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

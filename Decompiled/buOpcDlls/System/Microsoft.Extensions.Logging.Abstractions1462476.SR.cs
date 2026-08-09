using System.Resources;
using System.Runtime.CompilerServices;
using FxResources.Microsoft.Extensions.Logging.Abstractions;

namespace System;

[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(0)]
internal static class Microsoft_002EExtensions_002ELogging_002EAbstractions1462476_002ESR
{
	private static readonly bool s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out var isEnabled) && isEnabled;

	private static ResourceManager s_resourceManager;

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(0)]
	internal static ResourceManager ResourceManager
	{
		[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(0)]
		get
		{
			return s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));
		}
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(0)]
	internal static string UnexpectedNumberOfNamedParameters
	{
		[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(0)]
		get
		{
			return GetResourceString("UnexpectedNumberOfNamedParameters");
		}
	}

	private static bool UsingResourceKeys()
	{
		return s_usingResourceKeys;
	}

	internal static string GetResourceString(string resourceKey)
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

	internal static string GetResourceString(string resourceKey, string defaultString)
	{
		string resourceString = GetResourceString(resourceKey);
		if (!(resourceKey == resourceString) && resourceString != null)
		{
			return resourceString;
		}
		return defaultString;
	}

	internal static string Format(string resourceFormat, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] object p1, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(resourceFormat, p1, p2);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	[return: Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)]
	internal static string Format([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(resourceFormat, p1, p2, p3);
	}

	internal static string Format(string resourceFormat, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] params object[] args)
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

	internal static string Format([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] IFormatProvider provider, string resourceFormat, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(provider, resourceFormat, p1);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	[return: Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)]
	internal static string Format(IFormatProvider provider, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(provider, resourceFormat, p1, p2);
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(2)]
	[return: Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)]
	internal static string Format(IFormatProvider provider, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(1)] string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(provider, resourceFormat, p1, p2, p3);
	}

	internal static string Format([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] IFormatProvider provider, string resourceFormat, [Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] params object[] args)
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

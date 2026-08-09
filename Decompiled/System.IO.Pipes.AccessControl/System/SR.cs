using System.Resources;
using System.Runtime.CompilerServices;
using FxResources.System.IO.Pipes.AccessControl;

namespace System;

internal static class SR
{
	private static ResourceManager s_resourceManager;

	private static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(ResourceType));

	internal static Type ResourceType { get; } = typeof(SR);

	internal static string ArgumentOutOfRange_NeedValidPipeAccessRights => GetResourceString("ArgumentOutOfRange_NeedValidPipeAccessRights", null);

	internal static string Argument_NonContainerInvalidAnyFlag => GetResourceString("Argument_NonContainerInvalidAnyFlag", null);

	internal static string InvalidOperation_PipeNotYetConnected => GetResourceString("InvalidOperation_PipeNotYetConnected", null);

	internal static string IO_IO_PipeBroken => GetResourceString("IO_IO_PipeBroken", null);

	internal static string PlatformNotSupported_AccessControl => GetResourceString("PlatformNotSupported_AccessControl", null);

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool UsingResourceKeys()
	{
		return false;
	}

	internal static string GetResourceString(string resourceKey, string defaultString)
	{
		string text = null;
		try
		{
			text = ResourceManager.GetString(resourceKey);
		}
		catch (MissingManifestResourceException)
		{
		}
		if (defaultString != null && resourceKey.Equals(text, StringComparison.Ordinal))
		{
			return defaultString;
		}
		return text;
	}

	internal static string Format(string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + string.Join(", ", args);
			}
			return string.Format(resourceFormat, args);
		}
		return resourceFormat;
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
}

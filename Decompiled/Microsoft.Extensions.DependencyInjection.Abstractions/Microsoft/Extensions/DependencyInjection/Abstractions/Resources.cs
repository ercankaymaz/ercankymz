using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Microsoft.Extensions.DependencyInjection.Abstractions;

internal static class Resources
{
	private static readonly ResourceManager _resourceManager = new ResourceManager("Microsoft.Extensions.DependencyInjection.Abstractions.Resources", typeof(Resources).GetTypeInfo().Assembly);

	internal static string AmbiguousConstructorMatch => GetString("AmbiguousConstructorMatch");

	internal static string CannotLocateImplementation => GetString("CannotLocateImplementation");

	internal static string CannotResolveService => GetString("CannotResolveService");

	internal static string NoConstructorMatch => GetString("NoConstructorMatch");

	internal static string NoServiceRegistered => GetString("NoServiceRegistered");

	internal static string TryAddIndistinguishableTypeToEnumerable => GetString("TryAddIndistinguishableTypeToEnumerable");

	internal static string FormatAmbiguousConstructorMatch(object p0)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("AmbiguousConstructorMatch"), p0);
	}

	internal static string FormatCannotLocateImplementation(object p0, object p1)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("CannotLocateImplementation"), p0, p1);
	}

	internal static string FormatCannotResolveService(object p0, object p1)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("CannotResolveService"), p0, p1);
	}

	internal static string FormatNoConstructorMatch(object p0)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("NoConstructorMatch"), p0);
	}

	internal static string FormatNoServiceRegistered(object p0)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("NoServiceRegistered"), p0);
	}

	internal static string FormatTryAddIndistinguishableTypeToEnumerable(object p0, object p1)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("TryAddIndistinguishableTypeToEnumerable"), p0, p1);
	}

	private static string GetString(string name, params string[] formatterNames)
	{
		string text = _resourceManager.GetString(name);
		if (formatterNames != null)
		{
			for (int i = 0; i < formatterNames.Length; i++)
			{
				text = text.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
			}
		}
		return text;
	}
}

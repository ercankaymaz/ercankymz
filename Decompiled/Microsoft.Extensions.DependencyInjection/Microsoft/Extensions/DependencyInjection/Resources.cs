using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Microsoft.Extensions.DependencyInjection;

internal static class Resources
{
	private static readonly ResourceManager _resourceManager = new ResourceManager("Microsoft.Extensions.DependencyInjection.Resources", typeof(Resources).GetTypeInfo().Assembly);

	internal static string AmbiguousConstructorException => GetString("AmbiguousConstructorException");

	internal static string CannotResolveService => GetString("CannotResolveService");

	internal static string CircularDependencyException => GetString("CircularDependencyException");

	internal static string UnableToActivateTypeException => GetString("UnableToActivateTypeException");

	internal static string OpenGenericServiceRequiresOpenGenericImplementation => GetString("OpenGenericServiceRequiresOpenGenericImplementation");

	internal static string TypeCannotBeActivated => GetString("TypeCannotBeActivated");

	internal static string NoConstructorMatch => GetString("NoConstructorMatch");

	internal static string ScopedInSingletonException => GetString("ScopedInSingletonException");

	internal static string ScopedResolvedFromRootException => GetString("ScopedResolvedFromRootException");

	internal static string DirectScopedResolvedFromRootException => GetString("DirectScopedResolvedFromRootException");

	internal static string FormatAmbiguousConstructorException(object p0)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("AmbiguousConstructorException"), p0);
	}

	internal static string FormatCannotResolveService(object p0, object p1)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("CannotResolveService"), p0, p1);
	}

	internal static string FormatCircularDependencyException(object p0)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("CircularDependencyException"), p0);
	}

	internal static string FormatUnableToActivateTypeException(object p0)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("UnableToActivateTypeException"), p0);
	}

	internal static string FormatOpenGenericServiceRequiresOpenGenericImplementation(object p0)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("OpenGenericServiceRequiresOpenGenericImplementation"), p0);
	}

	internal static string FormatTypeCannotBeActivated(object p0, object p1)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("TypeCannotBeActivated"), p0, p1);
	}

	internal static string FormatNoConstructorMatch(object p0)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("NoConstructorMatch"), p0);
	}

	internal static string FormatScopedInSingletonException(object p0, object p1, object p2, object p3)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("ScopedInSingletonException"), p0, p1, p2, p3);
	}

	internal static string FormatScopedResolvedFromRootException(object p0, object p1, object p2)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("ScopedResolvedFromRootException"), p0, p1, p2);
	}

	internal static string FormatDirectScopedResolvedFromRootException(object p0, object p1)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("DirectScopedResolvedFromRootException"), p0, p1);
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

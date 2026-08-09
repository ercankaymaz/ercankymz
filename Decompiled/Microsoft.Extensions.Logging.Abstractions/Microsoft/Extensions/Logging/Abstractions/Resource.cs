using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Microsoft.Extensions.Logging.Abstractions;

internal static class Resource
{
	private static readonly ResourceManager _resourceManager = new ResourceManager("Microsoft.Extensions.Logging.Abstractions.Resource", typeof(Resource).GetTypeInfo().Assembly);

	internal static string UnexpectedNumberOfNamedParameters => GetString("UnexpectedNumberOfNamedParameters");

	internal static string FormatUnexpectedNumberOfNamedParameters(object p0, object p1, object p2)
	{
		return string.Format(CultureInfo.CurrentCulture, GetString("UnexpectedNumberOfNamedParameters"), p0, p1, p2);
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

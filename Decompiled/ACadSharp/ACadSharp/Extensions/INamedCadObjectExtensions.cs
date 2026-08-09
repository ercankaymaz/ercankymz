namespace ACadSharp.Extensions;

public static class INamedCadObjectExtensions
{
	public static readonly char[] InvalidCharacters = new char[13]
	{
		'\\', '/', ':', '*', '?', '"', '<', '>', '|', ';',
		',', '=', '`'
	};

	public static bool IsValidDxfName(this INamedCadObject namedCadObject, ACadVersion version = ACadVersion.AC1032)
	{
		if (string.IsNullOrEmpty(namedCadObject.Name))
		{
			return false;
		}
		if (version <= ACadVersion.AC1015 && namedCadObject.Name.Length > 31)
		{
			return false;
		}
		if (namedCadObject.Name.Length > 255)
		{
			return false;
		}
		return namedCadObject.Name.IndexOfAny(InvalidCharacters) == -1;
	}
}
